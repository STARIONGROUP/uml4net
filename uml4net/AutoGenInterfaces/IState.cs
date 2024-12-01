// -------------------------------------------------------------------------------------------------
// <copyright file="IState.cs" company="Starion Group S.A.">
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
    /// A State models a situation during which some (usually implicit) invariant condition holds.
    /// </summary>
    [Class(xmiId: "State", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    public partial interface IState : INamespace, IVertex
    {
        /// <summary>
        /// The entry and exit connection points used in conjunction with this (submachine) State, i.e., as
        /// targets and sources, respectively, in the Region with the submachine State. A connection point
        /// reference references the corresponding definition of a connection point Pseudostate in the
        /// StateMachine referenced by the submachine State.
        /// </summary>
        [Property(xmiId: "State-connection", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        public IContainerList<IConnectionPointReference> Connection { get; set; }

        /// <summary>
        /// The entry and exit Pseudostates of a composite State. These can only be entry or exit Pseudostates,
        /// and they must have different names. They can only be defined for composite States.
        /// </summary>
        [Property(xmiId: "State-connectionPoint", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        public IContainerList<IPseudostate> ConnectionPoint { get; set; }

        /// <summary>
        /// A list of Triggers that are candidates to be retained by the StateMachine if they trigger no
        /// Transitions out of the State (not consumed). A deferred Trigger is retained until the StateMachine
        /// reaches a State configuration where it is no longer deferred.
        /// </summary>
        [Property(xmiId: "State-deferrableTrigger", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<ITrigger> DeferrableTrigger { get; set; }

        /// <summary>
        /// An optional Behavior that is executed while being in the State. The execution starts when this State
        /// is entered, and ceases either by itself when done, or when the State is exited, whichever comes
        /// first.
        /// </summary>
        [Property(xmiId: "State-doActivity", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IBehavior> DoActivity { get; set; }

        /// <summary>
        /// An optional Behavior that is executed whenever this State is entered regardless of the Transition
        /// taken to reach the State. If defined, entry Behaviors are always executed to completion prior to any
        /// internal Behavior or Transitions performed within the State.
        /// </summary>
        [Property(xmiId: "State-entry", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IBehavior> Entry { get; set; }

        /// <summary>
        /// An optional Behavior that is executed whenever this State is exited regardless of which Transition
        /// was taken out of the State. If defined, exit Behaviors are always executed to completion only after
        /// all internal and transition Behaviors have completed execution.
        /// </summary>
        [Property(xmiId: "State-exit", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IBehavior> Exit { get; set; }

        /// <summary>
        /// A state with isComposite=true is said to be a composite State. A composite State is a State that
        /// contains at least one Region.
        /// </summary>
        [Property(xmiId: "State-isComposite", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public bool IsComposite { get; }

        /// <summary>
        /// A State with isOrthogonal=true is said to be an orthogonal composite State An orthogonal composite
        /// State contains two or more Regions.
        /// </summary>
        [Property(xmiId: "State-isOrthogonal", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public bool IsOrthogonal { get; }

        /// <summary>
        /// A State with isSimple=true is said to be a simple State A simple State does not have any Regions and
        /// it does not refer to any submachine StateMachine.
        /// </summary>
        [Property(xmiId: "State-isSimple", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public bool IsSimple { get; }

        /// <summary>
        /// A State with isSubmachineState=true is said to be a submachine State Such a State refers to another
        /// StateMachine(submachine).
        /// </summary>
        [Property(xmiId: "State-isSubmachineState", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public bool IsSubmachineState { get; }

        /// <summary>
        /// The Regions owned directly by the State.
        /// </summary>
        [Property(xmiId: "State-region", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        public IContainerList<IRegion> Region { get; set; }

        /// <summary>
        /// Specifies conditions that are always true when this State is the current State. In
        /// ProtocolStateMachines state invariants are additional conditions to the preconditions of the
        /// outgoing Transitions, and to the postcondition of the incoming Transitions.
        /// </summary>
        [Property(xmiId: "State-stateInvariant", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-ownedRule")]
        public IContainerList<IConstraint> StateInvariant { get; set; }

        /// <summary>
        /// The StateMachine that is to be inserted in place of the (submachine) State.
        /// </summary>
        [Property(xmiId: "State-submachine", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public IStateMachine Submachine { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------