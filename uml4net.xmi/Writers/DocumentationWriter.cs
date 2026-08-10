// -------------------------------------------------------------------------------------------------
// <copyright file="DocumentationWriter.cs" company="Starion Group S.A.">
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
    using System.Threading.Tasks;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using uml4net.xmi.Settings;
    using uml4net.xmi.Xmi;

    /// <summary>
    /// The purpose of the <see cref="DocumentationWriter"/> is to write an instance of
    /// <see cref="Documentation"/> to an XMI document.
    /// </summary>
    /// <remarks>
    /// The <see cref="Documentation"/> is written as the <c>xmi:Documentation</c> element, a
    /// sibling of the model content, which makes it survive a read - write cycle.
    /// </remarks>
    public class DocumentationWriter
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<DocumentationWriter> logger;

        /// <summary>
        /// The <see cref="IXmiWriterSettings"/> used to configure writing
        /// </summary>
        private readonly IXmiWriterSettings xmiWriterSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentationWriter"/> class.
        /// </summary>
        /// <param name="xmiWriterSettings">
        /// The <see cref="IXmiWriterSettings"/> used to configure writing
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public DocumentationWriter(IXmiWriterSettings xmiWriterSettings, ILoggerFactory loggerFactory)
        {
            this.xmiWriterSettings = xmiWriterSettings;
            this.logger = loggerFactory == null ? NullLogger<DocumentationWriter>.Instance : loggerFactory.CreateLogger<DocumentationWriter>();
        }

        /// <summary>
        /// Writes the <see cref="Documentation"/> object to its XML representation
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="documentation">
        /// The <see cref="Documentation"/> that is to be written
        /// </param>
        public void Write(XmlWriter xmlWriter, Documentation documentation)
        {
            if (xmlWriter == null)
            {
                throw new ArgumentNullException(nameof(xmlWriter));
            }

            if (documentation == null)
            {
                throw new ArgumentNullException(nameof(documentation));
            }

            this.logger.LogTrace("writing the Documentation of {Exporter}:{ExporterVersion}", documentation.Exporter, documentation.ExporterVersion);

            xmlWriter.WriteStartElement("xmi", "Documentation", this.xmiWriterSettings.XmiNamespaceUri);

            if (!string.IsNullOrEmpty(documentation.Contact))
            {
                xmlWriter.WriteAttributeString("contact", documentation.Contact);
            }

            if (!string.IsNullOrEmpty(documentation.Exporter))
            {
                xmlWriter.WriteAttributeString("exporter", documentation.Exporter);
            }

            if (!string.IsNullOrEmpty(documentation.ExporterID))
            {
                xmlWriter.WriteAttributeString("exporterID", documentation.ExporterID);
            }

            if (!string.IsNullOrEmpty(documentation.ExporterVersion))
            {
                xmlWriter.WriteAttributeString("exporterVersion", documentation.ExporterVersion);
            }

            if (documentation.TimeStamp != default)
            {
                xmlWriter.WriteAttributeString("timestamp", XmlConvert.ToString(documentation.TimeStamp, XmlDateTimeSerializationMode.RoundtripKind));
            }

            foreach (var longDescription in documentation.LongDescription)
            {
                xmlWriter.WriteElementString("xmi", "longDescription", this.xmiWriterSettings.XmiNamespaceUri, longDescription);
            }

            foreach (var shortDescription in documentation.ShortDescription)
            {
                xmlWriter.WriteElementString("xmi", "shortDescription", this.xmiWriterSettings.XmiNamespaceUri, shortDescription);
            }

            foreach (var notice in documentation.Notice)
            {
                xmlWriter.WriteElementString("xmi", "notice", this.xmiWriterSettings.XmiNamespaceUri, notice);
            }

            foreach (var owner in documentation.Owner)
            {
                xmlWriter.WriteElementString("xmi", "owner", this.xmiWriterSettings.XmiNamespaceUri, owner);
            }

            xmlWriter.WriteEndElement();
        }

        /// <summary>
        /// Asynchronously writes the <see cref="Documentation"/> object to its XML representation
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="documentation">
        /// The <see cref="Documentation"/> that is to be written
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        public async Task WriteAsync(XmlWriter xmlWriter, Documentation documentation)
        {
            if (xmlWriter == null)
            {
                throw new ArgumentNullException(nameof(xmlWriter));
            }

            if (documentation == null)
            {
                throw new ArgumentNullException(nameof(documentation));
            }

            this.logger.LogTrace("writing the Documentation of {Exporter}:{ExporterVersion}", documentation.Exporter, documentation.ExporterVersion);

            await xmlWriter.WriteStartElementAsync("xmi", "Documentation", this.xmiWriterSettings.XmiNamespaceUri);

            if (!string.IsNullOrEmpty(documentation.Contact))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "contact", null, documentation.Contact);
            }

            if (!string.IsNullOrEmpty(documentation.Exporter))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "exporter", null, documentation.Exporter);
            }

            if (!string.IsNullOrEmpty(documentation.ExporterID))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "exporterID", null, documentation.ExporterID);
            }

            if (!string.IsNullOrEmpty(documentation.ExporterVersion))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "exporterVersion", null, documentation.ExporterVersion);
            }

            if (documentation.TimeStamp != default)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "timestamp", null, XmlConvert.ToString(documentation.TimeStamp, XmlDateTimeSerializationMode.RoundtripKind));
            }

            foreach (var longDescription in documentation.LongDescription)
            {
                await xmlWriter.WriteElementStringAsync("xmi", "longDescription", this.xmiWriterSettings.XmiNamespaceUri, longDescription);
            }

            foreach (var shortDescription in documentation.ShortDescription)
            {
                await xmlWriter.WriteElementStringAsync("xmi", "shortDescription", this.xmiWriterSettings.XmiNamespaceUri, shortDescription);
            }

            foreach (var notice in documentation.Notice)
            {
                await xmlWriter.WriteElementStringAsync("xmi", "notice", this.xmiWriterSettings.XmiNamespaceUri, notice);
            }

            foreach (var owner in documentation.Owner)
            {
                await xmlWriter.WriteElementStringAsync("xmi", "owner", this.xmiWriterSettings.XmiNamespaceUri, owner);
            }

            await xmlWriter.WriteEndElementAsync();
        }
    }
}
