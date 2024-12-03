// -------------------------------------------------------------------------------------------------
// <copyright file="OperationTemplateParameter.cs" company="Starion Group S.A.">
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

namespace uml4net.Classification
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
    /// An OperationTemplateParameter exposes an Operation as a formal parameter for a template.
    /// </summary>
    [Class(xmiId: "OperationTemplateParameter", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    public partial class OperationTemplateParameter : XmiElement, IOperationTemplateParameter
    {
        /// <summary>
        /// Gets or sets the container of this <see cref="IElement"/>
        /// </summary>
        public IElement Possessor { get; set; }

        /// <summary>
        /// The ParameterableElement that is the default for this formal TemplateParameter.
        /// </summary>
        [Property(xmiId: "TemplateParameter-default", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "ITemplateParameter.Default")]
        public IParameterableElement Default { get; set; }

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
        /// The ParameterableElement that is owned by this TemplateParameter for the purpose of providing a
        /// default.
        /// </summary>
        [Property(xmiId: "TemplateParameter-ownedDefault", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [SubsettedProperty(propertyName: "TemplateParameter-default")]
        [Implements(implementation: "ITemplateParameter.OwnedDefault")]
        public IContainerList<IParameterableElement> OwnedDefault
        {
            get => this.ownedDefault ??= new ContainerList<IParameterableElement>(this);
            set => this.ownedDefault = value;
        }

        /// <summary>
        /// Backing field for <see cref="OwnedDefault"/>
        /// </summary>
        private IContainerList<IParameterableElement> ownedDefault;

        /// <summary>
        /// The Elements owned by this Element.
        /// </summary>
        [Property(xmiId: "Element-ownedElement", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IElement.OwnedElement")]
        public IContainerList<IElement> OwnedElement => this.QueryOwnedElement();

        /// <summary>
        /// The ParameterableElement that is owned by this TemplateParameter for the purpose of exposing it as
        /// the parameteredElement.
        /// </summary>
        [Property(xmiId: "TemplateParameter-ownedParameteredElement", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [SubsettedProperty(propertyName: "TemplateParameter-parameteredElement")]
        [Implements(implementation: "ITemplateParameter.OwnedParameteredElement")]
        public IContainerList<IParameterableElement> OwnedParameteredElement
        {
            get => this.ownedParameteredElement ??= new ContainerList<IParameterableElement>(this);
            set => this.ownedParameteredElement = value;
        }

        /// <summary>
        /// Backing field for <see cref="OwnedParameteredElement"/>
        /// </summary>
        private IContainerList<IParameterableElement> ownedParameteredElement;

        /// <summary>
        /// The Element that owns this Element.
        /// </summary>
        [Property(xmiId: "Element-owner", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IElement.Owner")]
        public IElement Owner => this.QueryOwner();

        /// <summary>
        /// The Operation exposed by this OperationTemplateParameter.
        /// </summary>
        [Property(xmiId: "OperationTemplateParameter-parameteredElement", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [RedefinedProperty(propertyName: "TemplateParameter-parameteredElement")]
        [Implements(implementation: "IOperationTemplateParameter.ParameteredElement")]
        public new IOperation ParameteredElement { get; set; }

        /// <summary>
        /// The ParameterableElement exposed by this TemplateParameter.
        /// </summary>
        [Property(xmiId: "TemplateParameter-parameteredElement", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [RedefinedByProperty("IOperationTemplateParameter.ParameteredElement")]
        [Implements(implementation: "ITemplateParameter.ParameteredElement")]
        IParameterableElement ITemplateParameter.ParameteredElement { get; set; }

        /// <summary>
        /// The TemplateSignature that owns this TemplateParameter.
        /// </summary>
        [Property(xmiId: "TemplateParameter-signature", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_parameter_templateSignature-templateSignature")]
        [SubsettedProperty(propertyName: "Element-owner")]
        [Implements(implementation: "ITemplateParameter.Signature")]
        public ITemplateSignature Signature { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
