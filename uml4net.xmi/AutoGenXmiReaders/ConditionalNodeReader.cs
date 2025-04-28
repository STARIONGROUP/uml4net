// -------------------------------------------------------------------------------------------------
// <copyright file="ConditionalNodeReader.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="ConditionalNodeReader"/> is to read an instance of <see cref="IConditionalNode"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public class ConditionalNodeReader : XmiElementReader<IConditionalNode>, IXmiElementReader<IConditionalNode>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConditionalNodeReader"/> class.
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
        public ConditionalNodeReader(IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, IXmiReaderSettings xmiReaderSettings, ILoggerFactory loggerFactory)
            : base(cache, xmiElementReaderFacade, xmiReaderSettings, loggerFactory)
        {
        }

        /// <summary>
        /// Reads the <see cref="IConditionalNode"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="IConditionalNode"/>
        /// </param>
        /// <param name="namespaceUri">
        /// the namespace that the <see cref="IConditionalNode"/> belongs to
        /// </param>
        /// <returns>
        /// an instance of <see cref="IConditionalNode"/>
        /// </returns>
        public override IConditionalNode Read(XmlReader xmlReader, string documentName, string namespaceUri)
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

            var defaultLineInfo = xmlReader as IXmlLineInfo;

            IConditionalNode poco = new ConditionalNode();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:ConditionalNode")
                {
                    throw new XmlException($"The XmiType should be 'uml:ConditionalNode' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:ConditionalNode";
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
                    this.Logger.LogCritical("Failed to add element type [{Poco}] with id [{Id}] as it was already in the Cache. The XMI document seems to have duplicate xmi:id values", "ConditionalNode", poco.XmiId);
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

                var inStructuredNodeXmlAttribute = xmlReader.GetAttribute("inStructuredNode");

                if (!string.IsNullOrEmpty(inStructuredNodeXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("inStructuredNode", inStructuredNodeXmlAttribute);
                }

                var isAssuredXmlAttribute = xmlReader.GetAttribute("isAssured");

                if (!string.IsNullOrEmpty(isAssuredXmlAttribute))
                {
                    poco.IsAssured = bool.Parse(isAssuredXmlAttribute);
                }

                var isDeterminateXmlAttribute = xmlReader.GetAttribute("isDeterminate");

                if (!string.IsNullOrEmpty(isDeterminateXmlAttribute))
                {
                    poco.IsDeterminate = bool.Parse(isDeterminateXmlAttribute);
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
                            case "clause":
                                var clauseValue = (IClause)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "uml:Clause");
                                poco.Clause.Add(clauseValue);
                                break;
                            case "edge":
                                var edgeValue = (IActivityEdge)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory);
                                poco.Edge.Add(edgeValue);
                                break;
                            case "elementImport":
                                var elementImportValue = (IElementImport)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "uml:ElementImport");
                                poco.ElementImport.Add(elementImportValue);
                                break;
                            case "handler":
                                var handlerValue = (IExceptionHandler)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "uml:ExceptionHandler");
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
                            case "inStructuredNode":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "inStructuredNode");
                                break;
                            case "isAssured":
                                var isAssuredValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(isAssuredValue))
                                {
                                    poco.IsAssured = bool.Parse(isAssuredValue);
                                }

                                break;
                            case "isDeterminate":
                                var isDeterminateValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(isDeterminateValue))
                                {
                                    poco.IsDeterminate = bool.Parse(isDeterminateValue);
                                }

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
                                var localPostconditionValue = (IConstraint)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "uml:Constraint");
                                poco.LocalPostcondition.Add(localPostconditionValue);
                                break;
                            case "localPrecondition":
                                var localPreconditionValue = (IConstraint)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "uml:Constraint");
                                poco.LocalPrecondition.Add(localPreconditionValue);
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
                                var nameExpressionValue = (IStringExpression)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "uml:StringExpression");
                                poco.NameExpression.Add(nameExpressionValue);
                                break;
                            case "node":
                                var nodeValue = (IActivityNode)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory);
                                poco.Node.Add(nodeValue);
                                break;
                            case "outgoing":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "outgoing");
                                break;
                            case "ownedComment":
                                var ownedCommentValue = (IComment)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "uml:Comment");
                                poco.OwnedComment.Add(ownedCommentValue);
                                break;
                            case "ownedRule":
                                var ownedRuleValue = (IConstraint)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "uml:Constraint");
                                poco.OwnedRule.Add(ownedRuleValue);
                                break;
                            case "packageImport":
                                var packageImportValue = (IPackageImport)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "uml:PackageImport");
                                poco.PackageImport.Add(packageImportValue);
                                break;
                            case "redefinedNode":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "redefinedNode");
                                break;
                            case "result":
                                var resultValue = (IOutputPin)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "uml:OutputPin");
                                poco.Result.Add(resultValue);
                                break;
                            case "structuredNodeInput":
                                var structuredNodeInputValue = (IInputPin)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "uml:InputPin");
                                poco.StructuredNodeInput.Add(structuredNodeInputValue);
                                break;
                            case "variable":
                                var variableValue = (IVariable)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "uml:Variable");
                                poco.Variable.Add(variableValue);
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
                                    throw new NotSupportedException($"ConditionalNodeReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
                                }
                                else
                                {
                                    this.Logger.LogWarning("Not Supported: ConditionalNodeReader: {LocalName} at line:position {LineNumber}:{LinePosition}", xmlReader.LocalName, defaultLineInfo.LineNumber, defaultLineInfo.LinePosition);
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
