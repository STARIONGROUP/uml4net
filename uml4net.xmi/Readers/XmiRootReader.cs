// -------------------------------------------------------------------------------------------------
//  <copyright file="XmiRootReader.cs" company="Starion Group S.A.">
// 
//    Copyright (C) 2019-2026 Starion Group S.A.
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

    using uml4net.Profiling;

    using uml4net.xmi.Extender;
    using uml4net.xmi.Settings;
    using uml4net.xmi.Xmi;

    /// <summary>
    /// The purpose of the <see cref="XmiRootReader"/> is to read an instance of <see cref="XmiRoot"/>
    /// from the XMI document
    /// </summary>
    public class XmiRootReader
    {
        /// <summary>
        /// The (injected) <see cref="IXmiElementCache"/> used cache the <see cref="IXmiElement"/>s
        /// </summary>
        private readonly IXmiElementCache cache;

        /// <summary>
        /// The (injected) <see cref="IXmiElementReaderFacade"/> used to resolve any
        /// required <see cref="IXmiElementReader{T}"/>
        /// </summary>
        private readonly IXmiElementReaderFacade xmiElementReaderFacade;

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
        /// The injected <see cref="IExtenderReaderRegistry"/> that provides <see cref="IExtenderReader"/> resolve
        /// </summary>
        private readonly IExtenderReaderRegistry extenderReaderRegistry;

        /// <summary>
        /// The <see cref="ILoggerFactory"/> used to set up logging
        /// </summary>
        private readonly ILoggerFactory loggerFactory;

        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<XmiRootReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiRootReader"/> class.
        /// </summary>>
        /// <param name="cache">
        /// The (injected) <see cref="IXmiElementCache"/>> in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="xmiElementReaderFacade">
        /// The (injected) <see cref="IXmiElementReaderFacade"/> used to resolve any
        /// required <see cref="IXmiElementReader{T}"/>
        /// </param>
        /// <param name="xmiReaderSettings">
        /// The <see cref="IXmiReaderSettings"/> used to configure reading
        /// </param>
        /// <param name="nameSpaceResolver">
        /// The (injected) <see cref="INameSpaceResolver"/> used to resolve a namespace to one of the
        /// <see cref="KnowNamespacePrefixes"/> constants
        /// </param>
        /// <param name="extenderReaderRegistry">The injected <see cref="IExtenderReaderRegistry"/> that provides <see cref="IExtenderReader"/> resolve</param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public XmiRootReader(IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, IXmiReaderSettings xmiReaderSettings, INameSpaceResolver nameSpaceResolver, IExtenderReaderRegistry extenderReaderRegistry, ILoggerFactory loggerFactory)
        {
            this.cache = cache;
            this.xmiElementReaderFacade = xmiElementReaderFacade;
            this.xmiReaderSettings = xmiReaderSettings;
            this.nameSpaceResolver = nameSpaceResolver;
            this.extenderReaderRegistry = extenderReaderRegistry;
            this.loggerFactory = loggerFactory;
            this.logger = loggerFactory == null ? NullLogger<XmiRootReader>.Instance : loggerFactory.CreateLogger<XmiRootReader>();
        }

        /// <summary>
        /// Reads the <see cref="Documentation"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="IXmiElement"/>
        /// </param>
        /// <param name="namespaceUri">
        /// the namespace that the <see cref="IXmiElement"/> belongs to
        /// </param>
        /// <param name="xmiRoot">
        /// An instance of <see cref="XmiRoot"/> that may be the result of a read action
        /// </param>
        /// <returns>
        /// an instance of <see cref="XmiRoot"/>
        /// </returns>
        public XmiRoot Read(XmlReader xmlReader, string documentName, string namespaceUri, XmiRoot xmiRoot)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            var xmlLineInfo = xmlReader as IXmlLineInfo;

            var processRootProperties = false;

            if (xmiRoot == null)
            {
                processRootProperties = true;
                xmiRoot = new XmiRoot();
            }

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.logger.LogTrace("reading from XmiRoot at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        var activeNamespaceUri = string.IsNullOrEmpty(xmlReader.NamespaceURI) ? namespaceUri : xmlReader.NamespaceURI;

                        var activeNameSpace = this.nameSpaceResolver.ResolvePrefix(activeNamespaceUri);

                        switch (activeNameSpace, xmlReader.LocalName)
                        {
                            case (KnowNamespacePrefixes.Xmi, "extension"):
                            case (KnowNamespacePrefixes.Xmi, "Extension"):
                                {
                                    using var xmiExtensionXmlReader = xmlReader.ReadSubtree();
                                    var xmiExtensionReader = new XmiExtensionReader(this.xmiReaderSettings, this.nameSpaceResolver, this.extenderReaderRegistry, this.loggerFactory);
                                    xmiRoot.Extensions.Add(xmiExtensionReader.Read(xmiExtensionXmlReader, documentName, namespaceUri));
                                }
                                break;
                            case (KnowNamespacePrefixes.Xmi, "difference"):
                            case (KnowNamespacePrefixes.Xmi, "Difference"):
                                this.logger.LogInformation("Difference elements contained in the XmiRoot Element are currently ignored - line:position {Line}:{Position}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);
                                xmlReader.Skip();
                                break;
                            case (KnowNamespacePrefixes.Xmi, "documentation"):
                            case (KnowNamespacePrefixes.Xmi, "Documentation"):
                                if (processRootProperties)
                                {
                                    using var subXmlReader = xmlReader.ReadSubtree();
                                    var documentationReader = new DocumentationReader(this.xmiReaderSettings, this.nameSpaceResolver, this.loggerFactory);
                                    var documentation = documentationReader.Read(subXmlReader, activeNamespaceUri);
                                    xmiRoot.Documentation = documentation;
                                }
                                break;
                            case (KnowNamespacePrefixes.Uml, _):
                                this.logger.LogTrace("reading at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);
                                var explicitTypeName = $"uml:{xmlReader.LocalName}";
                                var xmiElement = this.xmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, xmlReader.NamespaceURI, this.cache, this.xmiReaderSettings, this.nameSpaceResolver, this.extenderReaderRegistry, this.loggerFactory, explicitTypeName);
                                xmiRoot.Content.Add(xmiElement);
                                break;
                            case (KnowNamespacePrefixes.StandardProfile, _):
                                this.logger.LogWarning("StandardProfile reading is not yet supported, skipping element at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);
                                xmlReader.Skip();
                                break;
                            case (KnowNamespacePrefixes.UmlDi, _):
                                this.logger.LogWarning("DiagramInterchange reading is not yet supported, skipping element at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);
                                xmlReader.Skip();
                                break;
                            case (KnowNamespacePrefixes.MofExt, _):
                                {
                                    using var mofExtensionTagXmlReader = xmlReader.ReadSubtree();
                                    var tagReader = new TagReader(this.nameSpaceResolver, this.loggerFactory);
                                    var tag = tagReader.Read(mofExtensionTagXmlReader, activeNamespaceUri);
                                    xmiRoot.Tags.Add(tag);
                                }
                                break;
                            case (KnowNamespacePrefixes.PrimitiveTypes, _):
                                this.logger.LogWarning("PrimitiveTypes reading is not yet supported, skipping element at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);
                                xmlReader.Skip();
                                break;
                            case (KnowNamespacePrefixes.Other, _):
                                this.ProcessOtherNamespaces(xmlReader, xmiRoot);
                                break;
                        }
                    }
                }
            }

            return xmiRoot;
        }

        /// <summary>
        /// Processes the 'other' Namespace which typically holds <see cref="StereoTypeApplication"/>s
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="xmiRoot">
        /// The <see cref="XmiRoot"/>
        /// </param>
        private void  ProcessOtherNamespaces(XmlReader xmlReader, XmiRoot xmiRoot)
        {
            var xmlLineInfo = xmlReader as IXmlLineInfo;

            if (xmiRoot != null)
            {
                using var otherXmlReader = xmlReader.ReadSubtree();
                var stereoTypeApplicationReader = new StereoTypeApplicationReader(this.loggerFactory);

                if (stereoTypeApplicationReader.TryRead(otherXmlReader, out var stereoTypeApplication))
                {
                    xmiRoot.StereoTypeApplications.Add(stereoTypeApplication);
                }
                else
                {
                    this.logger.LogWarning("unknown namespaced-element at line:position {LineNumber}:{LinePosition} skipped", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);
                }
            }
            else
            {
                this.logger.LogWarning("unknown namespaced-element at line:position {LineNumber}:{LinePosition} skipped", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);
                xmlReader.Skip();
            }
        }
    }
}
