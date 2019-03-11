// -------------------------------------------------------------------------------------------------
// <copyright file="Clause.cs" company="RHEA System S.A.">
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
    using Uml.Activities;
    using Uml.Attributes;
    using Uml.Classification;
    using Uml.CommonStructure;

    /// <summary>
    /// A <see cref="Clause"/> is an <see cref="Element"/> that represents a single branch of a <see cref="ConditionalNode"/>, including a test and a body section. The body section is executed only if (but not necessarily if) the test section evaluates to true.
    /// </summary>
    [Class(IsAbstract = false, IsActive = false, Specializations = "")]
    public interface Clause : Element
    {
        /// <summary>
        /// The set of <see cref="ExecutableNode"/>s that are executed if the test evaluates to true and the <see cref="Clause"/> is chosen over other <see cref="Clause"/>s within the <see cref="ConditionalNode"/> that also have tests that evaluate to true.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        List<ExecutableNode> Body { get; set; }

        /// <summary>
        /// The <see cref="OutputPin"/>s on <see cref="Action"/>s within the body section whose values are moved to the result <see cref="OutputPin"/>s of the containing <see cref="ConditionalNode"/> after execution of the body.
        /// </summary>
        [MultiplicityElement(IsOrdered = true, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        List<OutputPin> BodyOutput { get; set; }

        /// <summary>
        /// An <see cref="OutputPin"/> on an <see cref="Action"/> in the test section whose Boolean value determines the result of the test.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        OutputPin Decider { get; set; }

        /// <summary>
        /// A set of <see cref="Clause"/>s whose tests must all evaluate to false before this <see cref="Clause"/> can evaluate its test.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        List<Clause> PredecessorClause { get; set; }

        /// <summary>
        /// A set of <see cref="Clause"/>s that may not evaluate their tests unless the test for this <see cref="Clause"/> evaluates to false.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        List<Clause> SuccessorClause { get; set; }

        /// <summary>
        /// The set of <see cref="ExecutableNode"/>s that are executed in order to provide a test result for the <see cref="Clause"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        List<ExecutableNode> Test { get; set; }
    }
}