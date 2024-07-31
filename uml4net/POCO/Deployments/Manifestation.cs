// -------------------------------------------------------------------------------------------------
// <copyright file="Manifestation.cs" company="Starion Group S.A.">
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

namespace uml4net.POCO.Deployments
{
    using System.Collections.Generic;
    using uml4net.Decorators;
    using uml4net.POCO.CommonStructure;

    using uml4net.POCO.StructuredClassifiers;
    using uml4net.POCO.Values;

    /// <summary>
    /// A manifestation is the concrete physical rendering of one or more model elements by an artifact.
    /// </summary>
    public class Manifestation : IManifestation
    {
        /// <summary>
        /// An OpaqueExpression that states the abstraction relationship between the supplier(s) and the client(s). 
        /// In some cases, such as derivation, it is usually formal and unidirectional; in other cases, such as trace, 
        /// it is usually informal and bidirectional. The mapping expression is optional and may be omitted if the
        /// precise relationship between the Elements is not specified.
        /// </summary>
        [Feature(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1)]
        [Implements(implementation: "IAbstraction.Mapping")]
        [SubsettedProperty(propertyName: "Element.OwnedElement")]
        public IOpaqueExpression Mapping { get; set; }

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
        /// The Element(s) dependent on the supplier Element(s). In some cases (such as a trace Abstraction)
        /// the assignment of direction (that is, the designation of the client Element) is at the discretion 
        /// of the modeler and is a stipulation.
        /// </summary>
        [Feature(aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue)]
        [Implements(implementation: "IDependency.Client")]
        [SubsettedProperty(propertyName: "DirectedRelationship.Source")]
        public List<INamedElement> Client { get; set; }

        /// <summary>
        /// The Element(s) on which the client Element(s) depend in some respect. The modeler may stipulate
        /// a sense of Dependency direction suitable for their domain.
        /// </summary>
        [Feature(aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue)]
        [Implements(implementation: "IDependency.Supplier")]
        [SubsettedProperty(propertyName: "DirectedRelationship.Target")]
        public List<INamedElement> Supplier { get; set; }

        /// <summary>
        /// Specifies the source Element(s) of the DirectedRelationship.
        /// </summary>
        [Feature(aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [Implements(implementation: "IDirectedRelationship.Source")]
        [SubsettedProperty(propertyName: "Relationship.RelatedElement")]
        public List<IElement> Source { get; }

        /// <summary>
        /// Specifies the target Element(s) of the DirectedRelationship.
        /// </summary>
        [Feature(aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [Implements(implementation: "IDirectedRelationship.Target")]
        [SubsettedProperty(propertyName: "Relationship.RelatedElement")]
        public List<IElement> Target { get; }
    }
}
