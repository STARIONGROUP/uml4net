// -------------------------------------------------------------------------------------------------
// <copyright file="RelationshipExtensions.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2024 Starion Group S.A.
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

    /// <summary>
    /// The <see cref="RelationshipExtensions"/> class provides extensions methods for <see cref="IRelationship"/>
    /// </summary>
    public static class RelationshipExtensions
    {
        /// <summary>
        /// Queries the elements related by the Relationship.
        /// </summary>
        /// <param name="relationship">
        /// The subject <see cref="IRelationship"/>
        /// </param>
        /// <returns>
        /// The elements related by the Relationship.
        /// </returns>
        public static List<IElement> QueryRelatedElement(this IRelationship relationship)
        {
            throw new NotImplementedException();
        }
    }
}
