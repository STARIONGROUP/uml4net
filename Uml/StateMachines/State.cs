// -------------------------------------------------------------------------------------------------
// <copyright file="State.cs" company="RHEA System S.A.">
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
    using Uml.Assembler;
    using Uml.CommonBehavior;
    using Uml.CommonStructure;

    /// <summary>
    /// A State models a situation during which some (usually implicit) invariant condition holds.
    /// </summary>
    public interface State : Namespace, Vertex
    {
        /// <summary>
        /// The entry and exit connection points used in conjunction with this (submachine) State, i.e., as targets and sources, respectively, in the Region with the submachine State. A connection point reference references the corresponding definition of a connection point Pseudostate in the StateMachine referenced by the submachine State.
        /// </summary>
        OwnerList<ConnectionPointReference> Connection { get; set; }

        /// <summary>
        /// The entry and exit <see cref="Pseudostate"/>s of a composite <see cref="State"/>. These can only be entry or exit <see cref="Pseudostate"/>s, and they must have different names. They can only be defined for composite <see cref="State"/>s.
        /// </summary>
        OwnerList<Pseudostate> ConnectionPoint { get; set; }

        /// <summary>
        /// A list of Triggers that are candidates to be retained by the <see cref="StateMachine"/> if they trigger no Transitions out of the State (not consumed). A deferred <see cref="Trigger"/> is retained until the <see cref="StateMachine"/> reaches a State configuration where it is no longer deferred.
        /// </summary>
        OwnerList<Trigger> DeferrableTrigger { get; set; }

        /// <summary>
        /// An optional <see cref="Behavior"/> that is executed while being in the <see cref="State"/>. The execution starts when this <see cref="State"/> is entered, and ceases either by itself when done, or when the <see cref="State"/> is exited, whichever comes first.
        /// </summary>
        OwnerList<Behavior> DoActivity { get; set; }

        /// <summary>
        /// An optional <see cref="Behavior"/> that is executed whenever this State is entered regardless of the <see cref="Transition"/> taken to reach the <see cref="State"/>. If defined, entry <see cref="Behavior"/>s are always executed to completion prior to any internal <see cref="Behavior"/> or <see cref="Transition"/>s performed within the <see cref="State"/>.
        /// </summary>
        OwnerList<Behavior> Entry { get; set; }

        /// <summary>
        /// An optional Behavior that is executed whenever this State is exited regardless of which Transition was taken out of the State. If defined, exit Behaviors are always executed to completion only after all internal and transition Behaviors have completed execution.
        /// </summary>
        OwnerList<Behavior> Exit { get; set; }

        /// <summary>
        /// A state with isComposite=true is said to be a composite State. A composite <see cref="State"/> is a State that contains at least one <see cref="Region"/>.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        bool IsComposite { get; }

        /// <summary>
        /// A <see cref="State"/> with isOrthogonal=true is said to be an orthogonal composite <see cref="State"/> An orthogonal composite <see cref="State"/> contains two or more <see cref="Region"/>s.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        bool IsOrthogonal { get; }

        /// <summary>
        /// A <see cref="State"/> with isSimple=true is said to be a simple <see cref="State"/> A simple <see cref="State"/> does not have any <see cref="Region"/>s and it does not refer to any submachine <see cref="StateMachine"/>.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        bool IsSimple { get; }

        /// <summary>
        /// A <see cref="State"/> with isSubmachineState=true is said to be a submachine State Such a <see cref="State"/> refers to another <see cref="StateMachine"/>(submachine).
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        bool IsSubmachineState { get; }

        /// <summary>
        /// The <see cref="Region"/>s owned directly by the <see cref="State"/>.
        /// </summary>
        OwnerList<Region> Region { get; set; }

        /// <summary>
        /// Specifies conditions that are always true when this State is the current State. In ProtocolStateMachines state invariants are additional conditions to the preconditions of the outgoing Transitions, and to the postcondition of the incoming Transitions.
        /// </summary>
        OwnerList<Constraint> StateInvariant { get; set; }

        /// <summary>
        /// The <see cref="StateMachine"/> that is to be inserted in place of the (submachine) State.
        /// </summary>
        StateMachine Submachine { get; set; }
    }
}