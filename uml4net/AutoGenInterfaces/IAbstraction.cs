// -------------------------------------------------------------------------------------------------
// <copyright file="IAbstraction.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace uml4net.CommonStructure
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
    /// An Abstraction is a Relationship that relates two Elements or sets of Elements that represent the
    /// same concept at different levels of abstraction or from different viewpoints.
    /// </summary>
    [Class(xmiId: "Abstraction", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IAbstraction : IDependency
    {
        /// <summary>
        /// An OpaqueExpression that states the abstraction relationship between the supplier(s) and the
        /// client(s). In some cases, such as derivation, it is usually formal and unidirectional; in other
        /// cases, such as trace, it is usually informal and bidirectional. The mapping expression is optional
        /// and may be omitted if the precise relationship between the Elements is not specified.
        /// </summary>
        [Property(xmiId: "Abstraction-mapping", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IOpaqueExpression> Mapping { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
