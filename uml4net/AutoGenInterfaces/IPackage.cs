// -------------------------------------------------------------------------------------------------
// <copyright file="IPackage.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2025 Starion Group S.A.
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

namespace uml4net.Packages
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
    /// A package can have one or more profile applications to indicate which profiles have been applied.
    /// Because a profile is a package, it is possible to apply a profile not only to packages, but also to
    /// profiles.Package specializes TemplateableElement and PackageableElement specializes
    /// ParameterableElement to specify that a package can be used as a template and a PackageableElement as
    /// a template parameter.A package is used to group elements, and provides a namespace for the grouped
    /// elements.
    /// </summary>
    [Class(xmiId: "Package", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IPackage : IPackageableElement, ITemplateableElement, INamespace
    {
        /// <summary>
        /// Provides an identifier for the package that can be used for many purposes. A URI is the universally
        /// unique identification of the package following the IETF URI specification, RFC 2396
        /// http://www.ietf.org/rfc/rfc2396.txt and it must comply with those syntax rules.
        /// </summary>
        [Property(xmiId: "Package-URI", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public string URI { get; set; }

        /// <summary>
        /// References the packaged elements that are Packages.
        /// </summary>
        [Property(xmiId: "Package-nestedPackage", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Package-packagedElement")]
        public IContainerList<IPackage> NestedPackage { get; }

        /// <summary>
        /// References the Package that owns this Package.
        /// </summary>
        [Property(xmiId: "Package-nestingPackage", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_packagedElement_owningPackage-owningPackage")]
        public IPackage NestingPackage { get; set; }

        /// <summary>
        /// References the Stereotypes that are owned by the Package.
        /// </summary>
        [Property(xmiId: "Package-ownedStereotype", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Package-packagedElement")]
        public IContainerList<IStereotype> OwnedStereotype { get; }

        /// <summary>
        /// References the packaged elements that are Types.
        /// </summary>
        [Property(xmiId: "Package-ownedType", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Package-packagedElement")]
        public IContainerList<IType> OwnedType { get; }

        /// <summary>
        /// References the PackageMerges that are owned by this Package.
        /// </summary>
        [Property(xmiId: "Package-packageMerge", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_source_directedRelationship-directedRelationship")]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IPackageMerge> PackageMerge { get; set; }

        /// <summary>
        /// Specifies the packageable elements that are owned by this Package.
        /// </summary>
        [Property(xmiId: "Package-packagedElement", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        public IContainerList<IPackageableElement> PackagedElement { get; set; }

        /// <summary>
        /// References the ProfileApplications that indicate which profiles have been applied to the Package.
        /// </summary>
        [Property(xmiId: "Package-profileApplication", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_source_directedRelationship-directedRelationship")]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IProfileApplication> ProfileApplication { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
