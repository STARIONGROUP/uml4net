﻿// -------------------------------------------------------------------------------------------------
// <copyright file="ICallBehaviorAction.cs" company="Starion Group S.A.">
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

namespace uml4net.Actions
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
    /// A CallBehaviorAction is a CallAction that invokes a Behavior directly. The argument values of the
    /// CallBehaviorAction are passed on the input Parameters of the invoked Behavior. If the call is
    /// synchronous, the execution of the CallBehaviorAction waits until the execution of the invoked
    /// Behavior completes and the values of output Parameters of the Behavior are placed on the result
    /// OutputPins. If the call is asynchronous, the CallBehaviorAction completes immediately and no results
    /// values can be provided.
    /// </summary>
    [Class(xmiId: "CallBehaviorAction", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    public partial interface ICallBehaviorAction : ICallAction
    {
        /// <summary>
        /// The Behavior being invoked.
        /// </summary>
        [Property(xmiId: "CallBehaviorAction-behavior", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public IBehavior Behavior { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------