// -------------------------------------------------------------------------------------------------
// <copyright file="ExpansionRegionReader.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="ExpansionRegionReader"/> is to read an instance of <see cref="IExpansionRegion"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public class ExpansionRegionReader : XmiElementReader<IExpansionRegion>, IXmiElementReader<IExpansionRegion>
    {
        private readonly IXmiElementReaderFacade xmiElementReaderFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpansionRegionReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public ExpansionRegionReader(IXmiReaderCache cache, ILoggerFactory loggerFactory)
            : base(cache, loggerFactory)
        {
            this.xmiElementReaderFacade = new XmiElementReaderFacade();
        }

        /// <summary>
        /// Reads the <see cref="IExpansionRegion"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="IExpansionRegion"/>
        /// </returns>
        public override IExpansionRegion Read(XmlReader xmlReader)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            var defaultLineInfo = xmlReader as IXmlLineInfo;

            IExpansionRegion poco = new ExpansionRegion();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:ExpansionRegion")
                {
                    throw new XmlException($"The XmiType should be 'uml:ExpansionRegion' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:ExpansionRegion";
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

                var inputElementXmlAttribute = xmlReader.GetAttribute("inputElement");
                if (!string.IsNullOrEmpty(inputElementXmlAttribute))
                {
                    var inputElementXmlAttributeValues = inputElementXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("inputElement", inputElementXmlAttributeValues);
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

                var modeXmlAttribute = xmlReader.GetAttribute("mode");
                if (!string.IsNullOrEmpty(modeXmlAttribute))
                {
                    poco.Mode = (ExpansionKind)Enum.Parse(typeof(ExpansionKind), modeXmlAttribute, true);
                }

                var mustIsolateXmlAttribute = xmlReader.GetAttribute("mustIsolate");
                if (!string.IsNullOrEmpty(mustIsolateXmlAttribute))
                {
                    poco.MustIsolate = bool.Parse(mustIsolateXmlAttribute);
                }

                poco.Name = xmlReader.GetAttribute("name");

                var outgoingXmlAttribute = xmlReader.GetAttribute("outgoing");
                if (!string.IsNullOrEmpty(outgoingXmlAttribute))
                {
                    var outgoingXmlAttributeValues = outgoingXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("outgoing", outgoingXmlAttributeValues);
                }

                var outputElementXmlAttribute = xmlReader.GetAttribute("outputElement");
                if (!string.IsNullOrEmpty(outputElementXmlAttribute))
                {
                    var outputElementXmlAttributeValues = outputElementXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("outputElement", outputElementXmlAttributeValues);
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
                            case "edge":
                                var edgeValue = (IActivityEdge)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory);
                                poco.Edge.Add(edgeValue);
                                break;
                            case "elementImport":
                                var elementImportValue = (IElementImport)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:ElementImport");
                                poco.ElementImport.Add(elementImportValue);
                                break;
                            case "handler":
                                var handlerValue = (IExceptionHandler)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:ExceptionHandler");
                                poco.Handler.Add(handlerValue);
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
                            case "inputElement":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "inputElement");
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
                            case "isLocallyReentrant":
                                var isLocallyReentrantValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isLocallyReentrantValue))
                                {
                                    poco.IsLocallyReentrant = bool.Parse(isLocallyReentrantValue);
                                }
                                break;
                            case "localPostcondition":
                                var localPostconditionValue = (IConstraint)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Constraint");
                                poco.LocalPostcondition.Add(localPostconditionValue);
                                break;
                            case "localPrecondition":
                                var localPreconditionValue = (IConstraint)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Constraint");
                                poco.LocalPrecondition.Add(localPreconditionValue);
                                break;
                            case "mode":
                                var modeValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(modeValue))
                                {
                                    poco.Mode = (ExpansionKind)Enum.Parse(typeof(ExpansionKind), modeValue, true); ;
                                }
                                break;
                            case "mustIsolate":
                                var mustIsolateValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(mustIsolateValue))
                                {
                                    poco.MustIsolate = bool.Parse(mustIsolateValue);
                                }
                                break;
                            case "name":
                                poco.Name = xmlReader.ReadElementContentAsString();
                                break;
                            case "nameExpression":
                                var nameExpressionValue = (IStringExpression)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:StringExpression");
                                poco.NameExpression.Add(nameExpressionValue);
                                break;
                            case "node":
                                var nodeValue = (IActivityNode)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory);
                                poco.Node.Add(nodeValue);
                                break;
                            case "outgoing":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "outgoing");
                                break;
                            case "outputElement":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "outputElement");
                                break;
                            case "ownedComment":
                                var ownedCommentValue = (IComment)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Comment");
                                poco.OwnedComment.Add(ownedCommentValue);
                                break;
                            case "ownedRule":
                                var ownedRuleValue = (IConstraint)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Constraint");
                                poco.OwnedRule.Add(ownedRuleValue);
                                break;
                            case "packageImport":
                                var packageImportValue = (IPackageImport)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:PackageImport");
                                poco.PackageImport.Add(packageImportValue);
                                break;
                            case "redefinedNode":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "redefinedNode");
                                break;
                            case "structuredNodeInput":
                                var structuredNodeInputValue = (IInputPin)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:InputPin");
                                poco.StructuredNodeInput.Add(structuredNodeInputValue);
                                break;
                            case "structuredNodeOutput":
                                var structuredNodeOutputValue = (IOutputPin)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:OutputPin");
                                poco.StructuredNodeOutput.Add(structuredNodeOutputValue);
                                break;
                            case "variable":
                                var variableValue = (IVariable)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Variable");
                                poco.Variable.Add(variableValue);
                                break;
                            case "visibility":
                                var visibilityValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(visibilityValue))
                                {
                                    poco.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibilityValue, true); ;
                                }
                                break;
                            default:
                                throw new NotSupportedException($"ExpansionRegionReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
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
