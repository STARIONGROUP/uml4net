// -------------------------------------------------------------------------------------------------
// <copyright file="Region.cs" company="RHEA System S.A.">
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
    using Uml.Assembler;
    using Uml.Attributes;
    using Uml.Classification;
    using Uml.CommonStructure;
    using Uml.StructuredClassifiers;

    /// <summary>
    /// A <see cref="Region"/> is a top-level part of a <see cref="StateMachine"/> or a composite <see cref="State"/>, that serves as a container for the Vertices and <see cref="Transition"/>s of the <see cref="StateMachine"/>. A <see cref="StateMachine"/> or composite State may contain multiple <see cref="Region"/>s representing behaviors that may occur in parallel.
    /// </summary>
    [Class(IsAbstract = false, IsActive = false, Specializations = "")]
    public interface Region : Namespace, RedefinableElement
    {
        /// <summary>
        /// The region of which this region is an extension.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "RedefinableElement.RedefinedElement", RedefinedProperty = "")]
        Region ExtendedRegion { get; set; }

        /// <summary>
        /// References the <see cref="Classifier"/> in which context this element may be redefined.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = true, IsDerivedUnion = false, IsReadOnly = true, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "RedefinableElement.RedefinitionContext")]
        Class RedefinitionContext { get; }

        /// <summary>
        /// The <see cref="State"/> that owns the <see cref="Region"/>. If a Region is owned by a <see cref="State"/>, then it cannot also be owned by a <see cref="StateMachine"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "NamedElement.Namespace", RedefinedProperty = "")]
        State State { get; set; }

        /// <summary>
        /// The <see cref="StateMachine"/> that owns the <see cref="Region"/>. If a Region is owned by a <see cref="StateMachine"/>, then it cannot also be owned by a <see cref="State"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "NamedElement.Namespace", RedefinedProperty = "")]
        StateMachine StateMachine { get; set; }

        /// <summary>
        /// The set of Vertices that are owned by this <see cref="Region"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Namespace.OwnedMember", RedefinedProperty = "")]
        OwnerList<Vertex> SubVertex { get; set; }

        /// <summary>
        /// The set of <see cref="Transition"/>s owned by the <see cref="Region"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Namespace.OwnedMember", RedefinedProperty = "")]
        OwnerList<Transition> Transition { get; set; }
    }
} 