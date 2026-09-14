// -------------------------------------------------------------------------------------------------
// <copyright file="ProtocolTransitionReader.cs" company="Starion Group S.A.">
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
        /// <param name="extenderReaderRegistry">The injected <see cref="IExtenderReaderRegistry"/> that provides <see cref="IExtenderReader"/> resolve</param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public ProtocolTransitionReader(IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, IXmiReaderSettings xmiReaderSettings, INameSpaceResolver nameSpaceResolver, IExtenderReaderRegistry extenderReaderRegistry, ILoggerFactory loggerFactory)
            : base(cache, xmiElementReaderFacade, xmiReaderSettings, nameSpaceResolver, extenderReaderRegistry, loggerFactory)
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

                var xmiType = xmlReader.ResolveQualifiedName(xmlReader.GetXmiAttribute("type"), this.NameSpaceResolver);

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
                    // xmi:id values must be unique within a document (XMI 2.5.1 clause 7.6.1); the element that was read first is kept and referenced.
                    // This is reported, not rejected, even in strict mode: the normative UML.xmi itself contains a duplicate xmi:id
                    this.logger.LogError("The xmi:id is not unique within the document, the element that was read first is kept: ProtocolTransition [{XmiId}] property [xmi:id] at line:position {LineNumber}:{LinePosition}", poco.XmiId, xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);
                }

                var containerXmlAttribute = xmlReader.GetAttribute("container") ?? xmlReader.GetAttribute("container", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(containerXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("container", containerXmlAttribute);
                }

                var guardXmlAttribute = xmlReader.GetAttribute("guard") ?? xmlReader.GetAttribute("guard", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(guardXmlAttribute))
                {
                    var guardXmlAttributeValues = guardXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("guard", guardXmlAttributeValues);
                }

                var isLeafXmlAttribute = xmlReader.GetAttribute("isLeaf") ?? xmlReader.GetAttribute("isLeaf", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(isLeafXmlAttribute))
                {
                    poco.IsLeaf = XmlConvert.ToBoolean(isLeafXmlAttribute);
                }

                var kindXmlAttribute = xmlReader.GetAttribute("kind") ?? xmlReader.GetAttribute("kind", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(kindXmlAttribute))
                {
                    if (TransitionKindExtensions.TryParseXmiLiteral(kindXmlAttribute, out var kindLiteral))
                    {
                        poco.Kind = kindLiteral;
                    }
                    else
                    {
                        this.ReportXmiError(xmlReader, poco, "kind", $"[{kindXmlAttribute}] is not the name of a literal of TransitionKind");
                    }
                }

                poco.Name = xmlReader.GetAttribute("name") ?? xmlReader.GetAttribute("name", this.NameSpaceResolver.UmlNameSpace);

                var postConditionXmlAttribute = xmlReader.GetAttribute("postCondition") ?? xmlReader.GetAttribute("postCondition", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(postConditionXmlAttribute))
                {
                    var postConditionXmlAttributeValues = postConditionXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("postCondition", postConditionXmlAttributeValues);
                }

                var preConditionXmlAttribute = xmlReader.GetAttribute("preCondition") ?? xmlReader.GetAttribute("preCondition", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(preConditionXmlAttribute))
                {
                    var preConditionXmlAttributeValues = preConditionXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("preCondition", preConditionXmlAttributeValues);
                }

                var redefinedTransitionXmlAttribute = xmlReader.GetAttribute("redefinedTransition") ?? xmlReader.GetAttribute("redefinedTransition", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(redefinedTransitionXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("redefinedTransition", redefinedTransitionXmlAttribute);
                }

                var sourceXmlAttribute = xmlReader.GetAttribute("source") ?? xmlReader.GetAttribute("source", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(sourceXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("source", sourceXmlAttribute);
                }

                var targetXmlAttribute = xmlReader.GetAttribute("target") ?? xmlReader.GetAttribute("target", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(targetXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("target", targetXmlAttribute);
                }

                var visibilityXmlAttribute = xmlReader.GetAttribute("visibility") ?? xmlReader.GetAttribute("visibility", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(visibilityXmlAttribute))
                {
                    if (VisibilityKindExtensions.TryParseXmiLiteral(visibilityXmlAttribute, out var visibilityLiteral))
                    {
                        poco.Visibility = visibilityLiteral;
                    }
                    else
                    {
                        this.ReportXmiError(xmlReader, poco, "visibility", $"[{visibilityXmlAttribute}] is not the name of a literal of VisibilityKind");
                    }
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
                                CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "container");
                                break;
                            case (KnowNamespacePrefixes.Uml, "effect"):
                                if (!TryCollectCompositeReferencePropertyIdentifier(xmlReader, poco, "effect", poco.Effect.Count))
                                {
                                    var effectValue = (IBehavior)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory);
                                    poco.Effect.Add(effectValue);
                                }
                                break;
                            case (KnowNamespacePrefixes.Uml, "elementImport"):
                                if (!TryCollectCompositeReferencePropertyIdentifier(xmlReader, poco, "elementImport", poco.ElementImport.Count))
                                {
                                    var elementImportValue = (IElementImport)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory, "uml:ElementImport");
                                    poco.ElementImport.Add(elementImportValue);
                                }
                                break;
                            case (KnowNamespacePrefixes.Uml, "guard"):
                                if (!TryCollectCompositeReferencePropertyIdentifier(xmlReader, poco, "guard", poco.Guard.Count))
                                {
                                    var guardValue = (IConstraint)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory, "uml:Constraint");
                                    poco.Guard.Add(guardValue);
                                }
                                break;
                            case (KnowNamespacePrefixes.Uml, "isLeaf"):
                                var isLeafValue = xmlReader.ReadElementContentAsStringInPlace();

                                if (!string.IsNullOrWhiteSpace(isLeafValue))
                                {
                                    poco.IsLeaf = XmlConvert.ToBoolean(isLeafValue);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "kind"):
                                var kindValue = xmlReader.ReadElementContentAsStringInPlace();

                                if (!string.IsNullOrWhiteSpace(kindValue))
                                {
                                    if (TransitionKindExtensions.TryParseXmiLiteral(kindValue, out var kindLiteral))
                                    {
                                        poco.Kind = kindLiteral;
                                    }
                                    else
                                    {
                                        this.ReportXmiError(xmlReader, poco, "kind", $"[{kindValue}] is not the name of a literal of TransitionKind");
                                    }
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "name"):
                                poco.Name = xmlReader.ReadElementContentAsStringInPlace();
                                break;
                            case (KnowNamespacePrefixes.Uml, "nameExpression"):
                                if (!TryCollectCompositeReferencePropertyIdentifier(xmlReader, poco, "nameExpression", poco.NameExpression.Count))
                                {
                                    var nameExpressionValue = (IStringExpression)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory, "uml:StringExpression");
                                    poco.NameExpression.Add(nameExpressionValue);
                                }
                                break;
                            case (KnowNamespacePrefixes.Uml, "ownedComment"):
                                if (!TryCollectCompositeReferencePropertyIdentifier(xmlReader, poco, "ownedComment", poco.OwnedComment.Count))
                                {
                                    var ownedCommentValue = (IComment)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory, "uml:Comment");
                                    poco.OwnedComment.Add(ownedCommentValue);
                                }
                                break;
                            case (KnowNamespacePrefixes.Uml, "ownedRule"):
                                if (!TryCollectCompositeReferencePropertyIdentifier(xmlReader, poco, "ownedRule", poco.OwnedRule.Count))
                                {
                                    var ownedRuleValue = (IConstraint)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory, "uml:Constraint");
                                    poco.OwnedRule.Add(ownedRuleValue);
                                }
                                break;
                            case (KnowNamespacePrefixes.Uml, "packageImport"):
                                if (!TryCollectCompositeReferencePropertyIdentifier(xmlReader, poco, "packageImport", poco.PackageImport.Count))
                                {
                                    var packageImportValue = (IPackageImport)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory, "uml:PackageImport");
                                    poco.PackageImport.Add(packageImportValue);
                                }
                                break;
                            case (KnowNamespacePrefixes.Uml, "postCondition"):
                                if (!TryCollectCompositeReferencePropertyIdentifier(xmlReader, poco, "postCondition", poco.PostCondition.Count))
                                {
                                    var postConditionValue = (IConstraint)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory, "uml:Constraint");
                                    poco.PostCondition.Add(postConditionValue);
                                }
                                break;
                            case (KnowNamespacePrefixes.Uml, "preCondition"):
                                if (!TryCollectCompositeReferencePropertyIdentifier(xmlReader, poco, "preCondition", poco.PreCondition.Count))
                                {
                                    var preConditionValue = (IConstraint)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory, "uml:Constraint");
                                    poco.PreCondition.Add(preConditionValue);
                                }
                                break;
                            case (KnowNamespacePrefixes.Uml, "redefinedTransition"):
                                CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "redefinedTransition");
                                break;
                            case (KnowNamespacePrefixes.Uml, "source"):
                                CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "source");
                                break;
                            case (KnowNamespacePrefixes.Uml, "target"):
                                CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "target");
                                break;
                            case (KnowNamespacePrefixes.Uml, "trigger"):
                                if (!TryCollectCompositeReferencePropertyIdentifier(xmlReader, poco, "trigger", poco.Trigger.Count))
                                {
                                    var triggerValue = (ITrigger)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory, "uml:Trigger");
                                    poco.Trigger.Add(triggerValue);
                                }
                                break;
                            case (KnowNamespacePrefixes.Uml, "visibility"):
                                var visibilityValue = xmlReader.ReadElementContentAsStringInPlace();

                                if (!string.IsNullOrWhiteSpace(visibilityValue))
                                {
                                    if (VisibilityKindExtensions.TryParseXmiLiteral(visibilityValue, out var visibilityLiteral))
                                    {
                                        poco.Visibility = visibilityLiteral;
                                    }
                                    else
                                    {
                                        this.ReportXmiError(xmlReader, poco, "visibility", $"[{visibilityValue}] is not the name of a literal of VisibilityKind");
                                    }
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "clientDependency"):
                            case (KnowNamespacePrefixes.Uml, "importedMember"):
                            case (KnowNamespacePrefixes.Uml, "member"):
                            case (KnowNamespacePrefixes.Uml, "namespace"):
                            case (KnowNamespacePrefixes.Uml, "ownedElement"):
                            case (KnowNamespacePrefixes.Uml, "ownedMember"):
                            case (KnowNamespacePrefixes.Uml, "owner"):
                            case (KnowNamespacePrefixes.Uml, "qualifiedName"):
                            case (KnowNamespacePrefixes.Uml, "redefinedElement"):
                            case (KnowNamespacePrefixes.Uml, "redefinitionContext"):
                            case (KnowNamespacePrefixes.Uml, "referred"):
                                // serialized derived data (XMI 2.5.1 clause 7.8.10) is computed by uml4net, not read
                                this.logger.LogDebug("Ignoring the serialized derived property {LocalName} of ProtocolTransition at line:position {LineNumber}:{LinePosition}", xmlReader.LocalName, xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);
                                xmlReader.SkipInPlace();
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
                                    throw new NotSupportedException($"ProtocolTransitionReader: {xmlReader.LocalName} at line:position {xmlLineInfo.LineNumber}:{xmlLineInfo.LinePosition}");
                                }
                                else
                                {
                                    this.logger.LogWarning("Not Supported: ProtocolTransitionReader: {LocalName} at line:position {LineNumber}:{LinePosition}", xmlReader.LocalName, xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);

                                    // the children of an unknown element are not properties of this element
                                    xmlReader.SkipInPlace();
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
