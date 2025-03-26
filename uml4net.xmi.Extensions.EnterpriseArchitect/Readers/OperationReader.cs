// -------------------------------------------------------------------------------------------------
//  <copyright file="OperationReader.cs" company="Starion Group S.A.">
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
    /// The <see cref="OperationReader" /> class reads operations and operation nodes.
    /// </summary>
    public class OperationReader: XmiElementReader<IExtensionOperation>, IXmiElementReader<IExtensionOperation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OperationReader"/> class.
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
        public OperationReader(IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, IXmiReaderSettings xmiReaderSettings, ILoggerFactory loggerFactory) : base(cache, xmiElementReaderFacade, xmiReaderSettings, loggerFactory)
        {
        }

        /// <summary>
        /// Reads the <see cref="IExtensionOperation" /> object from its XML representation
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
        /// an instance of <see cref="IExtensionOperation" />
        /// </returns>
        public override IExtensionOperation Read(XmlReader xmlReader, string documentName, string namespaceUri)
        {
            var element = ExtensionElement.InitializeElement<ExtensionOperation>(xmlReader, this.Cache, documentName);

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
                        case "parameters":
                        {
                            using var parametersReader = xmlReader.ReadSubtree();

                            while (parametersReader.Read())
                            {
                                if (parametersReader.NodeType != XmlNodeType.Element || parametersReader.LocalName != "parameter")
                                {
                                    continue;
                                }

                                using var parameterXmlReader = parametersReader.ReadSubtree();

                                var parameterReader = new ParameterReader(this.Cache, this.XmiElementReaderFacade, this.XmiReaderSettings, this.LoggerFactory);
                                var extensionParameter = parameterReader.Read(parameterXmlReader, documentName, namespaceUri);
                                element.OwnedParameters.Add(extensionParameter);
                            }

                            break;
                        }
                        default:
                            this.Logger.LogTrace("OperationReader - Extension: {ElementName}", xmlReader.LocalName);
                            break;
                    }
                }
            }

            return element;
        }
    }
}
