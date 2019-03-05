// -------------------------------------------------------------------------------------------------
// <copyright file="Namespace.cs" company="RHEA System S.A.">
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

namespace Uml.CommonStructure
{
    using System.Collections.Generic;
    using Uml.Assembler;
    using Uml.Attributes;
    using Uml.Classification;

    /// <summary>
    /// A <see cref="Namespace"/> is an <see cref="Element"/> in a model that owns and/or imports a set of <see cref="NamedElement"/>s that can be identified by name.
    /// </summary>
    [Class(IsAbstract = true, IsActive = false, Specializations = "Region|State|Transition|Package|InteractionOperand|BehavioralFeature|Classifier|StructuredActivityNode")]
    public interface Namespace : NamedElement
    {
        /// <summary>
        /// References the <see cref="ElementImport"/>s owned by the <see cref="Namespace"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Element.OwnedElement", RedefinedProperty = "")]
        OwnerList<ElementImport> ElementImport { get; set; }

        /// <summary>
        /// References the <see cref="PackageableElement"/>s that are members of this <see cref="Namespace"/> as a result of either <see cref="PackageImport"/>s or <see cref="ElementImport"/>s.
        /// </summary>
        /// <remarks>
        /// Derived Property.
        /// </remarks>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = true, IsDerivedUnion = false, IsReadOnly = true, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "Namespace.Member", RedefinedProperty = "")]
        IEnumerable<PackageableElement> ImportedMember();

        /// <summary>
        /// A collection of <see cref="NamedElement"/>s identifiable within the <see cref="Namespace"/>, either by being owned or by being introduced by importing or inheritance.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = true, IsDerivedUnion = true, IsReadOnly = true, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        IEnumerable<NamedElement> Member();

        /// <summary>
        /// A collection of <see cref="NamedElement"/>s owned by the <see cref="Namespace"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = true, IsDerivedUnion = true, IsReadOnly = true, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Namespace.Member|Element.OwnedElement", RedefinedProperty = "")]
        IEnumerable<NamedElement> OwnedMember();

        /// <summary>
        /// Specifies a set of <see cref="Constraint"/>s owned by this <see cref="Namespace"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Namespace.OwnedMember", RedefinedProperty = "")]
        OwnerList<Constraint> OwnedRule { get; set; }

        /// <summary>
        /// References the <see cref="PackageImport"/>s owned by the <see cref="Namespace"/>.
        /// </summary>        
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Element.OwnedElement", RedefinedProperty = "")]
        OwnerList<PackageImport> PackageImport { get; set; }
    }
}