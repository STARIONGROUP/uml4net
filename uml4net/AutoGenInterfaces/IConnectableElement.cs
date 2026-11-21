// -------------------------------------------------------------------------------------------------
// <copyright file="IConnectableElement.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
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
    /// ConnectableElement is an abstract metaclass representing a set of instances that play roles of a
    /// StructuredClassifier. ConnectableElements may be joined by attached Connectors and specify
    /// configurations of linked instances to be created within an instance of the containing
    /// StructuredClassifier.
    /// </summary>
    [Class(xmiId: "ConnectableElement", isAbstract: true, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IConnectableElement : ITypedElement, IParameterableElement
    {
        /// <summary>
        /// A set of ConnectorEnds that attach to this ConnectableElement.
        /// </summary>
        [Property(xmiId: "ConnectableElement-end", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        public IReadOnlyList<IConnectorEnd> End { get; }

        /// <summary>
        /// The ConnectableElementTemplateParameter for this ConnectableElement parameter.
        /// </summary>
        [Property(xmiId: "ConnectableElement-templateParameter", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        [RedefinedProperty(propertyName: "ParameterableElement-templateParameter")]
        public new IConnectableElementTemplateParameter TemplateParameter { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
