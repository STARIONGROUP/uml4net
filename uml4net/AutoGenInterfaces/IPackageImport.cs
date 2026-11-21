// -------------------------------------------------------------------------------------------------
// <copyright file="IPackageImport.cs" company="Starion Group S.A.">
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
    /// A PackageImport is a Relationship that imports all the non-private members of a Package into the
    /// Namespace owning the PackageImport, so that those Elements may be referred to by their unqualified
    /// names in the importingNamespace.
    /// </summary>
    [Class(xmiId: "PackageImport", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IPackageImport : IDirectedRelationship
    {
        /// <summary>
        /// Specifies the Package whose members are imported into a Namespace.
        /// </summary>
        [Property(xmiId: "PackageImport-importedPackage", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        [SubsettedProperty(propertyName: "DirectedRelationship-target")]
        public IPackage ImportedPackage { get; set; }

        /// <summary>
        /// Specifies the Namespace that imports the members from a Package.
        /// </summary>
        [Property(xmiId: "PackageImport-importingNamespace", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: true)]
        [SubsettedProperty(propertyName: "DirectedRelationship-source")]
        [SubsettedProperty(propertyName: "Element-owner")]
        public INamespace ImportingNamespace { get; set; }

        /// <summary>
        /// Specifies the visibility of the imported PackageableElements within the importingNamespace, i.e.,
        /// whether imported Elements will in turn be visible to other Namespaces. If the PackageImport is
        /// public, the imported Elements will be visible outside the importingNamespace, while, if the
        /// PackageImport is private, they will not.
        /// </summary>
        [Property(xmiId: "PackageImport-visibility", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: "public", isOwnerEnd: false)]
        public VisibilityKind Visibility { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
