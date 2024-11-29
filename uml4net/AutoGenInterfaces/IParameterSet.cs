// -------------------------------------------------------------------------------------------------
// <copyright file="IParameterSet.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;

    using uml4net.Decorators;
    using uml4net.POCO.CommonStructure;

    /// <summary>
    /// A ParameterSet designates alternative sets of inputs or outputs that a Behavior may use.
    /// </summary>
    public interface IParameterSet : INamedElement
    {
        /// <summary>
        /// A constraint that should be satisfied for the owner of the Parameters in an input ParameterSet
        /// to start execution using the values provided for those Parameters, or the owner of the Parameters
        /// in an output ParameterSet to end execution providing the values for those Parameters, if all
        /// preconditions and conditions on input ParameterSets were satisfied.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty("Element-ownedElement")]
        public List<IConstraint> Condition { get; set; }

        /// <summary>
        /// Parameters in the ParameterSet.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue)]
        public List<IParameter> Parameter { get; set; }
    }
}
