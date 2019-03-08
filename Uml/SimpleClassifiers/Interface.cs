// -------------------------------------------------------------------------------------------------
// <copyright file="Interface.cs" company="RHEA System S.A.">
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

namespace Uml.SimpleClassifiers
{
    using System.Collections.Generic;
    using Uml.Assembler;
    using Uml.Attributes;
    using Uml.Classification;
    using Uml.StateMachines;

    /// <summary>
    /// Interfaces declare coherent services that are implemented by <see cref="BehavioredClassifier"/>s that implement the <see cref="Interface"/>s via <see cref="InterfaceRealization"/>s.
    /// </summary>
    [Class(IsAbstract = false, IsActive = false, Specializations = "")]
    public interface Interface : Classifier
    {
        /// <summary>
        /// References all the Classifiers that are defined (nested) within the Interface.
        /// </summary>
        [MultiplicityElement(IsOrdered = true, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Namespace.OwnedMember", RedefinedProperty = "")]
        OwnerList<Classifier> NestedClassifier { get; set; }

        /// <summary>
        /// The attributes (i.e., the Properties) owned by the <see cref="Interface"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = true, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Classifier.Attribute|Namespace.OwnedMember", RedefinedProperty = "")]
        OwnerList<Property> OwnedAttribute { get; set; }

        /// <summary>
        /// The <see cref="Operation"/>s owned by the <see cref="Interface"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = true, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Classifier.Feature|Namespace.OwnedMember", RedefinedProperty = "")]
        OwnerList<Operation> OwnedOperation { get; set; }

        /// <summary>
        /// <see cref="Reception"/>s that objects providing this <see cref="Interface"/> are willing to accept.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Classifier.Feature|Namespace.OwnedMember", RedefinedProperty = "")]
        OwnerList<Reception> OwnedReception { get; set; }

        /// <summary>
        /// References a <see cref="ProtocolStateMachine"/> specifying the legal sequences of the invocation of the <see cref="BehavioralFeature"/>s described in the <see cref="Interface"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Namespace.OwnedMember", RedefinedProperty = "")]
        OwnerList<ProtocolStateMachine> Protocol { get; set; }

        /// <summary>
        /// References all the <see cref="Interface"/>s redefined by this <see cref="Interface"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "Classifier.RedefinedClassifier", RedefinedProperty = "")]
        List<Interface> RedefinedInterface { get; set; }
    }
}