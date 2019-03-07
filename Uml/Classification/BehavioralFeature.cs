// -------------------------------------------------------------------------------------------------
// <copyright file="BehavioralFeature.cs" company="RHEA System S.A.">
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

namespace Uml.Classification
{
    using System.Collections.Generic;
    using Uml.Assembler;
    using Uml.Attributes;
    using Uml.CommonBehavior;
    using Uml.CommonStructure;

    /// <summary>
    /// A substitution is a relationship between two classifiers signifying that the substituting classifier complies with the contract specified by the contract classifier. This implies that instances of the substituting classifier are runtime substitutable where instances of the contract classifier are expected.
    /// </summary>
    [Class(IsAbstract = true, IsActive = false, Specializations = "Operation|Reception")]
    public interface BehavioralFeature : Feature, Namespace
    {
        /// <summary>
        /// Specifies the semantics of concurrent calls to the same passive instance (i.e., an instance originating from a <see cref="Class"/> with isActive being false). Active instances control access to their own <see cref="BehavioralFeatures"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        CallConcurrencyKind Concurrency { get; set; }

        /// <summary>
        /// If true, then the BehavioralFeature does not have an implementation, and one must be supplied by a more specific <see cref="Classifier"/>. If false, the <see cref="BehavioralFeature"/> must have an implementation in the <see cref="Classifier"/> or one must be inherited.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        bool IsAbstract { get; set; }

        /// <summary>
        /// A <see cref="Behavior"/> that implements the <see cref="BehavioralFeature"/>. There may be at most one <see cref="Behavior"/> for a particular pairing of a <see cref="Classifier"/> (as owner of the Behavior) and a <see cref="BehavioralFeature"/> (as specification of the <see cref="Behavior"/>).
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        List<Behavior> Method { get; set; }

        /// <summary>
        /// The ordered set of formal <see cref="Parameter"/>s of this <see cref="BehavioralFeature"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = true, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Namespace.OwnedMember", RedefinedProperty = "")]
        OwnerList<Parameter> OwnedParameter { get; set; }

        /// <summary>
        /// The <see cref="ParameterSet"/>s owned by this <see cref="BehavioralFeature"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Namespace.OwnedMember", RedefinedProperty = "")]
        OwnerList<ParameterSet> OwnedParameterSet { get; set; }

        /// <summary>
        /// The <see cref="Type"/>s representing exceptions that may be raised during an invocation of this <see cref="BehavioralFeature"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        List<Type> RaisedException { get; set; }
    }
}