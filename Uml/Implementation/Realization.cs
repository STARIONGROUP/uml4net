// -------------------------------------------------------------------------------------------------
// <copyright file="Realization.cs" company="RHEA System S.A.">
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
    /// <summary>
    /// <see cref="Realization"/> is a specialized <see cref="Abstraction"/> relationship between two sets of model <see cref="Element"/>s, one representing a specification (the supplier) and the other represents an implementation of the latter (the client). Realization can be used to model stepwise refinement, optimizations, transformations, templates, model synthesis, framework composition, etc.
    /// </summary>
    internal class Realization : Implementation.CommonStructure.Abstraction, Uml.CommonStructure.Realization
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Realization"/> class.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the <see cref="Realization"/>
        /// </param>
        public Realization(string id) : base(id)
        {
        }
    }
}