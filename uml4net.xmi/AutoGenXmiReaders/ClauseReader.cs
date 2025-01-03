// -------------------------------------------------------------------------------------------------
// <copyright file="ClauseReader.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2024 Starion Group S.A.
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

    /// <summary>
    /// The purpose of the <see cref="ClauseReader"/> is to read an instance of <see cref="IClause"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public class ClauseReader : XmiElementReader<IClause>, IXmiElementReader<IClause>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClauseReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The (injected) <see cref="IXmiElementCache"/>> in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="xmiElementReaderFacade">
        /// The (injected) <see cref="IXmiElementReaderFacade"/> used to resolve any
        /// required <see cref="IXmiElementReader{T}"/>
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public ClauseReader(IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, ILoggerFactory loggerFactory)
            : base(cache, xmiElementReaderFacade, loggerFactory)
        {
        }

        /// <summary>
        /// Reads the <see cref="IClause"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="IClause"/>
        /// </param>
        /// <param name="namespaceUri">
        /// the namespace that the <see cref="IClause"/> belongs to
        /// </param>
        /// <returns>
        /// an instance of <see cref="IClause"/>
        /// </returns>
        public override IClause Read(XmlReader xmlReader, string documentName, string namespaceUri)
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

            IClause poco = new Clause();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:Clause")
                {
                    throw new XmlException($"The XmiType should be 'uml:Clause' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:Clause";
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
                    this.Logger.LogCritical("Failed to add element type [{Poco}] with id [{Id}] as it was already in the Cache. The XMI document seems to have duplicate xmi:id values", "Clause", poco.XmiId);
                }

                var bodyXmlAttribute = xmlReader.GetAttribute("body");
                if (!string.IsNullOrEmpty(bodyXmlAttribute))
                {
                    var bodyXmlAttributeValues = bodyXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("body", bodyXmlAttributeValues);
                }

                var bodyOutputXmlAttribute = xmlReader.GetAttribute("bodyOutput");
                if (!string.IsNullOrEmpty(bodyOutputXmlAttribute))
                {
                    var bodyOutputXmlAttributeValues = bodyOutputXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("bodyOutput", bodyOutputXmlAttributeValues);
                }

                var deciderXmlAttribute = xmlReader.GetAttribute("decider");
                if (!string.IsNullOrEmpty(deciderXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("decider", deciderXmlAttribute);
                }

                var predecessorClauseXmlAttribute = xmlReader.GetAttribute("predecessorClause");
                if (!string.IsNullOrEmpty(predecessorClauseXmlAttribute))
                {
                    var predecessorClauseXmlAttributeValues = predecessorClauseXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("predecessorClause", predecessorClauseXmlAttributeValues);
                }

                var successorClauseXmlAttribute = xmlReader.GetAttribute("successorClause");
                if (!string.IsNullOrEmpty(successorClauseXmlAttribute))
                {
                    var successorClauseXmlAttributeValues = successorClauseXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("successorClause", successorClauseXmlAttributeValues);
                }

                var testXmlAttribute = xmlReader.GetAttribute("test");
                if (!string.IsNullOrEmpty(testXmlAttribute))
                {
                    var testXmlAttributeValues = testXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("test", testXmlAttributeValues);
                }


                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            case "body":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "body");
                                break;
                            case "bodyOutput":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "bodyOutput");
                                break;
                            case "decider":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "decider");
                                break;
                            case "ownedComment":
                                var ownedCommentValue = (IComment)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.LoggerFactory, "uml:Comment");
                                poco.OwnedComment.Add(ownedCommentValue);
                                break;
                            case "predecessorClause":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "predecessorClause");
                                break;
                            case "successorClause":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "successorClause");
                                break;
                            case "test":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "test");
                                break;
                            default:
                                throw new NotSupportedException($"ClauseReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
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
