// -------------------------------------------------------------------------------------------------
// <copyright file="DecisionNodeReader.cs" company="Starion Group S.A.">
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
    using uml4net.Utils;
    using uml4net.Values;
    using uml4net.xmi.Cache;

    /// <summary>
    /// The purpose of the <see cref="DecisionNodeReader"/> is to read an instance of <see cref="IDecisionNode"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public class DecisionNodeReader : XmiElementReader<IDecisionNode>, IXmiElementReader<IDecisionNode>
    {
        private readonly IXmiElementReaderFacade xmiElementReaderFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="DecisionNodeReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public DecisionNodeReader(IXmiReaderCache cache, ILoggerFactory loggerFactory)
            : base(cache, loggerFactory)
        {
            this.xmiElementReaderFacade = new XmiElementReaderFacade();
        }

        /// <summary>
        /// Reads the <see cref="IDecisionNode"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="IDecisionNode"/>
        /// </returns>
        public override IDecisionNode Read(XmlReader xmlReader)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            var defaultLineInfo = xmlReader as IXmlLineInfo;

            IDecisionNode poco = new DecisionNode();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:DecisionNode")
                {
                    throw new XmlException($"The XmiType should be 'uml:DecisionNode' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:DecisionNode";
                }

                poco.XmiType = xmiType;

                poco.XmiId = xmlReader.GetAttribute("xmi:id");

                poco.XmiGuid = xmlReader.GetAttribute("xmi:uuid");

                this.Cache.Add(poco.XmiId, poco);

                var activityXmlAttribute = xmlReader.GetAttribute("activity");
                if (!string.IsNullOrEmpty(activityXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("activity", activityXmlAttribute);
                }

                var decisionInputXmlAttribute = xmlReader.GetAttribute("decisionInput");
                if (!string.IsNullOrEmpty(decisionInputXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("decisionInput", decisionInputXmlAttribute);
                }

                var decisionInputFlowXmlAttribute = xmlReader.GetAttribute("decisionInputFlow");
                if (!string.IsNullOrEmpty(decisionInputFlowXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("decisionInputFlow", decisionInputFlowXmlAttribute);
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


                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            case "activity":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "activity");
                                break;
                            case "decisionInput":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "decisionInput");
                                break;
                            case "decisionInputFlow":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "decisionInputFlow");
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
                            case "inStructuredNode":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "inStructuredNode");
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
                                var nameExpressionValue = (IStringExpression)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:StringExpression");
                                poco.NameExpression.Add(nameExpressionValue);
                                break;
                            case "outgoing":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "outgoing");
                                break;
                            case "ownedComment":
                                var ownedCommentValue = (IComment)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Comment");
                                poco.OwnedComment.Add(ownedCommentValue);
                                break;
                            case "redefinedNode":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "redefinedNode");
                                break;
                            case "visibility":
                                var visibilityValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(visibilityValue))
                                {
                                    poco.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibilityValue, true); ;
                                }
                                break;
                            default:
                                throw new NotSupportedException($"DecisionNodeReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
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
