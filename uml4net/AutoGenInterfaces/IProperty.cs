// -------------------------------------------------------------------------------------------------
// <copyright file="IProperty.cs" company="Starion Group S.A.">
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
    public partial interface IProperty : IConnectableElement, IDeploymentTarget, IStructuralFeature
    {
        /// <summary>
        /// Specifies the kind of aggregation that applies to the Property.
        /// </summary>
        [Property(xmiId: "Property-aggregation", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "none")]
        public AggregationKind Aggregation { get; set; }

        /// <summary>
        /// The Association of which this Property is a member, if any.
        /// </summary>
        [Property(xmiId: "Property-association", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_member_memberNamespace-memberNamespace")]
        public IAssociation Association { get; set; }

        /// <summary>
        /// Designates the optional association end that owns a qualifier attribute.
        /// </summary>
        [Property(xmiId: "Property-associationEnd", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-owner")]
        public IProperty AssociationEnd { get; set; }

        /// <summary>
        /// The Class that owns this Property, if any.
        /// </summary>
        [Property(xmiId: "Property-class", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_attribute_classifier-classifier")]
        [SubsettedProperty(propertyName: "A_ownedAttribute_structuredClassifier-structuredClassifier")]
        [SubsettedProperty(propertyName: "NamedElement-namespace")]
        public IClass Class { get; set; }

        /// <summary>
        /// The DataType that owns this Property, if any.
        /// </summary>
        [Property(xmiId: "Property-datatype", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_attribute_classifier-classifier")]
        [SubsettedProperty(propertyName: "NamedElement-namespace")]
        public IDataType Datatype { get; set; }

        /// <summary>
        /// A ValueSpecification that is evaluated to give a default value for the Property when an instance of
        /// the owning Classifier is instantiated.
        /// </summary>
        [Property(xmiId: "Property-defaultValue", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IValueSpecification> DefaultValue { get; set; }

        /// <summary>
        /// The Interface that owns this Property, if any.
        /// </summary>
        [Property(xmiId: "Property-interface", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_attribute_classifier-classifier")]
        [SubsettedProperty(propertyName: "NamedElement-namespace")]
        public IInterface Interface { get; set; }

        /// <summary>
        /// If isComposite is true, the object containing the attribute is a container for the object or value
        /// contained in the attribute. This is a derived value, indicating whether the aggregation of the
        /// Property is composite or not.
        /// </summary>
        [Property(xmiId: "Property-isComposite", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: "false")]
        public bool IsComposite { get; }

        /// <summary>
        /// Specifies whether the Property is derived, i.e., whether its value or values can be computed from
        /// other information.
        /// </summary>
        [Property(xmiId: "Property-isDerived", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "false")]
        public bool IsDerived { get; set; }

        /// <summary>
        /// Specifies whether the property is derived as the union of all of the Properties that are constrained
        /// to subset it.
        /// </summary>
        [Property(xmiId: "Property-isDerivedUnion", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "false")]
        public bool IsDerivedUnion { get; set; }

        /// <summary>
        /// True indicates this property can be used to uniquely identify an instance of the containing Class.
        /// </summary>
        [Property(xmiId: "Property-isID", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "false")]
        public bool IsID { get; set; }

        /// <summary>
        /// In the case where the Property is one end of a binary association this gives the other end.
        /// </summary>
        [Property(xmiId: "Property-opposite", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public IProperty Opposite { get; }

        /// <summary>
        /// The owning association of this property, if any.
        /// </summary>
        [Property(xmiId: "Property-owningAssociation", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Feature-featuringClassifier")]
        [SubsettedProperty(propertyName: "NamedElement-namespace")]
        [SubsettedProperty(propertyName: "Property-association")]
        [SubsettedProperty(propertyName: "RedefinableElement-redefinitionContext")]
        public IAssociation OwningAssociation { get; set; }

        /// <summary>
        /// An optional list of ordered qualifier attributes for the end.
        /// </summary>
        [Property(xmiId: "Property-qualifier", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IProperty> Qualifier { get; set; }

        /// <summary>
        /// The properties that are redefined by this property, if any.
        /// </summary>
        [Property(xmiId: "Property-redefinedProperty", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "RedefinableElement-redefinedElement")]
        public List<IProperty> RedefinedProperty { get; set; }

        /// <summary>
        /// The properties of which this Property is constrained to be a subset, if any.
        /// </summary>
        [Property(xmiId: "Property-subsettedProperty", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public List<IProperty> SubsettedProperty { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
