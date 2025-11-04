// -------------------------------------------------------------------------------------------------
// <copyright file="ValuePinReader.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="ValuePinReader"/> is to read an instance of <see cref="IValuePin"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public class ValuePinReader : XmiElementReader<IValuePin>, IXmiElementReader<IValuePin>
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<ValuePinReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValuePinReader"/> class.
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
        public ValuePinReader(IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, IXmiReaderSettings xmiReaderSettings, INameSpaceResolver nameSpaceResolver, ILoggerFactory loggerFactory)
            : base(cache, xmiElementReaderFacade, xmiReaderSettings, nameSpaceResolver, loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<ValuePinReader>.Instance : loggerFactory.CreateLogger<ValuePinReader>();
        }

        /// <summary>
        /// Reads the <see cref="IValuePin"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="IValuePin"/>
        /// </param>
        /// <param name="namespaceUri">
        /// the namespace that the <see cref="IValuePin"/> belongs to
        /// </param>
        /// <returns>
        /// an instance of <see cref="IValuePin"/>
        /// </returns>
        public override IValuePin Read(XmlReader xmlReader, string documentName, string namespaceUri)
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

            IValuePin poco = new ValuePin();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.logger.LogTrace("reading ValuePin at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

                var xmiType = xmlReader.GetAttribute("type", this.NameSpaceResolver.XmiNameSpace);

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:ValuePin")
                {
                    throw new XmlException($"The XmiType should be 'uml:ValuePin' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:ValuePin";
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
                    this.logger.LogCritical("Failed to add element type [{Poco}] with id [{Id}] as it was already in the Cache. The XMI document seems to have duplicate xmi:id values", "ValuePin", poco.XmiId);
                }

                var activityXmlAttribute = xmlReader.GetAttribute("activity") ?? xmlReader.GetAttribute("activity", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(activityXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("activity", activityXmlAttribute);
                }

                var incomingXmlAttribute = xmlReader.GetAttribute("incoming") ?? xmlReader.GetAttribute("incoming", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(incomingXmlAttribute))
                {
                    var incomingXmlAttributeValues = incomingXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("incoming", incomingXmlAttributeValues);
                }

                var inInterruptibleRegionXmlAttribute = xmlReader.GetAttribute("inInterruptibleRegion") ?? xmlReader.GetAttribute("inInterruptibleRegion", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(inInterruptibleRegionXmlAttribute))
                {
                    var inInterruptibleRegionXmlAttributeValues = inInterruptibleRegionXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("inInterruptibleRegion", inInterruptibleRegionXmlAttributeValues);
                }

                var inPartitionXmlAttribute = xmlReader.GetAttribute("inPartition") ?? xmlReader.GetAttribute("inPartition", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(inPartitionXmlAttribute))
                {
                    var inPartitionXmlAttributeValues = inPartitionXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("inPartition", inPartitionXmlAttributeValues);
                }

                var inStateXmlAttribute = xmlReader.GetAttribute("inState") ?? xmlReader.GetAttribute("inState", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(inStateXmlAttribute))
                {
                    var inStateXmlAttributeValues = inStateXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("inState", inStateXmlAttributeValues);
                }

                var inStructuredNodeXmlAttribute = xmlReader.GetAttribute("inStructuredNode") ?? xmlReader.GetAttribute("inStructuredNode", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(inStructuredNodeXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("inStructuredNode", inStructuredNodeXmlAttribute);
                }

                var isControlXmlAttribute = xmlReader.GetAttribute("isControl") ?? xmlReader.GetAttribute("isControl", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(isControlXmlAttribute))
                {
                    poco.IsControl = bool.Parse(isControlXmlAttribute);
                }

                var isControlTypeXmlAttribute = xmlReader.GetAttribute("isControlType") ?? xmlReader.GetAttribute("isControlType", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(isControlTypeXmlAttribute))
                {
                    poco.IsControlType = bool.Parse(isControlTypeXmlAttribute);
                }

                var isLeafXmlAttribute = xmlReader.GetAttribute("isLeaf") ?? xmlReader.GetAttribute("isLeaf", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(isLeafXmlAttribute))
                {
                    poco.IsLeaf = bool.Parse(isLeafXmlAttribute);
                }

                var isOrderedXmlAttribute = xmlReader.GetAttribute("isOrdered") ?? xmlReader.GetAttribute("isOrdered", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(isOrderedXmlAttribute))
                {
                    poco.IsOrdered = bool.Parse(isOrderedXmlAttribute);
                }

                var isUniqueXmlAttribute = xmlReader.GetAttribute("isUnique") ?? xmlReader.GetAttribute("isUnique", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(isUniqueXmlAttribute))
                {
                    poco.IsUnique = bool.Parse(isUniqueXmlAttribute);
                }

                poco.Name = xmlReader.GetAttribute("name") ?? xmlReader.GetAttribute("name", this.NameSpaceResolver.UmlNameSpace);

                var orderingXmlAttribute = xmlReader.GetAttribute("ordering") ?? xmlReader.GetAttribute("ordering", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(orderingXmlAttribute))
                {
                    poco.Ordering = (ObjectNodeOrderingKind)Enum.Parse(typeof(ObjectNodeOrderingKind), orderingXmlAttribute, true);
                }

                var outgoingXmlAttribute = xmlReader.GetAttribute("outgoing") ?? xmlReader.GetAttribute("outgoing", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(outgoingXmlAttribute))
                {
                    var outgoingXmlAttributeValues = outgoingXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("outgoing", outgoingXmlAttributeValues);
                }

                var redefinedNodeXmlAttribute = xmlReader.GetAttribute("redefinedNode") ?? xmlReader.GetAttribute("redefinedNode", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(redefinedNodeXmlAttribute))
                {
                    var redefinedNodeXmlAttributeValues = redefinedNodeXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("redefinedNode", redefinedNodeXmlAttributeValues);
                }

                var selectionXmlAttribute = xmlReader.GetAttribute("selection") ?? xmlReader.GetAttribute("selection", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(selectionXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("selection", selectionXmlAttribute);
                }

                var typeXmlAttribute = xmlReader.GetAttribute("type") ?? xmlReader.GetAttribute("type", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(typeXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("type", typeXmlAttribute);
                }

                var visibilityXmlAttribute = xmlReader.GetAttribute("visibility") ?? xmlReader.GetAttribute("visibility", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(visibilityXmlAttribute))
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
                            case (KnowNamespacePrefixes.Uml, "activity"):
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "activity");
                                break;
                            case (KnowNamespacePrefixes.Uml, "incoming"):
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "incoming");
                                break;
                            case (KnowNamespacePrefixes.Uml, "inInterruptibleRegion"):
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "inInterruptibleRegion");
                                break;
                            case (KnowNamespacePrefixes.Uml, "inPartition"):
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "inPartition");
                                break;
                            case (KnowNamespacePrefixes.Uml, "inState"):
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "inState");
                                break;
                            case (KnowNamespacePrefixes.Uml, "inStructuredNode"):
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "inStructuredNode");
                                break;
                            case (KnowNamespacePrefixes.Uml, "isControl"):
                                var isControlValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrWhiteSpace(isControlValue))
                                {
                                    poco.IsControl = bool.Parse(isControlValue);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "isControlType"):
                                var isControlTypeValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrWhiteSpace(isControlTypeValue))
                                {
                                    poco.IsControlType = bool.Parse(isControlTypeValue);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "isLeaf"):
                                var isLeafValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrWhiteSpace(isLeafValue))
                                {
                                    poco.IsLeaf = bool.Parse(isLeafValue);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "isOrdered"):
                                var isOrderedValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrWhiteSpace(isOrderedValue))
                                {
                                    poco.IsOrdered = bool.Parse(isOrderedValue);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "isUnique"):
                                var isUniqueValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrWhiteSpace(isUniqueValue))
                                {
                                    poco.IsUnique = bool.Parse(isUniqueValue);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "lowerValue"):
                                var lowerValueValue = (IValueSpecification)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory);
                                poco.LowerValue.Add(lowerValueValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "name"):
                                poco.Name = xmlReader.ReadElementContentAsString();
                                break;
                            case (KnowNamespacePrefixes.Uml, "nameExpression"):
                                var nameExpressionValue = (IStringExpression)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "uml:StringExpression");
                                poco.NameExpression.Add(nameExpressionValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "ordering"):
                                var orderingValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrWhiteSpace(orderingValue))
                                {
                                    poco.Ordering = (ObjectNodeOrderingKind)Enum.Parse(typeof(ObjectNodeOrderingKind), orderingValue, true);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "outgoing"):
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "outgoing");
                                break;
                            case (KnowNamespacePrefixes.Uml, "ownedComment"):
                                var ownedCommentValue = (IComment)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "uml:Comment");
                                poco.OwnedComment.Add(ownedCommentValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "redefinedNode"):
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "redefinedNode");
                                break;
                            case (KnowNamespacePrefixes.Uml, "selection"):
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "selection");
                                break;
                            case (KnowNamespacePrefixes.Uml, "type"):
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "type");
                                break;
                            case (KnowNamespacePrefixes.Uml, "upperBound"):
                                var upperBoundValue = (IValueSpecification)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory);
                                poco.UpperBound.Add(upperBoundValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "upperValue"):
                                var upperValueValue = (IValueSpecification)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory);
                                poco.UpperValue.Add(upperValueValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "value"):
                                var valueValue = (IValueSpecification)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory);
                                poco.Value.Add(valueValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "visibility"):
                                var visibilityValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrWhiteSpace(visibilityValue))
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
                                    throw new NotSupportedException($"ValuePinReader: {xmlReader.LocalName} at line:position {xmlLineInfo.LineNumber}:{xmlLineInfo.LinePosition}");
                                }
                                else
                                {
                                    this.logger.LogWarning("Not Supported: ValuePinReader: {LocalName} at line:position {LineNumber}:{LinePosition}", xmlReader.LocalName, xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);
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
