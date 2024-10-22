// -------------------------------------------------------------------------------------------------
// <copyright file="TemplateBinding.cs" company="Starion Group S.A.">
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
    /// A TemplateBinding is a DirectedRelationship between a TemplateableElement and a template. 
    /// A TemplateBinding specifies the TemplateParameterSubstitutions of actual parameters for the
    /// formal parameters of the template.
    /// </summary>
    public class TemplateBinding : XmiElement, ITemplateBinding
    {
        /// <summary>
        /// The Comments owned by this Element.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [Implements(implementation: "IElement.OwnedComment")]
        public List<IComment> OwnedComment { get; set; } = new List<IComment>();

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
        /// Specifies the source Element(s) of the DirectedRelationship.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [Implements(implementation: "IDirectedRelationship.Source")]
        [SubsettedProperty(propertyName: "Relationship.RelatedElement")]
        public List<IElement> Source => throw new NotImplementedException();

        /// <summary>
        /// Specifies the target Element(s) of the DirectedRelationship.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [Implements(implementation: "IDirectedRelationship.Target")]
        [SubsettedProperty(propertyName: "Relationship.RelatedElement")]
        public List<IElement> Target => throw new NotImplementedException();

        /// <summary>
        /// Specifies the elements related by the Relationship.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [Implements(implementation: "IRelationship.RelatedElement")]
        public List<IElement> RelatedElement => throw new NotImplementedException();

        /// <summary>
        /// The TemplateableElement that is bound by this TemplateBinding.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1)]
        [Implements(implementation: "ITemplateBinding.BoundElement")]
        [SubsettedProperty(propertyName: "DirectedRelationship.Source")]
        [SubsettedProperty(propertyName: "Element.Owner")]
        public ITemplateableElement BoundElement { get; set; }

        /// <summary>
        /// The TemplateParameterSubstitutions owned by this TemplateBinding.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [Implements(implementation: "ITemplateBinding.ParameterSubstitution")]
        [SubsettedProperty(propertyName: "Element.OwnedElement")]
        public List<ITemplateParameterSubstitution> ParameterSubstitution { get; set; }

        /// <summary>
        /// The TemplateSignature for the template that is the target of this TemplateBinding.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1)]
        [Implements(implementation: "ITemplateBinding.Signature")]
        public TemplateSignature Signature { get; set; }
    }
}
