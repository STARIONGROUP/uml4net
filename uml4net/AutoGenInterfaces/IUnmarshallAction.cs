// -------------------------------------------------------------------------------------------------
// <copyright file="IUnmarshallAction.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace uml4net.Actions
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
    /// An UnmarshallAction is an Action that retrieves the values of the StructuralFeatures of an object
    /// and places them on OutputPins.
    /// </summary>
    [Class(xmiId: "UnmarshallAction", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IUnmarshallAction : IAction
    {
        /// <summary>
        /// The InputPin that gives the object to be unmarshalled.
        /// </summary>
        [Property(xmiId: "UnmarshallAction-object", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        [SubsettedProperty(propertyName: "Action-input")]
        public IContainerList<IInputPin> Object { get; set; }

        /// <summary>
        /// The OutputPins on which are placed the values of the StructuralFeatures of the input object.
        /// </summary>
        [Property(xmiId: "UnmarshallAction-result", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: int.MaxValue, isOrdered: true, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        [SubsettedProperty(propertyName: "Action-output")]
        public IContainerList<IOutputPin> Result { get; set; }

        /// <summary>
        /// The type of the object to be unmarshalled.
        /// </summary>
        [Property(xmiId: "UnmarshallAction-unmarshallType", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        public IClassifier UnmarshallType { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
