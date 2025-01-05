// -------------------------------------------------------------------------------------------------
// <copyright file="IStateMachine.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2025 Starion Group S.A.
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
    /// StateMachines can be used to express event-driven behaviors of parts of a system. Behavior is
    /// modeled as a traversal of a graph of Vertices interconnected by one or more joined Transition arcs
    /// that are triggered by the dispatching of successive Event occurrences. During this traversal, the
    /// StateMachine may execute a sequence of Behaviors associated with various elements of the
    /// StateMachine.
    /// </summary>
    [Class(xmiId: "StateMachine", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IStateMachine : IBehavior
    {
        /// <summary>
        /// The connection points defined for this StateMachine. They represent the interface of the
        /// StateMachine when used as part of submachine State
        /// </summary>
        [Property(xmiId: "StateMachine-connectionPoint", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        public IContainerList<IPseudostate> ConnectionPoint { get; set; }

        /// <summary>
        /// The StateMachines of which this is an extension.
        /// </summary>
        [Property(xmiId: "StateMachine-extendedStateMachine", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [RedefinedProperty(propertyName: "Behavior-redefinedBehavior")]
        public new List<IStateMachine> ExtendedStateMachine { get; set; }

        /// <summary>
        /// The Regions owned directly by the StateMachine.
        /// </summary>
        [Property(xmiId: "StateMachine-region", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        public IContainerList<IRegion> Region { get; set; }

        /// <summary>
        /// References the submachine(s) in case of a submachine State. Multiple machines are referenced in case
        /// of a concurrent State.
        /// </summary>
        [Property(xmiId: "StateMachine-submachineState", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public List<IState> SubmachineState { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
