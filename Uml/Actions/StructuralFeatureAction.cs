// -------------------------------------------------------------------------------------------------
// <copyright file="StructuralFeatureAction.cs" company="RHEA System S.A.">
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
    /// <see cref="StructuralFeatureAction"/> is an abstract class for all <see cref="Action"/>s that operate on <see cref="StructuralFeature"/>s.
    /// </summary>
    public interface StructuralFeatureAction : Action
    {
        /// <summary>
        /// The <see cref="InputPin"/> from which the object whose <see cref="StructuralFeature"/> is to be read or written is obtained.
        /// </summary>
        OwnerList<InputPin> Object { get; set; }

        /// <summary>
        /// The <see cref="StructuralFeature"/> to be read or written.
        /// </summary>
        StructuralFeature StructuralFeature { get; set; } 
    }
}