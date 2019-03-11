// -------------------------------------------------------------------------------------------------
// <copyright file="LinkAction.cs" company="RHEA System S.A.">
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
    /// <see cref="LinkAction"/> is an abstract class for all <see cref="Action"/>s that identify the links to be acted on using <see cref="LinkEndData"/>.
    /// </summary>
    [Class(IsAbstract = true, IsActive = false, Specializations = "WriteLinkAction|ReadLinkAction")]
    public interface LinkAction : Action
    {
        /// <summary>
        /// The <see cref="LinkEndData"/> identifying the values on the ends of the links acting on by this <see cref="LinkAction"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 2, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Element.OwnedElement", RedefinedProperty = "")]
        OwnerList<LinkEndData> EndData { get; set; }

        /// <summary>
        /// <see cref="InputPin"/>s used by the <see cref="LinkEndData"/> of the <see cref="LinkAction"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Action.Input", RedefinedProperty = "")]
        OwnerList<InputPin> InputValue { get; set; }
    }
}