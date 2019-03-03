// -------------------------------------------------------------------------------------------------
// <copyright file="ComponentRealization.cs" company="RHEA System S.A.">
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
    /// Realization is specialized to (optionally) define the Classifiers that realize the contract offered by a Component in terms of its provided and required Interfaces. The Component forms an abstraction from these various Classifiers.
    /// </summary>
    internal class ComponentRealization : Implementation.CommonStructure.Element //, Uml.StructuredClassifiers.ComponentRealization
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ComponentRealization"/>
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the <see cref="ComponentRealization"/>
        /// </param>        
        public ComponentRealization(string id) : base(id)
        {
        }
    }
}