// -------------------------------------------------------------------------------------------------
// <copyright file="IPort.cs" company="Starion Group S.A.">
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

namespace uml4net.StructuredClassifiers
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

    using uml4net.Utils;

    /// <summary>
    /// A Port is a property of an EncapsulatedClassifier that specifies a distinct interaction point
    /// between that EncapsulatedClassifier and its environment or between the (behavior of the)
    /// EncapsulatedClassifier and its internal parts. Ports are connected to Properties of the
    /// EncapsulatedClassifier by Connectors through which requests can be made to invoke
    /// BehavioralFeatures. A Port may specify the services an EncapsulatedClassifier provides (offers) to
    /// its environment as well as the services that an EncapsulatedClassifier expects (requires) of its
    /// environment.  A Port may have an associated ProtocolStateMachine.
    /// </summary>
    [Class(xmiId: "Port", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IPort : IProperty
    {
        /// <summary>
        /// Specifies whether requests arriving at this Port are sent to the classifier behavior of this
        /// EncapsulatedClassifier. Such a Port is referred to as a behavior Port. Any invocation of a
        /// BehavioralFeature targeted at a behavior Port will be handled by the instance of the owning
        /// EncapsulatedClassifier itself, rather than by any instances that it may contain.
        /// </summary>
        [Property(xmiId: "Port-isBehavior", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "false")]
        public bool IsBehavior { get; set; }

        /// <summary>
        /// Specifies the way that the provided and required Interfaces are derived from the Port’s Type.
        /// </summary>
        [Property(xmiId: "Port-isConjugated", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "false")]
        public bool IsConjugated { get; set; }

        /// <summary>
        /// If true, indicates that this Port is used to provide the published functionality of an
        /// EncapsulatedClassifier.  If false, this Port is used to implement the EncapsulatedClassifier but is
        /// not part of the essential externally-visible functionality of the EncapsulatedClassifier and can,
        /// therefore, be altered or deleted along with the internal implementation of the
        /// EncapsulatedClassifier and other properties that are considered part of its implementation.
        /// </summary>
        [Property(xmiId: "Port-isService", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "true")]
        public bool IsService { get; set; }

        /// <summary>
        /// An optional ProtocolStateMachine which describes valid interactions at this interaction point.
        /// </summary>
        [Property(xmiId: "Port-protocol", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public IProtocolStateMachine Protocol { get; set; }

        /// <summary>
        /// The Interfaces specifying the set of Operations and Receptions that the EncapsulatedCclassifier
        /// offers to its environment via this Port, and which it will handle either directly or by forwarding
        /// it to a part of its internal structure. This association is derived according to the value of
        /// isConjugated. If isConjugated is false, provided is derived as the union of the sets of Interfaces
        /// realized by the type of the port and its supertypes, or directly from the type of the Port if the
        /// Port is typed by an Interface. If isConjugated is true, it is derived as the union of the sets of
        /// Interfaces used by the type of the Port and its supertypes.
        /// </summary>
        [Property(xmiId: "Port-provided", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public List<IInterface> Provided { get; }

        /// <summary>
        /// A Port may be redefined when its containing EncapsulatedClassifier is specialized. The redefining
        /// Port may have additional Interfaces to those that are associated with the redefined Port or it may
        /// replace an Interface by one of its subtypes.
        /// </summary>
        [Property(xmiId: "Port-redefinedPort", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Property-redefinedProperty")]
        public List<IPort> RedefinedPort { get; set; }

        /// <summary>
        /// The Interfaces specifying the set of Operations and Receptions that the EncapsulatedCassifier
        /// expects its environment to handle via this port. This association is derived according to the value
        /// of isConjugated. If isConjugated is false, required is derived as the union of the sets of
        /// Interfaces used by the type of the Port and its supertypes. If isConjugated is true, it is derived
        /// as the union of the sets of Interfaces realized by the type of the Port and its supertypes, or
        /// directly from the type of the Port if the Port is typed by an Interface.
        /// </summary>
        [Property(xmiId: "Port-required", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public List<IInterface> Required { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
