// -------------------------------------------------------------------------------------------------
// <copyright file="IProtocolConformance.cs" company="Starion Group S.A.">
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

namespace uml4net.StateMachines
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
    /// A ProtocolStateMachine can be redefined into a more specific ProtocolStateMachine or into behavioral
    /// StateMachine. ProtocolConformance declares that the specific ProtocolStateMachine specifies a
    /// protocol that conforms to the general ProtocolStateMachine or that the specific behavioral
    /// StateMachine abides by the protocol of the general ProtocolStateMachine.
    /// </summary>
    [Class(xmiId: "ProtocolConformance", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    public partial interface IProtocolConformance : IDirectedRelationship
    {
        /// <summary>
        /// Specifies the ProtocolStateMachine to which the specific ProtocolStateMachine conforms.
        /// </summary>
        [Property(xmiId: "ProtocolConformance-generalMachine", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "DirectedRelationship-target")]
        public IProtocolStateMachine GeneralMachine { get; set; }

        /// <summary>
        /// Specifies the ProtocolStateMachine which conforms to the general ProtocolStateMachine.
        /// </summary>
        [Property(xmiId: "ProtocolConformance-specificMachine", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "DirectedRelationship-source")]
        [SubsettedProperty(propertyName: "Element-owner")]
        public IProtocolStateMachine SpecificMachine { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
