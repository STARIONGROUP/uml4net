// -------------------------------------------------------------------------------------------------
// <copyright file="InteractionOperand.cs" company="RHEA System S.A.">
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
    using Uml.CommonStructure;

    /// <summary>
    /// An <see cref="InteractionOperand"/> is contained in a <see cref="CombinedFragment"/>. An <see cref="InteractionOperand"/> represents one operand of the expression given by the enclosing <see cref="CombinedFragment"/>.
    /// </summary>
    public interface InteractionOperand : InteractionFragment, Namespace
    {
        /// <summary>
        /// The fragments of the operand.
        /// </summary>
        OwnerList<InteractionFragment> Fragment { get; set; }

        /// <summary>
        /// Constraint of the operand.
        /// </summary>
        OwnerList<InteractionConstraint> Guard { get; set; }
    }
}