// -------------------------------------------------------------------------------------------------
// <copyright file="ObjectNode.cs" company="RHEA System S.A.">
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

namespace Uml.Activities
{
    using System.Collections.Generic;    
    using Uml.Assembler;
    using Uml.Attributes;
    using Uml.Classification;
    using Uml.CommonBehavior;
    using Uml.CommonStructure;
    using Uml.StateMachines;
    using Uml.Values;

    /// <summary>
    /// An <see cref="ObjectNode"/> is an abstract <see cref="ActivityNode"/> that may hold tokens within the object flow in an <see cref="Activity"/>. <see cref="ObjectNode"/>s also support token selection, limitation on the number of tokens held, specification of the state required for tokens being held, and carrying control values.
    /// </summary>
    [Class(IsAbstract = true, IsActive = false, Specializations = "ActivityParameterNode|CentralBufferNode|ExpansionNode|Pin")]
    public interface ObjectNode : TypedElement, ActivityNode
    {
        /// <summary>
        /// The <see cref="State"/>s required to be associated with the values held by tokens on this <see cref="ObjectNode"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        List<State> InState { get; set; }

        /// <summary>
        /// Indicates whether the type of the <see cref="ObjectNode"/> is to be treated as representing control values that may traverse <see cref="ControlFlow"/>s.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        bool IsControlType { get; set; }

        /// <summary>
        /// Indicates how the tokens held by the <see cref="ObjectNode"/> are ordered for selection to traverse <see cref="ActivityEdge"/>s outgoing from the <see cref="ObjectNode"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        ObjectNodeOrderingKind Ordering { get; set; }

        /// <summary>
        /// A <see cref="Behavior"/> used to select tokens to be offered on outgoing <see cref="ActivityEdge"/>s.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        Behavior Selection { get; set; }

        /// <summary>
        /// The maximum number of tokens that may be held by this <see cref="ObjectNode"/>. Tokens cannot flow into the <see cref="ObjectNode"/> if the upperBound is reached. If no upperBound is specified, then there is no limit on how many tokens the <see cref="ObjectNode"/> can hold.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Element.OwnedElement", RedefinedProperty = "")]
        OwnerList<ValueSpecification> UpperBound { get; set; }
    }
}