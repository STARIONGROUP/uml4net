// -------------------------------------------------------------------------------------------------
// <copyright file="ExpansionNodeReader.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="ExpansionNodeReader"/> is to read an instance of <see cref="IExpansionNode"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public class ExpansionNodeReader : XmiElementReader<IExpansionNode>, IXmiElementReader<IExpansionNode>
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<ExpansionNodeReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpansionNodeReader"/> class.
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
        public ExpansionNodeReader(IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, IXmiReaderSettings xmiReaderSettings, ILoggerFactory loggerFactory)
            : base(cache, xmiElementReaderFacade, xmiReaderSettings, loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<ExpansionNodeReader>.Instance : loggerFactory.CreateLogger<ExpansionNodeReader>();
        }

        /// <summary>
        /// Reads the <see cref="IExpansionNode"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="IExpansionNode"/>
        /// </param>
        /// <param name="namespaceUri">
        /// the namespace that the <see cref="IExpansionNode"/> belongs to
        /// </param>
        /// <returns>
        /// an instance of <see cref="IExpansionNode"/>
        /// </returns>
        public override IExpansionNode Read(XmlReader xmlReader, string documentName, string namespaceUri)
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

            IExpansionNode poco = new ExpansionNode();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.logger.LogTrace("reading ExpansionNode at line:position {LineNumber}:{LinePosition}", xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);

                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:ExpansionNode")
                {
                    throw new XmlException($"The XmiType should be 'uml:ExpansionNode' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:ExpansionNode";
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
                    this.logger.LogCritical("Failed to add element type [{Poco}] with id [{Id}] as it was already in the Cache. The XMI document seems to have duplicate xmi:id values", "ExpansionNode", poco.XmiId);
                }

                var activityXmlAttribute = xmlReader.GetAttribute("activity");

                if (!string.IsNullOrEmpty(activityXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("activity", activityXmlAttribute);
                }

                var incomingXmlAttribute = xmlReader.GetAttribute("incoming");

                if (!string.IsNullOrEmpty(incomingXmlAttribute))
                {
                    var incomingXmlAttributeValues = incomingXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("incoming", incomingXmlAttributeValues);
                }

                var inInterruptibleRegionXmlAttribute = xmlReader.GetAttribute("inInterruptibleRegion");

                if (!string.IsNullOrEmpty(inInterruptibleRegionXmlAttribute))
                {
                    var inInterruptibleRegionXmlAttributeValues = inInterruptibleRegionXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("inInterruptibleRegion", inInterruptibleRegionXmlAttributeValues);
                }

                var inPartitionXmlAttribute = xmlReader.GetAttribute("inPartition");

                if (!string.IsNullOrEmpty(inPartitionXmlAttribute))
                {
                    var inPartitionXmlAttributeValues = inPartitionXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("inPartition", inPartitionXmlAttributeValues);
                }

                var inStateXmlAttribute = xmlReader.GetAttribute("inState");

                if (!string.IsNullOrEmpty(inStateXmlAttribute))
                {
                    var inStateXmlAttributeValues = inStateXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("inState", inStateXmlAttributeValues);
                }

                var inStructuredNodeXmlAttribute = xmlReader.GetAttribute("inStructuredNode");

                if (!string.IsNullOrEmpty(inStructuredNodeXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("inStructuredNode", inStructuredNodeXmlAttribute);
                }

                var isControlTypeXmlAttribute = xmlReader.GetAttribute("isControlType");

                if (!string.IsNullOrEmpty(isControlTypeXmlAttribute))
                {
                    poco.IsControlType = bool.Parse(isControlTypeXmlAttribute);
                }

                var isLeafXmlAttribute = xmlReader.GetAttribute("isLeaf");

                if (!string.IsNullOrEmpty(isLeafXmlAttribute))
                {
                    poco.IsLeaf = bool.Parse(isLeafXmlAttribute);
                }

                poco.Name = xmlReader.GetAttribute("name");

                var orderingXmlAttribute = xmlReader.GetAttribute("ordering");

                if (!string.IsNullOrEmpty(orderingXmlAttribute))
                {
                    poco.Ordering = (ObjectNodeOrderingKind)Enum.Parse(typeof(ObjectNodeOrderingKind), orderingXmlAttribute, true);
                }

                var outgoingXmlAttribute = xmlReader.GetAttribute("outgoing");

                if (!string.IsNullOrEmpty(outgoingXmlAttribute))
                {
                    var outgoingXmlAttributeValues = outgoingXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("outgoing", outgoingXmlAttributeValues);
                }

                var redefinedNodeXmlAttribute = xmlReader.GetAttribute("redefinedNode");

                if (!string.IsNullOrEmpty(redefinedNodeXmlAttribute))
                {
                    var redefinedNodeXmlAttributeValues = redefinedNodeXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("redefinedNode", redefinedNodeXmlAttributeValues);
                }

                var regionAsInputXmlAttribute = xmlReader.GetAttribute("regionAsInput");

                if (!string.IsNullOrEmpty(regionAsInputXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("regionAsInput", regionAsInputXmlAttribute);
                }

                var regionAsOutputXmlAttribute = xmlReader.GetAttribute("regionAsOutput");

                if (!string.IsNullOrEmpty(regionAsOutputXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("regionAsOutput", regionAsOutputXmlAttribute);
                }

                var selectionXmlAttribute = xmlReader.GetAttribute("selection");

                if (!string.IsNullOrEmpty(selectionXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("selection", selectionXmlAttribute);
                }

                var typeXmlAttribute = xmlReader.GetAttribute("type");

                if (!string.IsNullOrEmpty(typeXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("type", typeXmlAttribute);
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
                            case "activity":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "activity");
                                break;
                            case "incoming":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "incoming");
                                break;
                            case "inInterruptibleRegion":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "inInterruptibleRegion");
                                break;
                            case "inPartition":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "inPartition");
                                break;
                            case "inState":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "inState");
                                break;
                            case "inStructuredNode":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "inStructuredNode");
                                break;
                            case "isControlType":
                                var isControlTypeValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(isControlTypeValue))
                                {
                                    poco.IsControlType = bool.Parse(isControlTypeValue);
                                }

                                break;
                            case "isLeaf":
                                var isLeafValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(isLeafValue))
                                {
                                    poco.IsLeaf = bool.Parse(isLeafValue);
                                }

                                break;
                            case "name":
                                poco.Name = xmlReader.ReadElementContentAsString();
                                break;
                            case "nameExpression":
                                var nameExpressionValue = (IStringExpression)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "uml:StringExpression");
                                poco.NameExpression.Add(nameExpressionValue);
                                break;
                            case "ordering":
                                var orderingValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(orderingValue))
                                {
                                    poco.Ordering = (ObjectNodeOrderingKind)Enum.Parse(typeof(ObjectNodeOrderingKind), orderingValue, true);
                                }

                                break;
                            case "outgoing":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "outgoing");
                                break;
                            case "ownedComment":
                                var ownedCommentValue = (IComment)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "uml:Comment");
                                poco.OwnedComment.Add(ownedCommentValue);
                                break;
                            case "redefinedNode":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "redefinedNode");
                                break;
                            case "regionAsInput":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "regionAsInput");
                                break;
                            case "regionAsOutput":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "regionAsOutput");
                                break;
                            case "selection":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "selection");
                                break;
                            case "type":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "type");
                                break;
                            case "upperBound":
                                var upperBoundValue = (IValueSpecification)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory);
                                poco.UpperBound.Add(upperBoundValue);
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
                                    throw new NotSupportedException($"ExpansionNodeReader: {xmlReader.LocalName} at line:position {xmlLineInfo.LineNumber}:{xmlLineInfo.LinePosition}");
                                }
                                else
                                {
                                    this.logger.LogWarning("Not Supported: ExpansionNodeReader: {LocalName} at line:position {LineNumber}:{LinePosition}", xmlReader.LocalName, xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);
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
