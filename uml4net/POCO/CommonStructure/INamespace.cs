// -------------------------------------------------------------------------------------------------
// <copyright file="INamespace.cs" company="Starion Group S.A.">
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
    using uml4net.POCO.StructuredClassifiers;

    /// <summary>
    /// A Namespace is an Element in a model that owns and/or imports a set of NamedElements that can be identified by name.
    /// </summary>
    public interface INamespace : INamedElement
    {
        /// <summary>
        /// References the ElementImports owned by the Namespace.
        /// </summary>
        [Feature(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty(propertyName: "A_source_directedRelationship.directedRelationship")]
        [SubsettedProperty(propertyName: "Element.OwnedElement")]
        public List<ElementImport> ElementImport { get; set; }

        /// <summary>
        /// References the PackageableElements that are members of this Namespace as a result of either PackageImports or ElementImports.
        /// </summary>
        [Feature(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isReadOnly:true, isDerived:true)]
        [SubsettedProperty(propertyName: "Namespace.Member")]
        public List<IPackageableElement> ImportedMember { get; }

        /// <summary>
        /// A collection of NamedElements owned by the Namespace.
        /// </summary>
        [Feature(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isReadOnly: true, isDerived: true, isDerivedUnion:true)]
        [SubsettedProperty(propertyName: "Element`.OwnedElement")]
        [SubsettedProperty(propertyName: "Namespace.Member")]
        public List<INamedElement> OwnedMember { get; }

        /// <summary>
        /// Specifies a set of Constraints owned by this Namespace.
        /// </summary>
        [Feature(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty(propertyName: "Namespace.OwnedMember")]
        public List<IConstraint> OwnedRule { get; set; }

        /// <summary>
        /// References the PackageImports owned by the Namespace.
        /// </summary>
        [Feature(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty(propertyName: "Element`.OwnedElement")]
        public List<IPackageImport> PackageImport { get; set; }
    }
}
