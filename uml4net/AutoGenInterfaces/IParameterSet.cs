// -------------------------------------------------------------------------------------------------
// <copyright file="IParameterSet.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace uml4net.Classification
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
    /// A ParameterSet designates alternative sets of inputs or outputs that a Behavior may use.
    /// </summary>
    [Class(xmiId: "ParameterSet", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IParameterSet : INamedElement
    {
        /// <summary>
        /// A constraint that should be satisfied for the owner of the Parameters in an input ParameterSet to
        /// start execution using the values provided for those Parameters, or the owner of the Parameters in an
        /// output ParameterSet to end execution providing the values for those Parameters, if all preconditions
        /// and conditions on input ParameterSets were satisfied.
        /// </summary>
        [Property(xmiId: "ParameterSet-condition", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IConstraint> Condition { get; set; }

        /// <summary>
        /// Parameters in the ParameterSet.
        /// </summary>
        [Property(xmiId: "ParameterSet-parameter", aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null, isOwnerEnd: false)]
        public List<IParameter> Parameter { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
