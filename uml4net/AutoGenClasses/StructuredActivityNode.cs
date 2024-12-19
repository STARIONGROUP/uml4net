// -------------------------------------------------------------------------------------------------
// <copyright file="StructuredActivityNode.cs" company="Starion Group S.A.">
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

namespace uml4net.Actions
{
    using System;
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
    /// A StructuredActivityNode is an Action that is also an ActivityGroup and whose behavior is specified
    /// by the ActivityNodes and ActivityEdges it so contains. Unlike other kinds of ActivityGroup, a
    /// StructuredActivityNode owns the ActivityNodes and ActivityEdges it contains, and so a node or edge
    /// can only be directly contained in one StructuredActivityNode, though StructuredActivityNodes may be
    /// nested.
    /// </summary>
    [Class(xmiId: "StructuredActivityNode", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    public partial class StructuredActivityNode : XmiElement, IStructuredActivityNode
    {
        /// <summary>
        /// Gets or sets the container of this <see cref="IElement"/>
        /// </summary>
        public IElement Possessor { get; set; }

        /// <summary>
        /// The Activity immediately containing the StructuredActivityNode, if it is not contained in another
        /// StructuredActivityNode.
        /// </summary>
        [Property(xmiId: "StructuredActivityNode-activity", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [RedefinedProperty(propertyName: "ActivityGroup-inActivity")]
        [RedefinedProperty(propertyName: "ActivityNode-activity")]
        [Implements(implementation: "IStructuredActivityNode.Activity")]
        public IActivity Activity { get; set; }

        /// <summary>
        /// The Activity containing the ActivityNode, if it is directly owned by an Activity.
        /// </summary>
        [Property(xmiId: "ActivityNode-activity", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-owner")]
        [RedefinedByProperty("IStructuredActivityNode.Activity")]
        [Implements(implementation: "IActivityNode.Activity")]
        IActivity IActivityNode.Activity
        {
            get => throw new InvalidOperationException("Redefined by property IStructuredActivityNode.Activity");
            set => throw new InvalidOperationException("Redefined by property IStructuredActivityNode.Activity");
        }

        /// <summary>
        /// Indicates the Dependencies that reference this NamedElement as a client.
        /// </summary>
        [Property(xmiId: "NamedElement-clientDependency", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_source_directedRelationship-directedRelationship")]
        [Implements(implementation: "INamedElement.ClientDependency")]
        public List<IDependency> ClientDependency => this.QueryClientDependency();

        /// <summary>
        /// ActivityEdges immediately contained in the ActivityGroup.
        /// </summary>
        [Property(xmiId: "ActivityGroup-containedEdge", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IActivityGroup.ContainedEdge")]
        public List<IActivityEdge> ContainedEdge => this.QueryContainedEdge();

        /// <summary>
        /// ActivityNodes immediately contained in the ActivityGroup.
        /// </summary>
        [Property(xmiId: "ActivityGroup-containedNode", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IActivityGroup.ContainedNode")]
        public List<IActivityNode> ContainedNode => this.QueryContainedNode();

        /// <summary>
        /// The context Classifier of the Behavior that contains this Action, or the Behavior itself if it has
        /// no context.
        /// </summary>
        [Property(xmiId: "Action-context", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IAction.Context")]
        public IClassifier Context => this.QueryContext();

        /// <summary>
        /// The ActivityEdges immediately contained in the StructuredActivityNode.
        /// </summary>
        [Property(xmiId: "StructuredActivityNode-edge", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "ActivityGroup-containedEdge")]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "IStructuredActivityNode.Edge")]
        public IContainerList<IActivityEdge> Edge
        {
            get => this.edge ??= new ContainerList<IActivityEdge>(this);
            set => this.edge = value;
        }

        /// <summary>
        /// Backing field for <see cref="Edge"/>
        /// </summary>
        private IContainerList<IActivityEdge> edge;

        /// <summary>
        /// References the ElementImports owned by the Namespace.
        /// </summary>
        [Property(xmiId: "Namespace-elementImport", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_source_directedRelationship-directedRelationship")]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "INamespace.ElementImport")]
        public IContainerList<IElementImport> ElementImport
        {
            get => this.elementImport ??= new ContainerList<IElementImport>(this);
            set => this.elementImport = value;
        }

        /// <summary>
        /// Backing field for <see cref="ElementImport"/>
        /// </summary>
        private IContainerList<IElementImport> elementImport;

        /// <summary>
        /// A set of ExceptionHandlers that are examined if an exception propagates out of the ExceptionNode.
        /// </summary>
        [Property(xmiId: "ExecutableNode-handler", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "IExecutableNode.Handler")]
        public IContainerList<IExceptionHandler> Handler
        {
            get => this.handler ??= new ContainerList<IExceptionHandler>(this);
            set => this.handler = value;
        }

        /// <summary>
        /// Backing field for <see cref="Handler"/>
        /// </summary>
        private IContainerList<IExceptionHandler> handler;

        /// <summary>
        /// References the PackageableElements that are members of this Namespace as a result of either
        /// PackageImports or ElementImports.
        /// </summary>
        [Property(xmiId: "Namespace-importedMember", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-member")]
        [Implements(implementation: "INamespace.ImportedMember")]
        public List<IPackageableElement> ImportedMember => this.QueryImportedMember();

        /// <summary>
        /// The Activity containing the ActivityGroup, if it is directly owned by an Activity.
        /// </summary>
        [Property(xmiId: "ActivityGroup-inActivity", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-owner")]
        [RedefinedByProperty("IStructuredActivityNode.Activity")]
        [Implements(implementation: "IActivityGroup.InActivity")]
        IActivity IActivityGroup.InActivity
        {
            get => throw new InvalidOperationException("Redefined by property IStructuredActivityNode.Activity");
            set => throw new InvalidOperationException("Redefined by property IStructuredActivityNode.Activity");
        }

        /// <summary>
        /// ActivityEdges that have the ActivityNode as their target.
        /// </summary>
        [Property(xmiId: "ActivityNode-incoming", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IActivityNode.Incoming")]
        public List<IActivityEdge> Incoming { get; set; } = new();

        /// <summary>
        /// ActivityGroups containing the ActivityNode.
        /// </summary>
        [Property(xmiId: "ActivityNode-inGroup", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IActivityNode.InGroup")]
        public List<IActivityGroup> InGroup => this.QueryInGroup();

        /// <summary>
        /// InterruptibleActivityRegions containing the ActivityNode.
        /// </summary>
        [Property(xmiId: "ActivityNode-inInterruptibleRegion", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "ActivityNode-inGroup")]
        [Implements(implementation: "IActivityNode.InInterruptibleRegion")]
        public List<IInterruptibleActivityRegion> InInterruptibleRegion { get; set; } = new();

        /// <summary>
        /// ActivityPartitions containing the ActivityNode.
        /// </summary>
        [Property(xmiId: "ActivityNode-inPartition", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "ActivityNode-inGroup")]
        [Implements(implementation: "IActivityNode.InPartition")]
        public List<IActivityPartition> InPartition { get; set; } = new();

        /// <summary>
        /// The ordered set of InputPins representing the inputs to the Action.
        /// </summary>
        [Property(xmiId: "Action-input", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "IAction.Input")]
        public IContainerList<IInputPin> Input => this.QueryInput();

        /// <summary>
        /// The StructuredActivityNode containing the ActvityNode, if it is directly owned by a
        /// StructuredActivityNode.
        /// </summary>
        [Property(xmiId: "ActivityNode-inStructuredNode", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "ActivityNode-inGroup")]
        [SubsettedProperty(propertyName: "Element-owner")]
        [Implements(implementation: "IActivityNode.InStructuredNode")]
        public IStructuredActivityNode InStructuredNode { get; set; }

        /// <summary>
        /// Indicates whether it is possible to further redefine a RedefinableElement. If the value is true,
        /// then it is not possible to further redefine the RedefinableElement.
        /// </summary>
        [Property(xmiId: "RedefinableElement-isLeaf", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "false")]
        [Implements(implementation: "IRedefinableElement.IsLeaf")]
        public bool IsLeaf { get; set; }

        /// <summary>
        /// If true, the Action can begin a new, concurrent execution, even if there is already another
        /// execution of the Action ongoing. If false, the Action cannot begin a new execution until any
        /// previous execution has completed.
        /// </summary>
        [Property(xmiId: "Action-isLocallyReentrant", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "false")]
        [Implements(implementation: "IAction.IsLocallyReentrant")]
        public bool IsLocallyReentrant { get; set; }

        /// <summary>
        /// A Constraint that must be satisfied when execution of the Action is completed.
        /// </summary>
        [Property(xmiId: "Action-localPostcondition", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "IAction.LocalPostcondition")]
        public IContainerList<IConstraint> LocalPostcondition
        {
            get => this.localPostcondition ??= new ContainerList<IConstraint>(this);
            set => this.localPostcondition = value;
        }

        /// <summary>
        /// Backing field for <see cref="LocalPostcondition"/>
        /// </summary>
        private IContainerList<IConstraint> localPostcondition;

        /// <summary>
        /// A Constraint that must be satisfied when execution of the Action is started.
        /// </summary>
        [Property(xmiId: "Action-localPrecondition", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "IAction.LocalPrecondition")]
        public IContainerList<IConstraint> LocalPrecondition
        {
            get => this.localPrecondition ??= new ContainerList<IConstraint>(this);
            set => this.localPrecondition = value;
        }

        /// <summary>
        /// Backing field for <see cref="LocalPrecondition"/>
        /// </summary>
        private IContainerList<IConstraint> localPrecondition;

        /// <summary>
        /// A collection of NamedElements identifiable within the Namespace, either by being owned or by being
        /// introduced by importing or inheritance.
        /// </summary>
        [Property(xmiId: "Namespace-member", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        [Implements(implementation: "INamespace.Member")]
        public List<INamedElement> Member => this.QueryMember();

        /// <summary>
        /// If true, then any object used by an Action within the StructuredActivityNode cannot be accessed by
        /// any Action outside the node until the StructuredActivityNode as a whole completes. Any concurrent
        /// Actions that would result in accessing such objects are required to have their execution deferred
        /// until the completion of the StructuredActivityNode.
        /// </summary>
        [Property(xmiId: "StructuredActivityNode-mustIsolate", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "false")]
        [Implements(implementation: "IStructuredActivityNode.MustIsolate")]
        public bool MustIsolate { get; set; }

        /// <summary>
        /// The name of the NamedElement.
        /// </summary>
        [Property(xmiId: "NamedElement-name", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "INamedElement.Name")]
        public string Name { get; set; }

        /// <summary>
        /// The StringExpression used to define the name of this NamedElement.
        /// </summary>
        [Property(xmiId: "NamedElement-nameExpression", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "INamedElement.NameExpression")]
        public IContainerList<IStringExpression> NameExpression
        {
            get => this.nameExpression ??= new ContainerList<IStringExpression>(this);
            set => this.nameExpression = value;
        }

        /// <summary>
        /// Backing field for <see cref="NameExpression"/>
        /// </summary>
        private IContainerList<IStringExpression> nameExpression;

        /// <summary>
        /// Specifies the Namespace that owns the NamedElement.
        /// </summary>
        [Property(xmiId: "NamedElement-namespace", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_member_memberNamespace-memberNamespace")]
        [SubsettedProperty(propertyName: "Element-owner")]
        [Implements(implementation: "INamedElement.Namespace")]
        public INamespace Namespace => this.QueryNamespace();

        /// <summary>
        /// The ActivityNodes immediately contained in the StructuredActivityNode.
        /// </summary>
        [Property(xmiId: "StructuredActivityNode-node", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "ActivityGroup-containedNode")]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "IStructuredActivityNode.Node")]
        public IContainerList<IActivityNode> Node
        {
            get => this.node ??= new ContainerList<IActivityNode>(this);
            set => this.node = value;
        }

        /// <summary>
        /// Backing field for <see cref="Node"/>
        /// </summary>
        private IContainerList<IActivityNode> node;

        /// <summary>
        /// ActivityEdges that have the ActivityNode as their source.
        /// </summary>
        [Property(xmiId: "ActivityNode-outgoing", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IActivityNode.Outgoing")]
        public List<IActivityEdge> Outgoing { get; set; } = new();

        /// <summary>
        /// The ordered set of OutputPins representing outputs from the Action.
        /// </summary>
        [Property(xmiId: "Action-output", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "IAction.Output")]
        public IContainerList<IOutputPin> Output => this.QueryOutput();

        /// <summary>
        /// The Comments owned by this Element.
        /// </summary>
        [Property(xmiId: "Element-ownedComment", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "IElement.OwnedComment")]
        public IContainerList<IComment> OwnedComment
        {
            get => this.ownedComment ??= new ContainerList<IComment>(this);
            set => this.ownedComment = value;
        }

        /// <summary>
        /// Backing field for <see cref="OwnedComment"/>
        /// </summary>
        private IContainerList<IComment> ownedComment;

        /// <summary>
        /// The Elements owned by this Element.
        /// </summary>
        [Property(xmiId: "Element-ownedElement", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IElement.OwnedElement")]
        public IContainerList<IElement> OwnedElement => this.QueryOwnedElement();

        /// <summary>
        /// A collection of NamedElements owned by the Namespace.
        /// </summary>
        [Property(xmiId: "Namespace-ownedMember", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [SubsettedProperty(propertyName: "Namespace-member")]
        [Implements(implementation: "INamespace.OwnedMember")]
        public IContainerList<INamedElement> OwnedMember => this.QueryOwnedMember();

        /// <summary>
        /// Specifies a set of Constraints owned by this Namespace.
        /// </summary>
        [Property(xmiId: "Namespace-ownedRule", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        [Implements(implementation: "INamespace.OwnedRule")]
        public IContainerList<IConstraint> OwnedRule
        {
            get => this.ownedRule ??= new ContainerList<IConstraint>(this);
            set => this.ownedRule = value;
        }

        /// <summary>
        /// Backing field for <see cref="OwnedRule"/>
        /// </summary>
        private IContainerList<IConstraint> ownedRule;

        /// <summary>
        /// The Element that owns this Element.
        /// </summary>
        [Property(xmiId: "Element-owner", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IElement.Owner")]
        public IElement Owner => this.QueryOwner();

        /// <summary>
        /// References the PackageImports owned by the Namespace.
        /// </summary>
        [Property(xmiId: "Namespace-packageImport", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_source_directedRelationship-directedRelationship")]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "INamespace.PackageImport")]
        public IContainerList<IPackageImport> PackageImport
        {
            get => this.packageImport ??= new ContainerList<IPackageImport>(this);
            set => this.packageImport = value;
        }

        /// <summary>
        /// Backing field for <see cref="PackageImport"/>
        /// </summary>
        private IContainerList<IPackageImport> packageImport;

        /// <summary>
        /// A name that allows the NamedElement to be identified within a hierarchy of nested Namespaces. It is
        /// constructed from the names of the containing Namespaces starting at the root of the hierarchy and
        /// ending with the name of the NamedElement itself.
        /// </summary>
        [Property(xmiId: "NamedElement-qualifiedName", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "INamedElement.QualifiedName")]
        public string QualifiedName => this.QueryQualifiedName();

        /// <summary>
        /// The RedefinableElement that is being redefined by this element.
        /// </summary>
        [Property(xmiId: "RedefinableElement-redefinedElement", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IRedefinableElement.RedefinedElement")]
        public List<IRedefinableElement> RedefinedElement => this.QueryRedefinedElement();

        /// <summary>
        /// ActivityNodes from a generalization of the Activity containining this ActivityNode that are
        /// redefined by this ActivityNode.
        /// </summary>
        [Property(xmiId: "ActivityNode-redefinedNode", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "RedefinableElement-redefinedElement")]
        [Implements(implementation: "IActivityNode.RedefinedNode")]
        public List<IActivityNode> RedefinedNode { get; set; } = new();

        /// <summary>
        /// The contexts that this element may be redefined from.
        /// </summary>
        [Property(xmiId: "RedefinableElement-redefinitionContext", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IRedefinableElement.RedefinitionContext")]
        public List<IClassifier> RedefinitionContext => this.QueryRedefinitionContext();

        /// <summary>
        /// The InputPins owned by the StructuredActivityNode.
        /// </summary>
        [Property(xmiId: "StructuredActivityNode-structuredNodeInput", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Action-input")]
        [Implements(implementation: "IStructuredActivityNode.StructuredNodeInput")]
        public IContainerList<IInputPin> StructuredNodeInput
        {
            get => this.structuredNodeInput ??= new ContainerList<IInputPin>(this);
            set => this.structuredNodeInput = value;
        }

        /// <summary>
        /// Backing field for <see cref="StructuredNodeInput"/>
        /// </summary>
        private IContainerList<IInputPin> structuredNodeInput;

        /// <summary>
        /// The OutputPins owned by the StructuredActivityNode.
        /// </summary>
        [Property(xmiId: "StructuredActivityNode-structuredNodeOutput", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Action-output")]
        [Implements(implementation: "IStructuredActivityNode.StructuredNodeOutput")]
        public IContainerList<IOutputPin> StructuredNodeOutput
        {
            get => this.structuredNodeOutput ??= new ContainerList<IOutputPin>(this);
            set => this.structuredNodeOutput = value;
        }

        /// <summary>
        /// Backing field for <see cref="StructuredNodeOutput"/>
        /// </summary>
        private IContainerList<IOutputPin> structuredNodeOutput;

        /// <summary>
        /// Other ActivityGroups immediately contained in this ActivityGroup.
        /// </summary>
        [Property(xmiId: "ActivityGroup-subgroup", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "IActivityGroup.Subgroup")]
        public IContainerList<IActivityGroup> Subgroup => this.QuerySubgroup();

        /// <summary>
        /// The ActivityGroup immediately containing this ActivityGroup, if it is directly owned by another
        /// ActivityGroup.
        /// </summary>
        [Property(xmiId: "ActivityGroup-superGroup", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-owner")]
        [Implements(implementation: "IActivityGroup.SuperGroup")]
        public IActivityGroup SuperGroup => this.QuerySuperGroup();

        /// <summary>
        /// The Variables defined in the scope of the StructuredActivityNode.
        /// </summary>
        [Property(xmiId: "StructuredActivityNode-variable", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        [Implements(implementation: "IStructuredActivityNode.Variable")]
        public IContainerList<IVariable> Variable
        {
            get => this.variable ??= new ContainerList<IVariable>(this);
            set => this.variable = value;
        }

        /// <summary>
        /// Backing field for <see cref="Variable"/>
        /// </summary>
        private IContainerList<IVariable> variable;

        /// <summary>
        /// Determines whether and how the NamedElement is visible outside its owning Namespace.
        /// </summary>
        [Property(xmiId: "NamedElement-visibility", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "INamedElement.Visibility")]
        public VisibilityKind Visibility { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
