// -------------------------------------------------------------------------------------------------
// <copyright file="DurationReader.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Readers.Values
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
    using uml4net.StructuredClassifiers;
    using uml4net.UseCases;
    using uml4net.Utils;
    using uml4net.Values;
    using uml4net.xmi.Cache;
    using uml4net.xmi.Readers;

    /// <summary>
    /// The purpose of the <see cref="DurationReader"/> is to read an instance of <see cref="IDuration"/>
    /// from the XMI document
    /// </summary>
    public class DurationReader : XmiElementReader<IDuration>, IXmiElementReader<IDuration>
    {
        private readonly IXmiElementReaderFacade xmiElementReaderFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="DurationReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public DurationReader(IXmiReaderCache cache, ILoggerFactory loggerFactory)
            : base(cache, loggerFactory)
        {
            this.xmiElementReaderFacade = new XmiElementReaderFacade();
        }

        /// <summary>
        /// Reads the <see cref="IDuration"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="IDuration"/>
        /// </returns>
        public override IDuration Read(XmlReader xmlReader)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            IDuration poco = new Duration();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:Duration")
                {
                    throw new XmlException($"The XmiType should be 'uml:Duration' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:Duration";
                }

                poco.XmiType = xmiType;

                poco.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(poco.XmiId, poco);

                poco.Name = xmlReader.GetAttribute("name");

                var observationXmlAttribute = xmlReader.GetAttribute("observation");
                if (!string.IsNullOrEmpty(observationXmlAttribute))
                {
                    var observationXmlAttributeValues = observationXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("observation", observationXmlAttributeValues);
                }

                var owningTemplateParameterXmlAttribute = xmlReader.GetAttribute("owningTemplateParameter");
                if (!string.IsNullOrEmpty(owningTemplateParameterXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("owningTemplateParameter", owningTemplateParameterXmlAttribute);
                }

                var templateParameterXmlAttribute = xmlReader.GetAttribute("templateParameter");
                if (!string.IsNullOrEmpty(templateParameterXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("templateParameter", templateParameterXmlAttribute);
                }

                var typeXmlAttribute = xmlReader.GetAttribute("type");
                if (!string.IsNullOrEmpty(typeXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("type", typeXmlAttribute);
                }

                var visibilityXmlAttribute = xmlReader.GetAttribute("visibility");
                if (!string.IsNullOrEmpty(visibilityXmlAttribute))
                {
                    poco.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibilityXmlAttribute, true);
                }


                var observation = new List<string>();

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            case "expr":
                                var expr = (IValueSpecification)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory);
                                poco.Expr.Add(expr);
                                break;
                            case "name":
                                poco.Name = xmlReader.ReadElementContentAsString();
                                break;
                            case "nameExpression":
                                var nameExpression = (IStringExpression)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:StringExpression");
                                poco.NameExpression.Add(nameExpression);
                                break;
                            case "observation":
                                this.CollectMultiValueReferencePropertyIdentifiers(xmlReader, observation, "observation");
                                break;
                            case "ownedComment":
                                var ownedComment = (IComment)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Comment");
                                poco.OwnedComment.Add(ownedComment);
                                break;
                            case "owningTemplateParameter":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "owningTemplateParameter");
                                break;
                            case "templateParameter":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "templateParameter");
                                break;
                            case "type":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "type");
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
                                throw new NotSupportedException($"DurationReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
                        }
                    }
                }

                if (observation.Count > 0)
                {
                    poco.MultiValueReferencePropertyIdentifiers.Add("observation", observation);
                }

            }

            return poco;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
