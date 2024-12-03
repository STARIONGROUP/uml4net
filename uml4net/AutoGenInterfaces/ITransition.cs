// -------------------------------------------------------------------------------------------------
// <copyright file="ITransition.cs" company="Starion Group S.A.">
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
    /// A Transition represents an arc between exactly one source Vertex and exactly one Target vertex (the
    /// source and targets may be the same Vertex). It may form part of a compound transition, which takes
    /// the StateMachine from one steady State configuration to another, representing the full response of
    /// the StateMachine to an occurrence of an Event that triggered it.
    /// </summary>
    [Class(xmiId: "Transition", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    public partial interface ITransition : INamespace, IRedefinableElement
    {
        /// <summary>
        /// Designates the Region that owns this Transition.
        /// </summary>
        [Property(xmiId: "Transition-container", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "NamedElement-namespace")]
        public IRegion Container { get; set; }

        /// <summary>
        /// Specifies an optional behavior to be performed when the Transition fires.
        /// </summary>
        [Property(xmiId: "Transition-effect", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IBehavior> Effect { get; set; }

        /// <summary>
        /// A guard is a Constraint that provides a fine-grained control over the firing of the Transition. The
        /// guard is evaluated when an Event occurrence is dispatched by the StateMachine. If the guard is true
        /// at that time, the Transition may be enabled, otherwise, it is disabled. Guards should be pure
        /// expressions without side effects. Guard expressions with side effects are ill formed.
        /// </summary>
        [Property(xmiId: "Transition-guard", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-ownedRule")]
        public IContainerList<IConstraint> Guard { get; set; }

        /// <summary>
        /// Indicates the precise type of the Transition.
        /// </summary>
        [Property(xmiId: "Transition-kind", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "external")]
        public TransitionKind Kind { get; set; }

        /// <summary>
        /// The Transition that is redefined by this Transition.
        /// </summary>
        [Property(xmiId: "Transition-redefinedTransition", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "RedefinableElement-redefinedElement")]
        public ITransition RedefinedTransition { get; set; }

        /// <summary>
        /// References the Classifier in which context this element may be redefined.
        /// </summary>
        [Property(xmiId: "Transition-redefinitionContext", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [RedefinedProperty(propertyName: "RedefinableElement-redefinitionContext")]
        public new IClassifier RedefinitionContext { get; }

        /// <summary>
        /// Designates the originating Vertex (State or Pseudostate) of the Transition.
        /// </summary>
        [Property(xmiId: "Transition-source", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public IVertex Source { get; set; }

        /// <summary>
        /// Designates the target Vertex that is reached when the Transition is taken.
        /// </summary>
        [Property(xmiId: "Transition-target", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public IVertex Target { get; set; }

        /// <summary>
        /// Specifies the Triggers that may fire the transition.
        /// </summary>
        [Property(xmiId: "Transition-trigger", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<ITrigger> Trigger { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
