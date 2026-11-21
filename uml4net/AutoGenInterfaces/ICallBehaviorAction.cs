// -------------------------------------------------------------------------------------------------
// <copyright file="ICallBehaviorAction.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace uml4net.Actions
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
    /// A CallBehaviorAction is a CallAction that invokes a Behavior directly. The argument values of the
    /// CallBehaviorAction are passed on the input Parameters of the invoked Behavior. If the call is
    /// synchronous, the execution of the CallBehaviorAction waits until the execution of the invoked
    /// Behavior completes and the values of output Parameters of the Behavior are placed on the result
    /// OutputPins. If the call is asynchronous, the CallBehaviorAction completes immediately and no results
    /// values can be provided.
    /// </summary>
    [Class(xmiId: "CallBehaviorAction", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface ICallBehaviorAction : ICallAction
    {
        /// <summary>
        /// The Behavior being invoked.
        /// </summary>
        [Property(xmiId: "CallBehaviorAction-behavior", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        public IBehavior Behavior { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
