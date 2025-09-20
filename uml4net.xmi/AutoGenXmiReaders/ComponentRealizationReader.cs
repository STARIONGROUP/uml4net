// -------------------------------------------------------------------------------------------------
// <copyright file="ComponentRealizationReader.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Readers
{
    using System;
    using System.CodeDom.Compiler;
    using System.Linq;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using uml4net;
    using uml4net.Actions;
    using uml4net.Activities;
    using uml4net.Classification;
    using uml4net.CommonBehavior;
    using uml4net.CommonStructure;
    using uml4net.Deployments;
    using uml4net.InformationFlows;
    using uml4net.Interactions;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StateMachines;
    using uml4net.StructuredClassifiers;
    using uml4net.UseCases;
    using uml4net.Values;
    using uml4net.xmi.ReferenceResolver;
    using uml4net.xmi.Settings;

    /// <summary>
    /// The purpose of the <see cref="ComponentRealizationReader"/> is to read an instance of <see cref="IComponentRealization"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public class ComponentRealizationReader : XmiElementReader<IComponentRealization>, IXmiElementReader<IComponentRealization>
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<ComponentRealizationReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentRealizationReader"/> class.
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
        public ComponentRealizationReader(IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, IXmiReaderSettings xmiReaderSettings, INameSpaceResolver nameSpaceResolver, ILoggerFactory loggerFactory)
            : base(cache, xmiElementReaderFacade, xmiReaderSettings, nameSpaceResolver, loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<ComponentRealizationReader>.Instance : loggerFactory.CreateLogger<ComponentRealizationReader>();
        }

        /// <summary>
        /// Reads the <see cref="IComponentRealization"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="IComponentRealization"/>
        /// </param>
        /// <param name="namespaceUri">
        /// the namespace that the <see cref="IComponentRealization"/> belongs to
        /// </param>
        /// <returns>
        /// an instance of <see cref="IComponentRealization"/>
        /// </returns>
        public override IComponentRealization Read(XmlReader xmlReader, string documentName, string namespaceUri)
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

            IComponentRealization poco = new ComponentRealization();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.logger.LogTrace("reading ComponentRealization at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

                var xmiType = xmlReader.GetAttribute("type", this.NameSpaceResolver.XmiNameSpace);

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:ComponentRealization")
                {
                    throw new XmlException($"The XmiType should be 'uml:ComponentRealization' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:ComponentRealization";
                }

                if (!string.IsNullOrEmpty(xmlReader.NamespaceURI))
                {
                    namespaceUri = xmlReader.NamespaceURI;
                }

                this.NameSpaceResolver.ResolveAndSetNamespace(namespaceUri);

                poco.XmiType = xmiType;

                poco.XmiId = xmlReader.GetAttribute("id", this.NameSpaceResolver.XmiNameSpace);

                poco.XmiGuid = xmlReader.GetAttribute("uuid", this.NameSpaceResolver.XmiNameSpace);

                poco.DocumentName = documentName;

                poco.XmiNamespaceUri = namespaceUri;

                if (!this.Cache.TryAdd(poco))
                {
                    this.logger.LogCritical("Failed to add element type [{Poco}] with id [{Id}] as it was already in the Cache. The XMI document seems to have duplicate xmi:id values", "ComponentRealization", poco.XmiId);
                }

                var abstractionXmlAttribute = xmlReader.GetAttribute("abstraction") ?? xmlReader.GetAttribute("abstraction", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrEmpty(abstractionXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("abstraction", abstractionXmlAttribute);
                }

                var clientXmlAttribute = xmlReader.GetAttribute("client") ?? xmlReader.GetAttribute("client", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrEmpty(clientXmlAttribute))
                {
                    var clientXmlAttributeValues = clientXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("client", clientXmlAttributeValues);
                }

                poco.Name = xmlReader.GetAttribute("name") ?? xmlReader.GetAttribute("name", this.NameSpaceResolver.UmlNameSpace);

                var owningTemplateParameterXmlAttribute = xmlReader.GetAttribute("owningTemplateParameter") ?? xmlReader.GetAttribute("owningTemplateParameter", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrEmpty(owningTemplateParameterXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("owningTemplateParameter", owningTemplateParameterXmlAttribute);
                }

                var realizingClassifierXmlAttribute = xmlReader.GetAttribute("realizingClassifier") ?? xmlReader.GetAttribute("realizingClassifier", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrEmpty(realizingClassifierXmlAttribute))
                {
                    var realizingClassifierXmlAttributeValues = realizingClassifierXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("realizingClassifier", realizingClassifierXmlAttributeValues);
                }

                var supplierXmlAttribute = xmlReader.GetAttribute("supplier") ?? xmlReader.GetAttribute("supplier", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrEmpty(supplierXmlAttribute))
                {
                    var supplierXmlAttributeValues = supplierXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("supplier", supplierXmlAttributeValues);
                }

                var templateParameterXmlAttribute = xmlReader.GetAttribute("templateParameter") ?? xmlReader.GetAttribute("templateParameter", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrEmpty(templateParameterXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("templateParameter", templateParameterXmlAttribute);
                }

                var visibilityXmlAttribute = xmlReader.GetAttribute("visibility") ?? xmlReader.GetAttribute("visibility", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrEmpty(visibilityXmlAttribute))
                {
                    poco.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibilityXmlAttribute, true);
                }


                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        var activeNamespaceUri = string.IsNullOrEmpty(xmlReader.NamespaceURI) ? namespaceUri : xmlReader.NamespaceURI;

                        var activePrefix = this.NameSpaceResolver.ResolvePrefix(activeNamespaceUri);

                        switch (activePrefix, xmlReader.LocalName)
                        {
                            case (KnowNamespacePrefixes.Uml, "abstraction"):
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "abstraction");
                                break;
                            case (KnowNamespacePrefixes.Uml, "client"):
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "client");
                                break;
                            case (KnowNamespacePrefixes.Uml, "mapping"):
                                var mappingValue = (IOpaqueExpression)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "uml:OpaqueExpression");
                                poco.Mapping.Add(mappingValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "name"):
                                poco.Name = xmlReader.ReadElementContentAsString();
                                break;
                            case (KnowNamespacePrefixes.Uml, "nameExpression"):
                                var nameExpressionValue = (IStringExpression)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "uml:StringExpression");
                                poco.NameExpression.Add(nameExpressionValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "ownedComment"):
                                var ownedCommentValue = (IComment)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "uml:Comment");
                                poco.OwnedComment.Add(ownedCommentValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "owningTemplateParameter"):
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "owningTemplateParameter");
                                break;
                            case (KnowNamespacePrefixes.Uml, "realizingClassifier"):
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "realizingClassifier");
                                break;
                            case (KnowNamespacePrefixes.Uml, "supplier"):
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "supplier");
                                break;
                            case (KnowNamespacePrefixes.Uml, "templateParameter"):
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "templateParameter");
                                break;
                            case (KnowNamespacePrefixes.Uml, "visibility"):
                                var visibilityValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(visibilityValue))
                                {
                                    poco.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibilityValue, true);
                                }

                                break;
                            case (KnowNamespacePrefixes.Xmi, "Extension"):
                                this.logger.LogInformation("Extension not yet supported)");
                                xmlReader.Skip();
                                break;
                            default:
                                if (this.XmiReaderSettings.UseStrictReading)
                                {
                                    throw new NotSupportedException($"ComponentRealizationReader: {xmlReader.LocalName} at line:position {xmlLineInfo.LineNumber}:{xmlLineInfo.LinePosition}");
                                }
                                else
                                {
                                    this.logger.LogWarning("Not Supported: ComponentRealizationReader: {LocalName} at line:position {LineNumber}:{LinePosition}", xmlReader.LocalName, xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);
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
