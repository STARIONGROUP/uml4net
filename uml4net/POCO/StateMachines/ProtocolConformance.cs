// -------------------------------------------------------------------------------------------------
// <copyright file="IProtocolConformance.cs" company="Starion Group S.A.">
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

namespace uml4net.POCO.StateMachines
{
    using System;
    using System.Collections.Generic;

    using uml4net.Decorators;
    using uml4net.POCO.Classification;
    using uml4net.POCO.CommonStructure;

    /// <summary>
    /// A ProtocolStateMachine can be redefined into a more specific ProtocolStateMachine or into behavioral
    /// StateMachine. ProtocolConformance declares that the specific ProtocolStateMachine specifies a protocol
    /// that conforms to the general ProtocolStateMachine or that the specific behavioral StateMachine abides
    /// by the protocol of the general ProtocolStateMachine.
    /// </summary>
    public class ProtocolConformance : IProtocolConformance
    {
        /// <summary>
        /// Gets or sets the unique identifier of the Element in the XMI document
        /// </summary>
        [Implements(implementation: "IXmiElement.XmiId")]
        public string XmiId { get; set; }

        /// <summary>
        /// Gets or sets the GUID unique identifier of the Element in the XMI document
        /// </summary>
        [Implements(implementation: "IXmiElement.XmiGuid")]
        public string XmiGuid { get; set; }

        /// <summary>
        /// Gets or sets the name of the xmi type
        /// </summary>
        [Implements(implementation: "IXmiElement.XmiType")]
        public string XmiType { get; set; }

        /// <summary>
        /// The Comments owned by this Element.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [Implements(implementation: "IElement.OwnedComment")]
        public List<IComment> OwnedComment { get; set; }

        /// <summary>
        /// The Elements owned by this Element
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [Implements(implementation: "IElement.OwnedElement")]
        public List<IElement> OwnedElement => throw new NotImplementedException();

        /// <summary>
        /// The Element that owns this Element.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [Implements(implementation: "IElement.Owner")]
        public IElement Owner => throw new NotImplementedException();

        /// <summary>
        /// Specifies the source Element(s) of the DirectedRelationship.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [Implements(implementation: "IDirectedRelationship.Source")]
        [SubsettedProperty(propertyName: "Relationship.RelatedElement")]
        public List<IElement> Source { get; }

        /// <summary>
        /// Specifies the target Element(s) of the DirectedRelationship.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [Implements(implementation: "IDirectedRelationship.Target")]
        [SubsettedProperty(propertyName: "Relationship.RelatedElement")]
        public List<IElement> Target { get; }

        /// <summary>
        /// Specifies the elements related by the Relationship.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [Implements(implementation: "IRelationship.RelatedElement")]
        public List<IElement> RelatedElement => throw new NotImplementedException();
    }
}
