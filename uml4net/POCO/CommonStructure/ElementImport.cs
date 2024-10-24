﻿// -------------------------------------------------------------------------------------------------
// <copyright file="ElementImport.cs" company="Starion Group S.A.">
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
    using uml4net.POCO.Classification;

    /// <summary>
    /// An ElementImport identifies a NamedElement in a Namespace other than the one that owns that 
    /// NamedElement and allows the NamedElement to be referenced using an unqualified name in the 
    /// Namespace owning the ElementImport.
    /// </summary>
    public class ElementImport : XmiElement, IElementImport
    {
        /// <summary>
        /// The Comments owned by this Element.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [Implements(implementation: "IElement.OwnedComment")]
        public List<IComment> OwnedComment { get; set; } = new List<IComment>();

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
        /// Specifies the name that should be added to the importing Namespace in lieu of the name of 
        /// the imported PackagableElement. The alias must not clash with any other member in the
        /// importing Namespace. By default, no alias is used.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [Implements(implementation: "IElementImport.Alias1")]
        public string Alias { get; set; }

        /// <summary>
        /// Specifies the PackageableElement whose name is to be added to a Namespace.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1)]
        [SubsettedProperty(propertyName: "DirectedRelationship.Target")]
        [Implements(implementation: "IElementImport.ImportedElement")]
        public IPackageableElement ImportedElement { get; set; }

        /// <summary>
        /// Specifies the Namespace that imports a PackageableElement from another Namespace.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1)]
        [SubsettedProperty(propertyName: "DirectedRelationship.Source")]
        [SubsettedProperty(propertyName: "Element.Oowner")]
        [Implements(implementation: "IElementImport.importingNamespace")]
        public INamespace importingNamespace { get; set; }

        /// <summary>
        /// Specifies the visibility of the imported PackageableElement within the importingNamespace, i.e., 
        /// whether the  importedElement will in turn be visible to other Namespaces. If the ElementImport is public,
        /// the importedElement will be visible outside the importingNamespace while, if the ElementImport is private, it will not.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1)]
        [Implements(implementation: "IElementImport.Visibility")]
        public VisibilityKind Visibility { get; set; }

        /// <summary>
        /// Specifies the elements related by the Relationship.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [Implements(implementation: "IRelationship.RelatedElement")]
        public List<IElement> RelatedElement => throw new NotImplementedException();
    }
}
