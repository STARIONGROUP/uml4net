// -------------------------------------------------------------------------------------------------
// <copyright file="IAcceptCallAction.cs" company="Starion Group S.A.">
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
    /// An AcceptCallAction is an AcceptEventAction that handles the receipt of a synchronous call request.
    /// In addition to the values from the Operation input parameters, the Action produces an output that is
    /// needed later to supply the information to the ReplyAction necessary to return control to the caller.
    /// An AcceptCallAction is for synchronous calls. If it is used to handle an asynchronous call,
    /// execution of the subsequent ReplyAction will complete immediately with no effect.
    /// </summary>
    [Class(xmiId: "AcceptCallAction", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IAcceptCallAction : IAcceptEventAction
    {
        /// <summary>
        /// An OutputPin where a value is placed containing sufficient information to perform a subsequent
        /// ReplyAction and return control to the caller. The contents of this value are opaque. It can be
        /// passed and copied but it cannot be manipulated by the model.
        /// </summary>
        [Property(xmiId: "AcceptCallAction-returnInformation", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        [SubsettedProperty(propertyName: "Action-output")]
        public IContainerList<IOutputPin> ReturnInformation { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
