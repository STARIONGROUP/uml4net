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
    using Microsoft.Extensions.Logging;
    using Settings;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// Resolves external references for XMI elements using provided settings and cache.
    /// </summary>
    /// <param name="cache">The cache containing XMI reader information.</param>
    /// <param name="httpClient">The HTTP client used for making requests to external resources.</param>
    /// <param name="settings">The settings for the XMI reader configuration.</param>
    /// <param name="logger">The logger for logging information and errors.</param>
    public class ExternalReferenceResolver(IXmiReaderCache cache, HttpClient httpClient, IXmiReaderSettings settings, ILogger<ExternalReferenceResolver> logger)
        : IExternalReferenceResolver
    {
        /// <summary>
        /// Asynchronously attempts to resolve external references and yields their context and stream.
        /// </summary>
        /// <returns>An asynchronous enumerable of tuples containing the context and stream of resolved references.</returns>
        public async IAsyncEnumerable<(string Context, Stream Stream)> TryResolve()
        {
            foreach (var identifier in cache.Cache.Values
                         .SelectMany(cacheEntry => cacheEntry.SingleValueReferencePropertyIdentifiers.Values))
            {
                if(await this.TryResolve(identifier) is { Stream: { Length: >0 } } reference)
                {
                    yield return reference;
                }
            }

            foreach (var identifiers in cache.Cache.Values
                         .SelectMany(cacheEntry => cacheEntry.MultiValueReferencePropertyIdentifiers.Values))
            {
                foreach (var identifier in identifiers)
                {
                    if (await this.TryResolve(identifier) is { Stream: { Length: > 0 } } reference)
                    {
                        yield return reference;
                    }
                }
            }
        }

        /// <summary>
        /// Asynchronously attempts to resolve an external reference identified by the specified key.
        /// </summary>
        /// <param name="key">The key representing the external reference to resolve.</param>
        /// <returns>A task that represents the asynchronous operation, containing a tuple with the context and stream if resolved; otherwise, a default value.</returns>
        private async Task<(string Context, Stream Stream)> TryResolve(string key)
        {
            if (string.IsNullOrEmpty(key) || key.StartsWith('#') || !key.Contains('#') || 
                !cache.TryResolveContext(key, out var resource))
            {
                logger.LogInformation("Invalid external resource key [{key}]", key);
                return default;
            }

            if (cache.DoesContextExists(resource.Context, resource.ResourceId))
            {
                logger.LogInformation("The resource {resource} was already parsed", resource.Context);
                return default;
            }
            
            try
            {
                var stream = default(Stream);

                if (Uri.TryCreate(key, UriKind.Absolute, out var uri))
                {
                    if (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps)
                    {
                        stream = await this.FetchRemoteXmi(uri);
                    }
                    if (uri.Scheme == Uri.UriSchemeFile)
                    {
                        stream = File.OpenRead(uri.LocalPath);
                    }
                }
                else if (key.StartsWith("pathmap://"))
                {
                    stream = this.ResolvePathmapResource(key);
                }
                else if (File.Exists(resource.Context))
                {
                    stream = File.OpenRead(resource.Context);
                }
                else
                {
                    logger.LogError("Unsupported external reference specified by {context}", resource.Context);
                    return default;
                }

                return (resource.Context, stream);
            }
            catch (Exception exception)
            {
                logger.LogError(exception,"Error resolving key '{key}': {message}", key, exception.Message);
            }

            return default;
        }

        /// <summary>
        /// Asynchronously fetches an XMI file from a remote URI.
        /// </summary>
        /// <param name="uri">The URI of the remote XMI file to fetch.</param>
        /// <returns>A task that represents the asynchronous operation, containing a stream of the fetched XMI file if successful; otherwise, <c>null</c>.</returns>
        private async Task<Stream> FetchRemoteXmi(Uri uri)
        {
            try
            {
                var response = await httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStreamAsync();
                }
            }
            catch (Exception exception)
            {
                logger.LogError(exception, "Error fetching remote XMI: {message}", exception.Message);
            }

            return default;
        }
        
        /// <summary>
        /// Resolves the file path of a resource identified by the specified key and returns a stream for it.
        /// </summary>
        /// <param name="key">The key representing the resource path to resolve.</param>
        /// <returns>A stream of the resource if the file exists; otherwise, <c>null</c>.</returns>
        private Stream ResolvePathmapResource(string key)
        {
            var mappedFilePath = key.Replace("pathmap://UML_PROFILES/", settings.UmlProfilesDirectoryPath);
            return File.Exists(mappedFilePath) ? File.OpenRead(mappedFilePath) : null;
        }
    }
}
