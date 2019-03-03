// -------------------------------------------------------------------------------------------------
// <copyright file="DataType.cs" company="RHEA System S.A.">
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
    using Uml.Classification;

    /// <summary>
    /// A DataType is a type whose instances are identified only by their value.
    /// </summary>
    public interface DataType : Classifier
    {
        /// <summary>
        /// The attributes owned by the <see cref="DataType"/>.
        /// </summary>
        OwnerList<Property> OwnedAttribute { get; set; }

        /// <summary>
        /// The <see cref="Operation"/>s owned by the <see cref="DataType"/>.
        /// </summary>
        OwnerList<Operation> OwnedOperation { get; set; }
    }
}