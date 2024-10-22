// -------------------------------------------------------------------------------------------------
// <copyright file="Generalization.cs" company="Starion Group S.A.">
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

    /// <summary>
    /// A Generalization is a taxonomic relationship between a more general Classifier and a more specific
    /// Classifier. Each instance of the specific Classifier is also an instance of the general Classifier.
    /// The specific Classifier inherits the features of the more general Classifier. A Generalization
    /// is owned by the specific Classifier.
    /// </summary>
    public class Generalization : XmiElement, IGeneralization
    {
        /// <summary>
        /// Gets or sets a dictionary of reference properties and the associated unique identifiers
        /// </summary>
        [Implements(implementation: "IGeneralization.ReferencePropertyValueIdentifiers")]
        public Dictionary<string, string> ReferencePropertyValueIdentifies { get; set; } = new Dictionary<string, string>();

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
        /// The general classifier in the Generalization relationship.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1)]
        [SubsettedProperty("DirectedRelationship-target")]
        [Implements(implementation: "IGeneralization.General")]
        public IClassifier General { get; set; }

        /// <summary>
        /// Represents a set of instances of Generalization.  A Generalization may appear in many GeneralizationSets.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue)]
        [Implements(implementation: "IGeneralization.GeneralizationSet")]
        public List<GeneralizationSet> GeneralizationSet { get; set; }

        /// <summary>
        /// Indicates whether the specific Classifier can be used wherever the general Classifier can be used. 
        /// If true, the execution traces of the specific Classifier shall be a superset of the execution traces 
        /// of the general Classifier. If false, there is no such constraint on execution traces. If unset, the 
        /// modeler has not stated whether there is such a constraint or not.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, defaultValue: "true")]
        [Implements(implementation: "IGeneralization.IsSubstitutable")]
        public bool IsSubstitutable { get; set; } = true;

        /// <summary>
        /// The specializing Classifier in the Generalization relationship.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1)]
        [Implements(implementation: "IGeneralization.Specific")]
        public IClassifier Specific { get; set; }
    }
}
