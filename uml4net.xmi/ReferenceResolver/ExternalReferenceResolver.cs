// -------------------------------------------------------------------------------------------------
//  <copyright file="ExternalReferenceResolver.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.ReferenceResolver
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Microsoft.Extensions.Logging;
    
    using uml4net.xmi.Settings;
    

    /// <summary>
    /// Resolves external references for XMI elements using provided settings and cache.
    /// </summary>
    /// <param name="cache">The cache containing XMI reader information.</param>
    /// <param name="settings">The settings for the XMI reader configuration.</param>
    /// <param name="logger">The logger for logging information and errors.</param>
    public class ExternalReferenceResolver(IXmiElementCache cache, IXmiReaderSettings settings, ILogger<ExternalReferenceResolver> logger)
        : IExternalReferenceResolver
    {
        /// <summary>
        /// a cache of processed external references
        /// </summary>
        private readonly HashSet<string> externalReferencesCache = [];

        /// <summary>
        /// Asynchronously attempts to resolve external references and yields their context and stream.
        /// </summary>
        /// <param>
        /// The current directory of the main resource
        /// </param>
        /// <returns>
        /// An IEnumerable of tuples containing the context and stream of resolved references.
        /// </returns>
        public IEnumerable<(string Context, Stream Stream)> TryResolve()
        {
            foreach (var identifier in cache.Values
                         .SelectMany(cacheEntry => cacheEntry.SingleValueReferencePropertyIdentifiers.Values))
            {
                if(this.TryResolve(identifier, out var reference))
                {
                    yield return reference;
                }
            }

            foreach (var identifiers in cache.Values
                         .SelectMany(cacheEntry => cacheEntry.MultiValueReferencePropertyIdentifiers.Values))
            {
                foreach (var identifier in identifiers)
                {
                    if (this.TryResolve(identifier, out var reference))
                    {
                        yield return reference;
                    }
                }
            }
        }
        /// <summary>
        /// Attempts to resolve an external reference identified by the specified key.
        /// </summary>
        /// <param name="key">
        /// The key representing the external reference to resolve.
        /// </param>
        /// <param name="result">
        /// When this method returns, contains a tuple with the context and stream if the reference is resolved; 
        /// otherwise, it is set to a default value.
        /// </param>
        /// <returns>
        /// <c>true</c> if the external reference is successfully resolved; otherwise, <c>false</c>.
        /// </returns>
        private bool TryResolve(string key, out (string Context, Stream Stream) result)
        {
            result = default;

            if (this.IsInvalidKey(key) || !this.TryResolveContext(key, out var resource))
            {
                logger.LogTrace("Resource key [{Key}] is not referencing an external resource", key);
                return false;
            }

            if (this.externalReferencesCache.Contains(resource.Context))
            {
                logger.LogDebug("The resource {Resource} was already parsed", resource.Context);
                return false;
            }

            try
            {
                var resolveResult = this.ResolveStream(key, resource.Context);

                if (resolveResult == null)
                {
                    logger.LogWarning("The resolving key '{Key}' from context '{Context}' could not be resolved", key, resource.Context);
                    return false;
                }

                result.Stream = resolveResult.Item1;
                result.Context = resource.Context;

                this.externalReferencesCache.Add(resource.Context);

                return result.Stream?.Length > 0;
            }
            catch (Exception exception)
            {
                logger.LogError(exception, "Error resolving key '{Key}': {Message}", key, exception.Message);
                return false;
            }
        }

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
        /// <returns>
        /// <c>true</c> if the context and resource ID were successfully resolved and, if applicable, the 
        /// context exists in the global cache; otherwise, <c>false</c>.
        /// </returns>
        private bool TryResolveContext(string resourceKey, out (string Context, string ResourceId) resolvedContextAndResource)
        {
            var referenceString = resourceKey.Split(['#'], StringSplitOptions.RemoveEmptyEntries);

            if (referenceString.Length == 2)
            {
                resolvedContextAndResource = new ValueTuple<string, string>(referenceString[0], referenceString[1]);
            }
            else
            {
                resolvedContextAndResource = new ValueTuple<string, string>("_", resourceKey);
            }

            return true;
        }

        /// <summary>
        /// Checks if the key is invalid for resolving.
        /// </summary>
        /// <param name="key">The key to check.</param>
        /// <returns><c>true</c> if the key is invalid; otherwise, <c>false</c>.</returns>
        private bool IsInvalidKey(string key) =>
            string.IsNullOrEmpty(key) || key.StartsWith("#") || !key.Contains("#");

        /// <summary>
        /// Resolves the appropriate stream based on the key and context.
        /// </summary>
        /// <param name="key">The key representing the resource location.</param>
        /// <param name="context">The resource context path.</param>
        /// <returns>The resolved <see cref="Stream"/> if found; otherwise, <c>null</c>.</returns>
        private Tuple<Stream, string> ResolveStream(string key, string context)
        {
            if (Uri.TryCreate(key, UriKind.Absolute, out var uri))
            {
                if (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps)
                {
                    return this.ResolveRemoteResource(uri, context);
                }
                else if (uri.Scheme == Uri.UriSchemeFile && File.Exists(uri.LocalPath))
                {
                    return new Tuple<Stream, string>(File.OpenRead(uri.LocalPath), uri.LocalPath) ;
                }
            }

            return key.StartsWith("pathmap://") ? this.ResolvePathmapResource(key) :
                   File.Exists(context) ? new Tuple<Stream, string>(File.OpenRead(context), context)  :
                   null;
        }

        /// <summary>
        /// Attempts to resolve a remote resource by treating it as a local file.
        /// </summary>
        /// <param name="uri">The URI of the remote resource.</param>
        /// <param name="context">The resource context.</param>
        /// <returns>The <see cref="Stream"/> if the file exists locally; otherwise, <c>null</c>.</returns>
        private Tuple<Stream, string> ResolveRemoteResource(Uri uri, string context)
        {
            logger.LogWarning("The resource {Resource} is a reference to a remote resource which is unsupported by the Uml4Net library. An attempt to load the resource locally will be made", context);

            var fileName = Path.GetFileName(uri.AbsolutePath);

            var localPath = Path.Combine(settings.LocalReferenceBasePath, fileName);
            
            return File.Exists(localPath) ? new Tuple<Stream, string>(File.OpenRead(localPath), fileName) : null;
        }

        /// <summary>
        /// Resolves the file path of a resource identified by the specified key and returns a stream for it.
        /// </summary>
        /// <param name="key">The key representing the resource path to resolve.</param>
        /// <returns>A stream of the resource if the file exists; otherwise, <c>null</c>.</returns>
        private Tuple<Stream, string> ResolvePathmapResource(string key)
        {
            if (key.IndexOf('#') is var index && index <= 0)
            {
                return default;
            }

            var substring = key.Substring(0, index);

            if (settings.PathMaps.TryGetValue(substring, out var resolvedPathmap)
                && File.Exists(resolvedPathmap))
            {
                return new Tuple<Stream, string>(File.OpenRead(resolvedPathmap), resolvedPathmap);
            }

            return  default;
        }
    }
}
