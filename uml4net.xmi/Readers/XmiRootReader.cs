// -------------------------------------------------------------------------------------------------
//  <copyright file="XmiRootReader.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2025 Starion Group S.A.
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
    using uml4net.xmi.Xmi;

    /// <summary>
    /// The purpose of the <see cref="XmiRootReader"/> is to read an instance of <see cref="Documentation"/>
    /// from the XMI document
    /// </summary>
    public class XmiRootReader
    {
        /// <summary>
        /// The (injected) <see cref="IXmiElementCache"/> used cache the <see cref="IXmiElement"/>s
        /// </summary>
        private readonly IXmiElementCache cache;

        /// <summary>
        /// The (injected) <see cref="IXmiElementReaderFacade"/> used to resolve any
        /// required <see cref="IXmiElementReader{T}"/>
        /// </summary>
        private readonly IXmiElementReaderFacade xmiElementReaderFacade;

        /// <summary>
        /// The <see cref="IXmiReaderSettings"/> used to configure reading
        /// </summary>
        private readonly IXmiReaderSettings xmiReaderSettings;

        /// <summary>
        /// The <see cref="ILoggerFactory"/> used to set up logging
        /// </summary>
        private readonly ILoggerFactory loggerFactory;

        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<XmiRootReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiRootReader"/> class.
        /// </summary>>
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
        public XmiRootReader(IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, IXmiReaderSettings xmiReaderSettings, ILoggerFactory loggerFactory)
        {
            this.cache = cache;
            this.xmiElementReaderFacade = xmiElementReaderFacade;
            this.xmiReaderSettings = xmiReaderSettings;
            this.loggerFactory = loggerFactory;
            this.logger = loggerFactory == null ? NullLogger<XmiRootReader>.Instance : loggerFactory.CreateLogger<XmiRootReader>();
        }

        /// <summary>
        /// Reads the <see cref="Documentation"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="IXmiElement"/>
        /// </param>
        /// <param name="namespaceUri">
        /// the namespace that the <see cref="IXmiElement"/> belongs to
        /// </param>
        /// <returns>
        /// an instance of <see cref="Documentation"/>
        /// </returns>
        public XmiRoot Read(XmlReader xmlReader, string documentName, string namespaceUri)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            var xmlLineInfo = xmlReader as IXmlLineInfo;

            var xmiRoot = new XmiRoot();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.logger.LogTrace("reading from XmiRoot at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        var supportedNamespace = XmlNamespaces.QuerySupportedNamespaces(string.IsNullOrEmpty(xmlReader.NamespaceURI) ? namespaceUri : xmlReader.NamespaceURI);

                        switch (supportedNamespace)
                            {
                                case SupportedNamespaces.Xmi:

                                    switch (xmlReader.LocalName)
                                    {
                                        case "extension":
                                        case "Extension":
                                            this.logger.LogInformation("Extensions elements contained in the XmiRoot Element are currently ignored - line:position {Line}:{Position}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);
                                            xmlReader.Skip();
                                            break;
                                        case "difference":
                                        case "Difference":
                                            this.logger.LogInformation("Difference elements contained in the XmiRoot Element are currently ignored - line:position {Line}:{Position}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);
                                            xmlReader.Skip();
                                            break;
                                        case "documentation":
                                        case "Documentation":
                                            using (var subXmlReader = xmlReader.ReadSubtree())
                                            {
                                                var documentationReader = new DocumentationReader(xmiReaderSettings, this.loggerFactory);
                                                var documentation = documentationReader.Read(subXmlReader);
                                                xmiRoot.Documentation = documentation;
                                            }
                                            break;
                                    }

                                    break;
                                case SupportedNamespaces.Uml:
                                    this.logger.LogTrace("reading at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);
                                    var explicitTypeName = $"uml:{xmlReader.LocalName}";
                                    var xmiElement = this.xmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, xmlReader.NamespaceURI, this.cache, this.xmiReaderSettings, this.loggerFactory, explicitTypeName);
                                    xmiRoot.Content.Add(xmiElement);
                                    break;
                                case SupportedNamespaces.UmlStandardProfile:
                                    this.logger.LogWarning("StandardProfile reading is not yet supported, skipping element at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);
                                    xmlReader.Skip();
                                    break;
                                case SupportedNamespaces.UmlDiagramInterchange:
                                    this.logger.LogWarning("DiagramInterchange reading is not yet supported, skipping element at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);
                                    xmlReader.Skip();
                                    break;
                            case SupportedNamespaces.Other:
                                    this.logger.LogWarning("unknown namespaced-element at line:position {LineNumber}:{LinePosition} skipped", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);
                                    xmlReader.Skip();
                                    break;
                            }
                    }
                }

            }

            return xmiRoot;
        }
    }
}
