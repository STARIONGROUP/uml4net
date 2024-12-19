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
    using uml4net.xmi.Readers.Classification;
    using uml4net.xmi.Readers.CommonStructure;
    using uml4net.xmi.Readers.Values;

    /// <summary>
    /// The purpose of the <see cref="ParameterReader"/> is to read an instance of <see cref="IParameter"/>
    /// from the XMI document
    /// </summary>
    public class ParameterReader : XmiElementReader<IParameter>, IXmiElementReader<IParameter>
    {
        private readonly IXmiElementReaderFacade xmiElementReaderFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILogger{T}"/> used to setup logging
        /// </param>
        public ParameterReader(IXmiReaderCache cache, ILoggerFactory loggerFactory)
            : base(cache, loggerFactory)
        {
            this.xmiElementReaderFacade = new XmiElementReaderFacade();
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
            Guard.ThrowIfNull(xmlReader);

            IParameter poco = new Parameter();

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

                poco.XmiType = xmiType;

                poco.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(poco.XmiId, poco);

                poco.Name = xmlReader.GetAttribute("name");

                var direction = xmlReader.GetAttribute("direction");
                if (!string.IsNullOrEmpty(direction))
                {
                    poco.Direction = (ParameterDirectionKind)Enum.Parse(typeof(ParameterDirectionKind), direction, true);
                }

                var visibility = xmlReader.GetAttribute("visibility");
                if (!string.IsNullOrEmpty(visibility))
                {
                    poco.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibility, true);
                }

                var type = xmlReader.GetAttribute("type");
                if (!string.IsNullOrEmpty(type))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("type", type);
                }

                var isOrdered = xmlReader.GetAttribute("isOrdered");
                if (!string.IsNullOrEmpty(isOrdered))
                {
                    poco.IsOrdered = bool.Parse(isOrdered);
                }

                var isUnique = xmlReader.GetAttribute("isUnique");
                if (!string.IsNullOrEmpty(isUnique))
                {
                    poco.IsUnique = bool.Parse(isUnique);
                }

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            case "ownedComment":
                                var ownedComment = (IComment)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Comment");
                                poco.OwnedComment.Add(ownedComment);
                                break;
                            case "type":
                                using (var typeXmlReader = xmlReader.ReadSubtree())
                                {
                                    if (typeXmlReader.MoveToContent() == XmlNodeType.Element)
                                    {
                                        var href = typeXmlReader.GetAttribute("href");
                                        if (!string.IsNullOrEmpty(href))
                                        {
                                            poco.SingleValueReferencePropertyIdentifiers.Add("type", href);
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
                            case "lowerValue":
                                using (var lowerValueXmlReader = xmlReader.ReadSubtree())
                                {
                                    if (lowerValueXmlReader.MoveToContent() == XmlNodeType.Element)
                                    {
                                        var reference = lowerValueXmlReader.GetAttribute("xmi:type");

                                        switch (reference)
                                        {
                                            case "uml:LiteralInteger":
                                                var literalIntegerReader = new LiteralIntegerReader(this.Cache, this.LoggerFactory);
                                                var literalInteger = literalIntegerReader.Read(lowerValueXmlReader);
                                                poco.LowerValue.Add(literalInteger);
                                                break;
                                            case "uml:LiteralUnlimitedNatural":
                                                var literalUnlimitedNaturalReader = new LiteralUnlimitedNaturalReader(this.Cache, this.LoggerFactory);
                                                var literalUnlimitedNatural = literalUnlimitedNaturalReader.Read(lowerValueXmlReader);
                                                poco.LowerValue.Add(literalUnlimitedNatural);
                                                break;
                                            default:
                                                throw new InvalidOperationException($"lowerValueXmlReader: type {reference} is unsupported.");
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
                                            switch (reference)
                                            {
                                                case "uml:LiteralInteger":
                                                    var literalIntegerReader = new LiteralIntegerReader(this.Cache, this.LoggerFactory);
                                                    var literalInteger = literalIntegerReader.Read(upperValueXmlReader);
                                                    poco.UpperValue.Add(literalInteger);
                                                    break;
                                                case "uml:LiteralUnlimitedNatural":
                                                    var literalUnlimitedNaturalReader = new LiteralUnlimitedNaturalReader(this.Cache, this.LoggerFactory);
                                                    var literalUnlimitedNatural = literalUnlimitedNaturalReader.Read(upperValueXmlReader);
                                                    poco.UpperValue.Add(literalUnlimitedNatural);
                                                    break;
                                                default:
                                                    throw new InvalidOperationException($"upperValueXmlReader: type {reference} is unsupported.");
                                            }
                                        }
                                    }
                                }
                                break;
                            default:
                                var defaultLineInfo = xmlReader as IXmlLineInfo;
                                throw new NotSupportedException($"ParameterReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
                        }
                    }
                }
            }

            return poco;
        }
    }
}
