// -------------------------------------------------------------------------------------------------
// <copyright file="PropertyAttribute.cs" company="RHEA System S.A.">
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

namespace Uml.Attributes
{
    using System;
    using Uml.Classification;

    /// <summary>
    /// The <see cref="PropertyAttribute"/> is used to decorate properties and methods of interfaces and classes to make Uml properties explicit
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Property | System.AttributeTargets.Method, AllowMultiple = false)]
    public class PropertyAttribute : Attribute
    {
        /// <summary>
        /// Specifies whether the Property is derived, i.e., whether its value or values can be computed from other information
        /// </summary>
        public bool IsDerived { get; set; }

        /// <summary>
        /// Specifies whether the property is derived as the union of all of the Properties that are constrained to subset it.
        /// </summary>
        public bool IsDerivedUnion { get; set; }
        
        /// <summary>
        /// If isReadOnly is true, the StructuralFeature may not be written to after initialization.
        /// </summary>
        public bool IsReadOnly { get; set; }

        /// <summary>
        /// Specifies whether this Feature characterizes individual instances classified by the Classifier (false) or the Classifier itself (true).
        /// </summary>
        public bool IsStatic { get; set; }
        
        /// <summary>
        /// The properties that are redefined by this property, if any.
        /// </summary>
        public string RedefinedProperty { get; set; }

        /// <summary>
        /// The properties of which this Property is constrained to be a subset, if any.
        /// </summary>
        public string SubsettedProperty { get; set; }

        /// <summary>
        /// Specifies the kind of aggregation that applies to the Property.
        /// </summary>
        public AggregationKind Aggregation { get; set; }
    }
}