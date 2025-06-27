// -------------------------------------------------------------------------------------------------
// <copyright file="ElementReader.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2025 Starion Group S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
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
    public partial class ElementReader : XmiElementReader<IElement>, IXmiElementReader<IElement>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElementReader"/> class.
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
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public ElementReader(IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, IXmiReaderSettings xmiReaderSettings, ILoggerFactory loggerFactory)
        : base(cache, xmiElementReaderFacade, xmiReaderSettings, loggerFactory)
        {
        }

        /// <summary>
        /// Reads the <see cref="IElement"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="IElement"/>
        /// </param>
        /// <param name="namespaceUri">
        /// the namespace that the <see cref="IElement"/> belongs to
        /// </param>
        /// <returns>
        /// an instance of <see cref="IElement"/>
        /// </returns>
        public override IElement Read(XmlReader xmlReader, string documentName, string namespaceUri)
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

            var defaultLineInfo = xmlReader as IXmlLineInfo;

            IElement poco = new xmi.Extensions.EntrepriseArchitect.Structure.Element();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = "Element";


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
                    this.Logger.LogCritical("Failed to add element type [{Poco}] with id [{Id}] as it was already in the Cache. The XMI document seems to have duplicate xmi:id values", "Element", poco.XmiId);
                }

                var extendedElementXmlAttribute = xmlReader.GetAttribute("extendedElement");

                if (!string.IsNullOrEmpty(extendedElementXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("extendedElement", extendedElementXmlAttribute);
                }

                poco.Name = xmlReader.GetAttribute("name");

                poco.Scope = xmlReader.GetAttribute("scope");


                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName.LowerCaseFirstLetter())
                        {
                            case "attributes":
                                var attributesValue = (IAttributesCollection)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "AttributesCollection", true);
                                poco.Attributes.Add(attributesValue);
                                break;
                            case "code":
                                var codeValue = (ICode)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "Code", true);
                                poco.Code.Add(codeValue);
                                break;
                            case "extendedElement":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "extendedElement");
                                break;
                            case "extendedProperties":
                                var extendedPropertiesValue = (IExtendedProperties)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "ExtendedProperties", true);
                                poco.ExtendedProperties.Add(extendedPropertiesValue);
                                break;
                            case "flags":
                                var flagsValue = (IFlags)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "Flags", true);
                                poco.Flags.Add(flagsValue);
                                break;
                            case "links":
                                var linksValue = (ILinksCollection)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "LinksCollection", true);
                                poco.Links.Add(linksValue);
                                break;
                            case "model":
                                var modelValue = (IModel)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "Model", true);
                                poco.Model.Add(modelValue);
                                break;
                            case "name":
                                poco.Name = xmlReader.ReadElementContentAsString();
                                break;
                            case "operations":
                                var operationsValue = (IOperations)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "Operations", true);
                                poco.Operations.Add(operationsValue);
                                break;
                            case "packageproperties":
                                var packagepropertiesValue = (IPackageProperties)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "PackageProperties", true);
                                poco.Packageproperties.Add(packagepropertiesValue);
                                break;
                            case "paths":
                                var pathsValue = (IPaths)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "Paths", true);
                                poco.Paths.Add(pathsValue);
                                break;
                            case "project":
                                var projectValue = (IProject)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "Project", true);
                                poco.Project.Add(projectValue);
                                break;
                            case "properties":
                                var propertiesValue = (IElementProperties)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "ElementProperties", true);
                                poco.Properties.Add(propertiesValue);
                                break;
                            case "scope":
                                poco.Scope = xmlReader.ReadElementContentAsString();
                                break;
                            case "style":
                                var styleValue = (IAppearanceStyle)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "AppearanceStyle", true);
                                poco.Style.Add(styleValue);
                                break;
                            case "tags":
                                var tagsValue = (ITagsCollection)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "TagsCollection", true);
                                poco.Tags.Add(tagsValue);
                                break;
                            case "times":
                                var timesValue = (ITimes)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "Times", true);
                                poco.Times.Add(timesValue);
                                break;
                            case "xrefs":
                                var xrefsValue = (IXrefs)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "Xrefs", true);
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
                                    throw new NotSupportedException($"ElementReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
                                }
                                else
                                {
                                    this.Logger.LogWarning("Not Supported: ElementReader: {LocalName} at line:position {LineNumber}:{LinePosition}", xmlReader.LocalName, defaultLineInfo.LineNumber, defaultLineInfo.LinePosition);
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
