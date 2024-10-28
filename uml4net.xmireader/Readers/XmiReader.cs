// -------------------------------------------------------------------------------------------------
// <copyright file="XmiReader.cs" company="Starion Group S.A.">
//
//   Copyright 2019-2024 Starion Group S.A.
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
    using Cache;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using uml4net.POCO.Packages;
    using xmi;

    /// <summary>
    /// The purpose of the <see cref="XmiReader"/> is to provide a means to read (deserialize)
    /// an UML 2.5.1 model from XMI
    /// </summary>
    public class XmiReader : IXmiReader
    {
        /// <summary>
        /// The <see cref="IAssembler"/>
        /// </summary>
        private readonly IAssembler assembler;

        /// <summary>
        /// The <see cref="ILogger"/> used to log
        /// </summary>
        private readonly ILogger<XmiReader> logger;
        
        /// <summary>
        /// The <see cref="IExternalReferenceResolver"/>
        /// </summary>
        private readonly IExternalReferenceResolver externalReferenceResolver;

        /// <summary>
        /// The <see cref="IXmiReaderScope"/>
        /// </summary>
        private readonly IXmiReaderScope scope;

        /// <summary>
        /// The <see cref="IXmiReaderCache"/>
        /// </summary>
        private readonly IXmiReaderCache cache;

        /// <summary>
        /// The <see cref="IXmiElementReader{T}"/>of <see cref="IPackage"/>
        /// </summary>
        public IXmiElementReader<IPackage> PackageReader { get; set; }

        /// <summary>
        /// The <see cref="IXmiElementReader{T}"/>of <see cref="IModel"/>
        /// </summary>
        public IXmiElementReader<IModel> ModelReader { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiReader"/> class.
        /// </summary>
        /// <param name="assembler">The <see cref="IAssembler"/></param>
        /// <param name="cache">The <see cref="IXmiReaderCache"/></param>
        /// <param name="logger">
        /// The (injected) <see cref="ILogger{T}"/> used to setup logging
        /// </param>
        /// <param name="externalReferenceResolver">The <see cref="IExternalReferenceResolver"/></param>
        /// <param name="scope">The <see cref="IXmiReaderScope"/></param>
        public XmiReader(IAssembler assembler, IXmiReaderCache cache, ILogger<XmiReader> logger,
            IExternalReferenceResolver externalReferenceResolver, IXmiReaderScope scope)
        {
            this.assembler = assembler;
            this.cache = cache;
            this.logger = logger;
            this.externalReferenceResolver = externalReferenceResolver;
            this.scope = scope;
        }

        /// <summary>
        /// Reads the content of a UML XMI 2.5.1 file asynchronously.
        /// </summary>
        /// <param name="fileUri">
        /// The URI of the XMI file to be read.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{IPackage}"/> representing the deserialized packages from the XMI file.
        /// </returns>
        public IEnumerable<IPackage> Read(string fileUri)
        {
            using var fileStream = File.OpenRead(fileUri);

            var sw = Stopwatch.StartNew();

            this.logger.LogTrace("start deserializing from {path}", fileUri);

            var result = this.Read(fileStream);

            this.logger.LogTrace("File {path} deserialized in {time} [ms]", fileUri, sw.ElapsedMilliseconds);

            return result;
        }

        /// <summary>
        /// Reads the content of a UML XMI 2.5.1 stream asynchronously.
        /// </summary>
        /// <param name="stream">
        /// The <see cref="Stream"/> that contains the XMI content to be read.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{IPackage}"/> representing the deserialized packages from the XMI stream.
        /// </returns>
        public IEnumerable<IPackage> Read(Stream stream)
        {
            return this.Read(stream, true);
        }

        /// <summary>
        /// Reads the content of a UML XMI 2.5.1 stream asynchronously.
        /// </summary>
        /// <param name="stream">
        /// The <see cref="Stream"/> that contains the XMI content to be read.
        /// </param>
        /// <param name="isRoot">
        /// A value indicating whether the reading occurs on the root node.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{IPackage}"/> representing the deserialized packages from the XMI stream.
        /// </returns>
        private IEnumerable<IPackage> Read(Stream stream, bool isRoot)
        {
            var settings = new XmlReaderSettings();

            stream.Seek(0, SeekOrigin.Begin);

            var sw = Stopwatch.StartNew();
            var packages = new List<IPackage>();

            using (var xmlReader = XmlReader.Create(stream, settings))
            {
                this.logger.LogTrace("starting to read xml");

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        //TODO: this should probably be a full list of all kinds of UML classes, use codegen
                        switch (xmlReader.Name)
                        {
                            case "uml:Package":
                                using (var packageXmlReader = xmlReader.ReadSubtree())
                                {
                                    var package = this.PackageReader.Read(packageXmlReader);
                                    packages.Add(package);
                                }

                                break;
                            case "uml:Model":
                                using (var modelXmlReader = xmlReader.ReadSubtree())
                                {
                                    var model = this.ModelReader.Read(modelXmlReader);
                                    packages.Add(model);
                                }

                                break;
                        }
                    }
                }
            }

            var currentlyElapsedMilliseconds = sw.ElapsedMilliseconds;
            this.logger.LogTrace("xml read in {time}", currentlyElapsedMilliseconds);
            sw.Stop();

            this.TryResolveExternalReferences();

            if (isRoot)
            {
                this.assembler.Synchronize();
            }

            return packages;

        }

        /// <summary>
        /// Asynchronously resolves external references and updates the cache with the retrieved resources.
        /// </summary>
        private void TryResolveExternalReferences()
        {
            var stopwatch = Stopwatch.StartNew();

            foreach (var (context, externalResource) in this.externalReferenceResolver.TryResolve())
            {
                this.cache.SwitchContext(context);
                this.Read(externalResource, false);
            }

            this.logger.LogTrace("External references synchronized in {time}", stopwatch.ElapsedMilliseconds);
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
