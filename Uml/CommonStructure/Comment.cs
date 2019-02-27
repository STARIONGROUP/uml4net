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
//   along with Foobar.  If not, see<http://www.gnu.org/licenses/>.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Uml.CommonStructure
{
    using System.Collections.Generic;

    /// <summary>
    /// A <see cref="Comment"/> is a textual annotation that can be attached to a set of <see cref="Element"/>s.
    /// </summary>
    public interface Comment : Element
    {
        /// <summary>
        /// References the <see cref="Element"/>(s) being commented.
        /// </summary>
        List<Element> AnnotatedElement { get; set; }

        /// <summary>
        /// Specifies a string that is the comment.
        /// </summary>
        string Body { get; set; }
    }
}