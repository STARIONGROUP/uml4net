﻿// -------------------------------------------------------------------------------------------------
// <copyright file="Activity.cs" company="Starion Group S.A.">
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
    using System;
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
    public partial class Activity : XmiElement, IActivity
    {
        /// <summary>
        /// Gets or sets the container of this <see cref="IElement"/>
        /// </summary>
        public IElement Possessor { get; set; }

        /// <summary>
        /// All of the Properties that are direct (i.e., not inherited or imported) attributes of the
        /// Classifier.
        /// </summary>
        [Property(xmiId: "Classifier-attribute", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_redefinitionContext_redefinableElement-redefinableElement")]
        [SubsettedProperty(propertyName: "Classifier-feature")]
        [Implements(implementation: "IClassifier.Attribute")]
        public List<IProperty> Attribute => this.QueryAttribute();

        /// <summary>
        /// A Behavior that specifies the behavior of the BehavioredClassifier itself.
        /// </summary>
        [Property(xmiId: "BehavioredClassifier-classifierBehavior", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "BehavioredClassifier-ownedBehavior")]
        [Implements(implementation: "IBehavioredClassifier.ClassifierBehavior")]
        public IBehavior ClassifierBehavior { get; set; }

        /// <summary>
        /// Indicates the Dependencies that reference this NamedElement as a client.
        /// </summary>
        [Property(xmiId: "NamedElement-clientDependency", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: true, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_source_directedRelationship-directedRelationship")]
        [Implements(implementation: "INamedElement.ClientDependency")]
        public List<IDependency> ClientDependency => this.QueryClientDependency();

        /// <summary>
        /// The CollaborationUses owned by the Classifier.
        /// </summary>
        [Property(xmiId: "Classifier-collaborationUse", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "IClassifier.CollaborationUse")]
        public IContainerList<ICollaborationUse> CollaborationUse
        {
            get => this.collaborationUse ??= new ContainerList<ICollaborationUse>(this);
            set => this.collaborationUse = value;
        }

        /// <summary>
        /// Backing field for <see cref="CollaborationUse"/>
        /// </summary>
        private IContainerList<ICollaborationUse> collaborationUse;

        /// <summary>
        /// The BehavioredClassifier that is the context for the execution of the Behavior. A Behavior that is
        /// directly owned as a nestedClassifier does not have a context. Otherwise, to determine the context of
        /// a Behavior, find the first BehavioredClassifier reached by following the chain of owner
        /// relationships from the Behavior, if any. If there is such a BehavioredClassifier, then it is the
        /// context, unless it is itself a Behavior with a non-empty context, in which case that is also the
        /// context for the original Behavior. For example, following this algorithm, the context of an entry
        /// Behavior in a StateMachine is the BehavioredClassifier that owns the StateMachine. The features of
        /// the context BehavioredClassifier as well as the Elements visible to the context Classifier are
        /// visible to the Behavior.
        /// </summary>
        [Property(xmiId: "Behavior-context", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "RedefinableElement-redefinitionContext")]
        [Implements(implementation: "IBehavior.Context")]
        public IBehavioredClassifier Context => this.QueryContext();

        /// <summary>
        /// ActivityEdges expressing flow between the nodes of the Activity.
        /// </summary>
        [Property(xmiId: "Activity-edge", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "IActivity.Edge")]
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
        [Property(xmiId: "Namespace-elementImport", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
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
        /// This property is used when the Class is acting as a metaclass. It references the Extensions that
        /// specify additional properties of the metaclass. The property is derived from the Extensions whose
        /// memberEnds are typed by the Class.
        /// </summary>
        [Property(xmiId: "Class-extension", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IClass.Extension")]
        public List<IExtension> Extension => this.QueryExtension();

        /// <summary>
        /// Specifies each Feature directly defined in the classifier. Note that there may be members of the
        /// Classifier that are of the type Feature but are not included, e.g., inherited features.
        /// </summary>
        [Property(xmiId: "Classifier-feature", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-member")]
        [Implements(implementation: "IClassifier.Feature")]
        public List<IFeature> Feature => this.QueryFeature();

        /// <summary>
        /// The generalizing Classifiers for this Classifier.
        /// </summary>
        [Property(xmiId: "Classifier-general", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: true, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [RedefinedByProperty("IClass.SuperClass")]
        [Implements(implementation: "IClassifier.General")]
        List<IClassifier> IClassifier.General => throw new InvalidOperationException("Redefined by property IClass.SuperClass");

        /// <summary>
        /// The Generalization relationships for this Classifier. These Generalizations navigate to more general
        /// Classifiers in the generalization hierarchy.
        /// </summary>
        [Property(xmiId: "Classifier-generalization", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_source_directedRelationship-directedRelationship")]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "IClassifier.Generalization")]
        public IContainerList<IGeneralization> Generalization
        {
            get => this.generalization ??= new ContainerList<IGeneralization>(this);
            set => this.generalization = value;
        }

        /// <summary>
        /// Backing field for <see cref="Generalization"/>
        /// </summary>
        private IContainerList<IGeneralization> generalization;

        /// <summary>
        /// Top-level ActivityGroups in the Activity.
        /// </summary>
        [Property(xmiId: "Activity-group", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "IActivity.Group")]
        public IContainerList<IActivityGroup> Group
        {
            get => this.group ??= new ContainerList<IActivityGroup>(this);
            set => this.group = value;
        }

        /// <summary>
        /// Backing field for <see cref="Group"/>
        /// </summary>
        private IContainerList<IActivityGroup> group;

        /// <summary>
        /// References the PackageableElements that are members of this Namespace as a result of either
        /// PackageImports or ElementImports.
        /// </summary>
        [Property(xmiId: "Namespace-importedMember", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-member")]
        [Implements(implementation: "INamespace.ImportedMember")]
        public List<IPackageableElement> ImportedMember => this.QueryImportedMember();

        /// <summary>
        /// All elements inherited by this Classifier from its general Classifiers.
        /// </summary>
        [Property(xmiId: "Classifier-inheritedMember", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-member")]
        [Implements(implementation: "IClassifier.InheritedMember")]
        public List<INamedElement> InheritedMember => this.QueryInheritedMember();

        /// <summary>
        /// The set of InterfaceRealizations owned by the BehavioredClassifier. Interface realizations reference
        /// the Interfaces of which the BehavioredClassifier is an implementation.
        /// </summary>
        [Property(xmiId: "BehavioredClassifier-interfaceRealization", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [SubsettedProperty(propertyName: "NamedElement-clientDependency")]
        [Implements(implementation: "IBehavioredClassifier.InterfaceRealization")]
        public IContainerList<IInterfaceRealization> InterfaceRealization
        {
            get => this.interfaceRealization ??= new ContainerList<IInterfaceRealization>(this);
            set => this.interfaceRealization = value;
        }

        /// <summary>
        /// Backing field for <see cref="InterfaceRealization"/>
        /// </summary>
        private IContainerList<IInterfaceRealization> interfaceRealization;

        /// <summary>
        /// If true, the Class does not provide a complete declaration and cannot be instantiated. An abstract
        /// Class is typically used as a target of Associations or Generalizations.
        /// </summary>
        [Property(xmiId: "Class-isAbstract", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: "false")]
        [RedefinedProperty(propertyName: "Classifier-isAbstract")]
        [Implements(implementation: "IClass.IsAbstract")]
        public bool IsAbstract { get; set; }

        /// <summary>
        /// If true, the Classifier can only be instantiated by instantiating one of its specializations. An
        /// abstract Classifier is intended to be used by other Classifiers e.g., as the target of Associations
        /// or Generalizations.
        /// </summary>
        [Property(xmiId: "Classifier-isAbstract", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: "false")]
        [RedefinedByProperty("IClass.IsAbstract")]
        [Implements(implementation: "IClassifier.IsAbstract")]
        bool IClassifier.IsAbstract
        {
            get => throw new InvalidOperationException("Redefined by property IClass.IsAbstract");
            set => throw new InvalidOperationException("Redefined by property IClass.IsAbstract");
        }

        /// <summary>
        /// Determines whether an object specified by this Class is active or not. If true, then the owning
        /// Class is referred to as an active Class. If false, then such a Class is referred to as a passive
        /// Class.
        /// </summary>
        [Property(xmiId: "Class-isActive", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: "false")]
        [Implements(implementation: "IClass.IsActive")]
        public bool IsActive { get; set; }

        /// <summary>
        /// If true, the Classifier cannot be specialized.
        /// </summary>
        [Property(xmiId: "Classifier-isFinalSpecialization", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: "false")]
        [Implements(implementation: "IClassifier.IsFinalSpecialization")]
        public bool IsFinalSpecialization { get; set; }

        /// <summary>
        /// Indicates whether it is possible to further redefine a RedefinableElement. If the value is true,
        /// then it is not possible to further redefine the RedefinableElement.
        /// </summary>
        [Property(xmiId: "RedefinableElement-isLeaf", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: "false")]
        [Implements(implementation: "IRedefinableElement.IsLeaf")]
        public bool IsLeaf { get; set; }

        /// <summary>
        /// If true, this Activity must not make any changes to objects. The default is false (an Activity may
        /// make nonlocal changes). (This is an assertion, not an executable property. It may be used by an
        /// execution engine to optimize model execution. If the assertion is violated by the Activity, then the
        /// model is ill-formed.)
        /// </summary>
        [Property(xmiId: "Activity-isReadOnly", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: "false")]
        [Implements(implementation: "IActivity.IsReadOnly")]
        public bool IsReadOnly { get; set; }

        /// <summary>
        /// Tells whether the Behavior can be invoked while it is still executing from a previous invocation.
        /// </summary>
        [Property(xmiId: "Behavior-isReentrant", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: "true")]
        [Implements(implementation: "IBehavior.IsReentrant")]
        public bool IsReentrant { get; set; } = true;

        /// <summary>
        /// If true, all invocations of the Activity are handled by the same execution.
        /// </summary>
        [Property(xmiId: "Activity-isSingleExecution", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: "false")]
        [Implements(implementation: "IActivity.IsSingleExecution")]
        public bool IsSingleExecution { get; set; }

        /// <summary>
        /// A collection of NamedElements identifiable within the Namespace, either by being owned or by being
        /// introduced by importing or inheritance.
        /// </summary>
        [Property(xmiId: "Namespace-member", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: true, defaultValue: null)]
        [Implements(implementation: "INamespace.Member")]
        public List<INamedElement> Member => this.QueryMember();

        /// <summary>
        /// The name of the NamedElement.
        /// </summary>
        [Property(xmiId: "NamedElement-name", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "INamedElement.Name")]
        public string Name { get; set; }

        /// <summary>
        /// The StringExpression used to define the name of this NamedElement.
        /// </summary>
        [Property(xmiId: "NamedElement-nameExpression", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
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
        [Property(xmiId: "NamedElement-namespace", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_member_memberNamespace-memberNamespace")]
        [SubsettedProperty(propertyName: "Element-owner")]
        [Implements(implementation: "INamedElement.Namespace")]
        public INamespace Namespace => this.QueryNamespace();

        /// <summary>
        /// The Classifiers owned by the Class that are not ownedBehaviors.
        /// </summary>
        [Property(xmiId: "Class-nestedClassifier", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_redefinitionContext_redefinableElement-redefinableElement")]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        [Implements(implementation: "IClass.NestedClassifier")]
        public IContainerList<IClassifier> NestedClassifier
        {
            get => this.nestedClassifier ??= new ContainerList<IClassifier>(this);
            set => this.nestedClassifier = value;
        }

        /// <summary>
        /// Backing field for <see cref="NestedClassifier"/>
        /// </summary>
        private IContainerList<IClassifier> nestedClassifier;

        /// <summary>
        /// ActivityNodes coordinated by the Activity.
        /// </summary>
        [Property(xmiId: "Activity-node", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "IActivity.Node")]
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
        /// The attributes (i.e., the Properties) owned by the Class.
        /// </summary>
        [Property(xmiId: "Class-ownedAttribute", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Classifier-attribute")]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        [RedefinedProperty(propertyName: "StructuredClassifier-ownedAttribute")]
        [Implements(implementation: "IClass.OwnedAttribute")]
        public IContainerList<IProperty> OwnedAttribute
        {
            get => this.ownedAttribute ??= new ContainerList<IProperty>(this);
            set => this.ownedAttribute = value;
        }

        /// <summary>
        /// Backing field for <see cref="OwnedAttribute"/>
        /// </summary>
        private IContainerList<IProperty> ownedAttribute;

        /// <summary>
        /// The Properties owned by the StructuredClassifier.
        /// </summary>
        [Property(xmiId: "StructuredClassifier-ownedAttribute", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Classifier-attribute")]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        [SubsettedProperty(propertyName: "StructuredClassifier-role")]
        [RedefinedByProperty("IClass.OwnedAttribute")]
        [Implements(implementation: "IStructuredClassifier.OwnedAttribute")]
        IContainerList<IProperty> IStructuredClassifier.OwnedAttribute
        {
            get => throw new InvalidOperationException("Redefined by property IClass.OwnedAttribute");
            set => throw new InvalidOperationException("Redefined by property IClass.OwnedAttribute");
        }

        /// <summary>
        /// Behaviors owned by a BehavioredClassifier.
        /// </summary>
        [Property(xmiId: "BehavioredClassifier-ownedBehavior", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        [Implements(implementation: "IBehavioredClassifier.OwnedBehavior")]
        public IContainerList<IBehavior> OwnedBehavior
        {
            get => this.ownedBehavior ??= new ContainerList<IBehavior>(this);
            set => this.ownedBehavior = value;
        }

        /// <summary>
        /// Backing field for <see cref="OwnedBehavior"/>
        /// </summary>
        private IContainerList<IBehavior> ownedBehavior;

        /// <summary>
        /// The Comments owned by this Element.
        /// </summary>
        [Property(xmiId: "Element-ownedComment", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
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
        /// The connectors owned by the StructuredClassifier.
        /// </summary>
        [Property(xmiId: "StructuredClassifier-ownedConnector", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_redefinitionContext_redefinableElement-redefinableElement")]
        [SubsettedProperty(propertyName: "Classifier-feature")]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        [Implements(implementation: "IStructuredClassifier.OwnedConnector")]
        public IContainerList<IConnector> OwnedConnector
        {
            get => this.ownedConnector ??= new ContainerList<IConnector>(this);
            set => this.ownedConnector = value;
        }

        /// <summary>
        /// Backing field for <see cref="OwnedConnector"/>
        /// </summary>
        private IContainerList<IConnector> ownedConnector;

        /// <summary>
        /// The Elements owned by this Element.
        /// </summary>
        [Property(xmiId: "Element-ownedElement", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.OwnedElement")]
        public IContainerList<IElement> OwnedElement => this.QueryOwnedElement();

        /// <summary>
        /// A collection of NamedElements owned by the Namespace.
        /// </summary>
        [Property(xmiId: "Namespace-ownedMember", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [SubsettedProperty(propertyName: "Namespace-member")]
        [Implements(implementation: "INamespace.OwnedMember")]
        public IContainerList<INamedElement> OwnedMember => this.QueryOwnedMember();

        /// <summary>
        /// The Operations owned by the Class.
        /// </summary>
        [Property(xmiId: "Class-ownedOperation", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_redefinitionContext_redefinableElement-redefinableElement")]
        [SubsettedProperty(propertyName: "Classifier-feature")]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        [Implements(implementation: "IClass.OwnedOperation")]
        public IContainerList<IOperation> OwnedOperation
        {
            get => this.ownedOperation ??= new ContainerList<IOperation>(this);
            set => this.ownedOperation = value;
        }

        /// <summary>
        /// Backing field for <see cref="OwnedOperation"/>
        /// </summary>
        private IContainerList<IOperation> ownedOperation;

        /// <summary>
        /// References a list of Parameters to the Behavior which describes the order and type of arguments that
        /// can be given when the Behavior is invoked and of the values which will be returned when the Behavior
        /// completes its execution.
        /// </summary>
        [Property(xmiId: "Behavior-ownedParameter", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        [Implements(implementation: "IBehavior.OwnedParameter")]
        public IContainerList<IParameter> OwnedParameter
        {
            get => this.ownedParameter ??= new ContainerList<IParameter>(this);
            set => this.ownedParameter = value;
        }

        /// <summary>
        /// Backing field for <see cref="OwnedParameter"/>
        /// </summary>
        private IContainerList<IParameter> ownedParameter;

        /// <summary>
        /// The ParameterSets owned by this Behavior.
        /// </summary>
        [Property(xmiId: "Behavior-ownedParameterSet", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        [Implements(implementation: "IBehavior.OwnedParameterSet")]
        public IContainerList<IParameterSet> OwnedParameterSet
        {
            get => this.ownedParameterSet ??= new ContainerList<IParameterSet>(this);
            set => this.ownedParameterSet = value;
        }

        /// <summary>
        /// Backing field for <see cref="OwnedParameterSet"/>
        /// </summary>
        private IContainerList<IParameterSet> ownedParameterSet;

        /// <summary>
        /// The Ports owned by the EncapsulatedClassifier.
        /// </summary>
        [Property(xmiId: "EncapsulatedClassifier-ownedPort", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "StructuredClassifier-ownedAttribute")]
        [Implements(implementation: "IEncapsulatedClassifier.OwnedPort")]
        public IContainerList<IPort> OwnedPort => this.QueryOwnedPort();

        /// <summary>
        /// The Receptions owned by the Class.
        /// </summary>
        [Property(xmiId: "Class-ownedReception", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Classifier-feature")]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        [Implements(implementation: "IClass.OwnedReception")]
        public IContainerList<IReception> OwnedReception
        {
            get => this.ownedReception ??= new ContainerList<IReception>(this);
            set => this.ownedReception = value;
        }

        /// <summary>
        /// Backing field for <see cref="OwnedReception"/>
        /// </summary>
        private IContainerList<IReception> ownedReception;

        /// <summary>
        /// Specifies a set of Constraints owned by this Namespace.
        /// </summary>
        [Property(xmiId: "Namespace-ownedRule", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
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
        /// The optional RedefinableTemplateSignature specifying the formal template parameters.
        /// </summary>
        [Property(xmiId: "Classifier-ownedTemplateSignature", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_redefinitionContext_redefinableElement-redefinableElement")]
        [RedefinedProperty(propertyName: "TemplateableElement-ownedTemplateSignature")]
        [Implements(implementation: "IClassifier.OwnedTemplateSignature")]
        public IContainerList<IRedefinableTemplateSignature> OwnedTemplateSignature
        {
            get => this.ownedTemplateSignature ??= new ContainerList<IRedefinableTemplateSignature>(this);
            set => this.ownedTemplateSignature = value;
        }

        /// <summary>
        /// Backing field for <see cref="OwnedTemplateSignature"/>
        /// </summary>
        private IContainerList<IRedefinableTemplateSignature> ownedTemplateSignature;

        /// <summary>
        /// The optional TemplateSignature specifying the formal TemplateParameters for this
        /// TemplateableElement. If a TemplateableElement has a TemplateSignature, then it is a template.
        /// </summary>
        [Property(xmiId: "TemplateableElement-ownedTemplateSignature", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [RedefinedByProperty("IClassifier.OwnedTemplateSignature")]
        [Implements(implementation: "ITemplateableElement.OwnedTemplateSignature")]
        IContainerList<ITemplateSignature> ITemplateableElement.OwnedTemplateSignature
        {
            get => throw new InvalidOperationException("Redefined by property IClassifier.OwnedTemplateSignature");
            set => throw new InvalidOperationException("Redefined by property IClassifier.OwnedTemplateSignature");
        }

        /// <summary>
        /// The UseCases owned by this classifier.
        /// </summary>
        [Property(xmiId: "Classifier-ownedUseCase", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        [Implements(implementation: "IClassifier.OwnedUseCase")]
        public IContainerList<IUseCase> OwnedUseCase
        {
            get => this.ownedUseCase ??= new ContainerList<IUseCase>(this);
            set => this.ownedUseCase = value;
        }

        /// <summary>
        /// Backing field for <see cref="OwnedUseCase"/>
        /// </summary>
        private IContainerList<IUseCase> ownedUseCase;

        /// <summary>
        /// The Element that owns this Element.
        /// </summary>
        [Property(xmiId: "Element-owner", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.Owner")]
        public IElement Owner => this.QueryOwner();

        /// <summary>
        /// The formal TemplateParameter that owns this ParameterableElement.
        /// </summary>
        [Property(xmiId: "ParameterableElement-owningTemplateParameter", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-owner")]
        [SubsettedProperty(propertyName: "ParameterableElement-templateParameter")]
        [Implements(implementation: "IParameterableElement.OwningTemplateParameter")]
        public ITemplateParameter OwningTemplateParameter { get; set; }

        /// <summary>
        /// Specifies the owning Package of this Type, if any.
        /// </summary>
        [Property(xmiId: "Type-package", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_packagedElement_owningPackage-owningPackage")]
        [Implements(implementation: "IType.Package")]
        public IPackage Package { get; set; }

        /// <summary>
        /// References the PackageImports owned by the Namespace.
        /// </summary>
        [Property(xmiId: "Namespace-packageImport", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
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
        /// The Properties specifying instances that the StructuredClassifier owns by composition. This
        /// collection is derived, selecting those owned Properties where isComposite is true.
        /// </summary>
        [Property(xmiId: "StructuredClassifier-part", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IStructuredClassifier.Part")]
        public List<IProperty> Part => this.QueryPart();

        /// <summary>
        /// Top-level ActivityPartitions in the Activity.
        /// </summary>
        [Property(xmiId: "Activity-partition", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Activity-group")]
        [Implements(implementation: "IActivity.Partition")]
        public List<IActivityPartition> Partition { get; set; } = new();

        /// <summary>
        /// An optional set of Constraints specifying what is fulfilled after the execution of the Behavior is
        /// completed, if its precondition was fulfilled before its invocation.
        /// </summary>
        [Property(xmiId: "Behavior-postcondition", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-ownedRule")]
        [Implements(implementation: "IBehavior.Postcondition")]
        public IContainerList<IConstraint> Postcondition
        {
            get => this.postcondition ??= new ContainerList<IConstraint>(this);
            set => this.postcondition = value;
        }

        /// <summary>
        /// Backing field for <see cref="Postcondition"/>
        /// </summary>
        private IContainerList<IConstraint> postcondition;

        /// <summary>
        /// The GeneralizationSet of which this Classifier is a power type.
        /// </summary>
        [Property(xmiId: "Classifier-powertypeExtent", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IClassifier.PowertypeExtent")]
        public List<IGeneralizationSet> PowertypeExtent { get; set; } = new();

        /// <summary>
        /// An optional set of Constraints specifying what must be fulfilled before the Behavior is invoked.
        /// </summary>
        [Property(xmiId: "Behavior-precondition", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-ownedRule")]
        [Implements(implementation: "IBehavior.Precondition")]
        public IContainerList<IConstraint> Precondition
        {
            get => this.precondition ??= new ContainerList<IConstraint>(this);
            set => this.precondition = value;
        }

        /// <summary>
        /// Backing field for <see cref="Precondition"/>
        /// </summary>
        private IContainerList<IConstraint> precondition;

        /// <summary>
        /// A name that allows the NamedElement to be identified within a hierarchy of nested Namespaces. It is
        /// constructed from the names of the containing Namespaces starting at the root of the hierarchy and
        /// ending with the name of the NamedElement itself.
        /// </summary>
        [Property(xmiId: "NamedElement-qualifiedName", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "INamedElement.QualifiedName")]
        public string QualifiedName => this.QueryQualifiedName();

        /// <summary>
        /// References the Behavior that this Behavior redefines. A subtype of Behavior may redefine any other
        /// subtype of Behavior. If the Behavior implements a BehavioralFeature, it replaces the redefined
        /// Behavior. If the Behavior is a classifierBehavior, it extends the redefined Behavior.
        /// </summary>
        [Property(xmiId: "Behavior-redefinedBehavior", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Classifier-redefinedClassifier")]
        [Implements(implementation: "IBehavior.RedefinedBehavior")]
        public List<IBehavior> RedefinedBehavior { get; set; } = new();

        /// <summary>
        /// The Classifiers redefined by this Classifier.
        /// </summary>
        [Property(xmiId: "Classifier-redefinedClassifier", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "RedefinableElement-redefinedElement")]
        [Implements(implementation: "IClassifier.RedefinedClassifier")]
        public List<IClassifier> RedefinedClassifier { get; set; } = new();

        /// <summary>
        /// The RedefinableElement that is being redefined by this element.
        /// </summary>
        [Property(xmiId: "RedefinableElement-redefinedElement", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IRedefinableElement.RedefinedElement")]
        public List<IRedefinableElement> RedefinedElement => this.QueryRedefinedElement();

        /// <summary>
        /// The contexts that this element may be redefined from.
        /// </summary>
        [Property(xmiId: "RedefinableElement-redefinitionContext", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IRedefinableElement.RedefinitionContext")]
        public List<IClassifier> RedefinitionContext => this.QueryRedefinitionContext();

        /// <summary>
        /// A CollaborationUse which indicates the Collaboration that represents this Classifier.
        /// </summary>
        [Property(xmiId: "Classifier-representation", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Classifier-collaborationUse")]
        [Implements(implementation: "IClassifier.Representation")]
        public ICollaborationUse Representation { get; set; }

        /// <summary>
        /// The roles that instances may play in this StructuredClassifier.
        /// </summary>
        [Property(xmiId: "StructuredClassifier-role", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-member")]
        [Implements(implementation: "IStructuredClassifier.Role")]
        public List<IConnectableElement> Role => this.QueryRole();

        /// <summary>
        /// Designates a BehavioralFeature that the Behavior implements. The BehavioralFeature must be owned by
        /// the BehavioredClassifier that owns the Behavior or be inherited by it. The Parameters of the
        /// BehavioralFeature and the implementing Behavior must match. A Behavior does not need to have a
        /// specification, in which case it either is the classifierBehavior of a BehavioredClassifier or it can
        /// only be invoked by another Behavior of the Classifier.
        /// </summary>
        [Property(xmiId: "Behavior-specification", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IBehavior.Specification")]
        public IBehavioralFeature Specification { get; set; }

        /// <summary>
        /// Top-level StructuredActivityNodes in the Activity.
        /// </summary>
        [Property(xmiId: "Activity-structuredNode", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Activity-group")]
        [SubsettedProperty(propertyName: "Activity-node")]
        [Implements(implementation: "IActivity.StructuredNode")]
        public IContainerList<IStructuredActivityNode> StructuredNode
        {
            get => this.structuredNode ??= new ContainerList<IStructuredActivityNode>(this);
            set => this.structuredNode = value;
        }

        /// <summary>
        /// Backing field for <see cref="StructuredNode"/>
        /// </summary>
        private IContainerList<IStructuredActivityNode> structuredNode;

        /// <summary>
        /// The Substitutions owned by this Classifier.
        /// </summary>
        [Property(xmiId: "Classifier-substitution", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [SubsettedProperty(propertyName: "NamedElement-clientDependency")]
        [Implements(implementation: "IClassifier.Substitution")]
        public IContainerList<ISubstitution> Substitution
        {
            get => this.substitution ??= new ContainerList<ISubstitution>(this);
            set => this.substitution = value;
        }

        /// <summary>
        /// Backing field for <see cref="Substitution"/>
        /// </summary>
        private IContainerList<ISubstitution> substitution;

        /// <summary>
        /// The superclasses of a Class, derived from its Generalizations.
        /// </summary>
        [Property(xmiId: "Class-superClass", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: true, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [RedefinedProperty(propertyName: "Classifier-general")]
        [Implements(implementation: "IClass.SuperClass")]
        public List<IClass> SuperClass => this.QuerySuperClass();

        /// <summary>
        /// The optional TemplateBindings from this TemplateableElement to one or more templates.
        /// </summary>
        [Property(xmiId: "TemplateableElement-templateBinding", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_source_directedRelationship-directedRelationship")]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "ITemplateableElement.TemplateBinding")]
        public IContainerList<ITemplateBinding> TemplateBinding
        {
            get => this.templateBinding ??= new ContainerList<ITemplateBinding>(this);
            set => this.templateBinding = value;
        }

        /// <summary>
        /// Backing field for <see cref="TemplateBinding"/>
        /// </summary>
        private IContainerList<ITemplateBinding> templateBinding;

        /// <summary>
        /// TheClassifierTemplateParameter that exposes this element as a formal parameter.
        /// </summary>
        [Property(xmiId: "Classifier-templateParameter", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [RedefinedProperty(propertyName: "ParameterableElement-templateParameter")]
        [Implements(implementation: "IClassifier.TemplateParameter")]
        public IClassifierTemplateParameter TemplateParameter { get; set; }

        /// <summary>
        /// The TemplateParameter that exposes this ParameterableElement as a formal parameter.
        /// </summary>
        [Property(xmiId: "ParameterableElement-templateParameter", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [RedefinedByProperty("IClassifier.TemplateParameter")]
        [Implements(implementation: "IParameterableElement.TemplateParameter")]
        ITemplateParameter IParameterableElement.TemplateParameter
        {
            get => throw new InvalidOperationException("Redefined by property IClassifier.TemplateParameter");
            set => throw new InvalidOperationException("Redefined by property IClassifier.TemplateParameter");
        }

        /// <summary>
        /// The set of UseCases for which this Classifier is the subject.
        /// </summary>
        [Property(xmiId: "Classifier-useCase", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IClassifier.UseCases")]
        public List<IUseCase> UseCases { get; set; } = new();

        /// <summary>
        /// Top-level Variables defined by the Activity.
        /// </summary>
        [Property(xmiId: "Activity-variable", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        [Implements(implementation: "IActivity.Variable")]
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
        [Property(xmiId: "NamedElement-visibility", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [RedefinedByProperty("IPackageableElement.Visibility")]
        [Implements(implementation: "INamedElement.Visibility")]
        VisibilityKind INamedElement.Visibility
        {
            get => throw new InvalidOperationException("Redefined by property IPackageableElement.Visibility");
            set => throw new InvalidOperationException("Redefined by property IPackageableElement.Visibility");
        }

        /// <summary>
        /// A PackageableElement must have a visibility specified if it is owned by a Namespace. The default
        /// visibility is public.
        /// </summary>
        [Property(xmiId: "PackageableElement-visibility", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: "public")]
        [RedefinedProperty(propertyName: "NamedElement-visibility")]
        [Implements(implementation: "IPackageableElement.Visibility")]
        public VisibilityKind Visibility { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
