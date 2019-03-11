// -------------------------------------------------------------------------------------------------
// <copyright file="RemoveStructuralFeatureValueAction.cs" company="RHEA System S.A.">
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
    using Uml.Attributes;
    using Uml.Classification;

    /// <summary>
    /// A <see cref="RemoveStructuralFeatureValueAction"/> is a <see cref="WriteStructuralFeatureAction"/> that removes values from a <see cref="StructuralFeature"/>.
    /// </summary>
    [Class(IsAbstract = false, IsActive = false, Specializations = "")]
    public interface RemoveStructuralFeatureValueAction : WriteStructuralFeatureAction
    {
        /// <summary>
        /// Specifies whether to remove duplicates of the value in nonunique <see cref="StructuralFeature"/>s.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        bool IsRemoveDuplicates { get; set; }

        /// <summary>
        /// An <see cref="InputPin"/> that provides the position of an existing value to remove in ordered, nonunique structural features. The type of the removeAt InputPin is UnlimitedNatural, but the value cannot be zero or unlimited.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Action.Input", RedefinedProperty = "")]
        OwnerList<InputPin> RemoveAt { get; set; }
    }
}