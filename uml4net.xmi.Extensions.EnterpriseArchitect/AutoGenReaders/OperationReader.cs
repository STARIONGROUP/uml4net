// -------------------------------------------------------------------------------------------------
// <copyright file="OperationReader.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="OperationReader"/> is to read an instance of <see cref="IOperation"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public partial class OperationReader : XmiElementReader<IOperation>, IXmiElementReader<IOperation>
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<OperationReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationReader"/> class.
        /// </summary>
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
        /// <see cref="KnowNamespacePrefixes"/>
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public OperationReader(IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, IXmiReaderSettings xmiReaderSettings, INameSpaceResolver nameSpaceResolver, ILoggerFactory loggerFactory)
        : base(cache, xmiElementReaderFacade, xmiReaderSettings, nameSpaceResolver, loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<OperationReader>.Instance : loggerFactory.CreateLogger<OperationReader>();
        }

        /// <summary>
        /// Reads the <see cref="IOperation"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="IOperation"/>
        /// </param>
        /// <param name="namespaceUri">
        /// the namespace that the <see cref="IOperation"/> belongs to
        /// </param>
        /// <returns>
        /// an instance of <see cref="IOperation"/>
        /// </returns>
        public override IOperation Read(XmlReader xmlReader, string documentName, string namespaceUri)
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

            IOperation poco = new xmi.Extensions.EntrepriseArchitect.Structure.Operation();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.logger.LogTrace("reading Operation at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

                var xmiType = "Operation";

                if (!string.IsNullOrEmpty(xmlReader.NamespaceURI))
                {
                    namespaceUri = xmlReader.NamespaceURI;
                }

                poco.XmiType = xmiType;

                var idRef = xmlReader.GetAttribute("xmi:idref");
                poco.XmiId = $"Extension-{(string.IsNullOrEmpty(idRef) ? Guid.NewGuid() : idRef)}";

                if (!string.IsNullOrEmpty(idRef))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("extendedElement", $"{documentName}#{idRef}");
                }

                poco.XmiGuid = Guid.NewGuid().ToString();

                poco.DocumentName = documentName;

                poco.XmiNamespaceUri = namespaceUri;

                if (!this.Cache.TryAdd(poco))
                {
                    this.logger.LogCritical("Failed to add element type [{Poco}] with id [{Id}] as it was already in the Cache. The XMI document seems to have duplicate xmi:id values", "Operation", poco.XmiId);
                }

                var extendedElementXmlAttribute = xmlReader.GetAttribute("extendedElement") ?? xmlReader.GetAttribute("extendedElement", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrEmpty(extendedElementXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("extendedElement", extendedElementXmlAttribute);
                }

                poco.Name = xmlReader.GetAttribute("name") ?? xmlReader.GetAttribute("name", this.NameSpaceResolver.UmlNameSpace);

                poco.Scope = xmlReader.GetAttribute("scope") ?? xmlReader.GetAttribute("scope", this.NameSpaceResolver.UmlNameSpace);


                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName.LowerCaseFirstLetter())
                        {
                            case "behaviour":
                                var behaviourValue = (IBehaviour)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "Behaviour", true);
                                poco.Behaviour.Add(behaviourValue);
                                break;
                            case "code":
                                var codeValue = (ICode)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "Code", true);
                                poco.Code.Add(codeValue);
                                break;
                            case "documentation":
                                var documentationValue = (IDocumentation)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "Documentation", true);
                                poco.Documentation.Add(documentationValue);
                                break;
                            case "extendedElement":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "extendedElement");
                                break;
                            case "model":
                                var modelValue = (IModel)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "Model", true);
                                poco.Model.Add(modelValue);
                                break;
                            case "name":
                                poco.Name = xmlReader.ReadElementContentAsString();
                                break;
                            case "parameters":
                                var parametersValue = (IParametersCollection)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "ParametersCollection", true);
                                poco.Parameters.Add(parametersValue);
                                break;
                            case "properties":
                                var propertiesValue = (IOperationProperties)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "OperationProperties", true);
                                poco.Properties.Add(propertiesValue);
                                break;
                            case "scope":
                                poco.Scope = xmlReader.ReadElementContentAsString();
                                break;
                            case "stereotype":
                                var stereotypeValue = (IStereotypeDefinition)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "StereotypeDefinition", true);
                                poco.Stereotype.Add(stereotypeValue);
                                break;
                            case "style":
                                var styleValue = (IStyle)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "Style", true);
                                poco.Style.Add(styleValue);
                                break;
                            case "styleex":
                                var styleexValue = (IStyle)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "Style", true);
                                poco.Styleex.Add(styleexValue);
                                break;
                            case "tags":
                                var tagsValue = (ITagsCollection)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "TagsCollection", true);
                                poco.Tags.Add(tagsValue);
                                break;
                            case "type":
                                var typeValue = (ITypeElement)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "TypeElement", true);
                                poco.Type.Add(typeValue);
                                break;
                            case "xrefs":
                                var xrefsValue = (IXrefs)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "Xrefs", true);
                                poco.Xrefs.Add(xrefsValue);
                                break;
                            default:
                                var couldHandleReadElement = this.HandleManualXmlRead(poco, xmlReader, documentName, namespaceUri);

                                if (couldHandleReadElement)
                                {
                                    break;
                                }

                                if (this.XmiReaderSettings.UseStrictReading)
                                {
                                    throw new NotSupportedException($"OperationReader: {xmlReader.LocalName} at line:position {xmlLineInfo.LineNumber}:{xmlLineInfo.LinePosition}");
                                }
                                else
                                {
                                    this.logger.LogWarning("Not Supported: OperationReader: {LocalName} at line:position {LineNumber}:{LinePosition}", xmlReader.LocalName, xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);
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
