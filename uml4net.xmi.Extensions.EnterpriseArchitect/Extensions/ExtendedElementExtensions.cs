// -------------------------------------------------------------------------------------------------
//  <copyright file="ExtendedElementExtensions.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2025 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
//  </copyright>
//  ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Extensions.EnterpriseArchitect.Extensions
{
    using System;
    using System.Linq;

    using uml4net.CommonStructure;
    using uml4net.xmi.Extensions.EnterpriseArchitect.CommonStructureExtension;

    /// <summary>
    /// Provides extension methods for working with elements implementing <see cref="IExtensionElement" />.
    /// </summary>
    public static class ExtendedElementExtensions
    {
        /// <summary>
        /// Retrieves the suffix used to identify an extension element.
        /// </summary>
        public const string ExtensionIdSuffix = "_extension";

        /// <summary>
        /// Sets the extension element for the specified <paramref name="extensionElement" />
        /// using the provided <paramref name="cache" /> to resolve the associated element.
        /// </summary>
        /// <param name="extensionElement">The extension element to configure.</param>
        /// <param name="cache">The cache used to resolve the extended element.</param>
        /// <param name="documentName">The current document name</param>
        public static void SetExtensionElement(this IExtensionElement extensionElement, IXmiElementCache cache, string documentName)
        {
            if (extensionElement == null)
            {
                throw new ArgumentNullException(nameof(extensionElement));
            }

            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }

            var id = extensionElement.XmiId.EndsWith(ExtensionIdSuffix)
                ? extensionElement.XmiId.Substring(0, extensionElement.XmiId.Length - ExtensionIdSuffix.Length)
                : extensionElement.XmiId;

            if (cache.TryGetValue($"{documentName}#{id}", out var element))
            {
                element.Extensions.Add(extensionElement);
                extensionElement.ExtendedElement = element;
            }
        }

        /// <summary>
        /// Queries the documentation available from the extensions of the specified <paramref name="element" />.
        /// </summary>
        /// <param name="element">The element whose extensions are queried for documentation.</param>
        /// <returns>
        /// The documentation string from the first extension with non-empty documentation, or <c>null</c> if none is found.
        /// </returns>
        public static string QueryDocumentationFromExtensions(this IElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            return element.Extensions.OfType<IExtensionElement>()
                .FirstOrDefault(x => !string.IsNullOrWhiteSpace(x.Documentation))?.Documentation;
        }
    }
}
