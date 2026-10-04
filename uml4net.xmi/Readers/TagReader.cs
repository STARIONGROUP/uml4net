// -------------------------------------------------------------------------------------------------
// <copyright file="TagReader.cs" company="Starion Group S.A.">
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
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using uml4net.Mof.Extension;
    using uml4net.xmi.Settings;

    /// <summary>
    /// The purpose of the <see cref="TagReader"/> is to read an instance of <see cref="Tag"/>
    /// from the XMI document
    /// </summary>
    public class TagReader
    {
        /// <summary>
        /// The (injected) <see cref="INameSpaceResolver"/> used to resolve a namespace to one of the
        /// <see cref="KnowNamespacePrefixes"/> constants
        /// </summary>
        private readonly INameSpaceResolver nameSpaceResolver;

        /// <summary>
        /// The <see cref="IXmiReaderSettings"/> that specify whether an element that is not a Tag is rejected or
        /// skipped; null when the element is to be rejected
        /// </summary>
        private readonly IXmiReaderSettings xmiReaderSettings;

        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<TagReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TagReader"/> class.
        /// </summary>>
        /// <param name="nameSpaceResolver">
        /// The (injected) <see cref="INameSpaceResolver"/> used to resolve a namespace to one of the
        /// <see cref="KnowNamespacePrefixes"/> constants
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public TagReader(INameSpaceResolver nameSpaceResolver, ILoggerFactory loggerFactory)
            : this(nameSpaceResolver, null, loggerFactory)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TagReader"/> class.
        /// </summary>
        /// <param name="nameSpaceResolver">
        /// The (injected) <see cref="INameSpaceResolver"/> used to resolve a namespace to one of the
        /// <see cref="KnowNamespacePrefixes"/> constants
        /// </param>
        /// <param name="xmiReaderSettings">
        /// The <see cref="IXmiReaderSettings"/> that specify whether an element that is not a Tag is rejected
        /// (<see cref="IXmiReaderSettings.UseStrictReading"/>, the default when null) or skipped
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public TagReader(INameSpaceResolver nameSpaceResolver, IXmiReaderSettings xmiReaderSettings, ILoggerFactory loggerFactory)
        {
            this.nameSpaceResolver = nameSpaceResolver;
            this.xmiReaderSettings = xmiReaderSettings;
            this.logger = loggerFactory == null ? NullLogger<TagReader>.Instance : loggerFactory.CreateLogger<TagReader>();
        }

        /// <summary>
        /// Reads the <see cref="Tag"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="namespaceUri">
        /// the namespace that the <see cref="IXmiElement"/> belongs to
        /// </param>
        /// <returns>
        /// an instance of <see cref="Tag"/>; null when the element is not a Tag and reading is not strict
        /// </returns>
        /// <exception cref="XmiReadException">
        /// thrown when the element is not a Tag and <see cref="IXmiReaderSettings.UseStrictReading"/> is set, or no
        /// settings are available
        /// </exception>
        public Tag Read(XmlReader xmlReader, string namespaceUri)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            if (string.IsNullOrEmpty(namespaceUri))
            {
                throw new ArgumentException(nameof(namespaceUri));
            }

            var xmlLineInfo = xmlReader as IXmlLineInfo;

            var tag = new Tag();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.logger.LogTrace("reading Tag at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

                // the prefix of the xmi:type is chosen by the document, e.g. mof:Tag with mof bound to the MOF
                // namespace, it is resolved to the prefix uml4net uses for that namespace (XMI 2.5.1 clause 9.5.2, rule 2g)
                var documentXmiType = xmlReader.GetXmiAttribute("type");
                var xmiType = xmlReader.ResolveQualifiedName(documentXmiType, this.nameSpaceResolver);

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "mofext:Tag")
                {
                    var message = $"The element is not a Tag, its xmi:type is [{documentXmiType}]";
                    var xmiId = xmlReader.GetXmiAttribute("id");
                    var lineNumber = xmlLineInfo?.LineNumber ?? 0;
                    var linePosition = xmlLineInfo?.LinePosition ?? 0;

                    if (this.xmiReaderSettings == null || this.xmiReaderSettings.UseStrictReading)
                    {
                        throw new XmiReadException(message, documentXmiType, xmiId, "type", lineNumber, linePosition);
                    }

                    this.logger.LogError("{Message}: [{XmiId}] at line:position {LineNumber}:{LinePosition}, the element is skipped", message, xmiId, lineNumber, linePosition);

                    return null;
                }

                xmiType = "mofext:Tag";

                if (!string.IsNullOrEmpty(xmlReader.NamespaceURI))
                {
                    namespaceUri = xmlReader.NamespaceURI;
                }

                this.nameSpaceResolver.ResolveAndSetNamespace(namespaceUri);

                tag.XmiType = xmiType;

                tag.XmiId = xmlReader.GetXmiAttribute("id");

                tag.XmiUuid = xmlReader.GetXmiAttribute("uuid");

                tag.Name = xmlReader.GetAttribute("name") ?? xmlReader.GetAttribute("name", namespaceUri);
                tag.Value = xmlReader.GetAttribute("value") ?? xmlReader.GetAttribute("value", namespaceUri);

                var elementAttributeValue = xmlReader.GetAttribute("element") ?? xmlReader.GetAttribute("element", namespaceUri);
                if (!string.IsNullOrEmpty(elementAttributeValue))
                {
                    tag.Element.AddRange(elementAttributeValue.Split(' '));
                }

                // the properties may also be serialized as child elements, as Canonical XMI does (XMI 2.5.1 Annex B.2 rule 5);
                // reading the content of name and value moves the reader past their end tag, hence the explicit loop
                xmlReader.Read();

                while (!xmlReader.EOF)
                {
                    if (xmlReader.NodeType != XmlNodeType.Element)
                    {
                        xmlReader.Read();
                        continue;
                    }

                    var activeNamespaceUri = string.IsNullOrEmpty(xmlReader.NamespaceURI) ? namespaceUri : xmlReader.NamespaceURI;

                    var activePrefix = this.nameSpaceResolver.ResolvePrefix(activeNamespaceUri);

                    switch (activePrefix, xmlReader.LocalName)
                    {
                        case (KnowNamespacePrefixes.MofExt, "element"):

                            elementAttributeValue = xmlReader.GetAttribute("idref")
                                                    ?? xmlReader.GetXmiAttribute("idref")
                                                    ?? xmlReader.GetAttribute("href");

                            if (!string.IsNullOrEmpty(elementAttributeValue))
                            {
                                tag.Element.Add(elementAttributeValue);
                            }

                            xmlReader.Read();
                            break;
                        case (KnowNamespacePrefixes.MofExt, "name"):
                            tag.Name = xmlReader.ReadElementContentAsString();
                            break;
                        case (KnowNamespacePrefixes.MofExt, "value"):
                            tag.Value = xmlReader.ReadElementContentAsString();
                            break;
                        default:
                            xmlReader.Read();
                            break;
                    }
                }
            }

            return tag;
        }
    }
}
