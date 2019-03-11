// -------------------------------------------------------------------------------------------------
// <copyright file="WriteStructuralFeatureAction.cs" company="RHEA System S.A.">
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
    /// <see cref="WriteStructuralFeatureAction"/> is an abstract class for <see cref="StructuralFeatureAction"/>s that change <see cref="StructuralFeature"/> values.
    /// </summary>
    [Class(IsAbstract = true, IsActive = false, Specializations = "AddStructuralFeatureValueAction|RemoveStructuralFeatureValueAction")]
    public interface WriteStructuralFeatureAction : StructuralFeatureAction
    {
        /// <summary>
        /// The <see cref="OutputPin"/> on which is put the input object as modified by the <see cref="WriteStructuralFeatureAction"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Action.Output", RedefinedProperty = "")]
        OwnerList<OutputPin> Result { get; set; }

        /// <summary>
        /// The <see cref="InputPin"/> that provides the value to be added or removed from the <see cref="StructuralFeature"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Action.Input", RedefinedProperty = "")]
        OwnerList<InputPin> Value { get; set; }
    }
}