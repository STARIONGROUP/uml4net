// -------------------------------------------------------------------------------------------------
//  <copyright file="ConstraintReader.cs" company="Starion Group S.A.">
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
    using System;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using uml4net.POCO.CommonStructure;

    using uml4net.xmi.Values;

    /// <summary>
    /// The purpose of the <see cref="ConstraintReader"/> is to read an instance of <see cref="IConstraint"/>
    /// from the XMI document
    /// </summary>
    public class ConstraintReader
    {
        /// <summary>
        /// The (injected) <see cref="ILoggerFactory"/> used to setup logging
        /// </summary>
        private readonly ILoggerFactory loggerFactory;

        /// <summary>
        /// The <see cref="ILogger"/> used to log
        /// </summary>
        private readonly ILogger<ConstraintReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstraintReader"/> class.
        /// </summary>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to setup logging
        /// </param>
        public ConstraintReader(ILoggerFactory loggerFactory = null)
        {
            this.loggerFactory = loggerFactory;

            this.logger = this.loggerFactory == null
                ? NullLogger<ConstraintReader>.Instance
                : this.loggerFactory.CreateLogger<ConstraintReader>();
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
        public IConstraint Read(XmlReader xmlReader)
        {
            IConstraint constraint = new Constraint();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                constraint.XmiId = xmlReader.GetAttribute("xmi:id");

                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (xmiType != "uml:Constraint")
                {
                    throw new XmlException($"The XmiType should be: uml:Constraint while it is {xmiType}");
                }

                constraint.XmiType = xmlReader.GetAttribute("xmi:type");

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            case "constrainedElement":
                                this.logger.LogInformation("ConstraintReader.ownedRule not yet implemented");
                                break;
                            case "ownedComment":
                                using (var ownedCommentXmlReader = xmlReader.ReadSubtree())
                                {
                                    var commentReader = new CommentReader(this.loggerFactory);
                                    var comment = commentReader.Read(ownedCommentXmlReader);
                                    constraint.OwnedComment.Add(comment);
                                }
                                break;
                            case "specification":
                                this.ReadValueSpecification(constraint, xmlReader);
                                break;
                            default:
                                throw new NotImplementedException($"ClassReader: {xmlReader.LocalName}");
                        }
                    }
                }
            }

            return constraint;
        }

        /// <summary>
        /// Read the packaged elements
        /// </summary>
        /// <param name="constraint">
        /// The <see cref="IConstraint"/> that the nested <see cref="IValueSpecification"/>> elements are added to
        /// </param>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        private void ReadValueSpecification(IConstraint constraint, XmlReader xmlReader)
        {
            var xmiType = xmlReader.GetAttribute("xmi:type");

            switch (xmiType)
            {
                case "uml:OpaqueExpression":
                    using (var opaqueExpressionXmlReader = xmlReader.ReadSubtree())
                    {
                        var opaqueExpressionReader = new OpaqueExpressionReader(this.loggerFactory);
                        var opaqueExpression = opaqueExpressionReader.Read(opaqueExpressionXmlReader);
                        constraint.Specification = opaqueExpression;
                    }
                    break;
                default:
                    throw new NotImplementedException(xmiType);
            }
        }
    }
}
