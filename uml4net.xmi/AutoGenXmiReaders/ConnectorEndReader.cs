// -------------------------------------------------------------------------------------------------
// <copyright file="ConnectorEndReader.cs" company="Starion Group S.A.">
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
    using uml4net.Utils;
    using uml4net.Values;
    using uml4net.xmi.Cache;

    /// <summary>
    /// The purpose of the <see cref="ConnectorEndReader"/> is to read an instance of <see cref="IConnectorEnd"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public class ConnectorEndReader : XmiElementReader<IConnectorEnd>, IXmiElementReader<IConnectorEnd>
    {
        private readonly IXmiElementReaderFacade xmiElementReaderFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectorEndReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public ConnectorEndReader(IXmiReaderCache cache, ILoggerFactory loggerFactory)
            : base(cache, loggerFactory)
        {
            this.xmiElementReaderFacade = new XmiElementReaderFacade();
        }

        /// <summary>
        /// Reads the <see cref="IConnectorEnd"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="IConnectorEnd"/>
        /// </returns>
        public override IConnectorEnd Read(XmlReader xmlReader)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            var defaultLineInfo = xmlReader as IXmlLineInfo;

            IConnectorEnd poco = new ConnectorEnd();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:ConnectorEnd")
                {
                    throw new XmlException($"The XmiType should be 'uml:ConnectorEnd' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:ConnectorEnd";
                }

                poco.XmiType = xmiType;

                poco.XmiId = xmlReader.GetAttribute("xmi:id");

                poco.XmiGuid = xmlReader.GetAttribute("xmi:uuid");

                this.Cache.Add(poco.XmiId, poco);

                var isOrderedXmlAttribute = xmlReader.GetAttribute("isOrdered");
                if (!string.IsNullOrEmpty(isOrderedXmlAttribute))
                {
                    poco.IsOrdered = bool.Parse(isOrderedXmlAttribute);
                }

                var isUniqueXmlAttribute = xmlReader.GetAttribute("isUnique");
                if (!string.IsNullOrEmpty(isUniqueXmlAttribute))
                {
                    poco.IsUnique = bool.Parse(isUniqueXmlAttribute);
                }

                var partWithPortXmlAttribute = xmlReader.GetAttribute("partWithPort");
                if (!string.IsNullOrEmpty(partWithPortXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("partWithPort", partWithPortXmlAttribute);
                }

                var roleXmlAttribute = xmlReader.GetAttribute("role");
                if (!string.IsNullOrEmpty(roleXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("role", roleXmlAttribute);
                }


                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            case "isOrdered":
                                var isOrderedValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isOrderedValue))
                                {
                                    poco.IsOrdered = bool.Parse(isOrderedValue);
                                }
                                break;
                            case "isUnique":
                                var isUniqueValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isUniqueValue))
                                {
                                    poco.IsUnique = bool.Parse(isUniqueValue);
                                }
                                break;
                            case "lowerValue":
                                var lowerValueValue = (IValueSpecification)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory);
                                poco.LowerValue.Add(lowerValueValue);
                                break;
                            case "ownedComment":
                                var ownedCommentValue = (IComment)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Comment");
                                poco.OwnedComment.Add(ownedCommentValue);
                                break;
                            case "partWithPort":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "partWithPort");
                                break;
                            case "role":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "role");
                                break;
                            case "upperValue":
                                var upperValueValue = (IValueSpecification)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory);
                                poco.UpperValue.Add(upperValueValue);
                                break;
                            default:
                                throw new NotSupportedException($"ConnectorEndReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
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
