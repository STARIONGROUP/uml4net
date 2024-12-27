// -------------------------------------------------------------------------------------------------
// <copyright file="TemplateBindingReader.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="TemplateBindingReader"/> is to read an instance of <see cref="ITemplateBinding"/>
    /// from the XMI document
    /// </summary>
    public class TemplateBindingReader : XmiElementReader<ITemplateBinding>, IXmiElementReader<ITemplateBinding>
    {
        private readonly IXmiElementReaderFacade xmiElementReaderFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateBindingReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public TemplateBindingReader(IXmiReaderCache cache, ILoggerFactory loggerFactory)
            : base(cache, loggerFactory)
        {
            this.xmiElementReaderFacade = new XmiElementReaderFacade();
        }

        /// <summary>
        /// Reads the <see cref="ITemplateBinding"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="ITemplateBinding"/>
        /// </returns>
        public override ITemplateBinding Read(XmlReader xmlReader)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            var defaultLineInfo = xmlReader as IXmlLineInfo;

            ITemplateBinding poco = new TemplateBinding();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:TemplateBinding")
                {
                    throw new XmlException($"The XmiType should be 'uml:TemplateBinding' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:TemplateBinding";
                }

                poco.XmiType = xmiType;

                poco.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(poco.XmiId, poco);

                var boundElementXmlAttribute = xmlReader.GetAttribute("boundElement");
                if (!string.IsNullOrEmpty(boundElementXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("boundElement", boundElementXmlAttribute);
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
                            case "boundElement":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "boundElement");
                                break;
                            case "ownedComment":
                                var ownedCommentValue = (IComment)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Comment");
                                poco.OwnedComment.Add(ownedCommentValue);
                                break;
                            case "parameterSubstitution":
                                var parameterSubstitutionValue = (ITemplateParameterSubstitution)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:TemplateParameterSubstitution");
                                poco.ParameterSubstitution.Add(parameterSubstitutionValue);
                                break;
                            case "signature":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "signature");
                                break;
                            default:
                                throw new NotSupportedException($"TemplateBindingReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
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
