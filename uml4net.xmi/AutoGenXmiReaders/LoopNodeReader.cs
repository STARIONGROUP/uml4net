// -------------------------------------------------------------------------------------------------
// <copyright file="LoopNodeReader.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="LoopNodeReader"/> is to read an instance of <see cref="ILoopNode"/>
    /// from the XMI document
    /// </summary>
    public class LoopNodeReader : XmiElementReader<ILoopNode>, IXmiElementReader<ILoopNode>
    {
        private readonly IXmiElementReaderFacade xmiElementReaderFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoopNodeReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public LoopNodeReader(IXmiReaderCache cache, ILoggerFactory loggerFactory)
            : base(cache, loggerFactory)
        {
            this.xmiElementReaderFacade = new XmiElementReaderFacade();
        }

        /// <summary>
        /// Reads the <see cref="ILoopNode"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="ILoopNode"/>
        /// </returns>
        public override ILoopNode Read(XmlReader xmlReader)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            ILoopNode poco = new LoopNode();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:LoopNode")
                {
                    throw new XmlException($"The XmiType should be 'uml:LoopNode' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:LoopNode";
                }

                poco.XmiType = xmiType;

                poco.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(poco.XmiId, poco);

                var activityXmlAttribute = xmlReader.GetAttribute("activity");
                if (!string.IsNullOrEmpty(activityXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("activity", activityXmlAttribute);
                }

                var bodyOutputXmlAttribute = xmlReader.GetAttribute("bodyOutput");
                if (!string.IsNullOrEmpty(bodyOutputXmlAttribute))
                {
                    var bodyOutputXmlAttributeValues = bodyOutputXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("bodyOutput", bodyOutputXmlAttributeValues);
                }

                var bodyPartXmlAttribute = xmlReader.GetAttribute("bodyPart");
                if (!string.IsNullOrEmpty(bodyPartXmlAttribute))
                {
                    var bodyPartXmlAttributeValues = bodyPartXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("bodyPart", bodyPartXmlAttributeValues);
                }

                var deciderXmlAttribute = xmlReader.GetAttribute("decider");
                if (!string.IsNullOrEmpty(deciderXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("decider", deciderXmlAttribute);
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

                var isTestedFirstXmlAttribute = xmlReader.GetAttribute("isTestedFirst");
                if (!string.IsNullOrEmpty(isTestedFirstXmlAttribute))
                {
                    poco.IsTestedFirst = bool.Parse(isTestedFirstXmlAttribute);
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

                var redefinedNodeXmlAttribute = xmlReader.GetAttribute("redefinedNode");
                if (!string.IsNullOrEmpty(redefinedNodeXmlAttribute))
                {
                    var redefinedNodeXmlAttributeValues = redefinedNodeXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("redefinedNode", redefinedNodeXmlAttributeValues);
                }

                var setupPartXmlAttribute = xmlReader.GetAttribute("setupPart");
                if (!string.IsNullOrEmpty(setupPartXmlAttribute))
                {
                    var setupPartXmlAttributeValues = setupPartXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("setupPart", setupPartXmlAttributeValues);
                }

                var testXmlAttribute = xmlReader.GetAttribute("test");
                if (!string.IsNullOrEmpty(testXmlAttribute))
                {
                    var testXmlAttributeValues = testXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("test", testXmlAttributeValues);
                }

                var visibilityXmlAttribute = xmlReader.GetAttribute("visibility");
                if (!string.IsNullOrEmpty(visibilityXmlAttribute))
                {
                    poco.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibilityXmlAttribute, true);
                }


                var bodyOutput = new List<string>();
                var bodyPart = new List<string>();
                var incoming = new List<string>();
                var inInterruptibleRegion = new List<string>();
                var inPartition = new List<string>();
                var outgoing = new List<string>();
                var redefinedNode = new List<string>();
                var setupPart = new List<string>();
                var test = new List<string>();

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            case "activity":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "activity");
                                break;
                            case "bodyOutput":
                                this.CollectMultiValueReferencePropertyIdentifiers(xmlReader, bodyOutput, "bodyOutput");
                                break;
                            case "bodyPart":
                                this.CollectMultiValueReferencePropertyIdentifiers(xmlReader, bodyPart, "bodyPart");
                                break;
                            case "decider":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "decider");
                                break;
                            case "edge":
                                var edge = (IActivityEdge)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory);
                                poco.Edge.Add(edge);
                                break;
                            case "elementImport":
                                var elementImport = (IElementImport)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:ElementImport");
                                poco.ElementImport.Add(elementImport);
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
                            case "isTestedFirst":
                                var isTestedFirstXmlElement = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isTestedFirstXmlElement))
                                {
                                    poco.IsTestedFirst = bool.Parse(isTestedFirstXmlElement);
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
                            case "loopVariable":
                                var loopVariable = (IOutputPin)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:OutputPin");
                                poco.LoopVariable.Add(loopVariable);
                                break;
                            case "loopVariableInput":
                                var loopVariableInput = (IInputPin)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:InputPin");
                                poco.LoopVariableInput.Add(loopVariableInput);
                                break;
                            case "mustIsolate":
                                var mustIsolateXmlElement = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(mustIsolateXmlElement))
                                {
                                    poco.MustIsolate = bool.Parse(mustIsolateXmlElement);
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
                                var node = (IActivityNode)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory);
                                poco.Node.Add(node);
                                break;
                            case "outgoing":
                                this.CollectMultiValueReferencePropertyIdentifiers(xmlReader, outgoing, "outgoing");
                                break;
                            case "ownedComment":
                                var ownedComment = (IComment)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Comment");
                                poco.OwnedComment.Add(ownedComment);
                                break;
                            case "ownedRule":
                                var ownedRule = (IConstraint)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Constraint");
                                poco.OwnedRule.Add(ownedRule);
                                break;
                            case "packageImport":
                                var packageImport = (IPackageImport)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:PackageImport");
                                poco.PackageImport.Add(packageImport);
                                break;
                            case "redefinedNode":
                                this.CollectMultiValueReferencePropertyIdentifiers(xmlReader, redefinedNode, "redefinedNode");
                                break;
                            case "result":
                                var result = (IOutputPin)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:OutputPin");
                                poco.Result.Add(result);
                                break;
                            case "setupPart":
                                this.CollectMultiValueReferencePropertyIdentifiers(xmlReader, setupPart, "setupPart");
                                break;
                            case "test":
                                this.CollectMultiValueReferencePropertyIdentifiers(xmlReader, test, "test");
                                break;
                            case "variable":
                                var variable = (IVariable)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Variable");
                                poco.Variable.Add(variable);
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
                                throw new NotSupportedException($"LoopNodeReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
                        }
                    }
                }

                if (bodyOutput.Count > 0)
                {
                    poco.MultiValueReferencePropertyIdentifiers.Add("bodyOutput", bodyOutput);
                }

                if (bodyPart.Count > 0)
                {
                    poco.MultiValueReferencePropertyIdentifiers.Add("bodyPart", bodyPart);
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

                if (setupPart.Count > 0)
                {
                    poco.MultiValueReferencePropertyIdentifiers.Add("setupPart", setupPart);
                }

                if (test.Count > 0)
                {
                    poco.MultiValueReferencePropertyIdentifiers.Add("test", test);
                }

            }

            return poco;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
