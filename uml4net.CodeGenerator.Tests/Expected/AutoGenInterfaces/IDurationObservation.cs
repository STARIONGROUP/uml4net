// -------------------------------------------------------------------------------------------------
// <copyright file="IDurationObservation.cs" company="Starion Group S.A.">
//
//   Copyright 2019-2024 Starion Group S.A.
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

namespace uml4net.Values
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
    /// A DurationObservation is a reference to a duration during an execution. It points out the
    /// NamedElement(s) in the model to observe and whether the observations are when this NamedElement is
    /// entered or when it is exited.
    /// </summary>
    [Class(xmiId: "DurationObservation", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    public partial interface IDurationObservation : IObservation
    {
        /// <summary>
        /// The DurationObservation is determined as the duration between the entering or exiting of a single
        /// event Element during execution, or the entering/exiting of one event Element and the
        /// entering/exiting of a second.
        /// </summary>
        [Property(xmiId: "DurationObservation-event", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 2, isOrdered: true, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public List<INamedElement> Event { get; set; }

        /// <summary>
        /// The value of firstEvent[i] is related to event[i] (where i is 1 or 2). If firstEvent[i] is true,
        /// then the corresponding observation event is the first time instant the execution enters event[i]. If
        /// firstEvent[i] is false, then the corresponding observation event is the time instant the execution
        /// exits event[i].
        /// </summary>
        [Property(xmiId: "DurationObservation-firstEvent", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 2, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public List<bool> FirstEvent { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
