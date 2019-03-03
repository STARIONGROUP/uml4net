// -------------------------------------------------------------------------------------------------
// <copyright file="TimeExpression.cs" company="RHEA System S.A.">
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
    using Uml.Assembler;

    /// <summary>
    /// A <see cref="TimeExpression"/> is a <see cref="ValueSpecification"/> that represents a time value.
    /// </summary>
    public interface TimeExpression : ValueSpecification
    {
        /// <summary>
        /// /// A <see cref="ValueSpecification"/> that evaluates to the value of the <see cref="TimeExpression"/>.
        /// </summary>
        OwnerList<ValueSpecification> Expr { get; set; }

        /// <summary>
        /// Refers to the <see cref="Observation"/>s that are involved in the computation of the <see cref="TimeExpression"/> value.
        /// </summary>
        List<Observation> Observation { get; set; }
    }
}