// -------------------------------------------------------------------------------------------------
// <copyright file="DurationObservation.cs" company="RHEA System S.A.">
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
    using System.Collections.Generic;
    using Uml.CommonStructure;

    /// <summary>
    /// A <see cref="DurationObservation"/> is a reference to a duration during an execution. It points out the <see cref="NamedElement"/>(s) in the model to observe and whether the observations are when this <see cref="NamedElement"/> is entered or when it is exited.
    /// </summary>
    public interface DurationObservation
    {
        /// <summary>
        /// The <see cref="DurationObservation"/> is determined as the duration between the entering or exiting of a single event <see cref="Element"/> during execution, or the entering/exiting of one event Element and the entering/exiting of a second.
        /// </summary>
        List<NamedElement> Event { get; set; }

        /// <summary>
        /// The value of firstEvent[i] is related to event[i] (where i is 1 or 2). If firstEvent[i] is true, then the corresponding observation event is the first time instant the execution enters event[i]. If firstEvent[i] is false, then the corresponding observation event is the time instant the execution exits event[i].
        /// </summary>
        List<string> FirstEvent { get; set; }
    }
}