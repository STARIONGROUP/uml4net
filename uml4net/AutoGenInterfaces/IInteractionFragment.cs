// -------------------------------------------------------------------------------------------------
// <copyright file="IInteractionFragment.cs" company="Starion Group S.A.">
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
    /// InteractionFragment is an abstract notion of the most general interaction unit. An
    /// InteractionFragment is a piece of an Interaction. Each InteractionFragment is conceptually like an
    /// Interaction by itself.
    /// </summary>
    [Class(xmiId: "InteractionFragment", isAbstract: true, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IInteractionFragment : INamedElement
    {
        /// <summary>
        /// References the Lifelines that the InteractionFragment involves.
        /// </summary>
        [Property(xmiId: "InteractionFragment-covered", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        public List<ILifeline> Covered { get; set; }

        /// <summary>
        /// The Interaction enclosing this InteractionFragment.
        /// </summary>
        [Property(xmiId: "InteractionFragment-enclosingInteraction", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: true)]
        [SubsettedProperty(propertyName: "NamedElement-namespace")]
        public IInteraction EnclosingInteraction { get; set; }

        /// <summary>
        /// The operand enclosing this InteractionFragment (they may nest recursively).
        /// </summary>
        [Property(xmiId: "InteractionFragment-enclosingOperand", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: true)]
        [SubsettedProperty(propertyName: "NamedElement-namespace")]
        public IInteractionOperand EnclosingOperand { get; set; }

        /// <summary>
        /// The general ordering relationships contained in this fragment.
        /// </summary>
        [Property(xmiId: "InteractionFragment-generalOrdering", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IGeneralOrdering> GeneralOrdering { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
