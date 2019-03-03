// -------------------------------------------------------------------------------------------------
// <copyright file="DurationInterval.cs" company="RHEA System S.A.">
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
    /// <summary>
    /// A <see cref="DurationInterval"/> defines the range between two <see cref="Duration"/>s.
    /// </summary>
    public interface DurationInterval : Interval
    {
        /// <summary>
        /// Refers to the <see cref="Duration"/> denoting the maximum value of the range.
        /// </summary>
        Duration Max { get; set; }

        /// <summary>
        /// Refers to the <see cref="Duration"/> denoting the minimum value of the range.
        /// </summary>
        Duration Min { get; set; }
    }
}