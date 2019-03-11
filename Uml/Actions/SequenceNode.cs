// -------------------------------------------------------------------------------------------------
// <copyright file="SequenceNode.cs" company="RHEA System S.A.">
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
    using Uml.Activities;
    using Uml.Assembler;
    using Uml.Attributes;
    using Uml.Classification;

    /// <summary>
    /// A <see cref="SequenceNode"/> is a <see cref="StructuredActivityNode"/> that executes a sequence of <see cref="ExecutableNodes"/> in order.
    /// </summary>
    [Class(IsAbstract = false, IsActive = false, Specializations = "")]
    public interface SequenceNode : StructuredActivityNode
    {
        /// <summary>
        /// The ordered set of <see cref="ExecutableNode"/>s to be sequenced.
        /// </summary>
        [MultiplicityElement(IsOrdered = true, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "", RedefinedProperty = "StructuredActivityNode.Node")]
        OwnerList<ExecutableNode> ExecutableNode { get; set; }
    }
}