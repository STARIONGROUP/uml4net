// -------------------------------------------------------------------------------------------------
// <copyright file="ActivityPartition.cs" company="RHEA System S.A.">
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

using Uml.Assembler;
using Uml.CommonStructure;

namespace Uml.Activities
{
    using System.Collections.Generic;

    /// <summary>
    /// An <see cref="ActivityPartition"/> is a kind of <see cref="ActivityGroup"/> for identifying <see cref="ActivityNode"/>s that have some characteristic in common.
    /// </summary>
    public interface ActivityPartition : ActivityGroup
    {
        /// <summary>
        /// <see cref="ActivityEdge"/>s immediately contained in the <see cref="ActivityPartition"/>.
        /// </summary>
        List<ActivityEdge> Edge { get; set; }

        /// <summary>
        /// Indicates whether the <see cref="ActivityPartition"/> groups other <see cref="ActivityPartition"/>s along a dimension.
        /// </summary>
        bool IsDimension { get; set; }

        /// <summary>
        /// Indicates whether the <see cref="ActivityPartition"/> represents an entity to which the partitioning structure does not apply.
        /// </summary>
        bool IsExternal { get; set; }

        /// <summary>
        /// <see cref="ActivityNode"/>s immediately contained in the <see cref="ActivityPartition"/>.
        /// </summary>
        List<ActivityNode> Node { get; set; }

        /// <summary>
        /// An <see cref="Element"/> represented by the functionality modeled within the <see cref="ActivityPartition"/>.
        /// </summary>
        Element Represents { get; set; }

        /// <summary>
        /// Other <see cref="ActivityPartition"/>s immediately contained in this <see cref="ActivityPartition"/> (as its subgroups).
        /// </summary>
        OwnerList<ActivityPartition> Subpartition { get; set; }

        /// <summary>
        /// Other <see cref="ActivityPartition"/>s immediately containing this <see cref="ActivityPartition"/> (as its superGroups).
        /// </summary>
        ActivityPartition SuperPartition { get; set; }
    }
}