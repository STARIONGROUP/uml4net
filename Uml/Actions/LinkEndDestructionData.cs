// -------------------------------------------------------------------------------------------------
// <copyright file="LinkEndDestructionData.cs" company="RHEA System S.A.">
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
    using Uml.StructuredClassifiers;

    /// <summary>
    /// <see cref="LinkEndDestructionData"/> is <see cref="LinkEndData"/> used to provide values for one end of a link to be destroyed by a <see cref="DestroyLinkAction"/>.
    /// </summary>
    [Class(IsAbstract = false, IsActive = false, Specializations = "")]
    public interface LinkEndDestructionData : LinkEndData
    {
        /// <summary>
        /// The <see cref="InputPin"/> that provides the position of an existing link to be destroyed in an ordered, nonunique <see cref="Association"/> end. The type of the destroyAt <see cref="InputPin"/> is UnlimitedNatural, but the value cannot be zero or unlimited.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        InputPin DestroyAt { get; set; }

        /// <summary>
        /// Specifies whether to destroy duplicates of the value in nonunique <see cref="Association"/> ends.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        bool IsDestroyDuplicates { get; set; }
    }
}