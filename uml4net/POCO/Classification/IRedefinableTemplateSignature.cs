// -------------------------------------------------------------------------------------------------
// <copyright file="IRedefinableTemplateSignature.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;

    using uml4net.Decorators;
    using uml4net.POCO.CommonStructure;

    /// <summary>
    /// A RedefinableTemplateSignature supports the addition of formal template parameters in a specialization
    /// of a template classifier.
    /// </summary>
    public interface IRedefinableTemplateSignature : IRedefinableElement, ITemplateSignature
    {
        /// <summary>
        /// The Classifier that owns this RedefinableTemplateSignature.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1)]
        [RedefinedProperty("TemplateSignature-template")]
        [SubsettedProperty("RedefinableElement-redefinitionContext")]
        public IClassifier Classifier { get; set; }

        /// <summary>
        /// The signatures extended by this RedefinableTemplateSignature.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue)]
        [SubsettedProperty("RedefinableElement-redefinedElement")]
        public List<IRedefinableTemplateSignature> ExtendedSignature { get; set; }

        /// <summary>
        /// The formal template parameters of the extended signatures.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue, isReadOnly:true, isDerived:true)]
        [SubsettedProperty("TemplateSignature-parameter")]
        public ITemplateParameter InheritedParameter { get; }
    }
}
