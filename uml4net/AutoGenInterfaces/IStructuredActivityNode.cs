// -------------------------------------------------------------------------------------------------
// <copyright file="IStructuredActivityNode.cs" company="Starion Group S.A.">
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
    /// A StructuredActivityNode is an Action that is also an ActivityGroup and whose behavior is specified
    /// by the ActivityNodes and ActivityEdges it so contains. Unlike other kinds of ActivityGroup, a
    /// StructuredActivityNode owns the ActivityNodes and ActivityEdges it contains, and so a node or edge
    /// can only be directly contained in one StructuredActivityNode, though StructuredActivityNodes may be
    /// nested.
    /// </summary>
    [Class(xmiId: "StructuredActivityNode", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IStructuredActivityNode : INamespace, IActivityGroup, IAction
    {
        /// <summary>
        /// The Activity immediately containing the StructuredActivityNode, if it is not contained in another
        /// StructuredActivityNode.
        /// </summary>
        [Property(xmiId: "StructuredActivityNode-activity", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [RedefinedProperty(propertyName: "ActivityGroup-inActivity")]
        [RedefinedProperty(propertyName: "ActivityNode-activity")]
        public new IActivity Activity { get; set; }

        /// <summary>
        /// The ActivityEdges immediately contained in the StructuredActivityNode.
        /// </summary>
        [Property(xmiId: "StructuredActivityNode-edge", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "ActivityGroup-containedEdge")]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IActivityEdge> Edge { get; set; }

        /// <summary>
        /// If true, then any object used by an Action within the StructuredActivityNode cannot be accessed by
        /// any Action outside the node until the StructuredActivityNode as a whole completes. Any concurrent
        /// Actions that would result in accessing such objects are required to have their execution deferred
        /// until the completion of the StructuredActivityNode.
        /// </summary>
        [Property(xmiId: "StructuredActivityNode-mustIsolate", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "false")]
        public bool MustIsolate { get; set; }

        /// <summary>
        /// The ActivityNodes immediately contained in the StructuredActivityNode.
        /// </summary>
        [Property(xmiId: "StructuredActivityNode-node", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "ActivityGroup-containedNode")]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IActivityNode> Node { get; set; }

        /// <summary>
        /// The InputPins owned by the StructuredActivityNode.
        /// </summary>
        [Property(xmiId: "StructuredActivityNode-structuredNodeInput", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Action-input")]
        public IContainerList<IInputPin> StructuredNodeInput { get; set; }

        /// <summary>
        /// The OutputPins owned by the StructuredActivityNode.
        /// </summary>
        [Property(xmiId: "StructuredActivityNode-structuredNodeOutput", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Action-output")]
        public IContainerList<IOutputPin> StructuredNodeOutput { get; set; }

        /// <summary>
        /// The Variables defined in the scope of the StructuredActivityNode.
        /// </summary>
        [Property(xmiId: "StructuredActivityNode-variable", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        public IContainerList<IVariable> Variable { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
