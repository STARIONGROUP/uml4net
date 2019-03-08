// -------------------------------------------------------------------------------------------------
// <copyright file="EnumerationLiteral.cs" company="RHEA System S.A.">
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
    using Uml.Attributes;
    using Uml.Classification;

    /// <summary>
    /// An <see cref="EnumerationLiteral"/> is a user-defined data value for an <see cref="Enumeration"/>.
    /// </summary>
    [Class(IsAbstract = false, IsActive = false, Specializations = "")]
    public interface EnumerationLiteral : InstanceSpecification
    {
        /// <summary>
        /// The classifier of this <see cref="EnumerationLiteral"/> derived to be equal to its <see cref="Enumeration"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = true, IsDerivedUnion = false, IsReadOnly = true, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "InstanceSpecification.Classifier")]
        Enumeration Classifier { get; }

        /// <summary>
        /// The <see cref="Enumeration"/> that this <see cref="EnumerationLiteral"/> is a member of.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "NamedElement.Namespace", RedefinedProperty = "")]
        Enumeration  Enumeration { get; set; }
    }
}