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

namespace uml4net.xmi.Values
{
    using System;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using uml4net.POCO.CommonStructure;
    using uml4net.POCO.Values;
    using uml4net.xmi.CommonStructure;

    /// <summary>
    /// The purpose of the <see cref="LiteralIntegerReader"/> is to read an instance of <see cref="ILiteralInteger"/>
    /// from the XMI document
    /// </summary>
    public class LiteralIntegerReader
    {
        /// <summary>
        /// The (injected) <see cref="ILoggerFactory"/> used to setup logging
        /// </summary>
        private readonly ILoggerFactory loggerFactory;

        /// <summary>
        /// The <see cref="ILogger"/> used to log
        /// </summary>
        private readonly ILogger<LiteralIntegerReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LiteralIntegerReader"/> class.
        /// </summary>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to setup logging
        /// </param>
        public LiteralIntegerReader(ILoggerFactory loggerFactory = null)
        {
            this.loggerFactory = loggerFactory;

            this.logger = this.loggerFactory == null ? NullLogger<LiteralIntegerReader>.Instance : this.loggerFactory.CreateLogger<LiteralIntegerReader>();
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
        public ILiteralInteger Read(XmlReader xmlReader)
        {
            ILiteralInteger literalInteger = new LiteralInteger();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                literalInteger.XmiId = xmlReader.GetAttribute("xmi:id");

                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (xmiType != "uml:LiteralInteger")
                {
                    throw new XmlException($"The XmiType should be: uml:LiteralInteger while it is {xmiType}");
                }

                literalInteger.XmiType = xmlReader.GetAttribute("xmi:type");

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
                                    var commentReader = new CommentReader(this.loggerFactory);
                                    var comment = commentReader.Read(ownedCommentXmlReader);
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