// -------------------------------------------------------------------------------------------------
// <copyright file="Model.cs" company="Starion Group S.A.">
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

namespace uml4net.Packages
{
    using System;
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
    /// A model captures a view of a physical system. It is an abstraction of the physical system, with a
    /// certain purpose. This purpose determines what is to be included in the model and what is irrelevant.
    /// Thus the model completely describes those aspects of the physical system that are relevant to the
    /// purpose of the model, at the appropriate level of detail.
    /// </summary>
    [Class(xmiId: "Model", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    public partial class Model : XmiElement, IModel
    {
        /// <summary>
        /// Gets or sets the container of this <see cref="IElement"/>
        /// </summary>
        public IElement Possessor { get; set; }

        /// <summary>
        /// Indicates the Dependencies that reference this NamedElement as a client.
        /// </summary>
        [Property(xmiId: "NamedElement-clientDependency", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_source_directedRelationship-directedRelationship")]
        [Implements(implementation: "INamedElement.ClientDependency")]
        public List<IDependency> ClientDependency => this.QueryClientDependency();

        /// <summary>
        /// References the ElementImports owned by the Namespace.
        /// </summary>
        [Property(xmiId: "Namespace-elementImport", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
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
        /// References the PackageableElements that are members of this Namespace as a result of either
        /// PackageImports or ElementImports.
        /// </summary>
        [Property(xmiId: "Namespace-importedMember", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-member")]
        [Implements(implementation: "INamespace.ImportedMember")]
        public List<IPackageableElement> ImportedMember => this.QueryImportedMember();

        /// <summary>
        /// A collection of NamedElements identifiable within the Namespace, either by being owned or by being
        /// introduced by importing or inheritance.
        /// </summary>
        [Property(xmiId: "Namespace-member", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        [Implements(implementation: "INamespace.Member")]
        public List<INamedElement> Member => this.QueryMember();

        /// <summary>
        /// The name of the NamedElement.
        /// </summary>
        [Property(xmiId: "NamedElement-name", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "INamedElement.Name")]
        public string Name { get; set; }

        /// <summary>
        /// The StringExpression used to define the name of this NamedElement.
        /// </summary>
        [Property(xmiId: "NamedElement-nameExpression", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
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
        [Property(xmiId: "NamedElement-namespace", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_member_memberNamespace-memberNamespace")]
        [SubsettedProperty(propertyName: "Element-owner")]
        [Implements(implementation: "INamedElement.Namespace")]
        public INamespace Namespace => this.QueryNamespace();

        /// <summary>
        /// References the packaged elements that are Packages.
        /// </summary>
        [Property(xmiId: "Package-nestedPackage", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Package-packagedElement")]
        [Implements(implementation: "IPackage.NestedPackage")]
        public IContainerList<IPackage> NestedPackage => this.QueryNestedPackage();

        /// <summary>
        /// References the Package that owns this Package.
        /// </summary>
        [Property(xmiId: "Package-nestingPackage", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_packagedElement_owningPackage-owningPackage")]
        [Implements(implementation: "IPackage.NestingPackage")]
        public IPackage NestingPackage { get; set; }

        /// <summary>
        /// The Comments owned by this Element.
        /// </summary>
        [Property(xmiId: "Element-ownedComment", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
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
        [Property(xmiId: "Element-ownedElement", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IElement.OwnedElement")]
        public IContainerList<IElement> OwnedElement => this.QueryOwnedElement();

        /// <summary>
        /// A collection of NamedElements owned by the Namespace.
        /// </summary>
        [Property(xmiId: "Namespace-ownedMember", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [SubsettedProperty(propertyName: "Namespace-member")]
        [Implements(implementation: "INamespace.OwnedMember")]
        public IContainerList<INamedElement> OwnedMember => this.QueryOwnedMember();

        /// <summary>
        /// Specifies a set of Constraints owned by this Namespace.
        /// </summary>
        [Property(xmiId: "Namespace-ownedRule", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
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
        /// References the Stereotypes that are owned by the Package.
        /// </summary>
        [Property(xmiId: "Package-ownedStereotype", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Package-packagedElement")]
        [Implements(implementation: "IPackage.OwnedStereotype")]
        public IContainerList<IStereotype> OwnedStereotype => this.QueryOwnedStereotype();

        /// <summary>
        /// The optional TemplateSignature specifying the formal TemplateParameters for this
        /// TemplateableElement. If a TemplateableElement has a TemplateSignature, then it is a template.
        /// </summary>
        [Property(xmiId: "TemplateableElement-ownedTemplateSignature", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "ITemplateableElement.OwnedTemplateSignature")]
        public IContainerList<ITemplateSignature> OwnedTemplateSignature
        {
            get => this.ownedTemplateSignature ??= new ContainerList<ITemplateSignature>(this);
            set => this.ownedTemplateSignature = value;
        }

        /// <summary>
        /// Backing field for <see cref="OwnedTemplateSignature"/>
        /// </summary>
        private IContainerList<ITemplateSignature> ownedTemplateSignature;

        /// <summary>
        /// References the packaged elements that are Types.
        /// </summary>
        [Property(xmiId: "Package-ownedType", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Package-packagedElement")]
        [Implements(implementation: "IPackage.OwnedType")]
        public IContainerList<IType> OwnedType => this.QueryOwnedType();

        /// <summary>
        /// The Element that owns this Element.
        /// </summary>
        [Property(xmiId: "Element-owner", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IElement.Owner")]
        public IElement Owner => this.QueryOwner();

        /// <summary>
        /// The formal TemplateParameter that owns this ParameterableElement.
        /// </summary>
        [Property(xmiId: "ParameterableElement-owningTemplateParameter", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-owner")]
        [SubsettedProperty(propertyName: "ParameterableElement-templateParameter")]
        [Implements(implementation: "IParameterableElement.OwningTemplateParameter")]
        public ITemplateParameter OwningTemplateParameter { get; set; }

        /// <summary>
        /// Specifies the packageable elements that are owned by this Package.
        /// </summary>
        [Property(xmiId: "Package-packagedElement", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        [Implements(implementation: "IPackage.PackagedElement")]
        public IContainerList<IPackageableElement> PackagedElement
        {
            get => this.packagedElement ??= new ContainerList<IPackageableElement>(this);
            set => this.packagedElement = value;
        }

        /// <summary>
        /// Backing field for <see cref="PackagedElement"/>
        /// </summary>
        private IContainerList<IPackageableElement> packagedElement;

        /// <summary>
        /// References the PackageImports owned by the Namespace.
        /// </summary>
        [Property(xmiId: "Namespace-packageImport", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
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
        /// References the PackageMerges that are owned by this Package.
        /// </summary>
        [Property(xmiId: "Package-packageMerge", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_source_directedRelationship-directedRelationship")]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "IPackage.PackageMerge")]
        public IContainerList<IPackageMerge> PackageMerge
        {
            get => this.packageMerge ??= new ContainerList<IPackageMerge>(this);
            set => this.packageMerge = value;
        }

        /// <summary>
        /// Backing field for <see cref="PackageMerge"/>
        /// </summary>
        private IContainerList<IPackageMerge> packageMerge;

        /// <summary>
        /// References the ProfileApplications that indicate which profiles have been applied to the Package.
        /// </summary>
        [Property(xmiId: "Package-profileApplication", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_source_directedRelationship-directedRelationship")]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "IPackage.ProfileApplication")]
        public IContainerList<IProfileApplication> ProfileApplication
        {
            get => this.profileApplication ??= new ContainerList<IProfileApplication>(this);
            set => this.profileApplication = value;
        }

        /// <summary>
        /// Backing field for <see cref="ProfileApplication"/>
        /// </summary>
        private IContainerList<IProfileApplication> profileApplication;

        /// <summary>
        /// A name that allows the NamedElement to be identified within a hierarchy of nested Namespaces. It is
        /// constructed from the names of the containing Namespaces starting at the root of the hierarchy and
        /// ending with the name of the NamedElement itself.
        /// </summary>
        [Property(xmiId: "NamedElement-qualifiedName", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "INamedElement.QualifiedName")]
        public string QualifiedName => this.QueryQualifiedName();

        /// <summary>
        /// The optional TemplateBindings from this TemplateableElement to one or more templates.
        /// </summary>
        [Property(xmiId: "TemplateableElement-templateBinding", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
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
        /// The TemplateParameter that exposes this ParameterableElement as a formal parameter.
        /// </summary>
        [Property(xmiId: "ParameterableElement-templateParameter", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IParameterableElement.TemplateParameter")]
        public ITemplateParameter TemplateParameter { get; set; }

        /// <summary>
        /// Provides an identifier for the package that can be used for many purposes. A URI is the universally
        /// unique identification of the package following the IETF URI specification, RFC 2396
        /// http://www.ietf.org/rfc/rfc2396.txt and it must comply with those syntax rules.
        /// </summary>
        [Property(xmiId: "Package-URI", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IPackage.URI")]
        public string URI { get; set; }

        /// <summary>
        /// The name of the viewpoint that is expressed by a model (this name may refer to a profile
        /// definition).
        /// </summary>
        [Property(xmiId: "Model-viewpoint", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IModel.Viewpoint")]
        public string Viewpoint { get; set; }

        /// <summary>
        /// A PackageableElement must have a visibility specified if it is owned by a Namespace. The default
        /// visibility is public.
        /// </summary>
        [Property(xmiId: "PackageableElement-visibility", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "public")]
        [RedefinedProperty(propertyName: "NamedElement-visibility")]
        [Implements(implementation: "IPackageableElement.Visibility")]
        public VisibilityKind Visibility { get; set; }

        /// <summary>
        /// Determines whether and how the NamedElement is visible outside its owning Namespace.
        /// </summary>
        [Property(xmiId: "NamedElement-visibility", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [RedefinedByProperty("IPackageableElement.Visibility")]
        [Implements(implementation: "INamedElement.Visibility")]
        VisibilityKind INamedElement.Visibility
        {
            get => throw new InvalidOperationException("Redefined by property IPackageableElement.Visibility");
            set => throw new InvalidOperationException("Redefined by property IPackageableElement.Visibility");
        }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
