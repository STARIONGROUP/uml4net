// -------------------------------------------------------------------------------------------------
// <copyright file="ISubstitution.cs" company="Starion Group S.A.">
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
    using uml4net.POCO.CommonStructure;

    /// <summary>
    /// A substitution is a relationship between two classifiers signifying that the substituting classifier 
    /// complies with the contract specified by the contract classifier. This implies that instances of the 
    /// substituting classifier are runtime substitutable where instances of the contract classifier are expected.
    /// </summary>
    public interface ISubstitution : IRealization
    {
        /// <summary>
        /// The contract with which the substituting classifier complies.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1)]
        public IClassifier Contract { get; set; }

        /// <summary>
        /// Instances of the substituting classifier are runtime substitutable where instances
        /// of the contract classifier are expected.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1)]
        [SubsettedProperty(propertyName: "Dependency.Client")]
        [SubsettedProperty(propertyName: "Element.Owner")]
        public IClassifier SubstitutingClassifier { get; set; }
    }
}
