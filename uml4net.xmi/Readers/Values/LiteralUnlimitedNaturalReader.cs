﻿// -------------------------------------------------------------------------------------------------
//  <copyright file="LiteralUnlimitedNaturalReader.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Readers.Values
{
    using System;
    using System.Xml;

    using Microsoft.Extensions.Logging;

    using uml4net;
    using uml4net.CommonStructure;
    using uml4net.Utils;
    using uml4net.Values;
    using uml4net.xmi.Cache;
    using uml4net.xmi.Readers;

    /// <summary>
    /// The purpose of the <see cref="LiteralUnlimitedNaturalReader"/> is to read an instance of <see cref="ILiteralUnlimitedNatural"/>
    /// from the XMI document
    /// </summary>
    public class LiteralUnlimitedNaturalReader : XmiElementReader<ILiteralUnlimitedNatural>, IXmiElementReader<ILiteralUnlimitedNatural>
    {
        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IComment"/>
        /// </summary>
        public IXmiElementReader<IComment> CommentReader { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LiteralUnlimitedNaturalReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="logger">
        /// The (injected) <see cref="ILogger{T}"/> used to setup logging
        /// </param>
        public LiteralUnlimitedNaturalReader(IXmiReaderCache cache, ILogger<LiteralUnlimitedNaturalReader> logger)
            : base(cache, logger)
        {
        }

        /// <summary>
        /// Reads the <see cref="IConstraint"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="IConstraint"/>
        /// </returns>
        public override ILiteralUnlimitedNatural Read(XmlReader xmlReader)
        {
            Guard.ThrowIfNull(xmlReader);

            ILiteralUnlimitedNatural literalUnlimitedNatural = new LiteralUnlimitedNatural();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:LiteralUnlimitedNatural")
                {
                    throw new XmlException($"The XmiType should be 'uml:LiteralUnlimitedNatural' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:LiteralUnlimitedNatural";
                }

                literalUnlimitedNatural.XmiType = xmiType;

                literalUnlimitedNatural.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(literalUnlimitedNatural.XmiId, literalUnlimitedNatural);

                var value = xmlReader.GetAttribute("value");

                if (value == "*")
                {
                    literalUnlimitedNatural.Value = int.MaxValue;
                }
                else if (!string.IsNullOrEmpty(value))
                {
                    literalUnlimitedNatural.Value = int.Parse(value);
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
                                    literalUnlimitedNatural.OwnedComment.Add(comment);
                                }
                                break;
                            default:
                                var defaultLineInfo = xmlReader as IXmlLineInfo;
                                throw new NotSupportedException($"LiteralUnlimitedNaturalReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
                        }
                    }
                }
            }

            return literalUnlimitedNatural;
        }
    }
}
