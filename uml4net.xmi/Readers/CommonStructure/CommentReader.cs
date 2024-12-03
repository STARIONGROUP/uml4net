// -------------------------------------------------------------------------------------------------
//  <copyright file="CommentReader.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Readers.CommonStructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    using Microsoft.Extensions.Logging;

    using uml4net;
    using uml4net.CommonStructure;
    using uml4net.Utils;
    using uml4net.xmi.Cache;
    using uml4net.xmi.Readers;

    /// <summary>
    /// The purpose of the <see cref="CommentReader"/> is to read an instance of <see cref="IComment"/>
    /// from the XMI document
    /// </summary>
    public class CommentReader : XmiElementReader<IComment>, IXmiElementReader<IComment>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="logger">
        /// The (injected) <see cref="ILogger{T}"/> used to setup logging
        /// </param>
        public CommentReader(IXmiReaderCache cache, ILogger<CommentReader> logger)
            : base(cache, logger)
        {
        }

        /// <summary>
        /// Reads the <see cref="IComment"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="IComment"/>
        /// </returns>
        public override IComment Read(XmlReader xmlReader)
        {
            Guard.ThrowIfNull(xmlReader);

            IComment comment = new Comment();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:Comment")
                {
                    throw new XmlException($"The XmiType should be 'uml:Comment' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:Comment";
                }

                comment.XmiType = xmiType;

                comment.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(comment.XmiId, comment);

                comment.Body = xmlReader.GetAttribute("body");

                var annotatedElement = xmlReader.GetAttribute("annotatedElement");
                if (!string.IsNullOrEmpty(annotatedElement))
                {
                    comment.MultiValueReferencePropertyIdentifiers.Add("annotatedElement", annotatedElement.Split([' '], StringSplitOptions.RemoveEmptyEntries).ToList());
                }

                var annotatedElements = new List<string>();

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            case "annotatedElement":
                                using (var annotatedElementXmlReader = xmlReader.ReadSubtree())
                                {
                                    if (annotatedElementXmlReader.MoveToContent() == XmlNodeType.Element)
                                    {
                                        var href = annotatedElementXmlReader.GetAttribute("href");
                                        if (!string.IsNullOrEmpty(href))
                                        {
                                            annotatedElements.Add(href);
                                        }
                                        else if (annotatedElementXmlReader.GetAttribute("xmi:idref") is { Length: > 0 } idRef)
                                        {
                                            annotatedElements.Add(idRef);
                                        }
                                        else
                                        {
                                            throw new InvalidOperationException("annotatedElement xml-attribute reference could not be read");
                                        }
                                    }
                                }
                                break;
                            case "body":
                                comment.Body = xmlReader.ReadElementContentAsString();
                                break;
                            default:
                                var defaultLineInfo = xmlReader as IXmlLineInfo;
                                throw new NotImplementedException($"CommentReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
                        }
                    }
                }

                if (annotatedElements.Count > 0)
                {
                    comment.MultiValueReferencePropertyIdentifiers.Add("annotatedElement", annotatedElements);
                }
            }

            return comment;
        }
    }
}
