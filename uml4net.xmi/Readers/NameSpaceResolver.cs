// -------------------------------------------------------------------------------------------------
// <copyright file="NameSpaceResolver.cs" company="Starion Group S.A.">
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

    /// <summary>
    /// The purpose of the <see cref="NameSpaceResolver"/> is to resolve the namespace uri's of the
    /// supported namespaces to support parsing of a UML model from an XMI document.
    /// </summary>
    public class NameSpaceResolver : INameSpaceResolver
    {
        /// <summary>
        /// A cache of all known and supported namespacesUri's and prefixes for processing UML models.
        /// </summary>
        private readonly Dictionary<Uri, string> knownNamespaceCache;

        /// <summary>
        /// The prefixes declared by the document being processed, mapped to the supported prefix of the namespace
        /// they are bound to
        /// </summary>
        private readonly Dictionary<string, string> documentPrefixes = new Dictionary<string, string>();

        /// <summary>
        /// Instantiates a new instance of the <see cref="NameSpaceResolver"/> class.
        /// </summary>
        public NameSpaceResolver()
        {
            this.knownNamespaceCache = new Dictionary<Uri, string>
            {
                // 20131001 - corresponds to UML 2.5
                // 20161101 - corresponds to UML 2.5.1

                { new Uri("http://www.omg.org/spec/XMI/20131001"), KnowNamespacePrefixes.Xmi},
                { new Uri("https://www.omg.org/spec/XMI/20131001"), KnowNamespacePrefixes.Xmi},
                { new Uri("http://www.omg.org/spec/XMI/20161101"), KnowNamespacePrefixes.Xmi},
                { new Uri("https://www.omg.org/spec/XMI/20161101"), KnowNamespacePrefixes.Xmi},

                { new Uri("http://www.omg.org/spec/MOF/20131001"), KnowNamespacePrefixes.MofExt },
                { new Uri("https://www.omg.org/spec/MOF/20131001"), KnowNamespacePrefixes.MofExt },
                { new Uri("http://www.omg.org/spec/MOF/20161101"), KnowNamespacePrefixes.MofExt },
                { new Uri("https://www.omg.org/spec/MOF/20161101"), KnowNamespacePrefixes.MofExt },

                { new Uri("http://www.omg.org/spec/UML/20131001/PrimitiveTypes.xmi"),  KnowNamespacePrefixes.PrimitiveTypes },
                { new Uri("https://www.omg.org/spec/UML/20131001/PrimitiveTypes.xmi"), KnowNamespacePrefixes.PrimitiveTypes },
                { new Uri("http://www.omg.org/spec/UML/20161101/PrimitiveTypes.xmi"), KnowNamespacePrefixes.PrimitiveTypes },
                { new Uri("https://www.omg.org/spec/UML/20161101/PrimitiveTypes.xmi"), KnowNamespacePrefixes.PrimitiveTypes},

                { new Uri("http://www.omg.org/spec/UML/20131001"), KnowNamespacePrefixes.Uml },
                { new Uri("https://www.omg.org/spec/UML/20131001"), KnowNamespacePrefixes.Uml },
                { new Uri("http://www.omg.org/spec/UML/20161101"), KnowNamespacePrefixes.Uml },
                { new Uri("https://www.omg.org/spec/UML/20161101"), KnowNamespacePrefixes.Uml },

                { new Uri("http://www.eclipse.org/uml2/5.0.0/UML"), KnowNamespacePrefixes.Uml },
                { new Uri("https://www.eclipse.org/uml2/5.0.0/UML"), KnowNamespacePrefixes.Uml },

                { new Uri("http://www.omg.org/spec/UML/20131001/StandardProfile"), KnowNamespacePrefixes.StandardProfile },
                { new Uri("https://www.omg.org/spec/UML/20131001/StandardProfile"), KnowNamespacePrefixes.StandardProfile },
                { new Uri( "http://www.omg.org/spec/UML/20161101/StandardProfile"), KnowNamespacePrefixes.StandardProfile },
                { new Uri("https://www.omg.org/spec/UML/20161101/StandardProfile"), KnowNamespacePrefixes.StandardProfile },

                { new Uri("http://www.omg.org/spec/UML/20131001/UMLDI"), KnowNamespacePrefixes.UmlDi },
                { new Uri("https://www.omg.org/spec/UML/20131001/UMLDI"), KnowNamespacePrefixes.UmlDi },
                { new Uri("http://www.omg.org/spec/UML/20161101/UMLDI"), KnowNamespacePrefixes.UmlDi },
                { new Uri("https://www.omg.org/spec/UML/20161101/UMLDI"), KnowNamespacePrefixes.UmlDi },
            };
        }

        /// <summary>
        /// Resolves the prefix from the provided <paramref name="namespaceUri"/>
        /// </summary>
        /// <param name="namespaceUri">
        /// the namespace URI to resolve the namespace prefix. In case this is an un-registered
        /// one, "other" is returned
        /// </param>
        /// <returns>
        /// a namespace prefix
        /// </returns>
        public string ResolvePrefix(string namespaceUri)
        {
            var result = "other";

            if (string.IsNullOrEmpty(namespaceUri))
            {
                return result;
            }

            if (!Uri.TryCreate(namespaceUri, UriKind.Absolute, out var uri))
            {
                return "other";
            }

            if (this.knownNamespaceCache.TryGetValue(new Uri(namespaceUri.Trim()), out result))
            {
                return result;
            }

            if (this.knownNamespaceCache.TryGetValue(new Uri(namespaceUri.TrimEnd('/')), out result))
            {
                return result;
            }

            return "other";
        }

        /// <summary>
        /// Registers a mapping between a namespace name (URI) and a namespace prefix.
        /// </summary>
        /// <param name="namespaceUri">
        /// The namespace name (also known as the namespace URI) that uniquely identifies the XML namespace.
        /// </param>
        /// <param name="prefix">
        /// The namespace prefix to associate with the specified namespace URI. 
        /// The prefix is a shorthand alias used in XML element and attribute names within this scope.
        /// </param>
        public void Register(string namespaceUri, string prefix)
        {
            if (string.IsNullOrEmpty(namespaceUri))
            {
                throw new ArgumentException(nameof(namespaceUri));
            }

            if (string.IsNullOrEmpty(prefix))
            {
                throw new ArgumentException(nameof(prefix));
            }

            this.knownNamespaceCache.Add(new Uri(namespaceUri), prefix);
        }

        /// <summary>
        /// use the <see cref="INameSpaceResolver"/> to resolve and sets the namespaces said <see cref="INameSpaceResolver"/>
        /// </summary>
        /// <param name="namespaceUri">
        /// the subject namespace URI
        /// </param>
        public void ResolveAndSetNamespace(string namespaceUri)
        {
            if (this.ResolvePrefix(namespaceUri) == KnowNamespacePrefixes.Xmi)
            {
                this.XmiNameSpace = namespaceUri;
            }

            if (this.ResolvePrefix(namespaceUri) == KnowNamespacePrefixes.Uml)
            {
                this.UmlNameSpace = namespaceUri;
            }

            if (this.ResolvePrefix(namespaceUri) == KnowNamespacePrefixes.MofExt)
            {
                this.MofextNameSpace = namespaceUri;
            }

            if (this.ResolvePrefix(namespaceUri) == KnowNamespacePrefixes.UmlDi)
            {
                this.UmlDiagramInterchangeNameSpace = namespaceUri;
            }

            if (this.ResolvePrefix(namespaceUri) == KnowNamespacePrefixes.PrimitiveTypes)
            {
                this.PrimitiveTypesNameSpace = namespaceUri;
            }
        }

        /// <summary>
        /// Registers a namespace prefix that the document being processed binds to a namespace, so that qualified
        /// names found in the document (such as the value of an <c>xmi:type</c> attribute) can be resolved when the
        /// <see cref="System.Xml.XmlReader"/> at hand cannot resolve the prefix itself, which is the case for a
        /// subtree reader whose subtree does not contain the declaration
        /// </summary>
        /// <param name="prefix">
        /// The prefix as declared in the document; an empty string for the default namespace
        /// </param>
        /// <param name="namespaceUri">
        /// The namespace URI the document binds the <paramref name="prefix"/> to
        /// </param>
        public void RegisterDocumentPrefix(string prefix, string namespaceUri)
        {
            if (string.IsNullOrEmpty(namespaceUri))
            {
                throw new ArgumentException("The namespace URI is to be provided", nameof(namespaceUri));
            }

            this.documentPrefixes[prefix ?? string.Empty] = this.ResolvePrefix(namespaceUri);
        }

        /// <summary>
        /// Resolves a prefix declared in the document being processed to the supported prefix of the namespace
        /// it is bound to (such as xmi, uml, ...)
        /// </summary>
        /// <param name="prefix">
        /// The prefix as declared in the document; an empty string for the default namespace
        /// </param>
        /// <returns>
        /// the supported prefix, or "other" when the prefix is not registered or is bound to a namespace that is not supported
        /// </returns>
        public string ResolveDocumentPrefix(string prefix)
        {
            return this.documentPrefixes.TryGetValue(prefix ?? string.Empty, out var knownPrefix) ? knownPrefix : KnowNamespacePrefixes.Other;
        }

        /// <summary>
        /// Gets or sets the XMI namespace for the document that is being processed
        /// </summary>
        public string XmiNameSpace { get; set; }

        /// <summary>
        /// Gets or sets the Mofext namespace for the document that is being processed
        /// </summary>
        public string MofextNameSpace { get; set; }

        /// <summary>
        /// Gets or sets the UML namespace for the document that is being processed
        /// </summary>
        public string UmlNameSpace { get; set; }

        /// <summary>
        /// Gets or sets the UmlDiagramInterchange namespace for the document that is being processed
        /// </summary>
        public string UmlDiagramInterchangeNameSpace { get; set; }

        /// <summary>
        /// Gets or sets the PrimitiveTypes namespace for the document that is being processed
        /// </summary>
        public string PrimitiveTypesNameSpace { get; set; }
    }
}
