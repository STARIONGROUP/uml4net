// -------------------------------------------------------------------------------------------------
// <copyright file="StateInvariantReader.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Readers.Interactions
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
    /// The purpose of the <see cref="StateInvariantReader"/> is to read an instance of <see cref="IStateInvariant"/>
    /// from the XMI document
    /// </summary>
    public class StateInvariantReader : XmiElementReader<IStateInvariant>, IXmiElementReader<IStateInvariant>
    {
        private readonly IXmiElementReaderFacade xmiElementReaderFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="StateInvariantReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public StateInvariantReader(IXmiReaderCache cache, ILoggerFactory loggerFactory)
            : base(cache, loggerFactory)
        {
            this.xmiElementReaderFacade = new XmiElementReaderFacade();
        }

        /// <summary>
        /// Reads the <see cref="IStateInvariant"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="IStateInvariant"/>
        /// </returns>
        public override IStateInvariant Read(XmlReader xmlReader)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            IStateInvariant poco = new StateInvariant();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:StateInvariant")
                {
                    throw new XmlException($"The XmiType should be 'uml:StateInvariant' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:StateInvariant";
                }

                poco.XmiType = xmiType;

                poco.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(poco.XmiId, poco);

                var coveredXmlAttribute = xmlReader.GetAttribute("covered");
                if (!string.IsNullOrEmpty(coveredXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("covered", coveredXmlAttribute);
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


                var covered = new List<string>();

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            case "covered":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "covered");
                                break;
                            case "enclosingInteraction":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "enclosingInteraction");
                                break;
                            case "enclosingOperand":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "enclosingOperand");
                                break;
                            case "generalOrdering":
                                var generalOrdering = (IGeneralOrdering)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:GeneralOrdering");
                                poco.GeneralOrdering.Add(generalOrdering);
                                break;
                            case "invariant":
                                var invariant = (IConstraint)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Constraint");
                                poco.Invariant.Add(invariant);
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
                            case "visibility":
                                var visibilityXmlElement = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(visibilityXmlElement))
                                {
                                    poco.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibilityXmlElement, true); ;
                                }
                                break;
                            default:
                                var defaultLineInfo = xmlReader as IXmlLineInfo;
                                throw new NotSupportedException($"StateInvariantReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
                        }
                    }
                }

                if (covered.Count > 0)
                {
                    poco.MultiValueReferencePropertyIdentifiers.Add("covered", covered);
                }

            }

            return poco;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
