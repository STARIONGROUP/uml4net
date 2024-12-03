// -------------------------------------------------------------------------------------------------
// <copyright file="IProtocolTransition.cs" company="Starion Group S.A.">
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
    /// A ProtocolTransition specifies a legal Transition for an Operation. Transitions of
    /// ProtocolStateMachines have the following information: a pre-condition (guard), a Trigger, and a
    /// post-condition. Every ProtocolTransition is associated with at most one BehavioralFeature belonging
    /// to the context Classifier of the ProtocolStateMachine.
    /// </summary>
    [Class(xmiId: "ProtocolTransition", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    public partial interface IProtocolTransition : ITransition
    {
        /// <summary>
        /// Specifies the post condition of the Transition which is the Condition that should be obtained once
        /// the Transition is triggered. This post condition is part of the post condition of the Operation
        /// connected to the Transition.
        /// </summary>
        [Property(xmiId: "ProtocolTransition-postCondition", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-ownedRule")]
        public IContainerList<IConstraint> PostCondition { get; set; }

        /// <summary>
        /// Specifies the precondition of the Transition. It specifies the Condition that should be verified
        /// before triggering the Transition. This guard condition added to the source State will be evaluated
        /// as part of the precondition of the Operation referred by the Transition if any.
        /// </summary>
        [Property(xmiId: "ProtocolTransition-preCondition", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Transition-guard")]
        public IContainerList<IConstraint> PreCondition { get; set; }

        /// <summary>
        /// This association refers to the associated Operation. It is derived from the Operation of the
        /// CallEvent Trigger when applicable.
        /// </summary>
        [Property(xmiId: "ProtocolTransition-referred", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public List<IOperation> Referred { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
