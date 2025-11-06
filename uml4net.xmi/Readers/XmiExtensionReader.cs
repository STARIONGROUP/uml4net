// -------------------------------------------------------------------------------------------------
//  <copyright file="XmiExtensionReader.cs" company="Starion Group S.A.">
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
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;
    using System;
    using System.IO;
    using System.Xml;
    using uml4net.xmi.Extender;
    using uml4net.xmi.Settings;
    using Xmi;

    /// <summary>
    /// The purpose of the <see cref="DocumentationReader"/> is to read an instance of <see cref="Documentation"/>
    /// from the XMI document
    /// </summary>
    public class XmiExtensionReader
    {
        /// <summary>
        /// The <see cref="IXmiReaderSettings"/> used to configure reading
        /// </summary>
        private readonly IXmiReaderSettings xmiReaderSettings;

        /// <summary>
        /// The (injected) <see cref="INameSpaceResolver"/> used to resolve a namespace to one of the
        /// <see cref="KnowNamespacePrefixes"/> constants
        /// </summary>
        private readonly INameSpaceResolver nameSpaceResolver;

        /// <summary>
        /// The injected <see cref="IExtenderReaderRegistry"/> that provides <see cref="IExtenderReader"/> resolve features
        /// </summary>
        private readonly IExtenderReaderRegistry extenderReaderRegistry;

        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<XmiExtensionReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiExtensionReader"/> class.
        /// </summary>>
        /// <param name="xmiReaderSettings">
        /// The <see cref="IXmiReaderSettings"/> used to configure reading
        /// </param>
        /// <param name="nameSpaceResolver">
        /// The (injected) <see cref="INameSpaceResolver"/> used to resolve a namespace to one of the
        /// <see cref="KnowNamespacePrefixes"/> constants
        /// </param>
        /// <param name="extenderReaderRegistry">The injected <see cref="IExtenderReaderRegistry"/> that provides <see cref="IExtenderReader"/> resolve features</param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public XmiExtensionReader(IXmiReaderSettings xmiReaderSettings, INameSpaceResolver nameSpaceResolver, IExtenderReaderRegistry extenderReaderRegistry, ILoggerFactory loggerFactory)
        {
            this.xmiReaderSettings = xmiReaderSettings;
            this.nameSpaceResolver = nameSpaceResolver;
            this.extenderReaderRegistry = extenderReaderRegistry;
            this.logger = loggerFactory == null ? NullLogger<XmiExtensionReader>.Instance : loggerFactory.CreateLogger<XmiExtensionReader>();
        }

        /// <summary>
        /// Reads the <see cref="Documentation"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="XmiExtension"/>
        /// </param>
        /// <param name="namespaceUri">
        /// the namespace that the <see cref="IXmiElement"/> belongs to
        /// </param>
        /// <returns>
        /// an instance of <see cref="Documentation"/>
        /// </returns>
        public XmiExtension Read(XmlReader xmlReader, string documentName, string namespaceUri)
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

            var xmiExtension = new XmiExtension();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.logger.LogTrace("reading XmiExtension at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

                var xmiType = xmlReader.GetAttribute("type", this.nameSpaceResolver.XmiNameSpace);

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "xmi:Extension")
                {
                    throw new XmlException($"The XmiType should be 'xmi:Extension' while it is {xmiType}");
                }
                else
                {
                    xmiType = "xmi:Extension";
                }

                namespaceUri = string.IsNullOrEmpty(xmlReader.NamespaceURI) ? namespaceUri : xmlReader.NamespaceURI;

                xmiExtension.Id = xmlReader.GetAttribute("id", this.nameSpaceResolver.XmiNameSpace);

                xmiExtension.Uuid = xmlReader.GetAttribute("uuid", this.nameSpaceResolver.XmiNameSpace);

                xmiExtension.DocumentName = documentName;

                xmiExtension.Extender = xmlReader.GetAttribute("extender") ?? xmlReader.GetAttribute("extender", namespaceUri);
                xmiExtension.ExtenderId = xmlReader.GetAttribute("extenderID") ?? xmlReader.GetAttribute("extenderID", namespaceUri);

                var extenderReader = this.extenderReaderRegistry.Resolve(xmiExtension.Extender, xmiExtension.ExtenderId);

                if (extenderReader == null)
                {
                    this.logger.LogInformation("The ExtenderReader for {Extender}:{ExtenderID} does not exist, the Extension cannot be processed", xmiExtension.Extender, xmiExtension.ExtenderId);
                    xmlReader.Skip();
                }
                else
                {
                    while (xmlReader.Read())
                    {
                        if (xmlReader.NodeType == XmlNodeType.Element)
                        {
                            using var subtreeReader = xmlReader.ReadSubtree();

                            subtreeReader.Read();

                            var stringWriter = new StringWriter();
                            
                            using (var xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { OmitXmlDeclaration = true }))
                            {
                                xmlWriter.WriteNode(subtreeReader, true);
                            }

                            xmiExtension.ContentRawXmi = stringWriter.ToString();

                            xmiExtension.Content = extenderReader.ReadContent(xmiExtension.ContentRawXmi);
                        }
                    }
                }
            }

            return xmiExtension;
        }
    }
}
