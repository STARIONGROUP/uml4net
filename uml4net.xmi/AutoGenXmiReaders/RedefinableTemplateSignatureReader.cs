// -------------------------------------------------------------------------------------------------
// <copyright file="RedefinableTemplateSignatureReader.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2024 Starion Group S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Readers
{
    using System;
    using System.Linq;
    using System.Xml;

    using Microsoft.Extensions.Logging;

    using uml4net;
    using uml4net.Actions;
    using uml4net.Activities;
    using uml4net.Classification;
    using uml4net.CommonBehavior;
    using uml4net.CommonStructure;
    using uml4net.Deployments;
    using uml4net.InformationFlows;
    using uml4net.Interactions;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StateMachines;
    using uml4net.StructuredClassifiers;
    using uml4net.UseCases;
    using uml4net.Utils;
    using uml4net.Values;
    using uml4net.xmi.Cache;

    /// <summary>
    /// The purpose of the <see cref="RedefinableTemplateSignatureReader"/> is to read an instance of <see cref="IRedefinableTemplateSignature"/>
    /// from the XMI document
    /// </summary>
    public class RedefinableTemplateSignatureReader : XmiElementReader<IRedefinableTemplateSignature>, IXmiElementReader<IRedefinableTemplateSignature>
    {
        private readonly IXmiElementReaderFacade xmiElementReaderFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="RedefinableTemplateSignatureReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public RedefinableTemplateSignatureReader(IXmiReaderCache cache, ILoggerFactory loggerFactory)
            : base(cache, loggerFactory)
        {
            this.xmiElementReaderFacade = new XmiElementReaderFacade();
        }

        /// <summary>
        /// Reads the <see cref="IRedefinableTemplateSignature"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="IRedefinableTemplateSignature"/>
        /// </returns>
        public override IRedefinableTemplateSignature Read(XmlReader xmlReader)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            var defaultLineInfo = xmlReader as IXmlLineInfo;

            IRedefinableTemplateSignature poco = new RedefinableTemplateSignature();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:RedefinableTemplateSignature")
                {
                    throw new XmlException($"The XmiType should be 'uml:RedefinableTemplateSignature' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:RedefinableTemplateSignature";
                }

                poco.XmiType = xmiType;

                poco.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(poco.XmiId, poco);

                var classifierXmlAttribute = xmlReader.GetAttribute("classifier");
                if (!string.IsNullOrEmpty(classifierXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("classifier", classifierXmlAttribute);
                }

                var extendedSignatureXmlAttribute = xmlReader.GetAttribute("extendedSignature");
                if (!string.IsNullOrEmpty(extendedSignatureXmlAttribute))
                {
                    var extendedSignatureXmlAttributeValues = extendedSignatureXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("extendedSignature", extendedSignatureXmlAttributeValues);
                }

                var isLeafXmlAttribute = xmlReader.GetAttribute("isLeaf");
                if (!string.IsNullOrEmpty(isLeafXmlAttribute))
                {
                    poco.IsLeaf = bool.Parse(isLeafXmlAttribute);
                }

                poco.Name = xmlReader.GetAttribute("name");

                var parameterXmlAttribute = xmlReader.GetAttribute("parameter");
                if (!string.IsNullOrEmpty(parameterXmlAttribute))
                {
                    var parameterXmlAttributeValues = parameterXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("parameter", parameterXmlAttributeValues);
                }

                var visibilityXmlAttribute = xmlReader.GetAttribute("visibility");
                if (!string.IsNullOrEmpty(visibilityXmlAttribute))
                {
                    poco.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibilityXmlAttribute, true);
                }


                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            case "classifier":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "classifier");
                                break;
                            case "extendedSignature":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "extendedSignature");
                                break;
                            case "isLeaf":
                                var isLeafValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isLeafValue))
                                {
                                    poco.IsLeaf = bool.Parse(isLeafValue);
                                }
                                break;
                            case "name":
                                poco.Name = xmlReader.ReadElementContentAsString();
                                break;
                            case "nameExpression":
                                var nameExpressionValue = (IStringExpression)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:StringExpression");
                                poco.NameExpression.Add(nameExpressionValue);
                                break;
                            case "ownedComment":
                                var ownedCommentValue = (IComment)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Comment");
                                poco.OwnedComment.Add(ownedCommentValue);
                                break;
                            case "ownedParameter":
                                var ownedParameterValue = (ITemplateParameter)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:TemplateParameter");
                                poco.OwnedParameter.Add(ownedParameterValue);
                                break;
                            case "parameter":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "parameter");
                                break;
                            case "visibility":
                                var visibilityValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(visibilityValue))
                                {
                                    poco.Visibility = (VisibilityKind)Enum.Parse(typeof(VisibilityKind), visibilityValue, true); ;
                                }
                                break;
                            default:
                                throw new NotSupportedException($"RedefinableTemplateSignatureReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
                        }
                    }
                }
            }

            return poco;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
