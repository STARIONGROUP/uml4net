// -------------------------------------------------------------------------------------------------
// <copyright file="XmiReader.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2025 Starion Group S.A.
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
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using uml4net.Packages;
    using uml4net.xmi;
    using uml4net.xmi.Extender;
    using uml4net.xmi.ReferenceResolver;
    using uml4net.xmi.Settings;
    using Xmi;

    /// <summary>
    /// The purpose of the <see cref="XmiReader"/> is to provide a means to read (deserialize)
    /// a UML 2.5.1 model from XMI
    /// </summary>
    public class XmiReader : IXmiReader
    {
        /// <summary>
        /// The <see cref="IAssembler"/>
        /// </summary>
        private readonly IAssembler assembler;

        /// <summary>
        /// The (injected) <see cref="ILogger{XmiReader}"/> used to perform logging
        /// </summary>
        private readonly ILogger<XmiReader> logger;

        /// <summary>
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </summary>
        protected readonly ILoggerFactory LoggerFactory;

        /// <summary>
        /// The <see cref="IExternalReferenceResolver"/>
        /// </summary>
        private readonly IExternalReferenceResolver externalReferenceResolver;

        /// <summary>
        /// The (injected) <see cref="INameSpaceResolver"/> used to resolve a namespace to one of the
        /// <see cref="KnowNamespacePrefixes"/> constants
        /// </summary>
        protected readonly INameSpaceResolver nameSpaceResolver;

        /// <summary>
        /// The <see cref="IXmiReaderScope"/>
        /// </summary>
        private readonly IXmiReaderScope scope;

        /// <summary>
        /// The <see cref="IXmiElementCache"/>
        /// </summary>
        protected readonly IXmiElementCache Cache;

        /// <summary>
        /// The (injected) <see cref="IXmiElementReaderFacade"/> used to resolve any
        /// required <see cref="IXmiElementReader{T}"/>
        /// </summary>
        protected readonly IXmiElementReaderFacade XmiElementReaderFacade;

        /// <summary>
        /// The (injected) <see cref="IXmiReaderSettings"/> used to configure reading
        /// </summary>
        protected readonly IXmiReaderSettings XmiReaderSettings;

        /// <summary>
        /// The injected <see cref="IExtenderReaderRegistry"/> that provides <see cref="IExtenderReader"/> resolve features
        /// </summary>
        protected readonly IExtenderReaderRegistry ExtenderReaderRegistry;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiReader"/> class.
        /// </summary>
        /// <param name="assembler">
        /// The (injected) <see cref="IAssembler"/> used to assemble a UML object graph
        /// </param>
        /// <param name="cache">
        /// The (injected) <see cref="IXmiElementCache"/> used to cache all the <see cref="IXmiElement"/>s
        /// </param>
        /// <param name="xmiElementReaderFacade">
        /// The (injected) <see cref="IXmiElementReaderFacade"/> used to resolve any
        /// required <see cref="IXmiElementReader{T}"/>
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        /// <param name="externalReferenceResolver">
        /// The <see cref="IExternalReferenceResolver"/> used for resolving external references associated with XMI elements.
        /// </param>
        /// <param name="scope">
        /// The <see cref="IXmiReaderScope"/> used for managing the lifecycle of services used during the XMI reading process.
        /// </param>
        /// <param name="xmiReaderSettings">
        /// The injected <see cref="IXmiReaderSettings"/> that provides reading setting for XMI
        /// </param>
        /// <param name="nameSpaceResolver">
        /// The (injected) <see cref="INameSpaceResolver"/> used to resolve a namespace to one of the
        /// <see cref="KnowNamespacePrefixes"/> constants
        /// </param>
        /// <param name="extenderReaderRegistry">The injected <see cref="IExtenderReaderRegistry"/> that provides <see cref="IExtenderReader"/> resolve features</param>
        public XmiReader(IAssembler assembler, IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, ILoggerFactory loggerFactory,
            IExternalReferenceResolver externalReferenceResolver, IXmiReaderScope scope, IXmiReaderSettings xmiReaderSettings, INameSpaceResolver nameSpaceResolver, IExtenderReaderRegistry extenderReaderRegistry)
        {
            this.assembler = assembler;
            this.Cache = cache;
            this.XmiElementReaderFacade = xmiElementReaderFacade;
            this.XmiReaderSettings = xmiReaderSettings;
            this.LoggerFactory = loggerFactory;
            this.logger = this.LoggerFactory == null ? NullLogger<XmiReader>.Instance : this.LoggerFactory.CreateLogger<XmiReader>();
            this.externalReferenceResolver = externalReferenceResolver;
            this.scope = scope;
            this.nameSpaceResolver = nameSpaceResolver;
            this.ExtenderReaderRegistry = extenderReaderRegistry;
        }

        /// <summary>
        /// Reads the content of a UML XMI 2.5.1 file.
        /// </summary>
        /// <param name="fileUri">
        /// The URI of the XMI file to be read.
        /// </param>
        /// <returns>
        /// An <see cref="XmiReaderResult"/> that contains the root <see cref="IPackage"/> and other
        /// contained <see cref="IPackage"/>s representing contents of XMI file
        /// </returns>
        public XmiReaderResult Read(string fileUri)
        {
            if (string.IsNullOrEmpty(fileUri))
            {
                throw new ArgumentException(nameof(fileUri));
            }

            var fileInfo = new FileInfo(fileUri);
            
            if (!fileInfo.Exists)
            {
                throw new ArgumentException($"The file at {fileUri} does not exist");
            }

            using var fileStream = File.OpenRead(fileUri);

            var sw = Stopwatch.StartNew();

            this.logger.LogInformation("start deserializing from {Path}", fileUri);

            var result = this.Read(fileStream, fileInfo.Name);

            this.logger.LogInformation("File {Path} deserialized in {Time} [ms]", fileUri, sw.ElapsedMilliseconds);

            return result;
        }

        /// <summary>
        /// Reads the content of a UML XMI 2.5.1 stream.
        /// </summary>
        /// <param name="stream">
        /// The <see cref="Stream"/> that contains the XMI content to be read.
        /// </param>
        /// <param name="documentName">
        /// The name of the document that is being read from.
        /// </param>
        /// <returns>
        /// An <see cref="XmiReaderResult"/> that contains the root <see cref="IPackage"/> and other
        /// contained <see cref="IPackage"/>s representing contents of XMI stream
        /// </returns>
        public XmiReaderResult Read(Stream stream, string documentName)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (string.IsNullOrEmpty(documentName))
            {
                throw new ArgumentException(nameof(documentName));
            }

            var xmiReaderResult = new XmiReaderResult();

            this.Read(stream, documentName, xmiReaderResult, true);

            var extensions = new List<IXmiExtension>();
            extensions.AddRange(xmiReaderResult.XmiRoot.Extensions);
            extensions.AddRange(this.Cache.Values.SelectMany(x => x.Extensions));

            foreach (var xmiExtension in extensions)
            {
                var extenderReader = this.ExtenderReaderRegistry.Resolve(xmiExtension.Extender, xmiExtension.ExtenderId);
                
                if(extenderReader == null)
                {
                    this.logger.LogInformation("The ExtenderReader for {Extender}:{ExtenderID} does not exist, the Extension cannot be PostProcessed", xmiExtension.Extender, xmiExtension.ExtenderId);
                }
                else
                {
                    extenderReader.PostProcess(xmiExtension);
                }
            }
            
            return xmiReaderResult;
        }

        /// <summary>
        /// Reads the content of a UML XMI 2.5.1 stream.
        /// </summary>
        /// <param name="stream">
        /// The <see cref="Stream"/> that contains the XMI content to be read.
        /// </param>
        /// <param name="documentName">
        /// The name of the document that is being read from.
        /// </param>
        /// <param name="xmiReaderResult">
        /// The <see cref="XmiReaderResult"/> to which the read <see cref="IPackage"/>s are added
        /// </param>
        /// <param name="isRoot">
        /// A value indicating whether the reading occurs on the root node.
        /// </param>
        /// <returns>
        /// An <see cref="XmiReaderResult"/> that contains the root <see cref="IPackage"/> and other
        /// contained <see cref="IPackage"/>s representing contents of XMI stream
        /// </returns>
        private void Read(Stream stream, string documentName, XmiReaderResult xmiReaderResult, bool isRoot)
        {
            var settings = new XmlReaderSettings();

            stream.Seek(0, SeekOrigin.Begin);

            var sw = Stopwatch.StartNew();

            using (var reader = new StreamReader(stream, detectEncodingFromByteOrderMarks: true))

            using (var xmlReader = XmlReader.Create(reader, settings))
            {
                var xmlLineInfo = xmlReader as IXmlLineInfo;

                this.logger.LogTrace("starting to read xml {DocumentName}", documentName);

                xmlReader.MoveToContent();

                if (xmlReader is IXmlNamespaceResolver resolver)
                {
                    var namespaces = resolver.GetNamespacesInScope(XmlNamespaceScope.ExcludeXml);

                    foreach (var namespacesValue in namespaces.Values)
                    {
                        this.nameSpaceResolver.ResolveAndSetNamespace(namespacesValue);
                    }
                }

                var isRootXmiElement = this.nameSpaceResolver.ResolvePrefix(xmlReader.NamespaceURI) == KnowNamespacePrefixes.Xmi;
                var isRootUmlObject = this.nameSpaceResolver.ResolvePrefix(xmlReader.NamespaceURI) == KnowNamespacePrefixes.Uml;

                if (isRootXmiElement && !isRootUmlObject)
                {
                    var xmiRootReader = new XmiRootReader(this.Cache, this.XmiElementReaderFacade, this.XmiReaderSettings, this.nameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory);
                    using var subXmlReader = xmlReader.ReadSubtree();

                    if (isRoot)
                    {
                        var xmiRoot = xmiRootReader.Read(subXmlReader, documentName, xmlReader.NamespaceURI, null);
                        xmiReaderResult.Packages.AddRange(xmiRoot.Content.OfType<IPackage>());
                        xmiReaderResult.XmiRoot = xmiRoot;
                    }
                    else
                    {
                        var xmiRoot = xmiRootReader.Read(subXmlReader, documentName, xmlReader.NamespaceURI, xmiReaderResult.XmiRoot);

                        var existingPackages = new HashSet<IPackage>(xmiReaderResult.Packages);

                        foreach (var pkg in xmiRoot.Content.OfType<IPackage>())
                        {
                            if (existingPackages.Add(pkg))
                            {
                                xmiReaderResult.Packages.Add(pkg);
                            }
                        }
                    }
                }

                if (isRootUmlObject && !isRootXmiElement)
                {
                    XmiRoot xmiRoot = null;

                    if (isRoot)
                    {
                        xmiRoot = new XmiRoot
                        {
                            Documentation = new Documentation
                            {
                                Contact = "Starion Group S.A.",
                                LongDescription = ["uml4net generated XmiRoot -> XmiRoot was not present in the root XMI Document"],
                                ShortDescription = ["uml4net generated XmiRoot"],
                                TimeStamp = DateTime.Now
                            }
                        };
                    }

                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        var activePrefix = this.nameSpaceResolver.ResolvePrefix(xmlReader.NamespaceURI);

                        switch (activePrefix, xmlReader.LocalName)
                        {
                            case (KnowNamespacePrefixes.Uml, "Package"):
                            case (KnowNamespacePrefixes.Uml, "Model"):
                            case (KnowNamespacePrefixes.Uml, "Profile"):
                                var package = (IPackage)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, xmlReader.NamespaceURI, this.Cache, this.XmiReaderSettings, this.nameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory, $"uml:{xmlReader.LocalName}");
                                xmiReaderResult.Packages.Add(package);

                                if (isRoot)
                                {
                                    xmiReaderResult.XmiRoot = xmiRoot;
                                    xmiRoot.Content.Add(package);
                                }

                                break;
                            case (KnowNamespacePrefixes.Xmi, "Extension"):
                                using (var xmiExtensionReader = xmlReader.ReadSubtree())
                                {
                                    if (this.ReadXmiExtension(xmiExtensionReader, documentName, xmlReader.NamespaceURI) is { } extension)
                                    {
                                        xmiReaderResult.Packages.Add(extension);
                                    }
                                }
                                
                                break;
                            default:
                                this.logger.LogWarning("XmiReader: {LocalName} at line:position {Line}:{Position} was not read", xmlReader.LocalName, xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);
                                break;
                        }
                    }
                }

                if (!isRootXmiElement && !isRootUmlObject)
                {
                    throw new InvalidDataException("The root of the document is neither xmi:XMI or one of the UML root objects (Package, Model, Extension)");
                }
            }

            var currentlyElapsedMilliseconds = sw.ElapsedMilliseconds;
            this.logger.LogTrace("{DocumentName} xml read in {Time}", documentName, currentlyElapsedMilliseconds);
            sw.Stop();

            this.TryResolveExternalReferences(xmiReaderResult, documentName);

            if (isRoot)
            {
                this.assembler.Synchronize();
            }
        }

        /// <summary>
        /// Reads an XMI extension using the specified XML reader.
        /// </summary>
        /// <param name="xmlReader">
        /// The <see cref="XmlReader" /> instance to read the XMI extension from.
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="IXmiElement" />
        /// </param>
        /// <param name="namespaceUri">
        /// The namespaceUri of the parent <see cref="XmlReader" />>.
        /// Since <see cref="XmlReader.ReadSubtree" /> is used extensively the <see cref="XmlReader.NamespaceURI" />
        /// returns the empty string when reading from a subtree, therefore it is passed from the caller
        /// </param>
        /// <returns>
        /// An instance of <see cref="IPackage" /> representing the read XMI extension,
        /// or <c>default</c> if no extension is read.
        /// </returns>
        public virtual IPackage ReadXmiExtension(XmlReader xmlReader,  string documentName, string namespaceUri)
        {
            this.logger.LogInformation("Reading this xmi:Extension is not supported by the current XmiReader.");
            return default;
        }
        
        /// <summary>
        /// Asynchronously resolves external references and updates the cache with the retrieved resources.
        /// </summary>
        /// <param name="xmiReaderResult">
        /// The <see cref="XmiReaderResult"/> to which the read <see cref="IPackage"/>s are added
        /// </param>
        /// <param name="documentName">
        /// The name of the document that is being read from.
        /// </param>
        private void TryResolveExternalReferences(XmiReaderResult xmiReaderResult, string documentName)
        {
            var stopwatch = Stopwatch.StartNew();

            this.logger.LogTrace("resolving the external references for {DocumentName}", documentName);

            var x = this.externalReferenceResolver.TryResolve(documentName).ToList();

            foreach (var (context, externalResource) in x)
            {
                this.Read(externalResource, context, xmiReaderResult, false);
            }

            this.logger.LogTrace("External references for {DocumentName} synchronized in {Time} [ms]", documentName, stopwatch.ElapsedMilliseconds);

            stopwatch.Stop();
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
            this.Cache.Clear();
            this.scope.Dispose();
        }

        /// <summary>
        /// Finalizer
        /// </summary>
        ~XmiReader()
        {
            this.Dispose(false);
        }
    }
}
