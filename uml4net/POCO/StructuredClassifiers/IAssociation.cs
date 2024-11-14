// -------------------------------------------------------------------------------------------------
// <copyright file="IAssociation.cs" company="Starion Group S.A.">
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

namespace uml4net.POCO.StructuredClassifiers
{
    using System.Collections.Generic;

    using uml4net.Decorators;

    using uml4net.POCO.Classification;
    using uml4net.POCO.CommonStructure;
    using Utils;

    /// <summary>
    /// A link is a tuple of values that refer to typed objects.  An Association classifies a set of links, each of which
    /// is an instance of the Association.  Each value in the link refers to an instance of the type of the corresponding
    /// end of the Association
    /// </summary>
    public interface IAssociation  : IRelationship, IClassifier
    {
        /// <summary>
        /// The Classifiers that are used as types of the ends of the Association.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue, isReadOnly:true, isDerived:true)]
        public List<IType> EndType { get; }

        /// <summary>
        /// Specifies whether the Association is derived from other model elements such as other Associations.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, defaultValue:"false")]
        public bool IsDerived { get; set; }

        /// <summary>
        /// Each end represents participation of instances of the Classifier connected to the end in links of the Association.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 2, upperValue: int.MaxValue)]
        [SubsettedProperty(propertyName: "Namespace-member")]
        public IContainerList<IProperty> MemberEnd { get; set; }

        /// <summary>
        /// The navigable ends that are owned by the Association itself.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty(propertyName: "Association-ownedEnd")]
        public List<IProperty> NavigableOwnedEnd { get; set; }

        /// <summary>
        /// The ends that are owned by the Association itself.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered:true)]
        [SubsettedProperty(propertyName: "A_redefinitionContext_redefinableElement-redefinableElement")]
        [SubsettedProperty(propertyName: "Association-memberEnd")]
        [SubsettedProperty(propertyName: "Classifier-feature")]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        public IContainerList<IProperty> OwnedEnd { get; set; }
    }
}
