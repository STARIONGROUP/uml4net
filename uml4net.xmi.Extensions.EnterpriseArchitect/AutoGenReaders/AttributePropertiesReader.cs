// -------------------------------------------------------------------------------------------------
// <copyright file="AttributePropertiesReader.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="AttributePropertiesReader"/> is to read an instance of <see cref="IAttributeProperties"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public partial class AttributePropertiesReader : ExtensionContentReader<IAttributeProperties>
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<AttributePropertiesReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributePropertiesReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The (injected) <see cref="IXmiElementCache"/>> in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="extensionContentReaderFacade">
        /// The (injected) <see cref="IExtensionContentReaderFacade"/> used to resolve any
        /// required <see cref="IExtensionContentReader{T}"/>
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
        public AttributePropertiesReader(IXmiElementCache cache, IExtensionContentReaderFacade extensionContentReaderFacade, IXmiReaderSettings xmiReaderSettings, INameSpaceResolver nameSpaceResolver, ILoggerFactory loggerFactory)
        : base(cache, extensionContentReaderFacade, xmiReaderSettings, nameSpaceResolver, loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<AttributePropertiesReader>.Instance : loggerFactory.CreateLogger<AttributePropertiesReader>();
        }

        /// <summary>
        /// Reads the <see cref="IAttributeProperties"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="IAttributeProperties"/>
        /// </param>
        /// <param name="namespaceUri">
        /// the namespace that the <see cref="IAttributeProperties"/> belongs to
        /// </param>
        /// <returns>
        /// an instance of <see cref="IAttributeProperties"/>
        /// </returns>
        public override IAttributeProperties Read(XmlReader xmlReader, string documentName, string namespaceUri)
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

            IAttributeProperties poco = new xmi.Extensions.EntrepriseArchitect.Structure.AttributeProperties();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.logger.LogTrace("reading AttributeProperties at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

                var xmiType = "Extension - AttributeProperties";

                if (!string.IsNullOrEmpty(xmlReader.NamespaceURI))
                {
                    namespaceUri = xmlReader.NamespaceURI;
                }

            }

            return poco;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
