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
//    Unless required by applicable law or agreed to in writing, software
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
    
    using uml4net.xmi.Resources;
    using uml4net.xmi.Settings;

    /// <summary>
    /// Resolves external references for XMI elements using provided settings and cache.
    /// </summary>
    /// <param name="resourceLoader">
    /// The (injected) <see cref="IResourceLoader"/> used for loading embedded resources
    /// </param>
    /// <param name="cache">
    /// The (injected) cache containing XMI reader information.
    /// </param>
    /// <param name="settings">
    /// The (injected) settings for the XMI reader configuration.
    /// </param>
    /// <param name="logger">
    /// The (injected) logger used for logging.
    /// </param>
    public class ExternalReferenceResolver(IResourceLoader resourceLoader, IXmiElementCache cache, IXmiReaderSettings settings, ILogger<ExternalReferenceResolver> logger)
        : IExternalReferenceResolver
    {
        /// <summary>
        /// a cache of processed external references
        /// </summary>
        private readonly HashSet<string> externalReferencesCache = [];

        /// <summary>
        /// Asynchronously attempts to resolve external references and yields their context and stream.
        /// </summary>
        /// <param name="documentName">
        /// the name of the XMI document for which the external references are being resolved.
        /// </param>
        /// <returns>
        /// An IEnumerable of tuples containing the context and stream of resolved references.
        /// </returns>
        public IReadOnlyList<(string Context, Stream Stream)> TryResolve(string documentName)
        {
            this.externalReferencesCache.Add(documentName);

            var result = new List<(string Context, Stream Stream)>();

            var singleValueReferencePropertyIdentifiers = cache.Values
                .SelectMany(cacheEntry => cacheEntry.SingleValueReferencePropertyIdentifiers.Values).ToList();

            foreach (var identifier in singleValueReferencePropertyIdentifiers)
            {
                if(this.TryResolve(identifier, out var reference))
                {
                    result.Add(reference);
                }
            }

            var multiValueReferencePropertyIdentifiers = cache.Values
                .SelectMany(cacheEntry => cacheEntry.MultiValueReferencePropertyIdentifiers.Values).ToList();

            foreach (var identifiers in multiValueReferencePropertyIdentifiers)
            {
                foreach (var identifier in identifiers)
                {
                    if (this.TryResolve(identifier, out var reference))
                    {
                        result.Add(reference);
                    }
                }
            }

            return result;
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

            if (this.IsInvalidExternalResourceKey(key) || !this.TryResolveContext(key, out var externalResource))
            {
                logger.LogTrace("Resource key [{Key}] is not referencing an external resource", key);
                return false;
            }

            if (this.externalReferencesCache.Contains(externalResource.Context))
            {
                logger.LogDebug("The external resource {Resource} was already parsed", externalResource.Context);
                return false;
            }

            try
            {
                var resolvedStreamResult = this.ResolveStream(key, externalResource.Context);

                if (resolvedStreamResult == null)
                {
                    logger.LogWarning("The resolving key '{Key}' from context '{Context}' could not be resolved", key, externalResource.Context);
                    return false;
                }

                result.Stream = resolvedStreamResult.Item1;
                result.Context = externalResource.Context;

                this.externalReferencesCache.Add(externalResource.Context);

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
            
            resolvedContextAndResource = new ValueTuple<string, string>(referenceString[0], referenceString[1]);

            return true;
        }

        /// <summary>
        /// Checks if the key is invalid for resolving from an external resource
        /// </summary>
        /// <param name="key">
        /// The key to check.
        /// </param>
        /// <returns>
        /// <c>true</c> if the key is invalid; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// an invalid key is a key that:
        ///   starts with #
        ///   does not contain 1 #
        ///   contains more than 1 #
        /// contains the # sign at most once
        /// </remarks>
        private bool IsInvalidExternalResourceKey(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return true;
            }

            var firstIndex = key.IndexOf('#');

            // check if starts with #
            if (firstIndex == 0)
            {
                return true;
            }

            int lastIndex = key.LastIndexOf('#');

            // check if at most 1 #
            return !(firstIndex != -1 && firstIndex == lastIndex);
        }

        /// <summary>
        /// Resolves the appropriate stream based on the key and context.
        /// </summary>
        /// <param name="key">
        /// The key representing the resource location.
        /// </param>
        /// <param name="context">
        /// The resource context path.
        /// </param>
        /// <returns>
        /// The resolved <see cref="Stream"/> if found; otherwise, <c>null</c>.
        /// </returns>
        /// <remarks>
        /// The following kinds of context are supported:
        ///   - http: or https: - either resolves to a known resource that is embedded
        ///     or tries to load from a local file that has the same name as the last part of the uri
        ///     
        ///   - file: a file on the filesystem
        ///   - pathmap: a mapping to a local file
        ///   - resource-name#referfence-name: the resource-name is a name of file in the same directory
        ///     as the current xmi file
        /// </remarks>
        private Tuple<Stream, string> ResolveStream(string key, string context)
        {
            if (resourceLoader.TryLoadKnownResource(key, out var knownResourceStream))
            {
                return new Tuple<Stream, string>(knownResourceStream, context);
            }

            if (Uri.TryCreate(key, UriKind.Absolute, out var uri))
            {
                if (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps || uri.Scheme == Uri.UriSchemeFtp)
                {
                    return this.ResolveRemoteResource(uri);
                }

                if (uri.Scheme == Uri.UriSchemeFile && File.Exists(uri.LocalPath))
                {
                    return new Tuple<Stream, string>(File.OpenRead(uri.LocalPath), uri.LocalPath) ;
                }
            }

            if (key.StartsWith("pathmap://"))
            {
                return this.ResolvePathmapResource(key);
            }

            var localPath = Path.Combine(settings.LocalReferenceBasePath, context);
            if (File.Exists(localPath))
            {
                return new Tuple<Stream, string>(File.OpenRead(localPath), context);
            }

            return null;
        }

        /// <summary>
        /// Attempts to resolve a remote resource by treating it as a local file.
        /// </summary>
        /// <param name="uri">
        /// The URI of the remote resource.
        /// </param>
        /// <returns>
        /// The <see cref="Stream"/> if the file exists locally; otherwise, <c>null</c>.
        /// </returns>
        private Tuple<Stream, string> ResolveRemoteResource(Uri uri)
        {
            logger.LogWarning("The resource {Resource} is a reference to a remote resource which is unsupported by the Uml4Net library. " +
                              "An attempt to load the resource locally from {LocalReferenceBasePath} will be made", uri.AbsoluteUri, settings.LocalReferenceBasePath);

            var fileName = Path.GetFileName(uri.AbsolutePath);

            var localPath = Path.Combine(settings.LocalReferenceBasePath, fileName);

            if (!File.Exists(localPath))
            {
                logger.LogWarning("The resource at {LocalPath} could not be read as it does not exist", localPath);

                return null;
            }

            return new Tuple<Stream, string>(File.OpenRead(localPath), fileName);
        }

        /// <summary>
        /// Resolves the file path of a resource identified by the specified key and returns a stream for it.
        /// </summary>
        /// <param name="key">
        /// The key representing the resource path to resolve.
        /// </param>
        /// <returns>
        /// A stream of the resource if the file exists; otherwise, <c>null</c>.
        /// </returns>
        private Tuple<Stream, string> ResolvePathmapResource(string key)
        {
            if (key.IndexOf('#') is var index && index <= 0)
            {
                return default;
            }

            var substring = key.Substring(0, index);

            if (settings.PathMaps.TryGetValue(substring, out var resolvedPath))
            {
                if (File.Exists(resolvedPath))
                {
                    return new Tuple<Stream, string>(File.OpenRead(resolvedPath), resolvedPath);
                }

                logger.LogWarning("The Pathmap {Pathmap} is registered but the file cannot not be found {ResolvedPath}", substring, resolvedPath);
            }

            logger.LogWarning("A Pathmap was encountered that was not registered: {Pathmap}", substring);

            return  default;
        }
    }
}
