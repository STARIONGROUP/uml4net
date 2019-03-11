// -------------------------------------------------------------------------------------------------
// <copyright file="CallAction.cs" company="RHEA System S.A.">
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
    /// <see cref="CallAction"/> is an abstract class for <see cref="Action"/>s that invoke a <see cref="Behavior"/> with given argument values and (if the invocation is synchronous) receive reply values.
    /// </summary>
    [Class(IsAbstract = true, IsActive = false, Specializations = "CallBehaviorAction|CallOperationAction|StartObjectBehaviorAction")]
    public interface CallAction : InvocationAction
    {
        /// <summary>
        /// If true, the call is synchronous and the caller waits for completion of the invoked <see cref="Behavior"/>. If false, the call is asynchronous and the caller proceeds immediately and cannot receive return values.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        bool IsSynchronous { get; set; }

        /// <summary>
        /// The <see cref="OutputPin"/>s on which the reply values from the invocation are placed (if the call is synchronous).
        /// </summary>
        [MultiplicityElement(IsOrdered = true, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Action.Output", RedefinedProperty = "")]
        OwnerList<OutputPin> Result { get; set; }
    }
}