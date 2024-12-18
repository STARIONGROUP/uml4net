﻿// -------------------------------------------------------------------------------------------------
//  <copyright file="OpaqueExpressionReader.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="OpaqueExpressionReader"/> is to read an instance of <see cref="IOpaqueExpression"/>
    /// from the XMI document
    /// </summary>
    public class OpaqueExpressionReader : XmiElementReader<IOpaqueExpression>, IXmiElementReader<IOpaqueExpression>
    {
        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IComment"/>
        /// </summary>
        public IXmiElementReader<IComment> CommentReader { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpaqueExpressionReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="logger">
        /// The (injected) <see cref="ILogger{T}"/> used to setup logging
        /// </param> 
        /// <param name="commentReader">Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IComment"/></param>
        public OpaqueExpressionReader(IXmiReaderCache cache, ILogger<OpaqueExpressionReader> logger)
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
        public override IOpaqueExpression Read(XmlReader xmlReader)
        {
            Guard.ThrowIfNull(xmlReader);

            IOpaqueExpression opaqueExpression = new OpaqueExpression();

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

                opaqueExpression.XmiType = xmiType;

                opaqueExpression.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(opaqueExpression.XmiId, opaqueExpression);

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            case "body":
                                var body = xmlReader.ReadElementContentAsString();
                                opaqueExpression.Body.Add(body);
                                break;
                            case "language":
                                var language = xmlReader.ReadElementContentAsString();
                                opaqueExpression.Language.Add(language);
                                break;
                            case "ownedComment":
                                using (var ownedCommentXmlReader = xmlReader.ReadSubtree())
                                {
                                    var comment = this.CommentReader.Read(ownedCommentXmlReader);
                                    opaqueExpression.OwnedComment.Add(comment);
                                }
                                break;
                            default:
                                var defaultLineInfo = xmlReader as IXmlLineInfo;
                                throw new NotSupportedException($"OpaqueExpressionReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
                        }
                    }
                }
            }

            return opaqueExpression;
        }
    }
}
