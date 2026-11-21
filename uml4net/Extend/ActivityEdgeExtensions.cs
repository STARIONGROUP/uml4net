// -------------------------------------------------------------------------------------------------
// <copyright file="ActivityEdgeExtensions.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Activities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using uml4net.Actions;

    /// <summary>
    /// The <see cref="ActivityEdgeExtensions"/> class provides extensions methods for <see cref="IActivityEdge"/>
    /// </summary>
    internal static class ActivityEdgeExtensions
    {
        /// <summary>
        /// Queries the ActivityGroups containing the ActivityEdge. Per the UML 2.5.1 metamodel this is a derived
        /// union subset by <see cref="IActivityEdge.InPartition"/> and <see cref="IActivityEdge.InStructuredNode"/>.
        /// </summary>
        /// <param name="activityEdge">
        /// The subject <see cref="IActivityEdge"/>
        /// </param>
        /// <returns>
        /// a <see cref="List{IActivityGroup}"/>
        /// </returns>
        internal static List<IActivityGroup> QueryInGroup(this IActivityEdge activityEdge)
        {
            if (activityEdge == null)
            {
                throw new ArgumentNullException(nameof(activityEdge));
            }

            var inGroup = activityEdge.InPartition.Cast<IActivityGroup>().ToList();

            // ActivityEdge::inStructuredNode subsets owner and is not populated by the reader, hence the fallback to the owner
            var inStructuredNode = activityEdge.InStructuredNode ?? activityEdge.Owner as IStructuredActivityNode;

            if (inStructuredNode != null)
            {
                inGroup.Add(inStructuredNode);
            }

            return inGroup;
        }
    }
}
