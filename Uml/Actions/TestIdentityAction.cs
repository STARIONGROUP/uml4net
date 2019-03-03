// -------------------------------------------------------------------------------------------------
// <copyright file="TestIdentityAction.cs" company="RHEA System S.A.">
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

    /// <summary>
    /// A <see cref="TestIdentityAction"/> is an <see cref="Action"/> that tests if two values are identical objects.
    /// </summary>
    public interface TestIdentityAction : Action
    {
        /// <summary>
        /// The <see cref="InputPin"/> on which the first input object is placed.
        /// </summary>
        OwnerList<InputPin> First { get; set; }

        /// <summary>
        /// The <see cref="OutputPin"/> whose Boolean value indicates whether the two input objects are identical.
        /// </summary>
        OwnerList<OutputPin> Result { get; set; }

        /// <summary>
        /// The <see cref="OutputPin"/> on which the second input object is placed.
        /// </summary>
        OwnerList<InputPin> Second { get; set; }
    }
}