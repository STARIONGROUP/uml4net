// -------------------------------------------------------------------------------------------------
//  <copyright file="ConnectorEndReader.cs" company="Starion Group S.A.">
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

    using uml4net.xmi.Extensions.EnterpriseArchitect.CommonStructureExtension;
    using uml4net.xmi.Readers;
    using uml4net.xmi.Settings;

    /// <summary>
    /// The <see cref="ConnectorEmbeddedElementReader" /> class reads connector source and target element, embedded into a Connector
    /// </summary>
    public class ConnectorEmbeddedElementReader: XmiElementReader<IExtensionConnectorEmbeddedElement>, IXmiElementReader<IExtensionConnectorEmbeddedElement>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XmiElementReader{T}"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="xmiElementReaderFacade">
        /// The (injected) <see cref="IXmiElementReaderFacade"/> used to resolve any
        /// required <see cref="IXmiElementReader{T}"/>
        /// </param>
        /// <param name="xmiReaderSettings">The injected <see cref="IXmiReaderSettings" /> that provides Xmi Reader settings</param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public ConnectorEmbeddedElementReader(IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, IXmiReaderSettings xmiReaderSettings, ILoggerFactory loggerFactory) 
            : base(cache, xmiElementReaderFacade, xmiReaderSettings, loggerFactory)
        {
        }

        /// <summary>
        /// Reads the <see cref="IExtensionConnectorEmbeddedElement" /> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="IXmiElement"/>
        /// </param>
        /// <param name="namespaceUri">
        /// The namespaceUri of the parent <see cref="XmlReader"/>>.
        /// Since <see cref="XmlReader.ReadSubtree"/> is used extensively the <see cref="XmlReader.NamespaceURI"/>
        /// returns the empty string when reading from a subtree, therefore it is passed from the caller
        /// </param>
        /// <returns>
        /// an instance of <see cref="IExtensionConnectorEmbeddedElement" />
        /// </returns>
        public override IExtensionConnectorEmbeddedElement Read(XmlReader xmlReader, string documentName, string namespaceUri)
        {
            var element = new ExtensionConnectorEmbeddedElement();

            if (xmlReader.MoveToContent() != XmlNodeType.Element ||
                xmlReader.GetAttribute("xmi:idref") is not { Length: > 0 } extendedElementId)
            {
                return element;
            }

            // The ExtendedElementId reference the class and not the attribute, we then omit to set the extension. A post-process will be required 
            // to correctly retrieve the documentation for the property
            element.ExtendedElementId = extendedElementId;
            element.XmiType = xmlReader.GetAttribute("xmi:type");
            element.XmiId = $"{element.ExtendedElementId}_extension";

            this.Cache.TryAdd(element);
            
            while (xmlReader.Read())
            {
                if (xmlReader.NodeType == XmlNodeType.Element)
                {
                    switch (xmlReader.LocalName)
                    {
                        case "documentation":
                            using (var documentationReader = xmlReader.ReadSubtree())
                            {
                                documentationReader.Read();
                                element.Documentation = documentationReader.GetAttribute("value");
                            }

                            break;
                      
                        default:
                            this.Logger.LogTrace("ConnectorEmbeddedElement - Extension: {ElementName}", xmlReader.LocalName);
                            break;
                    }
                }
            }

            return element;
        } 
    }
}
