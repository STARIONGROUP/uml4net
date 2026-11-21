// -------------------------------------------------------------------------------------------------
// <copyright file="IExpansionRegion.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace uml4net.Actions
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
    /// An ExpansionRegion is a StructuredActivityNode that executes its content multiple times
    /// corresponding to elements of input collection(s).
    /// </summary>
    [Class(xmiId: "ExpansionRegion", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IExpansionRegion : IStructuredActivityNode
    {
        /// <summary>
        /// The ExpansionNodes that hold the input collections for the ExpansionRegion.
        /// </summary>
        [Property(xmiId: "ExpansionRegion-inputElement", aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        public List<IExpansionNode> InputElement { get; set; }

        /// <summary>
        /// The mode in which the ExpansionRegion executes its contents. If parallel, executions are concurrent.
        /// If iterative, executions are sequential. If stream, a stream of values flows into a single
        /// execution.
        /// </summary>
        [Property(xmiId: "ExpansionRegion-mode", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: "iterative", isOwnerEnd: false)]
        public ExpansionKind Mode { get; set; }

        /// <summary>
        /// The ExpansionNodes that form the output collections of the ExpansionRegion.
        /// </summary>
        [Property(xmiId: "ExpansionRegion-outputElement", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        public List<IExpansionNode> OutputElement { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
