// -------------------------------------------------------------------------------------------------
// <copyright file="DecisionNode.cs" company="RHEA System S.A.">
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

namespace Uml.Activities
{
    using Uml.CommonBehavior;

    /// <summary>
    /// A <see cref="DecisionNode"/> is a <see cref="ControlNode"/> that chooses between outgoing <see cref="ActivityEdge"/>s for the routing of tokens.
    /// </summary>
    public interface DecisionNode : ControlNode
    {
        /// <summary>
        /// A Behavior that is executed to provide an input to guard ValueSpecifications on ActivityEdges outgoing from the DecisionNode.
        /// </summary>
        Behavior DecisionInput { get; set; }
        
        /// <summary>
        /// An additional <see cref="ActivityEdge"/> incoming to the DecisionNode that provides a decision input value for the guards <see cref="ValueSpecification"/>s on <see cref="ActivityEdge"/>s outgoing from the <see cref="DecisionNode"/>.
        /// </summary>
        ObjectFlow DecisionInputFlow { get; set; }
    }
}