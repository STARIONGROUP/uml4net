// -------------------------------------------------------------------------------------------------
// <copyright file="DestroyObjectAction.cs" company="RHEA System S.A.">
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
    /// A <see cref="DestroyObjectAction"/> is an <see cref="Action"/> that destroys objects.
    /// </summary>
    public interface DestroyObjectAction : Action
    {
        /// <summary>
        /// Specifies whether links in which the object participates are destroyed along with the object.
        /// </summary>
        bool IsDestroyLinks { get; set; }

        /// <summary>
        /// Specifies whether objects owned by the object (via composition) are destroyed along with the object.
        /// </summary>
        bool IsDestroyOwnedObjects { get; set; }

        /// <summary>
        /// The InputPin providing the object to be destroyed.
        /// </summary>
        OwnerList<InputPin> Target { get; set; }
    }
}