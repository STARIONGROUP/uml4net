// -------------------------------------------------------------------------------------------------
// <copyright file="TimeConstraint.cs" company="RHEA System S.A.">
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
    using Uml.Assembler;

    /// <summary>
    /// A <see cref="TimeConstraint"/> is a <see cref="Constraint"/> that refers to a <see cref="TimeInterval"/>.
    /// </summary>
    public interface TimeConstraint : IntervalConstraint
    {
        /// <summary>
        /// The value of firstEvent is related to the constrainedElement. If firstEvent is true, then the corresponding observation event is the first time instant the execution enters the constrainedElement. If firstEvent is false, then the corresponding observation event is the last time instant the execution is within the constrainedElement.
        /// </summary>
        bool FirstEvent { get; set; }

        /// <summary>
        /// The <see cref="TimeInterval"/> constraining the duration.
        /// </summary>
        OwnerList<TimeInterval> Specification { get; set; }
    }
}