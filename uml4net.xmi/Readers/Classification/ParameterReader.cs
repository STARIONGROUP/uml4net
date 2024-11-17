// -------------------------------------------------------------------------------------------------
//  <copyright file="ParameterReader.cs" company="Starion Group S.A.">
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
    using System.Xml;

    using Microsoft.Extensions.Logging;

    using uml4net.POCO;
    using uml4net.POCO.Classification;
    using uml4net.POCO.CommonStructure;
    using uml4net.POCO.Values;
    using uml4net.xmi.Cache;
    using uml4net.xmi.Readers;

    /// <summary>
    /// The purpose of the <see cref="ParameterReader"/> is to read an instance of <see cref="IParameter"/>
    /// from the XMI document
    /// </summary>
    public class ParameterReader : XmiElementReader<IParameter>, IXmiElementReader<IParameter>
    {
        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IComment"/>
        /// </summary>
        public IXmiElementReader<IComment> CommentReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="ILiteralInteger"/>
        /// </summary>
        public IXmiElementReader<ILiteralInteger> LiteralIntegerReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="ILiteralUnlimitedNatural"/>
        /// </summary>
        public IXmiElementReader<ILiteralUnlimitedNatural> LiteralUnlimitedNaturalReader { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="logger">
        /// The (injected) <see cref="ILogger{T}"/> used to setup logging
        /// </param>
        public ParameterReader(IXmiReaderCache cache, ILogger<ParameterReader> logger)
            : base(cache, logger)
        {
        }

        /// <summary>
        /// Reads the <see cref="IParameter"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="IParameter"/>
        /// </returns>
        public override IParameter Read(XmlReader xmlReader)
        {
            IParameter parameter = new Parameter();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:Parameter")
                {
                    throw new XmlException($"The XmiType should be 'uml:Parameter' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:Parameter";
                }

                parameter.XmiType = xmiType;

                parameter.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(parameter.XmiId, parameter);

                parameter.Name = xmlReader.GetAttribute("name");

                var direction = xmlReader.GetAttribute("direction");
                if (!string.IsNullOrEmpty(direction))
                {
                    parameter.Direction = (ParameterDirectionKind)Enum.Parse(typeof(ParameterDirectionKind), direction, true);
                }

                var visibility = xmlReader.GetAttribute("visibility");
                if (!string.IsNullOrEmpty(visibility))
                {
                    parameter.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibility, true);
                }

                var type = xmlReader.GetAttribute("type");
                if (!string.IsNullOrEmpty(type))
                {
                    parameter.SingleValueReferencePropertyIdentifiers.Add("type", type);
                }

                var isOrdered = xmlReader.GetAttribute("isOrdered");
                if (!string.IsNullOrEmpty(isOrdered))
                {
                    parameter.IsOrdered = bool.Parse(isOrdered);
                }

                var isUnique = xmlReader.GetAttribute("isUnique");
                if (!string.IsNullOrEmpty(isUnique))
                {
                    parameter.IsUnique = bool.Parse(isUnique);
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
                                    parameter.OwnedComment.Add(comment);
                                }
                                break;
                            case "type":
                                using (var typeXmlReader = xmlReader.ReadSubtree())
                                {
                                    if (typeXmlReader.MoveToContent() == XmlNodeType.Element)
                                    {
                                        var href = typeXmlReader.GetAttribute("href");
                                        if (!string.IsNullOrEmpty(href))
                                        {
                                            parameter.SingleValueReferencePropertyIdentifiers.Add("type", href);
                                        }
                                        else if (typeXmlReader.GetAttribute("xmi:idref") is { Length: > 0 } idRef)
                                        {
                                            parameter.SingleValueReferencePropertyIdentifiers.Add("type", idRef);
                                        }
                                        else
                                        {
                                            throw new InvalidOperationException("type xml-attribute reference could not be read");
                                        }
                                    }
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
                                            parameter.LowerValue = reference switch
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
                                            parameter.UpperValue = reference switch
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
                            default:
                                var defaultLineInfo = xmlReader as IXmlLineInfo;
                                throw new NotImplementedException($"ParameterReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
                        }
                    }
                }
            }

            return parameter;
        }
    }
}