// -------------------------------------------------------------------------------------------------
// <copyright file="Enumeration.cs" company="RHEA System S.A.">
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

namespace Uml.SimpleClassifiers
{
    using Uml.Assembler;

    /// <summary>
    /// An Enumeration is a <see cref="DataType"/> whose values are enumerated in the model as <see cref="EnumerationLiteral"/>s.
    /// </summary>
    public interface Enumeration : DataType
    {
        /// <summary>
        /// The ordered set of literals owned by this <see cref="Enumeration"/>.
        /// </summary>
        OwnerList<EnumerationLiteral> OwnedLiteral { get; set; }
    }
}