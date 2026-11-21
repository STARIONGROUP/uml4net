// -------------------------------------------------------------------------------------------------
// <copyright file="ElementImportExtensions.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.CommonStructure
{
    using System;

    /// <summary>
    /// The <see cref="ElementImportExtensions"/> class provides extensions methods for <see cref="IElementImport"/>
    /// </summary>
    internal static class ElementImportExtensions
    {
        /// <summary>
        /// Queries the name under which the imported PackageableElement will be known in the
        /// importing Namespace.
        /// </summary>
        /// <param name="elementImport">
        /// The subject <see cref="IElementImport"/>
        /// </param>
        /// <returns>
        /// the alias, if set, otherwise the name of the imported element.
        /// </returns>
        internal static string QueryGetName(this IElementImport elementImport)
        {
            if (elementImport == null)
            {
                throw new ArgumentNullException(nameof(elementImport));
            }

            return !string.IsNullOrEmpty(elementImport.Alias) ? elementImport.Alias : elementImport.ImportedElement?.Name;
        }
    }
}
