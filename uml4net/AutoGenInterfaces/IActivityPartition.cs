// -------------------------------------------------------------------------------------------------
// <copyright file="IActivityPartition.cs" company="Starion Group S.A.">
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

    using uml4net.Utils;

    /// <summary>
    /// An ActivityPartition is a kind of ActivityGroup for identifying ActivityNodes that have some
    /// characteristic in common.
    /// </summary>
    [Class(xmiId: "ActivityPartition", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IActivityPartition : IActivityGroup
    {
        /// <summary>
        /// ActivityEdges immediately contained in the ActivityPartition.
        /// </summary>
        [Property(xmiId: "ActivityPartition-edge", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "ActivityGroup-containedEdge")]
        public List<IActivityEdge> Edge { get; set; }

        /// <summary>
        /// Indicates whether the ActivityPartition groups other ActivityPartitions along a dimension.
        /// </summary>
        [Property(xmiId: "ActivityPartition-isDimension", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "false")]
        public bool IsDimension { get; set; }

        /// <summary>
        /// Indicates whether the ActivityPartition represents an entity to which the partitioning structure
        /// does not apply.
        /// </summary>
        [Property(xmiId: "ActivityPartition-isExternal", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "false")]
        public bool IsExternal { get; set; }

        /// <summary>
        /// ActivityNodes immediately contained in the ActivityPartition.
        /// </summary>
        [Property(xmiId: "ActivityPartition-node", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "ActivityGroup-containedNode")]
        public List<IActivityNode> Node { get; set; }

        /// <summary>
        /// An Element represented by the functionality modeled within the ActivityPartition.
        /// </summary>
        [Property(xmiId: "ActivityPartition-represents", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public IElement Represents { get; set; }

        /// <summary>
        /// Other ActivityPartitions immediately contained in this ActivityPartition (as its subgroups).
        /// </summary>
        [Property(xmiId: "ActivityPartition-subpartition", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "ActivityGroup-subgroup")]
        public IContainerList<IActivityPartition> Subpartition { get; set; }

        /// <summary>
        /// Other ActivityPartitions immediately containing this ActivityPartition (as its superGroups).
        /// </summary>
        [Property(xmiId: "ActivityPartition-superPartition", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "ActivityGroup-superGroup")]
        public IActivityPartition SuperPartition { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
