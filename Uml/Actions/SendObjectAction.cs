// -------------------------------------------------------------------------------------------------
// <copyright file="SendObjectAction.cs" company="RHEA System S.A.">
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
    /// A <see cref="SendObjectAction"/> is an <see cref="InvocationAction"/> that transmits an input object to the target object, which is handled as a request message by the target object. The requestor continues execution immediately after the object is sent out and cannot receive reply values.
    /// </summary>
    public interface SendObjectAction : InvocationAction
    {
        /// <summary>
        /// The request object, which is transmitted to the target object. The object may be copied in transmission, so identity might not be preserved.
        /// </summary>
        OwnerList<InputPin> Request { get; set; }

        /// <summary>
        /// The target object to which the object is sent.
        /// </summary>
        OwnerList<InputPin> Target { get; set; }
    }
}