// -------------------------------------------------------------------------------------------------
// <copyright file="ElementExtensions.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2025 Starion Group S.A.
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
    /// The <see cref="ElementExtensions"/> class provides extensions methods for <see cref="IElement"/>
    /// </summary>
    public static class ElementExtensions
    {
        /// <summary>
        /// Gets the owning <see cref="IElement"/> that contains the specified <paramref name="element"/>.
        /// </summary>
        /// <param name="element">The <see cref="IElement"/> for which to retrieve the owner.</param>
        /// <returns>
        /// The <see cref="IElement"/> that acts as the container for the specified <paramref name="element"/>, 
        /// or <c>null</c> if the element does not have a container.
        /// </returns>
        public static IElement QueryOwner(this IElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            return element.Possessor;
        }

        /// <summary>
        /// Queries the Elements owned by this Element.
        /// </summary>
        /// <param name="element">
        /// The subject <see cref="IElement"/>
        /// </param>
        /// <returns>
        /// The Elements owned by this Element.
        /// </returns>
        public static IContainerList<IElement> QueryOwnedElement(this IElement element)
        {
            throw new NotSupportedException();
        }
    }
}
