// -------------------------------------------------------------------------------------------------
// <copyright file="IPackageImport.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2024 Starion Group S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
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

    using uml4net.Utils;

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
        [Property(xmiId: "PackageImport-importedPackage", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "DirectedRelationship-target")]
        public IPackage ImportedPackage { get; set; }

        /// <summary>
        /// Specifies the Namespace that imports the members from a Package.
        /// </summary>
        [Property(xmiId: "PackageImport-importingNamespace", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "DirectedRelationship-source")]
        [SubsettedProperty(propertyName: "Element-owner")]
        public INamespace ImportingNamespace { get; set; }

        /// <summary>
        /// Specifies the visibility of the imported PackageableElements within the importingNamespace, i.e.,
        /// whether imported Elements will in turn be visible to other Namespaces. If the PackageImport is
        /// public, the imported Elements will be visible outside the importingNamespace, while, if the
        /// PackageImport is private, they will not.
        /// </summary>
        [Property(xmiId: "PackageImport-visibility", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "public")]
        public VisibilityKind Visibility { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
