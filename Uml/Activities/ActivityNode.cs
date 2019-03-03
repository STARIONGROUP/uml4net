// -------------------------------------------------------------------------------------------------
// <copyright file="ActivityNode.cs" company="RHEA System S.A.">
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

using Uml.Actions;

namespace Uml.Activities
{
    using System.Collections.Generic;
    using Uml.Classification;

    /// <summary>
    /// <see cref="ActivityNode"/> is an abstract class for points in the flow of an <see cref="Activity"/> connected by <see cref="ActivityEdge"/>s.
    /// </summary>
    public interface ActivityNode : RedefinableElement
    {
        /// <summary>
        /// The <see cref="Activity"/> containing the <see cref="ActivityNode"/>, if it is directly owned by an <see cref="Activity"/>.
        /// </summary>
        Activity Activity { get; set; }

        /// <summary>
        /// <see cref="ActivityGroup"/>s containing the <see cref="ActivityNode"/>.
        /// </summary>
        /// <remarks>
        /// Redefined property.
        /// </remarks>
        IEnumerable<ActivityGroup> InGroup { get; }

        /// <summary>
        /// <see cref="InterruptibleActivityRegion"/>s containing the <see cref="ActivityNode"/>.
        /// </summary>
        List<InterruptibleActivityRegion> InInterruptibleRegion { get; set; }

        /// <summary>
        /// <see cref="ActivityPartition"/>s containing the <see cref="ActivityNode"/>.
        /// </summary>
        List<ActivityPartition> InPartition { get; set; }

        /// <summary>
        /// The <see cref="StructuredActivityNode"/> containing the <see cref="ActvityNode"/>, if it is directly owned by a <see cref="StructuredActivityNode"/>.
        /// </summary>
        StructuredActivityNode InStructuredNode { get; set; }

        /// <summary>
        /// <see cref="ActivityEdge"/>s that have the <see cref="ActivityNode"/> as their target.
        /// </summary>
        List<ActivityEdge> Incoming { get; set; }

        /// <summary>
        /// <see cref="ActivityEdge"/>s that have the <see cref="ActivityNode"/> as their source.
        /// </summary>
        List<ActivityEdge> Outgoing { get; set; }

        /// <summary>
        /// <see cref="ActivityNode"/>s from a generalization of the <see cref="Activity"/> containing this <see cref="ActivityNode"/> that are redefined by this <see cref="ActivityNode"/>.
        /// </summary>
        List<ActivityNode> RedefinedNode { get; set; }
    }
}