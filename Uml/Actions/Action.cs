// -------------------------------------------------------------------------------------------------
// <copyright file="Action.cs" company="RHEA System S.A.">
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

using Uml.CommonStructure;

namespace Uml.Actions
{
    using System.Collections.Generic;
    using Uml.Assembler;
    using Uml.Activities;
    using Uml.Classification;

    /// <summary>
    /// An Action is the fundamental unit of executable functionality. The execution of an Action represents some transformation or processing in the modeled system. Actions provide the ExecutableNodes within Activities and may also be used within Interactions.
    /// </summary>
    public interface Action : ExecutableNode
    {
        /// <summary>
        /// The context <see cref="Classifier"/> of the <see cref="Behavior"/> that contains this <see cref="Action"/>, or the <see cref="Behavior"/> itself if it has no context.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        Classifier Content { get; }

        /// <summary>
        /// The ordered set of InputPins representing the inputs to the Action.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        IEnumerable<InputPin> Input { get; }

        /// <summary>
        /// If true, the <see cref="Action"/> can begin a new, concurrent execution, even if there is already another execution of the <see cref="Action"/> ongoing. If false, the <see cref="Action"/> cannot begin a new execution until any previous execution has completed.
        /// </summary>
        bool IsLocallyReentrant { get; set; }

        /// <summary>
        /// A <see cref="Constraint"/> that must be satisfied when execution of the <see cref="Action"/> is completed.
        /// </summary>
        OwnerList<Constraint> LocalPostcondition { get; set; }

        /// <summary>
        /// A <see cref="Constraint"/> that must be satisfied when execution of the <see cref="Action"/> is started.
        /// </summary>
        OwnerList<Constraint> LocalPrecondition { get; set; }

        /// <summary>
        /// The ordered set of <see cref="OutputPin"/>s representing outputs from the <see cref="Action"/>.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        IEnumerable<OutputPin> Output { get; }
    }
}