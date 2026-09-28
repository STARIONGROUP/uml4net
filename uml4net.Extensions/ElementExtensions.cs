// -------------------------------------------------------------------------------------------------
// <copyright file="ElementExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    using HtmlAgilityPack;

    using uml4net.CommonStructure;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;

    /// <summary>
    /// Extension methods for <see cref="IElement"/> interface
    /// </summary>
    public static class ElementExtensions
    {
        /// <summary>
        /// Matches a run of white space that holds at least one line break
        /// </summary>
        private static readonly Regex LineBreakExpression = new(@"\s*[\r\n]\s*", RegexOptions.Compiled, TimeSpan.FromSeconds(1));

        /// <summary>
        /// Queries the documentation from the <see cref="IElement"/> and
        /// returns it as a string
        /// </summary>
        /// <param name="element">
        /// The subject <see cref="IElement"/> for which the documentation is queried
        /// </param>
        /// <returns>
        /// The documentation of the <see cref="IElement"/> stripped from unwanted HTML tags
        /// and split to lines of 100 characters long; every owned comment, in order, starts on a new line
        /// </returns>
        public static IEnumerable<string> QueryDocumentation(this IElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            return QueryCommentTexts(element).SelectMany(x => x.SplitToLines(100)).ToList();
        }

        /// <summary>
        /// Queries the documentation from the <paramref name="element"/>> and
        /// returns it as a string
        /// </summary>
        /// <param name="element">
        /// The subject <see cref="IElement"/> for which the documentation is queried
        /// </param>
        /// <returns>
        /// The documentation of the <see cref="IElement"/> stripped from unwanted HTML tags, on a single line; the
        /// owned comments, in order, are separated by a space
        /// </returns>
        public static string QueryRawDocumentation(this IElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            return string.Join(" ", QueryCommentTexts(element));
        }

        /// <summary>
        /// Queries the text of every owned comment of the <paramref name="element"/> that has a body, in order,
        /// stripped from unwanted HTML tags and on a single line
        /// </summary>
        /// <param name="element">
        /// The subject <see cref="IElement"/>
        /// </param>
        /// <returns>
        /// The texts of the owned comments (<c>Element::ownedComment</c> is <c>[0..*]</c>)
        /// </returns>
        /// <remarks>
        /// Every run of white space that holds a line break is replaced by a single space, so that the words on
        /// adjacent lines of a comment body stay apart.
        /// </remarks>
        private static IEnumerable<string> QueryCommentTexts(IElement element)
        {
            var unwantedTags = new List<string> { "p", "code", "em", "tt" };

            return element.OwnedComment
                .Where(x => !string.IsNullOrEmpty(x.Body))
                .Select(x => LineBreakExpression.Replace(x.Body.RemoveUnwantedHtmlTags(unwantedTags), " ").Trim())
                .Where(x => x.Length > 0);
        }

        /// <summary>
        /// Retrieves the root <see cref="IPackage"/> in the hierarchy of the specified <paramref name="element"/>.
        /// </summary>
        /// <param name="element">The <see cref="IElement"/> to start the search from.</param>
        /// <returns>
        /// The outermost <see cref="IPackage"/> on the <see cref="IElement.Owner"/> chain of the <paramref name="element"/>,
        /// the <paramref name="element"/> itself included, or <c>null</c> when that chain holds no <see cref="IPackage"/>.
        /// </returns>
        /// <remarks>
        /// The owners in between can be of any kind: a nested classifier is owned by a Class or an Interface, a
        /// classifier can be packaged in a Component, and a feature is owned by its classifier.
        /// </remarks>
        public static IPackage QueryRootPackage(this IElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            IPackage rootPackage = null;

            for (var current = element; current != null; current = current.Owner)
            {
                if (current is IPackage package)
                {
                    rootPackage = package;
                }
            }

            return rootPackage;
        }

        /// <summary>
        /// Queries and returns a collection of interfaces that are realized by the specified element.
        /// </summary>
        /// <param name="element">
        /// The element for which to query realized interfaces.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> of <see cref="IInterface"/> instances representing the interfaces
        /// realized by the specified element, each one once. If the element has no realizations, an empty enumeration is returned.
        /// </returns>
        /// <remarks>
        /// Follows <c>Classifier::directlyRealizedInterfaces()</c>: the interfaces that are the contract or a supplier of
        /// the InterfaceRealizations owned by the element (<c>BehavioredClassifier::interfaceRealization</c>), and the
        /// interfaces that are a supplier of a Realization packaged in a package of the model with the element as client.
        /// </remarks>
        public static IEnumerable<IInterface> QueryInterfaces(this IElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            return QueryInterfacesIterator(element);
        }

        /// <summary>
        /// Queries and returns a collection of interfaces that are realized by the specified element.
        /// </summary>
        /// <param name="element">
        /// The element for which to query realized interfaces.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> of <see cref="IInterface"/> instances representing the interfaces
        /// realized by the specified element. If the element is not contained by a <see cref="IPackage"/> or has no
        /// realizations, an empty enumeration is returned.
        /// </returns>
        private static IEnumerable<IInterface> QueryInterfacesIterator(IElement element)
        {
            var found = new HashSet<IInterface>();

            // the InterfaceRealizations owned by a BehavioredClassifier (BehavioredClassifier::interfaceRealization);
            // InterfaceRealization::contract subsets Dependency::supplier and is stored on its own
            if (element is IBehavioredClassifier behavioredClassifier)
            {
                foreach (var interfaceRealization in behavioredClassifier.InterfaceRealization)
                {
                    if (interfaceRealization.Contract != null && found.Add(interfaceRealization.Contract))
                    {
                        yield return interfaceRealization.Contract;
                    }

                    foreach (var @interface in interfaceRealization.Supplier.OfType<IInterface>().Where(found.Add))
                    {
                        yield return @interface;
                    }
                }
            }

            // the Realizations that are packaged elements of the packages of the model, as some tools export them
            var rootPackage = element.QueryRootPackage();

            if (rootPackage == null)
            {
                yield break;
            }

            var allPackages = rootPackage.QueryPackages();

            foreach (var package in allPackages)
            {
                foreach (var realization in package.PackagedElement.OfType<IRealization>()
                             .Where(x => x.Client.Any(c => c.XmiId == element.XmiId)))
                {
                    foreach (var @interface in realization.Supplier.OfType<IInterface>().Where(found.Add))
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
