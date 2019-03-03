// -------------------------------------------------------------------------------------------------
// <copyright file="UnmarshallAction.cs" company="RHEA System S.A.">
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
    using Uml.Classification;

    /// <summary>
    /// An <see cref="UnmarshallAction"/> is an <see cref="Action"/> that retrieves the values of the <see cref="StructuralFeature"/>s of an object and places them on <see cref="OutputPin"/>s. 
    /// </summary>
    public interface UnmarshallAction : Action
    {
        /// <summary>
        /// The <see cref="InputPin"/> that gives the object to be unmarshalled.
        /// </summary>
        OwnerList<InputPin> Object { get; set; }

        /// <summary>
        /// The <see cref="OutputPin"/>s on which are placed the values of the <see cref="StructuralFeature"/>s of the input object.
        /// </summary>
        OwnerList<OutputPin> Result { get; set; }

        /// <summary>
        /// The type of the object to be unmarshalled.
        /// </summary>
        Classifier UnmarshallType { get; set; }
    }
}