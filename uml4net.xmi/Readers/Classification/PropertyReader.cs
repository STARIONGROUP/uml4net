// -------------------------------------------------------------------------------------------------
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
    using System;
    using System.Collections.Generic;
    using System.Xml;

    using Microsoft.Extensions.Logging;

    using uml4net.POCO;
    using uml4net.POCO.Classification;
    using uml4net.POCO.CommonStructure;
    using uml4net.POCO.Values;
    using uml4net.xmi.Cache;
    using uml4net.xmi.Readers;

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
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IOpaqueExpression"/>
        /// </summary>
        public IXmiElementReader<IOpaqueExpression> OpaqueExpressionReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IInstanceValue"/>
        /// </summary>
        public IXmiElementReader<IInstanceValue> InstanceValueReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="ILiteralBoolean"/>
        /// </summary>
        public IXmiElementReader<ILiteralBoolean> LiteralBooleanReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="ILiteralString"/>
        /// </summary>
        public IXmiElementReader<ILiteralString> LiteralStringReader { get; set; }
        
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

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:Property")
                {
                    throw new XmlException($"The XmiType should be 'uml:Property' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:Property";
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

                var association = xmlReader.GetAttribute("association");
                if (!string.IsNullOrEmpty(association))
                {
                    property.SingleValueReferencePropertyIdentifiers.Add("association", association);
                }

                var redefinedPropertys = new List<string>();
                var subsettedPropertys = new List<string>();

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
                                using (var lowerValueXmlReader = xmlReader.ReadSubtree())
                                {
                                    if (lowerValueXmlReader.MoveToContent() == XmlNodeType.Element)
                                    {
                                        var reference = lowerValueXmlReader.GetAttribute("xmi:type");
                                        if (!string.IsNullOrEmpty(reference))
                                        {
                                            property.LowerValue = reference switch
                                            {
                                                "uml:LiteralInteger" => this.LiteralIntegerReader.Read(lowerValueXmlReader),
                                                "uml:LiteralUnlimitedNatural" => this.LiteralUnlimitedNaturalReader.Read(lowerValueXmlReader),
                                                _ => throw new InvalidOperationException($"lowerValueXmlReader: type {reference} is unsupported.")
                                            };
                                        }
                                        else
                                        {
                                            throw new InvalidOperationException("lowerValue xmi:type reference could not be read");
                                        }
                                    }
                                }
                                break;
                            case "upperValue":
                                using (var upperValueXmlReader = xmlReader.ReadSubtree())
                                {
                                    if (upperValueXmlReader.MoveToContent() == XmlNodeType.Element)
                                    {
                                        var reference = upperValueXmlReader.GetAttribute("xmi:type");
                                        if (!string.IsNullOrEmpty(reference))
                                        {
                                            property.UpperValue = reference switch
                                            {
                                                "uml:LiteralInteger" => this.LiteralIntegerReader.Read(upperValueXmlReader),
                                                "uml:LiteralUnlimitedNatural" => this.LiteralUnlimitedNaturalReader.Read(upperValueXmlReader),
                                                _ => throw new InvalidOperationException($"upperValueXmlReader: type {reference} is unsupported.")
                                            };
                                        }
                                        else
                                        {
                                            throw new InvalidOperationException("upperValue xmi:type reference could not be read");
                                        }
                                    }
                                }
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
                                        var href = subsettedPropertyXmlReader.GetAttribute("href");
                                        if (!string.IsNullOrEmpty(href))
                                        {
                                            subsettedPropertys.Add(href);
                                        }
                                        else if (subsettedPropertyXmlReader.GetAttribute("xmi:idref") is { Length: > 0 } idRef)
                                        {
                                            subsettedPropertys.Add(idRef);
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
                                this.ReadValueSpecification(property, xmlReader);
                                break;
                            case "redefinedProperty":
                                using (var redefinedPropertyXmlReader = xmlReader.ReadSubtree())
                                {
                                    if (redefinedPropertyXmlReader.MoveToContent() == XmlNodeType.Element)
                                    {
                                        var href = redefinedPropertyXmlReader.GetAttribute("href");
                                        if (!string.IsNullOrEmpty(href))
                                        {
                                            redefinedPropertys.Add(href);
                                        }
                                        else if (redefinedPropertyXmlReader.GetAttribute("xmi:idref") is { Length: > 0 } idRef)
                                        {
                                            redefinedPropertys.Add(idRef);
                                        }
                                        else
                                        {
                                            throw new InvalidOperationException("redefinedProperty xml-attribute reference could not be read");
                                        }
                                    }
                                }
                                break;
                            default:
                                var defaultLineInfo = xmlReader as IXmlLineInfo;
                                throw new NotImplementedException($"PropertyReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
                        }
                    }
                }

                if (redefinedPropertys.Count > 0)
                {
                    property.MultiValueReferencePropertyIdentifiers.Add("redefinedProperty", redefinedPropertys);
                }

                if (subsettedPropertys.Count > 0)
                {
                    property.MultiValueReferencePropertyIdentifiers.Add("subsettedProperty", subsettedPropertys);
                }
            }

            return property;
        }

        /// <summary>
        /// Read the packaged elements
        /// </summary>
        /// <param name="property">
        /// The <see cref="IProperty"/> that the nested <see cref="IValueSpecification"/>> elements are added to
        /// </param>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        private void ReadValueSpecification(IProperty property, XmlReader xmlReader)
        {
            var xmiType = xmlReader.GetAttribute("xmi:type");

            switch (xmiType)
            {
                case "uml:InstanceValue":
                    using (var instanceValueXmlReader = xmlReader.ReadSubtree())
                    {
                        var instanceValue = this.InstanceValueReader.Read(instanceValueXmlReader);
                        property.DefaultValue = instanceValue;
                    }
                    break;
                case "uml:LiteralBoolean":
                    using (var literalBooleanXmlReader = xmlReader.ReadSubtree())
                    {
                        var literalBoolean = this.LiteralBooleanReader.Read(literalBooleanXmlReader);
                        property.DefaultValue = literalBoolean;
                    }
                    break;
                case "uml:LiteralInteger":
                    using (var literalIntegerXmlReader = xmlReader.ReadSubtree())
                    {
                        var literalInteger = this.LiteralIntegerReader.Read(literalIntegerXmlReader);
                        property.DefaultValue = literalInteger;
                    }
                    break;
                case "uml:LiteralString":
                    using (var literalStringXmlReader = xmlReader.ReadSubtree())
                    {
                        var literalString = this.LiteralStringReader.Read(literalStringXmlReader);
                        property.DefaultValue = literalString;
                    }
                    break;
                case "uml:LiteralUnlimitedNatural":
                    using (var literalUnlimitedNaturalXmlReader = xmlReader.ReadSubtree())
                    {
                        var literalUnlimitedNatural = this.LiteralUnlimitedNaturalReader.Read(literalUnlimitedNaturalXmlReader);
                        property.DefaultValue = literalUnlimitedNatural;
                    }
                    break;
                case "uml:OpaqueExpression":
                    using (var opaqueExpressionXmlReader = xmlReader.ReadSubtree())
                    {
                        var opaqueExpression = this.OpaqueExpressionReader.Read(opaqueExpressionXmlReader);
                        property.DefaultValue = opaqueExpression;
                    }
                    break;
                default:
                    var defaultLineInfo = xmlReader as IXmlLineInfo;
                    throw new NotImplementedException($"PropertyReader.ReadValueSpecification: {xmiType} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
            }
        }
    }
}
