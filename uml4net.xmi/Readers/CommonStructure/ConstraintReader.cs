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

namespace uml4net.xmi.Readers.CommonStructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    using Microsoft.Extensions.Logging;

    using uml4net;
    using uml4net.Classification;
    using uml4net.CommonBehavior;
    using uml4net.CommonStructure;
    using uml4net.Deployments;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;
    using uml4net.UseCases;
    using uml4net.Utils;
    using uml4net.Values;
    using uml4net.xmi.Cache;
    using uml4net.xmi.Readers;
    using uml4net.xmi.Readers.Classification;
    using uml4net.xmi.Readers.CommonStructure;
    using uml4net.xmi.Readers.Values;

    /// <summary>
    /// The purpose of the <see cref="ConstraintReader"/> is to read an instance of <see cref="IConstraint"/>
    /// from the XMI document
    /// </summary>
    public class ConstraintReader : XmiElementReader<IConstraint>, IXmiElementReader<IConstraint>
    {
        private readonly IXmiElementReaderFacade xmiElementReaderFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstraintReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> are stored
        /// </param>
        /// <param name="logger">
        /// The <see cref="ILogger{T}"/>
        /// </param>
        public ConstraintReader(IXmiReaderCache cache, ILoggerFactory loggerFactory)
            : base(cache, loggerFactory)
        {
            this.xmiElementReaderFacade = new XmiElementReaderFacade();
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
            Guard.ThrowIfNull(xmlReader);

            IConstraint poco = new Constraint();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:Constraint")
                {
                    throw new XmlException($"The XmiType should be 'uml:Constraint' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:Constraint";
                }

                poco.XmiType = xmiType;

                poco.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(poco.XmiId, poco);

                var constrainedElement = new List<string>();

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            case "constrainedElement":

                                using (var constrainedElementXmlReader = xmlReader.ReadSubtree())
                                {
                                    if (constrainedElementXmlReader.MoveToContent() == XmlNodeType.Element)
                                    {
                                        var href = constrainedElementXmlReader.GetAttribute("href");
                                        if (!string.IsNullOrEmpty(href))
                                        {
                                            constrainedElement.Add(href);
                                        }
                                        else if (constrainedElementXmlReader.GetAttribute("xmi:idref") is { Length: > 0 } idRef)
                                        {
                                            constrainedElement.Add(idRef);
                                        }
                                        else
                                        {
                                            throw new InvalidOperationException("constrainedElement xml-attribute reference could not be read");
                                        }
                                    }
                                }

                                break;
                            case "ownedComment":
                                var ownedComment = (IComment)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Comment");
                                poco.OwnedComment.Add(ownedComment);
                                break;
                            case "specification":
                                this.ReadValueSpecification(poco, xmlReader);
                                break;
                            default:
                                var defaultLineInfo = xmlReader as IXmlLineInfo;
                                throw new NotSupportedException($"ConstraintReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
                        }
                    }
                }

                if (constrainedElement.Count > 0)
                {
                    poco.MultiValueReferencePropertyIdentifiers.Add("ConstrainedElement", constrainedElement);
                }
            }

            return poco;
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
                        var opaqueExpressionReader = new OpaqueExpressionReader(this.Cache, this.LoggerFactory);
                        var opaqueExpression = opaqueExpressionReader.Read(opaqueExpressionXmlReader);
                        constraint.Specification.Add(opaqueExpression);
                    }
                    break;
                default:
                    throw new NotSupportedException(xmiType);
            }
        }
    }
}
