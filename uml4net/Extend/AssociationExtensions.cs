// -------------------------------------------------------------------------------------------------
// <copyright file="AssociationExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.StructuredClassifiers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.Packages;

    /// <summary>
    /// The <see cref="AssociationExtensions"/> class provides extensions methods for <see cref="IAssociation"/>
    /// </summary>
    internal static class AssociationExtensions
    {
        /// <summary>
        /// Queries the Classifiers that are used as types of the ends of the Association
        /// </summary>
        /// <param name="association">
        /// The subject <see cref="IAssociation"/>
        /// </param>
        /// <returns>
        /// The Classifiers that are used as types of the ends of the Association.
        /// </returns>
        /// <remarks>
        /// Derived per the UML 2.5.1 OCL <c>memberEnd->collect(type)->asSet()</c>: all member ends are taken into
        /// account, not only the ends owned by the Association. The type of an <see cref="IExtensionEnd"/> is read
        /// through <see cref="IExtensionEnd.Type"/>, which redefines (and hides) <see cref="ITypedElement.Type"/>.
        /// </remarks>
        internal static List<IType> QueryEndType(this IAssociation association)
        {
            if (association == null)
            {
                throw new ArgumentNullException(nameof(association));
            }

            return association.MemberEnd
                .Select(ClassExtensions.QueryMemberEndType)
                .Where(type => type != null)
                .Distinct()
                .ToList();
        }
    }
}
