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
//   along with uml-sharp. If not, see<http://www.gnu.org/licenses/>.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Uml.Implementation
{
    using System.Collections.Generic;
    using Uml.Assembler;
    using Uml.CommonStructure;

    /// <summary>
    /// An <see cref="Element"/> is a constituent of a model. As such, it has the capability of owning other <see cref="Element"/>s.
    /// </summary>
    internal abstract class Element : Uml.CommonStructure.Element
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Element"/>
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the <see cref="Element"/>
        /// </param>
        protected Element(string id)
        {
            this.Id = id;
            this.OwnedComment = new OwnerList<Comment>(this);
        }
        
        /// <summary>
        /// Gets the unique Id of the <see cref="Element"/>
        /// </summary>
        /// <remarks>
        /// The Id is not specified in UML
        /// </remarks>
        public string Id { get; private set; }

        /// <summary>
        /// The Comments owned by this <see cref="Element"/>.
        /// </summary>
        public OwnerList<Comment> OwnedComment { get; set; }

        /// <summary>
        /// The <see cref="Element"/>s owned by this Element.
        /// </summary>
        /// <remarks>
        /// Derived property
        /// </remarks>
        public IEnumerable<CommonStructure.Element> OwnedElement()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the <see cref="Element"/> that owns this <see cref="Element"/>.
        /// </summary>
        /// <remarks>
        /// Derived property
        /// </remarks>
        public CommonStructure.Element Owner()
        {
            throw new System.NotImplementedException();
        }
    }
}