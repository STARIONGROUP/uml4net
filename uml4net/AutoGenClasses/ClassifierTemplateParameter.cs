// -------------------------------------------------------------------------------------------------
// <copyright file="ClassifierTemplateParameter.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2026 Starion Group S.A.
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
    /// A ClassifierTemplateParameter exposes a Classifier as a formal template parameter.
    /// </summary>
    [Class(xmiId: "ClassifierTemplateParameter", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial class ClassifierTemplateParameter : XmiElement, IClassifierTemplateParameter
    {
        /// <summary>
        /// Gets or sets the container of this <see cref="IElement"/>
        /// </summary>
        public IElement Possessor { get; set; }

        /// <summary>
        /// Constrains the required relationship between an actual parameter and the parameteredElement for this
        /// formal parameter.
        /// </summary>
        [Property(xmiId: "ClassifierTemplateParameter-allowSubstitutable", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: "true")]
        [Implements(implementation: "IClassifierTemplateParameter.AllowSubstitutable")]
        public bool AllowSubstitutable { get; set; } = true;

        /// <summary>
        /// The classifiers that constrain the argument that can be used for the parameter. If the
        /// allowSubstitutable attribute is true, then any Classifier that is compatible with this constraining
        /// Classifier can be substituted; otherwise, it must be either this Classifier or one of its
        /// specializations. If this property is empty, there are no constraints on the Classifier that can be
        /// used as an argument.
        /// </summary>
        [Property(xmiId: "ClassifierTemplateParameter-constrainingClassifier", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IClassifierTemplateParameter.ConstrainingClassifier")]
        public List<IClassifier> ConstrainingClassifier { get; set; } = new();

        /// <summary>
        /// The ParameterableElement that is the default for this formal TemplateParameter.
        /// </summary>
        [Property(xmiId: "TemplateParameter-default", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "ITemplateParameter.Default")]
        public IParameterableElement Default { get; set; }

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
        /// The ParameterableElement that is owned by this TemplateParameter for the purpose of providing a
        /// default.
        /// </summary>
        [Property(xmiId: "TemplateParameter-ownedDefault", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
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
        [Property(xmiId: "Element-ownedElement", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.OwnedElement")]
        public IContainerList<IElement> OwnedElement => this.QueryOwnedElement();

        /// <summary>
        /// The ParameterableElement that is owned by this TemplateParameter for the purpose of exposing it as
        /// the parameteredElement.
        /// </summary>
        [Property(xmiId: "TemplateParameter-ownedParameteredElement", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
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
        [Property(xmiId: "Element-owner", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.Owner")]
        public IElement Owner => this.QueryOwner();

        /// <summary>
        /// The Classifier exposed by this ClassifierTemplateParameter.
        /// </summary>
        [Property(xmiId: "ClassifierTemplateParameter-parameteredElement", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [RedefinedProperty(propertyName: "TemplateParameter-parameteredElement")]
        [Implements(implementation: "IClassifierTemplateParameter.ParameteredElement")]
        public IClassifier ParameteredElement { get; set; }

        /// <summary>
        /// The ParameterableElement exposed by this TemplateParameter.
        /// </summary>
        [Property(xmiId: "TemplateParameter-parameteredElement", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [RedefinedByProperty("IClassifierTemplateParameter.ParameteredElement")]
        [Implements(implementation: "ITemplateParameter.ParameteredElement")]
        IParameterableElement ITemplateParameter.ParameteredElement
        {
            get => throw new InvalidOperationException("Redefined by property IClassifierTemplateParameter.ParameteredElement");
            set => throw new InvalidOperationException("Redefined by property IClassifierTemplateParameter.ParameteredElement");
        }

        /// <summary>
        /// The TemplateSignature that owns this TemplateParameter.
        /// </summary>
        [Property(xmiId: "TemplateParameter-signature", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_parameter_templateSignature-templateSignature")]
        [SubsettedProperty(propertyName: "Element-owner")]
        [Implements(implementation: "ITemplateParameter.Signature")]
        public ITemplateSignature Signature { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
