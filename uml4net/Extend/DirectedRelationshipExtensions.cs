﻿// -------------------------------------------------------------------------------------------------
// <copyright file="DirectedRelationshipExtensions.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2025 Starion Group S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.CommonStructure
{
    using System;
    using System.Collections.Generic;

    using Classification;

    /// <summary>
    /// The <see cref="DirectedRelationshipExtensions"/> class provides extensions methods for <see cref="IDirectedRelationship"/>
    /// </summary>
    internal static class DirectedRelationshipExtensions
    {
        /// <summary>
        /// Queries the target Element(s) of the DirectedRelationship.
        /// </summary>
        /// <param name="directedRelationship">
        /// The subject <see cref="IDirectedRelationship"/>
        /// </param>
        /// <returns>
        /// the target Element(s) of the DirectedRelationship.
        /// </returns>
        internal static List<IElement> QueryTarget(this IDirectedRelationship directedRelationship)
        {
            if (directedRelationship == null)
            {
                throw new ArgumentNullException(nameof(directedRelationship));
            }

            if (directedRelationship is IGeneralization generalization)
            {
                return [generalization.General];
            }

            throw new NotSupportedException($"{directedRelationship.GetType()} not yet supported");
        }

        /// <summary>
        /// Queries the source Element(s) of the DirectedRelationship.
        /// </summary>
        /// <param name="directedRelationship">
        /// The subject <see cref="IDirectedRelationship"/>
        /// </param>
        /// <returns>
        /// the source Element(s) of the DirectedRelationship.
        /// </returns>
        internal static List<IElement> QuerySource(this IDirectedRelationship directedRelationship)
        {
            if (directedRelationship == null)
            {
                throw new ArgumentNullException(nameof(directedRelationship));
            }

            if (directedRelationship is IGeneralization generalization)
            {
                return [generalization.Specific];
            }

            throw new NotSupportedException($"{directedRelationship.GetType()} not yet supported");
        }
    }
}
