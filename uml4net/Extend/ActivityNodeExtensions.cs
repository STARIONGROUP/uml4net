﻿// -------------------------------------------------------------------------------------------------
// <copyright file="ActivityNodeExtensions.cs" company="Starion Group S.A.">
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
    /// The <see cref="ActivityNodeExtensions"/> class provides extensions methods for <see cref="IActivityNode"/>
    /// </summary>
    internal static class ActivityNodeExtensions
    {
        /// <summary>
        /// Queries the ActivityGroups containing the ActivityNode.
        /// </summary>
        /// <param name="activityNode">
        /// The subject <see cref="IActivityGroup"/>
        /// </param>
        /// <returns>
        /// The ActivityGroups containing the ActivityNode.
        /// </returns>
        internal static List<IActivityGroup> QueryInGroup(this IActivityNode activityNode)
        {
            throw new NotSupportedException();
        }
    }
}
