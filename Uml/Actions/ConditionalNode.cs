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
//   along with uml-sharp.  If not, see<http://www.gnu.org/licenses/>.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Uml.Actions
{
    using Uml.Assembler;

    /// <summary>
    /// A <see cref="ConditionalNode"/> is a <see cref="StructuredActivityNode"/> that chooses one among some number of alternative collections of <see cref="ExecutableNode"/>s to execute.
    /// </summary>
    public interface ConditionalNode : StructuredActivityNode
    {
        /// <summary>
        /// The set of Clauses composing the ConditionalNode.
        /// </summary>
        OwnerList<Clause> Clause { get; set; }

        /// <summary>
        /// If true, the modeler asserts that the test for at least one Clause of the ConditionalNode will succeed.
        /// </summary>
        bool IsAssured { get; set; }

        /// <summary>
        /// If true, the modeler asserts that the test for at most one Clause of the ConditionalNode will succeed.
        /// </summary>
        bool IsDeterminate { get; set; }

        /// <summary>
        /// The OutputPins that onto which are moved values from the bodyOutputs of the Clause selected for execution.
        /// </summary>
        OwnerList<OutputPin> Result { get; set; }
    }
}