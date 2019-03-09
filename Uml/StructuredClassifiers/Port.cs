// -------------------------------------------------------------------------------------------------
// <copyright file="Port.cs" company="RHEA System S.A.">
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

namespace Uml.StructuredClassifiers
{
    using System.Collections.Generic;
    using Uml.Attributes;
    using Uml.Classification;
    using Uml.CommonStructure;
    using Uml.SimpleClassifiers;
    using Uml.StateMachines;

    /// <summary>
    /// A <see cref="Port"/> is a property of an <see cref="EncapsulatedClassifier"/> that specifies a distinct interaction point between that <see cref="EncapsulatedClassifier"/> and its environment or between the (behavior of the) <see cref="EncapsulatedClassifier"/> and its internal parts. <see cref="Port"/>s are connected to Properties of the <see cref="EncapsulatedClassifier"/> by <see cref="Connector"/>s through which requests can be made to invoke <see cref="BehavioralFeature"/>s. A <see cref="Port"/> may specify the services an <see cref="EncapsulatedClassifier"/> provides (offers) to its environment as well as the services that an <see cref="EncapsulatedClassifier"/> expects (requires) of its environment.  A <see cref="Port"/> may have an associated <see cref="ProtocolStateMachine"/>.
    /// </summary>
    [Class(IsAbstract = false, IsActive = false, Specializations = "Class")]
    public interface Port : Property
    {
        /// <summary>
        /// Specifies whether requests arriving at this <see cref="Port"/> are sent to the classifier behavior of this <see cref="EncapsulatedClassifier"/>. Such a Port is referred to as a behavior <see cref="Port"/>. Any invocation of a <see cref="BehavioralFeature"/> targeted at a behavior <see cref="Port"/> will be handled by the instance of the owning <see cref="EncapsulatedClassifier"/> itself, rather than by any instances that it may contain.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        bool IsBehavior { get; set; }

        /// <summary>
        /// Specifies the way that the provided and required <see cref="Interface"/>s are derived from the <see cref="Port"/>’s <see cref="Type"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        bool IsConjugated { get; set; }

        /// <summary>
        /// If true, indicates that this Port is used to provide the published functionality of an <see cref="EncapsulatedClassifier"/>. If false, this <see cref="Port"/> is used to implement the <see cref="EncapsulatedClassifier"/> but is not part of the essential externally-visible functionality of the <see cref="EncapsulatedClassifier"/> and can, therefore, be altered or deleted along with the internal implementation of the <see cref="EncapsulatedClassifier"/> and other properties that are considered part of its implementation.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        bool IsService { get; set; }

        /// <summary>
        /// An optional <see cref="ProtocolStateMachine"/> which describes valid interactions at this interaction point.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        ProtocolStateMachine Protocol { get; set; }

        /// <summary>
        /// The <see cref="Interface"/>s specifying the set of <see cref="Operation"/>s and <see cref="Reception"/>s that the <see cref="EncapsulatedClassifier"/> offers to its environment via this <see cref="Port"/>, and which it will handle either directly or by forwarding it to a part of its internal structure. This association is derived according to the value of <see cref="IsConjugated"/>. If <see cref="IsConjugated"/> is false, provided is derived as the union of the sets of <see cref="Interface"/>s realized by the type of the port and its supertypes, or directly from the type of the <see cref="Port"/> if the Port is typed by an <see cref="Interface"/>. If <see cref="IsConjugated"/> is true, it is derived as the union of the sets of <see cref="Interface"/>s used by the type of the <see cref="Port"/> and its supertypes.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = true, IsDerivedUnion = false, IsReadOnly = true, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        IEnumerable<Interface> Provided { get; }

        /// <summary>
        /// A <see cref="Port"/> may be redefined when its containing <see cref="EncapsulatedClassifier"/> is specialized. The redefining <see cref="Port"/> may have additional <see cref="Interface"/>s to those that are associated with the redefined Port or it may replace an <see cref="Interface"/> by one of its subtypes.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "Property.RedefinedProperty", RedefinedProperty = "")]
        List<Port> RedefinedPort { get; set; }

        /// <summary>
        /// The <see cref="Interface"/>s specifying the set of <see cref="Operation"/>s and <see cref="Reception"/>s that the <see cref="EncapsulatedClassifier"/> expects its environment to handle via this port. This association is derived according to the value of <see cref="IsConjugated"/>. If <see cref="IsConjugated"/> is false, required is derived as the union of the sets of <see cref="Interface"/>s used by the type of the <see cref="Port"/> and its supertypes. If <see cref="IsConjugated"/> is true, it is derived as the union of the sets of <see cref="Interface"/>s realized by the type of the <see cref="Port"/> and its supertypes, or directly from the type of the Port if the <see cref="Port"/> is typed by an <see cref="Interface"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = true, IsDerivedUnion = false, IsReadOnly = true, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        IEnumerable<Interface> Required { get; }
    }
}