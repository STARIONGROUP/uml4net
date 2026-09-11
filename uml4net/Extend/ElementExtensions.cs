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
        /// Queries every <see cref="IElement"/> in the model that the specified <paramref name="element"/>
        /// belongs to, by walking up to the containment root and then down through <see cref="IElement.OwnedElement"/>.
        /// </summary>
        /// <param name="element">
        /// The subject <see cref="IElement"/>
        /// </param>
        /// <returns>
        /// every <see cref="IElement"/> reachable from the containment root, including the root itself.
        /// </returns>
        /// <remarks>
        /// Used to emulate OCL's <c>allInstances()</c>, which uml4net has no registry for.
        /// </remarks>
        internal static IEnumerable<IElement> QueryModelElements(this IElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            var root = element;

            while (root.Owner != null)
            {
                root = root.Owner;
            }

            var visited = new HashSet<IElement>();
            var elementsToProcess = new Stack<IElement>();
            elementsToProcess.Push(root);

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
