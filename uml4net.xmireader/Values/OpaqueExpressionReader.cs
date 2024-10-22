// -------------------------------------------------------------------------------------------------
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

namespace uml4net.xmi.Values
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using uml4net.POCO;
    using uml4net.POCO.CommonStructure;
    using uml4net.POCO.Values;
    using uml4net.xmi.CommonStructure;

    /// <summary>
    /// The purpose of the <see cref="OpaqueExpressionReader"/> is to read an instance of <see cref="IOpaqueExpression"/>
    /// from the XMI document
    /// </summary>
    public class OpaqueExpressionReader : XmiElementReader
    {
        /// <summary>
        /// The <see cref="ILogger"/> used to log
        /// </summary>
        private readonly ILogger<OpaqueExpressionReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpaqueExpressionReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to setup logging
        /// </param>
        public OpaqueExpressionReader(Dictionary<string, IXmiElement> cache, ILoggerFactory loggerFactory = null)
            : base(cache, loggerFactory)
        {
            this.logger = this.loggerFactory == null  ? NullLogger<OpaqueExpressionReader>.Instance  : this.loggerFactory.CreateLogger<OpaqueExpressionReader>();
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
        public IOpaqueExpression Read(XmlReader xmlReader)
        {
            IOpaqueExpression opaqueExpression = new OpaqueExpression();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (xmiType != "uml:OpaqueExpression")
                {
                    throw new XmlException($"The XmiType should be: uml:OpaqueExpression while it is {xmiType}");
                }

                opaqueExpression.XmiType = xmiType;

                opaqueExpression.XmiId = xmlReader.GetAttribute("xmi:id");

                this.cache.Add(opaqueExpression.XmiId, opaqueExpression);

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            case "body":
                                opaqueExpression.Body.Add(xmlReader.ReadElementContentAsString());
                                break;
                            case "language":
                                opaqueExpression.Language.Add(xmlReader.ReadElementContentAsString());
                                break;
                            case "ownedComment":
                                using (var ownedCommentXmlReader = xmlReader.ReadSubtree())
                                {
                                    var commentReader = new CommentReader(this.cache, this.loggerFactory);
                                    var comment = commentReader.Read(ownedCommentXmlReader);
                                    opaqueExpression.OwnedComment.Add(comment);
                                }
                                break;
                            default:
                                throw new NotImplementedException($"OpaqueExpressionReader: {xmlReader.LocalName}");
                        }
                    }
                }
            }

            return opaqueExpression;
        }
    }
}
