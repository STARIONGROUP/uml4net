// -------------------------------------------------------------------------------------------------
// <copyright file="Association.cs" company="RHEA System S.A.">
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
    using Uml.Assembler;
    using Uml.Attributes;
    using Uml.Classification;
    using Uml.CommonStructure;

    /// <summary>
    /// A link is a tuple of values that refer to typed objects.  An <see cref="Association"/> classifies a set of links, each of which is an instance of the Association.  Each value in the link refers to an instance of the type of the corresponding end of the Association.
    /// </summary>
    [Class(IsAbstract = false, IsActive = false, Specializations = "AssociationClass|Extension|CommunicationPath")]
    public interface Association : Relationship, Classifier
    {
        /// <summary>
        /// The <see cref="Classifier"/>s that are used as types of the ends of the <see cref="Association"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "*")]
        [Property(IsDerived = true, IsDerivedUnion = false, IsReadOnly = true, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "Relationship.RelatedElement", RedefinedProperty = "")]
        IEnumerable<Type> EndType();

        /// <summary>
        /// Specifies whether the <see cref="Association"/> is derived from other model elements such as other <see cref="Association"/>s.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        bool IsDerived { get; set; }

        /// <summary>
        /// Each end represents participation of instances of the <see cref="Classifier"/> connected to the end in links of the <see cref="Association"/>.
        /// </summary>        
        [MultiplicityElement(IsOrdered = true, IsUnique = true, Lower = 2, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "Namespace.Member", RedefinedProperty = "")]List<Property> MemberEnd { get; set; }

        /// <summary>
        /// The navigable ends that are owned by the <see cref="Association"/> itself.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "Association.OwnedEnd", RedefinedProperty = "")]
        List<Property> NavigableOwnedEnd { get; set; }

        /// <summary>
        /// The ends that are owned by the <see cref="Association"/> itself.
        /// </summary>
        [MultiplicityElement(IsOrdered = true, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Classifier.Feature|Association.MemberEnd|Namespace.OwnedMember", RedefinedProperty = "")]
        OwnerList<Property> OwnedEnd { get; set; }
    }
}