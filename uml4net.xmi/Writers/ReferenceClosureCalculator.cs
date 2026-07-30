// -------------------------------------------------------------------------------------------------
// <copyright file="ReferenceClosureCalculator.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2026 Starion Group S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Writers
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    using Microsoft.Extensions.Logging;

    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.Decorators;
    using uml4net.Packages;
    using uml4net.xmi.Settings;

    /// <summary>
    /// The purpose of the <see cref="ReferenceClosureCalculator"/> is to calculate the <see cref="XmiWritePlan"/>
    /// for a selected <see cref="IPackage"/>, which determines the elements that are serialized inside an
    /// XMI document and the root packages that the document contains.
    /// </summary>
    public class ReferenceClosureCalculator : IReferenceClosureCalculator
    {
        /// <summary>
        /// The cache of <see cref="TypeProperties"/> per concrete <see cref="IXmiElement"/> type.
        /// </summary>
        private static readonly ConcurrentDictionary<Type, TypeProperties> TypePropertiesCache = new ConcurrentDictionary<Type, TypeProperties>();

        /// <summary>
        /// The <see cref="ILogger"/> used to log
        /// </summary>
        private readonly ILogger<ReferenceClosureCalculator> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReferenceClosureCalculator"/> class.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger{T}"/></param>
        public ReferenceClosureCalculator(ILogger<ReferenceClosureCalculator> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Calculates the <see cref="XmiWritePlan"/> for the provided <see cref="IPackage"/>.
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> that is selected to be written
        /// </param>
        /// <param name="externalReferenceResolution">
        /// The <see cref="ExternalReferenceResolutionKind"/> that specifies how references to elements that are
        /// not contained by the <paramref name="package"/> are treated
        /// </param>
        /// <param name="documentName">
        /// The name of the document that is being written
        /// </param>
        /// <returns>
        /// The calculated <see cref="XmiWritePlan"/>
        /// </returns>
        public XmiWritePlan CalculateWritePlan(IPackage package, ExternalReferenceResolutionKind externalReferenceResolution, string documentName)
        {
            if (package == null)
            {
                throw new ArgumentNullException(nameof(package));
            }

            if (documentName == null)
            {
                throw new ArgumentNullException(nameof(documentName));
            }

            var localElements = new HashSet<IXmiElement>(ReferenceEqualityComparer.Instance);
            var localIdentifiers = new HashSet<string>();
            var elementsMissingXmiId = new List<IXmiElement>();
            var rootPackages = new List<IPackage> { package };

            CollectContainmentTree(package, localElements, localIdentifiers, elementsMissingXmiId);

            if (externalReferenceResolution == ExternalReferenceResolutionKind.Include)
            {
                this.IncludeExternalRootPackages(package, rootPackages, localElements, localIdentifiers, elementsMissingXmiId);
            }

            // A root package is written as a top-level element of the document, it is therefore never referred to
            // by means of an xmi:idref or an href. A missing XmiId on a root package - which is how Enterprise
            // Architect exports its uml:Model - is consequently harmless and is preserved as-is, rather than
            // being reported as an offender. For any contained element a missing XmiId remains an error since
            // such an element degrades into a dangling href and would lose its complete containment tree.
            elementsMissingXmiId.RemoveAll(element => rootPackages.Any(rootPackage => ReferenceEquals(rootPackage, element)));

            return new XmiWritePlan(rootPackages, localIdentifiers, elementsMissingXmiId);
        }

        /// <summary>
        /// Walks the external references of the selected <paramref name="package"/> and includes the root packages
        /// that contain those references into the <paramref name="rootPackages"/>, ordered by name.
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> that is selected to be written
        /// </param>
        /// <param name="rootPackages">
        /// The list of root packages that are written to the document; the selected <paramref name="package"/> is the first entry
        /// </param>
        /// <param name="localElements">
        /// The set of elements that are serialized inside the document that is being written
        /// </param>
        /// <param name="localIdentifiers">
        /// The <see cref="IXmiElement.FullyQualifiedIdentifier"/>s of the elements that are serialized inside the document
        /// </param>
        /// <param name="elementsMissingXmiId">
        /// The elements that are part of the document but do not have an <see cref="IXmiElement.XmiId"/>
        /// </param>
        private void IncludeExternalRootPackages(IPackage package, List<IPackage> rootPackages, HashSet<IXmiElement> localElements, HashSet<string> localIdentifiers, List<IXmiElement> elementsMissingXmiId)
        {
            var packagesToProcess = new Queue<IPackage>();
            packagesToProcess.Enqueue(package);

            while (packagesToProcess.Count > 0)
            {
                var packageToProcess = packagesToProcess.Dequeue();

                foreach (var externalElement in QueryExternalReferencedElements(packageToProcess, localElements))
                {
                    var rootPackage = QueryRootPackage(externalElement);

                    if (rootPackage == null)
                    {
                        this.logger.LogWarning("The externally referenced element with id [{XmiId}] is not contained by a root package and is written as an href reference", externalElement.XmiId);
                        continue;
                    }

                    if (localElements.Contains(rootPackage))
                    {
                        continue;
                    }

                    CollectContainmentTree(rootPackage, localElements, localIdentifiers, elementsMissingXmiId);
                    rootPackages.Add(rootPackage);
                    packagesToProcess.Enqueue(rootPackage);
                }
            }

            var includedPackages = rootPackages.Skip(1).OrderBy(x => x.Name, StringComparer.Ordinal).ToList();
            rootPackages.RemoveRange(1, rootPackages.Count - 1);
            rootPackages.AddRange(includedPackages);
        }

        /// <summary>
        /// Collects the complete containment tree of the provided <see cref="IXmiElement"/> into the provided sets.
        /// </summary>
        /// <param name="root">
        /// The <see cref="IXmiElement"/> from which the containment tree is walked
        /// </param>
        /// <param name="localElements">
        /// The set of elements that are serialized inside the document that is being written
        /// </param>
        /// <param name="localIdentifiers">
        /// The <see cref="IXmiElement.FullyQualifiedIdentifier"/>s of the elements that are serialized inside the document
        /// </param>
        /// <param name="elementsMissingXmiId">
        /// The elements that are part of the document but do not have an <see cref="IXmiElement.XmiId"/>
        /// </param>
        private static void CollectContainmentTree(IXmiElement root, HashSet<IXmiElement> localElements, HashSet<string> localIdentifiers, List<IXmiElement> elementsMissingXmiId)
        {
            var elementsToProcess = new Stack<IXmiElement>();
            elementsToProcess.Push(root);

            while (elementsToProcess.Count > 0)
            {
                var element = elementsToProcess.Pop();

                if (!localElements.Add(element))
                {
                    continue;
                }

                if (string.IsNullOrEmpty(element.XmiId))
                {
                    elementsMissingXmiId.Add(element);
                }
                else
                {
                    localIdentifiers.Add(element.FullyQualifiedIdentifier);
                }

                foreach (var containedElement in QueryPropertyValues(QueryTypeProperties(element.GetType()).ContainmentProperties, element))
                {
                    elementsToProcess.Push(containedElement);
                }
            }
        }

        /// <summary>
        /// Queries the elements that are referenced from the containment tree of the provided <see cref="IPackage"/>
        /// but are not part of the provided set of local elements.
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> whose containment tree is inspected
        /// </param>
        /// <param name="localElements">
        /// The set of elements that are serialized inside the document that is being written
        /// </param>
        /// <returns>
        /// The externally referenced <see cref="IXmiElement"/>s
        /// </returns>
        private static IEnumerable<IXmiElement> QueryExternalReferencedElements(IPackage package, HashSet<IXmiElement> localElements)
        {
            var externalElements = new HashSet<IXmiElement>(ReferenceEqualityComparer.Instance);
            var visitedElements = new HashSet<IXmiElement>(ReferenceEqualityComparer.Instance);
            var elementsToProcess = new Stack<IXmiElement>();
            elementsToProcess.Push(package);

            while (elementsToProcess.Count > 0)
            {
                var element = elementsToProcess.Pop();

                if (!visitedElements.Add(element))
                {
                    continue;
                }

                var typeProperties = QueryTypeProperties(element.GetType());

                foreach (var containedElement in QueryPropertyValues(typeProperties.ContainmentProperties, element))
                {
                    elementsToProcess.Push(containedElement);
                }

                foreach (var referencedElement in QueryPropertyValues(typeProperties.ReferenceProperties, element).Where(x => !localElements.Contains(x)))
                {
                    externalElements.Add(referencedElement);
                }
            }

            return externalElements;
        }

        /// <summary>
        /// Queries the top-level root <see cref="IPackage"/> that contains the provided <see cref="IXmiElement"/>
        /// by walking up the <see cref="IElement.Possessor"/> chain.
        /// </summary>
        /// <param name="element">
        /// The <see cref="IXmiElement"/> for which the root package is queried
        /// </param>
        /// <returns>
        /// The root <see cref="IPackage"/>, or null when the <paramref name="element"/> is not contained by a root package
        /// </returns>
        private static IPackage QueryRootPackage(IXmiElement element)
        {
            if (!(element is IElement current))
            {
                return null;
            }

            while (current.Possessor != null)
            {
                current = current.Possessor;
            }

            return current as IPackage;
        }

        /// <summary>
        /// Queries the <see cref="IXmiElement"/> values of the provided properties on the provided element.
        /// </summary>
        /// <param name="propertyInfos">
        /// The <see cref="PropertyInfo"/>s of the properties whose values are queried
        /// </param>
        /// <param name="element">
        /// The <see cref="IXmiElement"/> on which the property values are queried
        /// </param>
        /// <returns>
        /// The <see cref="IXmiElement"/> values of the properties
        /// </returns>
        private static IEnumerable<IXmiElement> QueryPropertyValues(IEnumerable<PropertyInfo> propertyInfos, IXmiElement element)
        {
            foreach (var propertyInfo in propertyInfos)
            {
                foreach (var value in QueryPropertyValues(propertyInfo, element))
                {
                    yield return value;
                }
            }
        }

        /// <summary>
        /// Queries the <see cref="IXmiElement"/> values of the provided property on the provided element.
        /// </summary>
        /// <param name="propertyInfo">
        /// The <see cref="PropertyInfo"/> of the property whose values are queried
        /// </param>
        /// <param name="element">
        /// The <see cref="IXmiElement"/> on which the property values are queried
        /// </param>
        /// <returns>
        /// The <see cref="IXmiElement"/> values of the property
        /// </returns>
        private static IEnumerable<IXmiElement> QueryPropertyValues(PropertyInfo propertyInfo, IXmiElement element)
        {
            var value = propertyInfo.GetValue(element);

            switch (value)
            {
                case null:
                    yield break;

                case IXmiElement xmiElement:
                    yield return xmiElement;
                    break;

                case IEnumerable enumerable:
                    foreach (var item in enumerable.OfType<IXmiElement>())
                    {
                        yield return item;
                    }

                    break;
            }
        }

        /// <summary>
        /// Queries the <see cref="TypeProperties"/> for the provided type from the cache, classifying the
        /// properties of the type when the type has not been classified before.
        /// </summary>
        /// <param name="type">
        /// The concrete <see cref="IXmiElement"/> type whose properties are classified
        /// </param>
        /// <returns>
        /// The <see cref="TypeProperties"/> of the provided type
        /// </returns>
        private static TypeProperties QueryTypeProperties(Type type)
        {
            return TypePropertiesCache.GetOrAdd(type, ClassifyTypeProperties);
        }

        /// <summary>
        /// Classifies the properties of the provided type into containment properties and reference properties,
        /// mirroring the classification that is used by the generated readers and writers.
        /// </summary>
        /// <param name="type">
        /// The concrete <see cref="IXmiElement"/> type whose properties are classified
        /// </param>
        /// <returns>
        /// The <see cref="TypeProperties"/> of the provided type
        /// </returns>
        private static TypeProperties ClassifyTypeProperties(Type type)
        {
            var containmentProperties = new List<PropertyInfo>();
            var referenceProperties = new List<PropertyInfo>();

            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var propertyInfo in properties)
            {
                var propertyAttribute = propertyInfo.GetCustomAttribute<PropertyAttribute>();

                if (propertyAttribute == null || propertyAttribute.IsDerived || propertyAttribute.IsDerivedUnion || propertyAttribute.IsReadOnly)
                {
                    continue;
                }

                if (!QueryIsXmiElementProperty(propertyInfo))
                {
                    continue;
                }

                if (propertyAttribute.Aggregation == AggregationKind.Composite && !QueryIsCompositeSerializedAsReference(propertyInfo, properties))
                {
                    containmentProperties.Add(propertyInfo);
                }
                else
                {
                    referenceProperties.Add(propertyInfo);
                }
            }

            return new TypeProperties(containmentProperties, referenceProperties);
        }

        /// <summary>
        /// Queries whether the provided property holds one or more <see cref="IXmiElement"/> values.
        /// </summary>
        /// <param name="propertyInfo">
        /// The <see cref="PropertyInfo"/> of the property that is checked
        /// </param>
        /// <returns>
        /// true when the property holds <see cref="IXmiElement"/> values, false otherwise
        /// </returns>
        private static bool QueryIsXmiElementProperty(PropertyInfo propertyInfo)
        {
            var propertyType = propertyInfo.PropertyType;

            if (propertyType.IsGenericType && propertyType.GenericTypeArguments.Length == 1)
            {
                propertyType = propertyType.GenericTypeArguments[0];
            }

            return typeof(IXmiElement).IsAssignableFrom(propertyType);
        }

        /// <summary>
        /// Queries whether the provided composite property is serialized as a reference, which is the case when
        /// the property has subsetted properties that are all non-derived. This mirrors the behavior of the
        /// generated readers and writers.
        /// </summary>
        /// <param name="propertyInfo">
        /// The <see cref="PropertyInfo"/> of the composite property that is checked
        /// </param>
        /// <param name="properties">
        /// All public instance properties of the type that declares the <paramref name="propertyInfo"/>
        /// </param>
        /// <returns>
        /// true when the composite property is serialized as a reference, false when it is serialized as contained content
        /// </returns>
        private static bool QueryIsCompositeSerializedAsReference(PropertyInfo propertyInfo, PropertyInfo[] properties)
        {
            var subsettedPropertyAttributes = propertyInfo.GetCustomAttributes<SubsettedPropertyAttribute>().ToList();

            if (subsettedPropertyAttributes.Count == 0)
            {
                return false;
            }

            foreach (var subsettedPropertyAttribute in subsettedPropertyAttributes)
            {
                var subsettedProperty = properties
                    .Select(x => x.GetCustomAttribute<PropertyAttribute>())
                    .FirstOrDefault(x => x != null && x.XmiId == subsettedPropertyAttribute.PropertyName);

                if (subsettedProperty == null || subsettedProperty.IsDerived || subsettedProperty.IsDerivedUnion || subsettedProperty.IsReadOnly)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// The <see cref="TypeProperties"/> class captures the classified containment and reference properties of a type.
        /// </summary>
        private sealed class TypeProperties
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="TypeProperties"/> class.
            /// </summary>
            /// <param name="containmentProperties">
            /// The properties through which the containment tree is walked
            /// </param>
            /// <param name="referenceProperties">
            /// The properties that reference other <see cref="IXmiElement"/>s
            /// </param>
            public TypeProperties(List<PropertyInfo> containmentProperties, List<PropertyInfo> referenceProperties)
            {
                this.ContainmentProperties = containmentProperties;
                this.ReferenceProperties = referenceProperties;
            }

            /// <summary>
            /// Gets the properties through which the containment tree is walked.
            /// </summary>
            public List<PropertyInfo> ContainmentProperties { get; }

            /// <summary>
            /// Gets the properties that reference other <see cref="IXmiElement"/>s.
            /// </summary>
            public List<PropertyInfo> ReferenceProperties { get; }
        }

        /// <summary>
        /// An <see cref="IEqualityComparer{T}"/> that compares <see cref="IXmiElement"/>s by reference.
        /// </summary>
        private sealed class ReferenceEqualityComparer : IEqualityComparer<IXmiElement>
        {
            /// <summary>
            /// Gets the singleton instance of the <see cref="ReferenceEqualityComparer"/>.
            /// </summary>
            public static readonly ReferenceEqualityComparer Instance = new ReferenceEqualityComparer();

            /// <summary>
            /// Determines whether the provided <see cref="IXmiElement"/>s are the same instance.
            /// </summary>
            /// <param name="x">The first <see cref="IXmiElement"/> to compare</param>
            /// <param name="y">The second <see cref="IXmiElement"/> to compare</param>
            /// <returns>true when both are the same instance, false otherwise</returns>
            public bool Equals(IXmiElement x, IXmiElement y)
            {
                return ReferenceEquals(x, y);
            }

            /// <summary>
            /// Returns the identity-based hash code of the provided <see cref="IXmiElement"/>.
            /// </summary>
            /// <param name="obj">The <see cref="IXmiElement"/> for which the hash code is returned</param>
            /// <returns>the identity-based hash code</returns>
            public int GetHashCode(IXmiElement obj)
            {
                return RuntimeHelpers.GetHashCode(obj);
            }
        }
    }
}
