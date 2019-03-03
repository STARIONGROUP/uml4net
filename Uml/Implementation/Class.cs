// -------------------------------------------------------------------------------------------------
// <copyright file="Class.cs" company="RHEA System S.A.">
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

namespace Implementation.StructuredClassifiers
{
    using Uml.CommonStructure;

    /// <summary>
    /// A Class classifies a set of objects and specifies the features that characterize the structure and behavior of those objects.  A Class may have an internal structure and Ports.
    /// </summary>
    internal class Class : Implementation.CommonStructure.Element //, Uml.StructuredClassifiers.Class
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Class"/>
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the <see cref="Class"/>
        /// </param>        
        public Class(string id) : base(id)
        {
        }
    }
}