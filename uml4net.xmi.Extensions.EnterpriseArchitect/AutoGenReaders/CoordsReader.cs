// -------------------------------------------------------------------------------------------------
// <copyright file="CoordsReader.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="CoordsReader"/> is to read an instance of <see cref="ICoords"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public partial class CoordsReader : ExtensionContentReader<ICoords>
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<CoordsReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CoordsReader"/> class.
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
        public CoordsReader(IExtensionContentReaderFacade extensionContentReaderFacade, IXmiReaderSettings xmiReaderSettings, INameSpaceResolver nameSpaceResolver, IXmiElementCache cache, ILoggerFactory loggerFactory)
        : base(extensionContentReaderFacade, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<CoordsReader>.Instance : loggerFactory.CreateLogger<CoordsReader>();
        }

        /// <summary>
        /// Reads the <see cref="ICoords"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">The name of the document that is currently read</param>
        /// <returns>
        /// an instance of <see cref="ICoords"/>
        /// </returns>
        public override ICoords Read(XmlReader xmlReader, string documentName)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            var xmlLineInfo = xmlReader as IXmlLineInfo;

            ICoords poco = new xmi.Extensions.EnterpriseArchitect.Structure.Coords();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.logger.LogTrace("reading Coords at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

                var orderedValue = xmlReader.GetAttribute("ordered");
                if (!string.IsNullOrWhiteSpace(orderedValue))
                {
                    poco.Ordered = int.Parse(orderedValue);
                }

                var scaleValue = xmlReader.GetAttribute("scale");
                if (!string.IsNullOrWhiteSpace(scaleValue))
                {
                    poco.Scale = int.Parse(scaleValue);
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
                                    throw new NotSupportedException($"CoordsReader: {xmlReader.LocalName} at line:position {xmlLineInfo?.LineNumber}:{xmlLineInfo.LinePosition}");
                                }
                                else
                                {
                                    this.logger.LogWarning("Not Supported: CoordsReader: {LocalName} at line:position {LineNumber}:{LinePosition}", xmlReader.LocalName, xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);
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
