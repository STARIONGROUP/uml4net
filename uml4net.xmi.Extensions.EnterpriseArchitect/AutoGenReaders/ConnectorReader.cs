// -------------------------------------------------------------------------------------------------
// <copyright file="Reader.cs" company="Starion Group S.A.">
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
    using uml4net.xmi.Extender;
    using uml4net.Extensions;
    using uml4net.xmi.Extensions.EnterpriseArchitect.Structure;
    using uml4net.xmi.Readers;
    using uml4net.xmi.Settings;

    /// <summary>
    /// The purpose of the <see cref="ConnectorReader"/> is to read an instance of <see cref="IConnector"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public partial class ConnectorReader : ExtensionContentReader<IConnector>
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<ConnectorReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectorReader"/> class.
        /// </summary>
        /// <param name="registry">The <see cref="IExtenderReaderRegistry"/> that allow to resolve <see cref="IExtensionContentReaderFacade"/></param>
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
        public ConnectorReader(IExtenderReaderRegistry registry, IXmiReaderSettings xmiReaderSettings, INameSpaceResolver nameSpaceResolver, IXmiElementCache cache, ILoggerFactory loggerFactory)
        : base(registry, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<ConnectorReader>.Instance : loggerFactory.CreateLogger<ConnectorReader>();
        }

        /// <summary>
        /// Reads the <see cref="IConnector"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">The name of the document that is currently read</param>
        /// <returns>
        /// an instance of <see cref="IConnector"/>
        /// </returns>
        public override IConnector Read(XmlReader xmlReader, string documentName)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            var xmlLineInfo = xmlReader as IXmlLineInfo;

            IConnector poco = new xmi.Extensions.EnterpriseArchitect.Structure.Connector();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.logger.LogTrace("reading  at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

                var nameValue = xmlReader.GetAttribute("name");
                poco.Name = nameValue;

                var idRef = xmlReader.GetAttribute("xmi:idref");

                if (!string.IsNullOrWhiteSpace(idRef) && this.Cache.TryGetValue($"{documentName}#{idRef}", out var extendedElement))
                {
                    poco.ExtendedElement = extendedElement;
                    this.Cache.AddExtender(extendedElement, poco);
                }

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            case "appearance":
                                {
                                    poco.Appearance = this.ExtensionContentReaderFacade.QueryExtensionContent<ConnectorAppearance>(xmlReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory);
                                    break;
                                }
                            case "documentation":
                                {
                                    poco.Documentation = this.ExtensionContentReaderFacade.QueryExtensionContent<Documentation>(xmlReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory);
                                    break;
                                }
                            case "extendedProperties":
                                {
                                    poco.ExtendedProperties = this.ExtensionContentReaderFacade.QueryExtensionContent<ConnectorExtendedProperties>(xmlReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory);
                                    break;
                                }
                            case "labels":
                                {
                                    poco.Labels = this.ExtensionContentReaderFacade.QueryExtensionContent<Labels>(xmlReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory);
                                    break;
                                }
                            case "model":
                                {
                                    poco.Model = this.ExtensionContentReaderFacade.QueryExtensionContent<Model>(xmlReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory);
                                    break;
                                }
                            case "modifiers":
                                {
                                    poco.Modifiers = this.ExtensionContentReaderFacade.QueryExtensionContent<Modifiers>(xmlReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory);
                                    break;
                                }
                            case "parameterSubstitutions":
                                {
                                    using var parameterSubstitutionsReader = xmlReader.ReadSubtree();

                                    while (parameterSubstitutionsReader.Read())
                                    {
                                        if (parameterSubstitutionsReader.NodeType != XmlNodeType.Element || parameterSubstitutionsReader.LocalName == "parameterSubstitutions")
                                        {
                                            continue;
                                        }

                                        poco.ParameterSubstitutions.Add(this.ExtensionContentReaderFacade.QueryExtensionContent<ParameterSubstitution>(parameterSubstitutionsReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory));
                                    }

                                    break;
                                }
                            case "properties":
                                {
                                    poco.Properties = this.ExtensionContentReaderFacade.QueryExtensionContent<ConnectorProperties>(xmlReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory);
                                    break;
                                }
                            case "source":
                                {
                                    poco.Source = this.ExtensionContentReaderFacade.QueryExtensionContent<ConnectorEnd>(xmlReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory);
                                    break;
                                }
                            case "style":
                                {
                                    poco.Style = this.ExtensionContentReaderFacade.QueryExtensionContent<Style>(xmlReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory);
                                    break;
                                }
                            case "tags":
                                {
                                    using var tagsReader = xmlReader.ReadSubtree();

                                    while (tagsReader.Read())
                                    {
                                        if (tagsReader.NodeType != XmlNodeType.Element || tagsReader.LocalName == "tags")
                                        {
                                            continue;
                                        }

                                        poco.Tags.Add(this.ExtensionContentReaderFacade.QueryExtensionContent<Tag>(tagsReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory));
                                    }

                                    break;
                                }
                            case "target":
                                {
                                    poco.Target = this.ExtensionContentReaderFacade.QueryExtensionContent<ConnectorEnd>(xmlReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory);
                                    break;
                                }
                            case "xrefs":
                                {
                                    poco.Xrefs = this.ExtensionContentReaderFacade.QueryExtensionContent<Xrefs>(xmlReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory);
                                    break;
                                }
                            default:
                                if (this.XmiReaderSettings.UseStrictReading)
                                {
                                    throw new NotSupportedException($"ConnectorReader: {xmlReader.LocalName} at line:position {xmlLineInfo?.LineNumber}:{xmlLineInfo.LinePosition}");
                                }
                                else
                                {
                                    this.logger.LogWarning("Not Supported: ConnectorReader: {LocalName} at line:position {LineNumber}:{LinePosition}", xmlReader.LocalName, xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);
                                }
                                break;
                        }
                    }
                }
            }

            return poco;
        }

        /// <summary>
        /// Gets the name of the extender value
        /// </summary>
        /// <returns>The extender name</returns>
        protected override string GetExtender()
        {
            return "Enterprise Architect";
        }

        /// <summary>
        /// Gets the identifier of the extender value
        /// </summary>
        /// <returns>The extender id</returns>
        protected override string GetExtenderId()
        {
            return "6.5";
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
