// -------------------------------------------------------------------------------------------------
// <copyright file="IMultiplicityElement.cs" company="Starion Group S.A.">
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

namespace uml4net.POCO.CommonStructure
{
    using uml4net.Decorators;

    using uml4net.POCO.StructuredClassifiers;
    using uml4net.POCO.Values;

    /// <summary>
    /// A multiplicity is a definition of an inclusive interval of non-negative integers beginning with 
    /// a lower bound and ending with a (possibly infinite) upper bound. A MultiplicityElement embeds 
    /// this information to specify the allowable cardinalities for an instantiation of the Element.
    /// </summary>
    public interface IMultiplicityElement : IElement
    {
        /// <summary>
        /// For a multivalued multiplicity, this attribute specifies whether the values in an instantiation
        /// of this MultiplicityElement are sequentially ordered.
        /// </summary>
        [Feature(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1)]
        public bool IsOrdered { get; set; }

        /// <summary>
        /// For a multivalued multiplicity, this attributes specifies whether the values in an instantiation
        /// of this MultiplicityElement are unique.
        /// </summary>
        [Feature(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1)]
        public bool IsUnique { get; set; }

        /// <summary>
        /// The lower bound of the multiplicity interval.
        /// </summary>
        [Feature(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isDerived: true)]
        public int Lower { get; set; }

        /// <summary>
        /// The specification of the lower bound for this multiplicity.
        /// </summary>
        [Feature(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isDerived: true)]
        public IValueSpecification LowerValue { get; set; }

        /// <summary>
        /// The upper bound of the multiplicity interval.
        /// </summary>
        [Feature(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isDerived: true)]
        public ILiteralUnlimitedNatural Upper { get; set; }

        /// <summary>
        /// The specification of the upper bound for this multiplicity.
        /// </summary>
        [Feature(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isDerived: true)]
        public IValueSpecification UpperValue { get; set; }
    }
}
