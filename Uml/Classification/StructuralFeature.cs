// -------------------------------------------------------------------------------------------------
// <copyright file="StructuralFeature.cs" company="RHEA System S.A.">
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

namespace Uml.Classification
{
    using Uml.CommonStructure;

    /// <summary>
    /// A StructuralFeature is a typed feature of a Classifier that specifies the structure of instances of the Classifier.
    /// </summary>
    public interface StructuralFeature : MultiplicityElement, TypedElement, Feature
    {
        /// <summary>
        /// If isReadOnly is true, the StructuralFeature may not be written to after initialization.
        /// </summary>
        bool IsReadOnly { get; set; }
    }
}