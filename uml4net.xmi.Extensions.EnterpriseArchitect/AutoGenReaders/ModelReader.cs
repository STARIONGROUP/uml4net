// -------------------------------------------------------------------------------------------------
// <copyright file="ModelReader.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="ModelReader"/> is to read an instance of <see cref="IModel"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public partial class ModelReader : XmiElementReader<IModel>, IXmiElementReader<IModel>
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<ModelReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelReader"/> class.
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
        public ModelReader(IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, IXmiReaderSettings xmiReaderSettings, INameSpaceResolver nameSpaceResolver, ILoggerFactory loggerFactory)
        : base(cache, xmiElementReaderFacade, xmiReaderSettings, nameSpaceResolver, loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<ModelReader>.Instance : loggerFactory.CreateLogger<ModelReader>();
        }

        /// <summary>
        /// Reads the <see cref="IModel"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="IModel"/>
        /// </param>
        /// <param name="namespaceUri">
        /// the namespace that the <see cref="IModel"/> belongs to
        /// </param>
        /// <returns>
        /// an instance of <see cref="IModel"/>
        /// </returns>
        public override IModel Read(XmlReader xmlReader, string documentName, string namespaceUri)
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

            IModel poco = new xmi.Extensions.EntrepriseArchitect.Structure.Model();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.logger.LogTrace("reading Model at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

                var xmiType = "Model";

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
                    this.logger.LogCritical("Failed to add element type [{Poco}] with id [{Id}] as it was already in the Cache. The XMI document seems to have duplicate xmi:id values", "Model", poco.XmiId);
                }

                poco.Ea_eleType = xmlReader.GetAttribute("ea_eleType") ?? xmlReader.GetAttribute("ea_eleType", this.NameSpaceResolver.UmlNameSpace);

                poco.Ea_guid = xmlReader.GetAttribute("ea_guid") ?? xmlReader.GetAttribute("ea_guid", this.NameSpaceResolver.UmlNameSpace);

                var ea_localidXmlAttribute = xmlReader.GetAttribute("ea_localid") ?? xmlReader.GetAttribute("ea_localid", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(ea_localidXmlAttribute))
                {
                    poco.Ea_localid = int.Parse(ea_localidXmlAttribute);
                }

                poco.Name = xmlReader.GetAttribute("name") ?? xmlReader.GetAttribute("name", this.NameSpaceResolver.UmlNameSpace);

                poco.Package = xmlReader.GetAttribute("package") ?? xmlReader.GetAttribute("package", this.NameSpaceResolver.UmlNameSpace);

                poco.Package2 = xmlReader.GetAttribute("package2") ?? xmlReader.GetAttribute("package2", this.NameSpaceResolver.UmlNameSpace);

                var tposXmlAttribute = xmlReader.GetAttribute("tpos") ?? xmlReader.GetAttribute("tpos", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(tposXmlAttribute))
                {
                    poco.Tpos = int.Parse(tposXmlAttribute);
                }

                poco.Type = xmlReader.GetAttribute("type") ?? xmlReader.GetAttribute("type", this.NameSpaceResolver.UmlNameSpace);


                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName.LowerCaseFirstLetter())
                        {
                            case "ea_eleType":
                                poco.Ea_eleType = xmlReader.ReadElementContentAsString();
                                break;
                            case "ea_guid":
                                poco.Ea_guid = xmlReader.ReadElementContentAsString();
                                break;
                            case "ea_localid":
                                var ea_localidValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrWhiteSpace(ea_localidValue))
                                {
                                    poco.Ea_localid = int.Parse(ea_localidValue);
                                }

                                break;
                            case "name":
                                poco.Name = xmlReader.ReadElementContentAsString();
                                break;
                            case "package":
                                poco.Package = xmlReader.ReadElementContentAsString();
                                break;
                            case "package2":
                                poco.Package2 = xmlReader.ReadElementContentAsString();
                                break;
                            case "tpos":
                                var tposValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrWhiteSpace(tposValue))
                                {
                                    poco.Tpos = int.Parse(tposValue);
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
                                    throw new NotSupportedException($"ModelReader: {xmlReader.LocalName} at line:position {xmlLineInfo.LineNumber}:{xmlLineInfo.LinePosition}");
                                }
                                else
                                {
                                    this.logger.LogWarning("Not Supported: ModelReader: {LocalName} at line:position {LineNumber}:{LinePosition}", xmlReader.LocalName, xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);
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
