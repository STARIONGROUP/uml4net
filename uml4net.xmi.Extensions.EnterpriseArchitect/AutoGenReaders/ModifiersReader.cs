// -------------------------------------------------------------------------------------------------
// <copyright file="ModifiersReader.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="ModifiersReader"/> is to read an instance of <see cref="IModifiers"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public partial class ModifiersReader : XmiElementReader<IModifiers>, IXmiElementReader<IModifiers>
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<ModifiersReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModifiersReader"/> class.
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
        /// <param name="nameSpaceResolver">
        /// The (injected) <see cref="INameSpaceResolver"/> used to resolve a namespace to one of the
        /// <see cref="KnowNamespacePrefixes"/>
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public ModifiersReader(IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, IXmiReaderSettings xmiReaderSettings, INameSpaceResolver nameSpaceResolver, ILoggerFactory loggerFactory)
        : base(cache, xmiElementReaderFacade, xmiReaderSettings, nameSpaceResolver, loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<ModifiersReader>.Instance : loggerFactory.CreateLogger<ModifiersReader>();
        }

        /// <summary>
        /// Reads the <see cref="IModifiers"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="IModifiers"/>
        /// </param>
        /// <param name="namespaceUri">
        /// the namespace that the <see cref="IModifiers"/> belongs to
        /// </param>
        /// <returns>
        /// an instance of <see cref="IModifiers"/>
        /// </returns>
        public override IModifiers Read(XmlReader xmlReader, string documentName, string namespaceUri)
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

            IModifiers poco = new xmi.Extensions.EntrepriseArchitect.Structure.Modifiers();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.logger.LogTrace("reading Modifiers at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

                var xmiType = "Modifiers";

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
                    this.logger.LogCritical("Failed to add element type [{Poco}] with id [{Id}] as it was already in the Cache. The XMI document seems to have duplicate xmi:id values", "Modifiers", poco.XmiId);
                }

                poco.Changeable = xmlReader.GetAttribute("changeable") ?? xmlReader.GetAttribute("changeable", this.NameSpaceResolver.UmlNameSpace);

                var isLeafXmlAttribute = xmlReader.GetAttribute("isLeaf") ?? xmlReader.GetAttribute("isLeaf", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrEmpty(isLeafXmlAttribute))
                {
                    poco.IsLeaf = bool.Parse(isLeafXmlAttribute);
                }

                var isNavigableXmlAttribute = xmlReader.GetAttribute("isNavigable") ?? xmlReader.GetAttribute("isNavigable", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrEmpty(isNavigableXmlAttribute))
                {
                    poco.IsNavigable = bool.Parse(isNavigableXmlAttribute);
                }

                var isOrderedXmlAttribute = xmlReader.GetAttribute("isOrdered") ?? xmlReader.GetAttribute("isOrdered", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrEmpty(isOrderedXmlAttribute))
                {
                    poco.IsOrdered = bool.Parse(isOrderedXmlAttribute);
                }

                var isRootXmlAttribute = xmlReader.GetAttribute("isRoot") ?? xmlReader.GetAttribute("isRoot", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrEmpty(isRootXmlAttribute))
                {
                    poco.IsRoot = bool.Parse(isRootXmlAttribute);
                }


                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName.LowerCaseFirstLetter())
                        {
                            case "changeable":
                                poco.Changeable = xmlReader.ReadElementContentAsString();
                                break;
                            case "isLeaf":
                                var isLeafValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(isLeafValue))
                                {
                                    poco.IsLeaf = bool.Parse(isLeafValue);
                                }

                                break;
                            case "isNavigable":
                                var isNavigableValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(isNavigableValue))
                                {
                                    poco.IsNavigable = bool.Parse(isNavigableValue);
                                }

                                break;
                            case "isOrdered":
                                var isOrderedValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(isOrderedValue))
                                {
                                    poco.IsOrdered = bool.Parse(isOrderedValue);
                                }

                                break;
                            case "isRoot":
                                var isRootValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(isRootValue))
                                {
                                    poco.IsRoot = bool.Parse(isRootValue);
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
                                    throw new NotSupportedException($"ModifiersReader: {xmlReader.LocalName} at line:position {xmlLineInfo.LineNumber}:{xmlLineInfo.LinePosition}");
                                }
                                else
                                {
                                    this.logger.LogWarning("Not Supported: ModifiersReader: {LocalName} at line:position {LineNumber}:{LinePosition}", xmlReader.LocalName, xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);
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
