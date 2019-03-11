// -------------------------------------------------------------------------------------------------
// <copyright file="ReplyAction.cs" company="RHEA System S.A.">
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
    using Uml.CommonBehavior;

    /// <summary>
    /// A <see cref="ReplyAction"/> is an <see cref="Action"/> that accepts a set of reply values and a value containing return information produced by a previous <see cref="AcceptCallAction"/>. The <see cref="ReplyAction"/> returns the values to the caller of the previous call, completing execution of the call.
    /// </summary>
    [Class(IsAbstract = false, IsActive = false, Specializations = "")]
    public interface ReplyAction : Action
    {
        /// <summary>
        /// The <see cref="Trigger"/> specifying the <see cref="Operation"/> whose call is being replied to.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        Trigger ReplyToCall { get; set; }

        /// <summary>
        /// A list of <see cref="InputPin"/>s providing the values for the output (inout, out, and return) <see cref="Parameter"/>s of the <see cref="Operation"/>. These values are returned to the caller.
        /// </summary>
        [MultiplicityElement(IsOrdered = true, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Action.Input", RedefinedProperty = "")]
        OwnerList<InputPin> ReplyValue { get; set; }

        /// <summary>
        /// An <see cref="InputPin"/> that holds the return information value produced by an earlier <see cref="AcceptCallAction"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Action.Input", RedefinedProperty = "")]
        OwnerList<InputPin> ReturnInformation { get; set; }
    }
}