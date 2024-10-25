// -------------------------------------------------------------------------------------------------
//  <copyright file="LiteralIntegerReader.cs" company="Starion Group S.A.">
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
    using Cache;
    using System;
    using System.Collections.Generic;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using POCO;
    using uml4net.POCO.CommonStructure;
    using uml4net.POCO.Values;
    using Readers;

    /// <summary>
    /// The purpose of the <see cref="LiteralIntegerReader"/> is to read an instance of <see cref="ILiteralInteger"/>
    /// from the XMI document
    /// </summary>
    public class LiteralIntegerReader : XmiCommentedElementReader<ILiteralInteger>, IXmiElementReader<ILiteralInteger>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LiteralIntegerReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="logger">
        /// The (injected) <see cref="ILogger{T}"/> used to setup logging
        /// </param>
        /// <param name="commentReader">The <see cref="IXmiElementReader{T}"/> of <see cref="IComment"/></param>
        public LiteralIntegerReader(IXmiReaderCache cache, ILogger<LiteralIntegerReader> logger, IXmiElementReader<IComment> commentReader)
            : base(cache, logger, commentReader)
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
        public override ILiteralInteger Read(XmlReader xmlReader)
        {
            ILiteralInteger literalInteger = new LiteralInteger();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (xmiType != "uml:LiteralInteger")
                {
                    throw new XmlException($"The XmiType should be: uml:LiteralInteger while it is {xmiType}");
                }

                literalInteger.XmiType = xmiType;

                literalInteger.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(literalInteger.XmiId, literalInteger);

                var value = xmlReader.GetAttribute("value");
                if (!string.IsNullOrEmpty(value))
                {
                    literalInteger.Value = int.Parse(value);
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
                                    literalInteger.OwnedComment.Add(comment);
                                }
                                break;
                            default:
                                throw new NotImplementedException($"LiteralIntegerReader: {xmlReader.LocalName}");
                        }
                    }
                }
            }

            return literalInteger;
        }
    }
}
