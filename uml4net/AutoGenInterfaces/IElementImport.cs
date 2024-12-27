// -------------------------------------------------------------------------------------------------
// <copyright file="IElementImport.cs" company="Starion Group S.A.">
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

    /// <summary>
    /// An ElementImport identifies a NamedElement in a Namespace other than the one that owns that
    /// NamedElement and allows the NamedElement to be referenced using an unqualified name in the Namespace
    /// owning the ElementImport.
    /// </summary>
    [Class(xmiId: "ElementImport", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IElementImport : IDirectedRelationship
    {
        /// <summary>
        /// Specifies the name that should be added to the importing Namespace in lieu of the name of the
        /// imported PackagableElement. The alias must not clash with any other member in the importing
        /// Namespace. By default, no alias is used.
        /// </summary>
        [Property(xmiId: "ElementImport-alias", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public string Alias { get; set; }

        /// <summary>
        /// Specifies the PackageableElement whose name is to be added to a Namespace.
        /// </summary>
        [Property(xmiId: "ElementImport-importedElement", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "DirectedRelationship-target")]
        public IPackageableElement ImportedElement { get; set; }

        /// <summary>
        /// Specifies the Namespace that imports a PackageableElement from another Namespace.
        /// </summary>
        [Property(xmiId: "ElementImport-importingNamespace", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "DirectedRelationship-source")]
        [SubsettedProperty(propertyName: "Element-owner")]
        public INamespace ImportingNamespace { get; set; }

        /// <summary>
        /// Specifies the visibility of the imported PackageableElement within the importingNamespace, i.e.,
        /// whether the  importedElement will in turn be visible to other Namespaces. If the ElementImport is
        /// public, the importedElement will be visible outside the importingNamespace while, if the
        /// ElementImport is private, it will not.
        /// </summary>
        [Property(xmiId: "ElementImport-visibility", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "public")]
        public VisibilityKind Visibility { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
