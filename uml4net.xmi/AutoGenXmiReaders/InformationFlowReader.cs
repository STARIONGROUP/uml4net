// -------------------------------------------------------------------------------------------------
// <copyright file="InformationFlowReader.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2024 Starion Group S.A.
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

namespace uml4net.xmi.Readers.InformationFlows
{
    using System;
    using System.Collections.Generic;
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
    using uml4net.StructuredClassifiers;
    using uml4net.UseCases;
    using uml4net.Utils;
    using uml4net.Values;
    using uml4net.xmi.Cache;
    using uml4net.xmi.Readers;

    /// <summary>
    /// The purpose of the <see cref="InformationFlowReader"/> is to read an instance of <see cref="IInformationFlow"/>
    /// from the XMI document
    /// </summary>
    public class InformationFlowReader : XmiElementReader<IInformationFlow>, IXmiElementReader<IInformationFlow>
    {
        private readonly IXmiElementReaderFacade xmiElementReaderFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="InformationFlowReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public InformationFlowReader(IXmiReaderCache cache, ILoggerFactory loggerFactory)
            : base(cache, loggerFactory)
        {
            this.xmiElementReaderFacade = new XmiElementReaderFacade();
        }

        /// <summary>
        /// Reads the <see cref="IInformationFlow"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="IInformationFlow"/>
        /// </returns>
        public override IInformationFlow Read(XmlReader xmlReader)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

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

                poco.XmiType = xmiType;

                poco.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(poco.XmiId, poco);

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


                var conveyed = new List<string>();
                var informationSource = new List<string>();
                var informationTarget = new List<string>();
                var realization = new List<string>();
                var realizingActivityEdge = new List<string>();
                var realizingConnector = new List<string>();
                var realizingMessage = new List<string>();

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            case "conveyed":
                                this.CollectMultiValueReferencePropertyIdentifiers(xmlReader, conveyed, "conveyed");
                                break;
                            case "informationSource":
                                this.CollectMultiValueReferencePropertyIdentifiers(xmlReader, informationSource, "informationSource");
                                break;
                            case "informationTarget":
                                this.CollectMultiValueReferencePropertyIdentifiers(xmlReader, informationTarget, "informationTarget");
                                break;
                            case "name":
                                poco.Name = xmlReader.ReadElementContentAsString();
                                break;
                            case "nameExpression":
                                var nameExpression = (IStringExpression)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:StringExpression");
                                poco.NameExpression.Add(nameExpression);
                                break;
                            case "ownedComment":
                                var ownedComment = (IComment)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Comment");
                                poco.OwnedComment.Add(ownedComment);
                                break;
                            case "owningTemplateParameter":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "owningTemplateParameter");
                                break;
                            case "realization":
                                this.CollectMultiValueReferencePropertyIdentifiers(xmlReader, realization, "realization");
                                break;
                            case "realizingActivityEdge":
                                this.CollectMultiValueReferencePropertyIdentifiers(xmlReader, realizingActivityEdge, "realizingActivityEdge");
                                break;
                            case "realizingConnector":
                                this.CollectMultiValueReferencePropertyIdentifiers(xmlReader, realizingConnector, "realizingConnector");
                                break;
                            case "realizingMessage":
                                this.CollectMultiValueReferencePropertyIdentifiers(xmlReader, realizingMessage, "realizingMessage");
                                break;
                            case "templateParameter":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "templateParameter");
                                break;
                            case "visibility":
                                var visibilityXmlElement = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(visibilityXmlElement))
                                {
                                    poco.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibilityXmlElement, true); ;
                                }
                                break;
                            default:
                                var defaultLineInfo = xmlReader as IXmlLineInfo;
                                throw new NotSupportedException($"InformationFlowReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
                        }
                    }
                }

                if (conveyed.Count > 0)
                {
                    poco.MultiValueReferencePropertyIdentifiers.Add("conveyed", conveyed);
                }

                if (informationSource.Count > 0)
                {
                    poco.MultiValueReferencePropertyIdentifiers.Add("informationSource", informationSource);
                }

                if (informationTarget.Count > 0)
                {
                    poco.MultiValueReferencePropertyIdentifiers.Add("informationTarget", informationTarget);
                }

                if (realization.Count > 0)
                {
                    poco.MultiValueReferencePropertyIdentifiers.Add("realization", realization);
                }

                if (realizingActivityEdge.Count > 0)
                {
                    poco.MultiValueReferencePropertyIdentifiers.Add("realizingActivityEdge", realizingActivityEdge);
                }

                if (realizingConnector.Count > 0)
                {
                    poco.MultiValueReferencePropertyIdentifiers.Add("realizingConnector", realizingConnector);
                }

                if (realizingMessage.Count > 0)
                {
                    poco.MultiValueReferencePropertyIdentifiers.Add("realizingMessage", realizingMessage);
                }

            }

            return poco;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
