// -------------------------------------------------------------------------------------------------
// <copyright file="Abstraction.cs" company="RHEA System S.A.">
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

namespace Uml.CommonStructure
{
    using Uml.Assembler;
    using Uml.Values;

    /// <summary>
    /// An <see cref="Abstraction"/> is a <see cref="Relationship"/> that relates two <see cref="Element"/>s or sets of <see cref="Element"/>s that represent the same concept at different levels of abstraction or from different viewpoints.
    /// </summary>
    public interface Abstraction : Dependency
    {
        /// <summary>
        /// An <see cref="OpaqueExpression"/> that states the abstraction relationship between the supplier(s) and the client(s). In some cases, such as derivation, it is usually formal and unidirectional; in other cases, such as trace, it is usually informal and bidirectional. The mapping expression is optional and may be omitted if the precise relationship between the Elements is not specified.
        /// </summary>
        OwnerList<OpaqueExpression> Mapping { get; set; }
    }
}