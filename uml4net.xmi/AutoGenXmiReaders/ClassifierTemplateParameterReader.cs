// -------------------------------------------------------------------------------------------------
// <copyright file="ClassifierTemplateParameterReader.cs" company="Starion Group S.A.">
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
    using System.CodeDom.Compiler;
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
    using uml4net.Values;
    using uml4net.xmi.Cache;

    /// <summary>
    /// The purpose of the <see cref="ClassifierTemplateParameterReader"/> is to read an instance of <see cref="IClassifierTemplateParameter"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public class ClassifierTemplateParameterReader : XmiElementReader<IClassifierTemplateParameter>, IXmiElementReader<IClassifierTemplateParameter>
    {
        private readonly IXmiElementReaderFacade xmiElementReaderFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassifierTemplateParameterReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public ClassifierTemplateParameterReader(IXmiReaderCache cache, ILoggerFactory loggerFactory)
            : base(cache, loggerFactory)
        {
            this.xmiElementReaderFacade = new XmiElementReaderFacade();
        }

        /// <summary>
        /// Reads the <see cref="IClassifierTemplateParameter"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="IClassifierTemplateParameter"/>
        /// </returns>
        public override IClassifierTemplateParameter Read(XmlReader xmlReader)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            var defaultLineInfo = xmlReader as IXmlLineInfo;

            IClassifierTemplateParameter poco = new ClassifierTemplateParameter();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:ClassifierTemplateParameter")
                {
                    throw new XmlException($"The XmiType should be 'uml:ClassifierTemplateParameter' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:ClassifierTemplateParameter";
                }

                poco.XmiType = xmiType;

                poco.XmiId = xmlReader.GetAttribute("xmi:id");

                poco.XmiGuid = xmlReader.GetAttribute("xmi:uuid");

                this.Cache.Add(poco.XmiId, poco);

                var allowSubstitutableXmlAttribute = xmlReader.GetAttribute("allowSubstitutable");
                if (!string.IsNullOrEmpty(allowSubstitutableXmlAttribute))
                {
                    poco.AllowSubstitutable = bool.Parse(allowSubstitutableXmlAttribute);
                }

                var constrainingClassifierXmlAttribute = xmlReader.GetAttribute("constrainingClassifier");
                if (!string.IsNullOrEmpty(constrainingClassifierXmlAttribute))
                {
                    var constrainingClassifierXmlAttributeValues = constrainingClassifierXmlAttribute.Split(SplitMultiReference, StringSplitOptions.RemoveEmptyEntries).ToList();
                    poco.MultiValueReferencePropertyIdentifiers.Add("constrainingClassifier", constrainingClassifierXmlAttributeValues);
                }

                var defaultXmlAttribute = xmlReader.GetAttribute("default");
                if (!string.IsNullOrEmpty(defaultXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("default", defaultXmlAttribute);
                }

                var parameteredElementXmlAttribute = xmlReader.GetAttribute("parameteredElement");
                if (!string.IsNullOrEmpty(parameteredElementXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("parameteredElement", parameteredElementXmlAttribute);
                }

                var signatureXmlAttribute = xmlReader.GetAttribute("signature");
                if (!string.IsNullOrEmpty(signatureXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("signature", signatureXmlAttribute);
                }


                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            case "allowSubstitutable":
                                var allowSubstitutableValue = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(allowSubstitutableValue))
                                {
                                    poco.AllowSubstitutable = bool.Parse(allowSubstitutableValue);
                                }
                                break;
                            case "constrainingClassifier":
                                this.TryCollectMultiValueReferencePropertyIdentifiers(xmlReader, poco, "constrainingClassifier");
                                break;
                            case "default":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "default");
                                break;
                            case "ownedComment":
                                var ownedCommentValue = (IComment)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Comment");
                                poco.OwnedComment.Add(ownedCommentValue);
                                break;
                            case "ownedDefault":
                                var ownedDefaultValue = (IParameterableElement)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory);
                                poco.OwnedDefault.Add(ownedDefaultValue);
                                break;
                            case "ownedParameteredElement":
                                var ownedParameteredElementValue = (IParameterableElement)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory);
                                poco.OwnedParameteredElement.Add(ownedParameteredElementValue);
                                break;
                            case "parameteredElement":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "parameteredElement");
                                break;
                            case "signature":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "signature");
                                break;
                            default:
                                throw new NotSupportedException($"ClassifierTemplateParameterReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
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
