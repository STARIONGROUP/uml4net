﻿// -------------------------------------------------------------------------------------------------
//  <copyright file="PropertyReader.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2024 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, softwareUseCases
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
//  </copyright>
//  ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Readers.Classification
{
    using Cache;
    using System;
    using System.Collections.Generic;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using POCO.Values;
    using POCO;
    using uml4net.POCO.Classification;
    using uml4net.POCO.CommonStructure;

    using Readers;

    /// <summary>
    /// The purpose of the <see cref="PropertyReader"/> is to read an instance of <see cref="IProperty"/>
    /// from the XMI document
    /// </summary>
    public class PropertyReader : XmiElementReader<IProperty>, IXmiElementReader<IProperty>
    {
        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="ILiteralInteger"/>
        /// </summary>
        public IXmiElementReader<ILiteralInteger> LiteralIntegerReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="ILiteralUnlimitedNatural"/>
        /// </summary>
        public IXmiElementReader<ILiteralUnlimitedNatural> LiteralUnlimitedNaturalReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IComment"/>
        /// </summary>
        public IXmiElementReader<IComment> CommentReader { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="logger">
        /// The (injected) <see cref="ILogger{T}"/> used to setup logging
        /// </param>
        public PropertyReader(IXmiReaderCache cache, ILogger<PropertyReader> logger)
            : base(cache, logger)
        {
        }

        /// <summary>
        /// Reads the <see cref="IProperty"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="IProperty"/>
        /// </returns>
        public override IProperty Read(XmlReader xmlReader)
        {
            IProperty property = new Property();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (xmiType != "uml:Property")
                {
                    throw new XmlException($"The XmiType should be: uml:Property while it is {xmiType}");
                }

                property.XmiType = xmiType;

                property.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(property.XmiId, property);

                property.Name = xmlReader.GetAttribute("name");

                var isDerived = xmlReader.GetAttribute("isDerived");
                if (!string.IsNullOrEmpty(isDerived))
                {
                    property.IsDerived = bool.Parse(isDerived);
                }

                var isDerivedUnion = xmlReader.GetAttribute("isDerivedUnion");
                if (!string.IsNullOrEmpty(isDerivedUnion))
                {
                    property.IsDerivedUnion = bool.Parse(isDerivedUnion);
                }

                var isId = xmlReader.GetAttribute("isID");
                if (!string.IsNullOrEmpty(isId))
                {
                    property.IsID = bool.Parse(isId);
                }

                var isLeaf = xmlReader.GetAttribute("isLeaf");
                if (!string.IsNullOrEmpty(isLeaf))
                {
                    property.IsLeaf = bool.Parse(isLeaf);
                }

                var isReadOnly = xmlReader.GetAttribute("isReadOnly");
                if (!string.IsNullOrEmpty(isReadOnly))
                {
                    property.IsReadOnly = bool.Parse(isReadOnly);
                }

                var isStatic = xmlReader.GetAttribute("isStatic");
                if (!string.IsNullOrEmpty(isStatic))
                {
                    property.IsStatic = bool.Parse(isStatic);
                }

                var isOrdered = xmlReader.GetAttribute("isOrdered");
                if (!string.IsNullOrEmpty(isOrdered))
                {
                    property.IsOrdered = bool.Parse(isOrdered);
                }

                var isUnique = xmlReader.GetAttribute("isUnique");
                if (!string.IsNullOrEmpty(isUnique))
                {
                    property.IsUnique = bool.Parse(isUnique);
                }

                var aggregation = xmlReader.GetAttribute("aggregation");
                if (!string.IsNullOrEmpty(aggregation))
                {
                    property.Aggregation = (AggregationKind)Enum.Parse(typeof(AggregationKind), aggregation, true);
                }

                var visibility = xmlReader.GetAttribute("visibility");
                if (!string.IsNullOrEmpty(visibility))
                {
                    property.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibility, true);
                }

                var type = xmlReader.GetAttribute("type");
                if (!string.IsNullOrEmpty(type))
                {
                    property.SingleValueReferencePropertyIdentifiers.Add("type", type);
                }

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            case "ownedComment":
                                using (var ownedCommentXmlReader = xmlReader.ReadSubtree())
                                {
                                    var comment = this.CommentReader.Read(ownedCommentXmlReader);
                                    property.OwnedComment.Add(comment);
                                }
                                break;
                            case "lowerValue":
                                property.LowerValue = this.GetLowerOrUpperValue(xmlReader);
                                break;
                            case "upperValue":
                                property.UpperValue = this.GetLowerOrUpperValue(xmlReader);
                                break;
                            case "nameExpression":
                                using (var nameExpressionXmlReader = xmlReader.ReadSubtree())
                                {
                                    this.Logger.LogDebug("property:nameExpression not yet implemented");
                                }
                                break;
                            case "subsettedProperty":
                                using (var subsettedPropertyXmlReader = xmlReader.ReadSubtree())
                                {
                                    if (subsettedPropertyXmlReader.MoveToContent() == XmlNodeType.Element)
                                    {
                                        var reference = subsettedPropertyXmlReader.GetAttribute("xmi:idref");
                                        if (!string.IsNullOrEmpty(reference))
                                        {
                                            if (property.MultiValueReferencePropertyIdentifiers.TryGetValue("subsettedProperty", out var references))
                                            {
                                                references.Add(reference);
                                            }
                                            else
                                            {
                                                property.MultiValueReferencePropertyIdentifiers.Add("subsettedProperty", new List<string> { reference });
                                            }
                                        }
                                        else
                                        {
                                            throw new InvalidOperationException("subsettedProperty xml-attribute reference could not be read");
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
                                            property.SingleValueReferencePropertyIdentifiers.Add("type", reference);
                                        }
                                        else if (typeXmlReader.GetAttribute("xmi:idref") is { Length: > 0 } idRef)
                                        {
                                            property.SingleValueReferencePropertyIdentifiers.Add("type", idRef);
                                        }
                                        else
                                        {
                                            throw new InvalidOperationException("type xml-attribute reference could not be read");
                                        }
                                    }
                                }
                                break;
                            case "defaultValue":
                                using (var defaultValueXmlReader = xmlReader.ReadSubtree())
                                {
                                    this.Logger.LogDebug("property:defaultValueXmlReader not yet implemented");
                                }
                                break;
                            case "redefinedProperty":
                                using (var redefinedPropertyXmlReader = xmlReader.ReadSubtree())
                                {
                                    this.Logger.LogDebug("property:redefinedProperty not yet implemented");
                                }
                                break;
                            default:
                                throw new NotImplementedException($"PropertyReader: {xmlReader.LocalName}");
                        }
                    }
                }
            }

            return property;
        }

        /// <summary>
        /// Retrieves the lower or upper value specification based on the type specified in the XML attribute "xmi:type".
        /// </summary>
        /// <param name="readSubtree">
        /// An <see cref="XmlReader"/> positioned at the subtree containing the value specification.
        /// </param>
        /// <returns>
        /// An <see cref="IValueSpecification"/> object representing either a literal integer or literal unlimited natural value,
        /// depending on the "xmi:type" attribute in the XML.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// Thrown when the "xmi:type" attribute contains an unrecognized type.
        /// </exception>
        private IValueSpecification GetLowerOrUpperValue(XmlReader readSubtree)
        {
            try
            {
                using var reader = readSubtree.ReadSubtree();

                if (reader.MoveToContent() == XmlNodeType.Element)
                {
                    return reader.GetAttribute("xmi:type") switch
                    {
                        "uml:LiteralInteger" => this.LiteralIntegerReader.Read(reader),
                        "uml:LiteralUnlimitedNatural" => this.LiteralUnlimitedNaturalReader.Read(reader),
                        _ => throw new NotImplementedException($"PropertyReader: {reader.LocalName}")
                    };
                }
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, "");
            }

            return default;
        }
    }
}