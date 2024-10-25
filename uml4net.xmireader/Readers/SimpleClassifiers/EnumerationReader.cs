// -------------------------------------------------------------------------------------------------
//  <copyright file="EnumerationReader.cs" company="Starion Group S.A.">
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
    using System;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using POCO;
    using uml4net.POCO.CommonStructure;
    using uml4net.POCO.SimpleClassifiers;
    using Cache;
    using Readers;

    /// <summary>
    /// The purpose of the <see cref="EnumerationReader"/> is to read an instance of <see cref="IEnumeration"/>
    /// from the XMI document
    /// </summary>
    public class EnumerationReader : XmiCommentedElementReader<IEnumeration>, IXmiElementReader<IEnumeration>
    {
        /// <summary>
        /// The <see cref="IXmiElementReader{T}"/> of <see cref="IEnumerationLiteral"/>
        /// </summary>
        private readonly IXmiElementReader<IEnumerationLiteral> enumerationLiteralReader;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumerationReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="logger">
        /// The (injected) <see cref="ILogger{T}"/> used to setup logging
        /// </param>
        /// <param name="commentReader">The <see cref="IXmiElementReader{T}"/> of <see cref="IComment"/></param>
        /// <param name="enumerationLiteralReader">The <see cref="IXmiElementReader{T}"/> of <see cref="IEnumerationLiteral"/></param>
        public EnumerationReader(IXmiReaderCache cache, ILogger<EnumerationReader> logger, IXmiElementReader<IComment> commentReader, IXmiElementReader<IEnumerationLiteral> enumerationLiteralReader)
            : base(cache, logger, commentReader)
        {
            this.enumerationLiteralReader = enumerationLiteralReader;
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
        public override IEnumeration Read(XmlReader xmlReader)
        {
            IEnumeration enumeration = new Enumeration();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (xmiType != "uml:Enumeration")
                {
                    throw new XmlException($"The XmiType should be: uml:Enumeration while it is {xmiType}");
                }

                enumeration.XmiType = xmiType;

                enumeration.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(enumeration.XmiId, enumeration);

                enumeration.Name = xmlReader.GetAttribute("name");

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
                                    enumeration.OwnedComment.Add(comment);
                                }
                                break;
                            case "ownedLiteral":
                                using (var ownedLiteralXmlReader = xmlReader.ReadSubtree())
                                {
                                    var enumerationLiteral = this.enumerationLiteralReader.Read(ownedLiteralXmlReader);
                                    enumeration.OwnedLiteral.Add(enumerationLiteral);

                                    this.Logger.LogInformation("ClassReader.ownedRule not yet implemented");
                                }
                                break;
                            default:
                                throw new NotImplementedException($"ClassReader: {xmlReader.LocalName}");
                        }
                    }
                }
            }

            return enumeration;
        }
    }
}