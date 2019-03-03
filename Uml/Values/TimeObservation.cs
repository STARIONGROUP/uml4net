// -------------------------------------------------------------------------------------------------
// <copyright file="TimeObservation.cs" company="RHEA System S.A.">
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

namespace Uml.Values
{
    using Uml.CommonStructure;

    /// <summary>
    /// A <see cref="TimeObservation"/> is a reference to a time instant during an execution. It points out the <see cref="NamedElement"/> in the model to observe and whether the observation is when this <see cref="NamedElement"/> is entered or when it is exited.
    /// </summary>
    public interface TimeObservation : Observation
    {
        /// <summary>
        /// The <see cref="TimeObservation"/> is determined by the entering or exiting of the event <see cref="Element"/> during execution.
        /// </summary>
        NamedElement Event { get; set; }

        /// <summary>
        /// The value of firstEvent is related to the event. If firstEvent is true, then the corresponding observation event is the first time instant the execution enters the event <see cref="Element"/>. If firstEvent is false, then the corresponding observation event is the time instant the execution exits the event <see cref="Element"/>.
        /// </summary>
        bool FirstEvent { get; set; }
    }
}