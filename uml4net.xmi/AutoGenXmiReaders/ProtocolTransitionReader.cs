// -------------------------------------------------------------------------------------------------
// <copyright file="ProtocolTransitionReader.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="ProtocolTransitionReader"/> is to read an instance of <see cref="IProtocolTransition"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public class ProtocolTransitionReader : XmiElementReader<IProtocolTransition>, IXmiElementReader<IProtocolTransition>
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<ProtocolTransitionReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProtocolTransitionReader"/> class.
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
        public ProtocolTransitionReader(IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, IXmiReaderSettings xmiReaderSettings, INameSpaceResolver nameSpaceResolver, ILoggerFactory loggerFactory)
            : base(cache, xmiElementReaderFacade, xmiReaderSettings, nameSpaceResolver, loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<ProtocolTransitionReader>.Instance : loggerFactory.CreateLogger<ProtocolTransitionReader>();
        }

        /// <summary>
        /// Reads the <see cref="IProtocolTransition"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="IProtocolTransition"/>
        /// </param>
        /// <param name="namespaceUri">
        /// the namespace that the <see cref="IProtocolTransition"/> belongs to
        /// </param>
        /// <returns>
        /// an instance of <see cref="IProtocolTransition"/>
        /// </returns>
        public override IProtocolTransition Read(XmlReader xmlReader, string documentName, string namespaceUri)
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

            IProtocolTransition poco = new ProtocolTransition();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.logger.LogTrace("reading ProtocolTransition at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

                var xmiType = xmlReader.GetAttribute("type", this.NameSpaceResolver.XmiNameSpace);

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:ProtocolTransition")
                {
                    throw new XmlException($"The XmiType should be 'uml:ProtocolTransition' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:ProtocolTransition";
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
                    this.logger.LogCritical("Failed to add element type [{Poco}] with id [{Id}] as it was already in the Cache. The XMI document seems to have duplicate xmi:id values", "ProtocolTransition", poco.XmiId);
                }

                var containerXmlAttribute = xmlReader.GetAttribute("container") ?? xmlReader.GetAttribute("container", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrEmpty(containerXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("container", containerXmlAttribute);
                }

                var isLeafXmlAttribute = xmlReader.GetAttribute("isLeaf") ?? xmlReader.GetAttribute("isLeaf", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrEmpty(isLeafXmlAttribute))
                {
                    poco.IsLeaf = bool.Parse(isLeafXmlAttribute);
                }

                var kindXmlAttribute = xmlReader.GetAttribute("kind") ?? xmlReader.GetAttribute("kind", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrEmpty(kindXmlAttribute))
                {
                    poco.Kind = (TransitionKind)Enum.Parse(typeof(TransitionKind), kindXmlAttribute, true);
                }

                poco.Name = xmlReader.GetAttribute("name") ?? xmlReader.GetAttribute("name", this.NameSpaceResolver.UmlNameSpace);

                var redefinedTransitionXmlAttribute = xmlReader.GetAttribute("redefinedTransition") ?? xmlReader.GetAttribute("redefinedTransition", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrEmpty(redefinedTransitionXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("redefinedTransition", redefinedTransitionXmlAttribute);
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
                            case (KnowNamespacePrefixes.Uml, "container"):
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "container");
                                break;
                            case (KnowNamespacePrefixes.Uml, "effect"):
                                var effectValue = (IBehavior)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory);
                                poco.Effect.Add(effectValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "elementImport"):
                                var elementImportValue = (IElementImport)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "uml:ElementImport");
                                poco.ElementImport.Add(elementImportValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "guard"):
                                if (!this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "guard"))
                                {
                                    this.logger.LogWarning("The ProtocolTransition.Guard attribute was not processed at {XmlLineInfo}", xmlLineInfo);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "isLeaf"):
                                var isLeafValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(isLeafValue))
                                {
                                    poco.IsLeaf = bool.Parse(isLeafValue);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "kind"):
                                var kindValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(kindValue))
                                {
                                    poco.Kind = (TransitionKind)Enum.Parse(typeof(TransitionKind), kindValue, true);
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
                            case (KnowNamespacePrefixes.Uml, "ownedRule"):
                                var ownedRuleValue = (IConstraint)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "uml:Constraint");
                                poco.OwnedRule.Add(ownedRuleValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "packageImport"):
                                var packageImportValue = (IPackageImport)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "uml:PackageImport");
                                poco.PackageImport.Add(packageImportValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "postCondition"):
                                if (!this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "postCondition"))
                                {
                                    this.logger.LogWarning("The ProtocolTransition.PostCondition attribute was not processed at {XmlLineInfo}", xmlLineInfo);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "preCondition"):
                                if (!this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "preCondition"))
                                {
                                    this.logger.LogWarning("The ProtocolTransition.PreCondition attribute was not processed at {XmlLineInfo}", xmlLineInfo);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "redefinedTransition"):
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "redefinedTransition");
                                break;
                            case (KnowNamespacePrefixes.Uml, "source"):
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "source");
                                break;
                            case (KnowNamespacePrefixes.Uml, "target"):
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "target");
                                break;
                            case (KnowNamespacePrefixes.Uml, "trigger"):
                                var triggerValue = (ITrigger)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.LoggerFactory, "uml:Trigger");
                                poco.Trigger.Add(triggerValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "visibility"):
                                var visibilityValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(visibilityValue))
                                {
                                    poco.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibilityValue, true);
                                }

                                break;
                            case (KnowNamespacePrefixes.Xmi, "Extension"):
                                this.logger.LogInformation("Extension not yet supported)");
                                xmlReader.Skip();
                                break;
                            default:
                                if (this.XmiReaderSettings.UseStrictReading)
                                {
                                    throw new NotSupportedException($"ProtocolTransitionReader: {xmlReader.LocalName} at line:position {xmlLineInfo.LineNumber}:{xmlLineInfo.LinePosition}");
                                }
                                else
                                {
                                    this.logger.LogWarning("Not Supported: ProtocolTransitionReader: {LocalName} at line:position {LineNumber}:{LinePosition}", xmlReader.LocalName, xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);
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
