// -------------------------------------------------------------------------------------------------
//  <copyright file="EnumerationLiteralReader.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.SimpleClassifiers
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using uml4net.POCO;
    using uml4net.POCO.SimpleClassifiers;

    using uml4net.xmi.CommonStructure;

    /// <summary>
    /// The purpose of the <see cref="EnumerationLiteralReader"/> is to read an instance of <see cref="IEnumerationLiteral"/>
    /// from the XMI document
    /// </summary>
    public class EnumerationLiteralReader : XmiElementReader
    {
        /// <summary>
        /// The <see cref="ILogger"/> used to log
        /// </summary>
        private readonly ILogger<EnumerationLiteralReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumerationLiteralReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to setup logging
        /// </param>
        public EnumerationLiteralReader(Dictionary<string, IXmiElement> cache, ILoggerFactory loggerFactory = null)
            : base(cache, loggerFactory)
        {
            this.logger = this.loggerFactory == null ? NullLogger<EnumerationLiteralReader>.Instance : this.loggerFactory.CreateLogger<EnumerationLiteralReader>();
        }

        /// <summary>
        /// Reads the <see cref="IEnumeration"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="IEnumeration"/>
        /// </returns>
        public IEnumerationLiteral Read(XmlReader xmlReader)
        {
            IEnumerationLiteral enumerationLiteral = new EnumerationLiteral();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (xmiType != "uml:EnumerationLiteral")
                {
                    throw new XmlException($"The XmiType should be: uml:EnumerationLiteral while it is {xmiType}");
                }

                enumerationLiteral.XmiType = xmiType;

                enumerationLiteral.XmiId = xmlReader.GetAttribute("xmi:id");

                this.cache.Add(enumerationLiteral.XmiId, enumerationLiteral);

                enumerationLiteral.Name = xmlReader.GetAttribute("name");

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            case "ownedComment":
                                using (var ownedCommentXmlReader = xmlReader.ReadSubtree())
                                {
                                    var commentReader = new CommentReader(this.cache, this.loggerFactory);
                                    var comment = commentReader.Read(ownedCommentXmlReader);
                                    enumerationLiteral.OwnedComment.Add(comment);
                                }
                                break;
                            default:
                                throw new NotImplementedException($"EnumerationLiteralReader: {xmlReader.LocalName}");
                        }
                    }
                }
            }

            return enumerationLiteral;
        }
    }
}