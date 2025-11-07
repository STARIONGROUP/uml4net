// -------------------------------------------------------------------------------------------------
// <copyright file="ElementReader.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="ElementReader"/> is to read an instance of <see cref="IElement"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public partial class ElementReader : ExtensionContentReader<IElement>
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<ElementReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ElementReader"/> class.
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
        public ElementReader(IExtensionContentReaderFacade extensionContentReaderFacade, IXmiReaderSettings xmiReaderSettings, INameSpaceResolver nameSpaceResolver, IXmiElementCache cache, ILoggerFactory loggerFactory)
        : base(extensionContentReaderFacade, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<ElementReader>.Instance : loggerFactory.CreateLogger<ElementReader>();
        }

        /// <summary>
        /// Reads the <see cref="IElement"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">The name of the document that is currently read</param>
        /// <returns>
        /// an instance of <see cref="IElement"/>
        /// </returns>
        public override IElement Read(XmlReader xmlReader, string documentName)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            var xmlLineInfo = xmlReader as IXmlLineInfo;

            IElement poco = new xmi.Extensions.EntrepriseArchitect.Structure.Element();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.logger.LogTrace("reading Element at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

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
                            case "attributes":
                                {
                                    using var attributesReader = xmlReader.ReadSubtree();

                                    while (attributesReader.Read())
                                    {
                                        if (attributesReader.NodeType != XmlNodeType.Element || attributesReader.LocalName == "attributes")
                                        {
                                            continue;
                                        }

                                        poco.Attributes.Add(this.ExtensionContentReaderFacade.QueryExtensionContent<xmi.Extensions.EntrepriseArchitect.Structure.Attribute>(attributesReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory));
                                    }

                                    break;
                                }
                            case "code":
                                {
                                    poco.Code = this.ExtensionContentReaderFacade.QueryExtensionContent<Code>(xmlReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory);
                                    break;
                                }
                            case "extendedProperties":
                                {
                                    poco.ExtendedProperties = this.ExtensionContentReaderFacade.QueryExtensionContent<ExtendedProperties>(xmlReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory);
                                    break;
                                }
                            case "flags":
                                {
                                    poco.Flags = this.ExtensionContentReaderFacade.QueryExtensionContent<Flags>(xmlReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory);
                                    break;
                                }
                            case "links":
                                {
                                    using var linksReader = xmlReader.ReadSubtree();

                                    while (linksReader.Read())
                                    {
                                        if (linksReader.NodeType != XmlNodeType.Element || linksReader.LocalName == "links")
                                        {
                                            continue;
                                        }

                                        poco.Links.Add(this.ExtensionContentReaderFacade.QueryExtensionContent<ILink>(linksReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory));
                                    }

                                    break;
                                }
                            case "model":
                                {
                                    poco.Model = this.ExtensionContentReaderFacade.QueryExtensionContent<Model>(xmlReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory);
                                    break;
                                }
                            case "operations":
                                {
                                    using var operationsReader = xmlReader.ReadSubtree();

                                    while (operationsReader.Read())
                                    {
                                        if (operationsReader.NodeType != XmlNodeType.Element || operationsReader.LocalName == "operations")
                                        {
                                            continue;
                                        }

                                        poco.Operations.Add(this.ExtensionContentReaderFacade.QueryExtensionContent<Operation>(operationsReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory));
                                    }

                                    break;
                                }
                            case "packageproperties":
                                {
                                    poco.Packageproperties = this.ExtensionContentReaderFacade.QueryExtensionContent<PackageProperties>(xmlReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory);
                                    break;
                                }
                            case "paths":
                                {
                                    using var pathsReader = xmlReader.ReadSubtree();

                                    while (pathsReader.Read())
                                    {
                                        if (pathsReader.NodeType != XmlNodeType.Element || pathsReader.LocalName == "paths")
                                        {
                                            continue;
                                        }

                                        poco.Paths.Add(this.ExtensionContentReaderFacade.QueryExtensionContent<Path>(pathsReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory));
                                    }

                                    break;
                                }
                            case "project":
                                {
                                    poco.Project = this.ExtensionContentReaderFacade.QueryExtensionContent<Project>(xmlReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory);
                                    break;
                                }
                            case "properties":
                                {
                                    poco.Properties = this.ExtensionContentReaderFacade.QueryExtensionContent<ElementProperties>(xmlReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory);
                                    break;
                                }
                            case "style":
                                {
                                    poco.Style = this.ExtensionContentReaderFacade.QueryExtensionContent<AppearanceStyle>(xmlReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory);
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
                            case "templateParameters":
                                {
                                    using var templateParametersReader = xmlReader.ReadSubtree();

                                    while (templateParametersReader.Read())
                                    {
                                        if (templateParametersReader.NodeType != XmlNodeType.Element || templateParametersReader.LocalName == "templateParameters")
                                        {
                                            continue;
                                        }

                                        poco.TemplateParameters.Add(this.ExtensionContentReaderFacade.QueryExtensionContent<Parameter>(templateParametersReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory));
                                    }

                                    break;
                                }
                            case "times":
                                {
                                    poco.Times = this.ExtensionContentReaderFacade.QueryExtensionContent<Times>(xmlReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory);
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
                                    throw new NotSupportedException($"ElementReader: {xmlReader.LocalName} at line:position {xmlLineInfo?.LineNumber}:{xmlLineInfo.LinePosition}");
                                }
                                else
                                {
                                    this.logger.LogWarning("Not Supported: ElementReader: {LocalName} at line:position {LineNumber}:{LinePosition}", xmlReader.LocalName, xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);
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
