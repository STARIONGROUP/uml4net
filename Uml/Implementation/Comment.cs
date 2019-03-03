// -------------------------------------------------------------------------------------------------
// <copyright file="Comment.cs" company="RHEA System S.A.">
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

namespace Implementation.CommonStructure
{
    using System.Collections.Generic;
    using Uml.CommonStructure;

    /// <summary>
    /// A <see cref="Comment"/> is a textual annotation that can be attached to a set of <see cref="Element"/>s.
    /// </summary>
    internal class Comment : Uml.Implementation.Element, Uml.CommonStructure.Comment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Comment"/> class.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the <see cref="Abstraction"/>
        /// </param>
        public Comment(string id) : base(id)
        {
            this.AnnotatedElement = new List<Element>();
        }

        /// <summary>
        /// References the <see cref="Element"/>(s) being commented.
        /// </summary>
        public List<Element> AnnotatedElement { get; set; }

        /// <summary>
        /// Specifies a string that is the comment.
        /// </summary>
        public string Body { get; set; }
    }
}