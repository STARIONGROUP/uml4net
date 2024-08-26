// -------------------------------------------------------------------------------------------------
// <copyright file="TemplateParameter.cs" company="Starion Group S.A.">
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

namespace uml4net.POCO.CommonStructure
{
    using System;
    using System.Collections.Generic;

    using uml4net.Decorators;
    using uml4net.POCO.Classification;

    /// <summary>
    /// A TemplateParameter exposes a ParameterableElement as a formal parameter of a template.
    /// </summary>
    public class TemplateParameter : ITemplateParameter
    {
        /// <summary>
        /// Gets or sets the unique identifier of the Element in the XMI document
        /// </summary>
        [Implements(implementation: "IXmiElement.XmiId")]
        public string XmiId { get; set; }

        /// <summary>
        /// Gets or sets the GUID unique identifier of the Element in the XMI document
        /// </summary>
        [Implements(implementation: "IXmiElement.XmiGuid")]
        public string XmiGuid { get; set; }

        /// <summary>
        /// Gets or sets the name of the xmi type
        /// </summary>
        [Implements(implementation: "IXmiElement.XmiType")]
        public string XmiType { get; set; }

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
