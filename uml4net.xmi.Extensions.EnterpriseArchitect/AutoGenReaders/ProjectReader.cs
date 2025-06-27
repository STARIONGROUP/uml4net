// -------------------------------------------------------------------------------------------------
// <copyright file="ProjectReader.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2025 Starion Group S.A.
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

namespace uml4net.xmi.Extensions.EntrepriseArchitect.Structure.Readers
{
    using System;
    using System.CodeDom.Compiler;
    using System.Linq;
    using System.Xml;

    using Microsoft.Extensions.Logging;

    using uml4net;
    using uml4net.Extensions;
    using uml4net.xmi.Extensions.EntrepriseArchitect.Structure;
    using uml4net.xmi.Readers;
    using uml4net.xmi.Settings;

    /// <summary>
    /// The purpose of the <see cref="ProjectReader"/> is to read an instance of <see cref="IProject"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public partial class ProjectReader : XmiElementReader<IProject>, IXmiElementReader<IProject>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectReader"/> class.
        /// </summary>
        /// <param name="cache">
        /// The (injected) <see cref="IXmiElementCache"/>> in which each <see cref="IXmiElement"/>> is stored
        /// </param>
        /// <param name="xmiElementReaderFacade">
        /// The (injected) <see cref="IXmiElementReaderFacade"/> used to resolve any
        /// required <see cref="IXmiElementReader{T}"/>
        /// </param>
        /// <param name="xmiReaderSettings">
        /// The <see cref="IXmiReaderSettings"/> used to configure reading
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public ProjectReader(IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, IXmiReaderSettings xmiReaderSettings, ILoggerFactory loggerFactory)
        : base(cache, xmiElementReaderFacade, xmiReaderSettings, loggerFactory)
        {
        }

        /// <summary>
        /// Reads the <see cref="IProject"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="IProject"/>
        /// </param>
        /// <param name="namespaceUri">
        /// the namespace that the <see cref="IProject"/> belongs to
        /// </param>
        /// <returns>
        /// an instance of <see cref="IProject"/>
        /// </returns>
        public override IProject Read(XmlReader xmlReader, string documentName, string namespaceUri)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            if (string.IsNullOrEmpty(documentName))
            {
                throw new ArgumentException(nameof(documentName));
            }

            if (string.IsNullOrEmpty(namespaceUri))
            {
                throw new ArgumentException(nameof(namespaceUri));
            }

            var defaultLineInfo = xmlReader as IXmlLineInfo;

            IProject poco = new xmi.Extensions.EntrepriseArchitect.Structure.Project();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                var xmiType = "Project";


                if (!string.IsNullOrEmpty(xmlReader.NamespaceURI))
                {
                    namespaceUri = xmlReader.NamespaceURI;
                }

                poco.XmiType = xmiType;

                var idRef = xmlReader.GetAttribute("xmi:idref");
                poco.XmiId = $"Extension-{(string.IsNullOrEmpty(idRef) ? Guid.NewGuid() : idRef)}";

                if (!string.IsNullOrEmpty(idRef))
                {
                    poco.SingleValueReferencePropertyIdentifiers.Add("extendedElement", $"{documentName}#{idRef}");
                }

                poco.XmiGuid = Guid.NewGuid().ToString();

                poco.DocumentName = documentName;

                poco.XmiNamespaceUri = namespaceUri;

                if (!this.Cache.TryAdd(poco))
                {
                    this.Logger.LogCritical("Failed to add element type [{Poco}] with id [{Id}] as it was already in the Cache. The XMI document seems to have duplicate xmi:id values", "Project", poco.XmiId);
                }

                poco.Author = xmlReader.GetAttribute("author");

                var complexityXmlAttribute = xmlReader.GetAttribute("complexity");

                if (!string.IsNullOrEmpty(complexityXmlAttribute))
                {
                    poco.Complexity = int.Parse(complexityXmlAttribute);
                }

                poco.Created = xmlReader.GetAttribute("created");

                poco.Modified = xmlReader.GetAttribute("modified");

                poco.Phase = xmlReader.GetAttribute("phase");

                var statusXmlAttribute = xmlReader.GetAttribute("status");

                if (!string.IsNullOrEmpty(statusXmlAttribute))
                {
                    poco.Status = (Status)Enum.Parse(typeof(Status), statusXmlAttribute, true);
                }

                poco.Version = xmlReader.GetAttribute("version");


                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName.LowerCaseFirstLetter())
                        {
                            case "author":
                                poco.Author = xmlReader.ReadElementContentAsString();
                                break;
                            case "complexity":
                                var complexityValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(complexityValue))
                                {
                                    poco.Complexity = int.Parse(complexityValue);
                                }

                                break;
                            case "created":
                                poco.Created = xmlReader.ReadElementContentAsString();
                                break;
                            case "modified":
                                poco.Modified = xmlReader.ReadElementContentAsString();
                                break;
                            case "phase":
                                poco.Phase = xmlReader.ReadElementContentAsString();
                                break;
                            case "status":
                                var statusValue = xmlReader.ReadElementContentAsString();

                                if (!string.IsNullOrEmpty(statusValue))
                                {
                                    poco.Status = (Status)Enum.Parse(typeof(Status), statusValue, true);
                                }

                                break;
                            case "version":
                                poco.Version = xmlReader.ReadElementContentAsString();
                                break;
                            default:
                                var couldHandleReadElement = this.HandleManualXmlRead(poco, xmlReader, documentName, namespaceUri);

                                if (couldHandleReadElement)
                                {
                                    break;
                                }

                                if (this.XmiReaderSettings.UseStrictReading)
                                {
                                    throw new NotSupportedException($"ProjectReader: {xmlReader.LocalName} at line:position {defaultLineInfo.LineNumber}:{defaultLineInfo.LinePosition}");
                                }
                                else
                                {
                                    this.Logger.LogWarning("Not Supported: ProjectReader: {LocalName} at line:position {LineNumber}:{LinePosition}", xmlReader.LocalName, defaultLineInfo.LineNumber, defaultLineInfo.LinePosition);
                                }

                                break;
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
