// -------------------------------------------------------------------------------------------------
// <copyright file="OperationTemplateParameter.cs" company="Starion Group S.A.">
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
    using System;
    using System.Collections.Generic;

    using uml4net.Decorators;
    using uml4net.POCO.CommonStructure;
    using uml4net.POCO.StructuredClassifiers;

    /// <summary>
    /// An OperationTemplateParameter exposes an Operation as a formal parameter for a template.
    /// </summary>
    public class OperationTemplateParameter : IOperationTemplateParameter
    {
        /// <summary>
        /// The Comments owned by this Element.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [Implements(implementation: "IElement.OwnedComment")]
        public List<IComment> OwnedComment { get; set; }

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
        public IElement Owner => throw new NotImplementedException();

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
        public IParameterableElement ParameteredElement { get; set; }

        /// <summary>
        /// The TemplateSignature that owns this TemplateParameter.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1)]
        [Implements(implementation: "ITemplateParameter.Signature")]
        [SubsettedProperty(propertyName: "A_parameter_templateSignature.TemplateSignature")]
        [SubsettedProperty(propertyName: "Element.Owner")]
        public ITemplateSignature Signature { get; set; }
    }
}
