// -------------------------------------------------------------------------------------------------
// <copyright file="LinkEndDestructionDataReader.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="LinkEndDestructionDataReader"/> is to read an instance of <see cref="ILinkEndDestructionData"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public class LinkEndDestructionDataReader : XmiElementReader<ILinkEndDestructionData>, IXmiElementReader<ILinkEndDestructionData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LinkEndDestructionDataReader"/> class.
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
        public LinkEndDestructionDataReader(IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, IXmiReaderSettings xmiReaderSettings, ILoggerFactory loggerFactory)
            : base(cache, xmiElementReaderFacade, xmiReaderSettings, loggerFactory)
        {
        }

        /// <summary>
        /// Reads the <see cref="ILinkEndDestructionData"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="ILinkEndDestructionData"/>
        /// </param>
        /// <param name="namespaceUri">
        /// the namespace that the <see cref="ILinkEndDestructionData"/> belongs to
        /// </param>
        /// <returns>
        /// an instance of <see cref="ILinkEndDestructionData"/>
        /// </returns>
        public override ILinkEndDestructionData Read(XmlReader xmlReader, string documentName, string namespaceUri)
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

            ILinkEndDestructionData poco = new LinkEndDestructionData();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:LinkEndDestructionData")
                {
                    throw new XmlException($"The XmiType should be 'uml:LinkEndDestructionData' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:LinkEndDestructionData";
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
                    this.Logger.LogCritical("Failed to add element type [{Poco}] with id [{Id}] as it was already in the Cache. The XMI document seems to have duplicate xmi:id values", "LinkEndDestructionData", poco.XmiId);
                }

                var destroyAtXmlAttribute = xmlReader.GetAttribute("destroyAt");
                if (!string.IsNullOrEmpty(destroyAtXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("destroyAt", destroyAtXmlAttribute);
                }

                var endXmlAttribute = xmlReader.GetAttribute("end");
                if (!string.IsNullOrEmpty(endXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("end", endXmlAttribute);
                }

                var isDestroyDuplicatesXmlAttribute = xmlReader.GetAttribute("isDestroyDuplicates");
                if (!string.IsNullOrEmpty(isDestroyDuplicatesXmlAttribute))
                {
                    poco.IsDestroyDuplicates = bool.Parse(isDestroyDuplicatesXmlAttribute);
                }

                var valueXmlAttribute = xmlReader.GetAttribute("value");
                if (!string.IsNullOrEmpty(valueXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("value", valueXmlAttribute);
                }


                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            case "destroyAt":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "destroyAt");
                                break;
                            case "end":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "end");
                                break;
                            case "isDestroyDuplicates":
                                var isDestroyDuplicatesValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isDestroyDuplicatesValue))
                                {
                                    poco.IsDestroyDuplicates = bool.Parse(isDestroyDuplicatesValue);
                                }
                                break;
                            case "ownedComment":
                                var ownedCommentValue = (IComment)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "uml:Comment");
                                poco.OwnedComment.Add(ownedCommentValue);
                                break;
                            case "qualifier":
                                var qualifierValue = (IQualifierValue)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.LoggerFactory, "uml:QualifierValue");
                                poco.Qualifier.Add(qualifierValue);
                                break;
                            case "value":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "value");
                                break;
                            default:
                                if (this.XmiReaderSettings.UseStrictReading)
                                {
                                    throw new NotSupportedException($"LinkEndDestructionDataReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
                                }
                                else
                                {
                                    this.Logger.LogWarning("Not Supported: LinkEndDestructionDataReader: {LocalName} at line:position {LineNumber}:{LinePosition}", xmlReader.LocalName, defaultLineInfo.LineNumber, defaultLineInfo.LinePosition);
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
