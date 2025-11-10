// -------------------------------------------------------------------------------------------------
// <copyright file="AttributeReader.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="AttributeReader"/> is to read an instance of <see cref="IAttribute"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public partial class AttributeReader : ExtensionContentReader<IAttribute>
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<AttributeReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeReader"/> class.
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
        public AttributeReader(IExtensionContentReaderFacade extensionContentReaderFacade, IXmiReaderSettings xmiReaderSettings, INameSpaceResolver nameSpaceResolver, IXmiElementCache cache, ILoggerFactory loggerFactory)
        : base(extensionContentReaderFacade, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<AttributeReader>.Instance : loggerFactory.CreateLogger<AttributeReader>();
        }

        /// <summary>
        /// Reads the <see cref="IAttribute"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">The name of the document that is currently read</param>
        /// <returns>
        /// an instance of <see cref="IAttribute"/>
        /// </returns>
        public override IAttribute Read(XmlReader xmlReader, string documentName)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            var xmlLineInfo = xmlReader as IXmlLineInfo;

            IAttribute poco = new xmi.Extensions.EnterpriseArchitect.Structure.Attribute();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.logger.LogTrace("reading Attribute at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

                var nameValue = xmlReader.GetAttribute("name");
                poco.Name = nameValue;
                var scopeValue = xmlReader.GetAttribute("scope");
                poco.Scope = scopeValue;

                var idRef = xmlReader.GetAttribute("xmi:idref");

                if (!string.IsNullOrWhiteSpace(idRef) && this.Cache.TryGetValue($"{documentName}#{idRef}", out var extendedElement))
                {
                    poco.ExtendedElement = extendedElement;
                }

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            case "bounds":
                                {
                                    poco.Bounds = this.ExtensionContentReaderFacade.QueryExtensionContent<Bounds>(xmlReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory);
                                    break;
                                }
                            case "containment":
                                {
                                    poco.Containment = this.ExtensionContentReaderFacade.QueryExtensionContent<ContainmentDefinition>(xmlReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory);
                                    break;
                                }
                            case "coords":
                                {
                                    poco.Coords = this.ExtensionContentReaderFacade.QueryExtensionContent<Coords>(xmlReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory);
                                    break;
                                }
                            case "documentation":
                                {
                                    poco.Documentation = this.ExtensionContentReaderFacade.QueryExtensionContent<Documentation>(xmlReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory);
                                    break;
                                }
                            case "initial":
                                {
                                    poco.Initial = this.ExtensionContentReaderFacade.QueryExtensionContent<Initial>(xmlReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory);
                                    break;
                                }
                            case "model":
                                {
                                    poco.Model = this.ExtensionContentReaderFacade.QueryExtensionContent<Model>(xmlReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory);
                                    break;
                                }
                            case "options":
                                {
                                    poco.Options = this.ExtensionContentReaderFacade.QueryExtensionContent<Options>(xmlReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory);
                                    break;
                                }
                            case "properties":
                                {
                                    poco.Properties = this.ExtensionContentReaderFacade.QueryExtensionContent<AttributeProperties>(xmlReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory);
                                    break;
                                }
                            case "stereotype":
                                {
                                    poco.Stereotype = this.ExtensionContentReaderFacade.QueryExtensionContent<StereotypeDefinition>(xmlReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory);
                                    break;
                                }
                            case "style":
                                {
                                    poco.Style = this.ExtensionContentReaderFacade.QueryExtensionContent<Style>(xmlReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory);
                                    break;
                                }
                            case "styleex":
                                {
                                    poco.Styleex = this.ExtensionContentReaderFacade.QueryExtensionContent<Style>(xmlReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory);
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
                            case "xrefs":
                                {
                                    poco.Xrefs = this.ExtensionContentReaderFacade.QueryExtensionContent<Xrefs>(xmlReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory);
                                    break;
                                }
                            default:
                                if (this.XmiReaderSettings.UseStrictReading)
                                {
                                    throw new NotSupportedException($"AttributeReader: {xmlReader.LocalName} at line:position {xmlLineInfo?.LineNumber}:{xmlLineInfo.LinePosition}");
                                }
                                else
                                {
                                    this.logger.LogWarning("Not Supported: AttributeReader: {LocalName} at line:position {LineNumber}:{LinePosition}", xmlReader.LocalName, xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);
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
