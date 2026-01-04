// -------------------------------------------------------------------------------------------------
// <copyright file="OperationReader.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="OperationReader"/> is to read an instance of <see cref="IOperation"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public class OperationReader : XmiElementReader<IOperation>, IXmiElementReader<IOperation>
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<OperationReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationReader"/> class.
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
        public OperationReader(IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, IXmiReaderSettings xmiReaderSettings, INameSpaceResolver nameSpaceResolver, IExtenderReaderRegistry extenderReaderRegistry, ILoggerFactory loggerFactory)
            : base(cache, xmiElementReaderFacade, xmiReaderSettings, nameSpaceResolver, extenderReaderRegistry, loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<OperationReader>.Instance : loggerFactory.CreateLogger<OperationReader>();
        }

        /// <summary>
        /// Reads the <see cref="IOperation"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="IOperation"/>
        /// </param>
        /// <param name="namespaceUri">
        /// the namespace that the <see cref="IOperation"/> belongs to
        /// </param>
        /// <returns>
        /// an instance of <see cref="IOperation"/>
        /// </returns>
        public override IOperation Read(XmlReader xmlReader, string documentName, string namespaceUri)
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

            IOperation poco = new Operation();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.logger.LogTrace("reading Operation at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

                var xmiType = xmlReader.GetAttribute("type", this.NameSpaceResolver.XmiNameSpace);

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:Operation")
                {
                    throw new XmlException($"The XmiType should be 'uml:Operation' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:Operation";
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
                    this.logger.LogCritical("Failed to add element type [{Poco}] with id [{Id}] as it was already in the Cache. The XMI document seems to have duplicate xmi:id values", "Operation", poco.XmiId);
                }

                var classXmlAttribute = xmlReader.GetAttribute("class") ?? xmlReader.GetAttribute("class", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(classXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("class", classXmlAttribute);
                }

                var concurrencyXmlAttribute = xmlReader.GetAttribute("concurrency") ?? xmlReader.GetAttribute("concurrency", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(concurrencyXmlAttribute))
                {
                    poco.Concurrency = (CallConcurrencyKind)Enum.Parse(typeof(CallConcurrencyKind), concurrencyXmlAttribute, true);
                }

                var datatypeXmlAttribute = xmlReader.GetAttribute("datatype") ?? xmlReader.GetAttribute("datatype", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(datatypeXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("datatype", datatypeXmlAttribute);
                }

                var interfaceXmlAttribute = xmlReader.GetAttribute("interface") ?? xmlReader.GetAttribute("interface", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(interfaceXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("interface", interfaceXmlAttribute);
                }

                var isAbstractXmlAttribute = xmlReader.GetAttribute("isAbstract") ?? xmlReader.GetAttribute("isAbstract", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(isAbstractXmlAttribute))
                {
                    poco.IsAbstract = bool.Parse(isAbstractXmlAttribute);
                }

                var isLeafXmlAttribute = xmlReader.GetAttribute("isLeaf") ?? xmlReader.GetAttribute("isLeaf", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(isLeafXmlAttribute))
                {
                    poco.IsLeaf = bool.Parse(isLeafXmlAttribute);
                }

                var isQueryXmlAttribute = xmlReader.GetAttribute("isQuery") ?? xmlReader.GetAttribute("isQuery", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(isQueryXmlAttribute))
                {
                    poco.IsQuery = bool.Parse(isQueryXmlAttribute);
                }

                var isStaticXmlAttribute = xmlReader.GetAttribute("isStatic") ?? xmlReader.GetAttribute("isStatic", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(isStaticXmlAttribute))
                {
                    poco.IsStatic = bool.Parse(isStaticXmlAttribute);
                }

                var methodXmlAttribute = xmlReader.GetAttribute("method") ?? xmlReader.GetAttribute("method", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(methodXmlAttribute))
                {
                    var methodXmlAttributeValues = methodXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("method", methodXmlAttributeValues);
                }

                poco.Name = xmlReader.GetAttribute("name") ?? xmlReader.GetAttribute("name", this.NameSpaceResolver.UmlNameSpace);

                var owningTemplateParameterXmlAttribute = xmlReader.GetAttribute("owningTemplateParameter") ?? xmlReader.GetAttribute("owningTemplateParameter", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(owningTemplateParameterXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("owningTemplateParameter", owningTemplateParameterXmlAttribute);
                }

                var raisedExceptionXmlAttribute = xmlReader.GetAttribute("raisedException") ?? xmlReader.GetAttribute("raisedException", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(raisedExceptionXmlAttribute))
                {
                    var raisedExceptionXmlAttributeValues = raisedExceptionXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("raisedException", raisedExceptionXmlAttributeValues);
                }

                var redefinedOperationXmlAttribute = xmlReader.GetAttribute("redefinedOperation") ?? xmlReader.GetAttribute("redefinedOperation", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(redefinedOperationXmlAttribute))
                {
                    var redefinedOperationXmlAttributeValues = redefinedOperationXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("redefinedOperation", redefinedOperationXmlAttributeValues);
                }

                var templateParameterXmlAttribute = xmlReader.GetAttribute("templateParameter") ?? xmlReader.GetAttribute("templateParameter", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(templateParameterXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("templateParameter", templateParameterXmlAttribute);
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
                            case (KnowNamespacePrefixes.Uml, "bodyCondition"):
                                if (!TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "bodyCondition"))
                                {
                                    this.logger.LogWarning("The Operation.BodyCondition attribute was not processed at {XmlLineInfo}", xmlLineInfo);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "class"):
                                CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "class");
                                break;
                            case (KnowNamespacePrefixes.Uml, "concurrency"):
                                var concurrencyValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrWhiteSpace(concurrencyValue))
                                {
                                    poco.Concurrency = (CallConcurrencyKind)Enum.Parse(typeof(CallConcurrencyKind), concurrencyValue, true);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "datatype"):
                                CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "datatype");
                                break;
                            case (KnowNamespacePrefixes.Uml, "elementImport"):
                                var elementImportValue = (IElementImport)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory, "uml:ElementImport");
                                poco.ElementImport.Add(elementImportValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "interface"):
                                CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "interface");
                                break;
                            case (KnowNamespacePrefixes.Uml, "isAbstract"):
                                var isAbstractValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrWhiteSpace(isAbstractValue))
                                {
                                    poco.IsAbstract = bool.Parse(isAbstractValue);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "isLeaf"):
                                var isLeafValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrWhiteSpace(isLeafValue))
                                {
                                    poco.IsLeaf = bool.Parse(isLeafValue);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "isQuery"):
                                var isQueryValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrWhiteSpace(isQueryValue))
                                {
                                    poco.IsQuery = bool.Parse(isQueryValue);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "isStatic"):
                                var isStaticValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrWhiteSpace(isStaticValue))
                                {
                                    poco.IsStatic = bool.Parse(isStaticValue);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "method"):
                                TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "method");
                                break;
                            case (KnowNamespacePrefixes.Uml, "name"):
                                poco.Name = xmlReader.ReadElementContentAsString();
                                break;
                            case (KnowNamespacePrefixes.Uml, "nameExpression"):
                                var nameExpressionValue = (IStringExpression)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory, "uml:StringExpression");
                                poco.NameExpression.Add(nameExpressionValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "ownedComment"):
                                var ownedCommentValue = (IComment)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory, "uml:Comment");
                                poco.OwnedComment.Add(ownedCommentValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "ownedParameter"):
                                var ownedParameterValue = (IParameter)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory, "uml:Parameter");
                                poco.OwnedParameter.Add(ownedParameterValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "ownedParameterSet"):
                                var ownedParameterSetValue = (IParameterSet)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory, "uml:ParameterSet");
                                poco.OwnedParameterSet.Add(ownedParameterSetValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "ownedRule"):
                                var ownedRuleValue = (IConstraint)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory, "uml:Constraint");
                                poco.OwnedRule.Add(ownedRuleValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "ownedTemplateSignature"):
                                var ownedTemplateSignatureValue = (ITemplateSignature)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory, "uml:TemplateSignature");
                                poco.OwnedTemplateSignature.Add(ownedTemplateSignatureValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "owningTemplateParameter"):
                                CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "owningTemplateParameter");
                                break;
                            case (KnowNamespacePrefixes.Uml, "packageImport"):
                                var packageImportValue = (IPackageImport)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory, "uml:PackageImport");
                                poco.PackageImport.Add(packageImportValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "postcondition"):
                                if (!TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "postcondition"))
                                {
                                    this.logger.LogWarning("The Operation.Postcondition attribute was not processed at {XmlLineInfo}", xmlLineInfo);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "precondition"):
                                if (!TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "precondition"))
                                {
                                    this.logger.LogWarning("The Operation.Precondition attribute was not processed at {XmlLineInfo}", xmlLineInfo);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "raisedException"):
                                TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "raisedException");
                                break;
                            case (KnowNamespacePrefixes.Uml, "redefinedOperation"):
                                TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "redefinedOperation");
                                break;
                            case (KnowNamespacePrefixes.Uml, "templateBinding"):
                                var templateBindingValue = (ITemplateBinding)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory, "uml:TemplateBinding");
                                poco.TemplateBinding.Add(templateBindingValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "templateParameter"):
                                CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "templateParameter");
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
                                    throw new NotSupportedException($"OperationReader: {xmlReader.LocalName} at line:position {xmlLineInfo.LineNumber}:{xmlLineInfo.LinePosition}");
                                }
                                else
                                {
                                    this.logger.LogWarning("Not Supported: OperationReader: {LocalName} at line:position {LineNumber}:{LinePosition}", xmlReader.LocalName, xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);
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
