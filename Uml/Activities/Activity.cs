// -------------------------------------------------------------------------------------------------
// <copyright file="Activity.cs" company="RHEA System S.A.">
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
    using Uml.Actions;
    using Uml.Assembler;
    using Uml.CommonBehavior;

    /// <summary>
    /// An <see cref="Activity"/> is the specification of parameterized Behavior as the coordinated sequencing of subordinate units.
    /// </summary>
    public interface Activity : Behavior
    {
        /// <summary>
        /// ActivityEdges expressing flow between the nodes of the Activity.
        /// </summary>
        OwnerList<ActivityEdge> Edge { get; set; }

        /// <summary>
        /// Top-level ActivityGroups in the Activity.
        /// </summary>
        OwnerList<ActivityGroup> Group { get; set; }

        /// <summary>
        /// If true, this Activity must not make any changes to objects. The default is false (an Activity may make nonlocal changes). (This is an assertion, not an executable property. It may be used by an execution engine to optimize model execution. If the assertion is violated by the Activity, then the model is ill-formed.) 
        /// </summary>
        bool IsReadOnly { get; set;  }

        /// <summary>
        /// If true, all invocations of the Activity are handled by the same execution.
        /// </summary>
        bool IsSingleExecution { get; set; }

        /// <summary>
        /// ActivityNodes coordinated by the Activity.
        /// </summary>
        OwnerList<ActivityNode> Node { get; set; }

        /// <summary>
        /// Top-level ActivityPartitions in the Activity.
        /// </summary>
        OwnerList<ActivityPartition> Partition { get; set; }

        /// <summary>
        /// Top-level ActivityPartitions in the Activity.
        /// </summary>
        OwnerList<StructuredActivityNode> StructuredNode { get; set; }

        /// <summary>
        /// Top-level Variables defined by the Activity.
        /// </summary>
        OwnerList<Variable> Variable { get; set; }
    }
}