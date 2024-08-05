// -------------------------------------------------------------------------------------------------
// <copyright file="PackageImport.cs" company="Starion Group S.A.">
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
    using System;
    using System.Collections.Generic;

    using uml4net.Decorators;
    using uml4net.POCO.Packages;
    using uml4net.POCO.StructuredClassifiers;

    /// <summary>
    /// A PackageImport is a Relationship that imports all the non-private members of a Package into the
    /// Namespace owning the PackageImport, so that those Elements may be referred to by their unqualified 
    /// names in the importingNamespace.
    /// </summary>
    public class PackageImport : IPackageImport
    {
        /// <summary>
        /// Gets or sets the unique identifier of the Element in the XMI document
        /// </summary>
        [Implements(implementation: "IPackageImport.XmiId")]
        public string XmiId { get; set; }

        /// <summary>
        /// Gets or sets a dictionary of reference properties and the associated unique identifiers
        /// </summary>
        [Implements(implementation: "IPackageImport.ReferencePropertyValueIdentifies")]
        public Dictionary<string, string> ReferencePropertyValueIdentifies { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// The Comments owned by this Element.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [Implements(implementation: "IElement.OwnedComment")]
        public List<IComment> OwnedComment { get; set; }

        /// <summary>
        /// The Elements owned by this Element
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [Implements(implementation: "IElement.OwnedElement")]
        public List<IElement> OwnedElement => throw new NotImplementedException();

        /// <summary>
        /// The Element that owns this Element.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [Implements(implementation: "IElement.Owner")]
        public IElement Owner => throw new NotImplementedException();

        /// <summary>
        /// Specifies the source Element(s) of the DirectedRelationship.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [Implements(implementation: "IDirectedRelationship.Source")]
        [SubsettedProperty(propertyName: "Relationship.RelatedElement")]
        public List<IElement> Source => throw new NotImplementedException();

        /// <summary>
        /// Specifies the target Element(s) of the DirectedRelationship.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [Implements(implementation: "IDirectedRelationship.Target")]
        [SubsettedProperty(propertyName: "Relationship.RelatedElement")]
        public List<IElement> Target => throw new NotImplementedException();

        /// <summary>
        /// Specifies the Package whose members are imported into a Namespace.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1)]
        [SubsettedProperty(propertyName: "DirectedRelationship.Target")]
        [Implements(implementation: "IPackageImport.ImportedPackage")]
        public IPackage ImportedPackage { get; set; }

        /// <summary>
        /// Specifies the Namespace that imports the members from a Package.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1)]
        [SubsettedProperty(propertyName: "DirectedRelationship.Source")]
        [SubsettedProperty(propertyName: "Element.Owner")]
        [Implements(implementation: "IPackageImport.ImportingNamespace")]
        public INamespace ImportingNamespace { get; set; }

        /// <summary>
        /// Specifies the visibility of the imported PackageableElements within the importingNamespace, i.e., 
        /// whether imported Elements will in turn be visible to other Namespaces. If the PackageImport is public, 
        /// the imported Elements will be visible outside the importingNamespace, while, if the PackageImport is private, they will not.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1)]
        [Implements(implementation: "IPackageImport.Visibility")]
        public VisibilityKind Visibility { get; set; } = VisibilityKind.Public;
    }
}
