// -------------------------------------------------------------------------------------------------
// <copyright file="InteractionOperandReader.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="InteractionOperandReader"/> is to read an instance of <see cref="IInteractionOperand"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public class InteractionOperandReader : XmiElementReader<IInteractionOperand>, IXmiElementReader<IInteractionOperand>
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<InteractionOperandReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="InteractionOperandReader"/> class.
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
        public InteractionOperandReader(IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, IXmiReaderSettings xmiReaderSettings, ILoggerFactory loggerFactory)
            : base(cache, xmiElementReaderFacade, xmiReaderSettings, loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<InteractionOperandReader>.Instance : loggerFactory.CreateLogger<InteractionOperandReader>();
        }

        /// <summary>
        /// Reads the <see cref="IInteractionOperand"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="IInteractionOperand"/>
        /// </param>
        /// <param name="namespaceUri">
        /// the namespace that the <see cref="IInteractionOperand"/> belongs to
        /// </param>
        /// <returns>
        /// an instance of <see cref="IInteractionOperand"/>
        /// </returns>
        public override IInteractionOperand Read(XmlReader xmlReader, string documentName, string namespaceUri)
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

            IInteractionOperand poco = new InteractionOperand();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.logger.LogTrace("reading InteractionOperand at line:position {LineNumber}:{LinePosition}", xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);

                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:InteractionOperand")
                {
                    throw new XmlException($"The XmiType should be 'uml:InteractionOperand' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:InteractionOperand";
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
                    this.logger.LogCritical("Failed to add element type [{Poco}] with id [{Id}] as it was already in the Cache. The XMI document seems to have duplicate xmi:id values", "InteractionOperand", poco.XmiId);
                }

                var coveredXmlAttribute = xmlReader.GetAttribute("covered");

                if (!string.IsNullOrEmpty(coveredXmlAttribute))
                {
                    var coveredXmlAttributeValues = coveredXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("covered", coveredXmlAttributeValues);
                }

                var enclosingInteractionXmlAttribute = xmlReader.GetAttribute("enclosingInteraction");

                if (!string.IsNullOrEmpty(enclosingInteractionXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("enclosingInteraction", enclosingInteractionXmlAttribute);
                }

                var enclosingOperandXmlAttribute = xmlReader.GetAttribute("enclosingOperand");

                if (!string.IsNullOrEmpty(enclosingOperandXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("enclosingOperand", enclosingOperandXmlAttribute);
                }

                poco.Name = xmlReader.GetAttribute("name");

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
                            case "covered":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "covered");
                                break;
                            case "elementImport":
                                var elementImportValue = (IElementImport)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "uml:ElementImport");
                                poco.ElementImport.Add(elementImportValue);
                                break;
                            case "enclosingInteraction":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "enclosingInteraction");
                                break;
                            case "enclosingOperand":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "enclosingOperand");
                                break;
                            case "fragment":
                                var fragmentValue = (IInteractionFragment)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory);
                                poco.Fragment.Add(fragmentValue);
                                break;
                            case "generalOrdering":
                                var generalOrderingValue = (IGeneralOrdering)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "uml:GeneralOrdering");
                                poco.GeneralOrdering.Add(generalOrderingValue);
                                break;
                            case "guard":
                                var guardValue = (IInteractionConstraint)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "uml:InteractionConstraint");
                                poco.Guard.Add(guardValue);
                                break;
                            case "name":
                                poco.Name = xmlReader.ReadElementContentAsString();
                                break;
                            case "nameExpression":
                                var nameExpressionValue = (IStringExpression)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "uml:StringExpression");
                                poco.NameExpression.Add(nameExpressionValue);
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
                                    throw new NotSupportedException($"InteractionOperandReader: {xmlReader.LocalName} at line:position {xmlLineInfo.LineNumber}:{xmlLineInfo.LinePosition}");
                                }
                                else
                                {
                                    this.logger.LogWarning("Not Supported: InteractionOperandReader: {LocalName} at line:position {LineNumber}:{LinePosition}", xmlReader.LocalName, xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);
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
