// -------------------------------------------------------------------------------------------------
// <copyright file="ControlFlowReader.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="ControlFlowReader"/> is to read an instance of <see cref="IControlFlow"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public class ControlFlowReader : XmiElementReader<IControlFlow>, IXmiElementReader<IControlFlow>
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<ControlFlowReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlFlowReader"/> class.
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
        public ControlFlowReader(IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, IXmiReaderSettings xmiReaderSettings, INameSpaceResolver nameSpaceResolver, ILoggerFactory loggerFactory)
            : base(cache, xmiElementReaderFacade, xmiReaderSettings, nameSpaceResolver, loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<ControlFlowReader>.Instance : loggerFactory.CreateLogger<ControlFlowReader>();
        }

        /// <summary>
        /// Reads the <see cref="IControlFlow"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="IControlFlow"/>
        /// </param>
        /// <param name="namespaceUri">
        /// the namespace that the <see cref="IControlFlow"/> belongs to
        /// </param>
        /// <returns>
        /// an instance of <see cref="IControlFlow"/>
        /// </returns>
        public override IControlFlow Read(XmlReader xmlReader, string documentName, string namespaceUri)
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

            IControlFlow poco = new ControlFlow();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.logger.LogTrace("reading ControlFlow at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

                var xmiType = xmlReader.GetAttribute("type", this.NameSpaceResolver.XmiNameSpace);

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:ControlFlow")
                {
                    throw new XmlException($"The XmiType should be 'uml:ControlFlow' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:ControlFlow";
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
                    this.logger.LogCritical("Failed to add element type [{Poco}] with id [{Id}] as it was already in the Cache. The XMI document seems to have duplicate xmi:id values", "ControlFlow", poco.XmiId);
                }

                var activityXmlAttribute = xmlReader.GetAttribute("activity") ?? xmlReader.GetAttribute("activity", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrEmpty(activityXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("activity", activityXmlAttribute);
                }

                var inPartitionXmlAttribute = xmlReader.GetAttribute("inPartition") ?? xmlReader.GetAttribute("inPartition", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrEmpty(inPartitionXmlAttribute))
                {
                    var inPartitionXmlAttributeValues = inPartitionXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("inPartition", inPartitionXmlAttributeValues);
                }

                var inStructuredNodeXmlAttribute = xmlReader.GetAttribute("inStructuredNode") ?? xmlReader.GetAttribute("inStructuredNode", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrEmpty(inStructuredNodeXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("inStructuredNode", inStructuredNodeXmlAttribute);
                }

                var interruptsXmlAttribute = xmlReader.GetAttribute("interrupts") ?? xmlReader.GetAttribute("interrupts", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrEmpty(interruptsXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("interrupts", interruptsXmlAttribute);
                }

                var isLeafXmlAttribute = xmlReader.GetAttribute("isLeaf") ?? xmlReader.GetAttribute("isLeaf", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrEmpty(isLeafXmlAttribute))
                {
                    poco.IsLeaf = bool.Parse(isLeafXmlAttribute);
                }

                poco.Name = xmlReader.GetAttribute("name") ?? xmlReader.GetAttribute("name", this.NameSpaceResolver.UmlNameSpace);

                var redefinedEdgeXmlAttribute = xmlReader.GetAttribute("redefinedEdge") ?? xmlReader.GetAttribute("redefinedEdge", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrEmpty(redefinedEdgeXmlAttribute))
                {
                    var redefinedEdgeXmlAttributeValues = redefinedEdgeXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("redefinedEdge", redefinedEdgeXmlAttributeValues);
                }

                var sourceXmlAttribute = xmlReader.GetAttribute("source") ?? xmlReader.GetAttribute("source", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrEmpty(sourceXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("source", sourceXmlAttribute);
                }

                var targetXmlAttribute = xmlReader.GetAttribute("target") ?? xmlReader.GetAttribute("target", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrEmpty(targetXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("target", targetXmlAttribute);
                }

                var visibilityXmlAttribute = xmlReader.GetAttribute("visibility") ?? xmlReader.GetAttribute("visibility", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrEmpty(visibilityXmlAttribute))
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
                            case (KnowNamespacePrefixes.Uml, "guard"):
                                var guardValue = (IValueSpecification)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory);
                                poco.Guard.Add(guardValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "inPartition"):
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "inPartition");
                                break;
                            case (KnowNamespacePrefixes.Uml, "inStructuredNode"):
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "inStructuredNode");
                                break;
                            case (KnowNamespacePrefixes.Uml, "interrupts"):
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "interrupts");
                                break;
                            case (KnowNamespacePrefixes.Uml, "isLeaf"):
                                var isLeafValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(isLeafValue))
                                {
                                    poco.IsLeaf = bool.Parse(isLeafValue);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "name"):
                                poco.Name = xmlReader.ReadElementContentAsString();
                                break;
                            case (KnowNamespacePrefixes.Uml, "nameExpression"):
                                var nameExpressionValue = (IStringExpression)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "uml:StringExpression");
                                poco.NameExpression.Add(nameExpressionValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "ownedComment"):
                                var ownedCommentValue = (IComment)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "uml:Comment");
                                poco.OwnedComment.Add(ownedCommentValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "redefinedEdge"):
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "redefinedEdge");
                                break;
                            case (KnowNamespacePrefixes.Uml, "source"):
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "source");
                                break;
                            case (KnowNamespacePrefixes.Uml, "target"):
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "target");
                                break;
                            case (KnowNamespacePrefixes.Uml, "visibility"):
                                var visibilityValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(visibilityValue))
                                {
                                    poco.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibilityValue, true);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "weight"):
                                var weightValue = (IValueSpecification)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory);
                                poco.Weight.Add(weightValue);
                                break;
                            case (KnowNamespacePrefixes.Xmi, "Extension"):
                                this.logger.LogInformation("Extension not yet supported)");
                                xmlReader.Skip();
                                break;
                            default:
                                if (this.XmiReaderSettings.UseStrictReading)
                                {
                                    throw new NotSupportedException($"ControlFlowReader: {xmlReader.LocalName} at line:position {xmlLineInfo.LineNumber}:{xmlLineInfo.LinePosition}");
                                }
                                else
                                {
                                    this.logger.LogWarning("Not Supported: ControlFlowReader: {LocalName} at line:position {LineNumber}:{LinePosition}", xmlReader.LocalName, xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);
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
