﻿// -------------------------------------------------------------------------------------------------
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

namespace uml4net.xmi.Readers.CommonStructure
{
    using Cache;
    using System;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using POCO.Values;
    using POCO;
    using uml4net.POCO.CommonStructure;

    using Readers;

    /// <summary>
    /// The purpose of the <see cref="ConstraintReader"/> is to read an instance of <see cref="IConstraint"/>
    /// from the XMI document
    /// </summary>
    public class ConstraintReader : XmiElementReader<IConstraint>, IXmiElementReader<IConstraint>
    {
        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IOpaqueExpression"/>
        /// </summary>
        public IXmiElementReader<IOpaqueExpression> OpaqueExpressionReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IComment"/>
        /// </summary>
        public IXmiElementReader<IComment> CommentReader { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstraintReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> are stored
        /// </param>
        /// <param name="logger">
        /// The <see cref="ILogger{T}"/>
        /// </param>
        public ConstraintReader(IXmiReaderCache cache, ILogger<ConstraintReader> logger)
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
        public override IConstraint Read(XmlReader xmlReader)
        {
            IConstraint constraint = new Constraint();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (xmiType != "uml:Constraint")
                {
                    throw new XmlException($"The XmiType should be: uml:Constraint while it is {xmiType}");
                }

                constraint.XmiType = xmiType;

                constraint.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(constraint.XmiId, constraint);

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            case "constrainedElement":
                                this.Logger.LogInformation("ConstraintReader.ownedRule not yet implemented");
                                break;
                            case "ownedComment":
                                using (var ownedCommentXmlReader = xmlReader.ReadSubtree())
                                {
                                    var comment = this.CommentReader.Read(ownedCommentXmlReader);
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
                        var opaqueExpression = this.OpaqueExpressionReader.Read(opaqueExpressionXmlReader);
                        constraint.Specification = opaqueExpression;
                    }
                    break;
                default:
                    throw new NotImplementedException(xmiType);
            }
        }
    }
}