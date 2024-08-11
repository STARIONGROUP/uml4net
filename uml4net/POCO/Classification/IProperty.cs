// -------------------------------------------------------------------------------------------------
// <copyright file="IProperty.cs" company="Starion Group S.A.">
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
    using uml4net.POCO.Deployments;
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
    public interface IProperty : IConnectableElement, IDeploymentTarget, IStructuralFeature
    {
        /// <summary>
        /// Specifies the kind of aggregation that applies to the Property.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, defaultValue: "AggregationKind.None")]
        public AggregationKind Aggregation { get; set; }

        /// <summary>
        /// The Association of which this Property is a member, if any.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [SubsettedProperty("A_member_memberNamespace-memberNamespace")]
        public IAssociation Association { get; set; }

        /// <summary>
        /// Designates the optional association end that owns a qualifier attribute.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [SubsettedProperty("Element-owner")]
        public IProperty AssociationEnd { get; set; }

        /// <summary>
        /// The Class that owns this Property, if any.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [SubsettedProperty("A_attribute_classifier-classifier")]
        [SubsettedProperty("A_ownedAttribute_structuredClassifier-structuredClassifier")]
        [SubsettedProperty("NamedElement-namespace")]
        public IClass Class { get; set; }

        /// <summary>
        /// The DataType that owns this Property, if any.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [SubsettedProperty("A_attribute_classifier-classifier")]
        [SubsettedProperty("NamedElement-namespace")]
        public IDataType DataType { get; set; }

        /// <summary>
        /// A ValueSpecification that is evaluated to give a default value for the Property 
        /// when an instance of the owning Classifier is instantiated.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1)]
        [SubsettedProperty("Element-ownedElement")]
        public IValueSpecification Default { get; set; }

        /// <summary>
        /// If isComposite is true, the object containing the attribute is a container for the 
        /// object or value contained in the attribute. This is a derived value, indicating 
        /// whether the aggregation of the Property is composite or not.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isDerived:true, defaultValue: "false")]
        public bool IsComposite { get; }

        /// <summary>
        /// Specifies whether the Property is derived, i.e., whether its value or values can be computed from other information.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, defaultValue: "false")]
        public bool IsDerived { get; set; }

        /// <summary>
        /// Specifies whether the property is derived as the union of all of the Properties that are constrained to subset it.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, defaultValue: "false")]
        public bool IsDerivedUnion { get; set; }

        /// <summary>
        /// True indicates this property can be used to uniquely identify an instance of the containing Class.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, defaultValue: "false")]
        public bool IsID { get; set; }

        /// <summary>
        /// In the case where the Property is one end of a binary association this gives the other end.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        public IProperty Opposite { get; }

        /// <summary>
        /// The owning association of this property, if any.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [SubsettedProperty("Feature-featuringClassifier")]
        [SubsettedProperty("NamedElement-namespace")]
        [SubsettedProperty("Property-association")]
        [SubsettedProperty("RedefinableElement-redefinitionContext")]
        public IAssociation OwningAssociation { get; set; }

        /// <summary>
        /// An optional list of ordered qualifier attributes for the end.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty("Element-ownedElement")]
        public List<IProperty> Qualifier { get; set; }

        /// <summary>
        /// The properties that are redefined by this property, if any.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty("RedefinableElement-redefinedElement")]
        public List<IProperty> RedefinedProperty { get; set; }

        /// <summary>
        /// The properties of which this Property is constrained to be a subset, if any.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue)]
        public List<IProperty> SubsettedProperty { get; set; }
    }
}
