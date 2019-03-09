// -------------------------------------------------------------------------------------------------
// <copyright file="CollaborationUse.cs" company="RHEA System S.A.">
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
    using Uml.Assembler;
    using Uml.Attributes;
    using Uml.Classification;
    using Uml.CommonStructure;

    /// <summary>
    /// A CollaborationUse is used to specify the application of a pattern specified by a <see cref="Collaboration"/> to a specific situation.
    /// </summary>
    [Class(IsAbstract = false, IsActive = false, Specializations = "")]
    public interface CollaborationUse : NamedElement
    {
        /// <summary>
        /// A mapping between features of the <see cref="Collaboration"/> and features of the owning <see cref="Classifier"/>. This mapping indicates which <see cref="ConnectableElement"/> of the <see cref="Classifier"/> plays which role(s) in the <see cref="Collaboration"/>. A <see cref="ConnectableElement"/> may be bound to multiple roles in the same <see cref="CollaborationUse"/> (that is, it may play multiple roles).
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Element.OwnedElement", RedefinedProperty = "")]
        OwnerList<Dependency> RoleBinding { get; set; }

        /// <summary>
        /// The <see cref="Collaboration"/> which is used in this <see cref="CollaborationUse"/>. The <see cref="Collaboration"/> defines the cooperation between its roles which are mapped to <see cref="ConnectableElement"/>s relating to the <see cref="Classifier"/> owning the <see cref="CollaborationUse"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        Collaboration Type { get; set; }
    }
}