// -------------------------------------------------------------------------------------------------
// <copyright file="ProtocolConformance.cs" company="RHEA System S.A.">
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
    using Uml.CommonStructure;

    /// <summary>
    /// A ProtocolStateMachine can be redefined into a more specific ProtocolStateMachine or into behavioral StateMachine. ProtocolConformance declares that the specific ProtocolStateMachine specifies a protocol that conforms to the general ProtocolStateMachine or that the specific behavioral StateMachine abides by the protocol of the general ProtocolStateMachine.
    /// </summary>
    public interface ProtocolConformance : DirectedRelationship
    {
        /// <summary>
        /// Specifies the <see cref="ProtocolStateMachine"/> to which the specific <see cref="ProtocolStateMachine"/> conforms.
        /// </summary>
        ProtocolStateMachine GeneralMachine { get; set; }

        /// <summary>
        /// Specifies the <see cref="ProtocolStateMachine"/> which conforms to the general <see cref="ProtocolStateMachine"/>.
        /// </summary>
        ProtocolStateMachine SpecificMachine { get; set; }
    }
}