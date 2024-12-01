// -------------------------------------------------------------------------------------------------
// <copyright file="Property.cs" company="Starion Group S.A.">
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
    using uml4net.Extend;
    using uml4net.Utils;
    using uml4net.POCO.CommonStructure;
    using uml4net.POCO.SimpleClassifiers;
    using uml4net.POCO.StructuredClassifiers;
    using uml4net.POCO.Values;

    /// <summary>
    /// A Property is a StructuralFeature. A Property related by ownedAttribute to a Classifier 
    /// (other than an association) represents an attribute and might also represent an association end.
    /// It relates an instance of the Classifier to a value or set of values of the type of the attribute. 
    /// A Property related by memberEnd to an Association represents an end of the Association. The type 
    /// of the Property is the type of the end of the Association. A Property has the capability of being
    /// a DeploymentTarget in a Deployment relationship. This enables modeling the deployment to hierarchical 
    /// nodes that have Properties functioning as internal parts.  Property specializes ParameterableElement 
    /// to specify that a Property can be exposed as a formal template parameter, and provided as an actual 
    /// parameter in a binding of a template.
    /// </summary>
    public class Property : XmiElement, IProperty
    {
        /// <summary>
        /// The Comments owned by this Element.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
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
        public IElement Owner => this.QueryOwner();

        /// <summary>
        /// Gets or sets the container of this <see cref="IElement"/>
        /// </summary>
        public IElement Possessor { get; set; }

        /// <summary>
        /// For a multivalued multiplicity, this attribute specifies whether the values in an instantiation
        /// of this MultiplicityElement are sequentially ordered.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1)]
        [Implements(implementation: "IMultiplicityElement.IsOrdered")]
        public bool IsOrdered { get; set; }

        /// <summary>
        /// For a multivalued multiplicity, this attributes specifies whether the values in an instantiation
        /// of this MultiplicityElement are unique.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1)]
        [Implements(implementation: "IMultiplicityElement.IsUnique")]
        public bool IsUnique { get; set; }

        /// <summary>
        /// The lower bound of the multiplicity interval.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isDerived: true)]
        [Implements(implementation: "IMultiplicityElement.Lower")]
        public int Lower => this.QueryLower();

        /// <summary>
        /// The specification of the lower bound for this multiplicity.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isDerived: true)]
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
        /// The upper bound of the multiplicity interval.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isDerived: true)]
        [Implements(implementation: "IMultiplicityElement.Upper")]
        public int Upper => this.QueryUpper();

        /// <summary>
        /// The specification of the upper bound for this multiplicity.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isDerived: true)]
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
        /// Indicates the Dependencies that reference this NamedElement as a client."
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isDerived: true)]
        [SubsettedProperty(propertyName: "A_source_directedRelationship.DirectedRelationship")]
        [Implements(implementation: "INamedElement.ClientDependency")]
        public List<IDependency> ClientDependency => throw new NotImplementedException();

        /// <summary>
        /// The name of the NamedElement.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [Implements(implementation: "INamedElement.Name")]
        public string Name { get; set; }

        /// <summary>
        /// The StringExpression used to define the name of this NamedElement.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1)]
        [SubsettedProperty(propertyName: "Element.OwnedElement")]
        [Implements(implementation: "INamedElement.NameExpression")]
        public IStringExpression NameExpression { get; set; }

        /// <summary>
        /// Specifies the Namespace that owns the NamedElement.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [SubsettedProperty(propertyName: "A_member_memberNamespace.MemberNamespace")]
        [SubsettedProperty(propertyName: "Element.Owner")]
        [Implements(implementation: "INamedElement.Namespace")]
        public INamespace Namespace => this.QueryNamespace();

        /// <summary>
        /// A name that allows the NamedElement to be identified within a hierarchy of nested Namespaces. It is constructed from the names of 
        /// the containing Namespaces starting at the root of the hierarchy and ending with the name of the NamedElement itself.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isReadOnly: true, isDerived: true)]
        [Implements(implementation: "INamedElement.QualifiedName")]
        public string QualifiedName => this.QueryQualifiedName();

        /// <summary>
        /// Determines whether and how the NamedElement is visible outside its owning Namespace.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [Implements(implementation: "INamedElement.Visibility")]
        public VisibilityKind Visibility { get; set; }

        /// <summary>
        /// The formal TemplateParameter that owns this ParameterableElement
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [Implements(implementation: "IParameterableElement.OwningTemplateParameter")]
        [SubsettedProperty(propertyName: "Element.Owner")]
        [SubsettedProperty(propertyName: "ParameterableElement.TemplateParameter")]
        public ITemplateParameter OwningTemplateParameter { get; set; }

        /// <summary>
        /// ParameterableElement-templateParameter-_ownedComment.0" body="The TemplateParameter that exposes this 
        /// ParameterableElement as a formal parameter.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [Implements(implementation: "IParameterableElement.TemplateParameter")]
        public ITemplateParameter TemplateParameter { get; set; }

        /// <summary>
        /// The type of the TypedElement.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [Implements(implementation: "ITypedElement.Type")]
        public IType Type { get; set; }

        /// <summary>
        /// The Classifiers that have this Feature as a feature.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [Implements(implementation: "IFeature.FeaturingClassifier")]
        public IClassifier FeaturingClassifier => throw new NotImplementedException();

        /// <summary>
        /// Specifies whether this Feature characterizes individual instances classified by the Classifier (false)
        /// or the Classifier itself (true).
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, defaultValue: "false")]
        [Implements(implementation: "IFeature.IsStatic")]
        public bool IsStatic { get; set; } = false;

        /// <summary>
        /// Specifies the kind of aggregation that applies to the Property.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, defaultValue: "AggregationKind.None")]
        [Implements(implementation: "IProperty.Aggregation")]
        public AggregationKind Aggregation { get; set; } = AggregationKind.None;

        /// <summary>
        /// The Association of which this Property is a member, if any.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [SubsettedProperty("A_member_memberNamespace-memberNamespace")]
        [Implements(implementation: "IProperty.Association")]
        public IAssociation Association { get; set; }

        /// <summary>
        /// Designates the optional association end that owns a qualifier attribute.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [SubsettedProperty("Element-owner")]
        [Implements(implementation: "IProperty.AssociationEnd")]
        public IProperty AssociationEnd { get; set; }

        /// <summary>
        /// The Class that owns this Property, if any.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [SubsettedProperty("A_attribute_classifier-classifier")]
        [SubsettedProperty("A_ownedAttribute_structuredClassifier-structuredClassifier")]
        [SubsettedProperty("NamedElement-namespace")]
        [Implements(implementation: "IProperty.Class")]
        public IClass Class { get; set; }

        /// <summary>
        /// The DataType that owns this Property, if any.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [SubsettedProperty("A_attribute_classifier-classifier")]
        [SubsettedProperty("NamedElement-namespace")]
        [Implements(implementation: "IProperty.DataType")]
        public IDataType DataType { get; set; }

        /// <summary>
        /// A ValueSpecification that is evaluated to give a default value for the Property 
        /// when an instance of the owning Classifier is instantiated.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1)]
        [SubsettedProperty("Element-ownedElement")]
        [Implements(implementation: "IProperty.DefaultValue")]
        public IValueSpecification DefaultValue { get; set; }

        /// <summary>
        /// If isComposite is true, the object containing the attribute is a container for the 
        /// object or value contained in the attribute. This is a derived value, indicating 
        /// whether the aggregation of the Property is composite or not.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isDerived: true, defaultValue: "false")]
        [Implements(implementation: "IProperty.IsComposite")]
        public bool IsComposite => throw new NotImplementedException();

        /// <summary>
        /// Specifies whether the Property is derived, i.e., whether its value or values can be computed from other information.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, defaultValue: "false")]
        [Implements(implementation: "IProperty.IsDerived")]
        public bool IsDerived { get; set; } = false;

        /// <summary>
        /// Specifies whether the property is derived as the union of all of the Properties that are constrained to subset it.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, defaultValue: "false")]
        [Implements(implementation: "IProperty.IsDerivedUnion")]
        public bool IsDerivedUnion { get; set; } = false;

        /// <summary>
        /// True indicates this property can be used to uniquely identify an instance of the containing Class.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, defaultValue: "false")]
        [Implements(implementation: "IProperty.IsID")]
        public bool IsID { get; set; } = false;

        /// <summary>
        /// In the case where the Property is one end of a binary association this gives the other end.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [Implements(implementation: "IProperty.Opposite")]
        public IProperty Opposite { get; }

        /// <summary>
        /// The owning association of this property, if any.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [SubsettedProperty("Feature-featuringClassifier")]
        [SubsettedProperty("NamedElement-namespace")]
        [SubsettedProperty("Property-association")]
        [SubsettedProperty("RedefinableElement-redefinitionContext")]
        [Implements(implementation: "IProperty.OwningAssociation")]
        public IAssociation OwningAssociation { get; set; }

        /// <summary>
        /// An optional list of ordered qualifier attributes for the end.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty("Element-ownedElement")]
        [Implements(implementation: "IProperty.Qualifier")]
        public List<IProperty> Qualifier { get; set; }

        /// <summary>
        /// The properties that are redefined by this property, if any.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty("RedefinableElement-redefinedElement")]
        [Implements(implementation: "IProperty.RedefinedProperty")]
        public List<IProperty> RedefinedProperty { get; set; } = new ();

        /// <summary>
        /// The properties of which this Property is constrained to be a subset, if any.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue)]
        [Implements(implementation: "IProperty.SubsettedProperty")]
        public List<IProperty> SubsettedProperty { get; set; } = new ();

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
        /// If isReadOnly is true, the StructuralFeature may not be written to after initialization.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, defaultValue: "false")]
        [Implements(implementation: "IStructuralFeature.IsReadOnly")]
        public bool IsReadOnly { get; set; } = false;
    }
}
