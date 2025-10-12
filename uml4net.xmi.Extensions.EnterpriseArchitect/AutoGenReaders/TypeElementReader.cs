// -------------------------------------------------------------------------------------------------
// <copyright file="TypeElementReader.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="TypeElementReader"/> is to read an instance of <see cref="ITypeElement"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public partial class TypeElementReader : XmiElementReader<ITypeElement>, IXmiElementReader<ITypeElement>
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<TypeElementReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeElementReader"/> class.
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
        public TypeElementReader(IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, IXmiReaderSettings xmiReaderSettings, INameSpaceResolver nameSpaceResolver, ILoggerFactory loggerFactory)
        : base(cache, xmiElementReaderFacade, xmiReaderSettings, nameSpaceResolver, loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<TypeElementReader>.Instance : loggerFactory.CreateLogger<TypeElementReader>();
        }

        /// <summary>
        /// Reads the <see cref="ITypeElement"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="ITypeElement"/>
        /// </param>
        /// <param name="namespaceUri">
        /// the namespace that the <see cref="ITypeElement"/> belongs to
        /// </param>
        /// <returns>
        /// an instance of <see cref="ITypeElement"/>
        /// </returns>
        public override ITypeElement Read(XmlReader xmlReader, string documentName, string namespaceUri)
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

            ITypeElement poco = new xmi.Extensions.EntrepriseArchitect.Structure.TypeElement();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.logger.LogTrace("reading TypeElement at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

                var xmiType = "TypeElement";

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
                    this.logger.LogCritical("Failed to add element type [{Poco}] with id [{Id}] as it was already in the Cache. The XMI document seems to have duplicate xmi:id values", "TypeElement", poco.XmiId);
                }

                poco.Concurrency = xmlReader.GetAttribute("concurrency") ?? xmlReader.GetAttribute("concurrency", this.NameSpaceResolver.UmlNameSpace);

                var constXmlAttribute = xmlReader.GetAttribute("const") ?? xmlReader.GetAttribute("const", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrEmpty(constXmlAttribute))
                {
                    poco.Const = bool.Parse(constXmlAttribute);
                }

                var isAbstractXmlAttribute = xmlReader.GetAttribute("isAbstract") ?? xmlReader.GetAttribute("isAbstract", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrEmpty(isAbstractXmlAttribute))
                {
                    poco.IsAbstract = bool.Parse(isAbstractXmlAttribute);
                }

                var isQueryXmlAttribute = xmlReader.GetAttribute("isQuery") ?? xmlReader.GetAttribute("isQuery", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrEmpty(isQueryXmlAttribute))
                {
                    poco.IsQuery = bool.Parse(isQueryXmlAttribute);
                }

                var pureXmlAttribute = xmlReader.GetAttribute("pure") ?? xmlReader.GetAttribute("pure", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrEmpty(pureXmlAttribute))
                {
                    poco.Pure = int.Parse(pureXmlAttribute);
                }

                var returnarrayXmlAttribute = xmlReader.GetAttribute("returnarray") ?? xmlReader.GetAttribute("returnarray", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrEmpty(returnarrayXmlAttribute))
                {
                    poco.Returnarray = int.Parse(returnarrayXmlAttribute);
                }

                var staticXmlAttribute = xmlReader.GetAttribute("static") ?? xmlReader.GetAttribute("static", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrEmpty(staticXmlAttribute))
                {
                    poco.Static = bool.Parse(staticXmlAttribute);
                }

                poco.Stereotype = xmlReader.GetAttribute("stereotype") ?? xmlReader.GetAttribute("stereotype", this.NameSpaceResolver.UmlNameSpace);

                var synchronisedXmlAttribute = xmlReader.GetAttribute("synchronised") ?? xmlReader.GetAttribute("synchronised", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrEmpty(synchronisedXmlAttribute))
                {
                    poco.Synchronised = int.Parse(synchronisedXmlAttribute);
                }

                poco.Type = xmlReader.GetAttribute("type") ?? xmlReader.GetAttribute("type", this.NameSpaceResolver.UmlNameSpace);


                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName.LowerCaseFirstLetter())
                        {
                            case "concurrency":
                                poco.Concurrency = xmlReader.ReadElementContentAsString();
                                break;
                            case "const":
                                var constValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(constValue))
                                {
                                    poco.Const = bool.Parse(constValue);
                                }

                                break;
                            case "isAbstract":
                                var isAbstractValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(isAbstractValue))
                                {
                                    poco.IsAbstract = bool.Parse(isAbstractValue);
                                }

                                break;
                            case "isQuery":
                                var isQueryValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(isQueryValue))
                                {
                                    poco.IsQuery = bool.Parse(isQueryValue);
                                }

                                break;
                            case "pure":
                                var pureValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(pureValue))
                                {
                                    poco.Pure = int.Parse(pureValue);
                                }

                                break;
                            case "returnarray":
                                var returnarrayValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(returnarrayValue))
                                {
                                    poco.Returnarray = int.Parse(returnarrayValue);
                                }

                                break;
                            case "static":
                                var staticValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(staticValue))
                                {
                                    poco.Static = bool.Parse(staticValue);
                                }

                                break;
                            case "stereotype":
                                poco.Stereotype = xmlReader.ReadElementContentAsString();
                                break;
                            case "synchronised":
                                var synchronisedValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(synchronisedValue))
                                {
                                    poco.Synchronised = int.Parse(synchronisedValue);
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
                                    throw new NotSupportedException($"TypeElementReader: {xmlReader.LocalName} at line:position {xmlLineInfo.LineNumber}:{xmlLineInfo.LinePosition}");
                                }
                                else
                                {
                                    this.logger.LogWarning("Not Supported: TypeElementReader: {LocalName} at line:position {LineNumber}:{LinePosition}", xmlReader.LocalName, xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);
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
