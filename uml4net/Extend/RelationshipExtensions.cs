// -------------------------------------------------------------------------------------------------
// <copyright file="RelationshipExtensions.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
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
