// -------------------------------------------------------------------------------------------------
// <copyright file="ElementImportExtensions.cs" company="Starion Group S.A.">
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
