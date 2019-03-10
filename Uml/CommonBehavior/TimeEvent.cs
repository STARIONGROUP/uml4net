// -------------------------------------------------------------------------------------------------
// <copyright file="TimeEvent.cs" company="RHEA System S.A.">
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

namespace Uml.CommonBehavior
{
    using Uml.Assembler;
    using Uml.Attributes;
    using Uml.Classification;
    using Uml.Values;

    /// <summary>
    /// A <see cref="TimeEvent"/> is an <see cref="Event"/> that occurs at a specific point in time.
    /// </summary>
    [Class(IsAbstract = false, IsActive = false, Specializations = "")]
    public interface TimeEvent : Event
    {
        /// <summary>
        /// Specifies whether the <see cref="TimeEvent"/> is specified as an absolute or relative time.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        bool IsRelative { get; set; }

        /// <summary>
        /// Specifies the time of the <see cref="Specifies the time of the TimeEvent."/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Element.OwnedElement", RedefinedProperty = "")]
        OwnerList<TimeExpression> When { get; set; }
    }
}