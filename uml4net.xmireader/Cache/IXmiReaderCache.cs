// -------------------------------------------------------------------------------------------------
//  <copyright file="ICache.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Cache
{
    using POCO;

    using System.Collections.Concurrent;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a cache for storing and retrieving XMI elements during the reading process.
    /// </summary>
    public interface IXmiReaderCache
    {
        /// <summary>
        /// Provides a cache for storing XMI elements with unique IDs, organized by context. 
        /// Each <see cref="IXmiElement"/> is stored in a nested dictionary keyed by its context 
        /// (representing the XMI file) and the element’s unique identifier within that context.
        /// </summary>
        ConcurrentDictionary<string, Dictionary<string, IXmiElement>> GlobalCache { get; }

        /// <summary>
        /// Gets the collection of XMI elements associated with the current context. This 
        /// dictionary maps unique identifiers to their corresponding <see cref="IXmiElement"/> instances 
        /// within the active context.
        /// </summary>
        Dictionary<string, IXmiElement> Cache { get; }

        /// <summary>
        /// Switches the current context to a new XMI file, allowing elements to be stored 
        /// under a distinct key in the cache. Initializes an empty dictionary in <see cref="XmiReaderCache.Cache"/> 
        /// for the specified context if it does not exist.
        /// </summary>
        /// <param name="context">The unique identifier for the new context, typically the XMI file name.</param>
        void SwitchContext(string context);

        /// <summary>
        /// Adds the specified XMI element to the cache under the current context.
        /// If the context does not already exist, the default one is used. It can be changed via <see cref="XmiReaderCache.SwitchContext"/>.
        /// </summary>
        /// <param name="id">The unique identifier of the XMI element within the current context.</param>
        /// <param name="element">The XMI element to be added to the cache.</param>
        void Add(string id, IXmiElement element);

        /// <summary>
        /// Checks whether the specified context exists in the cache and optionally verifies the existence of a specific key within that context.
        /// </summary>
        /// <param name="context">
        /// The context name to check within the cache.
        /// </param>
        /// <param name="key">
        /// (Optional) The specific key to check within the specified context. If <c>null</c>, the method only verifies if the context exists
        /// and contains any entries.
        /// </param>
        /// <returns>
        /// <c>true</c> if the context is missing, contains no entries, or if a specified key exists in the context with a non-null value;
        /// otherwise, <c>false</c>.
        /// </returns>
        bool DoesContextExists(string context, string key = null);

        /// <summary>
        /// Attempts to retrieve an <see cref="IXmiElement"/> instance from the cache 
        /// based on the specified <paramref name="context"/> and <paramref name="key"/>. 
        /// Returns <c>true</c> if both the context and key exist in the cache, otherwise <c>false</c>.
        /// </summary>
        /// <param name="context">The context in which the element is stored, typically representing an XMI file.</param>
        /// <param name="key">The unique identifier of the XMI element within the specified context.</param>
        /// <param name="value">
        /// When this method returns, contains the <see cref="IXmiElement"/> associated with the specified 
        /// context and key, if found; otherwise, <c>default</c>.
        /// </param>
        /// <returns>
        /// <c>true</c> if the element is found in the cache with the specified context and key; otherwise, <c>false</c>.
        /// </returns>
        bool TryGetValue(string context, string key, out IXmiElement value);

        /// <summary>
        /// Attempts to resolve the context and resource ID from the specified resource key.
        /// </summary>
        /// <param name="resourceKey">
        /// The key representing the resource, which may contain context and resource ID separated by '#'.
        /// </param>
        /// <param name="resolvedContextAndResource">
        /// When this method returns, contains a tuple with the resolved context and resource ID if successful; 
        /// otherwise, <c>(null, null)</c> if unsuccessful.
        /// </param>
        /// <param name="validateContextExistence">
        /// If <c>true</c>, checks whether the resolved context exists in the global cache. If <c>false</c>, 
        /// performs no such check.
        /// </param>
        /// <returns>
        /// <c>true</c> if the context and resource ID were successfully resolved and, if applicable, the 
        /// context exists in the global cache; otherwise, <c>false</c>.
        /// </returns>
        bool TryResolveContext(string resourceKey, out (string Context, string ResourceId) resolvedContextAndResource, bool validateContextExistence = false);
    }
}
