// -------------------------------------------------------------------------------------------------
// <copyright file="Duration.cs" company="RHEA System S.A.">
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
    using System.Collections.Generic;
    using Uml.Assembler;
    using Uml.Attributes;
    using Uml.Classification;
    
    /// <summary>
    /// A <see cref="Duration"/> is a <see cref="ValueSpecification"/> that specifies the temporal distance between two time instants.
    /// </summary>
    [Class(IsAbstract = false, IsActive = false, Specializations = "")]
    public interface Duration : ValueSpecification
    {
        /// <summary>
        /// A <see cref="Duration"/> is a <see cref="ValueSpecification"/> that specifies the temporal distance between two time instants.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Element.OwnedElement", RedefinedProperty = "")]
        OwnerList<ValueSpecification> Expr { get; set; }

        /// <summary>
        /// Refers to the <see cref="Observation"/>s that are involved in the computation of the <see cref="Duration"/> value
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        List<Observation> Observation { get; set; }
    }
}