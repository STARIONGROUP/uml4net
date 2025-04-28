// -------------------------------------------------------------------------------------------------
// <copyright file="CommunicationPath.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2025 Starion Group S.A.
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

namespace uml4net.Deployments
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
    /// A communication path is an association between two deployment targets, through which they are able
    /// to exchange signals and messages.
    /// </summary>
    [Class(xmiId: "CommunicationPath", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial class CommunicationPath : XmiElement, ICommunicationPath
    {
        /// <summary>
        /// Gets or sets the container of this <see cref="IElement"/>
        /// </summary>
        public IElement Possessor { get; set; }

        /// <summary>
        /// All of the Properties that are direct (i.e., not inherited or imported) attributes of the
        /// Classifier.
        /// </summary>
        [Property(xmiId: "Classifier-attribute", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_redefinitionContext_redefinableElement-redefinableElement")]
        [SubsettedProperty(propertyName: "Classifier-feature")]
        [Implements(implementation: "IClassifier.Attribute")]
        public List<IProperty> Attribute => this.QueryAttribute();

        /// <summary>
        /// Indicates the Dependencies that reference this NamedElement as a client.
        /// </summary>
        [Property(xmiId: "NamedElement-clientDependency", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: true, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_source_directedRelationship-directedRelationship")]
        [Implements(implementation: "INamedElement.ClientDependency")]
        public List<IDependency> ClientDependency => this.QueryClientDependency();

        /// <summary>
        /// The CollaborationUses owned by the Classifier.
        /// </summary>
        [Property(xmiId: "Classifier-collaborationUse", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "IClassifier.CollaborationUse")]
        public IContainerList<ICollaborationUse> CollaborationUse
        {
            get => this.collaborationUse ??= new ContainerList<ICollaborationUse>(this);
            set => this.collaborationUse = value;
        }

        /// <summary>
        /// Backing field for <see cref="CollaborationUse"/>
        /// </summary>
        private IContainerList<ICollaborationUse> collaborationUse;

        /// <summary>
        /// References the ElementImports owned by the Namespace.
        /// </summary>
        [Property(xmiId: "Namespace-elementImport", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_source_directedRelationship-directedRelationship")]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "INamespace.ElementImport")]
        public IContainerList<IElementImport> ElementImport
        {
            get => this.elementImport ??= new ContainerList<IElementImport>(this);
            set => this.elementImport = value;
        }

        /// <summary>
        /// Backing field for <see cref="ElementImport"/>
        /// </summary>
        private IContainerList<IElementImport> elementImport;

        /// <summary>
        /// The Classifiers that are used as types of the ends of the Association.
        /// </summary>
        [Property(xmiId: "Association-endType", aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Relationship-relatedElement")]
        [Implements(implementation: "IAssociation.EndType")]
        public List<IType> EndType => this.QueryEndType();

        /// <summary>
        /// Specifies each Feature directly defined in the classifier. Note that there may be members of the
        /// Classifier that are of the type Feature but are not included, e.g., inherited features.
        /// </summary>
        [Property(xmiId: "Classifier-feature", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-member")]
        [Implements(implementation: "IClassifier.Feature")]
        public List<IFeature> Feature => this.QueryFeature();

        /// <summary>
        /// The generalizing Classifiers for this Classifier.
        /// </summary>
        [Property(xmiId: "Classifier-general", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: true, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IClassifier.General")]
        public List<IClassifier> General => this.QueryGeneral();

        /// <summary>
        /// The Generalization relationships for this Classifier. These Generalizations navigate to more general
        /// Classifiers in the generalization hierarchy.
        /// </summary>
        [Property(xmiId: "Classifier-generalization", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_source_directedRelationship-directedRelationship")]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "IClassifier.Generalization")]
        public IContainerList<IGeneralization> Generalization
        {
            get => this.generalization ??= new ContainerList<IGeneralization>(this);
            set => this.generalization = value;
        }

        /// <summary>
        /// Backing field for <see cref="Generalization"/>
        /// </summary>
        private IContainerList<IGeneralization> generalization;

        /// <summary>
        /// References the PackageableElements that are members of this Namespace as a result of either
        /// PackageImports or ElementImports.
        /// </summary>
        [Property(xmiId: "Namespace-importedMember", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-member")]
        [Implements(implementation: "INamespace.ImportedMember")]
        public List<IPackageableElement> ImportedMember => this.QueryImportedMember();

        /// <summary>
        /// All elements inherited by this Classifier from its general Classifiers.
        /// </summary>
        [Property(xmiId: "Classifier-inheritedMember", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-member")]
        [Implements(implementation: "IClassifier.InheritedMember")]
        public List<INamedElement> InheritedMember => this.QueryInheritedMember();

        /// <summary>
        /// If true, the Classifier can only be instantiated by instantiating one of its specializations. An
        /// abstract Classifier is intended to be used by other Classifiers e.g., as the target of Associations
        /// or Generalizations.
        /// </summary>
        [Property(xmiId: "Classifier-isAbstract", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: "false")]
        [Implements(implementation: "IClassifier.IsAbstract")]
        public bool IsAbstract { get; set; }

        /// <summary>
        /// Specifies whether the Association is derived from other model elements such as other Associations.
        /// </summary>
        [Property(xmiId: "Association-isDerived", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: "false")]
        [Implements(implementation: "IAssociation.IsDerived")]
        public bool IsDerived { get; set; }

        /// <summary>
        /// If true, the Classifier cannot be specialized.
        /// </summary>
        [Property(xmiId: "Classifier-isFinalSpecialization", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: "false")]
        [Implements(implementation: "IClassifier.IsFinalSpecialization")]
        public bool IsFinalSpecialization { get; set; }

        /// <summary>
        /// Indicates whether it is possible to further redefine a RedefinableElement. If the value is true,
        /// then it is not possible to further redefine the RedefinableElement.
        /// </summary>
        [Property(xmiId: "RedefinableElement-isLeaf", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: "false")]
        [Implements(implementation: "IRedefinableElement.IsLeaf")]
        public bool IsLeaf { get; set; }

        /// <summary>
        /// A collection of NamedElements identifiable within the Namespace, either by being owned or by being
        /// introduced by importing or inheritance.
        /// </summary>
        [Property(xmiId: "Namespace-member", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: true, defaultValue: null)]
        [Implements(implementation: "INamespace.Member")]
        public List<INamedElement> Member => this.QueryMember();

        /// <summary>
        /// Each end represents participation of instances of the Classifier connected to the end in links of
        /// the Association.
        /// </summary>
        [Property(xmiId: "Association-memberEnd", aggregation: AggregationKind.None, lowerValue: 2, upperValue: int.MaxValue, isOrdered: true, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-member")]
        [Implements(implementation: "IAssociation.MemberEnd")]
        public List<IProperty> MemberEnd { get; set; } = new();

        /// <summary>
        /// The name of the NamedElement.
        /// </summary>
        [Property(xmiId: "NamedElement-name", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "INamedElement.Name")]
        public string Name { get; set; }

        /// <summary>
        /// The StringExpression used to define the name of this NamedElement.
        /// </summary>
        [Property(xmiId: "NamedElement-nameExpression", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "INamedElement.NameExpression")]
        public IContainerList<IStringExpression> NameExpression
        {
            get => this.nameExpression ??= new ContainerList<IStringExpression>(this);
            set => this.nameExpression = value;
        }

        /// <summary>
        /// Backing field for <see cref="NameExpression"/>
        /// </summary>
        private IContainerList<IStringExpression> nameExpression;

        /// <summary>
        /// Specifies the Namespace that owns the NamedElement.
        /// </summary>
        [Property(xmiId: "NamedElement-namespace", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_member_memberNamespace-memberNamespace")]
        [SubsettedProperty(propertyName: "Element-owner")]
        [Implements(implementation: "INamedElement.Namespace")]
        public INamespace Namespace => this.QueryNamespace();

        /// <summary>
        /// The navigable ends that are owned by the Association itself.
        /// </summary>
        [Property(xmiId: "Association-navigableOwnedEnd", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Association-ownedEnd")]
        [Implements(implementation: "IAssociation.NavigableOwnedEnd")]
        public List<IProperty> NavigableOwnedEnd { get; set; } = new();

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
        /// The Elements owned by this Element.
        /// </summary>
        [Property(xmiId: "Element-ownedElement", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.OwnedElement")]
        public IContainerList<IElement> OwnedElement => this.QueryOwnedElement();

        /// <summary>
        /// The ends that are owned by the Association itself.
        /// </summary>
        [Property(xmiId: "Association-ownedEnd", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_redefinitionContext_redefinableElement-redefinableElement")]
        [SubsettedProperty(propertyName: "Association-memberEnd")]
        [SubsettedProperty(propertyName: "Classifier-feature")]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        [Implements(implementation: "IAssociation.OwnedEnd")]
        public IContainerList<IProperty> OwnedEnd
        {
            get => this.ownedEnd ??= new ContainerList<IProperty>(this);
            set => this.ownedEnd = value;
        }

        /// <summary>
        /// Backing field for <see cref="OwnedEnd"/>
        /// </summary>
        private IContainerList<IProperty> ownedEnd;

        /// <summary>
        /// A collection of NamedElements owned by the Namespace.
        /// </summary>
        [Property(xmiId: "Namespace-ownedMember", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [SubsettedProperty(propertyName: "Namespace-member")]
        [Implements(implementation: "INamespace.OwnedMember")]
        public IContainerList<INamedElement> OwnedMember => this.QueryOwnedMember();

        /// <summary>
        /// Specifies a set of Constraints owned by this Namespace.
        /// </summary>
        [Property(xmiId: "Namespace-ownedRule", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        [Implements(implementation: "INamespace.OwnedRule")]
        public IContainerList<IConstraint> OwnedRule
        {
            get => this.ownedRule ??= new ContainerList<IConstraint>(this);
            set => this.ownedRule = value;
        }

        /// <summary>
        /// Backing field for <see cref="OwnedRule"/>
        /// </summary>
        private IContainerList<IConstraint> ownedRule;

        /// <summary>
        /// The optional RedefinableTemplateSignature specifying the formal template parameters.
        /// </summary>
        [Property(xmiId: "Classifier-ownedTemplateSignature", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_redefinitionContext_redefinableElement-redefinableElement")]
        [RedefinedProperty(propertyName: "TemplateableElement-ownedTemplateSignature")]
        [Implements(implementation: "IClassifier.OwnedTemplateSignature")]
        public IContainerList<IRedefinableTemplateSignature> OwnedTemplateSignature
        {
            get => this.ownedTemplateSignature ??= new ContainerList<IRedefinableTemplateSignature>(this);
            set => this.ownedTemplateSignature = value;
        }

        /// <summary>
        /// Backing field for <see cref="OwnedTemplateSignature"/>
        /// </summary>
        private IContainerList<IRedefinableTemplateSignature> ownedTemplateSignature;

        /// <summary>
        /// The optional TemplateSignature specifying the formal TemplateParameters for this
        /// TemplateableElement. If a TemplateableElement has a TemplateSignature, then it is a template.
        /// </summary>
        [Property(xmiId: "TemplateableElement-ownedTemplateSignature", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [RedefinedByProperty("IClassifier.OwnedTemplateSignature")]
        [Implements(implementation: "ITemplateableElement.OwnedTemplateSignature")]
        IContainerList<ITemplateSignature> ITemplateableElement.OwnedTemplateSignature
        {
            get => throw new InvalidOperationException("Redefined by property IClassifier.OwnedTemplateSignature");
            set => throw new InvalidOperationException("Redefined by property IClassifier.OwnedTemplateSignature");
        }

        /// <summary>
        /// The UseCases owned by this classifier.
        /// </summary>
        [Property(xmiId: "Classifier-ownedUseCase", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        [Implements(implementation: "IClassifier.OwnedUseCase")]
        public IContainerList<IUseCase> OwnedUseCase
        {
            get => this.ownedUseCase ??= new ContainerList<IUseCase>(this);
            set => this.ownedUseCase = value;
        }

        /// <summary>
        /// Backing field for <see cref="OwnedUseCase"/>
        /// </summary>
        private IContainerList<IUseCase> ownedUseCase;

        /// <summary>
        /// The Element that owns this Element.
        /// </summary>
        [Property(xmiId: "Element-owner", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IElement.Owner")]
        public IElement Owner => this.QueryOwner();

        /// <summary>
        /// The formal TemplateParameter that owns this ParameterableElement.
        /// </summary>
        [Property(xmiId: "ParameterableElement-owningTemplateParameter", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-owner")]
        [SubsettedProperty(propertyName: "ParameterableElement-templateParameter")]
        [Implements(implementation: "IParameterableElement.OwningTemplateParameter")]
        public ITemplateParameter OwningTemplateParameter { get; set; }

        /// <summary>
        /// Specifies the owning Package of this Type, if any.
        /// </summary>
        [Property(xmiId: "Type-package", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_packagedElement_owningPackage-owningPackage")]
        [Implements(implementation: "IType.Package")]
        public IPackage Package { get; set; }

        /// <summary>
        /// References the PackageImports owned by the Namespace.
        /// </summary>
        [Property(xmiId: "Namespace-packageImport", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_source_directedRelationship-directedRelationship")]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "INamespace.PackageImport")]
        public IContainerList<IPackageImport> PackageImport
        {
            get => this.packageImport ??= new ContainerList<IPackageImport>(this);
            set => this.packageImport = value;
        }

        /// <summary>
        /// Backing field for <see cref="PackageImport"/>
        /// </summary>
        private IContainerList<IPackageImport> packageImport;

        /// <summary>
        /// The GeneralizationSet of which this Classifier is a power type.
        /// </summary>
        [Property(xmiId: "Classifier-powertypeExtent", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IClassifier.PowertypeExtent")]
        public List<IGeneralizationSet> PowertypeExtent { get; set; } = new();

        /// <summary>
        /// A name that allows the NamedElement to be identified within a hierarchy of nested Namespaces. It is
        /// constructed from the names of the containing Namespaces starting at the root of the hierarchy and
        /// ending with the name of the NamedElement itself.
        /// </summary>
        [Property(xmiId: "NamedElement-qualifiedName", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "INamedElement.QualifiedName")]
        public string QualifiedName => this.QueryQualifiedName();

        /// <summary>
        /// The Classifiers redefined by this Classifier.
        /// </summary>
        [Property(xmiId: "Classifier-redefinedClassifier", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "RedefinableElement-redefinedElement")]
        [Implements(implementation: "IClassifier.RedefinedClassifier")]
        public List<IClassifier> RedefinedClassifier { get; set; } = new();

        /// <summary>
        /// The RedefinableElement that is being redefined by this element.
        /// </summary>
        [Property(xmiId: "RedefinableElement-redefinedElement", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IRedefinableElement.RedefinedElement")]
        public List<IRedefinableElement> RedefinedElement => this.QueryRedefinedElement();

        /// <summary>
        /// The contexts that this element may be redefined from.
        /// </summary>
        [Property(xmiId: "RedefinableElement-redefinitionContext", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IRedefinableElement.RedefinitionContext")]
        public List<IClassifier> RedefinitionContext => this.QueryRedefinitionContext();

        /// <summary>
        /// Specifies the elements related by the Relationship.
        /// </summary>
        [Property(xmiId: "Relationship-relatedElement", aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IRelationship.RelatedElement")]
        public List<IElement> RelatedElement => this.QueryRelatedElement();

        /// <summary>
        /// A CollaborationUse which indicates the Collaboration that represents this Classifier.
        /// </summary>
        [Property(xmiId: "Classifier-representation", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Classifier-collaborationUse")]
        [Implements(implementation: "IClassifier.Representation")]
        public ICollaborationUse Representation { get; set; }

        /// <summary>
        /// The Substitutions owned by this Classifier.
        /// </summary>
        [Property(xmiId: "Classifier-substitution", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [SubsettedProperty(propertyName: "NamedElement-clientDependency")]
        [Implements(implementation: "IClassifier.Substitution")]
        public IContainerList<ISubstitution> Substitution
        {
            get => this.substitution ??= new ContainerList<ISubstitution>(this);
            set => this.substitution = value;
        }

        /// <summary>
        /// Backing field for <see cref="Substitution"/>
        /// </summary>
        private IContainerList<ISubstitution> substitution;

        /// <summary>
        /// The optional TemplateBindings from this TemplateableElement to one or more templates.
        /// </summary>
        [Property(xmiId: "TemplateableElement-templateBinding", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_source_directedRelationship-directedRelationship")]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "ITemplateableElement.TemplateBinding")]
        public IContainerList<ITemplateBinding> TemplateBinding
        {
            get => this.templateBinding ??= new ContainerList<ITemplateBinding>(this);
            set => this.templateBinding = value;
        }

        /// <summary>
        /// Backing field for <see cref="TemplateBinding"/>
        /// </summary>
        private IContainerList<ITemplateBinding> templateBinding;

        /// <summary>
        /// TheClassifierTemplateParameter that exposes this element as a formal parameter.
        /// </summary>
        [Property(xmiId: "Classifier-templateParameter", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [RedefinedProperty(propertyName: "ParameterableElement-templateParameter")]
        [Implements(implementation: "IClassifier.TemplateParameter")]
        public IClassifierTemplateParameter TemplateParameter { get; set; }

        /// <summary>
        /// The TemplateParameter that exposes this ParameterableElement as a formal parameter.
        /// </summary>
        [Property(xmiId: "ParameterableElement-templateParameter", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [RedefinedByProperty("IClassifier.TemplateParameter")]
        [Implements(implementation: "IParameterableElement.TemplateParameter")]
        ITemplateParameter IParameterableElement.TemplateParameter
        {
            get => throw new InvalidOperationException("Redefined by property IClassifier.TemplateParameter");
            set => throw new InvalidOperationException("Redefined by property IClassifier.TemplateParameter");
        }

        /// <summary>
        /// The set of UseCases for which this Classifier is the subject.
        /// </summary>
        [Property(xmiId: "Classifier-useCase", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [Implements(implementation: "IClassifier.UseCases")]
        public List<IUseCase> UseCases { get; set; } = new();

        /// <summary>
        /// Determines whether and how the NamedElement is visible outside its owning Namespace.
        /// </summary>
        [Property(xmiId: "NamedElement-visibility", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [RedefinedByProperty("IPackageableElement.Visibility")]
        [Implements(implementation: "INamedElement.Visibility")]
        VisibilityKind INamedElement.Visibility
        {
            get => throw new InvalidOperationException("Redefined by property IPackageableElement.Visibility");
            set => throw new InvalidOperationException("Redefined by property IPackageableElement.Visibility");
        }

        /// <summary>
        /// A PackageableElement must have a visibility specified if it is owned by a Namespace. The default
        /// visibility is public.
        /// </summary>
        [Property(xmiId: "PackageableElement-visibility", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: "public")]
        [RedefinedProperty(propertyName: "NamedElement-visibility")]
        [Implements(implementation: "IPackageableElement.Visibility")]
        public VisibilityKind Visibility { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
