// -------------------------------------------------------------------------------------------------
// <copyright file="IOccurrenceSpecification.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace uml4net.Interactions
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
    /// An OccurrenceSpecification is the basic semantic unit of Interactions. The sequences of occurrences
    /// specified by them are the meanings of Interactions.
    /// </summary>
    [Class(xmiId: "OccurrenceSpecification", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IOccurrenceSpecification : IInteractionFragment
    {
        /// <summary>
        /// References the Lifeline on which the OccurrenceSpecification appears.
        /// </summary>
        [Property(xmiId: "OccurrenceSpecification-covered", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        [RedefinedProperty(propertyName: "InteractionFragment-covered")]
        public new ILifeline Covered { get; set; }

        /// <summary>
        /// References the GeneralOrderings that specify EventOcurrences that must occur after this
        /// OccurrenceSpecification.
        /// </summary>
        [Property(xmiId: "OccurrenceSpecification-toAfter", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        public List<IGeneralOrdering> ToAfter { get; set; }

        /// <summary>
        /// References the GeneralOrderings that specify EventOcurrences that must occur before this
        /// OccurrenceSpecification.
        /// </summary>
        [Property(xmiId: "OccurrenceSpecification-toBefore", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        public List<IGeneralOrdering> ToBefore { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
