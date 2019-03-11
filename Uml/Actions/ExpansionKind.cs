// -------------------------------------------------------------------------------------------------
// <copyright file="ExpansionKind.cs" company="RHEA System S.A.">
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
    /// <summary>
    /// <see cref="ExpansionKind"/> is an enumeration type used to specify how an <see cref="ExpansionRegion"/> executes its contents.
    /// </summary>
    public enum ExpansionKind
    {
        /// <summary>
        /// The content of the <see cref="ExpansionRegion"/> is executed concurrently for the elements of the input collections.
        /// </summary>
        Parallel,

        /// <summary>
        /// The content of the <see cref="ExpansionRegion"/> is executed iteratively for the elements of the input collections, in the order of the input elements, if the collections are ordered.
        /// </summary>
        Iterative,

        /// <summary>
        /// A stream of input collection elements flows into a single execution of the content of the <see cref="ExpansionRegion"/>, in the order of the collection elements if the input collections are ordered.
        /// </summary>
        Stream
    }     
}