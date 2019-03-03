// -------------------------------------------------------------------------------------------------
// <copyright file="AcceptEventAction.cs" company="RHEA System S.A.">
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

namespace Uml.Actions
{
    using Uml.Assembler;
    using Uml.CommonBehavior;

    /// <summary>
    /// An AcceptEventAction is an Action that waits for the occurrence of one or more specific Events.
    /// </summary>
    public interface AcceptEventAction : Action
    {
        /// <summary>
        /// Indicates whether there is a single <see cref="OutputPin"/> for a <see cref="SignalEvent"/> occurrence, or multiple <see cref="OutputPin"/>s for attribute values of the instance of the <see cref="Signal"/> associated with a <see cref="SignalEvent"/> occurrence.
        /// </summary>
        bool IsUnmarshall { get; set; }

        /// <summary>
        /// <see cref="OutputPin"/>s holding the values received from an <see cref="Event"/> occurrence.
        /// </summary>
        OwnerList<OutputPin> Result { get; set; }

        /// <summary>
        /// The <see cref="Trigger"/>s specifying the Events of which the <see cref="AcceptEventAction"/> waits for occurrences.
        /// </summary>
        OwnerList<Trigger> Trigger { get; set; }
    }
}