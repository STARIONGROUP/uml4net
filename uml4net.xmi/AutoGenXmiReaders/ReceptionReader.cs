// -------------------------------------------------------------------------------------------------
// <copyright file="ReceptionReader.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="ReceptionReader"/> is to read an instance of <see cref="IReception"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public class ReceptionReader : XmiElementReader<IReception>, IXmiElementReader<IReception>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceptionReader"/> class.
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
        public ReceptionReader(IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, IXmiReaderSettings xmiReaderSettings, ILoggerFactory loggerFactory)
            : base(cache, xmiElementReaderFacade, xmiReaderSettings, loggerFactory)
        {
        }

        /// <summary>
        /// Reads the <see cref="IReception"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="IReception"/>
        /// </param>
        /// <param name="namespaceUri">
        /// the namespace that the <see cref="IReception"/> belongs to
        /// </param>
        /// <returns>
        /// an instance of <see cref="IReception"/>
        /// </returns>
        public override IReception Read(XmlReader xmlReader, string documentName, string namespaceUri)
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

            IReception poco = new Reception();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:Reception")
                {
                    throw new XmlException($"The XmiType should be 'uml:Reception' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:Reception";
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
                    this.Logger.LogCritical("Failed to add element type [{Poco}] with id [{Id}] as it was already in the Cache. The XMI document seems to have duplicate xmi:id values", "Reception", poco.XmiId);
                }

                var concurrencyXmlAttribute = xmlReader.GetAttribute("concurrency");

                if (!string.IsNullOrEmpty(concurrencyXmlAttribute))
                {
                    poco.Concurrency = (CallConcurrencyKind)Enum.Parse(typeof(CallConcurrencyKind), concurrencyXmlAttribute, true);
                }

                var isAbstractXmlAttribute = xmlReader.GetAttribute("isAbstract");

                if (!string.IsNullOrEmpty(isAbstractXmlAttribute))
                {
                    poco.IsAbstract = bool.Parse(isAbstractXmlAttribute);
                }

                var isLeafXmlAttribute = xmlReader.GetAttribute("isLeaf");

                if (!string.IsNullOrEmpty(isLeafXmlAttribute))
                {
                    poco.IsLeaf = bool.Parse(isLeafXmlAttribute);
                }

                var isStaticXmlAttribute = xmlReader.GetAttribute("isStatic");

                if (!string.IsNullOrEmpty(isStaticXmlAttribute))
                {
                    poco.IsStatic = bool.Parse(isStaticXmlAttribute);
                }

                var methodXmlAttribute = xmlReader.GetAttribute("method");

                if (!string.IsNullOrEmpty(methodXmlAttribute))
                {
                    var methodXmlAttributeValues = methodXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("method", methodXmlAttributeValues);
                }

                poco.Name = xmlReader.GetAttribute("name");

                var raisedExceptionXmlAttribute = xmlReader.GetAttribute("raisedException");

                if (!string.IsNullOrEmpty(raisedExceptionXmlAttribute))
                {
                    var raisedExceptionXmlAttributeValues = raisedExceptionXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("raisedException", raisedExceptionXmlAttributeValues);
                }

                var signalXmlAttribute = xmlReader.GetAttribute("signal");

                if (!string.IsNullOrEmpty(signalXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("signal", signalXmlAttribute);
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
                            case "concurrency":
                                var concurrencyValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(concurrencyValue))
                                {
                                    poco.Concurrency = (CallConcurrencyKind)Enum.Parse(typeof(CallConcurrencyKind), concurrencyValue, true);
                                }

                                break;
                            case "elementImport":
                                var elementImportValue = (IElementImport)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "uml:ElementImport");
                                poco.ElementImport.Add(elementImportValue);
                                break;
                            case "isAbstract":
                                var isAbstractValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(isAbstractValue))
                                {
                                    poco.IsAbstract = bool.Parse(isAbstractValue);
                                }

                                break;
                            case "isLeaf":
                                var isLeafValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(isLeafValue))
                                {
                                    poco.IsLeaf = bool.Parse(isLeafValue);
                                }

                                break;
                            case "isStatic":
                                var isStaticValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(isStaticValue))
                                {
                                    poco.IsStatic = bool.Parse(isStaticValue);
                                }

                                break;
                            case "method":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "method");
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
                            case "ownedParameter":
                                var ownedParameterValue = (IParameter)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "uml:Parameter");
                                poco.OwnedParameter.Add(ownedParameterValue);
                                break;
                            case "ownedParameterSet":
                                var ownedParameterSetValue = (IParameterSet)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "uml:ParameterSet");
                                poco.OwnedParameterSet.Add(ownedParameterSetValue);
                                break;
                            case "ownedRule":
                                var ownedRuleValue = (IConstraint)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "uml:Constraint");
                                poco.OwnedRule.Add(ownedRuleValue);
                                break;
                            case "packageImport":
                                var packageImportValue = (IPackageImport)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "uml:PackageImport");
                                poco.PackageImport.Add(packageImportValue);
                                break;
                            case "raisedException":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "raisedException");
                                break;
                            case "signal":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "signal");
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
                                    throw new NotSupportedException($"ReceptionReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
                                }
                                else
                                {
                                    this.Logger.LogWarning("Not Supported: ReceptionReader: {LocalName} at line:position {LineNumber}:{LinePosition}", xmlReader.LocalName, defaultLineInfo.LineNumber, defaultLineInfo.LinePosition);
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
