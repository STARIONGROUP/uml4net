// -------------------------------------------------------------------------------------------------
// <copyright file="Message.cs" company="RHEA System S.A.">
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
    using Uml.StructuredClassifiers;
    using Uml.Values;

    /// <summary>
    /// A <see cref="Message"/> defines a particular communication between <see cref="Lifeline"/>s of an <see cref="Interaction"/>.
    /// </summary>
    public interface Message : NamedElement
    {
        /// <summary>
        /// The arguments of the <see cref="Message"/>.
        /// </summary>
        OwnerList<ValueSpecification> Argument { get; set; }

        /// <summary>
        /// The <see cref="Connector"/> on which this <see cref="Message"/> is sent.
        /// </summary>
        Connector Connector { get; set; }

        /// <summary>
        /// The enclosing <see cref="Interaction"/> owning the <see cref="Message"/>.
        /// </summary>
        Interaction Interaction { get; set; }

        /// <summary>
        /// The derived kind of the Message (complete, lost, found, or unknown).
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        MessageKind MessageKind { get; }

        /// <summary>
        /// The sort of communication reflected by the <see cref="Message"/>.
        /// </summary>
        MessageSort MessageSort { get; set; }

        /// <summary>
        /// References the Receiving of the <see cref="Message"/>.
        /// </summary>
        MessageEnd ReceiveEvent { get; set; }
    }
}