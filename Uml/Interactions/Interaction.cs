// -------------------------------------------------------------------------------------------------
// <copyright file="Interaction.cs" company="RHEA System S.A.">
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

namespace Uml.Interactions
{
    using System;
    using Uml.Assembler;
    using Uml.CommonBehavior;
    
    /// <summary>
    /// An <see cref="Interaction"/> is a unit of <see cref="Behavior"/> that focuses on the observable exchange of information between connectable elements.
    /// </summary>
    public interface Interaction : InteractionFragment, Behavior
    {
        /// <summary>
        /// <see cref="Action"/>s owned by the <see cref="Interaction"/>.
        /// </summary>
        OwnerList<Action> Action { get; ; set; }

        /// <summary>
        /// Specifies the gates that form the message interface between this <see cref="Interaction"/> and any <see cref="InteractionUse"/>s which reference it.
        /// </summary>
        OwnerList<Gate> FormalGate { get; set; }

        /// <summary>
        /// The ordered set of fragments in the <see cref="Interaction"/>.
        /// </summary>
        OwnerList<InteractionFragment> Fragment { get; set; }

        /// <summary>
        /// Specifies the participants in this <see cref="Interaction"/>.
        /// </summary>
        OwnerList<Lifeline> Lifeline { get; set; }

        /// <summary>
        /// The <see cref="Message"/>s contained in this <see cref="Interaction"/>.
        /// </summary>
        OwnerList<Message> Message { get; set; }
    }
}