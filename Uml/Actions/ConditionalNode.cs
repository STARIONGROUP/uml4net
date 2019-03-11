// -------------------------------------------------------------------------------------------------
// <copyright file="ConditionalNode.cs" company="RHEA System S.A.">
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
    using Uml.Assembler;
    using Uml.Attributes;
    using Uml.Classification;

    /// <summary>
    /// A <see cref="ConditionalNode"/> is a <see cref="StructuredActivityNode"/> that chooses one among some number of alternative collections of <see cref="ExecutableNode"/>s to execute.
    /// </summary>
    [Class(IsAbstract = false, IsActive = false, Specializations = "")]
    public interface ConditionalNode : StructuredActivityNode
    {
        /// <summary>
        /// The set of <see cref="Clause"/>s composing the <see cref="ConditionalNode"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Element.OwnedElement", RedefinedProperty = "")]
        OwnerList<Clause> Clause { get; set; }

        /// <summary>
        /// If true, the modeler asserts that the test for at least one <see cref="Clause"/> of the <see cref="ConditionalNode"/> will succeed.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        bool IsAssured { get; set; }

        /// <summary>
        /// If true, the modeler asserts that the test for at most one <see cref="Clause"/> of the <see cref="ConditionalNode"/> will succeed.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        bool IsDeterminate { get; set; }

        /// <summary>
        /// The <see cref="OutputPin"/>s that onto which are moved values from the bodyOutputs of the <see cref="Clause"/> selected for execution.
        /// </summary>
        [MultiplicityElement(IsOrdered = true, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "", RedefinedProperty = "")]
        OwnerList<OutputPin> Result { get; set; }
    }
}