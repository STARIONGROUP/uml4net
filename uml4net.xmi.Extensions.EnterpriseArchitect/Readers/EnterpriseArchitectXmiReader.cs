// -------------------------------------------------------------------------------------------------
//  <copyright file="EnterpriseArchitectXmiReader.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Extensions.EnterpriseArchitect.Readers
{
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using uml4net.Packages;
    using uml4net.xmi;
    using uml4net.xmi.Extensions.EnterpriseArchitect.CommonStructureExtension;
    using uml4net.xmi.Readers;
    using uml4net.xmi.ReferenceResolver;
    using uml4net.xmi.Settings;

    /// <summary>
    /// The <see cref="EnterpriseArchitectXmiReader" /> class reads XMI extensions nodes.
    /// </summary>
    public class EnterpriseArchitectXmiReader: XmiReader
    {
        /// <summary>
        /// The (injected) <see cref="ILogger{EnterpriseArchitectXmiReader}"/> used to perform logging
        /// </summary>
        private ILogger<EnterpriseArchitectXmiReader> logger;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="XmiReader"/> class.
        /// </summary>
        /// <param name="assembler">
        /// The (injected) <see cref="IAssembler"/> used to assemble a UML object graph
        /// </param>
        /// <param name="cache">
        /// The (injected) <see cref="IXmiElementCache"/> used to cache all the <see cref="IXmiElement"/>s
        /// </param>
        /// <param name="xmiElementReaderFacade">
        /// The (injected) <see cref="IXmiElementReaderFacade"/> used to resolve any
        /// required <see cref="IXmiElementReader{T}"/>
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        /// <param name="externalReferenceResolver">The <see cref="IExternalReferenceResolver"/></param>
        /// <param name="scope">The <see cref="IXmiReaderScope"/></param>
        /// <param name="xmiReaderSettings">The injected <see cref="IXmiReaderSettings"/> that provides reading setting for XMI</param>
        public EnterpriseArchitectXmiReader(IAssembler assembler, IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, ILoggerFactory loggerFactory,
            IExternalReferenceResolver externalReferenceResolver, IXmiReaderScope scope, IXmiReaderSettings xmiReaderSettings) : base(assembler, cache, xmiElementReaderFacade, loggerFactory, externalReferenceResolver, scope, xmiReaderSettings)
        {
            this.logger = this.LoggerFactory == null ? NullLogger<EnterpriseArchitectXmiReader>.Instance : this.LoggerFactory.CreateLogger<EnterpriseArchitectXmiReader>();
        }

        /// <summary>
        /// Reads an XMI extension from the provided <see cref="XmlReader" /> and returns an instance of
        /// <see cref="IEnterpriseArchitectExtension" /> populated with the extension data.
        /// </summary>
        /// <param name="xmlReader">
        /// The <see cref="XmlReader" /> instance used to parse the XMI data.
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="IXmiElement" />
        /// </param>
        /// <param name="namespaceUri">
        /// The namespaceUri of the parent <see cref="XmlReader" />>.
        /// Since <see cref="XmlReader.ReadSubtree" /> is used extensively the <see cref="XmlReader.NamespaceURI" />
        /// returns the empty string when reading from a subtree, therefore it is passed from the caller
        /// </param>     
        /// <returns>
        /// An instance of <see cref="IPackage" />, specifically an <see cref="IEnterpriseArchitectExtension" />
        /// containing the extension information.
        /// </returns>
        /// <remarks>
        /// The method processes the XML structure for an extension, including its extender attributes
        /// and nested elements, while logging warnings for unrecognized XML nodes.
        /// </remarks>
        public override IPackage ReadXmiExtension(XmlReader xmlReader, string documentName, string namespaceUri)
        {
            IEnterpriseArchitectExtension extension = new EnterpriseArchitectExtension();

            if (xmlReader.MoveToContent() != XmlNodeType.Element)
            {
                return extension;
            }

            extension.Extender = xmlReader.GetAttribute("extender");
            extension.ExtenderId = xmlReader.GetAttribute("extenderID");

            while (xmlReader.Read())
            {
                if (xmlReader.NodeType == XmlNodeType.Element)
                {
                    switch (xmlReader.LocalName)
                    {
                        case "elements":
                        {
                            using var elementsReader = xmlReader.ReadSubtree();

                            while (elementsReader.Read())
                            {
                                if (elementsReader.NodeType != XmlNodeType.Element || elementsReader.LocalName != "element")
                                {
                                    continue;
                                }

                                var extensionElementReader = new ExtensionElementReader(this.Cache, this.XmiElementReaderFacade, this.XmiReaderSettings, this.LoggerFactory);
                                var elementReader = elementsReader.ReadSubtree();
                                
                                extension.Elements.Add(extensionElementReader.Read(elementReader, documentName, namespaceUri));
                            }

                            break;
                        }
                        case "connectors":
                        {
                            using var connectorsXmlReader = xmlReader.ReadSubtree();

                            while (connectorsXmlReader.Read())
                            {
                                if (connectorsXmlReader.NodeType != XmlNodeType.Element || connectorsXmlReader.LocalName != "connector")
                                {
                                    continue;
                                }

                                var connectorReader = new ConnectorReader(this.Cache, this.XmiElementReaderFacade, this.XmiReaderSettings, this.LoggerFactory);
                                var connectorXmlReader = connectorsXmlReader.ReadSubtree();
                                
                                extension.Elements.Add(connectorReader.Read(connectorXmlReader, documentName, namespaceUri));
                            }

                            break;
                        }
                        default:
                            this.logger.LogTrace("EnterpriseArchitectXmiReader: {Name}", xmlReader.LocalName);
                            break;
                    }
                }
            }

            return extension;
        }
    }
}
