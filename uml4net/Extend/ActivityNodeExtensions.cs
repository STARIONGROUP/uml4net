// -------------------------------------------------------------------------------------------------
// <copyright file="ActivityNodeExtensions.cs" company="Starion Group S.A.">
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
    /// The <see cref="ActivityNodeExtensions"/> class provides extensions methods for <see cref="IActivityNode"/>
    /// </summary>
    internal static class ActivityNodeExtensions
    {
        /// <summary>
        /// Queries the ActivityGroups containing the ActivityNode. Per the UML 2.5.1 metamodel this is a derived
        /// union subset by <see cref="IActivityNode.InPartition"/>, <see cref="IActivityNode.InInterruptibleRegion"/> and
        /// <see cref="IActivityNode.InStructuredNode"/>.
        /// </summary>
        /// <param name="activityNode">
        /// The subject <see cref="IActivityNode"/>
        /// </param>
        /// <returns>
        /// The ActivityGroups containing the ActivityNode.
        /// </returns>
        internal static List<IActivityGroup> QueryInGroup(this IActivityNode activityNode)
        {
            if (activityNode == null)
            {
                throw new ArgumentNullException(nameof(activityNode));
            }

            var inGroup = activityNode.InPartition.Cast<IActivityGroup>().ToList();

            inGroup.AddRange(activityNode.InInterruptibleRegion);

            // ActivityNode::inStructuredNode subsets owner and is not populated by the reader, hence the fallback to the owner
            var inStructuredNode = activityNode.InStructuredNode ?? activityNode.Owner as IStructuredActivityNode;

            if (inStructuredNode != null)
            {
                inGroup.Add(inStructuredNode);
            }

            return inGroup.Distinct().ToList();
        }
    }
}
