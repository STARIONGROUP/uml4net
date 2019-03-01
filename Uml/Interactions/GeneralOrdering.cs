// -------------------------------------------------------------------------------------------------
// <copyright file="GeneralOrdering.cs" company="RHEA System S.A.">
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

namespace Uml.Interactions
{
    using Uml.CommonStructure;

    /// <summary>
    /// A <see cref="GeneralOrdering"/> represents a binary relation between two <see cref="OccurrenceSpecification"/>s, to describe that one <see cref="OccurrenceSpecification"/> must occur before the other in a valid trace. This mechanism provides the ability to define partial orders of <see cref="OccurrenceSpecification"/>s that may otherwise not have a specified order.
    /// </summary>
    public interface GeneralOrdering : NamedElement
    {
        /// <summary>
        /// The <see cref="OccurrenceSpecification"/> referenced comes after the <see cref="OccurrenceSpecification"/> referenced by before.
        /// </summary>
        OccurrenceSpecification After { get; set; }

        /// <summary>
        /// The <see cref="OccurrenceSpecification"/> referenced comes before the <see cref="OccurrenceSpecification"/> referenced by after.
        /// </summary>
        OccurrenceSpecification Before { get; set; }
    }
}