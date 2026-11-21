// -------------------------------------------------------------------------------------------------
// <copyright file="IActivityGroup.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace uml4net.Activities
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
    /// ActivityGroup is an abstract class for defining sets of ActivityNodes and ActivityEdges in an
    /// Activity.
    /// </summary>
    [Class(xmiId: "ActivityGroup", isAbstract: true, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IActivityGroup : INamedElement
    {
        /// <summary>
        /// ActivityEdges immediately contained in the ActivityGroup.
        /// </summary>
        [Property(xmiId: "ActivityGroup-containedEdge", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        public IReadOnlyList<IActivityEdge> ContainedEdge { get; }

        /// <summary>
        /// ActivityNodes immediately contained in the ActivityGroup.
        /// </summary>
        [Property(xmiId: "ActivityGroup-containedNode", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        public IReadOnlyList<IActivityNode> ContainedNode { get; }

        /// <summary>
        /// The Activity containing the ActivityGroup, if it is directly owned by an Activity.
        /// </summary>
        [Property(xmiId: "ActivityGroup-inActivity", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: true)]
        [SubsettedProperty(propertyName: "Element-owner")]
        public IActivity InActivity { get; set; }

        /// <summary>
        /// Other ActivityGroups immediately contained in this ActivityGroup.
        /// </summary>
        [Property(xmiId: "ActivityGroup-subgroup", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IReadOnlyList<IActivityGroup> Subgroup { get; }

        /// <summary>
        /// The ActivityGroup immediately containing this ActivityGroup, if it is directly owned by another
        /// ActivityGroup.
        /// </summary>
        [Property(xmiId: "ActivityGroup-superGroup", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: true, defaultValue: null, isOwnerEnd: true)]
        [SubsettedProperty(propertyName: "Element-owner")]
        public IActivityGroup SuperGroup { get; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
