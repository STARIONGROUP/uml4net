// -------------------------------------------------------------------------------------------------
// <copyright file="ITimeObservation.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace uml4net.Values
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
    /// A TimeObservation is a reference to a time instant during an execution. It points out the
    /// NamedElement in the model to observe and whether the observation is when this NamedElement is
    /// entered or when it is exited.
    /// </summary>
    [Class(xmiId: "TimeObservation", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface ITimeObservation : IObservation
    {
        /// <summary>
        /// The TimeObservation is determined by the entering or exiting of the event Element during execution.
        /// </summary>
        [Property(xmiId: "TimeObservation-event", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        public INamedElement Event { get; set; }

        /// <summary>
        /// The value of firstEvent is related to the event. If firstEvent is true, then the corresponding
        /// observation event is the first time instant the execution enters the event Element. If firstEvent is
        /// false, then the corresponding observation event is the time instant the execution exits the event
        /// Element.
        /// </summary>
        [Property(xmiId: "TimeObservation-firstEvent", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: "true", isOwnerEnd: false)]
        public bool FirstEvent { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
