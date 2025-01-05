// -------------------------------------------------------------------------------------------------
// <copyright file="IExtend.cs" company="Starion Group S.A.">
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

namespace uml4net.UseCases
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
    /// A relationship from an extending UseCase to an extended UseCase that specifies how and when the
    /// behavior defined in the extending UseCase can be inserted into the behavior defined in the extended
    /// UseCase.
    /// </summary>
    [Class(xmiId: "Extend", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IExtend : INamedElement, IDirectedRelationship
    {
        /// <summary>
        /// References the condition that must hold when the first ExtensionPoint is reached for the extension
        /// to take place. If no constraint is associated with the Extend relationship, the extension is
        /// unconditional.
        /// </summary>
        [Property(xmiId: "Extend-condition", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IConstraint> Condition { get; set; }

        /// <summary>
        /// The UseCase that is being extended.
        /// </summary>
        [Property(xmiId: "Extend-extendedCase", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "DirectedRelationship-target")]
        public IUseCase ExtendedCase { get; set; }

        /// <summary>
        /// The UseCase that represents the extension and owns the Extend relationship.
        /// </summary>
        [Property(xmiId: "Extend-extension", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "DirectedRelationship-source")]
        [SubsettedProperty(propertyName: "NamedElement-namespace")]
        public IUseCase Extension { get; set; }

        /// <summary>
        /// An ordered list of ExtensionPoints belonging to the extended UseCase, specifying where the
        /// respective behavioral fragments of the extending UseCase are to be inserted. The first fragment in
        /// the extending UseCase is associated with the first extension point in the list, the second fragment
        /// with the second point, and so on. Note that, in most practical cases, the extending UseCase has just
        /// a single behavior fragment, so that the list of ExtensionPoints is trivial.
        /// </summary>
        [Property(xmiId: "Extend-extensionLocation", aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue, isOrdered: true, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public List<IExtensionPoint> ExtensionLocation { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
