// -------------------------------------------------------------------------------------------------
//  <copyright file="IXmiElementCache.cs" company="Starion Group S.A.">
// 
//    Copyright (C) 2019-2025 Starion Group S.A.
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

namespace uml4net
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a cache for storing and retrieving XMI elements during the reading process.
    /// </summary>
    public interface IXmiElementCache
    {
        /// <summary>
        /// Adds the specified XMI element to the cache using the <see cref="IXmiElement.FullyQualifiedIdentifier"/>
        /// as the key
        /// </summary>
        /// <param name="element">The XMI element to be added to the cache.</param>
        /// <returns>
        /// true if the element was added, false if the element was already present in the
        /// cache and could not be added again
        /// </returns>
        bool TryAdd(IXmiElement element);

        /// <summary>Gets the value associated with the specified key.</summary>
        /// <param name="key">The key of the value to get.</param>
        /// <param name="value">When this method returns, contains the value associated with the specified key, if the key is found; otherwise, the default value for the type of the value parameter. This parameter is passed uninitialized.</param>
        /// <returns>true if the Cache contains an element with the specified key; otherwise, false.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="key">key</paramref> is null.</exception>
        bool TryGetValue(string key, out IXmiElement value);

        /// <summary>
        /// Returns an enumerator that iterates through the key-value pairs in the Cache
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.Dictionary`2.Enumerator"></see> structure
        /// </returns>
        public Dictionary<string, IXmiElement>.Enumerator GetEnumerator();

        /// <summary>
        /// Gets a collection containing the values in the Cache.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.Dictionary`2.ValueCollection"></see> containing
        /// the values in the Cache.
        /// </returns>
        public Dictionary<string, IXmiElement>.ValueCollection Values { get; }

        /// <summary>
        /// Gets a collection containing the keys in the cache.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.Dictionary`2.KeyCollection"></see> containing the keys in the cache.
        /// </returns>
        public Dictionary<string, IXmiElement>.KeyCollection Keys { get; }

        /// <summary>
        /// Gets the number of key/value pairs contained in the Cache.
        /// </summary>
        /// <returns>
        /// The number of key/value pairs contained in the Cache.
        /// </returns>
        public int Count { get; }

        /// <summary>
        /// Removes all keys and values from the Cache
        /// </summary>
        public void Clear();
    }
}
