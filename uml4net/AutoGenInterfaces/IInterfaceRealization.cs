// -------------------------------------------------------------------------------------------------
// <copyright file="IInterfaceRealization.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace uml4net.SimpleClassifiers
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
    /// An InterfaceRealization is a specialized realization relationship between a BehavioredClassifier and
    /// an Interface. This relationship signifies that the realizing BehavioredClassifier conforms to the
    /// contract specified by the Interface.
    /// </summary>
    [Class(xmiId: "InterfaceRealization", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IInterfaceRealization : IRealization
    {
        /// <summary>
        /// References the Interface specifying the conformance contract.
        /// </summary>
        [Property(xmiId: "InterfaceRealization-contract", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        [SubsettedProperty(propertyName: "Dependency-supplier")]
        public IInterface Contract { get; set; }

        /// <summary>
        /// References the BehavioredClassifier that owns this InterfaceRealization, i.e., the
        /// BehavioredClassifier that realizes the Interface to which it refers.
        /// </summary>
        [Property(xmiId: "InterfaceRealization-implementingClassifier", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: true)]
        [SubsettedProperty(propertyName: "Dependency-client")]
        [SubsettedProperty(propertyName: "Element-owner")]
        public IBehavioredClassifier ImplementingClassifier { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
