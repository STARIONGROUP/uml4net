// -------------------------------------------------------------------------------------------------
// <copyright file="IPseudostate.cs" company="Starion Group S.A.">
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
    /// A Pseudostate is an abstraction that encompasses different types of transient Vertices in the
    /// StateMachine graph. A StateMachine instance never comes to rest in a Pseudostate, instead, it will
    /// exit and enter the Pseudostate within a single run-to-completion step.
    /// </summary>
    [Class(xmiId: "Pseudostate", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IPseudostate : IVertex
    {
        /// <summary>
        /// Determines the precise type of the Pseudostate and can be one of: entryPoint, exitPoint, initial,
        /// deepHistory, shallowHistory, join, fork, junction, terminate or choice.
        /// </summary>
        [Property(xmiId: "Pseudostate-kind", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: "initial", isOwnerEnd: false)]
        public PseudostateKind Kind { get; set; }

        /// <summary>
        /// The State that owns this Pseudostate and in which it appears.
        /// </summary>
        [Property(xmiId: "Pseudostate-state", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: true)]
        [SubsettedProperty(propertyName: "NamedElement-namespace")]
        public IState State { get; set; }

        /// <summary>
        /// The StateMachine in which this Pseudostate is defined. This only applies to Pseudostates of the kind
        /// entryPoint or exitPoint.
        /// </summary>
        [Property(xmiId: "Pseudostate-stateMachine", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: true)]
        [SubsettedProperty(propertyName: "NamedElement-namespace")]
        public IStateMachine StateMachine { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
