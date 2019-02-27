// -------------------------------------------------------------------------------------------------
// <copyright file="ActivityGroup.cs" company="RHEA System S.A.">
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
//   along with Foobar.  If not, see<http://www.gnu.org/licenses/>.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Uml.Activities
{
    using System.Collections.Generic;
    using Uml.CommonStructure;

    /// <summary>
    /// <see cref="ActivityGroup"/> is an abstract class for defining sets of <see cref="ActivityNode"/>s and <see cref="ActivityEdge"/>s in an <see cref="Activity"/>.
    /// </summary>
    public interface ActivityGroup : NamedElement
    {
        /// <summary>
        /// <see cref="ActivityEdge"/>s immediately contained in the <see cref="ActivityGroup"/>.
        /// </summary>
        /// <remarks>
        /// Derived property
        /// </remarks>
        IEnumerable<ActivityEdge> ContainedEdge { get; }

        /// <summary>
        /// <see cref="ActivityNode"/>s immediately contained in the <see cref="ActivityGroup"/>.
        /// </summary>
        /// <remarks>
        /// Derived property
        /// </remarks>
        IEnumerable<ActivityNode> ContainedNode { get; }

        /// <summary>
        /// The <see cref="Activity"/> containing the <see cref="ActivityGroup"/>, if it is directly owned by an <see cref="Activity"/>.
        /// </summary>
        Activity InActivity { get; set; } 

        /// <summary>
        /// Other <see cref="ActivityGroup"/>s immediately contained in this <see cref="ActivityGroup"/>.
        /// </summary>
        /// <remarks>
        /// Derived property
        /// </remarks>
        IEnumerable<ActivityGroup> Subgroup { get; }

        /// <summary>
        /// The <see cref="ActivityGroup"/> immediately containing this <see cref="ActivityGroup"/>, if it is directly owned by another <see cref="ActivityGroup"/>.
        /// </summary>
        /// <remarks>
        /// Derived property
        /// </remarks>
        IEnumerable<ActivityGroup> SuperGroup { get; }
    }
}