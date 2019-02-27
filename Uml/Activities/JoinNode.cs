// -------------------------------------------------------------------------------------------------
// <copyright file="JoinNode.cs" company="RHEA System S.A.">
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
    using Uml.Assembler;
    using Uml.Values;

    /// <summary>
    /// A <see cref="JoinNode"/> is a <see cref="ControlNode"/> that synchronizes multiple flows.
    /// </summary>
    public interface JoinNode : ControlNode
    {
        /// <summary>
        /// Indicates whether incoming tokens having objects with the same identity are combined into one by the <see cref="JoinNode"/>.
        /// </summary>
        bool IsCombineDuplicate { get; set; }

        /// <summary>
        /// A <see cref="ValueSpecification"/> giving the condition under which the <see cref="JoinNode"/> will offer a token on its outgoing <see cref="ActivityEdge"/>. If no joinSpec is specified, then the <see cref="JoinNode"/> will offer an outgoing token if tokens are offered on all of its incoming <see cref="ActivityEdge"/>s (an "and" condition).
        /// </summary>
        OwnerList<ValueSpecification> JoinSpec { get; set; }
    }
}