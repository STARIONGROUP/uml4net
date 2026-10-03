// -------------------------------------------------------------------------------------------------
// <copyright file="StereoTypeApplicationResolver.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Readers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using uml4net.Classification;
    using uml4net.Extensions;
    using uml4net.Mof.Extension;
    using uml4net.Packages;
    using uml4net.Profiling;
    using uml4net.xmi.Xmi;

    /// <summary>
    /// The purpose of the <see cref="StereoTypeApplicationResolver"/> is to resolve the <see cref="StereoTypeApplication"/>s
    /// that have been read: to link each one to the <see cref="IStereotype"/> that it instantiates and to the element that
    /// it extends, to type its tagged values, and to register it in the <see cref="IXmiElementCache"/> so that the
    /// stereotypes applied to an element can be queried
    /// </summary>
    /// <remarks>
    /// UML 2.5.1 clause 12.3.3: the XML namespace of a stereotype application identifies the profile, by the URI of the
    /// profile or by its <c>org.omg.xmi.nsURI</c> tag. In practice tools also use the location of the profile document,
    /// as referenced by the <c>appliedProfile</c> of a <c>ProfileApplication</c>, which is accepted as well. The prefix of
    /// the namespace, by default the name of the profile or its <c>org.omg.xmi.nsPrefix</c> tag, is the last resort.
    /// URIs are compared without their fragment and trailing slash, and the <c>http</c> and <c>https</c> schemes are
    /// considered equivalent.
    /// </remarks>
    public class StereoTypeApplicationResolver
    {
        /// <summary>
        /// The name of the MOF tag that holds the namespace URI of a profile
        /// </summary>
        private const string NsUriTagName = "org.omg.xmi.nsURI";

        /// <summary>
        /// The name of the MOF tag that holds the namespace prefix of a profile
        /// </summary>
        private const string NsPrefixTagName = "org.omg.xmi.nsPrefix";

        /// <summary>
        /// The <see cref="IXmiElementCache"/> that holds the elements that were read
        /// </summary>
        private readonly IXmiElementCache cache;

        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<StereoTypeApplicationResolver> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="StereoTypeApplicationResolver"/> class.
        /// </summary>
        /// <param name="cache">
        /// The <see cref="IXmiElementCache"/> that holds the elements that were read
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public StereoTypeApplicationResolver(IXmiElementCache cache, ILoggerFactory loggerFactory)
        {
            this.cache = cache ?? throw new ArgumentNullException(nameof(cache));
            this.logger = loggerFactory == null ? NullLogger<StereoTypeApplicationResolver>.Instance : loggerFactory.CreateLogger<StereoTypeApplicationResolver>();
        }

        /// <summary>
        /// Resolves the <see cref="StereoTypeApplication"/>s of the document that was read and of the external documents
        /// that were loaded while resolving its references
        /// </summary>
        /// <param name="xmiReaderResult">
        /// The <see cref="XmiReaderResult"/> whose stereotype applications are resolved
        /// </param>
        public void Resolve(XmiReaderResult xmiReaderResult)
        {
            if (xmiReaderResult == null)
            {
                throw new ArgumentNullException(nameof(xmiReaderResult));
            }

            var xmiRoots = new List<XmiRoot>();

            if (xmiReaderResult.XmiRoot != null)
            {
                xmiRoots.Add(xmiReaderResult.XmiRoot);
            }

            xmiRoots.AddRange(xmiReaderResult.ExternalXmiRoots.Values);

            var stereoTypeApplications = xmiRoots.SelectMany(x => x.StereoTypeApplications).ToList();

            if (stereoTypeApplications.Count == 0)
            {
                return;
            }

            var profileIndex = this.CreateProfileIndex(xmiRoots);
            var unresolvedNamespaces = new Dictionary<string, int>();

            foreach (var stereoTypeApplication in stereoTypeApplications)
            {
                if (!this.TryResolve(stereoTypeApplication, profileIndex))
                {
                    var key = stereoTypeApplication.NamespaceUri ?? stereoTypeApplication.ProfileName ?? string.Empty;
                    unresolvedNamespaces[key] = unresolvedNamespaces.TryGetValue(key, out var count) ? count + 1 : 1;
                }
            }

            foreach (var unresolvedNamespace in unresolvedNamespaces)
            {
                this.logger.LogWarning("{Count} stereotype applications of the namespace {Namespace} are not resolved, the profile is not available", unresolvedNamespace.Value, unresolvedNamespace.Key);
            }

            // a document can hold thousands of applications whose base_ reference dangles, they are reported at once
            var applicationsWithoutElement = stereoTypeApplications.Where(x => x.ExtendedElement == null).ToList();

            if (applicationsWithoutElement.Count > 0)
            {
                var examples = string.Join(", ", applicationsWithoutElement.Take(3).Select(x => $"{x.ElementIdentifier} by {x.XmiId}"));

                this.logger.LogWarning("{Count} stereotype applications extend an element that is not found, for example {Examples}", applicationsWithoutElement.Count, examples);
            }
        }

        /// <summary>
        /// Resolves the provided <see cref="StereoTypeApplication"/>
        /// </summary>
        /// <param name="stereoTypeApplication">
        /// The <see cref="StereoTypeApplication"/> that is resolved
        /// </param>
        /// <param name="profileIndex">
        /// The <see cref="ProfileIndex"/> used to find the profile of the application
        /// </param>
        /// <returns>
        /// true when the profile of the application is found, false otherwise
        /// </returns>
        private bool TryResolve(StereoTypeApplication stereoTypeApplication, ProfileIndex profileIndex)
        {
            var extendedElement = this.QueryReferencedElement(stereoTypeApplication.DocumentName, stereoTypeApplication.ElementIdentifier);

            if (extendedElement == null)
            {
                this.logger.LogDebug("The element {ElementIdentifier} extended by the stereotype application {XmiId} is not found", stereoTypeApplication.ElementIdentifier, stereoTypeApplication.XmiId);
            }
            else
            {
                stereoTypeApplication.ExtendedElement = extendedElement;
                this.cache.AddStereoTypeApplication(extendedElement, stereoTypeApplication);
            }

            var profile = profileIndex.Query(stereoTypeApplication.NamespaceUri, stereoTypeApplication.ProfileName);

            if (profile == null)
            {
                return false;
            }

            var stereotypes = QueryStereotypes(profile).ToList();
            var stereotype = stereotypes.FirstOrDefault(x => x.Name == stereoTypeApplication.StereoTypeName)
                             ?? stereotypes.FirstOrDefault(x => XmlNameConverter.ToXmlName(x.Name) == stereoTypeApplication.StereoTypeName);

            if (stereotype == null)
            {
                this.logger.LogWarning("The stereotype {StereoTypeName} of the stereotype application {XmiId} is not found in the profile {Profile}", stereoTypeApplication.StereoTypeName, stereoTypeApplication.XmiId, profile.Name);
                return true;
            }

            stereoTypeApplication.Stereotype = stereotype;

            var properties = stereotype.QueryAllGeneralClassifiers()
                .OfType<IStereotype>()
                .SelectMany(x => x.OwnedAttribute)
                .Where(x => !string.IsNullOrEmpty(x.Name))
                .ToList();

            foreach (var taggedValue in stereoTypeApplication.TaggedValues)
            {
                var property = properties.FirstOrDefault(x => x.Name == taggedValue.Name)
                               ?? properties.FirstOrDefault(x => XmlNameConverter.ToXmlName(x.Name) == taggedValue.Name);

                if (property == null)
                {
                    this.logger.LogWarning("The tagged value {Name} of the stereotype application {XmiId} is not a property of the stereotype {StereoTypeName}", taggedValue.Name, stereoTypeApplication.XmiId, stereotype.Name);
                    continue;
                }

                taggedValue.Property = property;

                if (TaggedValueConverter.TryConvert(property, taggedValue, reference => this.QueryReferencedElement(stereoTypeApplication.DocumentName, reference), out var values, out var isReference))
                {
                    taggedValue.Values = values;
                    taggedValue.IsReference |= isReference;
                }
                else
                {
                    this.logger.LogWarning("The tagged value {Name} of the stereotype application {XmiId} cannot be converted to the type of the property, it is kept as read", taggedValue.Name, stereoTypeApplication.XmiId);
                }
            }

            return true;
        }

        /// <summary>
        /// Queries the element that a reference in the provided document points to
        /// </summary>
        /// <param name="documentName">
        /// The name of the document that contains the reference
        /// </param>
        /// <param name="reference">
        /// The reference: an identifier of the same document, or a <c>document#identifier</c> href
        /// </param>
        /// <returns>
        /// The referenced <see cref="IXmiElement"/>, or null when it is not found
        /// </returns>
        private IXmiElement QueryReferencedElement(string documentName, string reference)
        {
            if (string.IsNullOrEmpty(reference))
            {
                return null;
            }

            var hashIndex = reference.IndexOf('#');

            // as for any other reference: a document part is used as is, a bare identifier is one of the same document
            var key = hashIndex > 0 ? reference : $"{documentName}#{reference.TrimStart('#')}";

            return this.cache.TryGetValue(key, out var element) ? element : null;
        }

        /// <summary>
        /// Queries the <see cref="IStereotype"/>s of the provided <see cref="IProfile"/>, those of its nested packages
        /// included
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> whose stereotypes are queried
        /// </param>
        /// <returns>
        /// The <see cref="IStereotype"/>s
        /// </returns>
        private static IEnumerable<IStereotype> QueryStereotypes(IPackage package)
        {
            foreach (var packageableElement in package.PackagedElement)
            {
                switch (packageableElement)
                {
                    case IStereotype stereotype:
                        yield return stereotype;
                        break;
                    case IPackage nestedPackage:
                        foreach (var nestedStereotype in QueryStereotypes(nestedPackage))
                        {
                            yield return nestedStereotype;
                        }

                        break;
                }
            }
        }

        /// <summary>
        /// Creates the <see cref="ProfileIndex"/> of the profiles that were read
        /// </summary>
        /// <param name="xmiRoots">
        /// The <see cref="XmiRoot"/>s of the documents that were read, whose tags are taken into account
        /// </param>
        /// <returns>
        /// The <see cref="ProfileIndex"/>
        /// </returns>
        private ProfileIndex CreateProfileIndex(List<XmiRoot> xmiRoots)
        {
            var profileIndex = new ProfileIndex();
            var profiles = this.cache.Values.OfType<IProfile>().ToList();

            foreach (var profile in profiles)
            {
                profileIndex.AddNamespace(profile.URI, profile);
            }

            foreach (var xmiRoot in xmiRoots)
            {
                var documentName = xmiRoot.Content.FirstOrDefault()?.DocumentName;
                var profilesOfDocument = profiles.Where(x => x.DocumentName == documentName).ToList();

                foreach (var tag in xmiRoot.Tags.Where(x => x.Name == NsUriTagName || x.Name == NsPrefixTagName))
                {
                    // a tag applies to the profiles of its document that it names, or to all of them when it names none
                    var taggedProfiles = tag.Element.Count == 0
                        ? profilesOfDocument
                        : profilesOfDocument.Where(x => tag.Element.Contains(x.XmiId)).ToList();

                    foreach (var taggedProfile in taggedProfiles)
                    {
                        if (tag.Name == NsUriTagName)
                        {
                            profileIndex.AddNamespace(tag.Value, taggedProfile);
                        }
                        else
                        {
                            profileIndex.AddPrefix(tag.Value, taggedProfile);
                        }
                    }
                }
            }

            foreach (var profile in profiles)
            {
                // the location of the document of the profile, which is how a ProfileApplication references it
                if (Uri.TryCreate(profile.DocumentName, UriKind.Absolute, out _))
                {
                    profileIndex.AddNamespace(profile.DocumentName, profile);
                }

                profileIndex.AddPrefix(profile.Name, profile);

                // UML 2.5.1 clause 12.3.3 recommends the name of the profile, with the characters that are illegal in an
                // XML name removed, as nsPrefix; Eclipse UML2 exports, for example, use ValidationProfile for the profile
                // "Validation Profile" and declare their nsURI in an Ecore annotation that is not read
                profileIndex.AddPrefix(XmlNameConverter.ToXmlName(profile.Name), profile);
            }

            return profileIndex;
        }

        /// <summary>
        /// An index of the profiles by namespace URI and by namespace prefix; the first profile that is registered for
        /// a key is kept
        /// </summary>
        private sealed class ProfileIndex
        {
            /// <summary>
            /// The profiles by normalized namespace URI
            /// </summary>
            private readonly Dictionary<string, IProfile> profilesByNamespace = new(StringComparer.Ordinal);

            /// <summary>
            /// The profiles by namespace prefix
            /// </summary>
            private readonly Dictionary<string, IProfile> profilesByPrefix = new(StringComparer.Ordinal);

            /// <summary>
            /// Registers a namespace URI of a profile
            /// </summary>
            /// <param name="namespaceUri">The namespace URI, ignored when null or empty</param>
            /// <param name="profile">The <see cref="IProfile"/></param>
            public void AddNamespace(string namespaceUri, IProfile profile)
            {
                if (!string.IsNullOrEmpty(namespaceUri) && !this.profilesByNamespace.ContainsKey(Normalize(namespaceUri)))
                {
                    this.profilesByNamespace[Normalize(namespaceUri)] = profile;
                }
            }

            /// <summary>
            /// Registers a namespace prefix of a profile
            /// </summary>
            /// <param name="prefix">The namespace prefix, ignored when null or empty</param>
            /// <param name="profile">The <see cref="IProfile"/></param>
            public void AddPrefix(string prefix, IProfile profile)
            {
                if (!string.IsNullOrEmpty(prefix) && !this.profilesByPrefix.ContainsKey(prefix))
                {
                    this.profilesByPrefix[prefix] = profile;
                }
            }

            /// <summary>
            /// Queries the profile of a stereotype application by its namespace URI, or else by its prefix
            /// </summary>
            /// <param name="namespaceUri">The namespace URI of the application</param>
            /// <param name="prefix">The namespace prefix of the application</param>
            /// <returns>The <see cref="IProfile"/>, or null when it is not found</returns>
            public IProfile Query(string namespaceUri, string prefix)
            {
                if (!string.IsNullOrEmpty(namespaceUri) && this.profilesByNamespace.TryGetValue(Normalize(namespaceUri), out var profile))
                {
                    return profile;
                }

                return !string.IsNullOrEmpty(prefix) && this.profilesByPrefix.TryGetValue(prefix, out profile) ? profile : null;
            }

            /// <summary>
            /// Normalizes a namespace URI: the fragment and a trailing slash are removed and <c>https</c> is replaced by
            /// <c>http</c>
            /// </summary>
            /// <param name="namespaceUri">The namespace URI</param>
            /// <returns>The normalized namespace URI</returns>
            private static string Normalize(string namespaceUri)
            {
                var hashIndex = namespaceUri.IndexOf('#');
                var normalized = hashIndex >= 0 ? namespaceUri.Substring(0, hashIndex) : namespaceUri;

                normalized = normalized.TrimEnd('/');

                return normalized.StartsWith("https://", StringComparison.OrdinalIgnoreCase)
                    ? "http://" + normalized.Substring("https://".Length)
                    : normalized;
            }
        }
    }
}
