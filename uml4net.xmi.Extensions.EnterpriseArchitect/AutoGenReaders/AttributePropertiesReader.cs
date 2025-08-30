// -------------------------------------------------------------------------------------------------
// <copyright file="AttributePropertiesReader.cs" company="Starion Group S.A.">
//
//    Copyright (C) 2019-2025 Starion Group S.A.
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
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Extensions.EntrepriseArchitect.Structure.Readers
{
    using System;
    using System.CodeDom.Compiler;
    using System.Linq;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using uml4net;
    using uml4net.Extensions;
    using uml4net.xmi.Extensions.EntrepriseArchitect.Structure;
    using uml4net.xmi.Readers;
    using uml4net.xmi.Settings;

    /// <summary>
    /// The purpose of the <see cref="AttributePropertiesReader"/> is to read an instance of <see cref="IAttributeProperties"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public partial class AttributePropertiesReader : XmiElementReader<IAttributeProperties>, IXmiElementReader<IAttributeProperties>
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<AttributePropertiesReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributePropertiesReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The (injected) <see cref="IXmiElementCache"/>> in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="xmiElementReaderFacade">
        /// The (injected) <see cref="IXmiElementReaderFacade"/> used to resolve any
        /// required <see cref="IXmiElementReader{T}"/>
        /// </param>
        /// <param name="xmiReaderSettings">
        /// The <see cref="IXmiReaderSettings"/> used to configure reading
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public AttributePropertiesReader(IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, IXmiReaderSettings xmiReaderSettings, ILoggerFactory loggerFactory)
        : base(cache, xmiElementReaderFacade, xmiReaderSettings, loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<AttributePropertiesReader>.Instance : loggerFactory.CreateLogger<AttributePropertiesReader>();
        }

        /// <summary>
        /// Reads the <see cref="IAttributeProperties"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="IAttributeProperties"/>
        /// </param>
        /// <param name="namespaceUri">
        /// the namespace that the <see cref="IAttributeProperties"/> belongs to
        /// </param>
        /// <returns>
        /// an instance of <see cref="IAttributeProperties"/>
        /// </returns>
        public override IAttributeProperties Read(XmlReader xmlReader, string documentName, string namespaceUri)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            if (string.IsNullOrEmpty(documentName))
            {
                throw new ArgumentException(nameof(documentName));
            }

            if (string.IsNullOrEmpty(namespaceUri))
            {
                throw new ArgumentException(nameof(namespaceUri));
            }

            var xmlLineInfo = xmlReader as IXmlLineInfo;

            IAttributeProperties poco = new xmi.Extensions.EntrepriseArchitect.Structure.AttributeProperties();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.logger.LogTrace("reading AttributeProperties at line:position {LineNumber}:{LinePosition}", xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);

                var xmiType = "AttributeProperties";

                if (!string.IsNullOrEmpty(xmlReader.NamespaceURI))
                {
                    namespaceUri = xmlReader.NamespaceURI;
                }

                poco.XmiType = xmiType;

                var idRef = xmlReader.GetAttribute("xmi:idref");
                poco.XmiId = $"Extension-{(string.IsNullOrEmpty(idRef) ? Guid.NewGuid() : idRef)}";

                if (!string.IsNullOrEmpty(idRef))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("extendedElement", $"{documentName}#{idRef}");
                }

                poco.XmiGuid = Guid.NewGuid().ToString();

                poco.DocumentName = documentName;

                poco.XmiNamespaceUri = namespaceUri;

                if (!this.Cache.TryAdd(poco))
                {
                    this.logger.LogCritical("Failed to add element type [{Poco}] with id [{Id}] as it was already in the Cache. The XMI document seems to have duplicate xmi:id values", "AttributeProperties", poco.XmiId);
                }

                poco.Changeability = xmlReader.GetAttribute("changeability");

                var collectionXmlAttribute = xmlReader.GetAttribute("collection");

                if (!string.IsNullOrEmpty(collectionXmlAttribute))
                {
                    poco.Collection = bool.Parse(collectionXmlAttribute);
                }

                var derivedXmlAttribute = xmlReader.GetAttribute("derived");

                if (!string.IsNullOrEmpty(derivedXmlAttribute))
                {
                    poco.Derived = int.Parse(derivedXmlAttribute);
                }

                var duplicatesXmlAttribute = xmlReader.GetAttribute("duplicates");

                if (!string.IsNullOrEmpty(duplicatesXmlAttribute))
                {
                    poco.Duplicates = int.Parse(duplicatesXmlAttribute);
                }

                var lengthXmlAttribute = xmlReader.GetAttribute("length");

                if (!string.IsNullOrEmpty(lengthXmlAttribute))
                {
                    poco.Length = int.Parse(lengthXmlAttribute);
                }

                var precisionXmlAttribute = xmlReader.GetAttribute("precision");

                if (!string.IsNullOrEmpty(precisionXmlAttribute))
                {
                    poco.Precision = int.Parse(precisionXmlAttribute);
                }

                var staticXmlAttribute = xmlReader.GetAttribute("static");

                if (!string.IsNullOrEmpty(staticXmlAttribute))
                {
                    poco.Static = int.Parse(staticXmlAttribute);
                }

                poco.Type = xmlReader.GetAttribute("type");


                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName.LowerCaseFirstLetter())
                        {
                            case "changeability":
                                poco.Changeability = xmlReader.ReadElementContentAsString();
                                break;
                            case "collection":
                                var collectionValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(collectionValue))
                                {
                                    poco.Collection = bool.Parse(collectionValue);
                                }

                                break;
                            case "derived":
                                var derivedValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(derivedValue))
                                {
                                    poco.Derived = int.Parse(derivedValue);
                                }

                                break;
                            case "duplicates":
                                var duplicatesValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(duplicatesValue))
                                {
                                    poco.Duplicates = int.Parse(duplicatesValue);
                                }

                                break;
                            case "length":
                                var lengthValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(lengthValue))
                                {
                                    poco.Length = int.Parse(lengthValue);
                                }

                                break;
                            case "precision":
                                var precisionValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(precisionValue))
                                {
                                    poco.Precision = int.Parse(precisionValue);
                                }

                                break;
                            case "static":
                                var staticValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(staticValue))
                                {
                                    poco.Static = int.Parse(staticValue);
                                }

                                break;
                            case "type":
                                poco.Type = xmlReader.ReadElementContentAsString();
                                break;
                            default:
                                var couldHandleReadElement = this.HandleManualXmlRead(poco, xmlReader, documentName, namespaceUri);

                                if (couldHandleReadElement)
                                {
                                    break;
                                }

                                if (this.XmiReaderSettings.UseStrictReading)
                                {
                                    throw new NotSupportedException($"AttributePropertiesReader: {xmlReader.LocalName} at line:position {xmlLineInfo.LineNumber}:{xmlLineInfo.LinePosition}");
                                }
                                else
                                {
                                    this.logger.LogWarning("Not Supported: AttributePropertiesReader: {LocalName} at line:position {LineNumber}:{LinePosition}", xmlReader.LocalName, xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);
                                }

                                break;
                        }
                    }
                }
            }

            return poco;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
