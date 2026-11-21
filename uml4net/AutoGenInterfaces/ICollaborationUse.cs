// -------------------------------------------------------------------------------------------------
// <copyright file="ICollaborationUse.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace uml4net.StructuredClassifiers
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
    /// A CollaborationUse is used to specify the application of a pattern specified by a Collaboration to a
    /// specific situation.
    /// </summary>
    [Class(xmiId: "CollaborationUse", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface ICollaborationUse : INamedElement
    {
        /// <summary>
        /// A mapping between features of the Collaboration and features of the owning Classifier. This mapping
        /// indicates which ConnectableElement of the Classifier plays which role(s) in the Collaboration. A
        /// ConnectableElement may be bound to multiple roles in the same CollaborationUse (that is, it may play
        /// multiple roles).
        /// </summary>
        [Property(xmiId: "CollaborationUse-roleBinding", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IDependency> RoleBinding { get; set; }

        /// <summary>
        /// The Collaboration which is used in this CollaborationUse. The Collaboration defines the cooperation
        /// between its roles which are mapped to ConnectableElements relating to the Classifier owning the
        /// CollaborationUse.
        /// </summary>
        [Property(xmiId: "CollaborationUse-type", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        public ICollaboration Type { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
