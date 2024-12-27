// -------------------------------------------------------------------------------------------------
//  <copyright file="ElementExtensions.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2024 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, softwareUseCases
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
//  </copyright>
//  ------------------------------------------------------------------------------------------------

namespace uml4net.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using HtmlAgilityPack;

    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.CommonStructure;
    using uml4net.Utils;

    /// <summary>
    /// Extension methods for <see cref="IElement"/> interface
    /// </summary>
    public static class ElementExtensions
    {
        /// <summary>
        /// Queries the documentation from the <see cref="IElement"/> and
        /// returns it as a string
        /// </summary>
        /// <param name="element">
        /// The subject <see cref="IElement"/> for which the documentation is queried
        /// </param>
        /// <returns>
        /// The documentation of the <see cref="IElement"/> stripped from unwanted HTML tags
        /// and split to lines of 100 characters long
        /// </returns>
        public static IEnumerable<string> QueryDocumentation(this IElement element)
        {
            Guard.ThrowIfNull(element);

            var ownedComment = element.OwnedComment.FirstOrDefault();
            if (ownedComment == null)
            {
                return Enumerable.Empty<string>();
            }

            if (!string.IsNullOrEmpty(ownedComment.Body))
            {
                var unwantedTags = new List<string> { "p", "code", "em", "tt" };

                var result = ownedComment.Body.RemoveUnwantedHtmlTags(unwantedTags).Replace("\r\n", "").Replace("\n", "").Replace("\r", "");

                var splitLines = result.SplitToLines(100);

                return splitLines;
            }

            return Enumerable.Empty<string>();
        }

        /// <summary>
        /// Queries the documentation from the <see cref="element"/> and
        /// returns it as a string
        /// </summary>
        /// <param name="element">
        /// The subject <see cref="IElement"/> for which the documentation is queried
        /// </param>
        /// <returns>
        /// The documentation of the <see cref="IElement"/> stripped from unwanted HTML tags
        /// </returns>
        public static string QueryRawDocumentation(this IElement element)
        {
            Guard.ThrowIfNull(element);

            var ownedComment = element.OwnedComment.FirstOrDefault();
            if (ownedComment == null)
            {
                return string.Empty;
            }

            if (!string.IsNullOrEmpty(ownedComment.Body))
            {
                var unwantedTags = new List<string> { "p", "code", "em", "tt" };

                var result = ownedComment.Body.RemoveUnwantedHtmlTags(unwantedTags).Replace("\r\n", "").Replace("\n", "").Replace("\r", "");

                return result;
            }

            return string.Empty;
        }

        /// <summary>
        /// Retrieves the root <see cref="IPackage"/> in the hierarchy of the specified <paramref name="element"/>.
        /// </summary>
        /// <param name="element">The <see cref="IElement"/> to start the search from.</param>
        /// <returns>
        /// The root <see cref="IPackage"/> if found, or <c>null</c> if the element is not associated with any <see cref="IPackage"/> hierarchy.
        /// </returns>
        public static IPackage QueryRootPackage(this IElement element)
        {
            Guard.ThrowIfNull(element);

            if (element.Owner is not IPackage owner)
            {
                return element as IPackage;
            }

            var lastPackageFound = owner;

            while (owner != null)
            {
                lastPackageFound = owner;
                owner = owner.Owner as IPackage;
            }

            return lastPackageFound;
        }

        /// <summary>
        /// Queries and returns a collection of interfaces that are realized by the specified element.
        /// </summary>
        /// <param name="element">
        /// The element for which to query realized interfaces. This element should have an owner of type <see cref="IPackage"/>.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> of <see cref="IInterface"/> instances representing the interfaces
        /// realized by the specified element. If the element has no owner or no realizations, an empty enumeration is returned.
        /// </returns>
        public static IEnumerable<IInterface> QueryInterfaces(this IElement element)
        {
            Guard.ThrowIfNull(element);

            if (element.Owner is not IPackage)
            {
                yield break;
            }

            var allPackages = element.QueryRootPackage().QueryPackages();

            foreach (var package in allPackages)
            {
                foreach (var realization in package.PackagedElement.OfType<IRealization>()
                             .Where(x => x.Client.Any(c => c.XmiId == element.XmiId)))
                {
                    foreach (var @interface in realization.Supplier.OfType<IInterface>())
                    {
                        yield return @interface;
                    }
                }
            }
            
        }
        
        /// <summary>
        /// removes the specified html tags from the <paramref name="html"/>
        /// </summary>
        /// <param name="html">
        /// the string from which the unwanted html tags are to be removed
        /// </param>
        /// <param name="unwantedTags">
        /// list of unwanted html tags
        /// </param>
        /// <returns>
        /// a cleaned up string
        /// </returns>
        public static string RemoveUnwantedHtmlTags(this string html, List<string> unwantedTags)
        {
            if (string.IsNullOrEmpty(html))
            {
                return html;
            }

            var document = new HtmlDocument();
            document.LoadHtml(html);

            HtmlNodeCollection tryGetNodes = document.DocumentNode.SelectNodes("./*|./text()");

            if (tryGetNodes == null || !tryGetNodes.Any())
            {
                return html;
            }

            var nodes = new Queue<HtmlNode>(tryGetNodes);

            while (nodes.Count > 0)
            {
                var node = nodes.Dequeue();
                var parentNode = node.ParentNode;

                var childNodes = node.SelectNodes("./*|./text()");

                if (childNodes != null)
                {
                    foreach (var child in childNodes)
                    {
                        nodes.Enqueue(child);
                    }
                }

                if (unwantedTags.Any(tag => tag == node.Name))
                {
                    if (childNodes != null)
                    {
                        foreach (var child in childNodes)
                        {
                            parentNode.InsertBefore(child, node);
                        }
                    }

                    parentNode.RemoveChild(node);

                }
            }

            return document.DocumentNode.InnerHtml;
        }
    }
}
