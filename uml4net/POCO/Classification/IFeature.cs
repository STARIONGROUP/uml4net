﻿// -------------------------------------------------------------------------------------------------
// <copyright file="IFeature.cs" company="Starion Group S.A.">
//
//   Copyright 2019-2024 Starion Group S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, softwareUseCases
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.POCO.Classification
{
    using uml4net.Decorators;

    /// <summary>
    /// A Feature declares a behavioral or structural characteristic of Classifiers.
    /// </summary>
    public interface IFeature : IRedefinableElement
    {
        /// <summary>
        /// The Classifiers that have this Feature as a feature.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isReadOnly:true, isDerived:true, isDerivedUnion:true)]
        public IClassifier FeaturingClassifier { get; }

        /// <summary>
        /// Specifies whether this Feature characterizes individual instances classified by the Classifier (false)
        /// or the Classifier itself (true).
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, defaultValue:"false")]
        public bool IsStatic { get; set; }
    }
}
