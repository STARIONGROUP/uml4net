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
    using System;
    using System.Xml;

    using Microsoft.Extensions.Logging;

    using uml4net.POCO;
    using uml4net.POCO.CommonStructure;
    using uml4net.POCO.Values;
    using uml4net.xmi.Cache;
    using uml4net.xmi.Readers;

    /// <summary>
    /// The purpose of the <see cref="LiteralIntegerReader"/> is to read an instance of <see cref="ILiteralInteger"/>
    /// from the XMI document
    /// </summary>
    public class LiteralIntegerReader : XmiElementReader<ILiteralInteger>, IXmiElementReader<ILiteralInteger>
    {
        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IComment"/>
        /// </summary>
        public IXmiElementReader<IComment> CommentReader { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LiteralIntegerReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="logger">
        /// The (injected) <see cref="ILogger{T}"/> used to setup logging
        /// </param>
        public LiteralIntegerReader(IXmiReaderCache cache, ILogger<LiteralIntegerReader> logger)
            : base(cache, logger)
        {
        }

        /// <summary>
        /// Reads the <see cref="ILiteralInteger"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="ILiteralInteger"/>
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
                                var defaultLineInfo = xmlReader as IXmlLineInfo;
                                throw new NotImplementedException($"LiteralIntegerReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
                        }
                    }
                }
            }

            return literalInteger;
        }
    }
}
