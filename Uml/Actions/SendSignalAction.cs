// -------------------------------------------------------------------------------------------------
// <copyright file="SendSignalAction.cs" company="RHEA System S.A.">
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
    using Uml.SimpleClassifiers;

    /// <summary>
    /// A <see cref="SendSignalAction"/> is an <see cref="InvocationAction"/> that creates a <see cref="Signal"/> instance and transmits it to the target object. Values from the argument <see cref="InputPin"/>s are used to provide values for the attributes of the <see cref="Signal"/>. The requestor continues execution immediately after the <see cref="Signal"/> instance is sent out and cannot receive reply values.
    /// </summary>
    [Class(IsAbstract = false, IsActive = false, Specializations = "")]
    public interface SendSignalAction : InvocationAction
    {
        /// <summary>
        /// The <see cref="Signal"/> whose instance is transmitted to the target.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        Signal Signal { get; set; }

        /// <summary>
        /// The <see cref="InputPin"/> that provides the target object to which the Signal instance is sent.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Action.Input", RedefinedProperty = "")]
        OwnerList<InputPin> Target { get; set; }
    }
}