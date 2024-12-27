// -------------------------------------------------------------------------------------------------
// <copyright file="IActivityNode.cs" company="Starion Group S.A.">
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

    /// <summary>
    /// ActivityNode is an abstract class for points in the flow of an Activity connected by ActivityEdges.
    /// </summary>
    [Class(xmiId: "ActivityNode", isAbstract: true, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IActivityNode : IRedefinableElement
    {
        /// <summary>
        /// The Activity containing the ActivityNode, if it is directly owned by an Activity.
        /// </summary>
        [Property(xmiId: "ActivityNode-activity", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-owner")]
        public IActivity Activity { get; set; }

        /// <summary>
        /// ActivityGroups containing the ActivityNode.
        /// </summary>
        [Property(xmiId: "ActivityNode-inGroup", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        public List<IActivityGroup> InGroup { get; }

        /// <summary>
        /// InterruptibleActivityRegions containing the ActivityNode.
        /// </summary>
        [Property(xmiId: "ActivityNode-inInterruptibleRegion", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "ActivityNode-inGroup")]
        public List<IInterruptibleActivityRegion> InInterruptibleRegion { get; set; }

        /// <summary>
        /// ActivityPartitions containing the ActivityNode.
        /// </summary>
        [Property(xmiId: "ActivityNode-inPartition", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "ActivityNode-inGroup")]
        public List<IActivityPartition> InPartition { get; set; }

        /// <summary>
        /// The StructuredActivityNode containing the ActvityNode, if it is directly owned by a
        /// StructuredActivityNode.
        /// </summary>
        [Property(xmiId: "ActivityNode-inStructuredNode", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "ActivityNode-inGroup")]
        [SubsettedProperty(propertyName: "Element-owner")]
        public IStructuredActivityNode InStructuredNode { get; set; }

        /// <summary>
        /// ActivityEdges that have the ActivityNode as their target.
        /// </summary>
        [Property(xmiId: "ActivityNode-incoming", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public List<IActivityEdge> Incoming { get; set; }

        /// <summary>
        /// ActivityEdges that have the ActivityNode as their source.
        /// </summary>
        [Property(xmiId: "ActivityNode-outgoing", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public List<IActivityEdge> Outgoing { get; set; }

        /// <summary>
        /// ActivityNodes from a generalization of the Activity containining this ActivityNode that are
        /// redefined by this ActivityNode.
        /// </summary>
        [Property(xmiId: "ActivityNode-redefinedNode", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "RedefinableElement-redefinedElement")]
        public List<IActivityNode> RedefinedNode { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
