// -------------------------------------------------------------------------------------------------
// <copyright file="ConnectorAppearanceReader.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Extensions.EnterpriseArchitect.Structure.Readers
{
    using System;
    using System.CodeDom.Compiler;
    using System.Linq;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using uml4net;
    using uml4net.Extensions;
    using uml4net.xmi.Extensions.EnterpriseArchitect.Structure;
    using uml4net.xmi.Readers;
    using uml4net.xmi.Settings;

    /// <summary>
    /// The purpose of the <see cref="ConnectorAppearanceReader"/> is to read an instance of <see cref="IConnectorAppearance"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public partial class ConnectorAppearanceReader : ExtensionContentReader<IConnectorAppearance>
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<ConnectorAppearanceReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectorAppearanceReader"/> class.
        /// </summary>
        /// <param name="extensionContentReaderFacade">The <see cref="IExtensionContentReaderFacade"/> that allow other <see cref="ExtensionContentReader{TContent}"/> read capabilities</param>
        /// <param name="xmiReaderSettings">
        /// The <see cref="IXmiReaderSettings"/> used to configure reading
        /// </param>
        /// <param name="nameSpaceResolver">
        /// The (injected) <see cref="INameSpaceResolver"/> used to resolve a namespace to one of the
        /// <see cref="KnowNamespacePrefixes"/>
        /// </param>
        /// <param name="cache">The <see cref="IXmiElementCache"/> that provides cached <see cref="IXmiElement"/> retriveal</param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public ConnectorAppearanceReader(IExtensionContentReaderFacade extensionContentReaderFacade, IXmiReaderSettings xmiReaderSettings, INameSpaceResolver nameSpaceResolver, IXmiElementCache cache, ILoggerFactory loggerFactory)
        : base(extensionContentReaderFacade, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<ConnectorAppearanceReader>.Instance : loggerFactory.CreateLogger<ConnectorAppearanceReader>();
        }

        /// <summary>
        /// Reads the <see cref="IConnectorAppearance"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">The name of the document that is currently read</param>
        /// <returns>
        /// an instance of <see cref="IConnectorAppearance"/>
        /// </returns>
        public override IConnectorAppearance Read(XmlReader xmlReader, string documentName)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            var xmlLineInfo = xmlReader as IXmlLineInfo;

            IConnectorAppearance poco = new xmi.Extensions.EnterpriseArchitect.Structure.ConnectorAppearance();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.logger.LogTrace("reading ConnectorAppearance at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

                var headStyleValue = xmlReader.GetAttribute("headStyle");
                if (!string.IsNullOrWhiteSpace(headStyleValue))
                {
                    poco.HeadStyle = int.Parse(headStyleValue);
                }

                var linecolorValue = xmlReader.GetAttribute("linecolor");
                if (!string.IsNullOrWhiteSpace(linecolorValue))
                {
                    poco.Linecolor = int.Parse(linecolorValue);
                }

                var linemodeValue = xmlReader.GetAttribute("linemode");
                if (!string.IsNullOrWhiteSpace(linemodeValue))
                {
                    poco.Linemode = int.Parse(linemodeValue);
                }

                var lineStyleValue = xmlReader.GetAttribute("lineStyle");
                if (!string.IsNullOrWhiteSpace(lineStyleValue))
                {
                    poco.LineStyle = int.Parse(lineStyleValue);
                }

                var linewidthValue = xmlReader.GetAttribute("linewidth");
                if (!string.IsNullOrWhiteSpace(linewidthValue))
                {
                    poco.Linewidth = int.Parse(linewidthValue);
                }

                var seqnoValue = xmlReader.GetAttribute("seqno");
                if (!string.IsNullOrWhiteSpace(seqnoValue))
                {
                    poco.Seqno = int.Parse(seqnoValue);
                }



                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            default:
                                if (this.XmiReaderSettings.UseStrictReading)
                                {
                                    throw new NotSupportedException($"ConnectorAppearanceReader: {xmlReader.LocalName} at line:position {xmlLineInfo?.LineNumber}:{xmlLineInfo.LinePosition}");
                                }
                                else
                                {
                                    this.logger.LogWarning("Not Supported: ConnectorAppearanceReader: {LocalName} at line:position {LineNumber}:{LinePosition}", xmlReader.LocalName, xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);
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
