// -------------------------------------------------------------------------------------------------
// <copyright file="ClearAssociationActionReader.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Readers.Actions
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
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;
    using uml4net.UseCases;
    using uml4net.Utils;
    using uml4net.Values;
    using uml4net.xmi.Cache;
    using uml4net.xmi.Readers;

    /// <summary>
    /// The purpose of the <see cref="ClearAssociationActionReader"/> is to read an instance of <see cref="IClearAssociationAction"/>
    /// from the XMI document
    /// </summary>
    public class ClearAssociationActionReader : XmiElementReader<IClearAssociationAction>, IXmiElementReader<IClearAssociationAction>
    {
        private readonly IXmiElementReaderFacade xmiElementReaderFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClearAssociationActionReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public ClearAssociationActionReader(IXmiReaderCache cache, ILoggerFactory loggerFactory)
            : base(cache, loggerFactory)
        {
            this.xmiElementReaderFacade = new XmiElementReaderFacade();
        }

        /// <summary>
        /// Reads the <see cref="IClearAssociationAction"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="IClearAssociationAction"/>
        /// </returns>
        public override IClearAssociationAction Read(XmlReader xmlReader)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            IClearAssociationAction poco = new ClearAssociationAction();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:ClearAssociationAction")
                {
                    throw new XmlException($"The XmiType should be 'uml:ClearAssociationAction' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:ClearAssociationAction";
                }

                poco.XmiType = xmiType;

                poco.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(poco.XmiId, poco);

                var activityXmlAttribute = xmlReader.GetAttribute("activity");
                if (!string.IsNullOrEmpty(activityXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("activity", activityXmlAttribute);
                }

                var associationXmlAttribute = xmlReader.GetAttribute("association");
                if (!string.IsNullOrEmpty(associationXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("association", associationXmlAttribute);
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

                var inStructuredNodeXmlAttribute = xmlReader.GetAttribute("inStructuredNode");
                if (!string.IsNullOrEmpty(inStructuredNodeXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("inStructuredNode", inStructuredNodeXmlAttribute);
                }

                var isLeafXmlAttribute = xmlReader.GetAttribute("isLeaf");
                if (!string.IsNullOrEmpty(isLeafXmlAttribute))
                {
                    poco.IsLeaf = bool.Parse(isLeafXmlAttribute);
                }

                var isLocallyReentrantXmlAttribute = xmlReader.GetAttribute("isLocallyReentrant");
                if (!string.IsNullOrEmpty(isLocallyReentrantXmlAttribute))
                {
                    poco.IsLocallyReentrant = bool.Parse(isLocallyReentrantXmlAttribute);
                }

                poco.Name = xmlReader.GetAttribute("name");

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

                var visibilityXmlAttribute = xmlReader.GetAttribute("visibility");
                if (!string.IsNullOrEmpty(visibilityXmlAttribute))
                {
                    poco.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibilityXmlAttribute, true);
                }


                var incoming = new List<string>();
                var inInterruptibleRegion = new List<string>();
                var inPartition = new List<string>();
                var outgoing = new List<string>();
                var redefinedNode = new List<string>();

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            case "activity":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "activity");
                                break;
                            case "association":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "association");
                                break;
                            case "handler":
                                var handler = (IExceptionHandler)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:ExceptionHandler");
                                poco.Handler.Add(handler);
                                break;
                            case "incoming":
                                this.CollectMultiValueReferencePropertyIdentifiers(xmlReader, incoming, "incoming");
                                break;
                            case "inInterruptibleRegion":
                                this.CollectMultiValueReferencePropertyIdentifiers(xmlReader, inInterruptibleRegion, "inInterruptibleRegion");
                                break;
                            case "inPartition":
                                this.CollectMultiValueReferencePropertyIdentifiers(xmlReader, inPartition, "inPartition");
                                break;
                            case "inStructuredNode":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "inStructuredNode");
                                break;
                            case "isLeaf":
                                var isLeafXmlElement = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isLeafXmlElement))
                                {
                                    poco.IsLeaf = bool.Parse(isLeafXmlElement);
                                }
                                break;
                            case "isLocallyReentrant":
                                var isLocallyReentrantXmlElement = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isLocallyReentrantXmlElement))
                                {
                                    poco.IsLocallyReentrant = bool.Parse(isLocallyReentrantXmlElement);
                                }
                                break;
                            case "localPostcondition":
                                var localPostcondition = (IConstraint)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Constraint");
                                poco.LocalPostcondition.Add(localPostcondition);
                                break;
                            case "localPrecondition":
                                var localPrecondition = (IConstraint)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Constraint");
                                poco.LocalPrecondition.Add(localPrecondition);
                                break;
                            case "name":
                                poco.Name = xmlReader.ReadElementContentAsString();
                                break;
                            case "nameExpression":
                                var nameExpression = (IStringExpression)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:StringExpression");
                                poco.NameExpression.Add(nameExpression);
                                break;
                            case "object":
                                var @object = (IInputPin)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:InputPin");
                                poco.Object.Add(@object);
                                break;
                            case "outgoing":
                                this.CollectMultiValueReferencePropertyIdentifiers(xmlReader, outgoing, "outgoing");
                                break;
                            case "ownedComment":
                                var ownedComment = (IComment)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Comment");
                                poco.OwnedComment.Add(ownedComment);
                                break;
                            case "redefinedNode":
                                this.CollectMultiValueReferencePropertyIdentifiers(xmlReader, redefinedNode, "redefinedNode");
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
                                throw new NotSupportedException($"ClearAssociationActionReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
                        }
                    }
                }

                if (incoming.Count > 0)
                {
                    poco.MultiValueReferencePropertyIdentifiers.Add("incoming", incoming);
                }

                if (inInterruptibleRegion.Count > 0)
                {
                    poco.MultiValueReferencePropertyIdentifiers.Add("inInterruptibleRegion", inInterruptibleRegion);
                }

                if (inPartition.Count > 0)
                {
                    poco.MultiValueReferencePropertyIdentifiers.Add("inPartition", inPartition);
                }

                if (outgoing.Count > 0)
                {
                    poco.MultiValueReferencePropertyIdentifiers.Add("outgoing", outgoing);
                }

                if (redefinedNode.Count > 0)
                {
                    poco.MultiValueReferencePropertyIdentifiers.Add("redefinedNode", redefinedNode);
                }

            }

            return poco;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
