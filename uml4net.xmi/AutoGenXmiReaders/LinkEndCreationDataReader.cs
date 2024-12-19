// -------------------------------------------------------------------------------------------------
// <copyright file="LinkEndCreationDataReader.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Readers.Actions
{
    using System;
    using System.Collections.Generic;
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
    using uml4net.Interactions;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;
    using uml4net.UseCases;
    using uml4net.Utils;
    using uml4net.Values;
    using uml4net.xmi.Cache;
    using uml4net.xmi.Readers;

    /// <summary>
    /// The purpose of the <see cref="LinkEndCreationDataReader"/> is to read an instance of <see cref="ILinkEndCreationData"/>
    /// from the XMI document
    /// </summary>
    public class LinkEndCreationDataReader : XmiElementReader<ILinkEndCreationData>, IXmiElementReader<ILinkEndCreationData>
    {
        private readonly IXmiElementReaderFacade xmiElementReaderFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="LinkEndCreationDataReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public LinkEndCreationDataReader(IXmiReaderCache cache, ILoggerFactory loggerFactory)
            : base(cache, loggerFactory)
        {
            this.xmiElementReaderFacade = new XmiElementReaderFacade();
        }

        /// <summary>
        /// Reads the <see cref="ILinkEndCreationData"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="ILinkEndCreationData"/>
        /// </returns>
        public override ILinkEndCreationData Read(XmlReader xmlReader)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            ILinkEndCreationData poco = new LinkEndCreationData();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:LinkEndCreationData")
                {
                    throw new XmlException($"The XmiType should be 'uml:LinkEndCreationData' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:LinkEndCreationData";
                }

                poco.XmiType = xmiType;

                poco.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(poco.XmiId, poco);

                var endXmlAttribute = xmlReader.GetAttribute("end");
                if (!string.IsNullOrEmpty(endXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("end", endXmlAttribute);
                }

                var insertAtXmlAttribute = xmlReader.GetAttribute("insertAt");
                if (!string.IsNullOrEmpty(insertAtXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("insertAt", insertAtXmlAttribute);
                }

                var isReplaceAllXmlAttribute = xmlReader.GetAttribute("isReplaceAll");
                if (!string.IsNullOrEmpty(isReplaceAllXmlAttribute))
                {
                    poco.IsReplaceAll = bool.Parse(isReplaceAllXmlAttribute);
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
                            case "end":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "end");
                                break;
                            case "insertAt":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "insertAt");
                                break;
                            case "isReplaceAll":
                                var isReplaceAllXmlElement = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isReplaceAllXmlElement))
                                {
                                    poco.IsReplaceAll = bool.Parse(isReplaceAllXmlElement);
                                }
                                break;
                            case "ownedComment":
                                var ownedComment = (IComment)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Comment");
                                poco.OwnedComment.Add(ownedComment);
                                break;
                            case "qualifier":
                                var qualifier = (IQualifierValue)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:QualifierValue");
                                poco.Qualifier.Add(qualifier);
                                break;
                            case "value":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "value");
                                break;
                            default:
                                var defaultLineInfo = xmlReader as IXmlLineInfo;
                                throw new NotSupportedException($"LinkEndCreationDataReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
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
