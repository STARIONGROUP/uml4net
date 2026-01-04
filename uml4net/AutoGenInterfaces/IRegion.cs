// -------------------------------------------------------------------------------------------------
// <copyright file="IRegion.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2026 Starion Group S.A.
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
    /// A Region is a top-level part of a StateMachine or a composite State, that serves as a container for
    /// the Vertices and Transitions of the StateMachine. A StateMachine or composite State may contain
    /// multiple Regions representing behaviors that may occur in parallel.
    /// </summary>
    [Class(xmiId: "Region", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IRegion : INamespace, IRedefinableElement
    {
        /// <summary>
        /// The region of which this region is an extension.
        /// </summary>
        [Property(xmiId: "Region-extendedRegion", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "RedefinableElement-redefinedElement")]
        public IRegion ExtendedRegion { get; set; }

        /// <summary>
        /// References the Classifier in which context this element may be redefined.
        /// </summary>
        [Property(xmiId: "Region-redefinitionContext", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [RedefinedProperty(propertyName: "RedefinableElement-redefinitionContext")]
        public new IClassifier RedefinitionContext { get; }

        /// <summary>
        /// The State that owns the Region. If a Region is owned by a State, then it cannot also be owned by a
        /// StateMachine.
        /// </summary>
        [Property(xmiId: "Region-state", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "NamedElement-namespace")]
        public IState State { get; set; }

        /// <summary>
        /// The StateMachine that owns the Region. If a Region is owned by a StateMachine, then it cannot also
        /// be owned by a State.
        /// </summary>
        [Property(xmiId: "Region-stateMachine", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "NamedElement-namespace")]
        public IStateMachine StateMachine { get; set; }

        /// <summary>
        /// The set of Vertices that are owned by this Region.
        /// </summary>
        [Property(xmiId: "Region-subvertex", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        public IContainerList<IVertex> Subvertex { get; set; }

        /// <summary>
        /// The set of Transitions owned by the Region.
        /// </summary>
        [Property(xmiId: "Region-transition", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        public IContainerList<ITransition> Transition { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
