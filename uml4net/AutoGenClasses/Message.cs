// -------------------------------------------------------------------------------------------------
// <copyright file="Message.cs" company="Starion Group S.A.">
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

namespace uml4net.Interactions
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

    using uml4net.Utils;

    /// <summary>
    /// A Message defines a particular communication between Lifelines of an Interaction.
    /// </summary>
    [Class(xmiId: "Message", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial class Message : XmiElement, IMessage
    {
        /// <summary>
        /// Gets or sets the container of this <see cref="IElement"/>
        /// </summary>
        public IElement Possessor { get; set; }

        /// <summary>
        /// The arguments of the Message.
        /// </summary>
        [Property(xmiId: "Message-argument", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "IMessage.Argument")]
        public IContainerList<IValueSpecification> Argument
        {
            get => this.argument ??= new ContainerList<IValueSpecification>(this);
            set => this.argument = value;
        }

        /// <summary>
        /// Backing field for <see cref="Argument"/>
        /// </summary>
        private IContainerList<IValueSpecification> argument;

        /// <summary>
        /// Indicates the Dependencies that reference this NamedElement as a client.
        /// </summary>
        [Property(xmiId: "NamedElement-clientDependency", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_source_directedRelationship-directedRelationship")]
        [Implements(implementation: "INamedElement.ClientDependency")]
        public List<IDependency> ClientDependency => this.QueryClientDependency();

        /// <summary>
        /// The Connector on which this Message is sent.
        /// </summary>
        [Property(xmiId: "Message-connector", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IMessage.Connector")]
        public IConnector Connector { get; set; }

        /// <summary>
        /// The enclosing Interaction owning the Message.
        /// </summary>
        [Property(xmiId: "Message-interaction", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "NamedElement-namespace")]
        [Implements(implementation: "IMessage.Interaction")]
        public IInteraction Interaction { get; set; }

        /// <summary>
        /// The derived kind of the Message (complete, lost, found, or unknown).
        /// </summary>
        [Property(xmiId: "Message-messageKind", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IMessage.MessageKind")]
        public MessageKind MessageKind => this.QueryMessageKind();

        /// <summary>
        /// The sort of communication reflected by the Message.
        /// </summary>
        [Property(xmiId: "Message-messageSort", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "synchCall")]
        [Implements(implementation: "IMessage.MessageSort")]
        public MessageSort MessageSort { get; set; }

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
        /// References the Receiving of the Message.
        /// </summary>
        [Property(xmiId: "Message-receiveEvent", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_message_messageEnd-messageEnd")]
        [Implements(implementation: "IMessage.ReceiveEvent")]
        public IMessageEnd ReceiveEvent { get; set; }

        /// <summary>
        /// References the Sending of the Message.
        /// </summary>
        [Property(xmiId: "Message-sendEvent", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_message_messageEnd-messageEnd")]
        [Implements(implementation: "IMessage.SendEvent")]
        public IMessageEnd SendEvent { get; set; }

        /// <summary>
        /// The signature of the Message is the specification of its content. It refers either an Operation or a
        /// Signal.
        /// </summary>
        [Property(xmiId: "Message-signature", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IMessage.Signature")]
        public INamedElement Signature { get; set; }

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
