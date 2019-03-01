// -------------------------------------------------------------------------------------------------
// <copyright file="CombinedFragment.cs" company="RHEA System S.A.">
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

    /// <summary>
    /// A <see cref="CombinedFragment"/> defines an expression of <see cref="InteractionFragment"/>s. A <see cref="CombinedFragment"/> is defined by an interaction operator and corresponding <see cref="InteractionOperand"/>s. Through the use of <see cref="CombinedFragment"/>s the user will be able to describe a number of traces in a compact and concise manner.
    /// </summary>
    public interface CombinedFragment : InteractionFragment
    {
        /// <summary>
        /// Specifies the gates that form the interface between this <see cref="CombinedFragment"/> and its surroundings
        /// </summary>
        OwnerList<Gate> CfragmentGate { get; set; }

        /// <summary>
        /// Specifies the operation which defines the semantics of this combination of <see cref="InteractionFragment"/>s.
        /// </summary>
        InteractionOperatorKind InteractionOperatorKind { get; set; }

        /// <summary>
        /// The set of operands of the combined fragment.
        /// </summary>
        OwnerList<InteractionOperand> Operand { get; set; }
    }
}