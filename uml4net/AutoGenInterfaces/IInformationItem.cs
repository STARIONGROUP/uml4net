// -------------------------------------------------------------------------------------------------
// <copyright file="IInformationItem.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace uml4net.InformationFlows
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
    /// InformationItems represent many kinds of information that can flow from sources to targets in very
    /// abstract ways.  They represent the kinds of information that may move within a system, but do not
    /// elaborate details of the transferred information.  Details of transferred information are the
    /// province of other Classifiers that may ultimately define InformationItems.  Consequently,
    /// InformationItems cannot be instantiated and do not themselves have features, generalizations, or
    /// associations. An important use of InformationItems is to represent information during early design
    /// stages, possibly before the detailed modeling decisions that will ultimately define them have been
    /// made. Another purpose of InformationItems is to abstract portions of complex models in less precise,
    /// but perhaps more general and communicable, ways.
    /// </summary>
    [Class(xmiId: "InformationItem", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IInformationItem : IClassifier
    {
        /// <summary>
        /// Determines the classifiers that will specify the structure and nature of the information. An
        /// information item represents all its represented classifiers.
        /// </summary>
        [Property(xmiId: "InformationItem-represented", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        public List<IClassifier> Represented { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
