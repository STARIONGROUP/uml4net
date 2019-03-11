// -------------------------------------------------------------------------------------------------
// <copyright file="ExecutableNode.cs" company="RHEA System S.A.">
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
    using Uml.Assembler;
    using Uml.Attributes;
    using Uml.Classification;

    /// <summary>
    /// An <see cref="ExecutableNode"/> is an abstract class for <see cref="ActivityNode"/>s whose execution may be controlled using <see cref="ControlFlow"/>s and to which <see cref="ExceptionHandler"/>s may be attached.
    /// </summary>
    [Class(IsAbstract = true, IsActive = false, Specializations = "Action")]
    public interface ExecutableNode : ActivityNode
    {
        /// <summary>
        /// A set of <see cref="ExceptionHandler"/>s that are examined if an exception propagates out of the <see cref="ExceptionNode"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Element.OwnedElement", RedefinedProperty = "")]
        OwnerList<ExceptionHandler> Handler { get; set; }
    }
}