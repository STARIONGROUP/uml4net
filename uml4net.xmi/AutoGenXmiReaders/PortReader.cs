// -------------------------------------------------------------------------------------------------
// <copyright file="PortReader.cs" company="Starion Group S.A.">
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
    using uml4net.xmi.Extender;
    using uml4net.xmi.ReferenceResolver;
    using uml4net.xmi.Settings;

    /// <summary>
    /// The purpose of the <see cref="PortReader"/> is to read an instance of <see cref="IPort"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public class PortReader : XmiElementReader<IPort>, IXmiElementReader<IPort>
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<PortReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PortReader"/> class.
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
        public PortReader(IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, IXmiReaderSettings xmiReaderSettings, INameSpaceResolver nameSpaceResolver, IExtenderReaderRegistry extenderReaderRegistry, ILoggerFactory loggerFactory)
            : base(cache, xmiElementReaderFacade, xmiReaderSettings, nameSpaceResolver, extenderReaderRegistry, loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<PortReader>.Instance : loggerFactory.CreateLogger<PortReader>();
        }

        /// <summary>
        /// Reads the <see cref="IPort"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="IPort"/>
        /// </param>
        /// <param name="namespaceUri">
        /// the namespace that the <see cref="IPort"/> belongs to
        /// </param>
        /// <returns>
        /// an instance of <see cref="IPort"/>
        /// </returns>
        public override IPort Read(XmlReader xmlReader, string documentName, string namespaceUri)
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

            IPort poco = new Port();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.logger.LogTrace("reading Port at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

                var xmiType = xmlReader.GetAttribute("type", this.NameSpaceResolver.XmiNameSpace);

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:Port")
                {
                    throw new XmlException($"The XmiType should be 'uml:Port' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:Port";
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
                    this.logger.LogCritical("Failed to add element type [{Poco}] with id [{Id}] as it was already in the Cache. The XMI document seems to have duplicate xmi:id values", "Port", poco.XmiId);
                }

                var aggregationXmlAttribute = xmlReader.GetAttribute("aggregation") ?? xmlReader.GetAttribute("aggregation", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(aggregationXmlAttribute))
                {
                    poco.Aggregation = (AggregationKind)Enum.Parse(typeof(AggregationKind), aggregationXmlAttribute, true);
                }

                var associationXmlAttribute = xmlReader.GetAttribute("association") ?? xmlReader.GetAttribute("association", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(associationXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("association", associationXmlAttribute);
                }

                var associationEndXmlAttribute = xmlReader.GetAttribute("associationEnd") ?? xmlReader.GetAttribute("associationEnd", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(associationEndXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("associationEnd", associationEndXmlAttribute);
                }

                var classXmlAttribute = xmlReader.GetAttribute("class") ?? xmlReader.GetAttribute("class", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(classXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("class", classXmlAttribute);
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

                var isBehaviorXmlAttribute = xmlReader.GetAttribute("isBehavior") ?? xmlReader.GetAttribute("isBehavior", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(isBehaviorXmlAttribute))
                {
                    poco.IsBehavior = bool.Parse(isBehaviorXmlAttribute);
                }

                var isConjugatedXmlAttribute = xmlReader.GetAttribute("isConjugated") ?? xmlReader.GetAttribute("isConjugated", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(isConjugatedXmlAttribute))
                {
                    poco.IsConjugated = bool.Parse(isConjugatedXmlAttribute);
                }

                var isDerivedXmlAttribute = xmlReader.GetAttribute("isDerived") ?? xmlReader.GetAttribute("isDerived", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(isDerivedXmlAttribute))
                {
                    poco.IsDerived = bool.Parse(isDerivedXmlAttribute);
                }

                var isDerivedUnionXmlAttribute = xmlReader.GetAttribute("isDerivedUnion") ?? xmlReader.GetAttribute("isDerivedUnion", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(isDerivedUnionXmlAttribute))
                {
                    poco.IsDerivedUnion = bool.Parse(isDerivedUnionXmlAttribute);
                }

                var isIDXmlAttribute = xmlReader.GetAttribute("isID") ?? xmlReader.GetAttribute("isID", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(isIDXmlAttribute))
                {
                    poco.IsID = bool.Parse(isIDXmlAttribute);
                }

                var isLeafXmlAttribute = xmlReader.GetAttribute("isLeaf") ?? xmlReader.GetAttribute("isLeaf", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(isLeafXmlAttribute))
                {
                    poco.IsLeaf = bool.Parse(isLeafXmlAttribute);
                }

                var isOrderedXmlAttribute = xmlReader.GetAttribute("isOrdered") ?? xmlReader.GetAttribute("isOrdered", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(isOrderedXmlAttribute))
                {
                    poco.IsOrdered = bool.Parse(isOrderedXmlAttribute);
                }

                var isReadOnlyXmlAttribute = xmlReader.GetAttribute("isReadOnly") ?? xmlReader.GetAttribute("isReadOnly", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(isReadOnlyXmlAttribute))
                {
                    poco.IsReadOnly = bool.Parse(isReadOnlyXmlAttribute);
                }

                var isServiceXmlAttribute = xmlReader.GetAttribute("isService") ?? xmlReader.GetAttribute("isService", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(isServiceXmlAttribute))
                {
                    poco.IsService = bool.Parse(isServiceXmlAttribute);
                }

                var isStaticXmlAttribute = xmlReader.GetAttribute("isStatic") ?? xmlReader.GetAttribute("isStatic", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(isStaticXmlAttribute))
                {
                    poco.IsStatic = bool.Parse(isStaticXmlAttribute);
                }

                var isUniqueXmlAttribute = xmlReader.GetAttribute("isUnique") ?? xmlReader.GetAttribute("isUnique", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(isUniqueXmlAttribute))
                {
                    poco.IsUnique = bool.Parse(isUniqueXmlAttribute);
                }

                poco.Name = xmlReader.GetAttribute("name") ?? xmlReader.GetAttribute("name", this.NameSpaceResolver.UmlNameSpace);

                var owningAssociationXmlAttribute = xmlReader.GetAttribute("owningAssociation") ?? xmlReader.GetAttribute("owningAssociation", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(owningAssociationXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("owningAssociation", owningAssociationXmlAttribute);
                }

                var owningTemplateParameterXmlAttribute = xmlReader.GetAttribute("owningTemplateParameter") ?? xmlReader.GetAttribute("owningTemplateParameter", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(owningTemplateParameterXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("owningTemplateParameter", owningTemplateParameterXmlAttribute);
                }

                var protocolXmlAttribute = xmlReader.GetAttribute("protocol") ?? xmlReader.GetAttribute("protocol", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(protocolXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("protocol", protocolXmlAttribute);
                }

                var redefinedPortXmlAttribute = xmlReader.GetAttribute("redefinedPort") ?? xmlReader.GetAttribute("redefinedPort", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(redefinedPortXmlAttribute))
                {
                    var redefinedPortXmlAttributeValues = redefinedPortXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("redefinedPort", redefinedPortXmlAttributeValues);
                }

                var redefinedPropertyXmlAttribute = xmlReader.GetAttribute("redefinedProperty") ?? xmlReader.GetAttribute("redefinedProperty", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(redefinedPropertyXmlAttribute))
                {
                    var redefinedPropertyXmlAttributeValues = redefinedPropertyXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("redefinedProperty", redefinedPropertyXmlAttributeValues);
                }

                var subsettedPropertyXmlAttribute = xmlReader.GetAttribute("subsettedProperty") ?? xmlReader.GetAttribute("subsettedProperty", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(subsettedPropertyXmlAttribute))
                {
                    var subsettedPropertyXmlAttributeValues = subsettedPropertyXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("subsettedProperty", subsettedPropertyXmlAttributeValues);
                }

                var templateParameterXmlAttribute = xmlReader.GetAttribute("templateParameter") ?? xmlReader.GetAttribute("templateParameter", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(templateParameterXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("templateParameter", templateParameterXmlAttribute);
                }

                var typeXmlAttribute = xmlReader.GetAttribute("type") ?? xmlReader.GetAttribute("type", this.NameSpaceResolver.UmlNameSpace);

                if (!string.IsNullOrWhiteSpace(typeXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("type", typeXmlAttribute);
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
                            case (KnowNamespacePrefixes.Uml, "aggregation"):
                                var aggregationValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrWhiteSpace(aggregationValue))
                                {
                                    poco.Aggregation = (AggregationKind)Enum.Parse(typeof(AggregationKind), aggregationValue, true);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "association"):
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "association");
                                break;
                            case (KnowNamespacePrefixes.Uml, "associationEnd"):
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "associationEnd");
                                break;
                            case (KnowNamespacePrefixes.Uml, "class"):
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "class");
                                break;
                            case (KnowNamespacePrefixes.Uml, "datatype"):
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "datatype");
                                break;
                            case (KnowNamespacePrefixes.Uml, "defaultValue"):
                                var defaultValueValue = (IValueSpecification)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory);
                                poco.DefaultValue.Add(defaultValueValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "deployment"):
                                var deploymentValue = (IDeployment)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory, "uml:Deployment");
                                poco.Deployment.Add(deploymentValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "interface"):
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "interface");
                                break;
                            case (KnowNamespacePrefixes.Uml, "isBehavior"):
                                var isBehaviorValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrWhiteSpace(isBehaviorValue))
                                {
                                    poco.IsBehavior = bool.Parse(isBehaviorValue);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "isConjugated"):
                                var isConjugatedValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrWhiteSpace(isConjugatedValue))
                                {
                                    poco.IsConjugated = bool.Parse(isConjugatedValue);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "isDerived"):
                                var isDerivedValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrWhiteSpace(isDerivedValue))
                                {
                                    poco.IsDerived = bool.Parse(isDerivedValue);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "isDerivedUnion"):
                                var isDerivedUnionValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrWhiteSpace(isDerivedUnionValue))
                                {
                                    poco.IsDerivedUnion = bool.Parse(isDerivedUnionValue);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "isID"):
                                var isIDValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrWhiteSpace(isIDValue))
                                {
                                    poco.IsID = bool.Parse(isIDValue);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "isLeaf"):
                                var isLeafValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrWhiteSpace(isLeafValue))
                                {
                                    poco.IsLeaf = bool.Parse(isLeafValue);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "isOrdered"):
                                var isOrderedValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrWhiteSpace(isOrderedValue))
                                {
                                    poco.IsOrdered = bool.Parse(isOrderedValue);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "isReadOnly"):
                                var isReadOnlyValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrWhiteSpace(isReadOnlyValue))
                                {
                                    poco.IsReadOnly = bool.Parse(isReadOnlyValue);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "isService"):
                                var isServiceValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrWhiteSpace(isServiceValue))
                                {
                                    poco.IsService = bool.Parse(isServiceValue);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "isStatic"):
                                var isStaticValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrWhiteSpace(isStaticValue))
                                {
                                    poco.IsStatic = bool.Parse(isStaticValue);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "isUnique"):
                                var isUniqueValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrWhiteSpace(isUniqueValue))
                                {
                                    poco.IsUnique = bool.Parse(isUniqueValue);
                                }

                                break;
                            case (KnowNamespacePrefixes.Uml, "lowerValue"):
                                var lowerValueValue = (IValueSpecification)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory);
                                poco.LowerValue.Add(lowerValueValue);
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
                            case (KnowNamespacePrefixes.Uml, "owningAssociation"):
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "owningAssociation");
                                break;
                            case (KnowNamespacePrefixes.Uml, "owningTemplateParameter"):
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "owningTemplateParameter");
                                break;
                            case (KnowNamespacePrefixes.Uml, "protocol"):
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "protocol");
                                break;
                            case (KnowNamespacePrefixes.Uml, "qualifier"):
                                var qualifierValue = (IProperty)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory, "uml:Property");
                                poco.Qualifier.Add(qualifierValue);
                                break;
                            case (KnowNamespacePrefixes.Uml, "redefinedPort"):
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "redefinedPort");
                                break;
                            case (KnowNamespacePrefixes.Uml, "redefinedProperty"):
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "redefinedProperty");
                                break;
                            case (KnowNamespacePrefixes.Uml, "subsettedProperty"):
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "subsettedProperty");
                                break;
                            case (KnowNamespacePrefixes.Uml, "templateParameter"):
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "templateParameter");
                                break;
                            case (KnowNamespacePrefixes.Uml, "type"):
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "type");
                                break;
                            case (KnowNamespacePrefixes.Uml, "upperValue"):
                                var upperValueValue = (IValueSpecification)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.NameSpaceResolver, this.ExtenderReaderRegistry, this.LoggerFactory);
                                poco.UpperValue.Add(upperValueValue);
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
                                    throw new NotSupportedException($"PortReader: {xmlReader.LocalName} at line:position {xmlLineInfo.LineNumber}:{xmlLineInfo.LinePosition}");
                                }
                                else
                                {
                                    this.logger.LogWarning("Not Supported: PortReader: {LocalName} at line:position {LineNumber}:{LinePosition}", xmlReader.LocalName, xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);
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
