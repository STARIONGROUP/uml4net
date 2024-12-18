﻿// -------------------------------------------------------------------------------------------------
//  <copyright file="OperationReader.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Readers.Classification
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    using Microsoft.Extensions.Logging;

    using uml4net;
    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.Utils;
    using uml4net.xmi.Cache;
    using uml4net.xmi.Readers;

    /// <summary>
    /// The purpose of the <see cref="OperationReader"/> is to read an instance of <see cref="IOperation"/>
    /// from the XMI document
    /// </summary>
    public class OperationReader : XmiElementReader<IOperation>, IXmiElementReader<IOperation>
    {
        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IComment"/>
        /// </summary>
        public IXmiElementReader<IConstraint> ConstraintReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IComment"/>
        /// </summary>
        public IXmiElementReader<IComment> CommentReader { get; set; }

        /// <summary>
        /// Gets the INJECTED <see cref="IXmiElementReader{T}"/> of <see cref="IParameter"/>
        /// </summary>
        public IXmiElementReader<IParameter> ParameterReader { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="logger">
        /// The (injected) <see cref="ILogger{T}"/> used to setup logging
        /// </param>
        public OperationReader(IXmiReaderCache cache, ILogger<OperationReader> logger)
            : base(cache, logger)
        {
        }

        /// <summary>
        /// Reads the <see cref="IProperty"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="IProperty"/>
        /// </returns>
        public override IOperation Read(XmlReader xmlReader)
        {
            Guard.ThrowIfNull(xmlReader);

            IOperation operation = new Operation();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:Operation")
                {
                    throw new XmlException($"The XmiType should be 'uml:Operation' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:Operation";
                }

                operation.XmiType = xmiType;

                operation.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(operation.XmiId, operation);

                operation.Name = xmlReader.GetAttribute("name");

                var isAbstract = xmlReader.GetAttribute("isAbstract");
                if (!string.IsNullOrEmpty(isAbstract))
                {
                    operation.IsAbstract = bool.Parse(isAbstract);
                }

                var isQuery = xmlReader.GetAttribute("isQuery");
                if (!string.IsNullOrEmpty(isQuery))
                {
                    operation.IsQuery = bool.Parse(isQuery);
                }

                var visibility = xmlReader.GetAttribute("visibility");
                if (!string.IsNullOrEmpty(visibility))
                {
                    operation.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibility, true);
                }

                var bodyCondition = xmlReader.GetAttribute("bodyCondition");
                if (!string.IsNullOrEmpty(bodyCondition))
                {
                    operation.MultiValueReferencePropertyIdentifiers.Add("BodyCondition", new List<string> { bodyCondition } );
                }

                var preconditions = new List<string>();
                var redefinedOperations = new List<string>();

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
                                    operation.OwnedComment.Add(comment);
                                }
                                break;
                            case "ownedParameter":
                                using (var ownedParameterXmlReader = xmlReader.ReadSubtree())
                                {
                                    var parameter = this.ParameterReader.Read(ownedParameterXmlReader);
                                    operation.OwnedParameter.Add(parameter);
                                }
                                break;
                            case "ownedRule":
                                using (var ownedRuleXmlReader = xmlReader.ReadSubtree())
                                {
                                    var constraint = this.ConstraintReader.Read(ownedRuleXmlReader);
                                    operation.OwnedRule.Add(constraint);
                                }
                                break;
                            case "precondition":
                                using (var preconditionXmlReader = xmlReader.ReadSubtree())
                                {
                                    if (preconditionXmlReader.MoveToContent() == XmlNodeType.Element)
                                    {
                                        var href = preconditionXmlReader.GetAttribute("href");
                                        if (!string.IsNullOrEmpty(href))
                                        {
                                            preconditions.Add(href);
                                        }
                                        else if (preconditionXmlReader.GetAttribute("xmi:idref") is { Length: > 0 } idRef)
                                        {
                                            preconditions.Add(idRef);
                                        }
                                        else
                                        {
                                            throw new InvalidOperationException("redefinedProperty xml-attribute reference could not be read");
                                        }
                                    }
                                }
                                break;
                            case "redefinedOperation":
                                using (var redefinedOperationXmlReader = xmlReader.ReadSubtree())
                                {
                                    if (redefinedOperationXmlReader.MoveToContent() == XmlNodeType.Element)
                                    {
                                        var href = redefinedOperationXmlReader.GetAttribute("href");
                                        if (!string.IsNullOrEmpty(href))
                                        {
                                            redefinedOperations.Add(href);
                                        }
                                        else if (redefinedOperationXmlReader.GetAttribute("xmi:idref") is { Length: > 0 } idRef)
                                        {
                                            redefinedOperations.Add(idRef);
                                        }
                                        else
                                        {
                                            throw new InvalidOperationException("redefinedOperation xml-attribute reference could not be read");
                                        }
                                    }
                                }
                                break;
                            default:
                                var defaultLineInfo = xmlReader as IXmlLineInfo;
                                throw new NotSupportedException($"OperationReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
                        }
                    }
                }

                if (preconditions.Count > 0)
                {
                    operation.MultiValueReferencePropertyIdentifiers.Add("precondition", preconditions);
                }

                if (redefinedOperations.Count > 0)
                {
                    operation.MultiValueReferencePropertyIdentifiers.Add("redefinedOperation", redefinedOperations);
                }
            }

            return operation;
        }
    }
}
