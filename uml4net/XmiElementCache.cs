// -------------------------------------------------------------------------------------------------
// <copyright file="XmiElementCache.cs" company="Starion Group S.A.">
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

namespace uml4net
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    /// <summary>
    /// A cache specifically designed for XMI elements, organized by context, to facilitate
    /// efficient lookups and storage during the reading of XMI files. This class provides methods
    /// to switch contexts, manage external references, and store elements for each context.
    /// </summary>
    /// <remarks>
    /// Each context typically corresponds to an individual XMI file, enabling the cache to
    /// organize elements on a per-file basis. Resolved external references are also tracked
    /// to prevent repeated processing of the same references.
    /// </remarks>
    public class XmiElementCache : IXmiElementCache
    {
        /// <summary>
        /// Gets the cached dictionary of XMI elements. The <see cref="IXmiElement.FullyQualifiedIdentifier" />
        /// is used as key, the <see cref="IXmiElement" /> is the value
        /// </summary>
        private readonly Dictionary<string, IXmiElement> cache = [];

        /// <summary>
        /// Gets the cached dictionary of extender objects, per <see cref="IXmiElement " />
        /// </summary>
        private readonly Dictionary<IXmiElement, List<object>> extenderCache = [];

        /// <summary>
        /// The number of elements without <see cref="IXmiElement.XmiId"/> that have been added, used to give each of
        /// them a unique key
        /// </summary>
        private int anonymousElementCount;

        /// <summary>
        /// The elements that carry an <c>xmi:uuid</c>, keyed by <c>{DocumentName}#{XmiGuid}</c>; the first element
        /// of a document with a given uuid is the one an XPointer uuid reference locates (XMI 2.5.1 clause 7.10.2)
        /// </summary>
        private readonly Dictionary<string, IXmiElement> uuidCache = [];

        /// <summary>
        /// Matches the XPointer form of an <c>xmi:uuid</c> reference, <c>xpointer((//*[@xmi:uuid='value'])[1])</c>
        /// (XMI 2.5.1 clause 7.10.2), capturing the value
        /// </summary>
        private static readonly Regex XPointerUuidExpression = new(@"^xpointer\(\(//\*\[@xmi:uuid=(['""])(?<uuid>.*?)\1\]\)\[1\]\)$", RegexOptions.Compiled, TimeSpan.FromMilliseconds(100));

        /// <summary>
        /// Tries to extract the <c>xmi:uuid</c> value from the fragment of a link that uses the XPointer form
        /// <c>xpointer((//*[@xmi:uuid='value'])[1])</c> (XMI 2.5.1 clause 7.10.2)
        /// </summary>
        /// <param name="fragment">
        /// The fragment of the link, the part after the <c>#</c>
        /// </param>
        /// <param name="uuid">
        /// The <c>xmi:uuid</c> value when the fragment has the XPointer uuid form, null otherwise
        /// </param>
        /// <returns>
        /// true when the fragment has the XPointer uuid form, false otherwise
        /// </returns>
        public static bool TryParseXPointerUuid(string fragment, out string uuid)
        {
            uuid = null;

            if (string.IsNullOrEmpty(fragment))
            {
                return false;
            }

            Match match;

            try
            {
                match = XPointerUuidExpression.Match(fragment);
            }
            catch (RegexMatchTimeoutException)
            {
                // a fragment that takes longer than the match timeout is not a well-formed uuid pointer
                return false;
            }

            if (!match.Success)
            {
                return false;
            }

            uuid = match.Groups["uuid"].Value;
            return true;
        }

        /// <summary>
        /// Gets a collection containing the values in the Cache.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.Dictionary`2.ValueCollection"></see> containing
        /// the values in the Cache.
        /// </returns>
        public Dictionary<string, IXmiElement>.ValueCollection Values => this.cache.Values;

        /// <summary>
        /// Gets a collection containing the keys in the cache.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.Dictionary`2.KeyCollection"></see> containing the keys in the cache.
        /// </returns>
        public Dictionary<string, IXmiElement>.KeyCollection Keys => this.cache.Keys;

        /// <summary>
        /// Gets the number of key/value pairs contained in the Cache.
        /// </summary>
        /// <returns>
        /// The number of key/value pairs contained in the Cache.
        /// </returns>
        public int Count => this.cache.Count;

        /// <summary>
        /// Tries to add the specified XMI element to the cache using the <see cref="IXmiElement.FullyQualifiedIdentifier" />
        /// as the key. An element without <see cref="IXmiElement.XmiId"/> is added under a synthetic unique key, so that
        /// every such element is part of the cache (and is assembled) although it cannot be looked up by identifier
        /// </summary>
        /// <param name="element">
        /// The XMI element to be added to the Cache
        /// </param>
        /// <returns>
        /// true if the element was added, false if the element was already present in the
        /// cache and could not be added again
        /// </returns>
        public bool TryAdd(IXmiElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            // xmi:id is optional (XMI 2.5.1 clause 7.6.1); an element without one cannot be referenced, but its
            // own references, hrefs and extensions still have to be processed, so it is cached under a synthetic
            // key that cannot clash with an xmi:id instead of the shared "document#" identifier
            var key = string.IsNullOrEmpty(element.XmiId)
                ? $"{element.FullyQualifiedIdentifier}<anonymous:{++this.anonymousElementCount}>"
                : element.FullyQualifiedIdentifier;

            if (this.cache.ContainsKey(key))
            {
                return false;
            }

            this.cache.Add(key, element);
            element.Cache = this;

            // the first element of a document with a given xmi:uuid is the one an XPointer uuid reference locates
            if (!string.IsNullOrEmpty(element.XmiGuid))
            {
                var uuidKey = $"{element.DocumentName}#{element.XmiGuid}";

                if (!this.uuidCache.ContainsKey(uuidKey))
                {
                    this.uuidCache.Add(uuidKey, element);
                }
            }

            return true;
        }

        /// <summary>Gets the value associated with the specified key.</summary>
        /// <param name="key">The key of the value to get.</param>
        /// <param name="value">When this method returns, contains the value associated with the specified key, if the key is found; otherwise, the default value for the type of the value parameter. This parameter is passed uninitialized.</param>
        /// <returns>true if the Cache contains an element with the specified key; otherwise, false.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="key">key</paramref> is null.</exception>
        public bool TryGetValue(string key, out IXmiElement value)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException(nameof(key));
            }

            if (this.cache.TryGetValue(key, out value))
            {
                return true;
            }

            // a link in the XPointer uuid form, {document}#xpointer((//*[@xmi:uuid='value'])[1]), locates the first
            // element of the document with that xmi:uuid (XMI 2.5.1 clause 7.10.2)
            var hashIndex = key.IndexOf('#');

            if (hashIndex >= 0 && TryParseXPointerUuid(key.Substring(hashIndex + 1), out var uuid)
                && this.uuidCache.TryGetValue($"{key.Substring(0, hashIndex)}#{uuid}", out value))
            {
                return true;
            }

            value = default;
            return false;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the key-value pairs in the Cache
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.Dictionary`2.Enumerator"></see> structure
        /// </returns>
        public Dictionary<string, IXmiElement>.Enumerator GetEnumerator()
        {
            return this.cache.GetEnumerator();
        }

        /// <summary>
        /// Removes all keys and values from the Cache
        /// </summary>
        public void Clear()
        {
            this.cache.Clear();
            this.uuidCache.Clear();
            this.extenderCache.Clear();
            this.anonymousElementCount = 0;
        }

        /// <summary>
        /// Adds an <see cref="object" /> that extends an <see cref="IXmiElement" /> into the cache storage
        /// </summary>
        /// <param name="xmiElement">An extended <see cref="IXmiElement" /></param>
        /// <param name="extender">The extender <see cref="object" /></param>
        /// <exception cref="ArgumentNullException">
        /// If the provided <paramref name="xmiElement" /> or the
        /// <paramref name="extender" /> is null
        /// </exception>
        public void AddExtender(IXmiElement xmiElement, object extender)
        {
            if (xmiElement == null)
            {
                throw new ArgumentNullException(nameof(xmiElement));
            }

            if (extender == null)
            {
                throw new ArgumentNullException(nameof(extender));
            }

            if (this.extenderCache.TryGetValue(xmiElement, out var extenders))
            {
                extenders.Add(extender);
            }
            else
            {
                this.extenderCache[xmiElement] = [extender];
            }
        }

        /// <summary>
        /// Tries to get the collection of extenders <see cref="object" /> for an <see cref="IXmiElement" />
        /// </summary>
        /// <param name="xmiElement">The <see cref="IXmiElement" /></param>
        /// <param name="extenders">
        /// When this method returns, contains extenders <see cref="object" /> associated with the specified
        /// <see cref="IXmiElement" />, if the key is found;
        /// otherwise, the default value for the type of the value parameter. This parameter is passed uninitialized.
        /// </param>
        /// <returns>true if the Cache contains an element with the specified key; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">If the provided <paramref name="xmiElement" /> is null</exception>
        public bool TryGetExtenders(IXmiElement xmiElement, out IReadOnlyCollection<object> extenders)
        {
            if (xmiElement == null)
            {
                throw new ArgumentNullException(nameof(xmiElement));
            }

            if (this.extenderCache.TryGetValue(xmiElement, out var extendersList))
            {
                extenders = extendersList;
                return true;
            }

            extenders = null;
            return false;
        }
    }
}
