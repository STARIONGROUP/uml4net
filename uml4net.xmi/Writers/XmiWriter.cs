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
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using uml4net.Packages;
    using uml4net.xmi.Settings;

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
            if (string.IsNullOrEmpty(fileUri))
            {
                throw new ArgumentException(nameof(fileUri));
            }

            using var fileStream = File.Create(fileUri);

            var sw = Stopwatch.StartNew();

            this.logger.LogInformation("start serializing to {Path}", fileUri);

            this.Write(package, fileStream, new FileInfo(fileUri).Name);

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
            if (package == null)
            {
                throw new ArgumentNullException(nameof(package));
            }

            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (string.IsNullOrEmpty(documentName))
            {
                throw new ArgumentException(nameof(documentName));
            }

            var writeContext = this.CreateWriteContext(package, documentName, out var xmiWritePlan);

            using var xmlWriter = XmlWriter.Create(stream, this.CreateXmlWriterSettings(isAsync: false));

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("xmi", "XMI", this.XmiWriterSettings.XmiNamespaceUri);
            xmlWriter.WriteAttributeString("xmlns", "uml", null, this.XmiWriterSettings.UmlNamespaceUri);

            foreach (var rootPackage in xmiWritePlan.RootPackages)
            {
                this.XmiElementWriterFacade.Write(xmlWriter, rootPackage, $"uml:{rootPackage.GetType().Name}", writeContext);
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
        public async Task WriteAsync(IPackage package, string fileUri, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(fileUri))
            {
                throw new ArgumentException(nameof(fileUri));
            }

            using var fileStream = File.Create(fileUri);

            var sw = Stopwatch.StartNew();

            this.logger.LogInformation("start serializing to {Path}", fileUri);

            await this.WriteAsync(package, fileStream, new FileInfo(fileUri).Name, cancellationToken);

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
        public async Task WriteAsync(IPackage package, Stream stream, string documentName, CancellationToken cancellationToken = default)
        {
            if (package == null)
            {
                throw new ArgumentNullException(nameof(package));
            }

            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (string.IsNullOrEmpty(documentName))
            {
                throw new ArgumentException(nameof(documentName));
            }

            var writeContext = this.CreateWriteContext(package, documentName, out var xmiWritePlan);

            using var xmlWriter = XmlWriter.Create(stream, this.CreateXmlWriterSettings(isAsync: true));

            await xmlWriter.WriteStartDocumentAsync();
            await xmlWriter.WriteStartElementAsync("xmi", "XMI", this.XmiWriterSettings.XmiNamespaceUri);
            await xmlWriter.WriteAttributeStringAsync("xmlns", "uml", null, this.XmiWriterSettings.UmlNamespaceUri);

            foreach (var rootPackage in xmiWritePlan.RootPackages)
            {
                cancellationToken.ThrowIfCancellationRequested();

                await this.XmiElementWriterFacade.WriteAsync(xmlWriter, rootPackage, $"uml:{rootPackage.GetType().Name}", writeContext);
            }

            await xmlWriter.WriteEndElementAsync();
            await xmlWriter.WriteEndDocumentAsync();
            await xmlWriter.FlushAsync();
        }

        /// <summary>
        /// Creates the <see cref="IXmiWriteContext"/> for the provided <see cref="IPackage"/> based on the
        /// <see cref="XmiWritePlan"/> that is calculated by the <see cref="IReferenceClosureCalculator"/>.
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> that is to be written
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
        /// thrown when elements that are part of the document do not have an <see cref="IXmiElement.XmiId"/>
        /// </exception>
        private IXmiWriteContext CreateWriteContext(IPackage package, string documentName, out XmiWritePlan xmiWritePlan)
        {
            xmiWritePlan = this.referenceClosureCalculator.CalculateWritePlan(package, this.XmiWriterSettings.ExternalReferenceResolution, documentName);

            if (xmiWritePlan.ElementsMissingXmiId.Count > 0)
            {
                var offenders = string.Join(", ", xmiWritePlan.ElementsMissingXmiId.Select(x => x.GetType().Name));

                throw new InvalidOperationException($"The model cannot be written since the following elements do not have an XmiId: {offenders}");
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
