// -------------------------------------------------------------------------------------------------
// <copyright file="Pseudostate.cs" company="RHEA System S.A.">
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

    /// <summary>
    /// A <see cref="Pseudostate"/> is an abstraction that encompasses different types of transient Vertices in the <see cref="StateMachine"/> graph. A <see cref="StateMachine"/> instance never comes to rest in a <see cref="Pseudostate"/>, instead, it will exit and enter the <see cref="Pseudostate"/> within a single run-to-completion step.
    /// </summary>
    [Class(IsAbstract = false, IsActive = false, Specializations = "")]
    public interface Pseudostate : Vertex
    {
        /// <summary>
        /// Determines the precise type of the <see cref="Pseudostate"/> and can be one of: entryPoint, exitPoint, initial, deepHistory, shallowHistory, join, fork, junction, terminate or choice.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        PseudostateKind Kind { get; set; }

        /// <summary>
        /// The <see cref="State"/> that owns this <see cref="Pseudostate"/> and in which it appears.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "NamedElement.Namespace", RedefinedProperty = "")]
        State State { get; set; }

        /// <summary>
        /// The StateMachine in which this <see cref="Pseudostate"/> is defined. This only applies to <see cref="Pseudostate"/>s of the kind entryPoint or exitPoint.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "NamedElement.Namespace", RedefinedProperty = "")]
        StateMachine StateMachine { get; set; }
    }
}