// -------------------------------------------------------------------------------------------------
// <copyright file="IDecisionNode.cs" company="Starion Group S.A.">
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
    /// A DecisionNode is a ControlNode that chooses between outgoing ActivityEdges for the routing of
    /// tokens.
    /// </summary>
    [Class(xmiId: "DecisionNode", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IDecisionNode : IControlNode
    {
        /// <summary>
        /// A Behavior that is executed to provide an input to guard ValueSpecifications on ActivityEdges
        /// outgoing from the DecisionNode.
        /// </summary>
        [Property(xmiId: "DecisionNode-decisionInput", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        public IBehavior DecisionInput { get; set; }

        /// <summary>
        /// An additional ActivityEdge incoming to the DecisionNode that provides a decision input value for the
        /// guards ValueSpecifications on ActivityEdges outgoing from the DecisionNode.
        /// </summary>
        [Property(xmiId: "DecisionNode-decisionInputFlow", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        public IObjectFlow DecisionInputFlow { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
