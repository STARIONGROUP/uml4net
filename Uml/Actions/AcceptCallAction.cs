// -------------------------------------------------------------------------------------------------
// <copyright file="AcceptCallAction.cs" company="RHEA System S.A.">
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
    using Uml.Values;

    /// <summary>
    /// An <see cref="AcceptCallAction"/> is an <see cref="AcceptEventAction"/> that handles the receipt of a synchronous call request. In addition to the values from the <see cref="Operation"/> input parameters, the <see cref="Action"/> produces an output that is needed later to supply the information to the <see cref="ReplyAction"/> necessary to return control to the caller. An <see cref="AcceptCallAction"/> is for synchronous calls. If it is used to handle an asynchronous call, execution of the subsequent <see cref="ReplyAction"/> will complete immediately with no effect.
    /// </summary>
    [Class(IsAbstract = false, IsActive = false, Specializations = "")]
    public interface AcceptCallAction : AcceptEventAction
    {
        /// <summary>
        /// An <see cref="OutputPin"/> where a value is placed containing sufficient information to perform a subsequent <see cref="ReplyAction"/> and return control to the caller. The contents of this value are opaque. It can be passed and copied but it cannot be manipulated by the model.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Action.Output", RedefinedProperty = "")]
        OwnerList<OutputPin> ReturnInformation { get; set; }
    }
}