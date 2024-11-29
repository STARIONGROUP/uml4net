// -------------------------------------------------------------------------------------------------
// <copyright file="IPackage.cs" company="Starion Group S.A.">
//
//   Copyright 2019-2024 Starion Group S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, softwareUseCases
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.POCO.Packages
{
    using System.Collections.Generic;

    using uml4net.Decorators;
    using uml4net.POCO.Classification;
    using uml4net.POCO.CommonStructure;
    using Utils;

    /// <summary>
    /// A package can have one or more profile applications to indicate which profiles have been applied.
    /// Because a profile is a package, it is possible to apply a profile not only to packages, but also
    /// to profiles.&#xA;Package specializes TemplateableElement and PackageableElement specializes 
    /// ParameterableElement to specify that a package can be used as a template and a PackageableElement
    /// as a template parameter. A package is used to group elements, and provides a namespace for the grouped elements.
    /// </summary>
    public interface IPackage : IPackageableElement, ITemplateableElement, INamespace
    {
        /// <summary>
        /// Provides an identifier for the package that can be used for many purposes. A URI is the universally
        /// unique identification of the package following the IETF URI specification, RFC 2396 http://www.ietf.org/rfc/rfc2396.txt
        /// and it must comply with those syntax rules.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        public string URI { get; set; }

        /// <summary>
        /// References the packaged elements that are Packages.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isDerived:true)]
        [SubsettedProperty("Package-packagedElement")]
        public List<IPackage> NestedPackage { get; }

        /// <summary>
        /// References the Package that owns this Package.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [SubsettedProperty("A_packagedElement_owningPackage-owningPackage")]
        public IPackage NestingPackage { get; set; }

        /// <summary>
        /// References the Stereotypes that are owned by the Package.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isReadOnly:true, isDerived:true)]
        [SubsettedProperty("Package-packagedElement")]
        public IStereotype OwnedStereotype { get; }

        /// <summary>
        /// References the packaged elements that are Types.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isDerived: true)]
        [SubsettedProperty("A_ownedType_package")]
        public List<IType> OwnedType { get; }

        /// <summary>
        /// References the PackageMerges that are owned by this Package.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty("A_source_directedRelationship-directedRelationship")]
        [SubsettedProperty("Element-ownedElement")]
        public List<IPackageMerge> PackageMerge { get; set; }

        /// <summary>
        /// Specifies the packageable elements that are owned by this Package.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty("Namespace-ownedMember")]
        public IContainerList<IPackageableElement> PackagedElement { get; set; }

        /// <summary>
        /// References the ProfileApplications that indicate which profiles have been applied to the Package.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty("A_source_directedRelationship-directedRelationship")]
        [SubsettedProperty("Element-ownedElement")]
        public IContainerList<IProfileApplication> ProfileApplication { get; set; }
    }
}

