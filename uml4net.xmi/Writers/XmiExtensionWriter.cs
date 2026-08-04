// -------------------------------------------------------------------------------------------------
// <copyright file="XmiExtensionWriter.cs" company="Starion Group S.A.">
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

    /// <summary>
    /// The purpose of the <see cref="XmiExtensionWriter"/> is to write an instance of <see cref="XmiExtension"/>
    /// to an XMI document.
    /// </summary>
    /// <remarks>
    /// The content of an <see cref="XmiExtension"/> is tool-vendor specific and is therefore not represented
    /// by the UML 2.5.1 metamodel. It is written verbatim, using the
    /// <see cref="XmiExtension.ContentRawXmi"/> that was captured when the extension was read, which makes
    /// an extension survive a read-write cycle.
    /// </remarks>
    public class XmiExtensionWriter
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<XmiExtensionWriter> logger;

        /// <summary>
        /// The <see cref="IXmiWriterSettings"/> used to configure writing
        /// </summary>
        private readonly IXmiWriterSettings xmiWriterSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiExtensionWriter"/> class.
        /// </summary>
        /// <param name="xmiWriterSettings">
        /// The <see cref="IXmiWriterSettings"/> used to configure writing
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public XmiExtensionWriter(IXmiWriterSettings xmiWriterSettings, ILoggerFactory loggerFactory)
        {
            this.xmiWriterSettings = xmiWriterSettings;
            this.logger = loggerFactory == null ? NullLogger<XmiExtensionWriter>.Instance : loggerFactory.CreateLogger<XmiExtensionWriter>();
        }

        /// <summary>
        /// Writes the <see cref="XmiExtension"/> object to its XML representation
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="extension">
        /// The <see cref="XmiExtension"/> that is to be written
        /// </param>
        public void Write(XmlWriter xmlWriter, XmiExtension extension)
        {
            if (xmlWriter == null)
            {
                throw new ArgumentNullException(nameof(xmlWriter));
            }

            if (extension == null)
            {
                throw new ArgumentNullException(nameof(extension));
            }

            this.logger.LogTrace("writing the XmiExtension of {Extender}:{ExtenderID}", extension.Extender, extension.ExtenderId);

            xmlWriter.WriteStartElement("xmi", "Extension", this.xmiWriterSettings.XmiNamespaceUri);

            if (!string.IsNullOrEmpty(extension.Id))
            {
                xmlWriter.WriteAttributeString("xmi", "id", this.xmiWriterSettings.XmiNamespaceUri, extension.Id);
            }

            if (!string.IsNullOrEmpty(extension.Uuid))
            {
                xmlWriter.WriteAttributeString("xmi", "uuid", this.xmiWriterSettings.XmiNamespaceUri, extension.Uuid);
            }

            if (!string.IsNullOrEmpty(extension.Extender))
            {
                xmlWriter.WriteAttributeString("extender", extension.Extender);
            }

            if (!string.IsNullOrEmpty(extension.ExtenderId))
            {
                xmlWriter.WriteAttributeString("extenderID", extension.ExtenderId);
            }

            if (!string.IsNullOrEmpty(extension.ContentRawXmi))
            {
                // the content is already serialized markup, it is therefore written as raw XML and
                // not as (escaped) text. As a consequence the content is not indented along with the
                // rest of the document.
                xmlWriter.WriteRaw(extension.ContentRawXmi);
            }

            xmlWriter.WriteEndElement();
        }

        /// <summary>
        /// Asynchronously writes the <see cref="XmiExtension"/> object to its XML representation
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="extension">
        /// The <see cref="XmiExtension"/> that is to be written
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        public async Task WriteAsync(XmlWriter xmlWriter, XmiExtension extension)
        {
            if (xmlWriter == null)
            {
                throw new ArgumentNullException(nameof(xmlWriter));
            }

            if (extension == null)
            {
                throw new ArgumentNullException(nameof(extension));
            }

            this.logger.LogTrace("writing the XmiExtension of {Extender}:{ExtenderID}", extension.Extender, extension.ExtenderId);

            await xmlWriter.WriteStartElementAsync("xmi", "Extension", this.xmiWriterSettings.XmiNamespaceUri);

            if (!string.IsNullOrEmpty(extension.Id))
            {
                await xmlWriter.WriteAttributeStringAsync("xmi", "id", this.xmiWriterSettings.XmiNamespaceUri, extension.Id);
            }

            if (!string.IsNullOrEmpty(extension.Uuid))
            {
                await xmlWriter.WriteAttributeStringAsync("xmi", "uuid", this.xmiWriterSettings.XmiNamespaceUri, extension.Uuid);
            }

            if (!string.IsNullOrEmpty(extension.Extender))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "extender", null, extension.Extender);
            }

            if (!string.IsNullOrEmpty(extension.ExtenderId))
            {
                await xmlWriter.WriteAttributeStringAsync(null, "extenderID", null, extension.ExtenderId);
            }

            if (!string.IsNullOrEmpty(extension.ContentRawXmi))
            {
                // the content is already serialized markup, it is therefore written as raw XML and
                // not as (escaped) text. As a consequence the content is not indented along with the
                // rest of the document.
                await xmlWriter.WriteRawAsync(extension.ContentRawXmi);
            }

            await xmlWriter.WriteEndElementAsync();
        }
    }
}
