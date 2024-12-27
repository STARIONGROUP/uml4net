// -------------------------------------------------------------------------------------------------
//  <copyright file="ActivityEdgeExtensions.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2024 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
//  </copyright>
//  ------------------------------------------------------------------------------------------------

namespace uml4net.Activities
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The <see cref="ActivityEdgeExtensions"/> class provides extensions methods for <see cref="IActivityEdge"/>
    /// </summary>
    public static class ActivityEdgeExtensions
    {
        /// <summary>
        /// Queries the ActivityGroups containing the ActivityEdge.
        /// </summary>
        /// <param name="activityEdge">
        /// The subject <see cref="IActivityEdge"/>
        /// </param>
        /// <returns>
        /// a <see cref="List{IActivityGroup}"/>
        /// </returns>
        public static List<IActivityGroup> QueryInGroup(this IActivityEdge activityEdge)
        {
            throw new NotSupportedException();
        }
    }
}
