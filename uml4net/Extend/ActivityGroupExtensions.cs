// -------------------------------------------------------------------------------------------------
// <copyright file="ActivityGroupExtensions.cs" company="Starion Group S.A.">
//
//   Copyright 2019-2024 Starion Group S.A.
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

    using uml4net.Utils;

    /// <summary>
    /// The <see cref="ActivityGroupExtensions"/> class provides extensions methods for <see cref="IActivityGroup"/>
    /// </summary>
    public static class ActivityGroupExtensions
    {
        public static List<IActivityEdge> QueryContainedEdge(this IActivityGroup activityGroup)
        {
            throw new NotImplementedException();
        }

        public static List<IActivityNode> QueryContainedNode(this IActivityGroup activityGroup)
        {
            throw new NotImplementedException();
        }

        public static IContainerList<IActivityGroup> QuerySubgroup(this IActivityGroup activityGroup)
        {
            throw new NotImplementedException();
        }

        public static IActivityGroup QuerySuperGroup(this IActivityGroup activityGroup)
        {
            throw new NotImplementedException();
        }
    }
}
