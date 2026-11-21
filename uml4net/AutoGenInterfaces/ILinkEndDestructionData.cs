// -------------------------------------------------------------------------------------------------
// <copyright file="ILinkEndDestructionData.cs" company="Starion Group S.A.">
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
    /// LinkEndDestructionData is LinkEndData used to provide values for one end of a link to be destroyed
    /// by a DestroyLinkAction.
    /// </summary>
    [Class(xmiId: "LinkEndDestructionData", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface ILinkEndDestructionData : ILinkEndData
    {
        /// <summary>
        /// The InputPin that provides the position of an existing link to be destroyed in an ordered, nonunique
        /// Association end. The type of the destroyAt InputPin is UnlimitedNatural, but the value cannot be
        /// zero or unlimited.
        /// </summary>
        [Property(xmiId: "LinkEndDestructionData-destroyAt", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        public IInputPin DestroyAt { get; set; }

        /// <summary>
        /// Specifies whether to destroy duplicates of the value in nonunique Association ends.
        /// </summary>
        [Property(xmiId: "LinkEndDestructionData-isDestroyDuplicates", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: "false", isOwnerEnd: false)]
        public bool IsDestroyDuplicates { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
