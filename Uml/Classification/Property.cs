// -------------------------------------------------------------------------------------------------
// <copyright file="Property.cs" company="RHEA System S.A.">
//   Copyright (c) 2018-2019 RHEA System S.A.
//
//   This file is part of uml-sharp
//
//   uml-sharp is free software: you can redistribute it and/or modify
//   it under the terms of the GNU General Public License as published by
//   the Free Software Foundation, either version 3 of the License, or
//   (at your option) any later version.
//   
//   uml-sharp is distributed in the hope that it will be useful,
//   but WITHOUT ANY WARRANTY; without even the implied warranty of
//   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//   GNU General Public License for more details.
//
//   You should have received a copy of the GNU General Public License
//   along with uml-sharp. If not, see<http://www.gnu.org/licenses/>.
// </copyright>
// -------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using Uml.Assembler;
using Uml.Values;

namespace Uml.Classification
{
    using Uml.Deployments;
    using Uml.SimpleClassifiers;
    using Uml.StructuredClassifiers;

    /// <summary>
    /// A Property is a StructuralFeature. A Property related by ownedAttribute to a Classifier (other than an association) represents an attribute and might also represent an association end. It relates an instance of the Classifier to a value or set of values of the type of the attribute. A Property related by memberEnd to an Association represents an end of the Association. The type of the Property is the type of the end of the Association. A Property has the capability of being a DeploymentTarget in a Deployment relationship. This enables modeling the deployment to hierarchical nodes that have Properties functioning as internal parts.  Property specializes ParameterableElement to specify that a Property can be exposed as a formal template parameter, and provided as an actual parameter in a binding of a template.
    /// </summary>
    public interface Property : ConnectableElement, DeploymentTarget, StructuralFeature
    {
        /// <summary>
        /// Specifies the kind of aggregation that applies to the Property.
        /// </summary>
        AggregationKind Aggregation { get; set; }

        /// <summary>
        /// The Association of which this Property is a member, if any.
        /// </summary>
        Association Association { get; set; }

        /// <summary>
        /// Designates the optional association end that owns a qualifier attribute.
        /// </summary>
        Property AssociationEnd { get; set; }

        /// <summary>
        /// The Class that owns this Property, if any.
        /// </summary>
        Class Class { get; set; }

        /// <summary>
        /// The <see cref="DataType"/> that owns this <see cref="Property"/>, if any.
        /// </summary>
        DataType DataType { get; set; } 

        /// <summary>
        /// A ValueSpecification that is evaluated to give a default value for the Property when an instance of the owning Classifier is instantiated.
        /// </summary>
        OwnerList<ValueSpecification> DefaultValue { get; set; }

        /// <summary>
        /// The Interface that owns this Property, if any.
        /// </summary>
        Interface Interface { get; set; }

        /// <summary>
        /// If isComposite is true, the object containing the attribute is a container for the object or value contained in the attribute. This is a derived value, indicating whether the aggregation of the Property is composite or not.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        bool IsComposite { get; }

        /// <summary>
        /// Specifies whether the Property is derived, i.e., whether its value or values can be computed from other information.
        /// </summary>
        bool IsDerived { get; set; }

        /// <summary>
        /// Specifies whether the property is derived as the union of all of the Properties that are constrained to subset it.
        /// </summary>
        bool IsDerivedUnion { get; set; }

        /// <summary>
        /// True indicates this property can be used to uniquely identify an instance of the containing Class.
        /// </summary>
        bool IsID { get; set; }

        /// <summary>
        /// In the case where the Property is one end of a binary association this gives the other end.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        Property Opposite { get; }

        /// <summary>
        /// The owning association of this property, if any.
        /// </summary>
        Association OwningAssociation { get; set; }

        /// <summary>
        /// An optional list of ordered qualifier attributes for the end.
        /// </summary>
        OwnerList<Property> Qualifier { get; set; }

        /// <summary>
        /// The properties that are redefined by this property, if any.
        /// </summary>
        List<Property> RedefinedProperty { get; set; }

        /// <summary>
        /// The properties of which this Property is constrained to be a subset, if any.
        /// </summary>
        List<Property> SubsettedProperty { get; set; }
    }
}