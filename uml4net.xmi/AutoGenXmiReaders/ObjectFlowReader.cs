// -------------------------------------------------------------------------------------------------
// <copyright file="ObjectFlowReader.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Readers.Activities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    using Microsoft.Extensions.Logging;

    using uml4net;
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
    /// The purpose of the <see cref="ObjectFlowReader"/> is to read an instance of <see cref="IObjectFlow"/>
    /// from the XMI document
    /// </summary>
    public class ObjectFlowReader : XmiElementReader<IObjectFlow>, IXmiElementReader<IObjectFlow>
    {
        private readonly IXmiElementReaderFacade xmiElementReaderFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectFlowReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public ObjectFlowReader(IXmiReaderCache cache, ILoggerFactory loggerFactory)
            : base(cache, loggerFactory)
        {
            this.xmiElementReaderFacade = new XmiElementReaderFacade();
        }

        /// <summary>
        /// Reads the <see cref="IObjectFlow"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="IObjectFlow"/>
        /// </returns>
        public override IObjectFlow Read(XmlReader xmlReader)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            IObjectFlow poco = new ObjectFlow();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:ObjectFlow")
                {
                    throw new XmlException($"The XmiType should be 'uml:ObjectFlow' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:ObjectFlow";
                }

                poco.XmiType = xmiType;

                poco.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(poco.XmiId, poco);

                var activityXmlAttribute = xmlReader.GetAttribute("activity");
                if (!string.IsNullOrEmpty(activityXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("activity", activityXmlAttribute);
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

                var interruptsXmlAttribute = xmlReader.GetAttribute("interrupts");
                if (!string.IsNullOrEmpty(interruptsXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("interrupts", interruptsXmlAttribute);
                }

                var isLeafXmlAttribute = xmlReader.GetAttribute("isLeaf");
                if (!string.IsNullOrEmpty(isLeafXmlAttribute))
                {
                    poco.IsLeaf = bool.Parse(isLeafXmlAttribute);
                }

                var isMulticastXmlAttribute = xmlReader.GetAttribute("isMulticast");
                if (!string.IsNullOrEmpty(isMulticastXmlAttribute))
                {
                    poco.IsMulticast = bool.Parse(isMulticastXmlAttribute);
                }

                var isMultireceiveXmlAttribute = xmlReader.GetAttribute("isMultireceive");
                if (!string.IsNullOrEmpty(isMultireceiveXmlAttribute))
                {
                    poco.IsMultireceive = bool.Parse(isMultireceiveXmlAttribute);
                }

                poco.Name = xmlReader.GetAttribute("name");

                var redefinedEdgeXmlAttribute = xmlReader.GetAttribute("redefinedEdge");
                if (!string.IsNullOrEmpty(redefinedEdgeXmlAttribute))
                {
                    var redefinedEdgeXmlAttributeValues = redefinedEdgeXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("redefinedEdge", redefinedEdgeXmlAttributeValues);
                }

                var selectionXmlAttribute = xmlReader.GetAttribute("selection");
                if (!string.IsNullOrEmpty(selectionXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("selection", selectionXmlAttribute);
                }

                var sourceXmlAttribute = xmlReader.GetAttribute("source");
                if (!string.IsNullOrEmpty(sourceXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("source", sourceXmlAttribute);
                }

                var targetXmlAttribute = xmlReader.GetAttribute("target");
                if (!string.IsNullOrEmpty(targetXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("target", targetXmlAttribute);
                }

                var transformationXmlAttribute = xmlReader.GetAttribute("transformation");
                if (!string.IsNullOrEmpty(transformationXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("transformation", transformationXmlAttribute);
                }

                var visibilityXmlAttribute = xmlReader.GetAttribute("visibility");
                if (!string.IsNullOrEmpty(visibilityXmlAttribute))
                {
                    poco.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibilityXmlAttribute, true);
                }


                var inPartition = new List<string>();
                var redefinedEdge = new List<string>();

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            case "activity":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "activity");
                                break;
                            case "guard":
                                var guard = (IValueSpecification)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory);
                                poco.Guard.Add(guard);
                                break;
                            case "inPartition":
                                this.CollectMultiValueReferencePropertyIdentifiers(xmlReader, inPartition, "inPartition");
                                break;
                            case "inStructuredNode":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "inStructuredNode");
                                break;
                            case "interrupts":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "interrupts");
                                break;
                            case "isLeaf":
                                var isLeafXmlElement = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isLeafXmlElement))
                                {
                                    poco.IsLeaf = bool.Parse(isLeafXmlElement);
                                }
                                break;
                            case "isMulticast":
                                var isMulticastXmlElement = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isMulticastXmlElement))
                                {
                                    poco.IsMulticast = bool.Parse(isMulticastXmlElement);
                                }
                                break;
                            case "isMultireceive":
                                var isMultireceiveXmlElement = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isMultireceiveXmlElement))
                                {
                                    poco.IsMultireceive = bool.Parse(isMultireceiveXmlElement);
                                }
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
                            case "redefinedEdge":
                                this.CollectMultiValueReferencePropertyIdentifiers(xmlReader, redefinedEdge, "redefinedEdge");
                                break;
                            case "selection":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "selection");
                                break;
                            case "source":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "source");
                                break;
                            case "target":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "target");
                                break;
                            case "transformation":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "transformation");
                                break;
                            case "visibility":
                                var visibilityXmlElement = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(visibilityXmlElement))
                                {
                                    poco.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibilityXmlElement, true); ;
                                }
                                break;
                            case "weight":
                                var weight = (IValueSpecification)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory);
                                poco.Weight.Add(weight);
                                break;
                            default:
                                var defaultLineInfo = xmlReader as IXmlLineInfo;
                                throw new NotSupportedException($"ObjectFlowReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
                        }
                    }
                }

                if (inPartition.Count > 0)
                {
                    poco.MultiValueReferencePropertyIdentifiers.Add("inPartition", inPartition);
                }

                if (redefinedEdge.Count > 0)
                {
                    poco.MultiValueReferencePropertyIdentifiers.Add("redefinedEdge", redefinedEdge);
                }

            }

            return poco;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
