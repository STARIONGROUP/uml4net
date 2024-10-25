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

namespace uml4net.xmi.Readers.SimpleClassifiers
{
    using Cache;
    using System;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using POCO.CommonStructure;
    using POCO;
    using uml4net.POCO.SimpleClassifiers;

    using Readers;

    /// <summary>
    /// The purpose of the <see cref="EnumerationLiteralReader"/> is to read an instance of <see cref="IEnumerationLiteral"/>
    /// from the XMI document
    /// </summary>
    public class EnumerationLiteralReader : XmiCommentedElementReader<IEnumerationLiteral>, IXmiElementReader<IEnumerationLiteral>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumerationLiteralReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="logger">
        /// The (injected) <see cref="ILogger{T}"/> used to setup logging
        /// </param>
        /// <param name="commentReader">The <see cref="IXmiElementReader{T}"/> of <see cref="IComment"/></param>
        public EnumerationLiteralReader(IXmiReaderCache cache, ILogger<EnumerationLiteralReader> logger, IXmiElementReader<IComment> commentReader)
            : base(cache, logger, commentReader)
        {
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
        public override IEnumerationLiteral Read(XmlReader xmlReader)
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

                this.Cache.Add(enumerationLiteral.XmiId, enumerationLiteral);

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
                                    var comment = this.CommentReader.Read(ownedCommentXmlReader);
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
