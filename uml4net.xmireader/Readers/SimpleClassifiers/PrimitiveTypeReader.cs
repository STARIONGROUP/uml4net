// -------------------------------------------------------------------------------------------------
//  <copyright file="PrimitiveTypeReader.cs" company="Starion Group S.A.">
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
    using Microsoft.Extensions.Logging;
    using uml4net.POCO.CommonStructure;
    using uml4net.POCO.SimpleClassifiers;
    using uml4net.xmi.Cache;

    using POCO;
    using System.Xml;
    using System;

    public class PrimitiveTypeReader : XmiCommentedElementReader<IPrimitiveType>, IXmiElementReader<IPrimitiveType>
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
        public PrimitiveTypeReader(IXmiReaderCache cache, ILogger<PrimitiveTypeReader> logger, IXmiElementReader<IComment> commentReader)
            : base(cache, logger, commentReader)
        {
        }

        /// <summary>
        /// Reads the <see cref="IPrimitiveType"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="IPrimitiveType"/>
        /// </returns>
        public override IPrimitiveType Read(XmlReader xmlReader)
        {
            IPrimitiveType primitiveType = new PrimitiveType();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (xmiType != "uml:PrimitiveType")
                {
                    throw new XmlException($"The XmiType should be: uml:PrimitiveType while it is {xmiType}");
                }

                primitiveType.XmiType = xmiType;

                primitiveType.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(primitiveType.XmiId, primitiveType);

                primitiveType.Name = xmlReader.GetAttribute("name");

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
                                    primitiveType.OwnedComment.Add(comment);
                                }
                                break;
                            default:
                                throw new NotImplementedException($"PrimitiveTypeReader: {xmlReader.LocalName}");
                        }
                    }
                }
            }

            return primitiveType;
        }
    }
}
