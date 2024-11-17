// -------------------------------------------------------------------------------------------------
// <copyright file="Model.cs" company="Starion Group S.A.">
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
    using uml4net.POCO.Values;

    /// <summary>
    /// A model captures a view of a physical system. It is an abstraction of the physical system,
    /// with a certain purpose. This purpose determines what is to be included in the model and what
    /// is irrelevant. Thus the model completely describes those aspects of the physical system that
    /// are relevant to the purpose of the model, at the appropriate level of detail.
    /// </summary>
    public class Model : XmiElement, IModel
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
        /// Provides an identifier for the package that can be used for many purposes. A URI is the universally
        /// unique identification of the package following the IETF URI specification, RFC 2396 http://www.ietf.org/rfc/rfc2396.txt
        /// and it must comply with those syntax rules.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [Implements("IPackage.URI")]
        public string URI { get; set; }

        /// <summary>
        /// References the packaged elements that are Packages.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isDerived: true)]
        [SubsettedProperty("Package-packagedElement")]
        [Implements("NestedPackage.URI")]
        public List<IPackage> NestedPackage => this.QueryNestedPackage();

        /// <summary>
        /// References the Package that owns this Package.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [SubsettedProperty("A_packagedElement_owningPackage-owningPackage")]
        [Implements("NestedPackage.NestingPackage")]
        public IPackage NestingPackage { get; set; }

        /// <summary>
        /// References the Stereotypes that are owned by the Package.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isReadOnly: true, isDerived: true)]
        [SubsettedProperty("Package-packagedElement")]
        [Implements("NestedPackage.OwnedStereotype")]
        public IStereotype OwnedStereotype => throw new NotImplementedException();

        /// <summary>
        /// References the packaged elements that are Types.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isDerived: true)]
        [SubsettedProperty("A_ownedType_package")]
        [Implements("NestedPackage.OwnedType")]
        public List<IType> OwnedType => throw new NotImplementedException();

        /// <summary>
        /// References the PackageMerges that are owned by this Package.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty("A_source_directedRelationship-directedRelationship")]
        [SubsettedProperty("Element-ownedElement")]
        [Implements("NestedPackage.PackageMerge")]
        public List<IPackageMerge> PackageMerge { get; set; } = new List<IPackageMerge>();

        /// <summary>
        /// Specifies the packageable elements that are owned by this Package.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty("Namespace-ownedMember")]
        [Implements("NestedPackage.PackagedElement")]
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
        /// References the ProfileApplications that indicate which profiles have been applied to the Package.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty("A_source_directedRelationship-directedRelationship")]
        [SubsettedProperty("Element-ownedElement")]
        [Implements("NestedPackage.ProfileApplication")]
        public IContainerList<IProfileApplication> ProfileApplication
        {
            get => this.profileApplication ??= new ContainerList<IProfileApplication>(this);
            set => this.profileApplication = value;
        }

        /// <summary>
        /// Backing field for <see cref="PackageImport"/>
        /// </summary>
        private IContainerList<IProfileApplication> profileApplication;
        
        /// <summary>
        /// The name of the viewpoint that is expressed by a model (this name may refer to a profile definition).
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [Implements("Model.Viewpoint")]
        public string Viewpoint { get; set; }
    }
}
