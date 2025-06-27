// -------------------------------------------------------------------------------------------------
// <copyright file="ElementPropertiesReader.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="ElementPropertiesReader"/> is to read an instance of <see cref="IElementProperties"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public partial class ElementPropertiesReader : XmiElementReader<IElementProperties>, IXmiElementReader<IElementProperties>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElementPropertiesReader"/> class.
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
        public ElementPropertiesReader(IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, IXmiReaderSettings xmiReaderSettings, ILoggerFactory loggerFactory)
        : base(cache, xmiElementReaderFacade, xmiReaderSettings, loggerFactory)
        {
        }

        /// <summary>
        /// Reads the <see cref="IElementProperties"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="IElementProperties"/>
        /// </param>
        /// <param name="namespaceUri">
        /// the namespace that the <see cref="IElementProperties"/> belongs to
        /// </param>
        /// <returns>
        /// an instance of <see cref="IElementProperties"/>
        /// </returns>
        public override IElementProperties Read(XmlReader xmlReader, string documentName, string namespaceUri)
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

            IElementProperties poco = new xmi.Extensions.EntrepriseArchitect.Structure.ElementProperties();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = "ElementProperties";


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
                    this.Logger.LogCritical("Failed to add element type [{Poco}] with id [{Id}] as it was already in the Cache. The XMI document seems to have duplicate xmi:id values", "ElementProperties", poco.XmiId);
                }

                poco.Documentation = xmlReader.GetAttribute("documentation");

                var isSpecificationXmlAttribute = xmlReader.GetAttribute("isSpecification");

                if (!string.IsNullOrEmpty(isSpecificationXmlAttribute))
                {
                    poco.IsSpecification = bool.Parse(isSpecificationXmlAttribute);
                }

                var nTypeXmlAttribute = xmlReader.GetAttribute("nType");

                if (!string.IsNullOrEmpty(nTypeXmlAttribute))
                {
                    poco.NType = int.Parse(nTypeXmlAttribute);
                }

                poco.Scope = xmlReader.GetAttribute("scope");

                poco.Stereotype = xmlReader.GetAttribute("stereotype");

                poco.SType = xmlReader.GetAttribute("sType");


                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName.LowerCaseFirstLetter())
                        {
                            case "documentation":
                                poco.Documentation = xmlReader.ReadElementContentAsString();
                                break;
                            case "isSpecification":
                                var isSpecificationValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(isSpecificationValue))
                                {
                                    poco.IsSpecification = bool.Parse(isSpecificationValue);
                                }

                                break;
                            case "nType":
                                var nTypeValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(nTypeValue))
                                {
                                    poco.NType = int.Parse(nTypeValue);
                                }

                                break;
                            case "scope":
                                poco.Scope = xmlReader.ReadElementContentAsString();
                                break;
                            case "stereotype":
                                poco.Stereotype = xmlReader.ReadElementContentAsString();
                                break;
                            case "sType":
                                poco.SType = xmlReader.ReadElementContentAsString();
                                break;
                            default:
                                var couldHandleReadElement = this.HandleManualXmlRead(poco, xmlReader, documentName, namespaceUri);

                                if (couldHandleReadElement)
                                {
                                    break;
                                }

                                if (this.XmiReaderSettings.UseStrictReading)
                                {
                                    throw new NotSupportedException($"ElementPropertiesReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
                                }
                                else
                                {
                                    this.Logger.LogWarning("Not Supported: ElementPropertiesReader: {LocalName} at line:position {LineNumber}:{LinePosition}", xmlReader.LocalName, defaultLineInfo.LineNumber, defaultLineInfo.LinePosition);
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
