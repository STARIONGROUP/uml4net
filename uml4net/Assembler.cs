// -------------------------------------------------------------------------------------------------
// <copyright file="Assembler.cs" company="Starion Group S.A.">
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

namespace uml4net
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    
    using Microsoft.Extensions.Logging;

    using uml4net.CommonStructure;
    using uml4net.Decorators;

    /// <summary>
    /// The purpose of the Assembler is to resolve all the reference properties of the objects
    /// after deserialization to construct a complete object graph
    /// </summary>
    public class Assembler : IAssembler
    {
        /// <summary>
        /// The <see cref="ILogger"/> used to log
        /// </summary>
        private readonly ILogger<Assembler> logger;

        /// <summary>
        /// The <see cref="IXmiElementCache"/>
        /// </summary>
        private readonly IXmiElementCache cache;

        /// <summary>
        /// The references that could not be resolved by the most recent <see cref="Synchronize"/>
        /// </summary>
        private readonly List<XmiReferenceResolutionFailure> resolutionFailures = [];

        /// <summary>
        /// Initializes a new <see cref="Assembler"/>
        /// </summary>
        /// <param name="logger">The <see cref="ILogger{T}"/></param>
        /// <param name="cache">The <see cref="IXmiElementCache"/></param>
        public Assembler(ILogger<Assembler> logger, IXmiElementCache cache)
        {
            this.logger = logger;
            this.cache = cache;
        }

        /// <summary>
        /// Gets the references that could not be resolved by the most recent <see cref="Synchronize"/>
        /// </summary>
        public IReadOnlyList<XmiReferenceResolutionFailure> ResolutionFailures => this.resolutionFailures;

        /// <summary>
        /// Synchronizes the <see cref="IXmiElement"/>s in the <see cref="IXmiElementCache"/> by assigning
        /// the reference properties that are encoded by <see cref="IXmiElement.SingleValueReferencePropertyIdentifiers"/>
        /// and by <see cref="IXmiElement.MultiValueReferencePropertyIdentifiers"/>
        /// </summary>
        public void Synchronize()
        {
            this.resolutionFailures.Clear();

            foreach (var kvp in this.cache)
            {
                this.ResolveReferences(kvp.Value);
            }
        }

        /// <summary>
        /// Resolves single and multi-value references for the given element using the provided cache.
        /// </summary>
        /// <param name="element">The element whose references are to be resolved.</param>
        private void ResolveReferences(IXmiElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            foreach (var property in element.SingleValueReferencePropertyIdentifiers)
            {
                if (!this.TryGetReferencedElement(element.DocumentName,property.Value, out var referencedElement))
                {
                    this.logger.LogWarning("The reference to [{Reference}] for property [{Key}] on element type [{Element}] with id [{Id}] was not found in the cache, probably because its type is not supported.",
                        property.Value, property.Key, element.XmiType, element.XmiId);

                    this.RecordResolutionFailure(element, property.Key, property.Value, XmiReferenceResolutionFailureKind.NotFound);
                    continue;
                }

                var targetProperty = FindPropertyWithAttribute(element, property.Key, referencedElement.GetType());

                if (targetProperty is null)
                {
                    throw new InvalidOperationException($"The target property {property.Key} was not found on {element.GetType().Name} or the property type doesn't match the referenced {nameof(element)} type");
                }

                targetProperty.SetValue(element, referencedElement);

                RemoveResolvedReference(element, property.Key, property.Value);
            }

            foreach (var property in element.MultiValueReferencePropertyIdentifiers)
            {
                var targetProperty = FindPropertyWithAttribute(element, property.Key);
                var underlyingType = targetProperty?.PropertyType.GetGenericArguments().FirstOrDefault();

                if (targetProperty is null || underlyingType is null)
                {
                    throw new KeyNotFoundException($"The target property {property.Key} was not found on {element.GetType().Name} or the type is null");
                }

                var resolvedReferences = this.ResolveMultiValueReferences(element, property.Value, property.Key, underlyingType);

                if (targetProperty.GetValue(element) is not IList list)
                {
                    continue;
                }

                foreach (var resolvedReference in resolvedReferences)
                {
                    list.Add(resolvedReference);
                }
            }

            this.ResolveCompositeReferences(element);
        }

        /// <summary>
        /// Resolves the proxies (<c>xmi:idref</c> or <c>href</c>) of the composite properties of the given element,
        /// by adding the referenced definition to the composite property at the position of its proxy, and by
        /// making the given element its owner (XMI 2.5.1 clause 7.10.1)
        /// </summary>
        /// <param name="element">The element whose composite properties contain proxies.</param>
        /// <remarks>
        /// A definition that is already owned by another element is not taken away from that owner, since an
        /// element has exactly one owner. Proxies that cannot be resolved are kept, so that a later
        /// synchronization can resolve them.
        /// </remarks>
        private void ResolveCompositeReferences(IXmiElement element)
        {
            if (element.CompositeReferencePropertyIdentifiers.Count == 0)
            {
                return;
            }

            if (element is not IElement owner)
            {
                throw new InvalidOperationException($"The composite references of {element.GetType().Name} cannot be resolved since it is not an {nameof(IElement)}");
            }

            foreach (var property in element.CompositeReferencePropertyIdentifiers)
            {
                var targetProperty = FindPropertyWithAttribute(element, property.Key);
                var underlyingType = targetProperty?.PropertyType.GetGenericArguments().FirstOrDefault();

                if (targetProperty is null || underlyingType is null)
                {
                    throw new KeyNotFoundException($"The target property {property.Key} was not found on {element.GetType().Name} or the type is null");
                }

                if (targetProperty.GetValue(element) is not IList list)
                {
                    continue;
                }

                var unresolvedCompositeReferences = new List<XmiCompositeReference>();

                foreach (var compositeReference in property.Value.OrderBy(x => x.Position))
                {
                    var isFound = this.TryGetReferencedElement(element.DocumentName, compositeReference.Identifier, out var referencedElement);

                    if (!isFound || !underlyingType.IsInstanceOfType(referencedElement) || referencedElement is not IElement ownedElement)
                    {
                        this.logger.LogWarning("The proxy [{Reference}] for composite property [{Key}] on element type [{Element}] with id [{Id}] was not found in the cache, or its type is not supported.",
                            compositeReference.Identifier, property.Key, element.XmiType, element.XmiId);

                        this.RecordResolutionFailure(element, property.Key, compositeReference.Identifier,
                            isFound ? XmiReferenceResolutionFailureKind.UnexpectedType : XmiReferenceResolutionFailureKind.NotFound);

                        unresolvedCompositeReferences.Add(compositeReference);
                        continue;
                    }

                    if (ReferenceEquals(ownedElement, owner) || list.Contains(ownedElement))
                    {
                        RemoveResolvedReference(element, property.Key, compositeReference.Identifier);
                        continue;
                    }

                    if (ownedElement.Possessor != null && !ReferenceEquals(ownedElement.Possessor, owner))
                    {
                        this.logger.LogWarning("The proxy [{Reference}] for composite property [{Key}] on element type [{Element}] with id [{Id}] refers to an element that is already owned by another element; the proxy is ignored.",
                            compositeReference.Identifier, property.Key, element.XmiType, element.XmiId);

                        this.RecordResolutionFailure(element, property.Key, compositeReference.Identifier, XmiReferenceResolutionFailureKind.AlreadyOwned);

                        unresolvedCompositeReferences.Add(compositeReference);
                        continue;
                    }

                    var index = Math.Min(Math.Max(compositeReference.Position - unresolvedCompositeReferences.Count, 0), list.Count);

                    list.Insert(index, ownedElement);
                    ownedElement.Possessor = owner;

                    RemoveResolvedReference(element, property.Key, compositeReference.Identifier);
                }

                property.Value.Clear();
                property.Value.AddRange(unresolvedCompositeReferences);
            }
        }

        /// <summary>
        /// Records a reference that could not be resolved in the <see cref="ResolutionFailures"/>
        /// </summary>
        /// <param name="element">
        /// The <see cref="IXmiElement"/> that declares the reference
        /// </param>
        /// <param name="propertyName">
        /// The name of the property that holds the reference
        /// </param>
        /// <param name="identifier">
        /// The identifier of the referenced element
        /// </param>
        /// <param name="kind">
        /// The <see cref="XmiReferenceResolutionFailureKind"/> that specifies why the reference could not be resolved
        /// </param>
        private void RecordResolutionFailure(IXmiElement element, string propertyName, string identifier, XmiReferenceResolutionFailureKind kind)
        {
            this.resolutionFailures.Add(new XmiReferenceResolutionFailure
            {
                DocumentName = element.DocumentName,
                ElementXmiId = element.XmiId,
                ElementXmiType = element.XmiType,
                PropertyName = propertyName,
                Identifier = identifier,
                Kind = kind
            });
        }

        /// <summary>
        /// Try to get an <see cref="IXmiElement"/> from th cache based on the provided
        /// <paramref name="documentName"/> and <paramref name="referenceIdKey"/>
        /// </summary>
        /// <param name="documentName">
        /// The name of the document or resource from where the <see cref="IXmiElement"/> was parsed/read
        /// </param>
        /// <param name="referenceIdKey">
        /// The unique identifier of the <see cref="IXmiElement"/> that is to be retrieved
        /// </param>
        /// <param name="element">
        /// The found <see cref="IXmiElement"/>, null if not found
        /// </param>
        /// <returns>
        /// true if found, false if not
        /// </returns>
        private bool TryGetReferencedElement(string documentName, string referenceIdKey, out IXmiElement element)
        {
            var hashIndex = referenceIdKey.IndexOf('#');

            // hashIndex > 0  -> a document part is present (e.g. "file#id"), use as-is
            // otherwise      -> bare id ("id") or bare same-document fragment ("#id"),
            //                   resolve within the current document
            var key = hashIndex > 0
                ? referenceIdKey
                : $"{documentName}#{referenceIdKey.TrimStart('#')}";

            return this.cache.TryGetValue(key, out element);
        }

        /// <summary>
        /// resolves multi-valued reference properties
        /// </summary>
        /// <param name="element">
        /// The <see cref="IXmiElement"/> that declares the multi-valued reference property
        /// </param>
        /// <param name="propertyValues">
        /// The values of the property, which are references by unique identifier to other <see cref="IXmiElement"/>s
        /// </param>
        /// <param name="key">
        /// The name of the property for which the references to other <see cref="IXmiElement"/>s are being resolved
        /// </param>
        /// <param name="expectedType"></param>
        /// <returns></returns>
        private List<IXmiElement> ResolveMultiValueReferences(IXmiElement element, IEnumerable<string> propertyValues, string key, Type expectedType)
        {
            var resolvedReferences = new List<IXmiElement>();

            foreach (var propertyValue in propertyValues)
            {
                var isFound = this.TryGetReferencedElement(element.DocumentName, propertyValue, out var referencedElement);

                if (!isFound || !expectedType.IsInstanceOfType(referencedElement))
                {
                    this.logger.LogWarning("The reference with the id [{Key}] to [{PropertyValue}] was not found in the cache, probably because its type is not supported.", key, propertyValue);

                    this.RecordResolutionFailure(element, key, propertyValue,
                        isFound ? XmiReferenceResolutionFailureKind.UnexpectedType : XmiReferenceResolutionFailureKind.NotFound);
                    continue;
                }

                resolvedReferences.Add(referencedElement);

                RemoveResolvedReference(element, key, propertyValue);
            }

            return resolvedReferences;
        }

        /// <summary>
        /// Removes the reference element that was preserved in its original XMI form while reading from the
        /// <see cref="IXmiElement.UnresolvedReferences"/> of the provided <see cref="IXmiElement"/>, since the
        /// reference has been resolved and is written from the reference property that it has been assigned to
        /// </summary>
        /// <param name="element">
        /// The <see cref="IXmiElement"/> that declares the reference
        /// </param>
        /// <param name="propertyName">
        /// The name of the reference property through which the referenced <see cref="IXmiElement"/> is reached
        /// </param>
        /// <param name="referenceIdentifier">
        /// The unique identifier of the referenced <see cref="IXmiElement"/>
        /// </param>
        private static void RemoveResolvedReference(IXmiElement element, string propertyName, string referenceIdentifier)
        {
            if (element.UnresolvedReferences.Count == 0)
            {
                return;
            }

            element.UnresolvedReferences.RemoveAll(x => x.PropertyName == propertyName && x.Identifier == referenceIdentifier);
        }

        /// <summary>
        /// Finds a property in the given element that has the <see cref="PropertyAttribute"/> and matches the specified property name and type.
        /// </summary>
        /// <param name="element">The element whose properties are to be searched.</param>
        /// <param name="propertyName">The name of the property to find.</param>
        /// <param name="expectedType">The expected type of the property. If null, type checking is skipped.</param>
        /// <returns>The <see cref="PropertyInfo"/> of the found property, or null if no matching property is found.</returns>
        private static PropertyInfo FindPropertyWithAttribute(IXmiElement element, string propertyName, Type? expectedType = null)
        {
            return element.GetType().GetProperties()
                .FirstOrDefault(x => Attribute.IsDefined(x, typeof(PropertyAttribute))
                                     && x.Name.Equals(propertyName, StringComparison.InvariantCultureIgnoreCase)
                                     && (expectedType == null || x.PropertyType.IsAssignableFrom(expectedType)));
        }
    }
}
