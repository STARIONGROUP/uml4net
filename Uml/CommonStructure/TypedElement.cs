// -------------------------------------------------------------------------------------------------
// <copyright file="TypedElement.cs" company="RHEA System S.A.">
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
    using Uml.Attributes;
    using Uml.Classification;

    /// <summary>
    /// A <see cref="TypedElement"/> is a <see cref="NamedElement"/> that may have a <see cref="Type"/> specified for it.
    /// </summary>
    [Class(IsAbstract = true, IsActive = false, Specializations = "ObjectNode|ValueSpecification|ConnectableElement|StructuralFeature")]
    public interface TypedElement : NamedElement
    {
        /// <summary>
        /// The type of the <see cref="TypedElement"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        Type Type { get; set; }
    }
}