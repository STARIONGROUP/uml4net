// -------------------------------------------------------------------------------------------------
// <copyright file="OperationTemplateParameterReader.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="OperationTemplateParameterReader"/> is to read an instance of <see cref="IOperationTemplateParameter"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public class OperationTemplateParameterReader : XmiElementReader<IOperationTemplateParameter>, IXmiElementReader<IOperationTemplateParameter>
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<OperationTemplateParameterReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationTemplateParameterReader"/> class.
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
        public OperationTemplateParameterReader(IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, IXmiReaderSettings xmiReaderSettings, ILoggerFactory loggerFactory)
            : base(cache, xmiElementReaderFacade, xmiReaderSettings, loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<OperationTemplateParameterReader>.Instance : loggerFactory.CreateLogger<OperationTemplateParameterReader>();
        }

        /// <summary>
        /// Reads the <see cref="IOperationTemplateParameter"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="IOperationTemplateParameter"/>
        /// </param>
        /// <param name="namespaceUri">
        /// the namespace that the <see cref="IOperationTemplateParameter"/> belongs to
        /// </param>
        /// <returns>
        /// an instance of <see cref="IOperationTemplateParameter"/>
        /// </returns>
        public override IOperationTemplateParameter Read(XmlReader xmlReader, string documentName, string namespaceUri)
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

            IOperationTemplateParameter poco = new OperationTemplateParameter();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.logger.LogTrace("reading OperationTemplateParameter at line:position {LineNumber}:{LinePosition}", xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);

                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:OperationTemplateParameter")
                {
                    throw new XmlException($"The XmiType should be 'uml:OperationTemplateParameter' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:OperationTemplateParameter";
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
                    this.logger.LogCritical("Failed to add element type [{Poco}] with id [{Id}] as it was already in the Cache. The XMI document seems to have duplicate xmi:id values", "OperationTemplateParameter", poco.XmiId);
                }

                var defaultXmlAttribute = xmlReader.GetAttribute("default");

                if (!string.IsNullOrEmpty(defaultXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("default", defaultXmlAttribute);
                }

                var parameteredElementXmlAttribute = xmlReader.GetAttribute("parameteredElement");

                if (!string.IsNullOrEmpty(parameteredElementXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("parameteredElement", parameteredElementXmlAttribute);
                }

                var signatureXmlAttribute = xmlReader.GetAttribute("signature");

                if (!string.IsNullOrEmpty(signatureXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("signature", signatureXmlAttribute);
                }


                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            case "default":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "default");
                                break;
                            case "ownedComment":
                                var ownedCommentValue = (IComment)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "uml:Comment");
                                poco.OwnedComment.Add(ownedCommentValue);
                                break;
                            case "ownedDefault":
                                var ownedDefaultValue = (IParameterableElement)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory);
                                poco.OwnedDefault.Add(ownedDefaultValue);
                                break;
                            case "ownedParameteredElement":
                                var ownedParameteredElementValue = (IParameterableElement)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory);
                                poco.OwnedParameteredElement.Add(ownedParameteredElementValue);
                                break;
                            case "parameteredElement":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "parameteredElement");
                                break;
                            case "signature":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "signature");
                                break;
                            default:
                                if (this.XmiReaderSettings.UseStrictReading)
                                {
                                    throw new NotSupportedException($"OperationTemplateParameterReader: {xmlReader.LocalName} at line:position {xmlLineInfo.LineNumber}:{xmlLineInfo.LinePosition}");
                                }
                                else
                                {
                                    this.logger.LogWarning("Not Supported: OperationTemplateParameterReader: {LocalName} at line:position {LineNumber}:{LinePosition}", xmlReader.LocalName, xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);
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
