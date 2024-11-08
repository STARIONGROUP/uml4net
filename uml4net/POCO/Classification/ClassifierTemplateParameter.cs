// -------------------------------------------------------------------------------------------------
// <copyright file="ClassifierTemplateParameter.cs" company="Starion Group S.A.">
//
//   Copyright 2019-2024 Starion Group S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, softwareUseCases
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.POCO.Classification
{
    using Extensions;

    using Utils; 
 
    using System;
    using System.Collections.Generic;

    using uml4net.Decorators;
    using uml4net.POCO.CommonStructure;

    /// <summary>
    /// A ClassifierTemplateParameter exposes a Classifier as a formal template parameter.
    /// </summary>
    public class ClassifierTemplateParameter : XmiElement, IClassifierTemplateParameter
    {
        /// <summary>
        /// The Comments owned by this Element.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
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
        /// The Elements owned by this Element
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [Implements(implementation: "IElement.OwnedElement")]
        public List<IElement> OwnedElement => throw new NotImplementedException();

        /// <summary>
        /// The Element that owns this Element.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [Implements(implementation: "IElement.Owner")]
        public IElement Owner => this.QueryOwner();

        /// <summary>
        /// Gets or sets the container of this <see cref="IElement"/>
        /// </summary>
        public IElement Container { get; set; }

        /// <summary>
        /// The ParameterableElement that is the default for this formal TemplateParameter.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [Implements(implementation: "ITemplateParameter.Default")]
        public IParameterableElement Default { get; set; }

        /// <summary>
        /// The ParameterableElement that is owned by this TemplateParameter for the purpose of providing a default.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1)]
        [Implements(implementation: "ITemplateParameter.OwnedDefault")]
        [SubsettedProperty(propertyName: "Element.OwnedElement")]
        [SubsettedProperty(propertyName: "TemplateParameter.Default")]
        public IParameterableElement OwnedDefault { get; set; }

        /// <summary>
        /// The ParameterableElement that is owned by this TemplateParameter for the purpose of exposing it as
        /// the parameteredElement.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1)]
        [Implements(implementation: "ITemplateParameter.OwnedParameteredElement")]
        [SubsettedProperty(propertyName: "Element.OwnedElement")]
        [SubsettedProperty(propertyName: "TemplateParameter.ParameteredElement")]
        public IParameterableElement OwnedParameteredElement { get; set; }

        /// <summary>
        /// The ParameterableElement exposed by this TemplateParameter.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1)]
        [Implements(implementation: "ITemplateParameter.ParameteredElement")]
        [RedefinedByProperty("IClassifierTemplateParameter.ParameteredElement")]
        IParameterableElement ITemplateParameter.ParameteredElement { get; set; }

        /// <summary>
        /// The TemplateSignature that owns this TemplateParameter.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1)]
        [Implements(implementation: "ITemplateParameter.Signature")]
        [SubsettedProperty(propertyName: "A_parameter_templateSignature.TemplateSignature")]
        [SubsettedProperty(propertyName: "Element.Owner")]
        public ITemplateSignature Signature { get; set; }

        /// <summary>
        /// Constrains the required relationship between an actual parameter and the parameteredElement for this formal parameter.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, defaultValue: "true")]
        [Implements("IClassifierTemplateParameter.AllowSubstitutable")]
        public bool AllowSubstitutable { get; set; } = true;

        /// <summary>
        /// The classifiers that constrain the argument that can be used for the parameter. If the allowSubstitutable attribute is true, 
        /// then any Classifier that is compatible with this constraining Classifier can be substituted; otherwise, it must be either 
        /// this Classifier or one of its specializations. If this property is empty, there are no constraints on the Classifier that 
        /// can be used as an argument.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue)]
        [Implements("IClassifierTemplateParameter.constrainingClassifier")]
        public List<IClassifier> constrainingClassifier { get; set; }

        /// <summary>
        /// The Classifier exposed by this ClassifierTemplateParameter.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1)]
        [RedefinedProperty(propertyName: "TemplateParameter-parameteredElement")]
        [Implements("IClassifierTemplateParameter.ParameteredElement")]
        public IClassifier ParameteredElement { get; set; }
    }
}
