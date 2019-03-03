// -------------------------------------------------------------------------------------------------
// <copyright file="AssociationClass.cs" company="RHEA System S.A.">
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
    /// A model element that has both Association and Class properties. An AssociationClass can be seen as an Association that also has Class properties, or as a Class that also has Association properties. It not only connects a set of Classifiers but also defines a set of Features that belong to the Association itself and not to any of the associated Classifiers.
    /// </summary>
    internal class AssociationClass : Implementation.CommonStructure.Element //, Uml.StructuredClassifiers.AssociationClass
    {
        /// <summary>
        /// Initializes a new instance of <see cref="AssociationClass"/>
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the <see cref="AssociationClass"/>
        /// </param>        
        public AssociationClass(string id) : base(id)
        {
        }
    }
}