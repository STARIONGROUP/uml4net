// -------------------------------------------------------------------------------------------------
// <copyright file="DurationConstraint.cs" company="RHEA System S.A.">
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
    /// A DurationConstraint is a Constraint that refers to a DurationInterval.
    /// </summary>
    public interface DurationConstraint : IntervalConstraint
    {
        /// <summary>
        /// The value of firstEvent[i] is related to constrainedElement[i] (where i is 1 or 2). If firstEvent[i] is true, then the corresponding observation event is the first time instant the execution enters constrainedElement[i]. If firstEvent[i] is false, then the corresponding observation event is the last time instant the execution is within constrainedElement[i].
        /// </summary>
        List<string> FirstEvent { get; set; }

        /// <summary>
        /// The <see cref="DurationInterval"/> constraining the duration.
        /// </summary>
        OwnerList<DurationInterval> Specification { get; set; }
    }
}