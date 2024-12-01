// -------------------------------------------------------------------------------------------------
// <copyright file="IClassifier.cs" company="Starion Group S.A.">
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
    using uml4net.POCO.StructuredClassifiers;
    using uml4net.POCO.UseCases;
    using Utils;

    /// <summary>
    /// A Classifier represents a classification of instances according to their Features.
    /// </summary>
    public interface IClassifier : INamespace, IType, ITemplateableElement, IRedefinableElement
    {
        /// <summary>
        /// All of the Properties that are direct (i.e., not inherited or imported) attributes
        /// of the Classifier.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [SubsettedProperty(propertyName: "A_redefinitionContext_redefinableElement.RedefinableElement")]
        [SubsettedProperty(propertyName: "Classifier.Feature")]
        public List<IProperty> Attribute { get; }

        /// <summary>
        /// The CollaborationUses owned by the Classifier.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<ICollaborationUse> CollaborationUse { get; set; }

        /// <summary>
        /// Specifies each Feature directly defined in the classifier. Note that there may be members of the 
        /// Classifier that are of the type Feature but are not included, e.g., inherited features.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [SubsettedProperty(propertyName: "Namespace-member")]
        public List<IFeature> Feature { get; }

        /// <summary>
        /// The generalizing Classifiers for this Classifier.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isDerived: true)]
        public List<IClassifier> General { get; }

        /// <summary>
        /// The Generalization relationships for this Classifier. These Generalizations navigate to more general 
        /// Classifiers in the generalization hierarchy.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty(propertyName: "A_source_directedRelationship.DirectedRelationship")]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IGeneralization> Generalization { get; set; }

        /// <summary>
        /// All elements inherited by this Classifier from its general Classifiers.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isReadOnly: true, isDerived: true)]
        [SubsettedProperty(propertyName: "Namespace-member")]
        public List<INamedElement> InheritedMember { get; }

        /// <summary>
        /// If true, the Classifier can only be instantiated by instantiating one of its specializations. 
        /// An abstract Classifier is intended to be used by other Classifiers e.g., as the target of Associations or 
        /// Generalizations.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, defaultValue: "false")]
        public bool IsAbstract { get; set; }

        /// <summary>
        /// If true, the Classifier cannot be specialized.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, defaultValue: "false")]
        public bool IsFinalSpecialization { get; set; }

        /// <summary>
        /// The optional RedefinableTemplateSignature specifying the formal template parameters.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1)]
        [SubsettedProperty(propertyName: "A_redefinitionContext_redefinableElement-redefinableElement")]
        [RedefinedProperty(propertyName: "TemplateableElement-ownedTemplateSignature")]
        public new IContainerList<IRedefinableTemplateSignature>  OwnedTemplateSignature { get; set; }

        /// <summary>
        /// The UseCases owned by this classifier.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        public IContainerList<IUseCase> OwnedUseCase { get; set; }

        /// <summary>
        /// The GeneralizationSet of which this Classifier is a power type.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue)]
        public List<IGeneralizationSet> PowertypeExtent { get; set; }

        /// <summary>
        /// The Classifiers redefined by this Classifier.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty(propertyName: "RedefinableElement-redefinedElement")]
        public List<IClassifier> RedefinedClassifier { get; set; }

        /// <summary>
        /// A CollaborationUse which indicates the Collaboration that represents this Classifier.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [SubsettedProperty(propertyName: "Classifier-collaborationUse")]
        public ICollaborationUse Representation { get; set; }

        /// <summary>
        /// The Substitutions owned by this Classifier.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [SubsettedProperty(propertyName: "NamedElement-clientDependency")]
        public IContainerList<ISubstitution> Substitution { get; set; }

        /// <summary>
        /// TheClassifierTemplateParameter that exposes this element as a formal parameter.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [RedefinedProperty(propertyName: "ParameterableElement-templateParameter")]
        public new IClassifierTemplateParameter TemplateParameter { get; set; }
    }
}
