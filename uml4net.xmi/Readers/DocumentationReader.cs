// -------------------------------------------------------------------------------------------------
//  <copyright file="DocumentationReader.cs" company="Starion Group S.A.">
// 
//    Copyright (C) 2019-2026 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
//  </copyright>
//  ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Readers
{
    using System;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using uml4net.xmi.Settings;

    using Xmi;

    /// <summary>
    /// The purpose of the <see cref="DocumentationReader"/> is to read an instance of <see cref="Documentation"/>
    /// from the XMI document
    /// </summary>
    public class DocumentationReader
    {
        /// <summary>
        /// The <see cref="IXmiReaderSettings"/> used to configure reading
        /// </summary>
        private readonly IXmiReaderSettings xmiReaderSettings;

        /// <summary>
        /// The (injected) <see cref="INameSpaceResolver"/> used to resolve a namespace to one of the
        /// <see cref="KnowNamespacePrefixes"/> constants
        /// </summary>
        private readonly INameSpaceResolver nameSpaceResolver;

        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<DocumentationReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentationReader"/> class.
        /// </summary>>
        /// <param name="xmiReaderSettings">
        /// The <see cref="IXmiReaderSettings"/> used to configure reading
        /// </param>
        /// <param name="nameSpaceResolver">
        /// The (injected) <see cref="INameSpaceResolver"/> used to resolve a namespace to one of the
        /// <see cref="KnowNamespacePrefixes"/> constants
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public DocumentationReader(IXmiReaderSettings xmiReaderSettings, INameSpaceResolver nameSpaceResolver, ILoggerFactory loggerFactory)
        {
            this.xmiReaderSettings = xmiReaderSettings;
            this.nameSpaceResolver = nameSpaceResolver;
            this.logger = loggerFactory == null ? NullLogger<DocumentationReader>.Instance : loggerFactory.CreateLogger<DocumentationReader>();
        }

        /// <summary>
        /// Reads the <see cref="Documentation"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="namespaceUri">
        /// the namespace that the <see cref="IXmiElement"/> belongs to
        /// </param>
        /// <returns>
        /// an instance of <see cref="Documentation"/>
        /// </returns>
        public Documentation Read(XmlReader xmlReader, string namespaceUri)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            var xmlLineInfo = xmlReader as IXmlLineInfo;

            var documentation = new Documentation();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.logger.LogTrace("reading Documentation at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

                namespaceUri = string.IsNullOrEmpty(xmlReader.NamespaceURI) ? namespaceUri : xmlReader.NamespaceURI;

                documentation.Contact = xmlReader.GetAttribute("contact") ?? xmlReader.GetAttribute("contact", namespaceUri);
                documentation.Exporter = xmlReader.GetAttribute("exporter") ?? xmlReader.GetAttribute("exporter", namespaceUri);
                documentation.ExporterID = xmlReader.GetAttribute("exporterID") ?? xmlReader.GetAttribute("exporterID", namespaceUri);
                documentation.ExporterVersion = xmlReader.GetAttribute("exporterVersion") ?? xmlReader.GetAttribute("exporterVersion", namespaceUri);

                var longDescriptionAttributeValue = xmlReader.GetAttribute("longDescription") ?? xmlReader.GetAttribute("longDescription", namespaceUri);
                if (!string.IsNullOrEmpty(longDescriptionAttributeValue))
                {
                    documentation.LongDescription.Add(longDescriptionAttributeValue);
                }

                var shortDescriptionAttributeValue = xmlReader.GetAttribute("shortDescription") ?? xmlReader.GetAttribute("shortDescription", namespaceUri);
                if (!string.IsNullOrEmpty(shortDescriptionAttributeValue))
                {
                    documentation.ShortDescription.Add(shortDescriptionAttributeValue);
                }

                var noticeAttributeValue = xmlReader.GetAttribute("notice") ?? xmlReader.GetAttribute("notice", namespaceUri);
                if (!string.IsNullOrEmpty(noticeAttributeValue))
                {
                    documentation.Notice.Add(noticeAttributeValue);
                }

                var ownerAttributeValue = xmlReader.GetAttribute("owner") ?? xmlReader.GetAttribute("owner", namespaceUri);
                if (!string.IsNullOrEmpty(ownerAttributeValue))
                {
                    documentation.Owner.Add(ownerAttributeValue);
                }

                var timestampAttributeValue = xmlReader.GetAttribute("timestamp") ?? xmlReader.GetAttribute("timestamp", namespaceUri);
                if (!string.IsNullOrEmpty(timestampAttributeValue))
                {
                    try
                    {
                        documentation.TimeStamp = XmlConvert.ToDateTime(timestampAttributeValue, XmlDateTimeSerializationMode.RoundtripKind);
                    }
                    catch (FormatException formatException)
                    {
                        documentation.TimeStamp = DateTime.MinValue;

                        this.logger.LogWarning(formatException,"The Documentation Timestamp value could not be converted: {TimeStampValue}", timestampAttributeValue);
                    }
                }

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        var activeNamespaceUri = string.IsNullOrEmpty(xmlReader.NamespaceURI) ? namespaceUri : xmlReader.NamespaceURI;

                        var activePrefix = this.nameSpaceResolver.ResolvePrefix(activeNamespaceUri);

                        switch (activePrefix, xmlReader.LocalName)
                        {
                            case (KnowNamespacePrefixes.Xmi, "Extension"):
                                this.logger.LogInformation("Extensions in the Documentation Element are currently ignored - line:position {Line}:{Position}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);
                                xmlReader.Skip();
                                break;

                            case (KnowNamespacePrefixes.Xmi, "contact"):
                                var contactElementValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(contactElementValue))
                                {
                                    documentation.Contact = contactElementValue;
                                }
                                break;
                            case (KnowNamespacePrefixes.Xmi, "exporter"):
                                var exporterElementValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(exporterElementValue))
                                {
                                    documentation.Exporter = exporterElementValue;
                                }
                                break;
                            case (KnowNamespacePrefixes.Xmi, "exporterID"):
                                var exporterIDElementValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(exporterIDElementValue))
                                {
                                    documentation.ExporterID = exporterIDElementValue;
                                }
                                break;
                            case (KnowNamespacePrefixes.Xmi, "exporterVersion"):
                                var exporterVersionElementValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(exporterVersionElementValue))
                                {
                                    documentation.ExporterVersion = exporterVersionElementValue;
                                }
                                break;
                            case (KnowNamespacePrefixes.Xmi, "longDescription"):
                                var longDescriptionElementValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(longDescriptionElementValue))
                                {
                                    documentation.LongDescription.Add(longDescriptionElementValue);
                                }
                                break;
                            case (KnowNamespacePrefixes.Xmi, "shortDescription"):
                                var shortDescriptionElementValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(shortDescriptionElementValue))
                                {
                                    documentation.ShortDescription.Add(shortDescriptionElementValue);
                                }
                                break;
                            case (KnowNamespacePrefixes.Xmi, "notice"):
                                var noticeElementValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(noticeElementValue))
                                {
                                    documentation.Notice.Add(noticeElementValue);
                                }
                                break;
                            case (KnowNamespacePrefixes.Xmi, "owner"):
                                var ownerElementValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(ownerElementValue))
                                {
                                    documentation.Owner.Add(ownerElementValue);
                                }
                                break;
                            case (KnowNamespacePrefixes.Xmi, "timestamp"):
                                var timestampElementValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(timestampElementValue))
                                {
                                    try
                                    {
                                        documentation.TimeStamp = XmlConvert.ToDateTime(timestampElementValue, XmlDateTimeSerializationMode.RoundtripKind);
                                    }
                                    catch (FormatException formatException)
                                    {
                                        documentation.TimeStamp = DateTime.MinValue;

                                        this.logger.LogWarning(formatException,"The Documentation Timestamp value could not be converted: {TimeStampValue}", timestampElementValue);
                                    }
                                }
                                break;
                            default:
                                if (this.xmiReaderSettings.UseStrictReading)
                                {
                                    throw new NotSupportedException($"DocumentationReader: {xmlReader.LocalName} at line:position {xmlLineInfo?.LineNumber}:{xmlLineInfo?.LinePosition}");
                                }
                                else
                                {
                                    this.logger.LogWarning("Not Supported: DocumentationReader: {LocalName} at line:position {LineNumber}:{LinePosition}", xmlReader.LocalName, xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);
                                }

                                break;
                        }
                    }
                }
            }

            return documentation;
        }
    }
}
