// -------------------------------------------------------------------------------------------------
// <copyright file="Stereotype.cs" company="Starion Group S.A.">
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

namespace uml4net.POCO.Packages
{
    using System;
    using System.Collections.Generic;

    using uml4net.Decorators;
    using uml4net.Extend;
    using uml4net.Utils;
    using uml4net.POCO.Classification;
    using uml4net.POCO.CommonStructure;
    using uml4net.POCO.SimpleClassifiers;
    using uml4net.POCO.StructuredClassifiers;
    using uml4net.POCO.UseCases;
    using uml4net.POCO.Values;

    /// <summary>
    /// A stereotype defines how an existing metaclass may be extended, and enables the use of platform or domain
    /// specific terminology or notation in place of, or in addition to, the ones used for the extended metaclass.
    /// </summary>
    public class Stereotype : XmiElement, IStereotype
    {
        /// <summary>
        /// The Comments owned by this Element.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        IContainerList<IComment> IElement.OwnedComment
        {
            get => this.ownedComment ??= new ContainerList<IComment>(this);
            set => this.ownedComment = value;
        }

        /// <summary>
        /// Backing field for <see cref="IElement.OwnedComment"/>
        /// </summary>
        private IContainerList<IComment> ownedComment;

        /// <summary>
        /// The Elements owned by this Element
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        List<IElement> IElement.OwnedElement => throw new NotImplementedException();

        /// <summary>
        /// The Element that owns this Element.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        IElement IElement.Owner => this.QueryOwner();
        
        /// <summary>
        /// Gets or sets the container of this <see cref="IElement"/>
        /// </summary>
        public IElement Container { get; set; }

