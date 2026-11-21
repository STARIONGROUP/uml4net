// -------------------------------------------------------------------------------------------------
// <copyright file="IGeneralOrdering.cs" company="Starion Group S.A.">
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
    /// A GeneralOrdering represents a binary relation between two OccurrenceSpecifications, to describe
    /// that one OccurrenceSpecification must occur before the other in a valid trace. This mechanism
    /// provides the ability to define partial orders of OccurrenceSpecifications that may otherwise not
    /// have a specified order.
    /// </summary>
    [Class(xmiId: "GeneralOrdering", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IGeneralOrdering : INamedElement
    {
        /// <summary>
        /// The OccurrenceSpecification referenced comes after the OccurrenceSpecification referenced by before.
        /// </summary>
        [Property(xmiId: "GeneralOrdering-after", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        public IOccurrenceSpecification After { get; set; }

        /// <summary>
        /// The OccurrenceSpecification referenced comes before the OccurrenceSpecification referenced by after.
        /// </summary>
        [Property(xmiId: "GeneralOrdering-before", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        public IOccurrenceSpecification Before { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
