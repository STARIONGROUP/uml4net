﻿// -------------------------------------------------------------------------------------------------
// <copyright file="InformationFlowReader.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="InformationFlowReader"/> is to read an instance of <see cref="IInformationFlow"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public class InformationFlowReader : XmiElementReader<IInformationFlow>, IXmiElementReader<IInformationFlow>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InformationFlowReader"/> class.
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
        public InformationFlowReader(IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, IXmiReaderSettings xmiReaderSettings, ILoggerFactory loggerFactory)
            : base(cache, xmiElementReaderFacade, xmiReaderSettings, loggerFactory)
        {
        }

        /// <summary>
        /// Reads the <see cref="IInformationFlow"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="IInformationFlow"/>
        /// </param>
        /// <param name="namespaceUri">
        /// the namespace that the <see cref="IInformationFlow"/> belongs to
        /// </param>
        /// <returns>
        /// an instance of <see cref="IInformationFlow"/>
        /// </returns>
        public override IInformationFlow Read(XmlReader xmlReader, string documentName, string namespaceUri)
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

            IInformationFlow poco = new InformationFlow();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:InformationFlow")
                {
                    throw new XmlException($"The XmiType should be 'uml:InformationFlow' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:InformationFlow";
                }

                if (!string.IsNullOrEmpty(xmlReader.NamespaceURI))
                {
                    namespaceUri = xmlReader.NamespaceURI;
                }

                poco.XmiType = xmiType;

                poco.XmiId = xmlReader.GetAttribute("xmi:id");

                poco.XmiGuid = xmlReader.GetAttribute("xmi:uuid");

                poco.DocumentName = documentName;

                poco.XmiNamespaceUri = namespaceUri;

                if (!this.Cache.TryAdd(poco))
                {
                    this.Logger.LogCritical("Failed to add element type [{Poco}] with id [{Id}] as it was already in the Cache. The XMI document seems to have duplicate xmi:id values", "InformationFlow", poco.XmiId);
                }

                var conveyedXmlAttribute = xmlReader.GetAttribute("conveyed");

                if (!string.IsNullOrEmpty(conveyedXmlAttribute))
                {
                    var conveyedXmlAttributeValues = conveyedXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("conveyed", conveyedXmlAttributeValues);
                }

                var informationSourceXmlAttribute = xmlReader.GetAttribute("informationSource");

                if (!string.IsNullOrEmpty(informationSourceXmlAttribute))
                {
                    var informationSourceXmlAttributeValues = informationSourceXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("informationSource", informationSourceXmlAttributeValues);
                }

                var informationTargetXmlAttribute = xmlReader.GetAttribute("informationTarget");

                if (!string.IsNullOrEmpty(informationTargetXmlAttribute))
                {
                    var informationTargetXmlAttributeValues = informationTargetXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("informationTarget", informationTargetXmlAttributeValues);
                }

                poco.Name = xmlReader.GetAttribute("name");

                var owningTemplateParameterXmlAttribute = xmlReader.GetAttribute("owningTemplateParameter");

                if (!string.IsNullOrEmpty(owningTemplateParameterXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("owningTemplateParameter", owningTemplateParameterXmlAttribute);
                }

                var realizationXmlAttribute = xmlReader.GetAttribute("realization");

                if (!string.IsNullOrEmpty(realizationXmlAttribute))
                {
                    var realizationXmlAttributeValues = realizationXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("realization", realizationXmlAttributeValues);
                }

                var realizingActivityEdgeXmlAttribute = xmlReader.GetAttribute("realizingActivityEdge");

                if (!string.IsNullOrEmpty(realizingActivityEdgeXmlAttribute))
                {
                    var realizingActivityEdgeXmlAttributeValues = realizingActivityEdgeXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("realizingActivityEdge", realizingActivityEdgeXmlAttributeValues);
                }

                var realizingConnectorXmlAttribute = xmlReader.GetAttribute("realizingConnector");

                if (!string.IsNullOrEmpty(realizingConnectorXmlAttribute))
                {
                    var realizingConnectorXmlAttributeValues = realizingConnectorXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("realizingConnector", realizingConnectorXmlAttributeValues);
                }

                var realizingMessageXmlAttribute = xmlReader.GetAttribute("realizingMessage");

                if (!string.IsNullOrEmpty(realizingMessageXmlAttribute))
                {
                    var realizingMessageXmlAttributeValues = realizingMessageXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("realizingMessage", realizingMessageXmlAttributeValues);
                }

                var templateParameterXmlAttribute = xmlReader.GetAttribute("templateParameter");

                if (!string.IsNullOrEmpty(templateParameterXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("templateParameter", templateParameterXmlAttribute);
                }

                var visibilityXmlAttribute = xmlReader.GetAttribute("visibility");

                if (!string.IsNullOrEmpty(visibilityXmlAttribute))
                {
                    poco.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibilityXmlAttribute, true);
                }


                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            case "conveyed":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "conveyed");
                                break;
                            case "informationSource":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "informationSource");
                                break;
                            case "informationTarget":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "informationTarget");
                                break;
                            case "name":
                                poco.Name = xmlReader.ReadElementContentAsString();
                                break;
                            case "nameExpression":
                                var nameExpressionValue = (IStringExpression)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "uml:StringExpression");
                                poco.NameExpression.Add(nameExpressionValue);
                                break;
                            case "ownedComment":
                                var ownedCommentValue = (IComment)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "uml:Comment");
                                poco.OwnedComment.Add(ownedCommentValue);
                                break;
                            case "owningTemplateParameter":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "owningTemplateParameter");
                                break;
                            case "realization":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "realization");
                                break;
                            case "realizingActivityEdge":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "realizingActivityEdge");
                                break;
                            case "realizingConnector":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "realizingConnector");
                                break;
                            case "realizingMessage":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "realizingMessage");
                                break;
                            case "templateParameter":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "templateParameter");
                                break;
                            case "visibility":
                                var visibilityValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(visibilityValue))
                                {
                                    poco.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibilityValue, true);
                                }

                                break;
                            default:
                                if (this.XmiReaderSettings.UseStrictReading)
                                {
                                    throw new NotSupportedException($"InformationFlowReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
                                }
                                else
                                {
                                    this.Logger.LogWarning("Not Supported: InformationFlowReader: {LocalName} at line:position {LineNumber}:{LinePosition}", xmlReader.LocalName, defaultLineInfo.LineNumber, defaultLineInfo.LinePosition);
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
