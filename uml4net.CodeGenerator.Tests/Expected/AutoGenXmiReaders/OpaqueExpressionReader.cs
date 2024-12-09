// -------------------------------------------------------------------------------------------------
// <copyright file="OpaqueExpressionReader.cs" company="Starion Group S.A.">
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
    using System.Xml;

    using Microsoft.Extensions.Logging;

    using uml4net;
    using uml4net.Classification;
    using uml4net.CommonBehavior;
    using uml4net.CommonStructure;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;
    using uml4net.UseCases;
    using uml4net.Utils;
    using uml4net.Values;
    using uml4net.xmi.Cache;
    using uml4net.xmi.Readers;

    /// <summary>
    /// The purpose of the <see cref="OpaqueExpressionReader"/> is to read an instance of <see cref="IOpaqueExpression"/>
    /// from the XMI document
    /// </summary>
    public class OpaqueExpressionReader : XmiElementReader<IOpaqueExpression>, IXmiElementReader<IOpaqueExpression>
    {
        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IStringExpression"/> to read
        /// the <see cref="IOpaqueExpression.NameExpression"/> property.
        /// </summary>
        public IXmiElementReader<IStringExpression> NameExpressionReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IComment"/> to read
        /// the <see cref="IOpaqueExpression.OwnedComment"/> property.
        /// </summary>
        public IXmiElementReader<IComment> OwnedCommentReader { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="OpaqueExpressionReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="logger">
        /// The (injected) <see cref="ILogger{T}"/> used to set up logging
        /// </param>
        public OpaqueExpressionReader(IXmiReaderCache cache, ILogger<OpaqueExpressionReader> logger)
            : base(cache, logger)
        {
        }

        /// <summary>
        /// Reads the <see cref="IOpaqueExpression"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="IOpaqueExpression"/>
        /// </returns>
        public override IOpaqueExpression Read(XmlReader xmlReader)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            IOpaqueExpression poco = new OpaqueExpression();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:OpaqueExpression")
                {
                    throw new XmlException($"The XmiType should be 'uml:OpaqueExpression' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:OpaqueExpression";
                }

                poco.XmiType = xmiType;

                poco.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(poco.XmiId, poco);

                var bodyXmlAttribute = xmlReader.GetAttribute("body");
                if (!string.IsNullOrEmpty(bodyXmlAttribute))
                {
                    throw new NotSupportedException("DataTypes encoded as XML attributes are not (yet) supported: OpaqueExpression.body");
                }

                var languageXmlAttribute = xmlReader.GetAttribute("language");
                if (!string.IsNullOrEmpty(languageXmlAttribute))
                {
                    throw new NotSupportedException("DataTypes encoded as XML attributes are not (yet) supported: OpaqueExpression.language");
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
                            case "behavior":
                                using (var typeXmlReader = xmlReader.ReadSubtree())
                                {
                                    if (typeXmlReader.MoveToContent() == XmlNodeType.Element)
                                    {
                                        var reference = typeXmlReader.GetAttribute("href");
                                        if (!string.IsNullOrEmpty(reference))
                                        {
                                            poco.SingleValueReferencePropertyIdentifiers.Add("behavior", reference);
                                        }
                                        else if (typeXmlReader.GetAttribute("xmi:idref") is { Length: > 0 } idRef)
                                        {
                                            poco.SingleValueReferencePropertyIdentifiers.Add("behavior", idRef);
                                        }
                                        else
                                        {
                                            throw new InvalidOperationException("behavior xml-attribute reference could not be read");
                                        }
                                    }
                                }
                                break;
                            case "body":
                                var body = xmlReader.ReadElementContentAsString();
                                poco.Body.Add(body);
                                break;
                            case "language":
                                var language = xmlReader.ReadElementContentAsString();
                                poco.Language.Add(language);
                                break;
                            case "name":
                                poco.Name = xmlReader.ReadElementContentAsString();
                                break;
                            case "nameExpression":
                                using (var nameExpressionXmlReader = xmlReader.ReadSubtree())
                                {
                                    var nameExpression = this.NameExpressionReader.Read(nameExpressionXmlReader);
                                    poco.NameExpression.Add(nameExpression);
                                }
                                break;
                            case "ownedComment":
                                using (var ownedCommentXmlReader = xmlReader.ReadSubtree())
                                {
                                    var ownedComment = this.OwnedCommentReader.Read(ownedCommentXmlReader);
                                    poco.OwnedComment.Add(ownedComment);
                                }
                                break;
                            case "owningTemplateParameter":
                                using (var typeXmlReader = xmlReader.ReadSubtree())
                                {
                                    if (typeXmlReader.MoveToContent() == XmlNodeType.Element)
                                    {
                                        var reference = typeXmlReader.GetAttribute("href");
                                        if (!string.IsNullOrEmpty(reference))
                                        {
                                            poco.SingleValueReferencePropertyIdentifiers.Add("owningTemplateParameter", reference);
                                        }
                                        else if (typeXmlReader.GetAttribute("xmi:idref") is { Length: > 0 } idRef)
                                        {
                                            poco.SingleValueReferencePropertyIdentifiers.Add("owningTemplateParameter", idRef);
                                        }
                                        else
                                        {
                                            throw new InvalidOperationException("owningTemplateParameter xml-attribute reference could not be read");
                                        }
                                    }
                                }
                                break;
                            case "templateParameter":
                                using (var typeXmlReader = xmlReader.ReadSubtree())
                                {
                                    if (typeXmlReader.MoveToContent() == XmlNodeType.Element)
                                    {
                                        var reference = typeXmlReader.GetAttribute("href");
                                        if (!string.IsNullOrEmpty(reference))
                                        {
                                            poco.SingleValueReferencePropertyIdentifiers.Add("templateParameter", reference);
                                        }
                                        else if (typeXmlReader.GetAttribute("xmi:idref") is { Length: > 0 } idRef)
                                        {
                                            poco.SingleValueReferencePropertyIdentifiers.Add("templateParameter", idRef);
                                        }
                                        else
                                        {
                                            throw new InvalidOperationException("templateParameter xml-attribute reference could not be read");
                                        }
                                    }
                                }
                                break;
                            case "type":
                                using (var typeXmlReader = xmlReader.ReadSubtree())
                                {
                                    if (typeXmlReader.MoveToContent() == XmlNodeType.Element)
                                    {
                                        var reference = typeXmlReader.GetAttribute("href");
                                        if (!string.IsNullOrEmpty(reference))
                                        {
                                            poco.SingleValueReferencePropertyIdentifiers.Add("type", reference);
                                        }
                                        else if (typeXmlReader.GetAttribute("xmi:idref") is { Length: > 0 } idRef)
                                        {
                                            poco.SingleValueReferencePropertyIdentifiers.Add("type", idRef);
                                        }
                                        else
                                        {
                                            throw new InvalidOperationException("type xml-attribute reference could not be read");
                                        }
                                    }
                                }
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
                                throw new NotSupportedException($"OpaqueExpressionReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
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
