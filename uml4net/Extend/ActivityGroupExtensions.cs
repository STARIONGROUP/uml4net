// -------------------------------------------------------------------------------------------------
// <copyright file="ActivityGroupExtensions.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2026 Starion Group S.A.
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
    using System.Linq;

    using uml4net.Actions;

    /// <summary>
    /// The <see cref="ActivityGroupExtensions"/> class provides extensions methods for <see cref="IActivityGroup"/>
    /// </summary>
    internal static class ActivityGroupExtensions
    {
        /// <summary>
        /// Queries the ActivityEdges immediately contained in the ActivityGroup. Per the UML 2.5.1 metamodel this
        /// is a derived union: <see cref="IActivityPartition.Edge"/> and <see cref="IStructuredActivityNode.Edge"/>
        /// subset it, while <see cref="IInterruptibleActivityRegion"/> has no contributing property.
        /// </summary>
        /// <param name="activityGroup">
        /// The subject <see cref="IActivityGroup"/>
        /// </param>
        /// <returns>
        /// The ActivityEdges immediately contained in the ActivityGroup.
        /// </returns>
        internal static List<IActivityEdge> QueryContainedEdge(this IActivityGroup activityGroup)
        {
            if (activityGroup == null)
            {
                throw new ArgumentNullException(nameof(activityGroup));
            }

            return activityGroup switch
            {
                IActivityPartition activityPartition => activityPartition.Edge.ToList(),
                IStructuredActivityNode structuredActivityNode => structuredActivityNode.Edge.ToList(),
                _ => new List<IActivityEdge>()
            };
        }

        /// <summary>
        /// Queries the ActivityNodes immediately contained in the ActivityGroup. Per the UML 2.5.1 metamodel this
        /// is a derived union: <see cref="IActivityPartition.Node"/>, <see cref="IInterruptibleActivityRegion.Node"/>,
        /// and <see cref="IStructuredActivityNode.Node"/> each subset it.
        /// </summary>
        /// <param name="activityGroup">
        /// The subject <see cref="IActivityGroup"/>
        /// </param>
        /// <returns>
        /// The ActivityNodes immediately contained in the ActivityGroup.
        /// </returns>
        internal static List<IActivityNode> QueryContainedNode(this IActivityGroup activityGroup)
        {
            if (activityGroup == null)
            {
                throw new ArgumentNullException(nameof(activityGroup));
            }

            return activityGroup switch
            {
                IActivityPartition activityPartition => activityPartition.Node.ToList(),
                IInterruptibleActivityRegion interruptibleActivityRegion => interruptibleActivityRegion.Node.ToList(),
                IStructuredActivityNode structuredActivityNode => structuredActivityNode.Node.ToList(),
                _ => new List<IActivityNode>()
            };
        }

        /// <summary>
        /// Queries the Other ActivityGroups immediately contained in this ActivityGroup. Per the UML 2.5.1
        /// metamodel this is a derived union to which only <see cref="IActivityPartition.Subpartition"/>
        /// subsets/contributes.
        /// </summary>
        /// <param name="activityGroup">
        /// The subject <see cref="IActivityGroup"/>
        /// </param>
        /// <returns>
        /// The Other ActivityGroups immediately contained in this ActivityGroup.
        /// </returns>
        internal static IContainerList<IActivityGroup> QuerySubgroup(this IActivityGroup activityGroup)
        {
            if (activityGroup == null)
            {
                throw new ArgumentNullException(nameof(activityGroup));
            }

            var containerList = new ContainerList<IActivityGroup>(activityGroup);

            if (activityGroup is IActivityPartition activityPartition)
            {
                foreach (var subpartition in activityPartition.Subpartition)
                {
                    containerList.Add(subpartition);
                }
            }

            return containerList;
        }

        /// <summary>
        /// Queries the ActivityGroup immediately containing this ActivityGroup, if it is directly owned by another
        /// ActivityGroup. Per the UML 2.5.1 metamodel this is a derived union to which only
        /// <see cref="IActivityPartition.SuperPartition"/> subsets/contributes.
        /// </summary>
        /// <param name="activityGroup">
        /// The subject <see cref="IActivityGroup"/>
        /// </param>
        /// <returns>
        /// The ActivityGroup immediately containing this ActivityGroup, if it is directly owned by another
        /// ActivityGroup.
        /// </returns>
        internal static IActivityGroup QuerySuperGroup(this IActivityGroup activityGroup)
        {
            if (activityGroup == null)
            {
                throw new ArgumentNullException(nameof(activityGroup));
            }

            return activityGroup is IActivityPartition activityPartition ? activityPartition.SuperPartition : null;
        }
    }
}
