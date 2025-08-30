// -------------------------------------------------------------------------------------------------
// <copyright file="MessageReader.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="MessageReader"/> is to read an instance of <see cref="IMessage"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public class MessageReader : XmiElementReader<IMessage>, IXmiElementReader<IMessage>
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<MessageReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageReader"/> class.
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
        public MessageReader(IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, IXmiReaderSettings xmiReaderSettings, ILoggerFactory loggerFactory)
            : base(cache, xmiElementReaderFacade, xmiReaderSettings, loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<MessageReader>.Instance : loggerFactory.CreateLogger<MessageReader>();
        }

        /// <summary>
        /// Reads the <see cref="IMessage"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="IMessage"/>
        /// </param>
        /// <param name="namespaceUri">
        /// the namespace that the <see cref="IMessage"/> belongs to
        /// </param>
        /// <returns>
        /// an instance of <see cref="IMessage"/>
        /// </returns>
        public override IMessage Read(XmlReader xmlReader, string documentName, string namespaceUri)
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

            IMessage poco = new Message();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.logger.LogTrace("reading Message at line:position {LineNumber}:{LinePosition}", xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);

                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:Message")
                {
                    throw new XmlException($"The XmiType should be 'uml:Message' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:Message";
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
                    this.logger.LogCritical("Failed to add element type [{Poco}] with id [{Id}] as it was already in the Cache. The XMI document seems to have duplicate xmi:id values", "Message", poco.XmiId);
                }

                var connectorXmlAttribute = xmlReader.GetAttribute("connector");

                if (!string.IsNullOrEmpty(connectorXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("connector", connectorXmlAttribute);
                }

                var interactionXmlAttribute = xmlReader.GetAttribute("interaction");

                if (!string.IsNullOrEmpty(interactionXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("interaction", interactionXmlAttribute);
                }

                var messageSortXmlAttribute = xmlReader.GetAttribute("messageSort");

                if (!string.IsNullOrEmpty(messageSortXmlAttribute))
                {
                    poco.MessageSort = (MessageSort)Enum.Parse(typeof(MessageSort), messageSortXmlAttribute, true);
                }

                poco.Name = xmlReader.GetAttribute("name");

                var receiveEventXmlAttribute = xmlReader.GetAttribute("receiveEvent");

                if (!string.IsNullOrEmpty(receiveEventXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("receiveEvent", receiveEventXmlAttribute);
                }

                var sendEventXmlAttribute = xmlReader.GetAttribute("sendEvent");

                if (!string.IsNullOrEmpty(sendEventXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("sendEvent", sendEventXmlAttribute);
                }

                var signatureXmlAttribute = xmlReader.GetAttribute("signature");

                if (!string.IsNullOrEmpty(signatureXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("signature", signatureXmlAttribute);
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
                            case "argument":
                                var argumentValue = (IValueSpecification)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory);
                                poco.Argument.Add(argumentValue);
                                break;
                            case "connector":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "connector");
                                break;
                            case "interaction":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "interaction");
                                break;
                            case "messageSort":
                                var messageSortValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(messageSortValue))
                                {
                                    poco.MessageSort = (MessageSort)Enum.Parse(typeof(MessageSort), messageSortValue, true);
                                }

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
                            case "receiveEvent":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "receiveEvent");
                                break;
                            case "sendEvent":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "sendEvent");
                                break;
                            case "signature":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "signature");
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
                                    throw new NotSupportedException($"MessageReader: {xmlReader.LocalName} at line:position {xmlLineInfo.LineNumber}:{xmlLineInfo.LinePosition}");
                                }
                                else
                                {
                                    this.logger.LogWarning("Not Supported: MessageReader: {LocalName} at line:position {LineNumber}:{LinePosition}", xmlReader.LocalName, xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);
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
