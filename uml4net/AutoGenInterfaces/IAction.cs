// -------------------------------------------------------------------------------------------------
// <copyright file="IAction.cs" company="Starion Group S.A.">
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
    /// An Action is the fundamental unit of executable functionality. The execution of an Action represents
    /// some transformation or processing in the modeled system. Actions provide the ExecutableNodes within
    /// Activities and may also be used within Interactions.
    /// </summary>
    [Class(xmiId: "Action", isAbstract: true, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IAction : IExecutableNode
    {
        /// <summary>
        /// The context Classifier of the Behavior that contains this Action, or the Behavior itself if it has
        /// no context.
        /// </summary>
        [Property(xmiId: "Action-context", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public IClassifier Context { get; }

        /// <summary>
        /// The ordered set of InputPins representing the inputs to the Action.
        /// </summary>
        [Property(xmiId: "Action-input", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IInputPin> Input { get; }

        /// <summary>
        /// If true, the Action can begin a new, concurrent execution, even if there is already another
        /// execution of the Action ongoing. If false, the Action cannot begin a new execution until any
        /// previous execution has completed.
        /// </summary>
        [Property(xmiId: "Action-isLocallyReentrant", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "false")]
        public bool IsLocallyReentrant { get; set; }

        /// <summary>
        /// A Constraint that must be satisfied when execution of the Action is completed.
        /// </summary>
        [Property(xmiId: "Action-localPostcondition", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IConstraint> LocalPostcondition { get; set; }

        /// <summary>
        /// A Constraint that must be satisfied when execution of the Action is started.
        /// </summary>
        [Property(xmiId: "Action-localPrecondition", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IConstraint> LocalPrecondition { get; set; }

        /// <summary>
        /// The ordered set of OutputPins representing outputs from the Action.
        /// </summary>
        [Property(xmiId: "Action-output", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IOutputPin> Output { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
