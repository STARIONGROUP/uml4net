// -------------------------------------------------------------------------------------------------
// <copyright file="OpaqueExpression.cs" company="RHEA System S.A.">
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

namespace Uml.Values
{
    using System.Collections.Generic;
    using Uml.Attributes;
    using Uml.Classification;
    using Uml.CommonBehavior;

    /// <summary>
    /// An <see cref="OpaqueExpression"/> is a <see cref="ValueSpecification"/> that specifies the computation of a collection of values either in terms of a UML <see cref="Behavior"/> or based on a textual statement in a language other than UML
    /// </summary>
    [Class(IsAbstract = false, IsActive = false, Specializations = "")]
    public interface OpaqueExpression : ValueSpecification
    {
        /// <summary>
        /// Specifies the behavior of the <see cref="OpaqueExpression"/> as a UML Behavior.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        Behavior Behavior { get; set; }

        /// <summary>
        /// A textual definition of the behavior of the <see cref="OpaqueExpression"/>, possibly in multiple languages.
        /// </summary>
        [MultiplicityElement(IsOrdered = true, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        List<string> Body { get; set; }

        /// <summary>
        /// Specifies the languages used to express the textual bodies of the <see cref="OpaqueExpression"/>. Languages are matched to body Strings by order. The interpretation of the body depends on the languages. If the languages are unspecified, they may be implicit from the expression body or the context.
        /// </summary>
        [MultiplicityElement(IsOrdered = true, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        List<string> Language { get; set; }
        
        /// <summary>
        /// If an <see cref="OpaqueExpression is"/> specified using a UML Behavior, then this refers to the single required return <see cref="Parameter"/> of that <see cref="Behavior"/>. When the <see cref="Behavior"/> completes execution, the values on this <see cref="Parameter"/> give the result of evaluating the <see cref="OpaqueExpression"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "1")]
        [Property(IsDerived = true, IsDerivedUnion = false, IsReadOnly = true, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        Parameter Result { get; }
    }
}