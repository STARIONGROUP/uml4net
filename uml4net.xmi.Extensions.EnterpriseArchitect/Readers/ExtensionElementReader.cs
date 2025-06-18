// -------------------------------------------------------------------------------------------------
//  <copyright file="ExtensionElementReader.cs" company="Starion Group S.A.">
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

    using uml4net.CommonStructure;
    using uml4net.xmi.Extensions.EnterpriseArchitect.CommonStructureExtension;
    using uml4net.xmi.Extensions.EnterpriseArchitect.Extensions;
    using uml4net.xmi.Readers;
    using uml4net.xmi.Settings;

    /// <summary>
    /// The <see cref="ExtensionElementReader" /> class reads elements and element node.
    /// </summary>
    public class ExtensionElementReader : XmiElementReader<IExtensionElement>, IXmiElementReader<IExtensionElement>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XmiElementReader{T}" /> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement" />> is stored
        /// </param>
        /// <param name="xmiElementReaderFacade">
        /// The (injected) <see cref="IXmiElementReaderFacade" /> used to resolve any
        /// required <see cref="IXmiElementReader{T}" />
        /// </param>
        /// <param name="xmiReaderSettings">The injected <see cref="IXmiReaderSettings" /> that provides Xmi Reader settings</param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory" /> used to set up logging
        /// </param>
        public ExtensionElementReader(IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, IXmiReaderSettings xmiReaderSettings, ILoggerFactory loggerFactory) : base(cache, xmiElementReaderFacade, xmiReaderSettings, loggerFactory)
        {
        }

        /// <summary>
        /// Reads the <see cref="IExtensionElement" /> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader" />
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
        /// an instance of <see cref="IExtensionElement" />
        /// </returns>
        public override IExtensionElement Read(XmlReader xmlReader, string documentName, string namespaceUri)
        {
            var element = ExtensionElement.InitializeElement<ExtensionElement>(xmlReader, this.Cache, documentName);

            while (xmlReader.Read())
            {
                if (xmlReader.NodeType == XmlNodeType.Element)
                {
                    switch (xmlReader.LocalName)
                    {
                        case "ownedComment":
                            var comment = (IComment)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, xmlReader.NamespaceURI, this.Cache,
                                this.XmiReaderSettings, this.LoggerFactory, "uml:Comment");

                            element.OwnedComment.Add(comment);

                            break;
                        case "properties":
                            using (var propertiesXmlReader = xmlReader.ReadSubtree())
                            {
                                propertiesXmlReader.Read();

                                element.IsSpecification = bool.TryParse(propertiesXmlReader.GetAttribute("isSpecification"), out var isSpecification) && isSpecification;
                                element.SuperType = propertiesXmlReader.GetAttribute("stype");
                                element.Documentation = propertiesXmlReader.GetAttribute("documentation");
                                element.IsAbstract = bool.TryParse(propertiesXmlReader.GetAttribute("isAbstract"), out var isAbstract) && isAbstract;
                                element.Scope = propertiesXmlReader.GetAttribute("scope");
                            }

                            break;
                        case "attributes":
                        {
                            using var attributesReader = xmlReader.ReadSubtree();

                            while (attributesReader.Read())
                            {
                                if (attributesReader.NodeType != XmlNodeType.Element || attributesReader.LocalName != "attribute")
                                {
                                    continue;
                                }

                                using var attributeXmlReader = attributesReader.ReadSubtree();

                                var attributeReader = new AttributeReader(this.Cache, this.XmiElementReaderFacade, this.XmiReaderSettings, this.LoggerFactory);
                                var attributeExtensions = attributeReader.Read(attributeXmlReader, documentName, namespaceUri);
                                element.OwnedElement.Add(attributeExtensions);
                            }

                            break;
                        }
                        case "operations":
                        {
                            using var operationsReader = xmlReader.ReadSubtree();

                            while (operationsReader.Read())
                            {
                                if (operationsReader.NodeType != XmlNodeType.Element || operationsReader.LocalName != "operation")
                                {
                                    continue;
                                }

                                using var operationXmlReader = operationsReader.ReadSubtree();

                                var operationReader = new OperationReader(this.Cache, this.XmiElementReaderFacade, this.XmiReaderSettings, this.LoggerFactory);
                                var operationExtension = operationReader.Read(operationXmlReader, documentName, namespaceUri);
                                element.OwnedElement.Add(operationExtension);
                            }

                            break;
                        }
                        case "tags":
                        {
                            using var tagsReader = xmlReader.ReadSubtree();

                            while (tagsReader.Read())
                            {
                                if (tagsReader.NodeType != XmlNodeType.Element || tagsReader.LocalName != "tag")
                                {
                                    continue;
                                }

                                var tagReader = new TagReader(this.Cache, this.XmiElementReaderFacade, this.XmiReaderSettings, this.LoggerFactory);
                                var tagExtension = tagReader.Read(tagsReader, documentName, namespaceUri);
                                element.Tags.Add(tagExtension);
                            }

                            break;
                        }
                        case "model":
                            this.Logger.LogTrace("ExtensionElementReader: (model){ElementName}", xmlReader.LocalName);
                            break;
                        case "project":
                            this.Logger.LogTrace("ExtensionElementReader: (project){ElementName}", xmlReader.LocalName);
                            break;
                        default:
                            this.Logger.LogTrace("ExtensionElementReader: {ElementName}", xmlReader.LocalName);
                            break;
                    }
                }
            }

            return element;
        }
    }
}
