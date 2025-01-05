// -------------------------------------------------------------------------------------------------
// <copyright file="IActivityEdge.cs" company="Starion Group S.A.">
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
    /// An ActivityEdge is an abstract class for directed connections between two ActivityNodes.
    /// </summary>
    [Class(xmiId: "ActivityEdge", isAbstract: true, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IActivityEdge : IRedefinableElement
    {
        /// <summary>
        /// The Activity containing the ActivityEdge, if it is directly owned by an Activity.
        /// </summary>
        [Property(xmiId: "ActivityEdge-activity", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-owner")]
        public IActivity Activity { get; set; }

        /// <summary>
        /// A ValueSpecification that is evaluated to determine if a token can traverse the ActivityEdge. If an
        /// ActivityEdge has no guard, then there is no restriction on tokens traversing the edge.
        /// </summary>
        [Property(xmiId: "ActivityEdge-guard", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IValueSpecification> Guard { get; set; }

        /// <summary>
        /// ActivityGroups containing the ActivityEdge.
        /// </summary>
        [Property(xmiId: "ActivityEdge-inGroup", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        public List<IActivityGroup> InGroup { get; }

        /// <summary>
        /// ActivityPartitions containing the ActivityEdge.
        /// </summary>
        [Property(xmiId: "ActivityEdge-inPartition", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "ActivityEdge-inGroup")]
        public List<IActivityPartition> InPartition { get; set; }

        /// <summary>
        /// The StructuredActivityNode containing the ActivityEdge, if it is owned by a StructuredActivityNode.
        /// </summary>
        [Property(xmiId: "ActivityEdge-inStructuredNode", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "ActivityEdge-inGroup")]
        [SubsettedProperty(propertyName: "Element-owner")]
        public IStructuredActivityNode InStructuredNode { get; set; }

        /// <summary>
        /// The InterruptibleActivityRegion for which this ActivityEdge is an interruptingEdge.
        /// </summary>
        [Property(xmiId: "ActivityEdge-interrupts", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public IInterruptibleActivityRegion Interrupts { get; set; }

        /// <summary>
        /// ActivityEdges from a generalization of the Activity containing this ActivityEdge that are redefined
        /// by this ActivityEdge.
        /// </summary>
        [Property(xmiId: "ActivityEdge-redefinedEdge", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "RedefinableElement-redefinedElement")]
        public List<IActivityEdge> RedefinedEdge { get; set; }

        /// <summary>
        /// The ActivityNode from which tokens are taken when they traverse the ActivityEdge.
        /// </summary>
        [Property(xmiId: "ActivityEdge-source", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public IActivityNode Source { get; set; }

        /// <summary>
        /// The ActivityNode to which tokens are put when they traverse the ActivityEdge.
        /// </summary>
        [Property(xmiId: "ActivityEdge-target", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public IActivityNode Target { get; set; }

        /// <summary>
        /// The minimum number of tokens that must traverse the ActivityEdge at the same time. If no weight is
        /// specified, this is equivalent to specifying a constant value of 1.
        /// </summary>
        [Property(xmiId: "ActivityEdge-weight", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IValueSpecification> Weight { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
