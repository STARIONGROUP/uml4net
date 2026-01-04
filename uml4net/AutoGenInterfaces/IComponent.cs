// -------------------------------------------------------------------------------------------------
// <copyright file="IComponent.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2026 Starion Group S.A.
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

namespace uml4net.StructuredClassifiers
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
    /// A Component represents a modular part of a system that encapsulates its contents and whose
    /// manifestation is replaceable within its environment.
    /// </summary>
    [Class(xmiId: "Component", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IComponent : IClass
    {
        /// <summary>
        /// If true, the Component is defined at design-time, but at run-time (or execution-time) an object
        /// specified by the Component does not exist, that is, the Component is instantiated indirectly,
        /// through the instantiation of its realizing Classifiers or parts.
        /// </summary>
        [Property(xmiId: "Component-isIndirectlyInstantiated", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: "true")]
        public bool IsIndirectlyInstantiated { get; set; }

        /// <summary>
        /// The set of PackageableElements that a Component owns. In the namespace of a Component, all model
        /// elements that are involved in or related to its definition may be owned or imported explicitly.
        /// These may include e.g., Classes, Interfaces, Components, Packages, UseCases, Dependencies (e.g.,
        /// mappings), and Artifacts.
        /// </summary>
        [Property(xmiId: "Component-packagedElement", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        public IContainerList<IPackageableElement> PackagedElement { get; set; }

        /// <summary>
        /// The Interfaces that the Component exposes to its environment. These Interfaces may be Realized by
        /// the Component or any of its realizingClassifiers, or they may be the Interfaces that are provided by
        /// its public Ports.
        /// </summary>
        [Property(xmiId: "Component-provided", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public List<IInterface> Provided { get; }

        /// <summary>
        /// The set of Realizations owned by the Component. Realizations reference the Classifiers of which the
        /// Component is an abstraction; i.e., that realize its behavior.
        /// </summary>
        [Property(xmiId: "Component-realization", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_supplier_supplierDependency-supplierDependency")]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IComponentRealization> Realization { get; set; }

        /// <summary>
        /// The Interfaces that the Component requires from other Components in its environment in order to be
        /// able to offer its full set of provided functionality. These Interfaces may be used by the Component
        /// or any of its realizingClassifiers, or they may be the Interfaces that are required by its public
        /// Ports.
        /// </summary>
        [Property(xmiId: "Component-required", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public List<IInterface> Required { get; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
