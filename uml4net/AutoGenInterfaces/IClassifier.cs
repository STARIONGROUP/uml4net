// -------------------------------------------------------------------------------------------------
// <copyright file="IClassifier.cs" company="Starion Group S.A.">
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

    using uml4net.Utils;

    /// <summary>
    /// A Classifier represents a classification of instances according to their Features.
    /// </summary>
    [Class(xmiId: "Classifier", isAbstract: true, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IClassifier : INamespace, IType, ITemplateableElement, IRedefinableElement
    {
        /// <summary>
        /// All of the Properties that are direct (i.e., not inherited or imported) attributes of the
        /// Classifier.
        /// </summary>
        [Property(xmiId: "Classifier-attribute", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_redefinitionContext_redefinableElement-redefinableElement")]
        [SubsettedProperty(propertyName: "Classifier-feature")]
        public List<IProperty> Attribute { get; }

        /// <summary>
        /// The CollaborationUses owned by the Classifier.
        /// </summary>
        [Property(xmiId: "Classifier-collaborationUse", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<ICollaborationUse> CollaborationUse { get; set; }

        /// <summary>
        /// Specifies each Feature directly defined in the classifier. Note that there may be members of the
        /// Classifier that are of the type Feature but are not included, e.g., inherited features.
        /// </summary>
        [Property(xmiId: "Classifier-feature", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-member")]
        public List<IFeature> Feature { get; }

        /// <summary>
        /// The generalizing Classifiers for this Classifier.
        /// </summary>
        [Property(xmiId: "Classifier-general", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public List<IClassifier> General { get; }

        /// <summary>
        /// The Generalization relationships for this Classifier. These Generalizations navigate to more general
        /// Classifiers in the generalization hierarchy.
        /// </summary>
        [Property(xmiId: "Classifier-generalization", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_source_directedRelationship-directedRelationship")]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IGeneralization> Generalization { get; set; }

        /// <summary>
        /// All elements inherited by this Classifier from its general Classifiers.
        /// </summary>
        [Property(xmiId: "Classifier-inheritedMember", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-member")]
        public List<INamedElement> InheritedMember { get; }

        /// <summary>
        /// If true, the Classifier can only be instantiated by instantiating one of its specializations. An
        /// abstract Classifier is intended to be used by other Classifiers e.g., as the target of Associations
        /// or Generalizations.
        /// </summary>
        [Property(xmiId: "Classifier-isAbstract", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "false")]
        public bool IsAbstract { get; set; }

        /// <summary>
        /// If true, the Classifier cannot be specialized.
        /// </summary>
        [Property(xmiId: "Classifier-isFinalSpecialization", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "false")]
        public bool IsFinalSpecialization { get; set; }

        /// <summary>
        /// The optional RedefinableTemplateSignature specifying the formal template parameters.
        /// </summary>
        [Property(xmiId: "Classifier-ownedTemplateSignature", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_redefinitionContext_redefinableElement-redefinableElement")]
        [RedefinedProperty(propertyName: "TemplateableElement-ownedTemplateSignature")]
        public new IContainerList<IRedefinableTemplateSignature> OwnedTemplateSignature { get; set; }

        /// <summary>
        /// The UseCases owned by this classifier.
        /// </summary>
        [Property(xmiId: "Classifier-ownedUseCase", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        public IContainerList<IUseCase> OwnedUseCase { get; set; }

        /// <summary>
        /// The GeneralizationSet of which this Classifier is a power type.
        /// </summary>
        [Property(xmiId: "Classifier-powertypeExtent", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public List<IGeneralizationSet> PowertypeExtent { get; set; }

        /// <summary>
        /// The Classifiers redefined by this Classifier.
        /// </summary>
        [Property(xmiId: "Classifier-redefinedClassifier", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "RedefinableElement-redefinedElement")]
        public List<IClassifier> RedefinedClassifier { get; set; }

        /// <summary>
        /// A CollaborationUse which indicates the Collaboration that represents this Classifier.
        /// </summary>
        [Property(xmiId: "Classifier-representation", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Classifier-collaborationUse")]
        public ICollaborationUse Representation { get; set; }

        /// <summary>
        /// The Substitutions owned by this Classifier.
        /// </summary>
        [Property(xmiId: "Classifier-substitution", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [SubsettedProperty(propertyName: "NamedElement-clientDependency")]
        public IContainerList<ISubstitution> Substitution { get; set; }

        /// <summary>
        /// TheClassifierTemplateParameter that exposes this element as a formal parameter.
        /// </summary>
        [Property(xmiId: "Classifier-templateParameter", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [RedefinedProperty(propertyName: "ParameterableElement-templateParameter")]
        public new IClassifierTemplateParameter TemplateParameter { get; set; }

        /// <summary>
        /// The set of UseCases for which this Classifier is the subject.
        /// </summary>
        [Property(xmiId: "Classifier-useCase", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public List<IUseCase> UseCases { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
