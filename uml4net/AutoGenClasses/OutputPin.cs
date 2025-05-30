﻿// -------------------------------------------------------------------------------------------------
// <copyright file="OutputPin.cs" company="Starion Group S.A.">
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
    /// An OutputPin is a Pin that holds output values produced by an Action.
    /// </summary>
    [Class(xmiId: "OutputPin", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial class OutputPin : XmiElement, IOutputPin
    {
        /// <summary>
        /// Gets or sets the container of this <see cref="IElement"/>
        /// </summary>
        public IElement Possessor { get; set; }

        /// <summary>
        /// The Activity containing the ActivityNode, if it is directly owned by an Activity.
        /// </summary>
        [Property(xmiId: "ActivityNode-activity", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-owner")]
        [Implements(implementation: "IActivityNode.Activity")]
        public IActivity Activity { get; set; }

        /// <summary>
        /// Indicates the Dependencies that reference this NamedElement as a client.
        /// </summary>
        [Property(xmiId: "NamedElement-clientDependency", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: true, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_source_directedRelationship-directedRelationship")]
        [Implements(implementation: "INamedElement.ClientDependency")]
        public List<IDependency> ClientDependency => this.QueryClientDependency();

        /// <summary>
        /// ActivityEdges that have the ActivityNode as their target.
        /// </summary>
        [Property(xmiId: "ActivityNode-incoming", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IActivityNode.Incoming")]
        public List<IActivityEdge> Incoming { get; set; } = new();

        /// <summary>
        /// ActivityGroups containing the ActivityNode.
        /// </summary>
        [Property(xmiId: "ActivityNode-inGroup", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IActivityNode.InGroup")]
        public List<IActivityGroup> InGroup => this.QueryInGroup();

        /// <summary>
        /// InterruptibleActivityRegions containing the ActivityNode.
        /// </summary>
        [Property(xmiId: "ActivityNode-inInterruptibleRegion", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "ActivityNode-inGroup")]
        [Implements(implementation: "IActivityNode.InInterruptibleRegion")]
        public List<IInterruptibleActivityRegion> InInterruptibleRegion { get; set; } = new();

        /// <summary>
        /// ActivityPartitions containing the ActivityNode.
        /// </summary>
        [Property(xmiId: "ActivityNode-inPartition", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "ActivityNode-inGroup")]
        [Implements(implementation: "IActivityNode.InPartition")]
        public List<IActivityPartition> InPartition { get; set; } = new();

        /// <summary>
        /// The States required to be associated with the values held by tokens on this ObjectNode.
        /// </summary>
        [Property(xmiId: "ObjectNode-inState", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IObjectNode.InState")]
        public List<IState> InState { get; set; } = new();

        /// <summary>
        /// The StructuredActivityNode containing the ActvityNode, if it is directly owned by a
        /// StructuredActivityNode.
        /// </summary>
        [Property(xmiId: "ActivityNode-inStructuredNode", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "ActivityNode-inGroup")]
        [SubsettedProperty(propertyName: "Element-owner")]
        [Implements(implementation: "IActivityNode.InStructuredNode")]
        public IStructuredActivityNode InStructuredNode { get; set; }

        /// <summary>
        /// Indicates whether the Pin provides data to the Action or just controls how the Action executes.
        /// </summary>
        [Property(xmiId: "Pin-isControl", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: "false")]
        [Implements(implementation: "IPin.IsControl")]
        public bool IsControl { get; set; }

        /// <summary>
        /// Indicates whether the type of the ObjectNode is to be treated as representing control values that
        /// may traverse ControlFlows.
        /// </summary>
        [Property(xmiId: "ObjectNode-isControlType", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: "false")]
        [Implements(implementation: "IObjectNode.IsControlType")]
        public bool IsControlType { get; set; }

        /// <summary>
        /// Indicates whether it is possible to further redefine a RedefinableElement. If the value is true,
        /// then it is not possible to further redefine the RedefinableElement.
        /// </summary>
        [Property(xmiId: "RedefinableElement-isLeaf", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: "false")]
        [Implements(implementation: "IRedefinableElement.IsLeaf")]
        public bool IsLeaf { get; set; }

        /// <summary>
        /// For a multivalued multiplicity, this attribute specifies whether the values in an instantiation of
        /// this MultiplicityElement are sequentially ordered.
        /// </summary>
        [Property(xmiId: "MultiplicityElement-isOrdered", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: "false")]
        [Implements(implementation: "IMultiplicityElement.IsOrdered")]
        public bool IsOrdered { get; set; }

        /// <summary>
        /// For a multivalued multiplicity, this attributes specifies whether the values in an instantiation of
        /// this MultiplicityElement are unique.
        /// </summary>
        [Property(xmiId: "MultiplicityElement-isUnique", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: "true")]
        [Implements(implementation: "IMultiplicityElement.IsUnique")]
        public bool IsUnique { get; set; } = true;

        /// <summary>
        /// The lower bound of the multiplicity interval.
        /// </summary>
        [Property(xmiId: "MultiplicityElement-lower", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: true, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IMultiplicityElement.Lower")]
        public int Lower => this.QueryLower();

        /// <summary>
        /// The specification of the lower bound for this multiplicity.
        /// </summary>
        [Property(xmiId: "MultiplicityElement-lowerValue", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "IMultiplicityElement.LowerValue")]
        public IContainerList<IValueSpecification> LowerValue
        {
            get => this.lowerValue ??= new ContainerList<IValueSpecification>(this);
            set => this.lowerValue = value;
        }

        /// <summary>
        /// Backing field for <see cref="LowerValue"/>
        /// </summary>
        private IContainerList<IValueSpecification> lowerValue;

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
        /// Indicates how the tokens held by the ObjectNode are ordered for selection to traverse ActivityEdges
        /// outgoing from the ObjectNode.
        /// </summary>
        [Property(xmiId: "ObjectNode-ordering", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: "FIFO")]
        [Implements(implementation: "IObjectNode.Ordering")]
        public ObjectNodeOrderingKind Ordering { get; set; }

        /// <summary>
        /// ActivityEdges that have the ActivityNode as their source.
        /// </summary>
        [Property(xmiId: "ActivityNode-outgoing", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IActivityNode.Outgoing")]
        public List<IActivityEdge> Outgoing { get; set; } = new();

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
        /// The Elements owned by this Element.
        /// </summary>
        [Property(xmiId: "Element-ownedElement", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.OwnedElement")]
        public IContainerList<IElement> OwnedElement => this.QueryOwnedElement();

        /// <summary>
        /// The Element that owns this Element.
        /// </summary>
        [Property(xmiId: "Element-owner", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.Owner")]
        public IElement Owner => this.QueryOwner();

        /// <summary>
        /// A name that allows the NamedElement to be identified within a hierarchy of nested Namespaces. It is
        /// constructed from the names of the containing Namespaces starting at the root of the hierarchy and
        /// ending with the name of the NamedElement itself.
        /// </summary>
        [Property(xmiId: "NamedElement-qualifiedName", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "INamedElement.QualifiedName")]
        public string QualifiedName => this.QueryQualifiedName();

        /// <summary>
        /// The RedefinableElement that is being redefined by this element.
        /// </summary>
        [Property(xmiId: "RedefinableElement-redefinedElement", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IRedefinableElement.RedefinedElement")]
        public List<IRedefinableElement> RedefinedElement => this.QueryRedefinedElement();

        /// <summary>
        /// ActivityNodes from a generalization of the Activity containining this ActivityNode that are
        /// redefined by this ActivityNode.
        /// </summary>
        [Property(xmiId: "ActivityNode-redefinedNode", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "RedefinableElement-redefinedElement")]
        [Implements(implementation: "IActivityNode.RedefinedNode")]
        public List<IActivityNode> RedefinedNode { get; set; } = new();

        /// <summary>
        /// The contexts that this element may be redefined from.
        /// </summary>
        [Property(xmiId: "RedefinableElement-redefinitionContext", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IRedefinableElement.RedefinitionContext")]
        public List<IClassifier> RedefinitionContext => this.QueryRedefinitionContext();

        /// <summary>
        /// A Behavior used to select tokens to be offered on outgoing ActivityEdges.
        /// </summary>
        [Property(xmiId: "ObjectNode-selection", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IObjectNode.Selection")]
        public IBehavior Selection { get; set; }

        /// <summary>
        /// The type of the TypedElement.
        /// </summary>
        [Property(xmiId: "TypedElement-type", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "ITypedElement.Type")]
        public IType Type { get; set; }

        /// <summary>
        /// The upper bound of the multiplicity interval.
        /// </summary>
        [Property(xmiId: "MultiplicityElement-upper", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: true, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IMultiplicityElement.Upper")]
        public string Upper => this.QueryUpper();

        /// <summary>
        /// The maximum number of tokens that may be held by this ObjectNode. Tokens cannot flow into the
        /// ObjectNode if the upperBound is reached. If no upperBound is specified, then there is no limit on
        /// how many tokens the ObjectNode can hold.
        /// </summary>
        [Property(xmiId: "ObjectNode-upperBound", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "IObjectNode.UpperBound")]
        public IContainerList<IValueSpecification> UpperBound
        {
            get => this.upperBound ??= new ContainerList<IValueSpecification>(this);
            set => this.upperBound = value;
        }

        /// <summary>
        /// Backing field for <see cref="UpperBound"/>
        /// </summary>
        private IContainerList<IValueSpecification> upperBound;

        /// <summary>
        /// The specification of the upper bound for this multiplicity.
        /// </summary>
        [Property(xmiId: "MultiplicityElement-upperValue", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "IMultiplicityElement.UpperValue")]
        public IContainerList<IValueSpecification> UpperValue
        {
            get => this.upperValue ??= new ContainerList<IValueSpecification>(this);
            set => this.upperValue = value;
        }

        /// <summary>
        /// Backing field for <see cref="UpperValue"/>
        /// </summary>
        private IContainerList<IValueSpecification> upperValue;

        /// <summary>
        /// Determines whether and how the NamedElement is visible outside its owning Namespace.
        /// </summary>
        [Property(xmiId: "NamedElement-visibility", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "INamedElement.Visibility")]
        public VisibilityKind Visibility { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
