// -------------------------------------------------------------------------------------------------
// <copyright file="XmiReader.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2024 Starion Group S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, softwareUseCases
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
    using System.Diagnostics;
    using System.IO;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;
    
    using uml4net.Packages;
    using uml4net.xmi;
    using uml4net.xmi.ReferenceResolver;
    
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
        private readonly ILoggerFactory loggerFactory;

        /// <summary>
        /// The <see cref="IExternalReferenceResolver"/>
        /// </summary>
        private readonly IExternalReferenceResolver externalReferenceResolver;

        /// <summary>
        /// The <see cref="IXmiReaderScope"/>
        /// </summary>
        private readonly IXmiReaderScope scope;

        /// <summary>
        /// The <see cref="IXmiElementCache"/>
        /// </summary>
        private readonly IXmiElementCache cache;

        /// <summary>
        /// The (injected) <see cref="IXmiElementReaderFacade"/> used to resolve any
        /// required <see cref="IXmiElementReader{T}"/>
        /// </summary>
        private readonly IXmiElementReaderFacade xmiElementReaderFacade;

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
        /// <param name="externalReferenceResolver">The <see cref="IExternalReferenceResolver"/></param>
        /// <param name="scope">The <see cref="IXmiReaderScope"/></param>
        public XmiReader(IAssembler assembler, IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, ILoggerFactory loggerFactory,
            IExternalReferenceResolver externalReferenceResolver, IXmiReaderScope scope)
        {
            this.assembler = assembler;
            this.cache = cache;
            this.xmiElementReaderFacade = xmiElementReaderFacade;
            this.loggerFactory = loggerFactory;
            this.logger = this.loggerFactory == null ? NullLogger<XmiReader>.Instance : this.loggerFactory.CreateLogger<XmiReader>();
            this.externalReferenceResolver = externalReferenceResolver;
            this.scope = scope;
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
            if (fileUri == null)
            {
                throw new ArgumentNullException(nameof(fileUri));
            }

            if (fileUri.Length == 0)
            {
                throw new ArgumentException(nameof(fileUri));
            }

            using var fileStream = File.OpenRead(fileUri);

            var sw = Stopwatch.StartNew();

            this.logger.LogTrace("start deserializing from {Path}", fileUri);

            var result = this.Read(fileStream);

            this.logger.LogTrace("File {Path} deserialized in {Time} [ms]", fileUri, sw.ElapsedMilliseconds);

            return result;
        }

        /// <summary>
        /// Reads the content of a UML XMI 2.5.1 stream.
        /// </summary>
        /// <param name="stream">
        /// The <see cref="Stream"/> that contains the XMI content to be read.
        /// </param>
        /// <returns>
        /// An <see cref="XmiReaderResult"/> that contains the root <see cref="IPackage"/> and other
        /// contained <see cref="IPackage"/>s representing contents of XMI stream
        /// </returns>
        public XmiReaderResult Read(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            var xmiReaderResult = new XmiReaderResult();

            this.Read(stream, xmiReaderResult, true);

            return xmiReaderResult;
        }

        /// <summary>
        /// Reads the content of a UML XMI 2.5.1 stream.
        /// </summary>
        /// <param name="stream">
        /// The <see cref="Stream"/> that contains the XMI content to be read.
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
        private void Read(Stream stream, XmiReaderResult xmiReaderResult, bool isRoot)
        {
            var settings = new XmlReaderSettings();

            stream.Seek(0, SeekOrigin.Begin);

            var sw = Stopwatch.StartNew();

            using (var reader = new StreamReader(stream, detectEncodingFromByteOrderMarks: true))

            using (var xmlReader = XmlReader.Create(reader, settings))
            {
                var defaultLineInfo = xmlReader as IXmlLineInfo;

                this.logger.LogTrace("starting to read xml");

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.Name)
                        {
                            case "uml:Package":

                                var package = (IPackage)xmiElementReaderFacade.QueryXmiElement(xmlReader, this.cache, this.loggerFactory, "uml:Package");
                                xmiReaderResult.Packages.Add(package);

                                if (isRoot)
                                {
                                    xmiReaderResult.Root = package;
                                }

                                break;
                            case "uml:Model":

                                var model = (IModel)xmiElementReaderFacade.QueryXmiElement(xmlReader, this.cache, this.loggerFactory, "uml:Model");
                                xmiReaderResult.Packages.Add(model);

                                if (isRoot)
                                {
                                    xmiReaderResult.Root = model;
                                }

                                break;
                            case "uml:Profile":
                                var profile = (IProfile)xmiElementReaderFacade.QueryXmiElement(xmlReader, this.cache, this.loggerFactory, "uml:Profile");
                                xmiReaderResult.Packages.Add(profile);

                                if (isRoot)
                                {
                                    xmiReaderResult.Root = profile;
                                }

                                break;
                            default:
                                this.logger.LogWarning("XmiReader: {LocalName} at line:position {Line}:{Position} was not read", xmlReader.LocalName, defaultLineInfo.LineNumber, defaultLineInfo.LinePosition);
                                break;
                        }
                    }
                }
            }

            var currentlyElapsedMilliseconds = sw.ElapsedMilliseconds;
            this.logger.LogTrace("xml read in {Time}", currentlyElapsedMilliseconds);
            sw.Stop();

            this.TryResolveExternalReferences(xmiReaderResult);

            if (isRoot)
            {
                this.assembler.Synchronize();
            }
        }

        /// <summary>
        /// Asynchronously resolves external references and updates the cache with the retrieved resources.
        /// </summary>
        /// <param name="xmiReaderResult">
        /// The <see cref="XmiReaderResult"/> to which the read <see cref="IPackage"/>s are added
        /// </param>
        private void TryResolveExternalReferences(XmiReaderResult xmiReaderResult)
        {
            var stopwatch = Stopwatch.StartNew();

            this.logger.LogTrace("resolving the external references");

            foreach (var (context, externalResource) in this.externalReferenceResolver.TryResolve())
            {
                this.cache.SwitchContext(context);
                this.Read(externalResource, xmiReaderResult, false);
            }

            this.logger.LogTrace("External references synchronized in {Time}", stopwatch.ElapsedMilliseconds);

            stopwatch.Stop();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.cache.Cache.Clear();
            this.scope.Dispose();
        }
    }
}
