// -------------------------------------------------------------------------------------------------
// <copyright file="StructuredActivityNode.cs" company="RHEA System S.A.">
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
    using Uml.Activities;
    using Uml.CommonStructure;

    /// <summary>
    /// A <see cref="StructuredActivityNode"/> is an <see cref="Action"/> that is also an <see cref="ActivityGroup"/> and whose behavior is specified by the <see cref="ActivityNode"/>s and <see cref="ActivityEdge"/>s it so contains. Unlike other kinds of <see cref="ActivityGroup"/>, a <see cref="StructuredActivityNode"/> owns the <see cref="ActivityNode"/>s and <see cref="ActivityEdge"/>s it contains, and so a node or edge can only be directly contained in one <see cref="StructuredActivityNode"/>, though <see cref="StructuredActivityNode"/>s may be nested.
    /// </summary>
    public interface StructuredActivityNode : Namespace, ActivityGroup, Action
    {
        /// <summary>
        /// The <see cref="Activity"/> immediately containing the <see cref="StructuredActivityNode"/>, if it is not contained in another <see cref="StructuredActivityNode"/>.
        /// </summary>
        Activity Activity { get; set; }

        /// <summary>
        /// The <see cref="ActivityEdge"/>s immediately contained in the <see cref="StructuredActivityNode"/>.
        /// </summary>
        OwnerList<ActivityEdge> Edge { get; set; }

        /// <summary>
        /// If true, then any object used by an <see cref="Action"/> within the <see cref="StructuredActivityNode"/> cannot be accessed by any <see cref="Action"/> outside the node until the <see cref="StructuredActivityNode"/> as a whole completes. Any concurrent Actions that would result in accessing such objects are required to have their execution deferred until the completion of the <see cref="StructuredActivityNode"/>.
        /// </summary>
        bool MustIsolate { get; set; }
        
        /// <summary>
        /// The <see cref="ActivityNode"/>s immediately contained in the <see cref="StructuredActivityNode"/>.
        /// </summary>
        OwnerList<ActivityNode> Node { get; set; }

        /// <summary>
        /// The <see cref="InputPin"/>s owned by the <see cref="StructuredActivityNode"/>.
        /// </summary>
        OwnerList<InputPin> StructuredNodeInput { get; set; }

        /// <summary>
        /// The <see cref="OutputPin"/>s owned by the <see cref="StructuredActivityNode"/>.
        /// </summary>
        OwnerList<OutputPin> StructuredNodeOutput { get; set; }

        /// <summary>
        /// The <see cref="Variable"/>s defined in the scope of the <see cref="StructuredActivityNode"/>.
        /// </summary>
        OwnerList<Variable> Variable { get; set; }
    }
}