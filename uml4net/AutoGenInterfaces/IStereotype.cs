// -------------------------------------------------------------------------------------------------
// <copyright file="IStereotype.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
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
    /// A stereotype defines how an existing metaclass may be extended, and enables the use of platform or
    /// domain specific terminology or notation in place of, or in addition to, the ones used for the
    /// extended metaclass.
    /// </summary>
    [Class(xmiId: "Stereotype", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IStereotype : IClass
    {
        /// <summary>
        /// Stereotype can change the graphical appearance of the extended model element by using attached
        /// icons. When this association is not null, it references the location of the icon content to be
        /// displayed within diagrams presenting the extended model elements.
        /// </summary>
        [Property(xmiId: "Stereotype-icon", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IImage> Icon { get; set; }

        /// <summary>
        /// The profile that directly or indirectly contains this stereotype.
        /// </summary>
        [Property(xmiId: "Stereotype-profile", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        public IProfile Profile { get; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
