// -------------------------------------------------------------------------------------------------
// <copyright file="StateInvariant.cs" company="RHEA System S.A.">
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
    using Uml.Assembler;
    using Uml.Activities;
    using Uml.CommonStructure;
    using Uml.StateMachines;

    /// <summary>
    /// A <see cref="StateInvariant"/> is a runtime constraint on the participants of the <see cref="Interaction"/>. It may be used to specify a variety of different kinds of <see cref="Constraint"/>s, such as values of Attributes or <see cref="Variable"/>s, internal or external <see cref="State"/>s, and so on. A <see cref="StateInvariant"/> is an <see cref="InteractionFragment"/> and it is placed on a <see cref="Lifeline"/>.
    /// </summary>
    public interface StateInvariant : InteractionFragment
    {
        /// <summary>
        /// References the <see cref="Lifeline"/> on which the <see cref="StateInvariant"/> appears.
        /// </summary>
        Lifeline Covered { get; set; }

        /// <summary>
        /// A Constraint that should hold at runtime for this StateInvariant.
        /// </summary>
        OwnerList<Constraint> Invariant { get; set; }
    }
}