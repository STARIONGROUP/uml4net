// -------------------------------------------------------------------------------------------------
//  <copyright file="TagReader.cs" company="Starion Group S.A.">
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

    using uml4net.Mof.Extension;

    using Xmi;

    /// <summary>
    /// The purpose of the <see cref="TagReader"/> is to read an instance of <see cref="Tag"/>
    /// from the XMI document
    /// </summary>
    public class TagReader
    {
        /// <summary>
        /// The (injected) <see cref="INameSpaceResolver"/> used to resolve a namespace to one of the
        /// <see cref="KnowNamespacePrefixes"/> constants
        /// </summary>
        private readonly INameSpaceResolver nameSpaceResolver;

        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<TagReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TagReader"/> class.
        /// </summary>>
        /// <param name="nameSpaceResolver">
        /// The (injected) <see cref="INameSpaceResolver"/> used to resolve a namespace to one of the
        /// <see cref="KnowNamespacePrefixes"/> constants
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public TagReader(INameSpaceResolver nameSpaceResolver, ILoggerFactory loggerFactory)
        {
            this.nameSpaceResolver = nameSpaceResolver;
            this.logger = loggerFactory == null ? NullLogger<TagReader>.Instance : loggerFactory.CreateLogger<TagReader>();
        }

        /// <summary>
        /// Reads the <see cref="Tag"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="namespaceUri">
        /// the namespace that the <see cref="IXmiElement"/> belongs to
        /// </param>
        /// <returns>
        /// an instance of <see cref="Documentation"/>
        /// </returns>
        public Tag Read(XmlReader xmlReader, string namespaceUri)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            if (string.IsNullOrEmpty(namespaceUri))
            {
                throw new ArgumentException(nameof(namespaceUri));
            }

            var xmlLineInfo = xmlReader as IXmlLineInfo;

            var tag = new Tag();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.logger.LogTrace("reading Tag at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

                var xmiType = xmlReader.GetAttribute("type", this.nameSpaceResolver.XmiNameSpace);

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "mofext:Tag")
                {
                    throw new XmlException($"The XmiType should be 'mofext:Tag' while it is {xmiType}");
                }
                else
                {
                    xmiType = "mofext:Tag";
                }

                if (!string.IsNullOrEmpty(xmlReader.NamespaceURI))
                {
                    namespaceUri = xmlReader.NamespaceURI;
                }

                this.nameSpaceResolver.ResolveAndSetNamespace(namespaceUri);

                tag.XmiType = xmiType;

                tag.XmiId = xmlReader.GetAttribute("id", this.nameSpaceResolver.XmiNameSpace);

                tag.Name = xmlReader.GetAttribute("name") ?? xmlReader.GetAttribute("name", namespaceUri);
                tag.Value = xmlReader.GetAttribute("value") ?? xmlReader.GetAttribute("value", namespaceUri);

                var elementAttributeValue = xmlReader.GetAttribute("element") ?? xmlReader.GetAttribute("element", namespaceUri);
                if (!string.IsNullOrEmpty(elementAttributeValue))
                {
                    tag.Element.AddRange(elementAttributeValue.Split(' '));
                }

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        var activeNamespaceUri = string.IsNullOrEmpty(xmlReader.NamespaceURI) ? namespaceUri : xmlReader.NamespaceURI;

                        var activePrefix = this.nameSpaceResolver.ResolvePrefix(activeNamespaceUri);

                        switch (activePrefix, xmlReader.LocalName)
                        {
                            case (KnowNamespacePrefixes.MofExt, "element"):

                                elementAttributeValue = xmlReader.GetAttribute("idref") ?? xmlReader.GetAttribute("idref", this.nameSpaceResolver.XmiNameSpace);

                                if (!string.IsNullOrEmpty(elementAttributeValue))
                                {
                                    tag.Element.Add(elementAttributeValue);
                                }
                                break;
                        }
                    }
                }
            }

            return tag;
        }
    }
}
