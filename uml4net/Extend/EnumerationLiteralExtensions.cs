// -------------------------------------------------------------------------------------------------
// <copyright file="EnumerationLiteralExtensions.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.SimpleClassifiers
{
    using System;

    /// <summary>
    /// The <see cref="EnumerationLiteralExtensions"/> class provides extensions methods for <see cref="IEnumerationLiteral"/>
    /// </summary>
    internal static class EnumerationLiteralExtensions
    {
        /// <summary>
        /// Queries the classifier of this EnumerationLiteral derived to be equal to its Enumeration.
        /// </summary>
        /// <param name="enumerationLiteral">
        /// The subject <see cref="IEnumerationLiteral"/>
        /// </param>
        /// <returns>
        /// The classifier of this EnumerationLiteral derived to be equal to its Enumeration.
        /// </returns>
        internal static IEnumeration QueryClassifier(this IEnumerationLiteral enumerationLiteral)
        {
            if (enumerationLiteral == null)
            {
                throw new ArgumentNullException(nameof(enumerationLiteral));
            }

            return enumerationLiteral.Enumeration;
        }
    }
}
