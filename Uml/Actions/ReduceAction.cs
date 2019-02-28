// -------------------------------------------------------------------------------------------------
// <copyright file="ReduceAction.cs" company="RHEA System S.A.">
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
//   along with uml-sharp.  If not, see<http://www.gnu.org/licenses/>.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Uml.Actions
{
    using Uml.Assembler;
    using Uml.CommonBehavior;

    /// <summary>
    /// A <see cref="ReduceAction"/> is an <see cref="Action"/> that reduces a collection to a single value by repeatedly combining the elements of the collection using a reducer <see cref="Behavior"/>.
    /// </summary>
    public interface ReduceAction : Action
    {
        /// <summary>
        /// The <see cref="InputPin"/> that provides the collection to be reduced.
        /// </summary>
        OwnerList<InputPin> Collection { get; set; }

        /// <summary>
        /// Indicates whether the order of the input collection should determine the order in which the reducer <see cref="Behavior"/> is applied to its elements.
        /// </summary>
        bool IsOrdered { get; set; }

        /// <summary>
        /// A <see cref="Behavior"/> that is repreatedly applied to two elements of the input collection to produce a value that is of the same type as elements of the collection.
        /// </summary>
        Behavior Reducer { get; set; }

        /// <summary>
        /// The output pin on which the result value is placed.
        /// </summary>
        OwnerList<OutputPin> Result { get; set; }
    }
}