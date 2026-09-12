// -------------------------------------------------------------------------------------------------
// <copyright file="FeatureExtensions.cs" company="Starion Group S.A.">
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

    using uml4net.CommonStructure;

    /// <summary>
    /// The <see cref="FeatureExtensions"/> class provides extensions methods for <see cref="IFeature"/>
    /// </summary>
    internal static class FeatureExtensions
    {
        /// <summary>
        /// Queries The Classifiers that have this Feature as a feature.
        /// </summary>
        /// <param name="feature">
        /// The subject <see cref="IFeature"/>
        /// </param>
        /// <returns>
        /// The Classifiers that have this Feature as a feature.
        /// </returns>
        /// <remarks>
        /// Subsets <c>NamedElement::/memberNamespace</c> and has no OCL body of its own. Confirmed
        /// against both the raw <c>resources/UML/UML.xmi</c> and the uml4net-sage knowledge base's
        /// <c>Feature.md</c> that this property is scalar (<c>[0..1]</c>), matching the generated
        /// <see cref="IFeature.FeaturingClassifier"/> contract - NOT a collection, despite the
        /// abstract possibility of a Feature being shared by several Classifiers (e.g. via Interface
        /// realization) that the property's own name might suggest. Every one of the 9 properties
        /// that populate <see cref="ClassifierExtensions.QueryFeature"/> (#306) - e.g.
        /// <c>Class.OwnedOperation</c>, <c>StructuredClassifier.OwnedConnector</c>,
        /// <c>Association.OwnedEnd</c> - is a composite/owned relationship, so the Classifier that
        /// features a given Feature is always exactly its composite <see cref="IElement.Owner"/>.
        /// This does NOT need to depend on or search through <see cref="ClassifierExtensions.QueryFeature"/>
        /// itself, despite the issue's own assumption that it would.
        /// </remarks>
        internal static IClassifier QueryFeaturingClassifier(this IFeature feature)
        {
            if (feature == null)
            {
                throw new ArgumentNullException(nameof(feature));
            }

            return feature.Owner as IClassifier;
        }
    }
}
