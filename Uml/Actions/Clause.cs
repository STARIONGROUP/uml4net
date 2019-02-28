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
//   along with uml-sharp.  If not, see<http://www.gnu.org/licenses/>.
// </copyright>
// -------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using Uml.Activities;

namespace Uml.Actions
{
    using Uml.CommonStructure;

    /// <summary>
    /// A <see cref="Clause"/> is an <see cref="Element"/> that represents a single branch of a <see cref="ConditionalNode"/>, including a test and a body section. The body section is executed only if (but not necessarily if) the test section evaluates to true.
    /// </summary>
    public interface Clause : Element
    {
        /// <summary>
        /// The set of ExecutableNodes that are executed if the test evaluates to true and the Clause is chosen over other Clauses within the ConditionalNode that also have tests that evaluate to true.
        /// </summary>
        List<ExecutableNode> Body { get; set; }

        /// <summary>
        /// The OutputPins on Actions within the body section whose values are moved to the result OutputPins of the containing ConditionalNode after execution of the body.
        /// </summary>
        List<OutputPin> BodyOutput { get; set; }

        /// <summary>
        /// An OutputPin on an Action in the test section whose Boolean value determines the result of the test.
        /// </summary>
        OutputPin Decider { get; set; }

        /// <summary>
        /// A set of Clauses whose tests must all evaluate to false before this Clause can evaluate its test.
        /// </summary>
        List<Clause> PredecessorClause { get; set; }

        /// <summary>
        /// A set of Clauses that may not evaluate their tests unless the test for this Clause evaluates to false.
        /// </summary>
        List<Clause> SuccessorClause { get; set; }

        /// <summary>
        /// The set of ExecutableNodes that are executed in order to provide a test result for the Clause.
        /// </summary>
        List<ExecutableNode> Test { get; set; }
    }
}