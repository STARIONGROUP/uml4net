// -------------------------------------------------------------------------------------------------
// <copyright file="INamespace.cs" company="Starion Group S.A.">
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
    /// A Namespace is an Element in a model that owns and/or imports a set of NamedElements that can be
    /// identified by name.
    /// </summary>
    [Class(xmiId: "Namespace", isAbstract: true, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface INamespace : INamedElement
    {
        /// <summary>
        /// References the ElementImports owned by the Namespace.
        /// </summary>
        [Property(xmiId: "Namespace-elementImport", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_source_directedRelationship-directedRelationship")]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IElementImport> ElementImport { get; set; }

        /// <summary>
        /// References the PackageableElements that are members of this Namespace as a result of either
        /// PackageImports or ElementImports.
        /// </summary>
        [Property(xmiId: "Namespace-importedMember", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-member")]
        public List<IPackageableElement> ImportedMember { get; }

        /// <summary>
        /// A collection of NamedElements identifiable within the Namespace, either by being owned or by being
        /// introduced by importing or inheritance.
        /// </summary>
        [Property(xmiId: "Namespace-member", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        public List<INamedElement> Member { get; }

        /// <summary>
        /// A collection of NamedElements owned by the Namespace.
        /// </summary>
        [Property(xmiId: "Namespace-ownedMember", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [SubsettedProperty(propertyName: "Namespace-member")]
        public IContainerList<INamedElement> OwnedMember { get; }

        /// <summary>
        /// Specifies a set of Constraints owned by this Namespace.
        /// </summary>
        [Property(xmiId: "Namespace-ownedRule", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        public IContainerList<IConstraint> OwnedRule { get; set; }

        /// <summary>
        /// References the PackageImports owned by the Namespace.
        /// </summary>
        [Property(xmiId: "Namespace-packageImport", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_source_directedRelationship-directedRelationship")]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IPackageImport> PackageImport { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
