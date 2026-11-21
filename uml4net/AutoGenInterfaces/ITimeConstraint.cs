// -------------------------------------------------------------------------------------------------
// <copyright file="ITimeConstraint.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace uml4net.Values
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
    /// A TimeConstraint is a Constraint that refers to a TimeInterval.
    /// </summary>
    [Class(xmiId: "TimeConstraint", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface ITimeConstraint : IIntervalConstraint
    {
        /// <summary>
        /// The value of firstEvent is related to the constrainedElement. If firstEvent is true, then the
        /// corresponding observation event is the first time instant the execution enters the
        /// constrainedElement. If firstEvent is false, then the corresponding observation event is the last
        /// time instant the execution is within the constrainedElement.
        /// </summary>
        [Property(xmiId: "TimeConstraint-firstEvent", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: "true", isOwnerEnd: false)]
        public bool? FirstEvent { get; set; }

        /// <summary>
        /// TheTimeInterval constraining the duration.
        /// </summary>
        [Property(xmiId: "TimeConstraint-specification", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        [RedefinedProperty(propertyName: "IntervalConstraint-specification")]
        public new IContainerList<ITimeInterval> Specification { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
