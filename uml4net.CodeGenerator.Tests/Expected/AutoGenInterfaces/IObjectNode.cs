// -------------------------------------------------------------------------------------------------
// <copyright file="IObjectNode.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2024 Starion Group S.A.
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

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace uml4net.Activities
{
    using System.Collections.Generic;

    using uml4net.Decorators;
    using uml4net.Actions;
    using uml4net.Activities;
    using uml4net.Classification;
    using uml4net.CommonBehavior;
    using uml4net.CommonStructure;
    using uml4net.Deployments;
    using uml4net.InformationFlows;
    using uml4net.Interactions;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StateMachines;
    using uml4net.StructuredClassifiers;
    using uml4net.UseCases;
    using uml4net.Values;

    using uml4net.Utils;

    /// <summary>
    /// An ObjectNode is an abstract ActivityNode that may hold tokens within the object flow in an
    /// Activity. ObjectNodes also support token selection, limitation on the number of tokens held,
    /// specification of the state required for tokens being held, and carrying control values.
    /// </summary>
    [Class(xmiId: "ObjectNode", isAbstract: true, isFinalSpecialization: false, isActive: false)]
    public partial interface IObjectNode : ITypedElement, IActivityNode
    {
        /// <summary>
        /// The States required to be associated with the values held by tokens on this ObjectNode.
        /// </summary>
        [Property(xmiId: "ObjectNode-inState", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public List<IState> InState { get; set; }

        /// <summary>
        /// Indicates whether the type of the ObjectNode is to be treated as representing control values that
        /// may traverse ControlFlows.
        /// </summary>
        [Property(xmiId: "ObjectNode-isControlType", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "false")]
        public bool IsControlType { get; set; }

        /// <summary>
        /// Indicates how the tokens held by the ObjectNode are ordered for selection to traverse ActivityEdges
        /// outgoing from the ObjectNode.
        /// </summary>
        [Property(xmiId: "ObjectNode-ordering", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "FIFO")]
        public ObjectNodeOrderingKind Ordering { get; set; }

        /// <summary>
        /// A Behavior used to select tokens to be offered on outgoing ActivityEdges.
        /// </summary>
        [Property(xmiId: "ObjectNode-selection", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public IBehavior Selection { get; set; }

        /// <summary>
        /// The maximum number of tokens that may be held by this ObjectNode. Tokens cannot flow into the
        /// ObjectNode if the upperBound is reached. If no upperBound is specified, then there is no limit on
        /// how many tokens the ObjectNode can hold.
        /// </summary>
        [Property(xmiId: "ObjectNode-upperBound", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IValueSpecification> UpperBound { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
