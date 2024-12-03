﻿// -------------------------------------------------------------------------------------------------
// <copyright file="CallOperationAction.cs" company="Starion Group S.A.">
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
    /// A CallOperationAction is a CallAction that transmits an Operation call request to the target object,
    /// where it may cause the invocation of associated Behavior. The argument values of the
    /// CallOperationAction are passed on the input Parameters of the Operation. If call is synchronous, the
    /// execution of the CallOperationAction waits until the execution of the invoked Operation completes
    /// and the values of output Parameters of the Operation are placed on the result OutputPins. If the
    /// call is asynchronous, the CallOperationAction completes immediately and no results values can be
    /// provided.
    /// </summary>
    [Class(xmiId: "CallOperationAction", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    public partial class CallOperationAction : XmiElement, ICallOperationAction
    {
        /// <summary>
        /// Gets or sets the container of this <see cref="IElement"/>
        /// </summary>
        public IElement Possessor { get; set; }

        /// <summary>
        /// The Activity containing the ActivityNode, if it is directly owned by an Activity.
        /// </summary>
        [Property(xmiId: "ActivityNode-activity", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-owner")]
        [Implements(implementation: "IActivityNode.Activity")]
        public IActivity Activity { get; set; }

        /// <summary>
        /// The InputPins that provide the argument values passed in the invocation request.
        /// </summary>
        [Property(xmiId: "InvocationAction-argument", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Action-input")]
        [Implements(implementation: "IInvocationAction.Argument")]
        public IContainerList<IInputPin> Argument
        {
            get => this.argument ??= new ContainerList<IInputPin>(this);
            set => this.argument = value;
        }

        /// <summary>
        /// Backing field for <see cref="Argument"/>
        /// </summary>
        private IContainerList<IInputPin> argument;

        /// <summary>
        /// Indicates the Dependencies that reference this NamedElement as a client.
        /// </summary>
        [Property(xmiId: "NamedElement-clientDependency", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_source_directedRelationship-directedRelationship")]
        [Implements(implementation: "INamedElement.ClientDependency")]
        public List<IDependency> ClientDependency => this.QueryClientDependency();

        /// <summary>
        /// The context Classifier of the Behavior that contains this Action, or the Behavior itself if it has
        /// no context.
        /// </summary>
        [Property(xmiId: "Action-context", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IAction.Context")]
        public IClassifier Context => this.QueryContext();

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
        /// If true, the call is synchronous and the caller waits for completion of the invoked Behavior. If
        /// false, the call is asynchronous and the caller proceeds immediately and cannot receive return
        /// values.
        /// </summary>
        [Property(xmiId: "CallAction-isSynchronous", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "true")]
        [Implements(implementation: "ICallAction.IsSynchronous")]
        public bool IsSynchronous { get; set; }

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
        /// For CallOperationActions, SendSignalActions, and SendObjectActions, an optional Port of the target
        /// object through which the invocation request is sent.
        /// </summary>
        [Property(xmiId: "InvocationAction-onPort", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IInvocationAction.OnPort")]
        public IPort OnPort { get; set; }

        /// <summary>
        /// The Operation being invoked.
        /// </summary>
        [Property(xmiId: "CallOperationAction-operation", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "ICallOperationAction.Operation")]
        public IOperation Operation { get; set; }

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
        /// The Element that owns this Element.
        /// </summary>
        [Property(xmiId: "Element-owner", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IElement.Owner")]
        public IElement Owner => this.QueryOwner();

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
        /// The OutputPins on which the reply values from the invocation are placed (if the call is
        /// synchronous).
        /// </summary>
        [Property(xmiId: "CallAction-result", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Action-output")]
        [Implements(implementation: "ICallAction.Result")]
        public IContainerList<IOutputPin> Result
        {
            get => this.result ??= new ContainerList<IOutputPin>(this);
            set => this.result = value;
        }

        /// <summary>
        /// Backing field for <see cref="Result"/>
        /// </summary>
        private IContainerList<IOutputPin> result;

        /// <summary>
        /// The InputPin that provides the target object to which the Operation call request is sent.
        /// </summary>
        [Property(xmiId: "CallOperationAction-target", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Action-input")]
        [Implements(implementation: "ICallOperationAction.Target")]
        public IContainerList<IInputPin> Target
        {
            get => this.target ??= new ContainerList<IInputPin>(this);
            set => this.target = value;
        }

        /// <summary>
        /// Backing field for <see cref="Target"/>
        /// </summary>
        private IContainerList<IInputPin> target;

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
