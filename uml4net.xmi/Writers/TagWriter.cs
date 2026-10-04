// -------------------------------------------------------------------------------------------------
// <copyright file="TagWriter.cs" company="Starion Group S.A.">
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
    using System.Linq;
    using System.Threading.Tasks;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using uml4net.Mof.Extension;
    using uml4net.xmi.Settings;

    /// <summary>
    /// The purpose of the <see cref="TagWriter"/> is to write an instance of <see cref="Tag"/> to an XMI document
    /// </summary>
    /// <remarks>
    /// A <see cref="Tag"/> is written as a <c>mofext:Tag</c> element, a sibling of the model content, with its
    /// <c>element</c> references as a space separated attribute, as in the normative OMG documents, which makes it
    /// survive a read - write cycle. The <c>mofext</c> namespace has to be declared by the caller, on the root element.
    /// </remarks>
    public class TagWriter
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<TagWriter> logger;

        /// <summary>
        /// The <see cref="IXmiWriterSettings"/> used to configure writing
        /// </summary>
        private readonly IXmiWriterSettings xmiWriterSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="TagWriter"/> class.
        /// </summary>
        /// <param name="xmiWriterSettings">
        /// The <see cref="IXmiWriterSettings"/> used to configure writing
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public TagWriter(IXmiWriterSettings xmiWriterSettings, ILoggerFactory loggerFactory)
        {
            this.xmiWriterSettings = xmiWriterSettings ?? throw new ArgumentNullException(nameof(xmiWriterSettings));
            this.logger = loggerFactory == null ? NullLogger<TagWriter>.Instance : loggerFactory.CreateLogger<TagWriter>();
        }

        /// <summary>
        /// Writes the <see cref="Tag"/> object to its XML representation
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="tag">
        /// The <see cref="Tag"/> that is to be written
        /// </param>
        public void Write(XmlWriter xmlWriter, Tag tag)
        {
            if (xmlWriter == null)
            {
                throw new ArgumentNullException(nameof(xmlWriter));
            }

            if (tag == null)
            {
                throw new ArgumentNullException(nameof(tag));
            }

            this.logger.LogTrace("writing the Tag {TagName}", tag.Name);

            xmlWriter.WriteStartElement("mofext", "Tag", this.xmiWriterSettings.MofExtNamespaceUri);
            xmlWriter.WriteAttributeString("xmi", "type", this.xmiWriterSettings.XmiNamespaceUri, "mofext:Tag");

            if (!string.IsNullOrEmpty(tag.XmiId))
            {
                xmlWriter.WriteAttributeString("xmi", "id", this.xmiWriterSettings.XmiNamespaceUri, tag.XmiId);
            }

            if (!string.IsNullOrEmpty(tag.XmiUuid))
            {
                xmlWriter.WriteAttributeString("xmi", "uuid", this.xmiWriterSettings.XmiNamespaceUri, tag.XmiUuid);
            }

            if (tag.Name != null)
            {
                xmlWriter.WriteAttributeString("name", tag.Name);
            }

            if (tag.Value != null)
            {
                xmlWriter.WriteAttributeString("value", tag.Value);
            }

            if (tag.Element.Count > 0)
            {
                xmlWriter.WriteAttributeString("element", string.Join(" ", tag.Element));
            }

            xmlWriter.WriteEndElement();
        }

        /// <summary>
        /// Asynchronously writes the <see cref="Tag"/> object to its XML representation
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="tag">
        /// The <see cref="Tag"/> that is to be written
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        public async Task WriteAsync(XmlWriter xmlWriter, Tag tag)
        {
            if (xmlWriter == null)
            {
                throw new ArgumentNullException(nameof(xmlWriter));
            }

            if (tag == null)
            {
                throw new ArgumentNullException(nameof(tag));
            }

            this.logger.LogTrace("writing the Tag {TagName}", tag.Name);

            await xmlWriter.WriteStartElementAsync("mofext", "Tag", this.xmiWriterSettings.MofExtNamespaceUri);
            await xmlWriter.WriteAttributeStringAsync("xmi", "type", this.xmiWriterSettings.XmiNamespaceUri, "mofext:Tag");

            if (!string.IsNullOrEmpty(tag.XmiId))
            {
                await xmlWriter.WriteAttributeStringAsync("xmi", "id", this.xmiWriterSettings.XmiNamespaceUri, tag.XmiId);
            }

            if (!string.IsNullOrEmpty(tag.XmiUuid))
            {
                await xmlWriter.WriteAttributeStringAsync("xmi", "uuid", this.xmiWriterSettings.XmiNamespaceUri, tag.XmiUuid);
            }

            if (tag.Name != null)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "name", null, tag.Name);
            }

            if (tag.Value != null)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "value", null, tag.Value);
            }

            if (tag.Element.Count > 0)
            {
                await xmlWriter.WriteAttributeStringAsync(null, "element", null, string.Join(" ", tag.Element));
            }

            await xmlWriter.WriteEndElementAsync();
        }

        /// <summary>
        /// Writes the <see cref="Tag"/> as Canonical XMI (XMI 2.5.1 Annex B): its <c>name</c>, <c>value</c> and
        /// <c>element</c> properties as XML elements, the elements as <c>xmi:idref</c> links sorted by identifier, then as
        /// <c>href</c> links
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="tag">
        /// The <see cref="Tag"/> that is to be written
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="XmiWriteContext"/> of the Canonical XMI write operation
        /// </param>
        public void WriteCanonical(XmlWriter xmlWriter, Tag tag, XmiWriteContext writeContext)
        {
            if (xmlWriter == null)
            {
                throw new ArgumentNullException(nameof(xmlWriter));
            }

            this.CreateCanonicalElement(tag, writeContext).Write(xmlWriter);

            writeContext.EndCanonicalObject();
        }

        /// <summary>
        /// Asynchronously writes the <see cref="Tag"/> as Canonical XMI (XMI 2.5.1 Annex B), see
        /// <see cref="WriteCanonical"/>
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="tag">
        /// The <see cref="Tag"/> that is to be written
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="XmiWriteContext"/> of the Canonical XMI write operation
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        public async Task WriteCanonicalAsync(XmlWriter xmlWriter, Tag tag, XmiWriteContext writeContext)
        {
            if (xmlWriter == null)
            {
                throw new ArgumentNullException(nameof(xmlWriter));
            }

            await this.CreateCanonicalElement(tag, writeContext).WriteAsync(xmlWriter);

            writeContext.EndCanonicalObject();
        }

        /// <summary>
        /// Creates the <see cref="CanonicalXmlElement"/> of the provided <see cref="Tag"/> and records it in the write context
        /// </summary>
        /// <param name="tag">
        /// The <see cref="Tag"/>
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="XmiWriteContext"/> of the Canonical XMI write operation
        /// </param>
        /// <returns>
        /// The <see cref="CanonicalXmlElement"/>
        /// </returns>
        private CanonicalXmlElement CreateCanonicalElement(Tag tag, XmiWriteContext writeContext)
        {
            if (tag == null)
            {
                throw new ArgumentNullException(nameof(tag));
            }

            if (writeContext == null)
            {
                throw new ArgumentNullException(nameof(writeContext));
            }

            this.logger.LogTrace("writing the Tag {TagName} as Canonical XMI", tag.Name);

            writeContext.BeginCanonicalObject(tag, "mofext:Tag", tag.Name);

            var xmiId = writeContext.QueryXmiId(tag, tag.XmiId);

            var element = new CanonicalXmlElement("mofext", "Tag", this.xmiWriterSettings.MofExtNamespaceUri, this.xmiWriterSettings.XmiNamespaceUri)
            {
                XmiId = xmiId,
                XmiUuid = writeContext.QueryCanonicalXmiUuid(tag.XmiUuid, tag.XmiId ?? tag.Name ?? xmiId)
            };

            if (tag.Name != null)
            {
                element.AddValue("name", tag.Name);
            }

            if (tag.Value != null)
            {
                element.AddValue("value", tag.Value);
            }

            // Annex B.5.3: the links of a property that is not ordered, xmi:idrefs first, each set sorted
            var references = tag.Element.Where(x => !string.IsNullOrEmpty(x)).ToList();

            foreach (var reference in references.Where(x => x.IndexOf('#') <= 0).Select(writeContext.QueryXmiIdByReadIdentifier).OrderBy(x => x, StringComparer.Ordinal))
            {
                element.AddIdRef("element", reference);
            }

            foreach (var reference in references.Where(x => x.IndexOf('#') > 0).OrderBy(x => x, StringComparer.Ordinal))
            {
                element.AddHref("element", reference);
            }

            return element;
        }
    }
}
