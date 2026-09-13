// -------------------------------------------------------------------------------------------------
// <copyright file="RelationshipExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.CommonStructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using uml4net.StructuredClassifiers;

    /// <summary>
    /// The <see cref="RelationshipExtensions"/> class provides extensions methods for <see cref="IRelationship"/>
    /// </summary>
    internal static class RelationshipExtensions
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
        /// <remarks>
        /// <c>Relationship::relatedElement</c> is a derived union without OCL body. Per the <c>[SubsettedProperty]</c>
        /// metadata of the generated interfaces it is subsetted by <see cref="IDirectedRelationship.Source"/>,
        /// <see cref="IDirectedRelationship.Target"/> and <see cref="IAssociation.EndType"/>. Duplicates are removed.
        /// </remarks>
        internal static List<IElement> QueryRelatedElement(this IRelationship relationship)
        {
            if (relationship == null)
            {
                throw new ArgumentNullException(nameof(relationship));
            }

            var relatedElement = new List<IElement>();

            if (relationship is IDirectedRelationship directedRelationship)
            {
                relatedElement.AddRange(directedRelationship.Source);
                relatedElement.AddRange(directedRelationship.Target);
            }

            if (relationship is IAssociation association)
            {
                relatedElement.AddRange(association.EndType);
            }

            return relatedElement.Distinct().ToList();
        }
    }
}
