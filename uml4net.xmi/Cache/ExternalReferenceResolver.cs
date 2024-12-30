// -------------------------------------------------------------------------------------------------
//  <copyright file="ExternalReferenceResolver.cs" company="Starion Group S.A.">
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
        /// Asynchronously attempts to resolve external references and yields their context and stream.
        /// </summary>
        /// <param>The current directory of the main resource</param>
        /// <returns>An enumerable of tuples containing the context and stream of resolved references.</returns>
        public IEnumerable<(string Context, Stream Stream)> TryResolve()
        {
            foreach (var identifier in cache.Cache.Values
                         .SelectMany(cacheEntry => cacheEntry.SingleValueReferencePropertyIdentifiers.Values))
            {
                if(this.TryResolve(identifier, out var reference))
                {
                    yield return reference;
                }
            }

            foreach (var identifiers in cache.Cache.Values
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
        /// <param name="key">The key representing the external reference to resolve.</param>
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

            if (this.IsInvalidKey(key) || !cache.TryResolveContext(key, out var resource))
            {
                logger.LogTrace("Resource key [{Key}] is not referencing an external resource", key);
                return false;
            }

            if (cache.DoesContextExists(resource.Context, resource.ResourceId))
            {
                logger.LogInformation("The resource {Resource} was already parsed", resource.Context);
                return false;
            }

            result.Context = resource.Context;

            try
            {
                result.Stream = this.ResolveStream(key, resource.Context);
                return result.Stream?.Length > 0;
            }
            catch (Exception exception)
            {
                logger.LogError(exception, "Error resolving key '{Key}': {Message}", key, exception.Message);
                return false;
            }
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
        private Stream ResolveStream(string key, string context)
        {
            if (Uri.TryCreate(key, UriKind.Absolute, out var uri))
            {
                if (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps)
                {
                    return this.ResolveRemoteResource(uri, context);
                }
                else if (uri.Scheme == Uri.UriSchemeFile && File.Exists(uri.LocalPath))
                {
                    return File.OpenRead(uri.LocalPath);
                }
            }

            return key.StartsWith("pathmap://") ? this.ResolvePathmapResource(key) :
                   File.Exists(context) ? File.OpenRead(context) :
                   null;
        }

        /// <summary>
        /// Attempts to resolve a remote resource by treating it as a local file.
        /// </summary>
        /// <param name="uri">The URI of the remote resource.</param>
        /// <param name="context">The resource context.</param>
        /// <returns>The <see cref="Stream"/> if the file exists locally; otherwise, <c>null</c>.</returns>
        private Stream ResolveRemoteResource(Uri uri, string context)
        {
            logger.LogWarning("The resource {Resource} is a reference to a remote resource which is unsupported by the Uml4Net library. An attempt to load the resource locally will be made", context);
            var localPath = Path.Combine(settings.LocalReferenceBasePath, Path.GetFileName(uri.AbsolutePath));
            
            return File.Exists(localPath) ? File.OpenRead(localPath) : null;
        }

        /// <summary>
        /// Resolves the file path of a resource identified by the specified key and returns a stream for it.
        /// </summary>
        /// <param name="key">The key representing the resource path to resolve.</param>
        /// <returns>A stream of the resource if the file exists; otherwise, <c>null</c>.</returns>
        private Stream ResolvePathmapResource(string key)
        {
            if (key.IndexOf('#') is var index && index <= 0)
            {
                return default;
            }

            var substring = key.Substring(0, index);

            if (settings.PathMapMap.TryGetValue(substring, out var resolvedPathmap)
                && File.Exists(resolvedPathmap))
            {
                return File.OpenRead(resolvedPathmap);
            }

            return  default;
        }
    }
}
