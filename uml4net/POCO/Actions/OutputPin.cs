﻿// -------------------------------------------------------------------------------------------------
// <copyright file="OutputPin.cs" company="Starion Group S.A.">
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

namespace uml4net.POCO.Actions
{
    using System.Collections.Generic;
    using uml4net.Decorators;
    using uml4net.POCO.CommonStructure;

    using uml4net.POCO.StructuredClassifiers;
    using uml4net.POCO.Values;

    /// <summary>
    /// An OutputPin is a Pin that holds output values produced by an Action.
    /// </summary>
    public class OutputPin : IOutputPin
    {
        /// <summary>
        /// The Comments owned by this Element.
        /// </summary>
        [Feature(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [Implements(implementation: "IElement.OwnedComment")]
        public List<IComment> OwnedComment { get; set; }

        /// <summary>
        /// The Elements owned by this Element
        /// </summary>
        [Feature(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [Implements(implementation: "IElement.OwnedElement")]
        public List<IElement> OwnedElement { get; }

        /// <summary>
        /// The Element that owns this Element.
        /// </summary>
        [Feature(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [Implements(implementation: "IElement.Owner")]
        public IElement Owner { get; }

        /// <summary>
        /// For a multivalued multiplicity, this attribute specifies whether the values in an instantiation
        /// of this MultiplicityElement are sequentially ordered.
        /// </summary>
        [Feature(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1)]
        [Implements(implementation: "IMultiplicityElement.IsOrdered")]
        public bool IsOrdered { get; set; }

        /// <summary>
        /// For a multivalued multiplicity, this attributes specifies whether the values in an instantiation
        /// of this MultiplicityElement are unique.
        /// </summary>
        [Feature(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1)]
        [Implements(implementation: "IMultiplicityElement.IsUnique")]
        public bool IsUnique { get; set; }

        /// <summary>
        /// The lower bound of the multiplicity interval.
        /// </summary>
        [Feature(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isDerived: true)]
        [Implements(implementation: "IMultiplicityElement.Lower")]
        public int Lower { get; set; }

        /// <summary>
        /// The specification of the lower bound for this multiplicity.
        /// </summary>
        [Feature(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isDerived: true)]
        [Implements(implementation: "IMultiplicityElement.LowerValue")]
        public IValueSpecification LowerValue { get; set; }

        /// <summary>
        /// The upper bound of the multiplicity interval.
        /// </summary>
        [Feature(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isDerived: true)]
        [Implements(implementation: "IMultiplicityElement.Upper")]
        public ILiteralUnlimitedNatural Upper { get; set; }

        /// <summary>
        /// The specification of the upper bound for this multiplicity.
        /// </summary>
        [Feature(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isDerived: true)]
        [Implements(implementation: "IMultiplicityElement.UpperValue")]
        public IValueSpecification UpperValue { get; set; }
    }
}