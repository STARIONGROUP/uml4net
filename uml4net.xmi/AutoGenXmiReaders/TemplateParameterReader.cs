// -------------------------------------------------------------------------------------------------
// <copyright file="TemplateParameterReader.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="TemplateParameterReader"/> is to read an instance of <see cref="ITemplateParameter"/>
    /// from the XMI document
    /// </summary>
    public class TemplateParameterReader : XmiElementReader<ITemplateParameter>, IXmiElementReader<ITemplateParameter>
    {
        private readonly IXmiElementReaderFacade xmiElementReaderFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateParameterReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public TemplateParameterReader(IXmiReaderCache cache, ILoggerFactory loggerFactory)
            : base(cache, loggerFactory)
        {
            this.xmiElementReaderFacade = new XmiElementReaderFacade();
        }

        /// <summary>
        /// Reads the <see cref="ITemplateParameter"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="ITemplateParameter"/>
        /// </returns>
        public override ITemplateParameter Read(XmlReader xmlReader)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            var defaultLineInfo = xmlReader as IXmlLineInfo;

            ITemplateParameter poco = new TemplateParameter();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:TemplateParameter")
                {
                    throw new XmlException($"The XmiType should be 'uml:TemplateParameter' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:TemplateParameter";
                }

                poco.XmiType = xmiType;

                poco.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(poco.XmiId, poco);

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
                                throw new NotSupportedException($"TemplateParameterReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
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
