// -------------------------------------------------------------------------------------------------
// <copyright file="IProtocolConformance.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace uml4net.StateMachines
{
    using System.CodeDom.Compiler;
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

    /// <summary>
    /// A ProtocolStateMachine can be redefined into a more specific ProtocolStateMachine or into behavioral
    /// StateMachine. ProtocolConformance declares that the specific ProtocolStateMachine specifies a
    /// protocol that conforms to the general ProtocolStateMachine or that the specific behavioral
    /// StateMachine abides by the protocol of the general ProtocolStateMachine.
    /// </summary>
    [Class(xmiId: "ProtocolConformance", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IProtocolConformance : IDirectedRelationship
    {
        /// <summary>
        /// Specifies the ProtocolStateMachine to which the specific ProtocolStateMachine conforms.
        /// </summary>
        [Property(xmiId: "ProtocolConformance-generalMachine", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        [SubsettedProperty(propertyName: "DirectedRelationship-target")]
        public IProtocolStateMachine GeneralMachine { get; set; }

        /// <summary>
        /// Specifies the ProtocolStateMachine which conforms to the general ProtocolStateMachine.
        /// </summary>
        [Property(xmiId: "ProtocolConformance-specificMachine", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: true)]
        [SubsettedProperty(propertyName: "DirectedRelationship-source")]
        [SubsettedProperty(propertyName: "Element-owner")]
        public IProtocolStateMachine SpecificMachine { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
