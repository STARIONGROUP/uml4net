// -------------------------------------------------------------------------------------------------
// <copyright file="Dependency.cs" company="RHEA System S.A.">
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
    using Uml.Attributes;
    using Uml.Classification;

    /// <summary>
    /// A <see cref="Dependency"/> is a <see cref="Relationship"/> that signifies that a single model <see cref="Element"/> or a set of model <see cref="Element"/>s requires other model <see cref="Element"/>s for their specification or implementation. This means that the complete semantics of the client <see cref="Element"/>(s) are either semantically or structurally dependent on the definition of the supplier <see cref="Element"/>(s).
    /// </summary>
    [Class(IsAbstract = false, IsActive = false, Specializations = "Abstraction|Usage|Deployment")]
    public interface Dependency : DirectedRelationship, PackageableElement
    {
        /// <summary>
        /// The <see cref="Element"/>(s) dependent on the supplier <see cref="Element"/>(s). In some cases (such as a trace Abstraction) the assignment of direction (that is, the designation of the client Element) is at the discretion of the modeler and is a stipulation.
        /// </summary>
        /// <remarks>
        /// Subsets <see cref="DirectedRelationship.Source"/>
        /// </remarks>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "DirectedRelationship.Source", RedefinedProperty = "")]
        List<NamedElement> Client { get; set; }

        /// <summary>
        /// The <see cref="Element"/>(s) on which the client <see cref="Element"/>(s) depend in some respect. The modeler may stipulate a sense of Dependency direction suitable for their domain.
        /// </summary>
        /// <remarks>
        /// Subsets <see cref="DirectedRelationship.Target"/>
        /// </remarks>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "DirectedRelationship.Target", RedefinedProperty = "")]
        List<NamedElement> Supplier { get; set; }
    }
}