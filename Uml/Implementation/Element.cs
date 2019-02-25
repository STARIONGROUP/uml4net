// -------------------------------------------------------------------------------------------------
// <copyright file="Element.cs" company="RHEA System S.A.">
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
//   along with Foobar.  If not, see<http://www.gnu.org/licenses/>.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Uml.Implementation
{
    using System.Collections.Generic;
    using Uml.Assembler;

    /// <summary>
    /// An <see cref="Element"/> is a constituent of a model. As such, it has the capability of owning other <see cref="Element"/>s.
    /// </summary>
    public abstract class Element : Uml.CommonStructure.Element
    {
        /// <summary>
        /// Gets the unique Id of the <see cref="Element"/>
        /// </summary>
        /// <remarks>
        /// The Id is not specified in UML
        /// </remarks>
        public string Id { get; internal set; }

        /// <summary>
        /// Gets the <see cref="Element"/> that owns this <see cref="Element"/>.
        /// </summary>
        /// <remarks>
        /// derived property
        /// </remarks>
        public Uml.CommonStructure.Element Owner { get; set; }

        //// <summary>
        /// Gets the Comments owned by this Element.
        /// </summary>
        //public OwnerList<Comment> OwnedComment { get; private set; }

        /// <summary>
        /// Gets the <see cref="Element"/>s owned by this <see cref="Element"/>.
        /// </summary>
        /// <remarks>
        /// derived property
        /// </remarks>
        public abstract List<Element> OwnedElement { get; }
    }
}
