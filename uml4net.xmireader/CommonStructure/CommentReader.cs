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

namespace uml4net.xmi.CommonStructure
{
    using System.Collections.Generic;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using uml4net.POCO;
    using uml4net.POCO.CommonStructure;

    /// <summary>
    /// The purpose of the <see cref="CommentReader"/> is to read an instance of <see cref="IComment"/>
    /// from the XMI document
    /// </summary>
    public class CommentReader : XmiElementReader
    {
        /// <summary>
        /// The <see cref="ILogger"/> used to log
        /// </summary>
        private readonly ILogger<CommentReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to setup logging
        /// </param>
        public CommentReader(Dictionary<string, IXmiElement> cache, ILoggerFactory loggerFactory = null)
            : base(cache, loggerFactory)
        {
            this.logger = this.loggerFactory == null ? NullLogger<CommentReader>.Instance : this.loggerFactory.CreateLogger<CommentReader>();
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
        public IComment Read(XmlReader xmlReader)
        {
            IComment comment = new Comment();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (xmiType != "uml:Comment")
                {
                    throw new XmlException($"The XmiType should be: uml:Comment while it is {xmiType}");
                }

                comment.XmiType = xmiType;

                comment.XmiId = xmlReader.GetAttribute("xmi:id");

                this.cache.Add(comment.XmiId, comment);

                comment.Body = xmlReader.GetAttribute("body");
            }

            return comment;
        }
    }
}