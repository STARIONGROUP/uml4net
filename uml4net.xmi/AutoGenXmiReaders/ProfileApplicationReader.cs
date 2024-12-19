// -------------------------------------------------------------------------------------------------
// <copyright file="ProfileApplicationReader.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Readers.Packages
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

    /// <summary>
    /// The purpose of the <see cref="ProfileApplicationReader"/> is to read an instance of <see cref="IProfileApplication"/>
    /// from the XMI document
    /// </summary>
    public class ProfileApplicationReader : XmiElementReader<IProfileApplication>, IXmiElementReader<IProfileApplication>
    {
        private readonly IXmiElementReaderFacade xmiElementReaderFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileApplicationReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The cache in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public ProfileApplicationReader(IXmiReaderCache cache, ILoggerFactory loggerFactory)
            : base(cache, loggerFactory)
        {
            this.xmiElementReaderFacade = new XmiElementReaderFacade();
        }

        /// <summary>
        /// Reads the <see cref="IProfileApplication"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="IProfileApplication"/>
        /// </returns>
        public override IProfileApplication Read(XmlReader xmlReader)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            IProfileApplication poco = new ProfileApplication();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = xmlReader.GetAttribute("xmi:type");

                if (!string.IsNullOrEmpty(xmiType) && xmiType != "uml:ProfileApplication")
                {
                    throw new XmlException($"The XmiType should be 'uml:ProfileApplication' while it is {xmiType}");
                }
                else
                {
                    xmiType = "uml:ProfileApplication";
                }

                poco.XmiType = xmiType;

                poco.XmiId = xmlReader.GetAttribute("xmi:id");

                this.Cache.Add(poco.XmiId, poco);

                var appliedProfileXmlAttribute = xmlReader.GetAttribute("appliedProfile");
                if (!string.IsNullOrEmpty(appliedProfileXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("appliedProfile", appliedProfileXmlAttribute);
                }

                var applyingPackageXmlAttribute = xmlReader.GetAttribute("applyingPackage");
                if (!string.IsNullOrEmpty(applyingPackageXmlAttribute))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("applyingPackage", applyingPackageXmlAttribute);
                }

                var isStrictXmlAttribute = xmlReader.GetAttribute("isStrict");
                if (!string.IsNullOrEmpty(isStrictXmlAttribute))
                {
                    poco.IsStrict = bool.Parse(isStrictXmlAttribute);
                }



                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            case "appliedProfile":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "appliedProfile");
                                break;
                            case "applyingPackage":
                                this.CollectSingleValueReferencePropertyIdentifier(xmlReader, poco, "applyingPackage");
                                break;
                            case "isStrict":
                                var isStrictXmlElement = xmlReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty(isStrictXmlElement))
                                {
                                    poco.IsStrict = bool.Parse(isStrictXmlElement);
                                }
                                break;
                            case "ownedComment":
                                var ownedComment = (IComment)this.xmiElementReaderFacade.QueryXmiElement(xmlReader, this.Cache, this.LoggerFactory, "uml:Comment");
                                poco.OwnedComment.Add(ownedComment);
                                break;
                            default:
                                var defaultLineInfo = xmlReader as IXmlLineInfo;
                                throw new NotSupportedException($"ProfileApplicationReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
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
