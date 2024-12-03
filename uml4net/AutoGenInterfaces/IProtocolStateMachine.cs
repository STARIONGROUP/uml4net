// -------------------------------------------------------------------------------------------------
// <copyright file="IProtocolStateMachine.cs" company="Starion Group S.A.">
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
    /// A ProtocolStateMachine is always defined in the context of a Classifier. It specifies which
    /// BehavioralFeatures of the Classifier can be called in which State and under which conditions, thus
    /// specifying the allowed invocation sequences on the Classifier's BehavioralFeatures. A
    /// ProtocolStateMachine specifies the possible and permitted Transitions on the instances of its
    /// context Classifier, together with the BehavioralFeatures that carry the Transitions. In this manner,
    /// an instance lifecycle can be specified for a Classifier, by defining the order in which the
    /// BehavioralFeatures can be activated and the States through which an instance progresses during its
    /// existence.
    /// </summary>
    [Class(xmiId: "ProtocolStateMachine", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    public partial interface IProtocolStateMachine : IStateMachine
    {
        /// <summary>
        /// Conformance between ProtocolStateMachine
        /// </summary>
        [Property(xmiId: "ProtocolStateMachine-conformance", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_source_directedRelationship-directedRelationship")]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IProtocolConformance> Conformance { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
