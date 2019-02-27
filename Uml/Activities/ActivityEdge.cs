// -------------------------------------------------------------------------------------------------
// <copyright file="ActivityEdge.cs" company="RHEA System S.A.">
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
    using Uml.Actions;
    using Uml.Classification;
    using Uml.Values;

    /// <summary>
    /// An ActivityEdge is an abstract class for directed connections between two ActivityNodes.
    /// </summary>
    public interface ActivityEdge : RedefinableElement
    {
        /// <summary>
        /// The <see cref="Activity"/> containing the <see cref="ActivityEdge"/>, if it is directly owned by an <see cref="Activity"/>.
        /// </summary>
        Activity Activity { get; set; } 

        /// <summary>
        /// A <see cref="ValueSpecification"/> that is evaluated to determine if a token can traverse the <see cref="ActivityEdge"/>. If an <see cref="ActivityEdge"/> has no guard, then there is no restriction on tokens traversing the edge.
        /// </summary>
        ValueSpecification Guard { get; set; }

        /// <summary>
        /// <see cref="ActivityGroup"/>s containing the <see cref="ActivityEdge"/>.
        /// </summary>
        /// <remarks>
        /// derived property
        /// </remarks>
        IEnumerable<ActivityGroup>  InGroup { get; }

        /// <summary>
        /// <see cref="ActivityPartition"/>s containing the <see cref="ActivityEdge"/>.
        /// </summary>
        List<ActivityPartition> InPartition { get; set; }

        /// <summary>
        /// The <see cref="StructuredActivityNode"/> containing the <see cref="ActivityEdge"/>, if it is owned by a <see cref="StructuredActivityNode"/>.
        /// </summary>
        StructuredActivityNode InStructuredNode { get; set; }

        /// <summary>
        /// The <see cref="InterruptibleActivityRegion"/> for which this <see cref="ActivityEdge"/> is an interruptingEdge.
        /// </summary>
        InterruptibleActivityRegion Interrupts { get; set; }

        /// <summary>
        /// <see cref="ActivityEdge"/>s from a generalization of the <see cref="Activity"/> containing this <see cref="ActivityEdge"/> that are redefined by this <see cref="ActivityEdge"/>.
        /// </summary>
        ActivityEdge RedefinedEdge { get; set; }

        /// <summary>
        /// The ActivityNode from which tokens are taken when they traverse the ActivityEdge.
        /// </summary>
        ActivityNode Source { get; set; }

        /// <summary>
        /// The <see cref="ActivityNode"/> to which tokens are put when they traverse the <see cref="ActivityEdge"/>.
        /// </summary>
        ActivityNode Target { get; set; }

        /// <summary>
        /// The minimum number of tokens that must traverse the <see cref="ActivityEdge"/> at the same time. If no weight is specified, this is equivalent to specifying a constant value of 1.
        /// </summary>
        ValueSpecification Weight { get; set; }
    }
}