// -------------------------------------------------------------------------------------------------
// <copyright file="Property.cs" company="Starion Group S.A.">
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
    /// A Property is a StructuralFeature. A Property related by ownedAttribute to a Classifier (other than
    /// an association) represents an attribute and might also represent an association end. It relates an
    /// instance of the Classifier to a value or set of values of the type of the attribute. A Property
    /// related by memberEnd to an Association represents an end of the Association. The type of the
    /// Property is the type of the end of the Association. A Property has the capability of being a
    /// DeploymentTarget in a Deployment relationship. This enables modeling the deployment to hierarchical
    /// nodes that have Properties functioning as internal parts.  Property specializes ParameterableElement
    /// to specify that a Property can be exposed as a formal template parameter, and provided as an actual
    /// parameter in a binding of a template.
    /// </summary>
    [Class(xmiId: "Property", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial class Property : XmiElement, IProperty
    {
        /// <summary>
        /// Gets or sets the container of this <see cref="IElement"/>
        /// </summary>
        public IElement Possessor { get; set; }

        /// <summary>
        /// Specifies the kind of aggregation that applies to the Property.
        /// </summary>
        [Property(xmiId: "Property-aggregation", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "none")]
        [Implements(implementation: "IProperty.Aggregation")]
        public AggregationKind Aggregation { get; set; }

        /// <summary>
        /// The Association of which this Property is a member, if any.
        /// </summary>
        [Property(xmiId: "Property-association", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_member_memberNamespace-memberNamespace")]
        [Implements(implementation: "IProperty.Association")]
        public IAssociation Association { get; set; }

        /// <summary>
        /// Designates the optional association end that owns a qualifier attribute.
        /// </summary>
        [Property(xmiId: "Property-associationEnd", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-owner")]
        [Implements(implementation: "IProperty.AssociationEnd")]
        public IProperty AssociationEnd { get; set; }

        /// <summary>
        /// The Class that owns this Property, if any.
        /// </summary>
        [Property(xmiId: "Property-class", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_attribute_classifier-classifier")]
        [SubsettedProperty(propertyName: "A_ownedAttribute_structuredClassifier-structuredClassifier")]
        [SubsettedProperty(propertyName: "NamedElement-namespace")]
        [Implements(implementation: "IProperty.Class")]
        public IClass Class { get; set; }

        /// <summary>
        /// Indicates the Dependencies that reference this NamedElement as a client.
        /// </summary>
        [Property(xmiId: "NamedElement-clientDependency", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_source_directedRelationship-directedRelationship")]
        [Implements(implementation: "INamedElement.ClientDependency")]
        public List<IDependency> ClientDependency => this.QueryClientDependency();

        /// <summary>
        /// The DataType that owns this Property, if any.
        /// </summary>
        [Property(xmiId: "Property-datatype", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_attribute_classifier-classifier")]
        [SubsettedProperty(propertyName: "NamedElement-namespace")]
        [Implements(implementation: "IProperty.Datatype")]
        public IDataType Datatype { get; set; }

        /// <summary>
        /// A ValueSpecification that is evaluated to give a default value for the Property when an instance of
        /// the owning Classifier is instantiated.
        /// </summary>
        [Property(xmiId: "Property-defaultValue", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "IProperty.DefaultValue")]
        public IContainerList<IValueSpecification> DefaultValue
        {
            get => this.defaultValue ??= new ContainerList<IValueSpecification>(this);
            set => this.defaultValue = value;
        }

        /// <summary>
        /// Backing field for <see cref="DefaultValue"/>
        /// </summary>
        private IContainerList<IValueSpecification> defaultValue;

        /// <summary>
        /// The set of elements that are manifested in an Artifact that is involved in Deployment to a
        /// DeploymentTarget.
        /// </summary>
        [Property(xmiId: "DeploymentTarget-deployedElement", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IDeploymentTarget.DeployedElement")]
        public List<IPackageableElement> DeployedElement => this.QueryDeployedElement();

        /// <summary>
        /// The set of Deployments for a DeploymentTarget.
        /// </summary>
        [Property(xmiId: "DeploymentTarget-deployment", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [SubsettedProperty(propertyName: "NamedElement-clientDependency")]
        [Implements(implementation: "IDeploymentTarget.Deployment")]
        public IContainerList<IDeployment> Deployment
        {
            get => this.deployment ??= new ContainerList<IDeployment>(this);
            set => this.deployment = value;
        }

        /// <summary>
        /// Backing field for <see cref="Deployment"/>
        /// </summary>
        private IContainerList<IDeployment> deployment;

        /// <summary>
        /// A set of ConnectorEnds that attach to this ConnectableElement.
        /// </summary>
        [Property(xmiId: "ConnectableElement-end", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IConnectableElement.End")]
        public List<IConnectorEnd> End => this.QueryEnd();

        /// <summary>
        /// The Classifiers that have this Feature as a feature.
        /// </summary>
        [Property(xmiId: "Feature-featuringClassifier", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_member_memberNamespace-memberNamespace")]
        [Implements(implementation: "IFeature.FeaturingClassifier")]
        public IClassifier FeaturingClassifier => this.QueryFeaturingClassifier();

        /// <summary>
        /// The Interface that owns this Property, if any.
        /// </summary>
        [Property(xmiId: "Property-interface", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_attribute_classifier-classifier")]
        [SubsettedProperty(propertyName: "NamedElement-namespace")]
        [Implements(implementation: "IProperty.Interface")]
        public IInterface Interface { get; set; }

        /// <summary>
        /// If isComposite is true, the object containing the attribute is a container for the object or value
        /// contained in the attribute. This is a derived value, indicating whether the aggregation of the
        /// Property is composite or not.
        /// </summary>
        [Property(xmiId: "Property-isComposite", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: "false")]
        [Implements(implementation: "IProperty.IsComposite")]
        public bool IsComposite => this.QueryIsComposite();

        /// <summary>
        /// Specifies whether the Property is derived, i.e., whether its value or values can be computed from
        /// other information.
        /// </summary>
        [Property(xmiId: "Property-isDerived", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "false")]
        [Implements(implementation: "IProperty.IsDerived")]
        public bool IsDerived { get; set; }

        /// <summary>
        /// Specifies whether the property is derived as the union of all of the Properties that are constrained
        /// to subset it.
        /// </summary>
        [Property(xmiId: "Property-isDerivedUnion", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "false")]
        [Implements(implementation: "IProperty.IsDerivedUnion")]
        public bool IsDerivedUnion { get; set; }

        /// <summary>
        /// True indicates this property can be used to uniquely identify an instance of the containing Class.
        /// </summary>
        [Property(xmiId: "Property-isID", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "false")]
        [Implements(implementation: "IProperty.IsID")]
        public bool IsID { get; set; }

        /// <summary>
        /// Indicates whether it is possible to further redefine a RedefinableElement. If the value is true,
        /// then it is not possible to further redefine the RedefinableElement.
        /// </summary>
        [Property(xmiId: "RedefinableElement-isLeaf", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "false")]
        [Implements(implementation: "IRedefinableElement.IsLeaf")]
        public bool IsLeaf { get; set; }

        /// <summary>
        /// For a multivalued multiplicity, this attribute specifies whether the values in an instantiation of
        /// this MultiplicityElement are sequentially ordered.
        /// </summary>
        [Property(xmiId: "MultiplicityElement-isOrdered", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "false")]
        [Implements(implementation: "IMultiplicityElement.IsOrdered")]
        public bool IsOrdered { get; set; }

        /// <summary>
        /// If isReadOnly is true, the StructuralFeature may not be written to after initialization.
        /// </summary>
        [Property(xmiId: "StructuralFeature-isReadOnly", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "false")]
        [Implements(implementation: "IStructuralFeature.IsReadOnly")]
        public bool IsReadOnly { get; set; }

        /// <summary>
        /// Specifies whether this Feature characterizes individual instances classified by the Classifier
        /// (false) or the Classifier itself (true).
        /// </summary>
        [Property(xmiId: "Feature-isStatic", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "false")]
        [Implements(implementation: "IFeature.IsStatic")]
        public bool IsStatic { get; set; }

        /// <summary>
        /// For a multivalued multiplicity, this attributes specifies whether the values in an instantiation of
        /// this MultiplicityElement are unique.
        /// </summary>
        [Property(xmiId: "MultiplicityElement-isUnique", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "true")]
        [Implements(implementation: "IMultiplicityElement.IsUnique")]
        public bool IsUnique { get; set; }

        /// <summary>
        /// The lower bound of the multiplicity interval.
        /// </summary>
        [Property(xmiId: "MultiplicityElement-lower", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IMultiplicityElement.Lower")]
        public int Lower => this.QueryLower();

        /// <summary>
        /// The specification of the lower bound for this multiplicity.
        /// </summary>
        [Property(xmiId: "MultiplicityElement-lowerValue", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "IMultiplicityElement.LowerValue")]
        public IContainerList<IValueSpecification> LowerValue
        {
            get => this.lowerValue ??= new ContainerList<IValueSpecification>(this);
            set => this.lowerValue = value;
        }

        /// <summary>
        /// Backing field for <see cref="LowerValue"/>
        /// </summary>
        private IContainerList<IValueSpecification> lowerValue;

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
        /// In the case where the Property is one end of a binary association this gives the other end.
        /// </summary>
        [Property(xmiId: "Property-opposite", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IProperty.Opposite")]
        public IProperty Opposite => this.QueryOpposite();

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
        /// The Element that owns this Element.
        /// </summary>
        [Property(xmiId: "Element-owner", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IElement.Owner")]
        public IElement Owner => this.QueryOwner();

        /// <summary>
        /// The owning association of this property, if any.
        /// </summary>
        [Property(xmiId: "Property-owningAssociation", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Feature-featuringClassifier")]
        [SubsettedProperty(propertyName: "NamedElement-namespace")]
        [SubsettedProperty(propertyName: "Property-association")]
        [SubsettedProperty(propertyName: "RedefinableElement-redefinitionContext")]
        [Implements(implementation: "IProperty.OwningAssociation")]
        public IAssociation OwningAssociation { get; set; }

        /// <summary>
        /// The formal TemplateParameter that owns this ParameterableElement.
        /// </summary>
        [Property(xmiId: "ParameterableElement-owningTemplateParameter", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-owner")]
        [SubsettedProperty(propertyName: "ParameterableElement-templateParameter")]
        [Implements(implementation: "IParameterableElement.OwningTemplateParameter")]
        public ITemplateParameter OwningTemplateParameter { get; set; }

        /// <summary>
        /// A name that allows the NamedElement to be identified within a hierarchy of nested Namespaces. It is
        /// constructed from the names of the containing Namespaces starting at the root of the hierarchy and
        /// ending with the name of the NamedElement itself.
        /// </summary>
        [Property(xmiId: "NamedElement-qualifiedName", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "INamedElement.QualifiedName")]
        public string QualifiedName => this.QueryQualifiedName();

        /// <summary>
        /// An optional list of ordered qualifier attributes for the end.
        /// </summary>
        [Property(xmiId: "Property-qualifier", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "IProperty.Qualifier")]
        public IContainerList<IProperty> Qualifier
        {
            get => this.qualifier ??= new ContainerList<IProperty>(this);
            set => this.qualifier = value;
        }

        /// <summary>
        /// Backing field for <see cref="Qualifier"/>
        /// </summary>
        private IContainerList<IProperty> qualifier;

        /// <summary>
        /// The RedefinableElement that is being redefined by this element.
        /// </summary>
        [Property(xmiId: "RedefinableElement-redefinedElement", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IRedefinableElement.RedefinedElement")]
        public List<IRedefinableElement> RedefinedElement => this.QueryRedefinedElement();

        /// <summary>
        /// The properties that are redefined by this property, if any.
        /// </summary>
        [Property(xmiId: "Property-redefinedProperty", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "RedefinableElement-redefinedElement")]
        [Implements(implementation: "IProperty.RedefinedProperty")]
        public List<IProperty> RedefinedProperty { get; set; } = new();

        /// <summary>
        /// The contexts that this element may be redefined from.
        /// </summary>
        [Property(xmiId: "RedefinableElement-redefinitionContext", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IRedefinableElement.RedefinitionContext")]
        public List<IClassifier> RedefinitionContext => this.QueryRedefinitionContext();

        /// <summary>
        /// The properties of which this Property is constrained to be a subset, if any.
        /// </summary>
        [Property(xmiId: "Property-subsettedProperty", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IProperty.SubsettedProperty")]
        public List<IProperty> SubsettedProperty { get; set; } = new();

        /// <summary>
        /// The ConnectableElementTemplateParameter for this ConnectableElement parameter.
        /// </summary>
        [Property(xmiId: "ConnectableElement-templateParameter", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [RedefinedProperty(propertyName: "ParameterableElement-templateParameter")]
        [Implements(implementation: "IConnectableElement.TemplateParameter")]
        public IConnectableElementTemplateParameter TemplateParameter { get; set; }

        /// <summary>
        /// The TemplateParameter that exposes this ParameterableElement as a formal parameter.
        /// </summary>
        [Property(xmiId: "ParameterableElement-templateParameter", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [RedefinedByProperty("IConnectableElement.TemplateParameter")]
        [Implements(implementation: "IParameterableElement.TemplateParameter")]
        ITemplateParameter IParameterableElement.TemplateParameter
        {
            get => throw new InvalidOperationException("Redefined by property IConnectableElement.TemplateParameter");
            set => throw new InvalidOperationException("Redefined by property IConnectableElement.TemplateParameter");
        }

        /// <summary>
        /// The type of the TypedElement.
        /// </summary>
        [Property(xmiId: "TypedElement-type", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "ITypedElement.Type")]
        public IType Type { get; set; }

        /// <summary>
        /// The upper bound of the multiplicity interval.
        /// </summary>
        [Property(xmiId: "MultiplicityElement-upper", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IMultiplicityElement.Upper")]
        public string Upper => this.QueryUpper();

        /// <summary>
        /// The specification of the upper bound for this multiplicity.
        /// </summary>
        [Property(xmiId: "MultiplicityElement-upperValue", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "IMultiplicityElement.UpperValue")]
        public IContainerList<IValueSpecification> UpperValue
        {
            get => this.upperValue ??= new ContainerList<IValueSpecification>(this);
            set => this.upperValue = value;
        }

        /// <summary>
        /// Backing field for <see cref="UpperValue"/>
        /// </summary>
        private IContainerList<IValueSpecification> upperValue;

        /// <summary>
        /// Determines whether and how the NamedElement is visible outside its owning Namespace.
        /// </summary>
        [Property(xmiId: "NamedElement-visibility", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "INamedElement.Visibility")]
        public VisibilityKind Visibility { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
