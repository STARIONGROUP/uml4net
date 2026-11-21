// -------------------------------------------------------------------------------------------------
// <copyright file="IVariable.cs" company="Starion Group S.A.">
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
    /// A Variable is a ConnectableElement that may store values during the execution of an Activity.
    /// Reading and writing the values of a Variable provides an alternative means for passing data than the
    /// use of ObjectFlows. A Variable may be owned directly by an Activity, in which case it is accessible
    /// from anywhere within that activity, or it may be owned by a StructuredActivityNode, in which case it
    /// is only accessible within that node.
    /// </summary>
    [Class(xmiId: "Variable", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IVariable : IConnectableElement, IMultiplicityElement
    {
        /// <summary>
        /// An Activity that owns the Variable.
        /// </summary>
        [Property(xmiId: "Variable-activityScope", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: true)]
        [SubsettedProperty(propertyName: "NamedElement-namespace")]
        public IActivity ActivityScope { get; set; }

        /// <summary>
        /// A StructuredActivityNode that owns the Variable.
        /// </summary>
        [Property(xmiId: "Variable-scope", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: true)]
        [SubsettedProperty(propertyName: "NamedElement-namespace")]
        public IStructuredActivityNode Scope { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
