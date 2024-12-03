// -------------------------------------------------------------------------------------------------
// <copyright file="IInterface.cs" company="Starion Group S.A.">
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

namespace uml4net.SimpleClassifiers
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
    /// Interfaces declare coherent services that are implemented by BehavioredClassifiers that implement
    /// the Interfaces via InterfaceRealizations.
    /// </summary>
    [Class(xmiId: "Interface", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    public partial interface IInterface : IClassifier
    {
        /// <summary>
        /// References all the Classifiers that are defined (nested) within the Interface.
        /// </summary>
        [Property(xmiId: "Interface-nestedClassifier", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_redefinitionContext_redefinableElement-redefinableElement")]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        public IContainerList<IClassifier> NestedClassifier { get; set; }

        /// <summary>
        /// The attributes (i.e., the Properties) owned by the Interface.
        /// </summary>
        [Property(xmiId: "Interface-ownedAttribute", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Classifier-attribute")]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        public IContainerList<IProperty> OwnedAttribute { get; set; }

        /// <summary>
        /// The Operations owned by the Interface.
        /// </summary>
        [Property(xmiId: "Interface-ownedOperation", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_redefinitionContext_redefinableElement-redefinableElement")]
        [SubsettedProperty(propertyName: "Classifier-feature")]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        public IContainerList<IOperation> OwnedOperation { get; set; }

        /// <summary>
        /// Receptions that objects providing this Interface are willing to accept.
        /// </summary>
        [Property(xmiId: "Interface-ownedReception", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Classifier-feature")]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        public IContainerList<IReception> OwnedReception { get; set; }

        /// <summary>
        /// References a ProtocolStateMachine specifying the legal sequences of the invocation of the
        /// BehavioralFeatures described in the Interface.
        /// </summary>
        [Property(xmiId: "Interface-protocol", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        public IContainerList<IProtocolStateMachine> Protocol { get; set; }

        /// <summary>
        /// References all the Interfaces redefined by this Interface.
        /// </summary>
        [Property(xmiId: "Interface-redefinedInterface", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Classifier-redefinedClassifier")]
        public List<IInterface> RedefinedInterface { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
