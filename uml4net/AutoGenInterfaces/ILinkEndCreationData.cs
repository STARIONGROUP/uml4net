// -------------------------------------------------------------------------------------------------
// <copyright file="ILinkEndCreationData.cs" company="Starion Group S.A.">
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
    /// LinkEndCreationData is LinkEndData used to provide values for one end of a link to be created by a
    /// CreateLinkAction.
    /// </summary>
    [Class(xmiId: "LinkEndCreationData", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface ILinkEndCreationData : ILinkEndData
    {
        /// <summary>
        /// For ordered Association ends, the InputPin that provides the position where the new link should be
        /// inserted or where an existing link should be moved to. The type of the insertAt InputPin is
        /// UnlimitedNatural, but the input cannot be zero. It is omitted for Association ends that are not
        /// ordered.
        /// </summary>
        [Property(xmiId: "LinkEndCreationData-insertAt", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        public IInputPin InsertAt { get; set; }

        /// <summary>
        /// Specifies whether the existing links emanating from the object on this end should be destroyed
        /// before creating a new link.
        /// </summary>
        [Property(xmiId: "LinkEndCreationData-isReplaceAll", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: "false", isOwnerEnd: false)]
        public bool IsReplaceAll { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
