// -------------------------------------------------------------------------------------------------
// <copyright file="PropertyExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.Classification
{
    using System;
    using System.Linq;

    /// <summary>
    /// The <see cref="PropertyExtensions"/> class provides extensions methods for <see cref="IProperty"/>
    /// </summary>
    internal static class PropertyExtensions
    {
        /// <summary>
        /// Asserts whether the aggregation of the <see cref="IProperty"/> is composite or not.
        /// </summary>
        /// <param name="property">
        /// the subject <see cref="IProperty"/>
        /// </param>
        /// <returns>
        /// true if the aggregation is composite, false if not
        /// </returns>
        /// <remarks>
        /// Implements the OCL of <c>Property::isComposite</c>: <c>result = (aggregation = AggregationKind::composite)</c>.
        /// The aggregation of the other ends of the association plays no role: in an association with one composite
        /// end, the opposite end is not composite.
        /// </remarks>
        internal static bool QueryIsComposite(this IProperty property)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            return property.Aggregation == AggregationKind.Composite;
        }

        /// <summary>
        /// In the case where the Property is one end of a binary association this gives the other end.
        /// </summary>
        /// <param name="property">
        /// The subject <see cref="IProperty"/>
        /// </param>
        /// <returns>
        /// In the case where the Property is one end of a binary association this gives the other end.
        /// </returns>
        /// <remarks>
        /// Per the OMG UML 2.5.1 OCL for <c>Property::/opposite</c>, this is only meaningful for a
        /// BINARY association (<c>association.memberEnd->size() = 2</c>) - for any other association
        /// (no association at all, or a genuinely n-ary one with more than 2 member ends), there is no
        /// single well-defined opposite end, so this returns <c>null</c> rather than throwing.
        /// <c>Property::owningAssociation</c> subsets <c>Property::association</c>, so the owning association is used
        /// when the association is not set, as for an owned end that is serialized without its <c>association</c>.
        /// A property that is not one of the two member ends of its association, which only occurs in an inconsistent
        /// model, has no opposite either: the OCL <c>memberEnd->any(e | e &lt;&gt; self)</c> would pick either end.
        /// </remarks>
        internal static IProperty QueryOpposite(this IProperty property)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            var association = property.Association ?? property.OwningAssociation;

            if (association == null || association.MemberEnd.Count != 2 || !association.MemberEnd.Any(x => ReferenceEquals(x, property)))
            {
                return null;
            }

            var otherEnds = association.MemberEnd.Where(x => !ReferenceEquals(x, property)).ToList();

            return otherEnds.Count == 1 ? otherEnds[0] : null;
        }
    }
}
