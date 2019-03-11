// -------------------------------------------------------------------------------------------------
// <copyright file="LinkEndCreationData.cs" company="RHEA System S.A.">
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
    using Uml.Attributes;
    using Uml.Classification;

    /// <summary>
    /// <see cref="LinkEndCreationData"/> is <see cref="LinkEndData"/> used to provide values for one end of a link to be created by a <see cref="CreateLinkAction"/>.
    /// </summary>
    [Class(IsAbstract = false, IsActive = false, Specializations = "")]
    public interface LinkEndCreationData : LinkEndData
    {
        /// <summary>
        /// For ordered Association ends, the <see cref="InputPin"/> that provides the position where the new link should be inserted or where an existing link should be moved to. The type of the insertAt <see cref="InputPin"/> is UnlimitedNatural, but the input cannot be zero. It is omitted for Association ends that are not ordered.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        InputPin InsertAt { get; set; }

        /// <summary>
        /// Specifies whether the existing links emanating from the object on this end should be destroyed before creating a new link.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        bool IsReplaceAll { get; set; }
    }
}