// -------------------------------------------------------------------------------------------------
// <copyright file="ExecutionSpecification.cs" company="RHEA System S.A.">
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
    using Uml.Actions;
    using Uml.CommonBehavior;

    /// <summary>
    /// An <see cref="ExecutionSpecification"/> is a specification of the execution of a unit of <see cref="Behavior"/> or <see cref="Action"/> within the <see cref="Lifeline"/>. The duration of an <see cref="ExecutionSpecification"/> is represented by two <see cref="OccurrenceSpecification"/>s, the start <see cref="OccurrenceSpecification"/> and the finish <see cref="OccurrenceSpecification"/>.
    /// </summary>
    public interface ExecutionSpecification : InteractionFragment
    {
        /// <summary>
        /// References the <see cref="OccurrenceSpecification"/> that designates the finish of the <see cref="Action"/> or <see cref="Behavior"/>.
        /// </summary>
        OccurrenceSpecification Finish { get;set; }

        /// <summary>
        /// References the <see cref="OccurrenceSpecification"/> that designates the start of the <see cref="Action"/> or <see cref="Behavior"/>.
        /// </summary>
        OccurrenceSpecification Start { get;set; }
    }
}