// -------------------------------------------------------------------------------------------------
// <copyright file="Vertex.cs" company="RHEA System S.A.">
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
    using System.Collections.Generic;
    using Uml.Attributes;
    using Uml.Classification;
    using Uml.CommonStructure;

    /// <summary>
    /// A <see cref="Vertex"/> is an abstraction of a node in a <see cref="StateMachine"/> graph. It can be the source or destination of any number of Transitions.
    /// </summary>
    [Class(IsAbstract = true, IsActive = false, Specializations = "ConnectionPointReference|Pseudostate|State")]
    public interface Vertex : NamedElement, RedefinableElement
    {
        /// <summary>
        /// The <see cref="Region"/> that contains this <see cref="Vertex"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "NamedElement.Namespace", RedefinedProperty = "")]
        Region Container { get; set; }

        /// <summary>
        /// Specifies the <see cref="Transition"/>s entering this <see cref="Vertex"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = true, IsDerivedUnion = false, IsReadOnly = true, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        IEnumerable<Transition> Incoming { get; }

        /// <summary>
        /// Specifies the <see cref="Transition"/>s departing from this <see cref="Vertex"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = true, IsDerivedUnion = false, IsReadOnly = true, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        IEnumerable<Transition> Outgoing { get; }

        /// <summary>
        /// References the <see cref="Classifier"/> in which context this element may be redefined.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = true, IsDerivedUnion = false, IsReadOnly = true, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "RedefinableElement.RedefinitionContext")]
        Classifier RedefinitionContext { get; }

        /// <summary>
        /// The <see cref="Vertex"/> of which this <see cref="Vertex"/> is a redefinition.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "RedefinableElement.RedefinedElement", RedefinedProperty = "")]
        Vertex RedefinedVertex { get; set; }
    }
}