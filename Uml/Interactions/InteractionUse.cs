// -------------------------------------------------------------------------------------------------
// <copyright file="InteractionUse.cs" company="RHEA System S.A.">
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
    using Uml.Classification;
    using Uml.Values;

    /// <summary>
    /// An <see cref="InteractionUse"/> refers to an <see cref="Interaction"/>. The <see cref="InteractionUse"/> is a shorthand for copying the contents of the referenced <see cref="Interaction"/> where the <see cref="InteractionUse"/> is. To be accurate the copying must take into account substituting parameters with arguments and connect the formal <see cref="Gate"/>s with the actual ones.
    /// </summary>
    public interface InteractionUse : InteractionFragment
    {
        /// <summary>
        /// The actual gates of the <see cref="InteractionUse"/>.
        /// </summary>
        OwnerList<Gate> ActualGate { get; set; }

        /// <summary>
        /// The actual arguments of the <see cref="Interaction"/>.
        /// </summary>
        OwnerList<ValueSpecification> Argument { get; set; }

        /// <summary>
        /// Refers to the Interaction that defines its meaning.
        /// </summary>
        Interaction RefersTo { get; set; }

        /// <summary>
        /// The value of the executed <see cref="Interaction"/>.
        /// </summary>
        OwnerList<ValueSpecification> ReturnValue { get; set; }

        /// <summary>
        /// The recipient of the return value.
        /// </summary>
        Property ReturnValueRecipient { get; set; }
    }
}