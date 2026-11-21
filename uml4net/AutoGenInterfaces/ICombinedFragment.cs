// -------------------------------------------------------------------------------------------------
// <copyright file="ICombinedFragment.cs" company="Starion Group S.A.">
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
    /// A CombinedFragment defines an expression of InteractionFragments. A CombinedFragment is defined by
    /// an interaction operator and corresponding InteractionOperands. Through the use of CombinedFragments
    /// the user will be able to describe a number of traces in a compact and concise manner.
    /// </summary>
    [Class(xmiId: "CombinedFragment", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface ICombinedFragment : IInteractionFragment
    {
        /// <summary>
        /// Specifies the gates that form the interface between this CombinedFragment and its surroundings
        /// </summary>
        [Property(xmiId: "CombinedFragment-cfragmentGate", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IGate> CfragmentGate { get; set; }

        /// <summary>
        /// Specifies the operation which defines the semantics of this combination of InteractionFragments.
        /// </summary>
        [Property(xmiId: "CombinedFragment-interactionOperator", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: "seq", isOwnerEnd: false)]
        public InteractionOperatorKind InteractionOperator { get; set; }

        /// <summary>
        /// The set of operands of the combined fragment.
        /// </summary>
        [Property(xmiId: "CombinedFragment-operand", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: int.MaxValue, isOrdered: true, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IInteractionOperand> Operand { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
