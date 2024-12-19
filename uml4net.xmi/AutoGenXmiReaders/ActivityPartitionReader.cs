// -------------------------------------------------------------------------------------------------
// <copyright file="ActivityPartitionReader.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="ActivityPartitionReader"/> is to read an instance of <see cref="IActivityPartition"/>
    /// from the XMI document
    /// </summary>
    public class ActivityPartitionReader : XmiElementReader<IActivityPartition>, IXmiElementReader<IActivityPartition>
    {
        private readonly IXmiElementReaderFacade xmiElementReaderFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityPartitionReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public ActivityPartitionReader(IXmiReaderCache cache, ILoggerFactory loggerFactory)
            : base(cache, loggerFactory)
        {
            this.xmiElementReaderFacade = new XmiElementReaderFacade();
        }

        /// <summary>
        /// Reads the <see cref="IActivityPartition"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="IActivityPartition"/>
        /// </returns>
        public override IActivityPartition Read(XmlReader xmlReader)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            IActivityPartition poco = new ActivityPartition();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:ActivityPartition")
                {
                    throw new XmlException($"The XmiType should be 'uml:ActivityPartition' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:ActivityPartition";
                }

                poco.XmiType = xmiType;

                poco.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(poco.XmiId, poco);

                var edgeXmlAttribute = xmlReader.GetAttribute("edge");
                if (!string.IsNullOrEmpty(edgeXmlAttribute))
                {
                    var edgeXmlAttributeValues = edgeXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("edge", edgeXmlAttributeValues);
                }

                var inActivityXmlAttribute = xmlReader.GetAttribute("inActivity");
                if (!string.IsNullOrEmpty(inActivityXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("inActivity", inActivityXmlAttribute);
                }

                var isDimensionXmlAttribute = xmlReader.GetAttribute("isDimension");
                if (!string.IsNullOrEmpty(isDimensionXmlAttribute))
                {
                    poco.IsDimension = bool.Parse(isDimensionXmlAttribute);
                }

                var isExternalXmlAttribute = xmlReader.GetAttribute("isExternal");
                if (!string.IsNullOrEmpty(isExternalXmlAttribute))
                {
                    poco.IsExternal = bool.Parse(isExternalXmlAttribute);
                }

                poco.Name = xmlReader.GetAttribute("name");

                var nodeXmlAttribute = xmlReader.GetAttribute("node");
                if (!string.IsNullOrEmpty(nodeXmlAttribute))
                {
                    var nodeXmlAttributeValues = nodeXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("node", nodeXmlAttributeValues);
                }

                var representsXmlAttribute = xmlReader.GetAttribute("represents");
                if (!string.IsNullOrEmpty(representsXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("represents", representsXmlAttribute);
                }

                var superPartitionXmlAttribute = xmlReader.GetAttribute("superPartition");
                if (!string.IsNullOrEmpty(superPartitionXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("superPartition", superPartitionXmlAttribute);
                }

                var visibilityXmlAttribute = xmlReader.GetAttribute("visibility");
                if (!string.IsNullOrEmpty(visibilityXmlAttribute))
                {
                    poco.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibilityXmlAttribute, true);
                }


                var edge = new List<string>();
                var node = new List<string>();

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            case "edge":
                                this.CollectMultiValueReferencePropertyIdentifiers(xmlReader, edge, "edge");
                                break;
                            case "inActivity":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "inActivity");
                                break;
                            case "isDimension":
                                var isDimensionXmlElement = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isDimensionXmlElement))
                                {
                                    poco.IsDimension = bool.Parse(isDimensionXmlElement);
                                }
                                break;
                            case "isExternal":
                                var isExternalXmlElement = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isExternalXmlElement))
                                {
                                    poco.IsExternal = bool.Parse(isExternalXmlElement);
                                }
                                break;
                            case "name":
                                poco.Name = xmlReader.ReadElementContentAsString();
                                break;
                            case "nameExpression":
                                var nameExpression = (IStringExpression)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:StringExpression");
                                poco.NameExpression.Add(nameExpression);
                                break;
                            case "node":
                                this.CollectMultiValueReferencePropertyIdentifiers(xmlReader, node, "node");
                                break;
                            case "ownedComment":
                                var ownedComment = (IComment)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Comment");
                                poco.OwnedComment.Add(ownedComment);
                                break;
                            case "represents":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "represents");
                                break;
                            case "subpartition":
                                var subpartition = (IActivityPartition)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:ActivityPartition");
                                poco.Subpartition.Add(subpartition);
                                break;
                            case "superPartition":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "superPartition");
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
                                throw new NotSupportedException($"ActivityPartitionReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
                        }
                    }
                }

                if (edge.Count > 0)
                {
                    poco.MultiValueReferencePropertyIdentifiers.Add("edge", edge);
                }

                if (node.Count > 0)
                {
                    poco.MultiValueReferencePropertyIdentifiers.Add("node", node);
                }

            }

            return poco;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
