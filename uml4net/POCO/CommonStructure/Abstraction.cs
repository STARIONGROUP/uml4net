// -------------------------------------------------------------------------------------------------
// <copyright file="Abstraction.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;

    using uml4net.Decorators;
    using uml4net.POCO.StructuredClassifiers;
    using uml4net.POCO.Values;

    /// <summary>
    /// An Abstraction is a Relationship that relates two Elements or sets of Elements that represent the
    /// same concept at different levels of abstraction or from different viewpoints.
    /// </summary>
    public class Abstraction : IAbstraction
    {
        /// <summary>
        /// An OpaqueExpression that states the abstraction relationship between the supplier(s) and the client(s). 
        /// In some cases, such as derivation, it is usually formal and unidirectional; in other cases, such as trace, 
        /// it is usually informal and bidirectional. The mapping expression is optional and may be omitted if the
        /// precise relationship between the Elements is not specified.
        /// </summary>
        [Feature(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, subsets: "Element::ownedElement")]
        [Implements(implementation: "IAbstraction.Mapping")]
        public IOpaqueExpression Mapping { get; set; }

        /// <summary>
        /// The Element(s) dependent on the supplier Element(s). In some cases (such as a trace Abstraction)
        /// the assignment of direction (that is, the designation of the client Element) is at the discretion 
        /// of the modeler and is a stipulation.
        /// </summary>
        [Feature(aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue, subsets: "DirectedRelationship::source")]
        [Implements(implementation: "IDependency.Client")]
        public List<INamedElement> Client { get; set; }

        /// <summary>
        /// The Element(s) on which the client Element(s) depend in some respect. The modeler may stipulate
        /// a sense of Dependency direction suitable for their domain.
        /// </summary>
        [Feature(aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue, subsets: "DirectedRelationship::target")]
        [Implements(implementation: "IDependency.Supplier")]
        public List<INamedElement> Supplier { get; set; }

        /// <summary>
        /// Specifies the source Element(s) of the DirectedRelationship.
        /// </summary>
        [Feature(aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue, isReadOnly: true, isDerived: true, isDerivedUnion: true, subsets: "Relationship::relatedElement")]
        [Implements(implementation: "IDirectedRelationship.Source")]
        public List<IElement> Source { get; }

        /// <summary>
        /// Specifies the target Element(s) of the DirectedRelationship.
        /// </summary>
        [Feature(aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue, isReadOnly: true, isDerived: true, isDerivedUnion: true, subsets: "Relationship::relatedElement")]
        [Implements(implementation: "IDirectedRelationship.Target")]
        public List<IElement> Target { get; }

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
    }
}
