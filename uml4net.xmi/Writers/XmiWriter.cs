// -------------------------------------------------------------------------------------------------
// <copyright file="XmiWriter.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Writers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using uml4net.Mof.Extension;
    using uml4net.Packages;
    using uml4net.xmi.Readers;
    using uml4net.xmi.Settings;
    using uml4net.xmi.Xmi;

    /// <summary>
    /// The purpose of the <see cref="XmiWriter"/> is to provide a means to write (serialize)
    /// a UML 2.5.1 model to XMI
    /// </summary>
    public class XmiWriter : IXmiWriter
    {
        /// <summary>
        /// The (injected) <see cref="ILogger{XmiWriter}"/> used to perform logging
        /// </summary>
        private readonly ILogger<XmiWriter> logger;

        /// <summary>
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </summary>
        protected readonly ILoggerFactory LoggerFactory;

        /// <summary>
        /// The <see cref="IXmiWriterScope"/>
        /// </summary>
        private readonly IXmiWriterScope scope;

        /// <summary>
        /// The (injected) <see cref="IXmiElementWriterFacade"/> used to write the root packages
        /// </summary>
        protected readonly IXmiElementWriterFacade XmiElementWriterFacade;

        /// <summary>
        /// The (injected) <see cref="IXmiWriterSettings"/> used to configure writing
        /// </summary>
        protected readonly IXmiWriterSettings XmiWriterSettings;

        /// <summary>
        /// The (injected) <see cref="IReferenceClosureCalculator"/> used to calculate the <see cref="XmiWritePlan"/>
        /// </summary>
        private readonly IReferenceClosureCalculator referenceClosureCalculator;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiWriter"/> class.
        /// </summary>
        /// <param name="xmiElementWriterFacade">
        /// The (injected) <see cref="IXmiElementWriterFacade"/> used to write the root packages
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        /// <param name="scope">
        /// The <see cref="IXmiWriterScope"/> used for managing the lifecycle of services used during the XMI writing process.
        /// </param>
        /// <param name="xmiWriterSettings">
        /// The injected <see cref="IXmiWriterSettings"/> that provides writing settings for XMI
        /// </param>
        /// <param name="referenceClosureCalculator">
        /// The (injected) <see cref="IReferenceClosureCalculator"/> used to calculate the <see cref="XmiWritePlan"/>
        /// </param>
        public XmiWriter(IXmiElementWriterFacade xmiElementWriterFacade, ILoggerFactory loggerFactory, IXmiWriterScope scope,
            IXmiWriterSettings xmiWriterSettings, IReferenceClosureCalculator referenceClosureCalculator)
        {
            this.XmiElementWriterFacade = xmiElementWriterFacade;
            this.XmiWriterSettings = xmiWriterSettings;
            this.LoggerFactory = loggerFactory;
            this.logger = this.LoggerFactory == null ? NullLogger<XmiWriter>.Instance : this.LoggerFactory.CreateLogger<XmiWriter>();
            this.scope = scope;
            this.referenceClosureCalculator = referenceClosureCalculator;
        }

        /// <summary>
        /// Writes the provided <see cref="IPackage"/> to a UML XMI 2.5.1 file.
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> that is to be written
        /// </param>
        /// <param name="fileUri">
        /// The URI of the XMI file that is to be written.
        /// </param>
        public void Write(IPackage package, string fileUri)
        {
            this.Write(package, fileUri, null);
        }

        /// <summary>
        /// Writes the provided <see cref="IPackage"/> and <see cref="XmiExtension"/>s to a UML XMI 2.5.1 file.
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> that is to be written
        /// </param>
        /// <param name="fileUri">
        /// The URI of the XMI file that is to be written.
        /// </param>
        /// <param name="documentExtensions">
        /// The <see cref="XmiExtension"/>s that are to be written as a sibling of the <paramref name="package"/>,
        /// typically the <c>Extensions</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        public void Write(IPackage package, string fileUri, IEnumerable<XmiExtension> documentExtensions)
        {
            this.Write(package, fileUri, null, documentExtensions);
        }

        /// <summary>
        /// Writes the provided <see cref="IPackage"/>, <see cref="Documentation"/> and <see cref="XmiExtension"/>s to
        /// a UML XMI 2.5.1 file.
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> that is to be written
        /// </param>
        /// <param name="fileUri">
        /// The URI of the XMI file that is to be written.
        /// </param>
        /// <param name="documentation">
        /// The <see cref="Documentation"/> that is to be written as a sibling of the <paramref name="package"/>,
        /// typically the <c>Documentation</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        /// <param name="documentExtensions">
        /// The <see cref="XmiExtension"/>s that are to be written as a sibling of the <paramref name="package"/>,
        /// typically the <c>Extensions</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        public void Write(IPackage package, string fileUri, Documentation documentation, IEnumerable<XmiExtension> documentExtensions)
        {
            if (package == null)
            {
                throw new ArgumentNullException(nameof(package));
            }

            this.Write(new IXmiElement[] { package }, fileUri, documentation, documentExtensions);
        }

        /// <summary>
        /// Writes the provided root elements, <see cref="Documentation"/> and <see cref="XmiExtension"/>s to a
        /// UML XMI 2.5.1 file. The root elements are written as the top-level elements of the document, in the
        /// provided order, and do not need to be <see cref="IPackage"/>s.
        /// </summary>
        /// <param name="rootElements">
        /// The <see cref="IXmiElement"/>s that are to be written as top-level elements, typically the
        /// <c>DocumentRootElements</c> of the <c>XmiReaderResult</c> that was read. Its <c>RootElements</c> also hold the
        /// top-level elements of the external documents that were loaded while resolving references; writing those
        /// merges several documents into one, whose identifiers can clash
        /// </param>
        /// <param name="fileUri">
        /// The URI of the XMI file that is to be written.
        /// </param>
        /// <param name="documentation">
        /// The <see cref="Documentation"/> that is to be written as a sibling of the <paramref name="rootElements"/>,
        /// typically the <c>Documentation</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        /// <param name="documentExtensions">
        /// The <see cref="XmiExtension"/>s that are to be written as a sibling of the <paramref name="rootElements"/>,
        /// typically the <c>Extensions</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        public void Write(IEnumerable<IXmiElement> rootElements, string fileUri, Documentation documentation, IEnumerable<XmiExtension> documentExtensions)
        {
            this.Write(rootElements, fileUri, documentation, documentExtensions, null);
        }

        /// <summary>
        /// Writes the provided root elements, <see cref="Documentation"/>, <see cref="XmiExtension"/>s and MOF
        /// <see cref="Tag"/>s to a UML XMI 2.5.1 file. The root elements are written as the top-level elements of the
        /// document, in the provided order, and do not need to be <see cref="IPackage"/>s.
        /// </summary>
        /// <param name="rootElements">
        /// The <see cref="IXmiElement"/>s that are to be written as top-level elements, typically the
        /// <c>DocumentRootElements</c> of the <c>XmiReaderResult</c> that was read. Its <c>RootElements</c> also hold the
        /// top-level elements of the external documents that were loaded while resolving references; writing those
        /// merges several documents into one, whose identifiers can clash
        /// </param>
        /// <param name="fileUri">
        /// The URI of the XMI file that is to be written.
        /// </param>
        /// <param name="documentation">
        /// The <see cref="Documentation"/> that is to be written as a sibling of the <paramref name="rootElements"/>,
        /// typically the <c>Documentation</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        /// <param name="documentExtensions">
        /// The <see cref="XmiExtension"/>s that are to be written as a sibling of the <paramref name="rootElements"/>,
        /// typically the <c>Extensions</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        /// <param name="tags">
        /// The MOF <see cref="Tag"/>s that are to be written as <c>mofext:Tag</c> siblings of the
        /// <paramref name="rootElements"/>, typically the <c>Tags</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        public void Write(IEnumerable<IXmiElement> rootElements, string fileUri, Documentation documentation, IEnumerable<XmiExtension> documentExtensions, IEnumerable<Tag> tags)
        {
            if (rootElements == null)
            {
                throw new ArgumentNullException(nameof(rootElements));
            }

            if (string.IsNullOrEmpty(fileUri))
            {
                throw new ArgumentException(nameof(fileUri));
            }

            using var fileStream = File.Create(fileUri);

            var sw = Stopwatch.StartNew();

            this.logger.LogInformation("start serializing to {Path}", fileUri);

            this.Write(rootElements, fileStream, new FileInfo(fileUri).Name, documentation, documentExtensions, tags);

            this.logger.LogInformation("File {Path} serialized in {Time} [ms]", fileUri, sw.ElapsedMilliseconds);
        }

        /// <summary>
        /// Writes the provided <see cref="IPackage"/> to a UML XMI 2.5.1 stream.
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> that is to be written
        /// </param>
        /// <param name="stream">
        /// The <see cref="Stream"/> to which the XMI content is written.
        /// </param>
        /// <param name="documentName">
        /// The name of the document that is being written.
        /// </param>
        public void Write(IPackage package, Stream stream, string documentName)
        {
            this.Write(package, stream, documentName, null);
        }

        /// <summary>
        /// Writes the provided <see cref="IPackage"/> and <see cref="XmiExtension"/>s to a UML XMI 2.5.1 stream.
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> that is to be written
        /// </param>
        /// <param name="stream">
        /// The <see cref="Stream"/> to which the XMI content is written.
        /// </param>
        /// <param name="documentName">
        /// The name of the document that is being written.
        /// </param>
        /// <param name="documentExtensions">
        /// The <see cref="XmiExtension"/>s that are to be written as a sibling of the <paramref name="package"/>,
        /// typically the <c>Extensions</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        public void Write(IPackage package, Stream stream, string documentName, IEnumerable<XmiExtension> documentExtensions)
        {
            this.Write(package, stream, documentName, null, documentExtensions);
        }

        /// <summary>
        /// Writes the provided <see cref="IPackage"/>, <see cref="Documentation"/> and <see cref="XmiExtension"/>s to
        /// a UML XMI 2.5.1 stream.
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> that is to be written
        /// </param>
        /// <param name="stream">
        /// The <see cref="Stream"/> to which the XMI content is written.
        /// </param>
        /// <param name="documentName">
        /// The name of the document that is being written.
        /// </param>
        /// <param name="documentation">
        /// The <see cref="Documentation"/> that is to be written as a sibling of the <paramref name="package"/>,
        /// typically the <c>Documentation</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        /// <param name="documentExtensions">
        /// The <see cref="XmiExtension"/>s that are to be written as a sibling of the <paramref name="package"/>,
        /// typically the <c>Extensions</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        public void Write(IPackage package, Stream stream, string documentName, Documentation documentation, IEnumerable<XmiExtension> documentExtensions)
        {
            if (package == null)
            {
                throw new ArgumentNullException(nameof(package));
            }

            this.Write(new IXmiElement[] { package }, stream, documentName, documentation, documentExtensions);
        }

        /// <summary>
        /// Writes the provided root elements, <see cref="Documentation"/> and <see cref="XmiExtension"/>s to a
        /// UML XMI 2.5.1 stream. The root elements are written as the top-level elements of the document, in the
        /// provided order, and do not need to be <see cref="IPackage"/>s.
        /// </summary>
        /// <param name="rootElements">
        /// The <see cref="IXmiElement"/>s that are to be written as top-level elements, typically the
        /// <c>DocumentRootElements</c> of the <c>XmiReaderResult</c> that was read. Its <c>RootElements</c> also hold the
        /// top-level elements of the external documents that were loaded while resolving references; writing those
        /// merges several documents into one, whose identifiers can clash
        /// </param>
        /// <param name="stream">
        /// The <see cref="Stream"/> to which the XMI content is written.
        /// </param>
        /// <param name="documentName">
        /// The name of the document that is being written.
        /// </param>
        /// <param name="documentation">
        /// The <see cref="Documentation"/> that is to be written as a sibling of the <paramref name="rootElements"/>,
        /// typically the <c>Documentation</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        /// <param name="documentExtensions">
        /// The <see cref="XmiExtension"/>s that are to be written as a sibling of the <paramref name="rootElements"/>,
        /// typically the <c>Extensions</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        public void Write(IEnumerable<IXmiElement> rootElements, Stream stream, string documentName, Documentation documentation, IEnumerable<XmiExtension> documentExtensions)
        {
            this.Write(rootElements, stream, documentName, documentation, documentExtensions, null);
        }

        /// <summary>
        /// Writes the provided root elements, <see cref="Documentation"/>, <see cref="XmiExtension"/>s and MOF
        /// <see cref="Tag"/>s to a UML XMI 2.5.1 stream. The root elements are written as the top-level elements of the
        /// document, in the provided order, and do not need to be <see cref="IPackage"/>s.
        /// </summary>
        /// <param name="rootElements">
        /// The <see cref="IXmiElement"/>s that are to be written as top-level elements, typically the
        /// <c>DocumentRootElements</c> of the <c>XmiReaderResult</c> that was read. Its <c>RootElements</c> also hold the
        /// top-level elements of the external documents that were loaded while resolving references; writing those
        /// merges several documents into one, whose identifiers can clash
        /// </param>
        /// <param name="stream">
        /// The <see cref="Stream"/> to which the XMI content is written.
        /// </param>
        /// <param name="documentName">
        /// The name of the document that is being written.
        /// </param>
        /// <param name="documentation">
        /// The <see cref="Documentation"/> that is to be written as a sibling of the <paramref name="rootElements"/>,
        /// typically the <c>Documentation</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        /// <param name="documentExtensions">
        /// The <see cref="XmiExtension"/>s that are to be written as a sibling of the <paramref name="rootElements"/>,
        /// typically the <c>Extensions</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        /// <param name="tags">
        /// The MOF <see cref="Tag"/>s that are to be written as <c>mofext:Tag</c> siblings of the
        /// <paramref name="rootElements"/>, typically the <c>Tags</c> of the <c>XmiRoot</c> that was read. May be null;
        /// the <c>mofext</c> namespace is declared only when there are tags.
        /// </param>
        public void Write(IEnumerable<IXmiElement> rootElements, Stream stream, string documentName, Documentation documentation, IEnumerable<XmiExtension> documentExtensions, IEnumerable<Tag> tags)
        {
            this.WriteDocument(rootElements, stream, documentName, documentation, documentExtensions, tags, []);
        }

        /// <summary>
        /// Writes the provided root elements and the document-level parts of the provided <see cref="XmiRoot"/> to a UML
        /// XMI 2.5.1 file: its <see cref="XmiRoot.Documentation"/>, <see cref="XmiRoot.Tags"/>,
        /// <see cref="XmiRoot.Extensions"/>, and the elements that were captured without being processed,
        /// <see cref="XmiRoot.DiagramInterchange"/> and <see cref="XmiRoot.UnprocessedContent"/>.
        /// </summary>
        /// <param name="rootElements">
        /// The <see cref="IXmiElement"/>s that are to be written as top-level elements, typically the
        /// <c>DocumentRootElements</c> of the <c>XmiReaderResult</c> that was read
        /// </param>
        /// <param name="fileUri">
        /// The URI of the XMI file that is to be written.
        /// </param>
        /// <param name="xmiRoot">
        /// The <see cref="XmiRoot"/> whose document-level parts are written, typically the <c>XmiRoot</c> of the
        /// <c>XmiReaderResult</c> that was read; its <see cref="XmiRoot.Content"/> is not written, the
        /// <paramref name="rootElements"/> are. May be null, in which case only the <paramref name="rootElements"/> are written
        /// </param>
        public void Write(IEnumerable<IXmiElement> rootElements, string fileUri, XmiRoot xmiRoot)
        {
            if (rootElements == null)
            {
                throw new ArgumentNullException(nameof(rootElements));
            }

            if (string.IsNullOrEmpty(fileUri))
            {
                throw new ArgumentException(nameof(fileUri));
            }

            using var fileStream = File.Create(fileUri);

            var sw = Stopwatch.StartNew();

            this.logger.LogInformation("start serializing to {Path}", fileUri);

            this.Write(rootElements, fileStream, new FileInfo(fileUri).Name, xmiRoot);

            this.logger.LogInformation("File {Path} serialized in {Time} [ms]", fileUri, sw.ElapsedMilliseconds);
        }

        /// <summary>
        /// Writes the provided root elements and the document-level parts of the provided <see cref="XmiRoot"/> to a UML
        /// XMI 2.5.1 stream: its <see cref="XmiRoot.Documentation"/>, <see cref="XmiRoot.Tags"/>,
        /// <see cref="XmiRoot.Extensions"/>, and the elements that were captured without being processed,
        /// <see cref="XmiRoot.DiagramInterchange"/> and <see cref="XmiRoot.UnprocessedContent"/>.
        /// </summary>
        /// <param name="rootElements">
        /// The <see cref="IXmiElement"/>s that are to be written as top-level elements, typically the
        /// <c>DocumentRootElements</c> of the <c>XmiReaderResult</c> that was read
        /// </param>
        /// <param name="stream">
        /// The <see cref="Stream"/> to which the XMI content is written.
        /// </param>
        /// <param name="documentName">
        /// The name of the document that is being written.
        /// </param>
        /// <param name="xmiRoot">
        /// The <see cref="XmiRoot"/> whose document-level parts are written, typically the <c>XmiRoot</c> of the
        /// <c>XmiReaderResult</c> that was read; its <see cref="XmiRoot.Content"/> is not written, the
        /// <paramref name="rootElements"/> are. May be null, in which case only the <paramref name="rootElements"/> are written
        /// </param>
        /// <remarks>
        /// The top-level elements are written in this order: the documentation, the root elements, the tags, the captured
        /// elements in the order in which they were read, and the extensions. The namespaces that the captured elements
        /// use are declared on <c>xmi:XMI</c>. The <see cref="XmiRoot.StereoTypeApplications"/> are not written.
        /// </remarks>
        public void Write(IEnumerable<IXmiElement> rootElements, Stream stream, string documentName, XmiRoot xmiRoot)
        {
            this.WriteDocument(rootElements, stream, documentName, xmiRoot?.Documentation, xmiRoot?.Extensions, xmiRoot?.Tags, QueryCapturedElements(xmiRoot));
        }

        /// <summary>
        /// Queries the captured elements of the provided <see cref="XmiRoot"/>, in the order in which they were read
        /// </summary>
        /// <param name="xmiRoot">
        /// The <see cref="XmiRoot"/>, may be null
        /// </param>
        /// <returns>
        /// The <see cref="XmiRoot.DiagramInterchange"/> and <see cref="XmiRoot.UnprocessedContent"/> elements ordered by
        /// their <see cref="CapturedElement.Position"/>
        /// </returns>
        private static List<CapturedElement> QueryCapturedElements(XmiRoot xmiRoot)
        {
            if (xmiRoot == null)
            {
                return [];
            }

            return xmiRoot.DiagramInterchange.Concat(xmiRoot.UnprocessedContent).OrderBy(x => x.Position).ToList();
        }

        /// <summary>
        /// Queries the namespace declarations that the root element declares in addition to <c>xmi</c> and <c>uml</c>
        /// </summary>
        /// <param name="hasTags">
        /// A value indicating whether tags are written, in which case <c>mofext</c> is declared
        /// </param>
        /// <param name="capturedElements">
        /// The captured elements that are written
        /// </param>
        /// <returns>
        /// The additional namespace declarations, by prefix
        /// </returns>
        private List<KeyValuePair<string, string>> QueryAdditionalRootNamespaceDeclarations(bool hasTags, IReadOnlyList<CapturedElement> capturedElements)
        {
            var result = new List<KeyValuePair<string, string>>();
            var declaredPrefixes = new List<string> { KnowNamespacePrefixes.Xmi, KnowNamespacePrefixes.Uml };

            if (hasTags)
            {
                result.Add(new KeyValuePair<string, string>(KnowNamespacePrefixes.MofExt, this.XmiWriterSettings.MofExtNamespaceUri));
                declaredPrefixes.Add(KnowNamespacePrefixes.MofExt);
            }

            result.AddRange(CapturedElementWriter.QueryRootNamespaceDeclarations(capturedElements, declaredPrefixes));

            return result;
        }

        /// <summary>
        /// Writes the provided root elements and document-level parts to a UML XMI 2.5.1 stream
        /// </summary>
        /// <param name="rootElements">
        /// The <see cref="IXmiElement"/>s that are to be written as top-level elements
        /// </param>
        /// <param name="stream">
        /// The <see cref="Stream"/> to which the XMI content is written.
        /// </param>
        /// <param name="documentName">
        /// The name of the document that is being written.
        /// </param>
        /// <param name="documentation">
        /// The <see cref="Documentation"/> that is to be written, may be null
        /// </param>
        /// <param name="documentExtensions">
        /// The <see cref="XmiExtension"/>s that are to be written, may be null
        /// </param>
        /// <param name="tags">
        /// The MOF <see cref="Tag"/>s that are to be written, may be null
        /// </param>
        /// <param name="capturedElements">
        /// The <see cref="CapturedElement"/>s that are to be written, in order
        /// </param>
        private void WriteDocument(IEnumerable<IXmiElement> rootElements, Stream stream, string documentName, Documentation documentation, IEnumerable<XmiExtension> documentExtensions, IEnumerable<Tag> tags, IReadOnlyList<CapturedElement> capturedElements)
        {
            if (rootElements == null)
            {
                throw new ArgumentNullException(nameof(rootElements));
            }

            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (string.IsNullOrEmpty(documentName))
            {
                throw new ArgumentException(nameof(documentName));
            }

            var writeContext = this.CreateWriteContext(rootElements, documentName, out var xmiWritePlan);

            var tagList = tags?.ToList() ?? [];

            using var xmlWriter = XmlWriter.Create(stream, this.CreateXmlWriterSettings(isAsync: false));

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("xmi", "XMI", this.XmiWriterSettings.XmiNamespaceUri);
            xmlWriter.WriteAttributeString("xmlns", "uml", null, this.XmiWriterSettings.UmlNamespaceUri);

            foreach (var namespaceDeclaration in this.QueryAdditionalRootNamespaceDeclarations(tagList.Count > 0, capturedElements))
            {
                xmlWriter.WriteAttributeString("xmlns", namespaceDeclaration.Key, null, namespaceDeclaration.Value);
            }

            if (documentation != null)
            {
                var documentationWriter = new DocumentationWriter(this.XmiWriterSettings, this.LoggerFactory);

                documentationWriter.Write(xmlWriter, documentation);
            }

            foreach (var rootElement in xmiWritePlan.RootElements)
            {
                this.XmiElementWriterFacade.Write(xmlWriter, rootElement, $"uml:{rootElement.GetType().Name}", writeContext);
            }

            if (tagList.Count > 0)
            {
                var tagWriter = new TagWriter(this.XmiWriterSettings, this.LoggerFactory);

                foreach (var tag in tagList)
                {
                    tagWriter.Write(xmlWriter, tag);
                }
            }

            if (capturedElements.Count > 0)
            {
                var capturedElementWriter = new CapturedElementWriter(this.LoggerFactory);

                foreach (var capturedElement in capturedElements)
                {
                    capturedElementWriter.Write(xmlWriter, capturedElement);
                }
            }

            if (documentExtensions != null)
            {
                var xmiExtensionWriter = new XmiExtensionWriter(this.XmiWriterSettings, this.LoggerFactory);

                foreach (var documentExtension in documentExtensions)
                {
                    xmiExtensionWriter.Write(xmlWriter, documentExtension);
                }
            }

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Flush();
        }

        /// <summary>
        /// Asynchronously writes the provided <see cref="IPackage"/> to a UML XMI 2.5.1 file.
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> that is to be written
        /// </param>
        /// <param name="fileUri">
        /// The URI of the XMI file that is to be written.
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used to cancel the write operation
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        public Task WriteAsync(IPackage package, string fileUri, CancellationToken cancellationToken = default)
        {
            return this.WriteAsync(package, fileUri, null, cancellationToken);
        }

        /// <summary>
        /// Asynchronously writes the provided <see cref="IPackage"/> and <see cref="XmiExtension"/>s to a
        /// UML XMI 2.5.1 file.
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> that is to be written
        /// </param>
        /// <param name="fileUri">
        /// The URI of the XMI file that is to be written.
        /// </param>
        /// <param name="documentExtensions">
        /// The <see cref="XmiExtension"/>s that are to be written as a sibling of the <paramref name="package"/>,
        /// typically the <c>Extensions</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used to cancel the write operation
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        public Task WriteAsync(IPackage package, string fileUri, IEnumerable<XmiExtension> documentExtensions, CancellationToken cancellationToken = default)
        {
            return this.WriteAsync(package, fileUri, null, documentExtensions, cancellationToken);
        }

        /// <summary>
        /// Asynchronously writes the provided <see cref="IPackage"/>, <see cref="Documentation"/> and
        /// <see cref="XmiExtension"/>s to a UML XMI 2.5.1 file.
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> that is to be written
        /// </param>
        /// <param name="fileUri">
        /// The URI of the XMI file that is to be written.
        /// </param>
        /// <param name="documentation">
        /// The <see cref="Documentation"/> that is to be written as a sibling of the <paramref name="package"/>,
        /// typically the <c>Documentation</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        /// <param name="documentExtensions">
        /// The <see cref="XmiExtension"/>s that are to be written as a sibling of the <paramref name="package"/>,
        /// typically the <c>Extensions</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used to cancel the write operation
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        public Task WriteAsync(IPackage package, string fileUri, Documentation documentation, IEnumerable<XmiExtension> documentExtensions, CancellationToken cancellationToken = default)
        {
            if (package == null)
            {
                throw new ArgumentNullException(nameof(package));
            }

            return this.WriteAsync(new IXmiElement[] { package }, fileUri, documentation, documentExtensions, cancellationToken);
        }

        /// <summary>
        /// Asynchronously writes the provided root elements, <see cref="Documentation"/> and <see cref="XmiExtension"/>s
        /// to a UML XMI 2.5.1 file. The root elements are written as the top-level elements of the document, in the
        /// provided order, and do not need to be <see cref="IPackage"/>s.
        /// </summary>
        /// <param name="rootElements">
        /// The <see cref="IXmiElement"/>s that are to be written as top-level elements, typically the
        /// <c>DocumentRootElements</c> of the <c>XmiReaderResult</c> that was read. Its <c>RootElements</c> also hold the
        /// top-level elements of the external documents that were loaded while resolving references; writing those
        /// merges several documents into one, whose identifiers can clash
        /// </param>
        /// <param name="fileUri">
        /// The URI of the XMI file that is to be written.
        /// </param>
        /// <param name="documentation">
        /// The <see cref="Documentation"/> that is to be written as a sibling of the <paramref name="rootElements"/>,
        /// typically the <c>Documentation</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        /// <param name="documentExtensions">
        /// The <see cref="XmiExtension"/>s that are to be written as a sibling of the <paramref name="rootElements"/>,
        /// typically the <c>Extensions</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used to cancel the write operation
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        public Task WriteAsync(IEnumerable<IXmiElement> rootElements, string fileUri, Documentation documentation, IEnumerable<XmiExtension> documentExtensions, CancellationToken cancellationToken = default)
        {
            return this.WriteAsync(rootElements, fileUri, documentation, documentExtensions, null, cancellationToken);
        }

        /// <summary>
        /// Asynchronously writes the provided root elements, <see cref="Documentation"/>, <see cref="XmiExtension"/>s
        /// and MOF <see cref="Tag"/>s to a UML XMI 2.5.1 file. The root elements are written as the top-level elements of
        /// the document, in the provided order, and do not need to be <see cref="IPackage"/>s.
        /// </summary>
        /// <param name="rootElements">
        /// The <see cref="IXmiElement"/>s that are to be written as top-level elements, typically the
        /// <c>DocumentRootElements</c> of the <c>XmiReaderResult</c> that was read. Its <c>RootElements</c> also hold the
        /// top-level elements of the external documents that were loaded while resolving references; writing those
        /// merges several documents into one, whose identifiers can clash
        /// </param>
        /// <param name="fileUri">
        /// The URI of the XMI file that is to be written.
        /// </param>
        /// <param name="documentation">
        /// The <see cref="Documentation"/> that is to be written as a sibling of the <paramref name="rootElements"/>,
        /// typically the <c>Documentation</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        /// <param name="documentExtensions">
        /// The <see cref="XmiExtension"/>s that are to be written as a sibling of the <paramref name="rootElements"/>,
        /// typically the <c>Extensions</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        /// <param name="tags">
        /// The MOF <see cref="Tag"/>s that are to be written as <c>mofext:Tag</c> siblings of the
        /// <paramref name="rootElements"/>, typically the <c>Tags</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used to cancel the write operation
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        public async Task WriteAsync(IEnumerable<IXmiElement> rootElements, string fileUri, Documentation documentation, IEnumerable<XmiExtension> documentExtensions, IEnumerable<Tag> tags, CancellationToken cancellationToken = default)
        {
            if (rootElements == null)
            {
                throw new ArgumentNullException(nameof(rootElements));
            }

            if (string.IsNullOrEmpty(fileUri))
            {
                throw new ArgumentException(nameof(fileUri));
            }

            using var fileStream = File.Create(fileUri);

            var sw = Stopwatch.StartNew();

            this.logger.LogInformation("start serializing to {Path}", fileUri);

            await this.WriteAsync(rootElements, fileStream, new FileInfo(fileUri).Name, documentation, documentExtensions, tags, cancellationToken);

            this.logger.LogInformation("File {Path} serialized in {Time} [ms]", fileUri, sw.ElapsedMilliseconds);
        }

        /// <summary>
        /// Asynchronously writes the provided <see cref="IPackage"/> to a UML XMI 2.5.1 stream.
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> that is to be written
        /// </param>
        /// <param name="stream">
        /// The <see cref="Stream"/> to which the XMI content is written.
        /// </param>
        /// <param name="documentName">
        /// The name of the document that is being written.
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used to cancel the write operation
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        public Task WriteAsync(IPackage package, Stream stream, string documentName, CancellationToken cancellationToken = default)
        {
            return this.WriteAsync(package, stream, documentName, null, cancellationToken);
        }

        /// <summary>
        /// Asynchronously writes the provided <see cref="IPackage"/> and <see cref="XmiExtension"/>s to a
        /// UML XMI 2.5.1 stream.
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> that is to be written
        /// </param>
        /// <param name="stream">
        /// The <see cref="Stream"/> to which the XMI content is written.
        /// </param>
        /// <param name="documentName">
        /// The name of the document that is being written.
        /// </param>
        /// <param name="documentExtensions">
        /// The <see cref="XmiExtension"/>s that are to be written as a sibling of the <paramref name="package"/>,
        /// typically the <c>Extensions</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used to cancel the write operation
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        public Task WriteAsync(IPackage package, Stream stream, string documentName, IEnumerable<XmiExtension> documentExtensions, CancellationToken cancellationToken = default)
        {
            return this.WriteAsync(package, stream, documentName, null, documentExtensions, cancellationToken);
        }

        /// <summary>
        /// Asynchronously writes the provided <see cref="IPackage"/>, <see cref="Documentation"/> and
        /// <see cref="XmiExtension"/>s to a UML XMI 2.5.1 stream.
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> that is to be written
        /// </param>
        /// <param name="stream">
        /// The <see cref="Stream"/> to which the XMI content is written.
        /// </param>
        /// <param name="documentName">
        /// The name of the document that is being written.
        /// </param>
        /// <param name="documentation">
        /// The <see cref="Documentation"/> that is to be written as a sibling of the <paramref name="package"/>,
        /// typically the <c>Documentation</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        /// <param name="documentExtensions">
        /// The <see cref="XmiExtension"/>s that are to be written as a sibling of the <paramref name="package"/>,
        /// typically the <c>Extensions</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used to cancel the write operation
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        public Task WriteAsync(IPackage package, Stream stream, string documentName, Documentation documentation, IEnumerable<XmiExtension> documentExtensions, CancellationToken cancellationToken = default)
        {
            if (package == null)
            {
                throw new ArgumentNullException(nameof(package));
            }

            return this.WriteAsync(new IXmiElement[] { package }, stream, documentName, documentation, documentExtensions, cancellationToken);
        }

        /// <summary>
        /// Asynchronously writes the provided root elements, <see cref="Documentation"/> and <see cref="XmiExtension"/>s
        /// to a UML XMI 2.5.1 stream. The root elements are written as the top-level elements of the document, in the
        /// provided order, and do not need to be <see cref="IPackage"/>s.
        /// </summary>
        /// <param name="rootElements">
        /// The <see cref="IXmiElement"/>s that are to be written as top-level elements, typically the
        /// <c>DocumentRootElements</c> of the <c>XmiReaderResult</c> that was read. Its <c>RootElements</c> also hold the
        /// top-level elements of the external documents that were loaded while resolving references; writing those
        /// merges several documents into one, whose identifiers can clash
        /// </param>
        /// <param name="stream">
        /// The <see cref="Stream"/> to which the XMI content is written.
        /// </param>
        /// <param name="documentName">
        /// The name of the document that is being written.
        /// </param>
        /// <param name="documentation">
        /// The <see cref="Documentation"/> that is to be written as a sibling of the <paramref name="rootElements"/>,
        /// typically the <c>Documentation</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        /// <param name="documentExtensions">
        /// The <see cref="XmiExtension"/>s that are to be written as a sibling of the <paramref name="rootElements"/>,
        /// typically the <c>Extensions</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used to cancel the write operation
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        public Task WriteAsync(IEnumerable<IXmiElement> rootElements, Stream stream, string documentName, Documentation documentation, IEnumerable<XmiExtension> documentExtensions, CancellationToken cancellationToken = default)
        {
            return this.WriteAsync(rootElements, stream, documentName, documentation, documentExtensions, null, cancellationToken);
        }

        /// <summary>
        /// Asynchronously writes the provided root elements, <see cref="Documentation"/>, <see cref="XmiExtension"/>s
        /// and MOF <see cref="Tag"/>s to a UML XMI 2.5.1 stream. The root elements are written as the top-level elements
        /// of the document, in the provided order, and do not need to be <see cref="IPackage"/>s.
        /// </summary>
        /// <param name="rootElements">
        /// The <see cref="IXmiElement"/>s that are to be written as top-level elements, typically the
        /// <c>DocumentRootElements</c> of the <c>XmiReaderResult</c> that was read. Its <c>RootElements</c> also hold the
        /// top-level elements of the external documents that were loaded while resolving references; writing those
        /// merges several documents into one, whose identifiers can clash
        /// </param>
        /// <param name="stream">
        /// The <see cref="Stream"/> to which the XMI content is written.
        /// </param>
        /// <param name="documentName">
        /// The name of the document that is being written.
        /// </param>
        /// <param name="documentation">
        /// The <see cref="Documentation"/> that is to be written as a sibling of the <paramref name="rootElements"/>,
        /// typically the <c>Documentation</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        /// <param name="documentExtensions">
        /// The <see cref="XmiExtension"/>s that are to be written as a sibling of the <paramref name="rootElements"/>,
        /// typically the <c>Extensions</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        /// <param name="tags">
        /// The MOF <see cref="Tag"/>s that are to be written as <c>mofext:Tag</c> siblings of the
        /// <paramref name="rootElements"/>, typically the <c>Tags</c> of the <c>XmiRoot</c> that was read. May be null;
        /// the <c>mofext</c> namespace is declared only when there are tags.
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used to cancel the write operation
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        public Task WriteAsync(IEnumerable<IXmiElement> rootElements, Stream stream, string documentName, Documentation documentation, IEnumerable<XmiExtension> documentExtensions, IEnumerable<Tag> tags, CancellationToken cancellationToken = default)
        {
            return this.WriteDocumentAsync(rootElements, stream, documentName, documentation, documentExtensions, tags, [], cancellationToken);
        }

        /// <summary>
        /// Asynchronously writes the provided root elements and the document-level parts of the provided
        /// <see cref="XmiRoot"/> to a UML XMI 2.5.1 file: its <see cref="XmiRoot.Documentation"/>,
        /// <see cref="XmiRoot.Tags"/>, <see cref="XmiRoot.Extensions"/>, and the elements that were captured without being
        /// processed, <see cref="XmiRoot.DiagramInterchange"/> and <see cref="XmiRoot.UnprocessedContent"/>.
        /// </summary>
        /// <param name="rootElements">
        /// The <see cref="IXmiElement"/>s that are to be written as top-level elements, typically the
        /// <c>DocumentRootElements</c> of the <c>XmiReaderResult</c> that was read
        /// </param>
        /// <param name="fileUri">
        /// The URI of the XMI file that is to be written.
        /// </param>
        /// <param name="xmiRoot">
        /// The <see cref="XmiRoot"/> whose document-level parts are written, typically the <c>XmiRoot</c> of the
        /// <c>XmiReaderResult</c> that was read; its <see cref="XmiRoot.Content"/> is not written, the
        /// <paramref name="rootElements"/> are. May be null, in which case only the <paramref name="rootElements"/> are written
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used to cancel the write operation
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        public async Task WriteAsync(IEnumerable<IXmiElement> rootElements, string fileUri, XmiRoot xmiRoot, CancellationToken cancellationToken = default)
        {
            if (rootElements == null)
            {
                throw new ArgumentNullException(nameof(rootElements));
            }

            if (string.IsNullOrEmpty(fileUri))
            {
                throw new ArgumentException(nameof(fileUri));
            }

            using var fileStream = File.Create(fileUri);

            var sw = Stopwatch.StartNew();

            this.logger.LogInformation("start serializing to {Path}", fileUri);

            await this.WriteAsync(rootElements, fileStream, new FileInfo(fileUri).Name, xmiRoot, cancellationToken);

            this.logger.LogInformation("File {Path} serialized in {Time} [ms]", fileUri, sw.ElapsedMilliseconds);
        }

        /// <summary>
        /// Asynchronously writes the provided root elements and the document-level parts of the provided
        /// <see cref="XmiRoot"/> to a UML XMI 2.5.1 stream: its <see cref="XmiRoot.Documentation"/>,
        /// <see cref="XmiRoot.Tags"/>, <see cref="XmiRoot.Extensions"/>, and the elements that were captured without being
        /// processed, <see cref="XmiRoot.DiagramInterchange"/> and <see cref="XmiRoot.UnprocessedContent"/>.
        /// </summary>
        /// <param name="rootElements">
        /// The <see cref="IXmiElement"/>s that are to be written as top-level elements, typically the
        /// <c>DocumentRootElements</c> of the <c>XmiReaderResult</c> that was read
        /// </param>
        /// <param name="stream">
        /// The <see cref="Stream"/> to which the XMI content is written.
        /// </param>
        /// <param name="documentName">
        /// The name of the document that is being written.
        /// </param>
        /// <param name="xmiRoot">
        /// The <see cref="XmiRoot"/> whose document-level parts are written, typically the <c>XmiRoot</c> of the
        /// <c>XmiReaderResult</c> that was read; its <see cref="XmiRoot.Content"/> is not written, the
        /// <paramref name="rootElements"/> are. May be null, in which case only the <paramref name="rootElements"/> are written
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used to cancel the write operation
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        /// <remarks>
        /// The top-level elements are written in this order: the documentation, the root elements, the tags, the captured
        /// elements in the order in which they were read, and the extensions. The namespaces that the captured elements
        /// use are declared on <c>xmi:XMI</c>. The <see cref="XmiRoot.StereoTypeApplications"/> are not written.
        /// </remarks>
        public Task WriteAsync(IEnumerable<IXmiElement> rootElements, Stream stream, string documentName, XmiRoot xmiRoot, CancellationToken cancellationToken = default)
        {
            return this.WriteDocumentAsync(rootElements, stream, documentName, xmiRoot?.Documentation, xmiRoot?.Extensions, xmiRoot?.Tags, QueryCapturedElements(xmiRoot), cancellationToken);
        }

        /// <summary>
        /// Asynchronously writes the provided root elements and document-level parts to a UML XMI 2.5.1 stream
        /// </summary>
        /// <param name="rootElements">
        /// The <see cref="IXmiElement"/>s that are to be written as top-level elements
        /// </param>
        /// <param name="stream">
        /// The <see cref="Stream"/> to which the XMI content is written.
        /// </param>
        /// <param name="documentName">
        /// The name of the document that is being written.
        /// </param>
        /// <param name="documentation">
        /// The <see cref="Documentation"/> that is to be written, may be null
        /// </param>
        /// <param name="documentExtensions">
        /// The <see cref="XmiExtension"/>s that are to be written, may be null
        /// </param>
        /// <param name="tags">
        /// The MOF <see cref="Tag"/>s that are to be written, may be null
        /// </param>
        /// <param name="capturedElements">
        /// The <see cref="CapturedElement"/>s that are to be written, in order
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used to cancel the write operation
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        private async Task WriteDocumentAsync(IEnumerable<IXmiElement> rootElements, Stream stream, string documentName, Documentation documentation, IEnumerable<XmiExtension> documentExtensions, IEnumerable<Tag> tags, IReadOnlyList<CapturedElement> capturedElements, CancellationToken cancellationToken)
        {
            if (rootElements == null)
            {
                throw new ArgumentNullException(nameof(rootElements));
            }

            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (string.IsNullOrEmpty(documentName))
            {
                throw new ArgumentException(nameof(documentName));
            }

            var writeContext = this.CreateWriteContext(rootElements, documentName, out var xmiWritePlan);

            var tagList = tags?.ToList() ?? [];

            using var xmlWriter = XmlWriter.Create(stream, this.CreateXmlWriterSettings(isAsync: true));

            await xmlWriter.WriteStartDocumentAsync();
            await xmlWriter.WriteStartElementAsync("xmi", "XMI", this.XmiWriterSettings.XmiNamespaceUri);
            await xmlWriter.WriteAttributeStringAsync("xmlns", "uml", null, this.XmiWriterSettings.UmlNamespaceUri);

            foreach (var namespaceDeclaration in this.QueryAdditionalRootNamespaceDeclarations(tagList.Count > 0, capturedElements))
            {
                await xmlWriter.WriteAttributeStringAsync("xmlns", namespaceDeclaration.Key, null, namespaceDeclaration.Value);
            }

            if (documentation != null)
            {
                var documentationWriter = new DocumentationWriter(this.XmiWriterSettings, this.LoggerFactory);

                await documentationWriter.WriteAsync(xmlWriter, documentation);
            }

            foreach (var rootElement in xmiWritePlan.RootElements)
            {
                cancellationToken.ThrowIfCancellationRequested();

                await this.XmiElementWriterFacade.WriteAsync(xmlWriter, rootElement, $"uml:{rootElement.GetType().Name}", writeContext);
            }

            if (tagList.Count > 0)
            {
                var tagWriter = new TagWriter(this.XmiWriterSettings, this.LoggerFactory);

                foreach (var tag in tagList)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    await tagWriter.WriteAsync(xmlWriter, tag);
                }
            }

            if (capturedElements.Count > 0)
            {
                var capturedElementWriter = new CapturedElementWriter(this.LoggerFactory);

                foreach (var capturedElement in capturedElements)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    await capturedElementWriter.WriteAsync(xmlWriter, capturedElement);
                }
            }

            if (documentExtensions != null)
            {
                var xmiExtensionWriter = new XmiExtensionWriter(this.XmiWriterSettings, this.LoggerFactory);

                foreach (var documentExtension in documentExtensions)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    await xmiExtensionWriter.WriteAsync(xmlWriter, documentExtension);
                }
            }

            await xmlWriter.WriteEndElementAsync();
            await xmlWriter.WriteEndDocumentAsync();
            await xmlWriter.FlushAsync();
        }

        /// <summary>
        /// Creates the <see cref="IXmiWriteContext"/> for the provided root elements based on the
        /// <see cref="XmiWritePlan"/> that is calculated by the <see cref="IReferenceClosureCalculator"/>.
        /// </summary>
        /// <param name="rootElements">
        /// The <see cref="IXmiElement"/>s that are to be written as top-level elements
        /// </param>
        /// <param name="documentName">
        /// The name of the document that is being written.
        /// </param>
        /// <param name="xmiWritePlan">
        /// The calculated <see cref="XmiWritePlan"/>
        /// </param>
        /// <returns>
        /// The created <see cref="IXmiWriteContext"/>
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// thrown when elements that are part of the document do not have an <see cref="IXmiElement.XmiId"/>, or when
        /// referenced elements that are not written in the document do not have an <see cref="IXmiElement.DocumentName"/>
        /// </exception>
        private IXmiWriteContext CreateWriteContext(IEnumerable<IXmiElement> rootElements, string documentName, out XmiWritePlan xmiWritePlan)
        {
            xmiWritePlan = this.referenceClosureCalculator.CalculateWritePlan(rootElements, this.XmiWriterSettings.ExternalReferenceResolution, documentName);

            if (xmiWritePlan.ElementsMissingXmiId.Count > 0)
            {
                var offenders = string.Join(", ", xmiWritePlan.ElementsMissingXmiId.Select(x => x.GetType().Name));

                throw new InvalidOperationException($"The model cannot be written since the following elements do not have an XmiId: {offenders}");
            }

            if (xmiWritePlan.ElementsMissingDocumentName.Count > 0)
            {
                var offenders = string.Join(", ", xmiWritePlan.ElementsMissingDocumentName.Select(x => $"{x.GetType().Name} [{x.XmiId}]"));

                throw new InvalidOperationException($"The model cannot be written since the following referenced elements are not written in the document and do not have a DocumentName, an href to them would be \"#id\": {offenders}");
            }

            return new XmiWriteContext(documentName, xmiWritePlan.LocalIdentifiers);
        }

        /// <summary>
        /// Creates the <see cref="XmlWriterSettings"/> used to create an <see cref="XmlWriter"/>.
        /// </summary>
        /// <param name="isAsync">
        /// A value indicating whether asynchronous <see cref="XmlWriter"/> methods can be used
        /// </param>
        /// <returns>
        /// The created <see cref="XmlWriterSettings"/>
        /// </returns>
        private XmlWriterSettings CreateXmlWriterSettings(bool isAsync)
        {
            return new XmlWriterSettings
            {
                Async = isAsync,
                Indent = this.XmiWriterSettings.Indent,
                IndentChars = "  ",
                NewLineChars = "\n",
                NewLineHandling = NewLineHandling.Replace,
                OmitXmlDeclaration = false,
                Encoding = new UTF8Encoding(false)
            };
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">
        /// A value indicating whether this class is being disposed of
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.scope.Dispose();
            }
        }

        /// <summary>
        /// Finalizer
        /// </summary>
        ~XmiWriter()
        {
            this.Dispose(false);
        }
    }
}
