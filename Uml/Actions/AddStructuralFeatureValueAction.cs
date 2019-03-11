// -------------------------------------------------------------------------------------------------
// <copyright file="AddStructuralFeatureValueAction.cs" company="RHEA System S.A.">
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
    /// An <see cref="AddStructuralFeatureValueAction"/> is a <see cref="WriteStructuralFeatureAction"/> for adding values to a <see cref="StructuralFeature"/>.
    /// </summary>
    [Class(IsAbstract = false, IsActive = false, Specializations = "")]
    public interface AddStructuralFeatureValueAction : WriteStructuralFeatureAction
    {
        /// <summary>
        /// The <see cref="InputPin"/> that gives the position at which to insert the value in an ordered <see cref="StructuralFeature"/>. The type of the insertAt <see cref="InputPin"/> is UnlimitedNatural, but the value cannot be zero. It is omitted for unordered <see cref="StructuralFeature"/>s.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Action.Input", RedefinedProperty = "")]
        OwnerList<InputPin> InsertAt { get; set; }

        /// <summary>
        /// Specifies whether existing values of the <see cref="StructuralFeature"/> should be removed before adding the new value.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        bool IsReplaceAll { get; set; }
    }
}