// -------------------------------------------------------------------------------------------------
// <copyright file="IPackageImport.cs" company="Starion Group S.A.">
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

namespace uml4net.POCO.CommonStructure
{
    using System.Collections.Generic;

    using uml4net.Decorators;
    using uml4net.POCO.Classification;
    using uml4net.POCO.Packages;

    /// <summary>
    /// A PackageImport is a Relationship that imports all the non-private members of a Package into the
    /// Namespace owning the PackageImport, so that those Elements may be referred to by their unqualified 
    /// names in the importingNamespace.
    /// </summary>
    public interface IPackageImport : IDirectedRelationship
    {
        /// <summary>
        /// Gets or sets a dictionary of reference properties and the associated unique identifiers
        /// </summary>
        public Dictionary<string, string> ReferencePropertyValueIdentifies { get; set; }

        /// <summary>
        /// Specifies the Package whose members are imported into a Namespace.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1)]
        [SubsettedProperty(propertyName: "DirectedRelationship.Target")]
        public IPackage ImportedPackage { get; set; }

        /// <summary>
        /// Specifies the Namespace that imports the members from a Package.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1)]
        [SubsettedProperty(propertyName: "DirectedRelationship.Source")]
        [SubsettedProperty(propertyName: "Element.Owner")]
        public INamespace ImportingNamespace { get; set; }

        /// <summary>
        /// Specifies the visibility of the imported PackageableElements within the importingNamespace, i.e., 
        /// whether imported Elements will in turn be visible to other Namespaces. If the PackageImport is public, 
        /// the imported Elements will be visible outside the importingNamespace, while, if the PackageImport is private, they will not.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1)]
        public VisibilityKind Visibility { get; set; }
    }
}
