// -------------------------------------------------------------------------------------------------
// <copyright file="ObjectFlow.cs" company="RHEA System S.A.">
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
    using Uml.CommonBehavior;

    /// <summary>
    /// An <see cref="ObjectFlow"/> is an <see cref="ActivityEdge"/> that is traversed by object tokens that may hold values. Object flows also support multicast/receive, token selection from object nodes, and transformation of tokens.
    /// </summary>
    public interface ObjectFlow : ActivityEdge
    {
        /// <summary>
        /// Indicates whether the objects in the <see cref="ObjectFlow"/> are passed by multicasting.
        /// </summary>
        bool IsMulticast { get; set; }

        /// <summary>
        /// Indicates whether the objects in the <see cref="ObjectFlow"/> are gathered from respondents to multicasting.
        /// </summary>
        bool IsMultireceive { get; set; }

        /// <summary>
        /// A <see cref="Behavior"/> used to select tokens from a source <see cref="ObjectNode"/>.
        /// </summary>
        Behavior Selection { get; set; }

        /// <summary>
        /// A <see cref="Behavior"/> used to change or replace object tokens flowing along the <see cref="ObjectFlow"/>.
        /// </summary>
        Behavior Transformation { get; set; }
    }
}