        /// <summary>
        /// Indicates the Dependencies that reference this NamedElement as a client."
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isDerived: true)]
        [SubsettedProperty(propertyName: "A_source_directedRelationship.DirectedRelationship")]
        List<IDependency> INamedElement.ClientDependency => throw new NotImplementedException();

        /// <summary>
        /// The name of the NamedElement.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        string INamedElement.Name { get; set; }

        /// <summary>
        /// The StringExpression used to define the name of this NamedElement.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1)]
        [SubsettedProperty(propertyName: "Element.OwnedElement")]
        IStringExpression INamedElement.NameExpression { get; set; }

        /// <summary>
        /// Specifies the Namespace that owns the NamedElement.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [SubsettedProperty(propertyName: "A_member_memberNamespace.MemberNamespace")]
        [SubsettedProperty(propertyName: "Element.Owner")]
        INamespace INamedElement.Namespace => throw new NotImplementedException();

        /// <summary>
        /// A name that allows the NamedElement to be identified within a hierarchy of nested Namespaces. It is constructed from the names of 
        /// the containing Namespaces starting at the root of the hierarchy and ending with the name of the NamedElement itself.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isReadOnly: true, isDerived: true)]
        string INamedElement.QualifiedName => throw new NotImplementedException();

        /// <summary>
        /// Determines whether and how the NamedElement is visible outside its owning Namespace.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        VisibilityKind INamedElement.Visibility { get; set; }

        /// <summary>
        /// A PackageableElement must have a visibility specified if it is owned by a Namespace. The default visibility is public.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        VisibilityKind IPackageableElement.Visibility { get; set; }

        /// <summary>
        /// References the ElementImports owned by the Namespace.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty(propertyName: "A_source_directedRelationship.directedRelationship")]
        [SubsettedProperty(propertyName: "Element.OwnedElement")]
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
        /// References the PackageableElements that are members of this Namespace as a result of either PackageImports or ElementImports.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isReadOnly: true, isDerived: true)]
        [SubsettedProperty(propertyName: "Namespace.Member")]
        List<IPackageableElement> INamespace.ImportedMember => throw new NotImplementedException();
        

        /// <summary>
        /// A collection of NamedElements owned by the Namespace.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [SubsettedProperty(propertyName: "Element.OwnedElement")]
        [SubsettedProperty(propertyName: "Namespace.Member")]
        List<INamedElement> INamespace.OwnedMember => throw new NotImplementedException();

        /// <summary>
        /// Specifies a set of Constraints owned by this Namespace.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty(propertyName: "Namespace.OwnedMember")]
        List<IConstraint> INamespace.OwnedRule { get; set; }

        /// <summary>
        /// References the PackageImports owned by the Namespace.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty(propertyName: "Element.OwnedElement")]
        IContainerList<IPackageImport> INamespace.PackageImport
        {
            get => this.packageImport ??= new ContainerList<IPackageImport>(this);
            set => this.packageImport = value;
        }

        /// <summary>
        /// Backing field for <see cref="INamespace.PackageImport"/>
        /// </summary>
        private IContainerList<IPackageImport> packageImport;

        /// <summary>
        /// The formal TemplateParameter that owns this ParameterableElement
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [SubsettedProperty(propertyName: "Element.Owner")]
        [SubsettedProperty(propertyName: "ParameterableElement.TemplateParameter")]
        ITemplateParameter IParameterableElement.OwningTemplateParameter { get; set; }

        /// <summary>
        /// ParameterableElement-templateParameter-_ownedComment.0" body="The TemplateParameter that exposes this 
        /// ParameterableElement as a formal parameter.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        ITemplateParameter IParameterableElement.TemplateParameter { get; set; }

        /// <summary>
        /// The optional TemplateSignature specifying the formal TemplateParameters for this TemplateableElement.
        /// If a TemplateableElement has a TemplateSignature, then it is a template.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1)]
        ITemplateSignature ITemplateableElement.OwnedTemplateSignature { get; set; }

        /// <summary>
        /// The optional TemplateSignature specifying the formal TemplateParameters for this TemplateableElement.
        /// If a TemplateableElement has a TemplateSignature, then it is a template.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty(propertyName: "Element.OwnedElement")]
        [SubsettedProperty(propertyName: "A_source_directedRelationship.DirectedRelationship")]
        List<TemplateBinding> ITemplateableElement.TemplateBinding { get; set; }

        /// <summary>
        /// Specifies the owning Package of this Type, if any.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [SubsettedProperty(propertyName: "A_packagedElement_owningPackage.OwningPackage")]
        IPackage IType.Package { get; set; }

        /// <summary>
        /// All of the Properties that are direct (i.e., not inherited or imported) attributes
        /// of the Classifier.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [SubsettedProperty(propertyName: "A_redefinitionContext_redefinableElement.RedefinableElement")]
        [SubsettedProperty(propertyName: "Classifier.Feature")]
        List<IProperty> IClassifier.Attribute { get; set; }

        /// <summary>
        /// The CollaborationUses owned by the Classifier.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        List<ICollaborationUse> IClassifier.CollaborationUse { get; set; }

        /// <summary>
        /// Specifies each Feature directly defined in the classifier. Note that there may be members of the 
        /// Classifier that are of the type Feature but are not included, e.g., inherited features.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [SubsettedProperty(propertyName: "Namespace-member")]
        List<IFeature> IClassifier.Feature => throw new NotImplementedException();

        /// <summary>
        /// The generalizing Classifiers for this Classifier.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isDerived: true)]
        List<IClassifier> IClassifier.General => throw new NotImplementedException();

        /// <summary>
        /// The Generalization relationships for this Classifier. These Generalizations navigate to more general 
        /// Classifiers in the generalization hierarchy.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty(propertyName: "A_source_directedRelationship.DirectedRelationship")]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        IContainerList<IGeneralization> IClassifier.Generalization
        {
            get => this.generalization ??= new ContainerList<IGeneralization>(this);
            set => this.generalization = value;
        }

        /// <summary>
        /// Backing field for <see cref="IClassifier.Generalization"/>
        /// </summary>
        private IContainerList<IGeneralization> generalization;

        /// <summary>
        /// All elements inherited by this Classifier from its general Classifiers.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isReadOnly: true, isDerived: true)]
        [SubsettedProperty(propertyName: "Namespace-member")]
        List<INamedElement> IClassifier.InheritedMember => throw new NotImplementedException();

        /// <summary>
        /// If true, the Classifier can only be instantiated by instantiating one of its specializations. 
        /// An abstract Classifier is intended to be used by other Classifiers e.g., as the target of Associations or 
        /// Generalizations.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, defaultValue: "false")]
        bool IClassifier.IsAbstract { get; set; }

        /// <summary>
        /// If true, the Classifier cannot be specialized.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, defaultValue: "false")]
        bool IClassifier.IsFinalSpecialization { get; set; }

        /// <summary>
        /// The optional RedefinableTemplateSignature specifying the formal template parameters.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1)]
        [SubsettedProperty(propertyName: "A_redefinitionContext_redefinableElement-redefinableElement")]
        [RedefinedProperty(propertyName: "TemplateableElement-ownedTemplateSignature")]
        IRedefinableTemplateSignature IClassifier.OwnedTemplateSignature { get; set; }

        /// <summary>
        /// The UseCases owned by this classifier.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        List<IUseCase> IClassifier.OwnedUseCase { get; set; }

        /// <summary>
        /// The GeneralizationSet of which this Classifier is a power type.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue)]
        List<IGeneralizationSet> IClassifier.PowertypeExtent { get; set; }

        /// <summary>
        /// The Classifiers redefined by this Classifier.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty(propertyName: "RedefinableElement-redefinedElement")]
        List<IClassifier> IClassifier.RedefinedClassifier { get; set; }

        /// <summary>
        /// A CollaborationUse which indicates the Collaboration that represents this Classifier.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [SubsettedProperty(propertyName: "Classifier-collaborationUse")]
        ICollaborationUse IClassifier.Representation { get; set; }

        /// <summary>
        /// The Substitutions owned by this Classifier.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [SubsettedProperty(propertyName: "NamedElement-clientDependency")]
        List<ISubstitution> IClassifier.Substitution { get; set; }

        /// <summary>
        /// TheClassifierTemplateParameter that exposes this element as a formal parameter.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [RedefinedProperty(propertyName: "ParameterableElement-templateParameter")]
        IClassifierTemplateParameter IClassifier.TemplateParameter { get; set; }

        /// <summary>
        /// Indicates whether it is possible to further redefine a RedefinableElement. If the value is
        /// true, then it is not possible to further redefine the RedefinableElement.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, defaultValue: "false")]
        [Implements(implementation: "IRedefinableElement.IsLeaf")]
        public bool IsLeaf { get; set; } = false;

        /// <summary>
        /// The RedefinableElement that is being redefined by this element.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [Implements(implementation: "IRedefinableElement.RedefinedElement")]
        public IRedefinableElement RedefinedElement => throw new NotImplementedException();

        /// <summary>
        /// The contexts that this element may be redefined from.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [Implements(implementation: "IRedefinableElement.RedefinitionContext")]
        public IClassifier RedefinitionContext => throw new NotImplementedException();

        /// <summary>
        /// Stereotype can change the graphical appearance of the extended model element by using attached icons.
        /// When this association is not null, it references the location of the icon content to be displayed within
        /// diagrams presenting the extended model elements.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [Implements(implementation: "IStereotype.Icon")]
        public List<IImage> Icon { get; set; }

        /// <summary>
        /// The profile that directly or indirectly contains this stereotype.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isReadOnly: true, isDerived: true)]
        [Implements(implementation: "IStereotype.Profile")]
        public IProfile Profile => throw new NotImplementedException();

        /// <summary>
        /// This property is used when the Class is acting as a metaclass. It references the Extensions that specify
        /// additional properties of the metaclass. The property is derived from the Extensions whose memberEnds are
        /// typed by the Class.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isReadOnly: true, isDerived: true)]
        [Implements(implementation: "IClass.Extension")]
        public List<IExtension> Extension => throw new NotImplementedException();

        /// <summary>
        /// If true, the Class does not provide a complete declaration and cannot be instantiated. An abstract Class
        /// is typically used as a target of Associations or Generalizations.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, defaultValue: "false")]
        [RedefinedProperty("Classifier-isAbstract")]
        [Implements(implementation: "IClass.IsAbstract")]
        public bool IsAbstract { get; set; }

        /// <summary>
        /// Determines whether an object specified by this Class is active or not. If true, then the owning Class is
        /// referred to as an active Class. If false, then such a Class is referred to as a passive Class.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, defaultValue: "false")]
        [Implements(implementation: "IClass.IsActive")]
        public bool IsActive { get; set; }

        /// <summary>
        /// The Classifiers owned by the Class that are not ownedBehaviors.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty("A_redefinitionContext_redefinableElement-redefinableElement")]
        [SubsettedProperty("Namespace-ownedMember")]
        [Implements(implementation: "IClass.NestedClassifier")]
        public List<IClassifier> NestedClassifier { get; set; } = new();

        /// <summary>
        /// The attributes (i.e., the Properties) owned by the Class.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true)]
        [RedefinedProperty("StructuredClassifier-ownedAttribute")]
        [SubsettedProperty("Classifier-attribute")]
        [SubsettedProperty("Namespace-ownedMember")]
        [Implements(implementation: "IClass.OwnedAttribute")]
        public IContainerList<IProperty> OwnedAttribute
        {
            get => this.ownedAttribute ??= new ContainerList<IProperty>(this);
            set => this.ownedAttribute = value;
        }

        /// <summary>
        /// Backing field for <see cref="OwnedAttribute"/>
        /// </summary>
        private IContainerList<IProperty> ownedAttribute;

        /// <summary>
        /// The Operations owned by the Class.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true)]
        [SubsettedProperty("A_redefinitionContext_redefinableElement-redefinableElement")]
        [SubsettedProperty("Classifier-feature")]
        [SubsettedProperty("Namespace-ownedMember")]
        [Implements(implementation: "IClass.OwnedOperation")]
        public IContainerList<IOperation> OwnedOperation
        {
            get => this.ownedOperation ??= new ContainerList<IOperation>(this);
            set => this.ownedOperation = value;
        }

        /// <summary>
        /// Backing field for <see cref="OwnedOperation"/>
        /// </summary>
        private IContainerList<IOperation> ownedOperation;

        /// <summary>
        /// The Receptions owned by the Class.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty("Classifier-feature")]
        [SubsettedProperty("Namespace-ownedMember")]
        [Implements(implementation: "IClass.OwnedReception")]
        public IContainerList<IReception> OwnedReception
        {
            get => this.ownedReception ??= new ContainerList<IReception>(this);
            set => this.ownedReception = value;
        }

        /// <summary>
        /// Backing field for <see cref="OwnedReception"/>
        /// </summary>
        private IContainerList<IReception> ownedReception;

        /// <summary>
        /// The superclasses of a Class, derived from its Generalizations.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isDerived: true)]
        [RedefinedProperty("Class-superClass")]
        [Implements(implementation: "IClass.SuperClass")]
        public List<IClass> SuperClass => throw new NotImplementedException();
    }
}
