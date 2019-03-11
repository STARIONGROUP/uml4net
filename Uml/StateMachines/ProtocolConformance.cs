// -------------------------------------------------------------------------------------------------
// <copyright file="ProtocolConformance.cs" company="RHEA System S.A.">
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

namespace Uml.StateMachines
{
    using Uml.Attributes;
    using Uml.Classification;
    using Uml.CommonStructure;

    /// <summary>
    /// A <see cref="ProtocolStateMachine"/> can be redefined into a more specific <see cref="ProtocolStateMachine"/> or into behavioral <see cref="StateMachine"/>. <see cref="ProtocolConformance"/> declares that the specific <see cref="ProtocolStateMachine"/> specifies a protocol that conforms to the general <see cref="ProtocolStateMachine"/> or that the specific behavioral <see cref="StateMachine"/> abides by the protocol of the general <see cref="ProtocolStateMachine"/>.
    /// </summary>
    [Class(IsAbstract = false, IsActive = false, Specializations = "")]
    public interface ProtocolConformance : DirectedRelationship
    {
        /// <summary>
        /// Specifies the <see cref="ProtocolStateMachine"/> to which the specific <see cref="ProtocolStateMachine"/> conforms.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "DirectedRelationship.Target", RedefinedProperty = "")]
        ProtocolStateMachine GeneralMachine { get; set; }

        /// <summary>
        /// Specifies the <see cref="ProtocolStateMachine"/> which conforms to the general <see cref="ProtocolStateMachine"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "DirectedRelationship.Source|Element.Owner", RedefinedProperty = "")]
        ProtocolStateMachine SpecificMachine { get; set; }
    }
}