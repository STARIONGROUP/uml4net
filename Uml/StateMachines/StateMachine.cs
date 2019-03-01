// -------------------------------------------------------------------------------------------------
// <copyright file="StateMachine.cs" company="RHEA System S.A.">
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

namespace Uml.StateMachines
{
    using System.Collections.Generic;
    using Uml.Assembler;
    using Uml.CommonBehavior;

    /// <summary>
    /// <see cref="StateMachine"/>s can be used to express event-driven behaviors of parts of a system. <see cref="Behavior"/> is modeled as a traversal of a graph of Vertices interconnected by one or more joined <see cref="Transition"/> arcs that are triggered by the dispatching of successive Event occurrences. During this traversal, the <see cref="StateMachine"/> may execute a sequence of <see cref="Behavior"/>s associated with various elements of the <see cref="StateMachine"/>.
    /// </summary>
    public interface StateMachine : Behavior
    {
        /// <summary>
        /// The connection points defined for this <see cref="StateMachine"/>. They represent the interface of the <see cref="StateMachine"/> when used as part of submachine <see cref="State"/>
        /// </summary>
        OwnerList<Pseudostate> ConnectionPoint { get; set; }

        /// <summary>
        /// The <see cref="StateMachine"/>s of which this is an extension.
        /// </summary>
        List<StateMachine> ExtendedStateMachine { get; set; }

        /// <summary>
        /// The <see cref="Region"/>s owned directly by the <see cref="StateMachine"/>.
        /// </summary>
        OwnerList<Region> Region { get; set; }

        /// <summary>
        /// References the submachine(s) in case of a submachine State. Multiple machines are referenced in case of a concurrent <see cref="State"/>.
        /// </summary>
        List<State> SubmachineState { get; set; }
    }
}