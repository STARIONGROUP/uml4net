// -------------------------------------------------------------------------------------------------
// <copyright file="LiteralUnlimitedNatural.cs" company="RHEA System S.A.">
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

namespace Uml.Values
{
    using Uml.Attributes;
    using Uml.Classification;

    /// <summary>
    /// A <see cref="LiteralUnlimitedNatural"/> is a specification of an UnlimitedNatural number.
    /// </summary>
    [Class(IsAbstract = false, IsActive = false, Specializations = "")]
    public interface LiteralUnlimitedNatural : LiteralSpecification
    {
        /// <summary>
        /// The specified UnlimitedNatural value.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        string Value { get; set; }
    }
}