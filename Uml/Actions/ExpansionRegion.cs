// -------------------------------------------------------------------------------------------------
// <copyright file="ExpansionRegion.cs" company="RHEA System S.A.">
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

namespace Uml.Actions
{
    using System.Collections.Generic;
    using Uml.Attributes;
    using Uml.Classification;

    /// <summary>
    /// An <see cref="ExpansionRegion"/> is a <see cref="StructuredActivityNode"/> that executes its content multiple times corresponding to elements of input collection(s).
    /// </summary>
    [Class(IsAbstract = false, IsActive = false, Specializations = "")]
    public interface ExpansionRegion : StructuredActivityNode
    {
        /// <summary>
        /// The <see cref="ExpansionNode"/>s that hold the input collections for the <see cref="ExpansionRegion"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        List<ExpansionNode> InputElement { get; set; }

        /// <summary>
        /// The mode in which the <see cref="ExpansionRegion"/> executes its contents. If parallel, executions are concurrent. If iterative, executions are sequential. If stream, a stream of values flows into a single execution.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        ExpansionKind Mode { get; set; }

        /// <summary>
        /// The <see cref="ExpansionNode"/>s that form the output collections of the <see cref="ExpansionRegion"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        List<ExpansionNode> OutputElement { get; set; }
    }
}