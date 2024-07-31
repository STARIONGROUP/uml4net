// -------------------------------------------------------------------------------------------------
// <copyright file="Interaction.cs" company="Starion Group S.A.">
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

namespace uml4net.POCO.Interactions
{
    using System.Collections.Generic;
    using uml4net.Decorators;
    using uml4net.POCO.CommonStructure;

    using uml4net.POCO.StructuredClassifiers;
    using uml4net.POCO.Values;

    /// <summary>
    /// An InteractionConstraint is a Boolean expression that guards an operand in a CombinedFragment.
    /// </summary>
    public class InteractionConstraint : IInteractionConstraint
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
        /// A condition that must be true when evaluated in order for the Constraint to be satisfied.
        /// </summary>
        [Feature(aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1)]
        [Implements(implementation: "IConstraint.Specification")]
        public IValueSpecification Specification { get; set; }

        /// <summary>
        /// Specifies the Namespace that owns the Constraint.
        /// </summary>
        [Feature(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: true, subsets: "NamedElement::namespace")]
        [Implements(implementation: "IConstraint.Context")]
        public INamespace Context { get; set; }

        /// <summary>
        /// The ordered set of Elements referenced by this Constraint.
        /// </summary>
        [Feature(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true)]
        [Implements(implementation: "IConstraint.ConstrainedElement")]
        public List<IElement> ConstrainedElement { get; set; }
    }
}
