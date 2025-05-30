﻿// -------------------------------------------------------------------------------------------------
// <copyright file="IActivity.cs" company="Starion Group S.A.">
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

namespace uml4net.Activities
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
    /// An Activity is the specification of parameterized Behavior as the coordinated sequencing of
    /// subordinate units.
    /// </summary>
    [Class(xmiId: "Activity", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IActivity : IBehavior
    {
        /// <summary>
        /// ActivityEdges expressing flow between the nodes of the Activity.
        /// </summary>
        [Property(xmiId: "Activity-edge", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IActivityEdge> Edge { get; set; }

        /// <summary>
        /// Top-level ActivityGroups in the Activity.
        /// </summary>
        [Property(xmiId: "Activity-group", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IActivityGroup> Group { get; set; }

        /// <summary>
        /// If true, this Activity must not make any changes to objects. The default is false (an Activity may
        /// make nonlocal changes). (This is an assertion, not an executable property. It may be used by an
        /// execution engine to optimize model execution. If the assertion is violated by the Activity, then the
        /// model is ill-formed.)
        /// </summary>
        [Property(xmiId: "Activity-isReadOnly", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: "false")]
        public bool IsReadOnly { get; set; }

        /// <summary>
        /// If true, all invocations of the Activity are handled by the same execution.
        /// </summary>
        [Property(xmiId: "Activity-isSingleExecution", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: "false")]
        public bool IsSingleExecution { get; set; }

        /// <summary>
        /// ActivityNodes coordinated by the Activity.
        /// </summary>
        [Property(xmiId: "Activity-node", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IActivityNode> Node { get; set; }

        /// <summary>
        /// Top-level ActivityPartitions in the Activity.
        /// </summary>
        [Property(xmiId: "Activity-partition", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Activity-group")]
        public List<IActivityPartition> Partition { get; set; }

        /// <summary>
        /// Top-level StructuredActivityNodes in the Activity.
        /// </summary>
        [Property(xmiId: "Activity-structuredNode", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Activity-group")]
        [SubsettedProperty(propertyName: "Activity-node")]
        public IContainerList<IStructuredActivityNode> StructuredNode { get; set; }

        /// <summary>
        /// Top-level Variables defined by the Activity.
        /// </summary>
        [Property(xmiId: "Activity-variable", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        public IContainerList<IVariable> Variable { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
