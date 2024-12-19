// -------------------------------------------------------------------------------------------------
// <copyright file="PseudostateReader.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Readers.StateMachines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    using Microsoft.Extensions.Logging;

    using uml4net;
    using uml4net.Classification;
    using uml4net.CommonBehavior;
    using uml4net.CommonStructure;
    using uml4net.Deployments;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StateMachines;
    using uml4net.StructuredClassifiers;
    using uml4net.UseCases;
    using uml4net.Utils;
    using uml4net.Values;
    using uml4net.xmi.Cache;
    using uml4net.xmi.Readers;

    /// <summary>
    /// The purpose of the <see cref="PseudostateReader"/> is to read an instance of <see cref="IPseudostate"/>
    /// from the XMI document
    /// </summary>
    public class PseudostateReader : XmiElementReader<IPseudostate>, IXmiElementReader<IPseudostate>
    {
        private readonly IXmiElementReaderFacade xmiElementReaderFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="PseudostateReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public PseudostateReader(IXmiReaderCache cache, ILoggerFactory loggerFactory)
            : base(cache, loggerFactory)
        {
            this.xmiElementReaderFacade = new XmiElementReaderFacade();
        }

        /// <summary>
        /// Reads the <see cref="IPseudostate"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="IPseudostate"/>
        /// </returns>
        public override IPseudostate Read(XmlReader xmlReader)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            IPseudostate poco = new Pseudostate();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:Pseudostate")
                {
                    throw new XmlException($"The XmiType should be 'uml:Pseudostate' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:Pseudostate";
                }

                poco.XmiType = xmiType;

                poco.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(poco.XmiId, poco);

                var containerXmlAttribute = xmlReader.GetAttribute("container");
                if (!string.IsNullOrEmpty(containerXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("container", containerXmlAttribute);
                }

                var isLeafXmlAttribute = xmlReader.GetAttribute("isLeaf");
                if (!string.IsNullOrEmpty(isLeafXmlAttribute))
                {
                    poco.IsLeaf = bool.Parse(isLeafXmlAttribute);
                }

                var kindXmlAttribute = xmlReader.GetAttribute("kind");
                if (!string.IsNullOrEmpty(kindXmlAttribute))
                {
                    poco.Kind = (PseudostateKind)Enum.Parse(typeof(PseudostateKind), kindXmlAttribute, true);
                }

                poco.Name = xmlReader.GetAttribute("name");

                var redefinedVertexXmlAttribute = xmlReader.GetAttribute("redefinedVertex");
                if (!string.IsNullOrEmpty(redefinedVertexXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("redefinedVertex", redefinedVertexXmlAttribute);
                }

                var stateXmlAttribute = xmlReader.GetAttribute("state");
                if (!string.IsNullOrEmpty(stateXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("state", stateXmlAttribute);
                }

                var stateMachineXmlAttribute = xmlReader.GetAttribute("stateMachine");
                if (!string.IsNullOrEmpty(stateMachineXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("stateMachine", stateMachineXmlAttribute);
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
                            case "container":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "container");
                                break;
                            case "isLeaf":
                                var isLeafXmlElement = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isLeafXmlElement))
                                {
                                    poco.IsLeaf = bool.Parse(isLeafXmlElement);
                                }
                                break;
                            case "kind":
                                var kindXmlElement = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(kindXmlElement))
                                {
                                    poco.Kind = (PseudostateKind)Enum.Parse(typeof(PseudostateKind), kindXmlElement, true); ;
                                }
                                break;
                            case "name":
                                poco.Name = xmlReader.ReadElementContentAsString();
                                break;
                            case "nameExpression":
                                var nameExpression = (IStringExpression)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:StringExpression");
                                poco.NameExpression.Add(nameExpression);
                                break;
                            case "ownedComment":
                                var ownedComment = (IComment)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Comment");
                                poco.OwnedComment.Add(ownedComment);
                                break;
                            case "redefinedVertex":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "redefinedVertex");
                                break;
                            case "state":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "state");
                                break;
                            case "stateMachine":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "stateMachine");
                                break;
                            case "visibility":
                                var visibilityXmlElement = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(visibilityXmlElement))
                                {
                                    poco.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibilityXmlElement, true); ;
                                }
                                break;
                            default:
                                var defaultLineInfo = xmlReader as IXmlLineInfo;
                                throw new NotSupportedException($"PseudostateReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
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
