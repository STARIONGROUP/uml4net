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
    using System.Collections.Generic;
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
    /// The <see cref="Documentation"/> is written as the <c>xmi:documentation</c> element, a
    /// sibling of the model content, which makes it survive a read - write cycle. Within <c>xmi:XMI</c> the
    /// lowercase element name is used; <c>xmi:Documentation</c> may only be used as a root element (XMI 2.5.1
    /// clause 7.5.3). Its fields are written as the unqualified child elements that the Documentation type of the XMI
    /// schema declares, and its extensions as <c>xmi:Extension</c> elements, the element declaration that this content
    /// model refers to. <c>exporterID</c>, which the schema does not declare but Enterprise Architect writes, is kept
    /// as an attribute so that it survives a read - write cycle.
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
            this.loggerFactory = loggerFactory;
            this.logger = loggerFactory == null ? NullLogger<DocumentationWriter>.Instance : loggerFactory.CreateLogger<DocumentationWriter>();
        }

        /// <summary>
        /// The <see cref="ILoggerFactory"/> handed to the <see cref="XmiExtensionWriter"/>
        /// </summary>
        private readonly ILoggerFactory loggerFactory;

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

            xmlWriter.WriteStartElement("xmi", "documentation", this.xmiWriterSettings.XmiNamespaceUri);

            // exporterID is not declared by XMI.xsd; it is written by Enterprise Architect and kept as an attribute so
            // that it survives a read - write cycle
            if (!string.IsNullOrEmpty(documentation.ExporterID))
            {
                xmlWriter.WriteAttributeString("exporterID", documentation.ExporterID);
            }

            // the fields are the local, and therefore unqualified, elements of the Documentation type of XMI.xsd
            foreach (var (name, value) in QueryFieldElements(documentation))
            {
                xmlWriter.WriteElementString(name, value);
            }

            if (documentation.Extensions.Count > 0)
            {
                // the Documentation schema allows Extension elements (XMI 2.5.1 clause 7.5.5)
                var xmiExtensionWriter = new XmiExtensionWriter(this.xmiWriterSettings, this.loggerFactory);

                foreach (var extension in documentation.Extensions)
                {
                    xmiExtensionWriter.Write(xmlWriter, extension, true);
                }
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

            await xmlWriter.WriteStartElementAsync("xmi", "documentation", this.xmiWriterSettings.XmiNamespaceUri);

            // exporterID is not declared by XMI.xsd; it is written by Enterprise Architect and kept as an attribute so
            // that it survives a read - write cycle
            if (!string.IsNullOrEmpty(documentation.ExporterID))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "exporterID", null, documentation.ExporterID);
            }

            // the fields are the local, and therefore unqualified, elements of the Documentation type of XMI.xsd
            foreach (var (name, value) in QueryFieldElements(documentation))
            {
                await xmlWriter.WriteElementStringAsync(null, name, null, value);
            }

            if (documentation.Extensions.Count > 0)
            {
                // the Documentation schema allows Extension elements (XMI 2.5.1 clause 7.5.5)
                var xmiExtensionWriter = new XmiExtensionWriter(this.xmiWriterSettings, this.loggerFactory);

                foreach (var extension in documentation.Extensions)
                {
                    await xmiExtensionWriter.WriteAsync(xmlWriter, extension, true);
                }
            }

            await xmlWriter.WriteEndElementAsync();
        }

        /// <summary>
        /// Queries the fields of the <paramref name="documentation"/> that are written as child elements, in the order
        /// in which the Documentation type of XMI.xsd declares them
        /// </summary>
        /// <param name="documentation">
        /// The <see cref="Documentation"/> that is written
        /// </param>
        /// <returns>
        /// the name and value of each child element; a field without a value is left out
        /// </returns>
        private static IEnumerable<(string Name, string Value)> QueryFieldElements(Documentation documentation)
        {
            if (!string.IsNullOrEmpty(documentation.Contact))
            {
                yield return ("contact", documentation.Contact);
            }

            if (!string.IsNullOrEmpty(documentation.Exporter))
            {
                yield return ("exporter", documentation.Exporter);
            }

            if (!string.IsNullOrEmpty(documentation.ExporterVersion))
            {
                yield return ("exporterVersion", documentation.ExporterVersion);
            }

            foreach (var longDescription in documentation.LongDescription)
            {
                yield return ("longDescription", longDescription);
            }

            foreach (var shortDescription in documentation.ShortDescription)
            {
                yield return ("shortDescription", shortDescription);
            }

            foreach (var notice in documentation.Notice)
            {
                yield return ("notice", notice);
            }

            foreach (var owner in documentation.Owner)
            {
                yield return ("owner", owner);
            }

            if (documentation.TimeStamp != default)
            {
                yield return ("timestamp", XmlConvert.ToString(documentation.TimeStamp, XmlDateTimeSerializationMode.RoundtripKind));
            }
        }
    }
}
