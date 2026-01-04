// -------------------------------------------------------------------------------------------------
// <copyright file="LoopNodeReader.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2026 Starion Group S.A.
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
    using uml4net.xmi.Extender;
    using uml4net.xmi.ReferenceResolver;
    using uml4net.xmi.Settings;

    /// <summary>
    /// The purpose of the <see cref="LoopNodeReader"/> is to read an instance of <see cref="ILoopNode"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public class LoopNodeReader : XmiElementReader<ILoopNode>, IXmiElementReader<ILoopNode>
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<LoopNodeReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoopNodeReader"/> class.
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
        /// <param name="extenderReaderRegistry">The injected <see cref="IExtenderReaderRegistry"/> that provides <see cref="IExtenderReader"/> resolve</param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public LoopNodeReader(IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, IXmiReaderSettings xmiReaderSettings, INameSpaceResolver nameSpaceResolver, IExtenderReaderRegistry extenderReaderRegistry, ILoggerFactory loggerFactory)
            : base(cache, xmiElementReaderFacade, xmiReaderSettings, nameSpaceResolver, extenderReaderRegistry, loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<LoopNodeReader>.Instance : loggerFactory.CreateLogger<LoopNodeReader>();
        }

        /// <summary>
        /// Reads the <see cref="ILoopNode"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="ILoopNode"/>
        /// </param>
        /// <param name="namespaceUri">
        /// the namespace that the <see cref="ILoopNode"/> belongs to
        /// </param>
        /// <returns>
        /// an instance of <see cref="ILoopNode"/>
        /// </returns>
        public override ILoopNode Read(XmlReader xmlReader, string documentName, string namespaceUri)
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

            ILoopNode poco = new LoopNode();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.logger.LogTrace("reading LoopNode at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

                var xmiType = xmlReader.GetAttribute("type", this.NameSpaceResolver.XmiNameSpace);

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:LoopNode")
                {
                    throw new XmlException($"The XmiType should be 'uml:LoopNode' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:LoopNode";
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
                    this.logger.LogCritical("Failed to add element type [{Poco}] with id [{Id}] as it was already in the Cache. The XMI document seems to have duplicate xmi:id values", "LoopNode", poco.XmiId);
                }

                var activityXmlAttribute = xmlReader.GetAttribute("activity") ?? xmlReader.GetAttribute("activity", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(activityXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("activity", activityXmlAttribute);
                }

                var bodyOutputXmlAttribute = xmlReader.GetAttribute("bodyOutput") ?? xmlReader.GetAttribute("bodyOutput", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(bodyOutputXmlAttribute))
                {
                    var bodyOutputXmlAttributeValues = bodyOutputXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("bodyOutput", bodyOutputXmlAttributeValues);
                }

                var bodyPartXmlAttribute = xmlReader.GetAttribute("bodyPart") ?? xmlReader.GetAttribute("bodyPart", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(bodyPartXmlAttribute))
                {
                    var bodyPartXmlAttributeValues = bodyPartXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("bodyPart", bodyPartXmlAttributeValues);
                }

                var deciderXmlAttribute = xmlReader.GetAttribute("decider") ?? xmlReader.GetAttribute("decider", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(deciderXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("decider", deciderXmlAttribute);
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

                var inStructuredNodeXmlAttribute = xmlReader.GetAttribute("inStructuredNode") ?? xmlReader.GetAttribute("inStructuredNode", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(inStructuredNodeXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("inStructuredNode", inStructuredNodeXmlAttribute);
                }

                var isLeafXmlAttribute = xmlReader.GetAttribute("isLeaf") ?? xmlReader.GetAttribute("isLeaf", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(isLeafXmlAttribute))
                {
                    poco.IsLeaf = bool.Parse(isLeafXmlAttribute);
                }

                var isLocallyReentrantXmlAttribute = xmlReader.GetAttribute("isLocallyReentrant") ?? xmlReader.GetAttribute("isLocallyReentrant", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(isLocallyReentrantXmlAttribute))
                {
                    poco.IsLocallyReentrant = bool.Parse(isLocallyReentrantXmlAttribute);
                }

                var isTestedFirstXmlAttribute = xmlReader.GetAttribute("isTestedFirst") ?? xmlReader.GetAttribute("isTestedFirst", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(isTestedFirstXmlAttribute))
                {
                    poco.IsTestedFirst = bool.Parse(isTestedFirstXmlAttribute);
                }

                var mustIsolateXmlAttribute = xmlReader.GetAttribute("mustIsolate") ?? xmlReader.GetAttribute("mustIsolate", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(mustIsolateXmlAttribute))
                {
                    poco.MustIsolate = bool.Parse(mustIsolateXmlAttribute);
                }

                poco.Name = xmlReader.GetAttribute("name") ?? xmlReader.GetAttribute("name", this.NameSpaceResolver.UmlNameSpace);

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

                var setupPartXmlAttribute = xmlReader.GetAttribute("setupPart") ?? xmlReader.GetAttribute("setupPart", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(setupPartXmlAttribute))
                {
                    var setupPartXmlAttributeValues = setupPartXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("setupPart", setupPartXmlAttributeValues);
                }

                var testXmlAttribute = xmlReader.GetAttribute("test") ?? xmlReader.GetAttribute("test", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(testXmlAttribute))
                {
                    var testXmlAttributeValues = testXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("test", testXmlAttributeValues);
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
                                CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "activity");
                                break;
                            case (KnowNamespacePrefixes.Uml, "bodyOutput"):
                                TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "bodyOutput");
                                break;
                            case (KnowNamespacePrefixes.Uml, "bodyPart"):
                                TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "bodyPart");
                                break;
                            case (KnowNamespacePrefixes.Uml, "decider"):
                                CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "decider");
                                break;
                            case (KnowNamespacePrefixes.Uml, "edge"):
                                var edgeValue = (IActivityEdge)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory);
                                poco.Edge.Add(edgeValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "elementImport"):
                                var elementImportValue = (IElementImport)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory, "uml:ElementImport");
                                poco.ElementImport.Add(elementImportValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "handler"):
                                var handlerValue = (IExceptionHandler)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory, "uml:ExceptionHandler");
                                poco.Handler.Add(handlerValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "incoming"):
                                TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "incoming");
                                break;
                            case (KnowNamespacePrefixes.Uml, "inInterruptibleRegion"):
                                TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "inInterruptibleRegion");
                                break;
                            case (KnowNamespacePrefixes.Uml, "inPartition"):
                                TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "inPartition");
                                break;
                            case (KnowNamespacePrefixes.Uml, "inStructuredNode"):
                                CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "inStructuredNode");
                                break;
                            case (KnowNamespacePrefixes.Uml, "isLeaf"):
                                var isLeafValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrWhiteSpace(isLeafValue))
                                {
                                    poco.IsLeaf = bool.Parse(isLeafValue);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "isLocallyReentrant"):
                                var isLocallyReentrantValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrWhiteSpace(isLocallyReentrantValue))
                                {
                                    poco.IsLocallyReentrant = bool.Parse(isLocallyReentrantValue);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "isTestedFirst"):
                                var isTestedFirstValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrWhiteSpace(isTestedFirstValue))
                                {
                                    poco.IsTestedFirst = bool.Parse(isTestedFirstValue);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "localPostcondition"):
                                var localPostconditionValue = (IConstraint)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory, "uml:Constraint");
                                poco.LocalPostcondition.Add(localPostconditionValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "localPrecondition"):
                                var localPreconditionValue = (IConstraint)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory, "uml:Constraint");
                                poco.LocalPrecondition.Add(localPreconditionValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "loopVariable"):
                                var loopVariableValue = (IOutputPin)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory, "uml:OutputPin");
                                poco.LoopVariable.Add(loopVariableValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "loopVariableInput"):
                                var loopVariableInputValue = (IInputPin)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory, "uml:InputPin");
                                poco.LoopVariableInput.Add(loopVariableInputValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "mustIsolate"):
                                var mustIsolateValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrWhiteSpace(mustIsolateValue))
                                {
                                    poco.MustIsolate = bool.Parse(mustIsolateValue);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "name"):
                                poco.Name = xmlReader.ReadElementContentAsString();
                                break;
                            case (KnowNamespacePrefixes.Uml, "nameExpression"):
                                var nameExpressionValue = (IStringExpression)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory, "uml:StringExpression");
                                poco.NameExpression.Add(nameExpressionValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "node"):
                                var nodeValue = (IActivityNode)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory);
                                poco.Node.Add(nodeValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "outgoing"):
                                TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "outgoing");
                                break;
                            case (KnowNamespacePrefixes.Uml, "ownedComment"):
                                var ownedCommentValue = (IComment)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory, "uml:Comment");
                                poco.OwnedComment.Add(ownedCommentValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "ownedRule"):
                                var ownedRuleValue = (IConstraint)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory, "uml:Constraint");
                                poco.OwnedRule.Add(ownedRuleValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "packageImport"):
                                var packageImportValue = (IPackageImport)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory, "uml:PackageImport");
                                poco.PackageImport.Add(packageImportValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "redefinedNode"):
                                TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "redefinedNode");
                                break;
                            case (KnowNamespacePrefixes.Uml, "result"):
                                var resultValue = (IOutputPin)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory, "uml:OutputPin");
                                poco.Result.Add(resultValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "setupPart"):
                                TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "setupPart");
                                break;
                            case (KnowNamespacePrefixes.Uml, "test"):
                                TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "test");
                                break;
                            case (KnowNamespacePrefixes.Uml, "variable"):
                                var variableValue = (IVariable)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory, "uml:Variable");
                                poco.Variable.Add(variableValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "visibility"):
                                var visibilityValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrWhiteSpace(visibilityValue))
                                {
                                    poco.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibilityValue, true);
                                }

                                break;
                            case (KnowNamespacePrefixes.Xmi, "extension"):
                            case (KnowNamespacePrefixes.Xmi, "Extension"):
                                {
                                    using var xmiExtensionXmlReader = xmlReader.ReadSubtree();
                                    var xmiExtensionReader = new XmiExtensionReader(this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory);
                                    poco.Extensions.Add(xmiExtensionReader.Read(xmiExtensionXmlReader, documentName, namespaceUri));
                                }

                                break;
                            default:
                                if (this.XmiReaderSettings.UseStrictReading)
                                {
                                    throw new NotSupportedException($"LoopNodeReader: {xmlReader.LocalName} at line:position {xmlLineInfo.LineNumber}:{xmlLineInfo.LinePosition}");
                                }
                                else
                                {
                                    this.logger.LogWarning("Not Supported: LoopNodeReader: {LocalName} at line:position {LineNumber}:{LinePosition}", xmlReader.LocalName, xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);
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
