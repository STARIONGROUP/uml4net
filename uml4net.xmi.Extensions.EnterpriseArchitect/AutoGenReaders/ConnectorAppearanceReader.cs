// -------------------------------------------------------------------------------------------------
// <copyright file="ConnectorAppearanceReader.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2025 Starion Group S.A.
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

    using uml4net;
    using uml4net.Extensions;
    using uml4net.xmi.Extensions.EntrepriseArchitect.Structure;
    using uml4net.xmi.Readers;
    using uml4net.xmi.Settings;

    /// <summary>
    /// The purpose of the <see cref="ConnectorAppearanceReader"/> is to read an instance of <see cref="IConnectorAppearance"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public partial class ConnectorAppearanceReader : XmiElementReader<IConnectorAppearance>, IXmiElementReader<IConnectorAppearance>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectorAppearanceReader"/> class.
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
        public ConnectorAppearanceReader(IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, IXmiReaderSettings xmiReaderSettings, ILoggerFactory loggerFactory)
        : base(cache, xmiElementReaderFacade, xmiReaderSettings, loggerFactory)
        {
        }

        /// <summary>
        /// Reads the <see cref="IConnectorAppearance"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="IConnectorAppearance"/>
        /// </param>
        /// <param name="namespaceUri">
        /// the namespace that the <see cref="IConnectorAppearance"/> belongs to
        /// </param>
        /// <returns>
        /// an instance of <see cref="IConnectorAppearance"/>
        /// </returns>
        public override IConnectorAppearance Read(XmlReader xmlReader, string documentName, string namespaceUri)
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

            var defaultLineInfo = xmlReader as IXmlLineInfo;

            IConnectorAppearance poco = new xmi.Extensions.EntrepriseArchitect.Structure.ConnectorAppearance();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = "ConnectorAppearance";


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
                    this.Logger.LogCritical("Failed to add element type [{Poco}] with id [{Id}] as it was already in the Cache. The XMI document seems to have duplicate xmi:id values", "ConnectorAppearance", poco.XmiId);
                }

                var headStyleXmlAttribute = xmlReader.GetAttribute("headStyle");

                if (!string.IsNullOrEmpty(headStyleXmlAttribute))
                {
                    poco.HeadStyle = int.Parse(headStyleXmlAttribute);
                }

                var linecolorXmlAttribute = xmlReader.GetAttribute("linecolor");

                if (!string.IsNullOrEmpty(linecolorXmlAttribute))
                {
                    poco.Linecolor = int.Parse(linecolorXmlAttribute);
                }

                var linemodeXmlAttribute = xmlReader.GetAttribute("linemode");

                if (!string.IsNullOrEmpty(linemodeXmlAttribute))
                {
                    poco.Linemode = int.Parse(linemodeXmlAttribute);
                }

                var lineStyleXmlAttribute = xmlReader.GetAttribute("lineStyle");

                if (!string.IsNullOrEmpty(lineStyleXmlAttribute))
                {
                    poco.LineStyle = int.Parse(lineStyleXmlAttribute);
                }

                var linewidthXmlAttribute = xmlReader.GetAttribute("linewidth");

                if (!string.IsNullOrEmpty(linewidthXmlAttribute))
                {
                    poco.Linewidth = int.Parse(linewidthXmlAttribute);
                }

                var seqnoXmlAttribute = xmlReader.GetAttribute("seqno");

                if (!string.IsNullOrEmpty(seqnoXmlAttribute))
                {
                    poco.Seqno = int.Parse(seqnoXmlAttribute);
                }


                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName.LowerCaseFirstLetter())
                        {
                            case "headStyle":
                                var headStyleValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(headStyleValue))
                                {
                                    poco.HeadStyle = int.Parse(headStyleValue);
                                }

                                break;
                            case "linecolor":
                                var linecolorValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(linecolorValue))
                                {
                                    poco.Linecolor = int.Parse(linecolorValue);
                                }

                                break;
                            case "linemode":
                                var linemodeValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(linemodeValue))
                                {
                                    poco.Linemode = int.Parse(linemodeValue);
                                }

                                break;
                            case "lineStyle":
                                var lineStyleValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(lineStyleValue))
                                {
                                    poco.LineStyle = int.Parse(lineStyleValue);
                                }

                                break;
                            case "linewidth":
                                var linewidthValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(linewidthValue))
                                {
                                    poco.Linewidth = int.Parse(linewidthValue);
                                }

                                break;
                            case "seqno":
                                var seqnoValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(seqnoValue))
                                {
                                    poco.Seqno = int.Parse(seqnoValue);
                                }

                                break;
                            default:
                                var couldHandleReadElement = this.HandleManualXmlRead(poco, xmlReader, documentName, namespaceUri);

                                if (couldHandleReadElement)
                                {
                                    break;
                                }

                                if (this.XmiReaderSettings.UseStrictReading)
                                {
                                    throw new NotSupportedException($"ConnectorAppearanceReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
                                }
                                else
                                {
                                    this.Logger.LogWarning("Not Supported: ConnectorAppearanceReader: {LocalName} at line:position {LineNumber}:{LinePosition}", xmlReader.LocalName, defaultLineInfo.LineNumber, defaultLineInfo.LinePosition);
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
