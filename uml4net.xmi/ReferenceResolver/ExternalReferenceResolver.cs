// -------------------------------------------------------------------------------------------------
// <copyright file="ExternalReferenceResolver.cs" company="Starion Group S.A.">
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
        /// The location (absolute path or absolute URI) from which each document was read, keyed by the name of the
        /// document as used in the <see cref="IXmiElement.DocumentName"/> of its elements; relative <c>href</c>s of
        /// a document are resolved against its location
        /// </summary>
        private readonly Dictionary<string, string> documentLocations = [];

        /// <summary>
        /// Registers the location of a document so that the relative <c>href</c>s of that document are resolved
        /// against it (XMI 2.5.1 clause 7.10.2, IETF RFC 2396) instead of against the
        /// <see cref="IXmiReaderSettings.LocalReferenceBasePath"/>
        /// </summary>
        /// <param name="documentName">
        /// The name of the document as used in the <see cref="IXmiElement.DocumentName"/> of its elements
        /// </param>
        /// <param name="location">
        /// The absolute path or absolute URI from which the document was read
        /// </param>
        public void RegisterDocumentLocation(string documentName, string location)
        {
            if (string.IsNullOrEmpty(documentName))
            {
                throw new ArgumentException("The document name may not be null or empty", nameof(documentName));
            }

            if (string.IsNullOrEmpty(location))
            {
                throw new ArgumentException("The location may not be null or empty", nameof(location));
            }

            this.documentLocations[documentName] = location;
        }

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

            // each reference is paired with the document that declares it: a relative href is resolved against
            // the location of the referencing document (XMI 2.5.1 clause 7.10.2, IETF RFC 2396)
            var singleValueReferencePropertyIdentifiers = cache.Values
                .SelectMany(cacheEntry => cacheEntry.SingleValueReferencePropertyIdentifiers.Values.Select(identifier => (identifier, cacheEntry.DocumentName))).ToList();

            foreach (var (identifier, referencingDocument) in singleValueReferencePropertyIdentifiers)
            {
                if(this.TryResolve(identifier, referencingDocument, out var reference))
                {
                    result.Add(reference);
                }
            }

            var multiValueReferencePropertyIdentifiers = cache.Values
                .SelectMany(cacheEntry => cacheEntry.MultiValueReferencePropertyIdentifiers.Values.Select(identifiers => (identifiers, cacheEntry.DocumentName))).ToList();

            foreach (var (identifiers, referencingDocument) in multiValueReferencePropertyIdentifiers)
            {
                foreach (var identifier in identifiers)
                {
                    if (this.TryResolve(identifier, referencingDocument, out var reference))
                    {
                        result.Add(reference);
                    }
                }
            }

            var compositeReferenceIdentifiers = cache.Values
                .SelectMany(cacheEntry => cacheEntry.CompositeReferencePropertyIdentifiers.Values
                    .SelectMany(compositeReferences => compositeReferences)
                    .Select(compositeReference => (compositeReference.Identifier, cacheEntry.DocumentName)))
                .ToList();

            foreach (var (identifier, referencingDocument) in compositeReferenceIdentifiers)
            {
                if (this.TryResolve(identifier, referencingDocument, out var reference))
                {
                    result.Add(reference);
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
        /// <param name="referencingDocument">
        /// The name of the document that declares the reference, against whose location a relative reference
        /// is resolved
        /// </param>
        /// <param name="result">
        /// When this method returns, contains a tuple with the context and stream if the reference is resolved;
        /// otherwise, it is set to a default value.
        /// </param>
        /// <returns>
        /// <c>true</c> if the external reference is successfully resolved; otherwise, <c>false</c>.
        /// </returns>
        private bool TryResolve(string key, string referencingDocument, out (string Context, Stream Stream) result)
        {
            result = default;

            if (IsInvalidExternalResourceKey(key) || !TryResolveContext(key, out var externalResource))
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
                var resolvedStreamResult = this.ResolveStream(key, externalResource.Context, referencingDocument);

                if (resolvedStreamResult == null)
                {
                    logger.LogWarning("The resolving key '{Key}' from context '{Context}' declared in '{ReferencingDocument}' could not be resolved", key, externalResource.Context, referencingDocument);
                    return false;
                }

                result.Stream = resolvedStreamResult.Item1;
                result.Context = externalResource.Context;

                this.externalReferencesCache.Add(externalResource.Context);

                // the relative hrefs of the resolved document are in turn resolved against where it was found
                this.documentLocations[externalResource.Context] = resolvedStreamResult.Item2;

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
            resolvedContextAndResource = default;

            var referenceString = resourceKey.Split(['#'], StringSplitOptions.RemoveEmptyEntries);

            if (referenceString.Length != 2)
            {
                logger.LogTrace("Resource key [{Key}] does not resolve to a context and a resource id", resourceKey);
                return false;
            }

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
        private static bool IsInvalidExternalResourceKey(string key)
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
        /// <param name="referencingDocument">
        /// The name of the document that declares the reference, against whose registered location a relative
        /// context is resolved
        /// </param>
        /// <returns>
        /// The resolved <see cref="Stream"/> and the location (absolute path or absolute URI) it was read from
        /// if found; otherwise, <c>null</c>.
        /// </returns>
        /// <remarks>
        /// The following kinds of context are supported:
        ///   - http: or https: - either resolves to a known resource that is embedded
        ///     or tries to load a local copy under the <see cref="IXmiReaderSettings.LocalReferenceBasePath"/>,
        ///     first mirrored by host and path, then by file name only
        ///   - file: a file on the filesystem
        ///   - pathmap: a mapping to a local file
        ///   - resource-name#reference-name: a relative reference, resolved against the location of the
        ///     referencing document (XMI 2.5.1 clause 7.10.2, IETF RFC 2396) and, when that is not known or
        ///     does not exist, against the <see cref="IXmiReaderSettings.LocalReferenceBasePath"/>
        /// </remarks>
        private Tuple<Stream, string> ResolveStream(string key, string context, string referencingDocument)
        {
            if (resourceLoader.TryLoadKnownResource(key, out var knownResourceStream))
            {
                return new Tuple<Stream, string>(knownResourceStream, context);
            }

            if (key.StartsWith("pathmap://"))
            {
                return this.ResolvePathmapResource(key);
            }

            var resolvedContext = this.ResolveAgainstReferencingDocument(context, referencingDocument);

            if (Uri.TryCreate(resolvedContext, UriKind.Absolute, out var uri))
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

            var localPath = Path.Combine(settings.LocalReferenceBasePath, context);
            if (File.Exists(localPath))
            {
                return new Tuple<Stream, string>(File.OpenRead(localPath), Path.GetFullPath(localPath));
            }

            return null;
        }

        /// <summary>
        /// Resolves a relative context against the registered location of the referencing document
        /// (XMI 2.5.1 clause 7.10.2: the value of href is a URI reference as defined by IETF RFC 2396)
        /// </summary>
        /// <param name="context">
        /// The resource context path as it appears in the href
        /// </param>
        /// <param name="referencingDocument">
        /// The name of the document that declares the reference
        /// </param>
        /// <returns>
        /// the absolute path or absolute URI of the context when the referencing document has a registered
        /// location and, for a file location, the resolved file exists; the unchanged context otherwise
        /// </returns>
        private string ResolveAgainstReferencingDocument(string context, string referencingDocument)
        {
            if (Uri.TryCreate(context, UriKind.Absolute, out _))
            {
                return context;
            }

            if (string.IsNullOrEmpty(referencingDocument) || !this.documentLocations.TryGetValue(referencingDocument, out var baseLocation) || !Uri.TryCreate(baseLocation, UriKind.Absolute, out var baseUri))
            {
                return context;
            }

            if (baseUri.IsFile)
            {
                var candidate = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(baseUri.LocalPath) ?? string.Empty, context));

                if (File.Exists(candidate))
                {
                    logger.LogDebug("The relative reference {Context} of {ReferencingDocument} resolves to {Candidate}", context, referencingDocument, candidate);
                    return candidate;
                }

                logger.LogDebug("The relative reference {Context} of {ReferencingDocument} does not exist at {Candidate}, falling back to the LocalReferenceBasePath", context, referencingDocument, candidate);
                return context;
            }

            return new Uri(baseUri, context).AbsoluteUri;
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

            // a local copy that mirrors the host and path of the URI keeps documents with the same file name apart,
            // for example http://example.com/a/types.xmi and http://example.com/b/types.xmi; a copy by file name
            // only is the historical fallback
            var relativePath = uri.AbsolutePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar);

            var candidates = new[]
            {
                Path.Combine(settings.LocalReferenceBasePath, uri.Host, relativePath),
                Path.Combine(settings.LocalReferenceBasePath, relativePath),
                Path.Combine(settings.LocalReferenceBasePath, Path.GetFileName(uri.AbsolutePath))
            };

            foreach (var localPath in candidates)
            {
                if (File.Exists(localPath))
                {
                    logger.LogDebug("The remote resource {Resource} is read from the local copy {LocalPath}", uri.AbsoluteUri, localPath);

                    return new Tuple<Stream, string>(File.OpenRead(localPath), uri.AbsoluteUri);
                }
            }

            logger.LogWarning("The resource {Resource} could not be read, no local copy exists at {Candidates}", uri.AbsoluteUri, string.Join(", ", candidates));

            return null;
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
