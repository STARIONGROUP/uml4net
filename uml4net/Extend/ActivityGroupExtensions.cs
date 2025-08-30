// -------------------------------------------------------------------------------------------------
// <copyright file="ActivityGroupExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.Activities
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The <see cref="ActivityGroupExtensions"/> class provides extensions methods for <see cref="IActivityGroup"/>
    /// </summary>
    internal static class ActivityGroupExtensions
    {
        /// <summary>
        /// Queries the ActivityEdges immediately contained in the ActivityGroup.
        /// </summary>
        /// <param name="activityGroup">
        /// The subject <see cref="IActivityGroup"/>
        /// </param>
        /// <returns>
        /// The ActivityEdges immediately contained in the ActivityGroup.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        internal static List<IActivityEdge> QueryContainedEdge(this IActivityGroup activityGroup)
        {
            throw new NotSupportedException("Create a GitHub issue when this method is required");
        }

        /// <summary>
        /// Queries the ActivityNodes immediately contained in the ActivityGroup.
        /// </summary>
        /// <param name="activityGroup">
        /// The subject <see cref="IActivityGroup"/>
        /// </param>
        /// <returns>
        /// The ActivityNodes immediately contained in the ActivityGroup.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        internal static List<IActivityNode> QueryContainedNode(this IActivityGroup activityGroup)
        {
            throw new NotSupportedException("Create a GitHub issue when this method is required");
        }

        /// <summary>
        /// Queries the Other ActivityGroups immediately contained in this ActivityGroup.
        /// </summary>
        /// <param name="activityGroup">
        /// The subject <see cref="IActivityGroup"/>
        /// </param>
        /// <returns>
        /// The Other ActivityGroups immediately contained in this ActivityGroup.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        internal static IContainerList<IActivityGroup> QuerySubgroup(this IActivityGroup activityGroup)
        {
            throw new NotSupportedException("Create a GitHub issue when this method is required");
        }

        /// <summary>
        /// Queries the ActivityGroup immediately containing this ActivityGroup, if it is directly owned by another
        /// ActivityGroup.
        /// </summary>
        /// <param name="activityGroup">
        /// The subject <see cref="IActivityGroup"/>
        /// </param>
        /// <returns>
        /// The ActivityGroup immediately containing this ActivityGroup, if it is directly owned by another
        /// ActivityGroup.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        internal static IActivityGroup QuerySuperGroup(this IActivityGroup activityGroup)
        {
            throw new NotSupportedException("Create a GitHub issue when this method is required");
        }
    }
}
