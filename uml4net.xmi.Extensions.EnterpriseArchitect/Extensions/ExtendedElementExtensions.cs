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
    using System.Collections.Generic;
    using System.Linq;

    using uml4net.Classification;
    using uml4net.xmi.Extensions.EntrepriseArchitect.Structure;

    using IElement = uml4net.CommonStructure.IElement;

    /// <summary>
    /// Provides extension methods for working with elements implementing <see cref="EntrepriseArchitect.Structure.IElement" />.
    /// </summary>
    public static class ExtendedElementExtensions
    {
        /// <summary>
        /// Queries the documentation available from the extensions of the specified <paramref name="element" />.
        /// </summary>
        /// <param name="element">The element whose extensions are queried for documentation.</param>
        /// <returns>
        /// The documentation string from the first extension with non-empty documentation, or <c>null</c> if none is found.
        /// </returns>
        public static string QueryDocumentationFromExtensions(this IElement element)
        {
            switch (element)
            {
                case null:
                    throw new ArgumentNullException(nameof(element));
                case IProperty { Association: not null } property:
                {
                    var embeddedElements = property.Association.Extensions.OfType<IConnector>()
                        .SelectMany(x => element.XmiId.Contains("src") ? x.Source : x.Target); 

                    var documentation = embeddedElements.SelectMany(x => x.Documentation)
                        .Where(x => !string.IsNullOrEmpty(x.Value))
                        .Select(x => x.Value);
                    
                    return string.Join(Environment.NewLine, documentation);
                }

                default:
                    var documentations = new List<string>();
                    
                    documentations.AddRange(element.Extensions.OfType<uml4net.xmi.Extensions.EntrepriseArchitect.Structure.IElement>()
                        .SelectMany(x => x.Properties)
                        .Where(x => !string.IsNullOrWhiteSpace(x.Documentation))
                        .Select(x => x.Documentation));
                    
                    documentations.AddRange(element.Extensions.OfType<IDocumentedElement>()
                        .SelectMany(x => x.Documentation)
                        .Where(x => !string.IsNullOrWhiteSpace(x.Value))
                        .Select(x => x.Value));
                    
                    return string.Join(Environment.NewLine, documentations);
            }
        }
    }
}
