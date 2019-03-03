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
    using Uml.Classification;
    using Uml.CommonBehavior;

    /// <summary>
    /// An OpaqueExpression is a ValueSpecification that specifies the computation of a collection of values either in terms of a UML Behavior or based on a textual statement in a language other than UML
    /// </summary>
    public interface OpaqueExpression : ValueSpecification
    {
        /// <summary>
        /// Specifies the behavior of the OpaqueExpression as a UML Behavior.
        /// </summary>
        Behavior Behavior { get; set; }

        /// <summary>
        /// A textual definition of the behavior of the OpaqueExpression, possibly in multiple languages.
        /// </summary>
        List<string> Body { get; set; }

        /// <summary>
        /// Specifies the languages used to express the textual bodies of the OpaqueExpression.  Languages are matched to body Strings by order. The interpretation of the body depends on the languages. If the languages are unspecified, they may be implicit from the expression body or the context.
        /// </summary>
        List<string> Language { get; set; }
        
        /// <summary>
        /// If an OpaqueExpression is specified using a UML Behavior, then this refers to the single required return Parameter of that Behavior. When the Behavior completes execution, the values on this Parameter give the result of evaluating the OpaqueExpression.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        Parameter Result { get; }
    }
}