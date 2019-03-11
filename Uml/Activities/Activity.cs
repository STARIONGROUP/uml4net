// -------------------------------------------------------------------------------------------------
// <copyright file="Activity.cs" company="RHEA System S.A.">
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
    using Uml.Actions;
    using Uml.Assembler;
    using Uml.Attributes;
    using Uml.Classification;
    using Uml.CommonBehavior;

    /// <summary>
    /// An <see cref="Activity"/> is the specification of parameterized <see cref="Behavior"/> as the coordinated sequencing of subordinate units.
    /// </summary>
    [Class(IsAbstract = false, IsActive = false, Specializations = "")]
    public interface Activity : Behavior
    {
        /// <summary>
        /// <see cref="ActivityEdge"/>s expressing flow between the nodes of the <see cref="Activity"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Element.OwnedElement", RedefinedProperty = "")]
        OwnerList<ActivityEdge> Edge { get; set; }

        /// <summary>
        /// Top-level <see cref="ActivityGroup"/>s in the <see cref="Activity"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Element.OwnedElement", RedefinedProperty = "")]
        OwnerList<ActivityGroup> Group { get; set; }

        /// <summary>
        /// If true, this <see cref="Activity"/> must not make any changes to objects. The default is false (an Activity may make nonlocal changes). (This is an assertion, not an executable property. It may be used by an execution engine to optimize model execution. If the assertion is violated by the <see cref="Activity"/>, then the model is ill-formed.) 
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        bool IsReadOnly { get; set;  }

        /// <summary>
        /// If true, all invocations of the <see cref="Activity"/> are handled by the same execution.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        bool IsSingleExecution { get; set; }

        /// <summary>
        /// <see cref="ActivityNode"/>s coordinated by the <see cref="Activity"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Element.OwnedElement", RedefinedProperty = "")]
        OwnerList<ActivityNode> Node { get; set; }

        /// <summary>
        /// Top-level <see cref="ActivityPartition"/>s in the <see cref="Activity"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "Activity.Group", RedefinedProperty = "")]
        List<ActivityPartition> Partition { get; set; }

        /// <summary>
        /// Top-level <see cref="ActivityPartition"/>s in the <see cref="Activity"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Activity.Group|Activity.Node", RedefinedProperty = "")]
        OwnerList<StructuredActivityNode> StructuredNode { get; set; }

        /// <summary>
        /// Top-level <see cref="Variable"/>s defined by the <see cref="Activity"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Namespace.OwnedMember", RedefinedProperty = "")]
        OwnerList<Variable> Variable { get; set; }
    }
}