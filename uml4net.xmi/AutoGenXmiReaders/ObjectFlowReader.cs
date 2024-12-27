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

namespace uml4net.xmi.Readers
{
    using System;
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
    using uml4net.Utils;
    using uml4net.Values;
    using uml4net.xmi.Cache;

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

            var defaultLineInfo = xmlReader as IXmlLineInfo;

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
                                var guardValue = (IValueSpecification)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory);
                                poco.Guard.Add(guardValue);
                                break;
                            case "inPartition":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "inPartition");
                                break;
                            case "inStructuredNode":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "inStructuredNode");
                                break;
                            case "interrupts":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "interrupts");
                                break;
                            case "isLeaf":
                                var isLeafValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isLeafValue))
                                {
                                    poco.IsLeaf = bool.Parse(isLeafValue);
                                }
                                break;
                            case "isMulticast":
                                var isMulticastValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isMulticastValue))
                                {
                                    poco.IsMulticast = bool.Parse(isMulticastValue);
                                }
                                break;
                            case "isMultireceive":
                                var isMultireceiveValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isMultireceiveValue))
                                {
                                    poco.IsMultireceive = bool.Parse(isMultireceiveValue);
                                }
                                break;
                            case "name":
                                poco.Name = xmlReader.ReadElementContentAsString();
                                break;
                            case "nameExpression":
                                var nameExpressionValue = (IStringExpression)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:StringExpression");
                                poco.NameExpression.Add(nameExpressionValue);
                                break;
                            case "ownedComment":
                                var ownedCommentValue = (IComment)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Comment");
                                poco.OwnedComment.Add(ownedCommentValue);
                                break;
                            case "redefinedEdge":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "redefinedEdge");
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
                                var visibilityValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(visibilityValue))
                                {
                                    poco.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibilityValue, true); ;
                                }
                                break;
                            case "weight":
                                var weightValue = (IValueSpecification)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory);
                                poco.Weight.Add(weightValue);
                                break;
                            default:
                                throw new NotSupportedException($"ObjectFlowReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
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
