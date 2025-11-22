// -------------------------------------------------------------------------------------------------
//  <copyright file="EnterpriseArchitectExtenderReader.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Extensions.EnterpriseArchitect.Extender
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.Extensions;
    using uml4net.xmi.Extender;
    using uml4net.xmi.Extensions.EnterpriseArchitect.Structure;
    using uml4net.xmi.Readers;
    using uml4net.xmi.Settings;

    using Connector = uml4net.xmi.Extensions.EnterpriseArchitect.Structure.Connector;
    using IConnector = uml4net.xmi.Extensions.EnterpriseArchitect.Structure.IConnector;
    using IElement = uml4net.xmi.Extensions.EnterpriseArchitect.Structure.IElement;

    /// <summary>
    /// An <see cref="IExtenderReader" /> implementation that processes <c>xmi:Extension</c> elements
    /// produced by <strong>Sparx Systems Enterprise Architect</strong> version <c>6.5</c>.
    /// </summary>
    /// <remarks>
    /// Enterprise Architect embeds tool-specific metadata inside <c>xmi:Extension</c> blocks,
    /// including diagram layout, tagged values, and other proprietary modeling data.
    /// This reader extracts and interprets such content for downstream usage.
    /// </remarks>
    [ExtenderReader("Enterprise Architect", "6.5")]
    public class EnterpriseArchitectExtenderReader : IExtenderReader
    {
        /// <summary>
        /// Pattern that represent the exported value of the isID attribute from Enterprise Architect
        /// </summary>
        private const string IsIdPattern = "$TYP=attribute property$TYP;$VIS=Public$VIS;$PAR=0$PAR;$DES=@PROP=@NAME=isID@ENDNAME;@TYPE=Boolean@ENDTYPE;@VALU=1@ENDVALU;@PRMT=@ENDPRMT;@ENDPROP;";
        
        /// <summary>
        /// The injected <see cref="IExtensionContentReaderFacade" /> that provides extension content read capabailities
        /// </summary>
        protected readonly IExtensionContentReaderFacade ExtensionContentReaderFacade;

        /// <summary>
        /// The (injected) <see cref="ILogger{XmiReader}" /> used to perform logging
        /// </summary>
        private readonly ILogger<XmiReader> logger;

        /// <summary>
        /// The (injected) <see cref="ILoggerFactory" /> used to set up logging
        /// </summary>
        protected readonly ILoggerFactory LoggerFactory;

        /// <summary>
        /// The <see cref="IXmiReaderScope" />
        /// </summary>
        private readonly IXmiReaderScope scope;

        /// <summary>
        /// The (injected) <see cref="IXmiReaderSettings" /> used to configure reading
        /// </summary>
        protected readonly IXmiReaderSettings XmiReaderSettings;

        /// <summary>
        /// The injected <see cref="IXmiElementCache"/> that provides cached elements retrieval
        /// </summary>
        protected readonly IXmiElementCache Cache;

        /// <summary>
        /// The injected <see cref="INameSpaceResolver"/> that helps to resolve namespace uri
        /// </summary>
        protected readonly INameSpaceResolver NameSpaceResolver;
        
        /// <summary>
        /// The injected <see cref="IXmiElementReaderFacade" /> that allows reading <see cref="IXmiElement" />
        /// </summary>
        protected readonly IXmiElementReaderFacade XmiElementReaderFacade;

        /// <summary>
        /// The injected <see cref="IExtenderReaderRegistry"/> that provides <see cref="IExtenderReader"/> resolve
        /// </summary>
        protected readonly Lazy<IExtenderReaderRegistry> ExtenderReaderRegistry;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiReader" /> class.
        /// </summary>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory" /> used to set up logging
        /// </param>
        /// <param name="scope">The <see cref="IXmiReaderScope" /></param>
        /// <param name="xmiReaderSettings">The injected <see cref="IXmiReaderSettings" /> that provides reading setting for XMI</param>
        /// <param name="extensionContentReaderFacade">The injected <see cref="IExtensionContentReaderFacade" /> that provides extension content read capabailities</param>
        /// <param name="cache">The injected <see cref="IXmiElementCache"/> that provides cached elements retrieval</param>
        /// <param name="nameSpaceResolver">The injected <see cref="INameSpaceResolver"/> that helps to resolve namespace uri</param>
        /// <param name="xmiElementReaderFacade">The injected <see cref="IXmiElementReaderFacade" /> that allows reading <see cref="IXmiElement" /></param>
        /// <param name="extenderReaderRegistry">The injected <see cref="IExtenderReaderRegistry"/> that provides <see cref="IExtenderReader"/> resolve</param>
        public EnterpriseArchitectExtenderReader(IXmiReaderScope scope, IXmiReaderSettings xmiReaderSettings, ILoggerFactory loggerFactory, IExtensionContentReaderFacade extensionContentReaderFacade,
             IXmiElementCache cache, INameSpaceResolver nameSpaceResolver, IXmiElementReaderFacade xmiElementReaderFacade, Lazy<IExtenderReaderRegistry> extenderReaderRegistry)
        {
            this.XmiReaderSettings = xmiReaderSettings;
            this.LoggerFactory = loggerFactory;
            this.logger = this.LoggerFactory == null ? NullLogger<XmiReader>.Instance : this.LoggerFactory.CreateLogger<XmiReader>();
            this.scope = scope;
            this.ExtensionContentReaderFacade = extensionContentReaderFacade;
            this.Cache = cache;
            this.NameSpaceResolver = nameSpaceResolver;
            this.XmiElementReaderFacade = xmiElementReaderFacade;
            this.ExtenderReaderRegistry = extenderReaderRegistry;
        }
        
        /// <summary>
        /// Reads the content of the Enterprise Architect <see cref="XmiExtension" />
        /// </summary>
        /// <param name="extensionXmi">
        /// the xml content of the <see cref="XmiExtension" />
        /// </param>
        /// <param name="documentName">The name of the document that is currently read</param>
        /// <returns>
        /// the contents as a <see cref="List{Object}" />
        /// </returns>
        public List<object> ReadContent(string extensionXmi, string documentName)
        {
            var sw = Stopwatch.StartNew();

            this.logger.LogDebug("Starting to read Enterprise Architect 6.5 extension");

            var result = new List<object>();

            using (var xmlReader = XmlReader.Create(new StringReader(extensionXmi)))
            {
                if (xmlReader.MoveToContent() != XmlNodeType.Element)
                {
                    return result;
                }
                
                switch (xmlReader.LocalName.LowerCaseFirstLetter())
                {
                    case "elements":
                    {
                        using var elementsReader = xmlReader.ReadSubtree();

                        while (elementsReader.Read())
                        {
                            if (elementsReader.NodeType != XmlNodeType.Element || elementsReader.LocalName != "element")
                            {
                                continue;
                            }

                            result.Add(this.ExtensionContentReaderFacade.QueryExtensionContent<Element>(elementsReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory));
                        }

                        break;
                    }
                    case "connectors":
                    {
                        using var connectorsReader = xmlReader.ReadSubtree();

                        while (connectorsReader.Read())
                        {
                            if (connectorsReader.NodeType != XmlNodeType.Element || connectorsReader.LocalName != "connector")
                            {
                                continue;
                            }

                            result.Add(this.ExtensionContentReaderFacade.QueryExtensionContent<Connector>(connectorsReader, this.XmiReaderSettings, this.NameSpaceResolver, this.Cache, documentName, this.LoggerFactory));
                        }

                        break;
                    }
                    case "profiles":
                    {
                        using var profilesReader = xmlReader.ReadSubtree();

                        while (profilesReader.Read())
                        {
                            if (profilesReader.NodeType != XmlNodeType.Element || profilesReader.LocalName != "Profile")
                            {
                                continue;
                            }

                            var xmiAttribute = profilesReader.GetAttribute("xmlns:xmi");
                            var umlAttribute = profilesReader.GetAttribute("xmlns:uml");

                            if (!string.IsNullOrWhiteSpace(xmiAttribute))
                            {
                                this.NameSpaceResolver.ResolveAndSetNamespace(xmiAttribute);
                            }
                            
                            if (!string.IsNullOrWhiteSpace(umlAttribute))
                            {
                                this.NameSpaceResolver.ResolveAndSetNamespace(umlAttribute);
                            }

                            result.Add(this.XmiElementReaderFacade.QueryXmiElement(profilesReader, documentName, "uml", this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry.Value, this.LoggerFactory, "uml:Profile"));
                        }
                        
                        break;
                    }
                    case "primitivetypes":
                    {
                        xmlReader.Skip();
                        break;
                    }
                }
            }

            this.logger.LogDebug("Enterprise Architect 6.5 extension read in {ElapsedMilliseconds} [ms]", sw.ElapsedMilliseconds);

            return result;
        }

        /// <summary>
        /// Performs post-processing of a UMl model using content of the extension
        /// </summary>
        /// <param name="readExtension">The <see cref="IXmiExtension"/> that has been read</param>
        public void PostProcess(IXmiExtension readExtension)
        {
            // here we can update the documentation  based on docs in EA extension -> then
            // we do not need a separate QueryDocs method.

            ApplyDocumentation(readExtension);
            ApplyIsIdOnProperty(readExtension);
        }

        /// <summary>
        /// Apply the <see cref="IProperty.IsID"/> value since Enterprise Architect does not set it correctly
        /// </summary>
        /// <param name="readExtension">The read <see cref="IXmiExtension"/></param>
        private static void ApplyIsIdOnProperty(IXmiExtension readExtension)
        {
            var attributes = readExtension.Content.OfType<IElement>().SelectMany(x => x.Attributes).ToList();

            foreach (var attribute in attributes)
            {
                if (attribute.ExtendedElement is IProperty property && !string.IsNullOrWhiteSpace(attribute.Xrefs.Value) && attribute.Xrefs.Value.Contains(IsIdPattern))
                {
                    property.IsID = true;
                }
            }
        }

        /// <summary>
        /// Adds new <see cref="Comment"/> to <see cref="uml4net.CommonStructure.IElement" /> that are extended by the <see cref="IXmiExtension" />
        /// </summary>
        /// <param name="readExtension">The read <see cref="IXmiExtension"/></param>
        private static void ApplyDocumentation(IXmiExtension readExtension)
        {
            var  documentedElements = new List<IDocumentedElement>();
            
            var elements = readExtension.Content.OfType<IElement>().ToList();
            documentedElements.AddRange(elements.SelectMany(x => x.Attributes));
            documentedElements.AddRange(elements.SelectMany(x => x.Operations));
            documentedElements.AddRange(elements.SelectMany(x => x.Operations.SelectMany(o => o.Parameters)));
            documentedElements.AddRange(elements.SelectMany(x => x.TemplateParameters));

            foreach (var documentedElement in documentedElements)
            {
                if (documentedElement is not IElementReference { ExtendedElement: uml4net.CommonStructure.IElement element })
                {
                    continue;
                }
               
                if (!string.IsNullOrWhiteSpace(documentedElement.Documentation?.Value))
                {
                    element.OwnedComment.Add(new Comment()
                    {
                        Body = documentedElement.Documentation.Value
                    });
                }
            }

            foreach (var element in elements)
            {
                if (!string.IsNullOrEmpty(element.Properties?.Documentation) && element.ExtendedElement is uml4net.CommonStructure.IElement extendedElement)
                {
                    extendedElement.OwnedComment.Add(new Comment()
                    {
                        Body = element.Properties.Documentation
                    });
                }
            }

            var connectors = readExtension.Content.OfType<IConnector>().ToList();

            foreach (var connector in connectors)
            {
                if (!string.IsNullOrWhiteSpace(connector.Documentation?.Value) && connector.ExtendedElement is uml4net.CommonStructure.IElement extendedConnector)
                {
                    extendedConnector.OwnedComment.Add(new Comment()
                    {
                        Body = connector.Documentation?.Value
                    });
                }

                if (connector.ExtendedElement is  uml4net.StructuredClassifiers.IAssociation association)
                {
                    foreach (var property in association.MemberEnd)
                    {
                        var connectorEnd = property.XmiId.Contains("src") ? connector.Source :  connector.Target;

                        if (!string.IsNullOrWhiteSpace(connectorEnd.Documentation.Value))
                        {
                            property.OwnedComment.Add(new Comment()
                            {
                                Body = connectorEnd.Documentation.Value
                            });
                        }
                    }
                }
            }
        }
    }
}
