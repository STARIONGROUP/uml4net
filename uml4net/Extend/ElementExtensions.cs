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

namespace uml4net.CommonStructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The <see cref="ElementExtensions"/> class provides extensions methods for <see cref="IElement"/>
    /// </summary>
    internal static class ElementExtensions
    {
        /// <summary>
        /// Gets the owning <see cref="IElement"/> that contains the specified <paramref name="element"/>.
        /// </summary>
        /// <param name="element">The <see cref="IElement"/> for which to retrieve the owner.</param>
        /// <returns>
        /// The <see cref="IElement"/> that acts as the container for the specified <paramref name="element"/>,
        /// or <c>null</c> if the element does not have a container.
        /// </returns>
        internal static IElement QueryOwner(this IElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            return element.Possessor;
        }

        /// <summary>
        /// Queries every <see cref="IElement"/> that exists in the same model as the specified
        /// <paramref name="element"/>: the containment tree the <paramref name="element"/> lives in, and every
        /// element known to its <see cref="IXmiElement.Cache"/> (or to that of its nearest owner that has one)
        /// together with the elements they own.
        /// </summary>
        /// <param name="element">
        /// The subject <see cref="IElement"/>
        /// </param>
        /// <returns>
        /// every <see cref="IElement"/> of the model, each one once, starting with the containment tree of the
        /// <paramref name="element"/>.
        /// </returns>
        /// <remarks>
        /// Emulates OCL's <c>allInstances()</c>. The extent is the set of elements of a read: the
        /// <see cref="IXmiElementCache"/> of an <c>IXmiReader</c> holds every element read from the main
        /// document and from the external documents it references (profiles, libraries, the UML metamodel), across
        /// all root elements. The containment tree of the <paramref name="element"/> and of every cached element is
        /// walked as well, so that elements created in code and added to a read model, or a model that was built in
        /// code and has no cache, are included. Callers typically filter the result with <c>OfType&lt;T&gt;()</c>
        /// to emulate <c>T.allInstances()</c>.
        /// </remarks>
        internal static IEnumerable<IElement> QueryAllInstancesInModel(this IElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            // an element created in code has no cache of its own; when it was added to a read model, the cache of the
            // nearest owner that was read is used
            var root = element;
            var cache = element.Cache;

            while (root.Owner != null)
            {
                root = root.Owner;
                cache ??= root.Cache;
            }

            var startingPoints = new List<IElement> { root };

            if (cache != null)
            {
                startingPoints.AddRange(cache.Values.OfType<IElement>());
            }

            var visited = new HashSet<IElement>();

            foreach (var startingPoint in startingPoints)
            {
                var elementsToProcess = new Stack<IElement>();
                elementsToProcess.Push(startingPoint);

                while (elementsToProcess.Count > 0)
                {
                    var current = elementsToProcess.Pop();

                    if (!visited.Add(current))
                    {
                        continue;
                    }

                    yield return current;

                    foreach (var ownedElement in current.OwnedElement)
                    {
                        elementsToProcess.Push(ownedElement);
                    }
                }
            }
        }
    }
}
