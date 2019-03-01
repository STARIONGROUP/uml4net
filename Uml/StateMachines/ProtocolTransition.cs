// -------------------------------------------------------------------------------------------------
// <copyright file="ProtocolTransition.cs" company="RHEA System S.A.">
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
    using Uml.Classification;
    using Uml.CommonBehavior;
    using Uml.CommonStructure;

    /// <summary>
    /// A <see cref="ProtocolTransition"/> specifies a legal Transition for an <see cref="Operation"/>. Transitions of <see cref="ProtocolStateMachine"/>s have the following information: a pre-condition (guard), a <see cref="Trigger"/>, and a post-condition. Every <see cref="ProtocolTransition"/> is associated with at most one <see cref="BehavioralFeature"/> belonging to the context <see cref="Classifier"/> of the <see cref="ProtocolStateMachine"/>.
    /// </summary>
    public interface ProtocolTransition : Transition
    {
        /// <summary>
        /// Specifies the post condition of the <see cref="Transition"/> which is the Condition that should be obtained once the <see cref="Transition"/> is triggered. This post condition is part of the post condition of the <see cref="Operation"/> connected to the <see cref="Transition"/>.
        /// </summary>
        OwnerList<Constraint> PostCondition { get; set; }

        /// <summary>
        /// Specifies the precondition of the <see cref="Transition"/>. It specifies the Condition that should be verified before triggering the <see cref="Transition"/>. This guard condition added to the source <see cref="State"/> will be evaluated as part of the precondition of the <see cref="Operation"/> referred by the <see cref="Transition"/> if any.
        /// </summary>
        OwnerList<Constraint> PreCondition { get; set; }

        /// <summary>
        /// This association refers to the associated <see cref="Operation"/>. It is derived from the <see cref="Operation"/> of the <see cref="CallEvent"/> <see cref="Trigger"/> when applicable.
        /// </summary>
        IEnumerable<Operation> Referred { get; }
    }
}