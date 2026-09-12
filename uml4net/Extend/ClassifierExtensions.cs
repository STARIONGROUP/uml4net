// -------------------------------------------------------------------------------------------------
// <copyright file="ClassifierExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.Classification
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using uml4net.CommonStructure;
    using uml4net.Deployments;
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;
    using uml4net.Values;

    /// <summary>
    /// The <see cref="ClassifierExtensions"/> class provides extensions methods for <see cref="IClassifier"/>
    /// </summary>
    internal static class ClassifierExtensions
    {
        /// <summary>
        /// Queries All of the Properties that are direct (i.e., not inherited or imported) attributes of the
        /// Classifier.
        /// </summary>
        /// <param name="element">
        /// The subject <see cref="IClassifier"/>
        /// </param>
        /// <returns>
        /// All of the Properties that are direct (i.e., not inherited or imported) attributes of the
        /// Classifier.
        /// </returns>
        /// <remarks>
        /// Confirmed against the raw <c>resources/UML/UML.xmi</c>: exactly 6 properties directly
        /// subset <c>Classifier-attribute</c> - <see cref="IClass.OwnedAttribute"/> (which redefines,
        /// and must therefore be checked ahead of, <see cref="IStructuredClassifier.OwnedAttribute"/>),
        /// <see cref="IStructuredClassifier.OwnedAttribute"/> itself, <see cref="IInterface.OwnedAttribute"/>,
        /// <see cref="IDataType.OwnedAttribute"/> (which also covers <c>Enumeration</c>, a <c>DataType</c>
        /// that does not redefine or add its own), <see cref="ISignal.OwnedAttribute"/>, and
        /// <see cref="IArtifact.OwnedAttribute"/>. Every other <see cref="IClassifier"/> (e.g.
        /// <c>Association</c>, <c>UseCase</c>, <c>Actor</c>) genuinely has no attributes, so falls
        /// through to an empty list rather than throwing - <c>Association-ownedEnd</c> does NOT
        /// subset <c>Classifier-attribute</c> (it subsets <c>Classifier-feature</c> and
        /// <c>Namespace-ownedMember</c> instead), so returning it here for an <see cref="IAssociation"/>
        /// would have been incorrect.
        /// </remarks>
        internal static List<IProperty> QueryAttribute(this IClassifier element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            if (element is IClass @class)
            {
                return @class.OwnedAttribute.ToList();
            }

            if (element is IStructuredClassifier structuredClassifier)
            {
                return structuredClassifier.OwnedAttribute.ToList();
            }

            if (element is IInterface @interface)
            {
                return @interface.OwnedAttribute.ToList();
            }

            if (element is IDataType dataType)
            {
                return dataType.OwnedAttribute.ToList();
            }

            if (element is ISignal signal)
            {
                return signal.OwnedAttribute.ToList();
            }

            if (element is IArtifact artifact)
            {
                return artifact.OwnedAttribute.ToList();
            }

            return new List<IProperty>();
        }

        /// <summary>
        /// Queries each Feature directly defined in the classifier. Note that there may be members of the
        /// Classifier that are of the type Feature but are not included, e.g., inherited features.
        /// </summary>
        /// <param name="element">
        /// The subject <see cref="IClassifier"/>
        /// </param>
        /// <returns>
        /// each Feature directly defined in the classifier. Note that there may be members of the
        /// Classifier that are of the type Feature but are not included, e.g., inherited features.
        /// </returns>
        /// <remarks>
        /// Has no OCL body in the metamodel - like <see cref="QueryAttribute"/> and
        /// <see cref="NamespaceExtensions.QueryOwnedMember"/>, it is defined purely by the UML
        /// derived union mechanism. Confirmed against the raw <c>resources/UML/UML.xmi</c>: exactly
        /// 9 properties across 7 interfaces directly subset <c>Classifier-feature</c> -
        /// <see cref="IAssociation.OwnedEnd"/>, <see cref="IClass.OwnedOperation"/>,
        /// <see cref="IClass.OwnedReception"/>, <see cref="IStructuredClassifier.OwnedConnector"/>,
        /// <see cref="IDataType.OwnedOperation"/>, <see cref="IInterface.OwnedOperation"/>,
        /// <see cref="IInterface.OwnedReception"/>, <see cref="IArtifact.OwnedOperation"/>, and
        /// <c>Classifier-attribute</c> itself (<see cref="QueryAttribute"/>, which itself subsets
        /// this property). This is deliberately NOT implemented as a filter over
        /// <c>Namespace.Member</c> even though <c>Classifier-feature</c> also subsets
        /// <c>Namespace-member</c>: that subsetting relationship is a consistency constraint (every
        /// Feature must also appear as a Namespace member), not the formula that populates this
        /// derived union - <c>Namespace.Member</c> additionally includes <c>ImportedMember</c>, which
        /// would wrongly include Features that are merely imported, not "directly defined in the
        /// classifier" as this property's own documentation requires.
        /// </remarks>
        internal static List<IFeature> QueryFeature(this IClassifier element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            var result = new List<IFeature>();

            result.AddRange(element.QueryAttribute());

            if (element is IAssociation association)
            {
                result.AddRange(association.OwnedEnd);
            }

            if (element is IClass @class)
            {
                result.AddRange(@class.OwnedOperation);
                result.AddRange(@class.OwnedReception);
            }

            if (element is IStructuredClassifier structuredClassifier)
            {
                result.AddRange(structuredClassifier.OwnedConnector);
            }

            if (element is IDataType dataType)
            {
                result.AddRange(dataType.OwnedOperation);
            }

            if (element is IInterface @interface)
            {
                result.AddRange(@interface.OwnedOperation);
                result.AddRange(@interface.OwnedReception);
            }

            if (element is IArtifact artifact)
            {
                result.AddRange(artifact.OwnedOperation);
            }

            return result.Distinct().ToList();
        }

        /// <summary>
        /// Gets the collection of <see cref="IClassifier"/>s that represent the generalizations of the specified <paramref name="element"/>.
        /// </summary>
        /// <param name="element">The <see cref="IClassifier"/> for which to retrieve the generalizations.</param>
        /// <returns>
        /// A list of <see cref="IClassifier"/> objects that represent the generalizations of the specified <paramref name="element"/>. 
        /// If the element does not have any generalizations, an empty list will be returned.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        internal static List<IClassifier> QueryGeneral(this IClassifier element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            return element.Generalization.Select(x => x.General).ToList();
        }

        /// <summary>
        /// Queries All elements inherited by this Classifier from its general Classifiers
        /// </summary>
        /// <param name="element">
        /// The subject <see cref="IClassifier"/>
        /// </param>
        /// <returns>
        /// All elements inherited by this Classifier from its general Classifiers.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        internal static List<INamedElement> QueryInheritedMember(this IClassifier element)
        {
            throw new NotSupportedException("Create a GitHub issue when this method is required");
        }

        /// <summary>
        /// Queries the transitive closure of this Classifier's direct and indirect general Classifiers.
        /// </summary>
        /// <param name="element">
        /// The subject <see cref="IClassifier"/>
        /// </param>
        /// <returns>
        /// every <see cref="IClassifier"/> that this Classifier generalizes, directly or indirectly.
        /// </returns>
        internal static List<IClassifier> QueryAllGeneralClassifiers(this IClassifier element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            var result = new List<IClassifier>();
            var visited = new HashSet<IClassifier>();
            var elementsToProcess = new Stack<IClassifier>(element.QueryGeneral());

            while (elementsToProcess.Count > 0)
            {
                var current = elementsToProcess.Pop();

                if (!visited.Add(current))
                {
                    continue;
                }

                result.Add(current);

                foreach (var generalClassifier in current.QueryGeneral())
                {
                    elementsToProcess.Push(generalClassifier);
                }
            }

            return result;
        }

        /// <summary>
        /// Queries the Interfaces that this Classifier realizes directly, via its own client Dependencies.
        /// </summary>
        /// <param name="element">
        /// The subject <see cref="IClassifier"/>
        /// </param>
        /// <returns>
        /// the Interfaces realized directly by this Classifier.
        /// </returns>
        internal static List<IInterface> QueryDirectlyRealizedInterfaces(this IClassifier element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            return element.QueryClientDependency()
                .OfType<IRealization>()
                .Where(realization => realization.Supplier.All(supplier => supplier is IInterface))
                .SelectMany(realization => realization.Supplier.Cast<IInterface>())
                .Distinct()
                .ToList();
        }

        /// <summary>
        /// Queries the Interfaces that this Classifier uses directly, via its own supplier Dependencies.
        /// </summary>
        /// <param name="element">
        /// The subject <see cref="IClassifier"/>
        /// </param>
        /// <returns>
        /// the Interfaces used directly by this Classifier.
        /// </returns>
        internal static List<IInterface> QueryDirectlyUsedInterfaces(this IClassifier element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            return element.QuerySupplierDependency()
                .OfType<IUsage>()
                .Where(usage => usage.Client.All(client => client is IInterface))
                .SelectMany(usage => usage.Client.Cast<IInterface>())
                .Distinct()
                .ToList();
        }

        /// <summary>
        /// Queries the Interfaces that this Classifier realizes, directly or through any of its
        /// direct or indirect general Classifiers.
        /// </summary>
        /// <param name="element">
        /// The subject <see cref="IClassifier"/>
        /// </param>
        /// <returns>
        /// the Interfaces realized by this Classifier or any of its direct or indirect general Classifiers.
        /// </returns>
        internal static List<IInterface> QueryAllRealizedInterfaces(this IClassifier element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            return element.QueryDirectlyRealizedInterfaces()
                .Concat(element.QueryAllGeneralClassifiers().SelectMany(generalClassifier => generalClassifier.QueryDirectlyRealizedInterfaces()))
                .Distinct()
                .ToList();
        }

        /// <summary>
        /// Queries the Interfaces that this Classifier uses, directly or through any of its
        /// direct or indirect general Classifiers.
        /// </summary>
        /// <param name="element">
        /// The subject <see cref="IClassifier"/>
        /// </param>
        /// <returns>
        /// the Interfaces used by this Classifier or any of its direct or indirect general Classifiers.
        /// </returns>
        internal static List<IInterface> QueryAllUsedInterfaces(this IClassifier element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            return element.QueryDirectlyUsedInterfaces()
                .Concat(element.QueryAllGeneralClassifiers().SelectMany(generalClassifier => generalClassifier.QueryDirectlyUsedInterfaces()))
                .Distinct()
                .ToList();
        }
    }
}
