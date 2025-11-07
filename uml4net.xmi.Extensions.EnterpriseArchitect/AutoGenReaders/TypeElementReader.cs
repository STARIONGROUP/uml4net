// -------------------------------------------------------------------------------------------------
// <copyright file="TypeElementReader.cs" company="Starion Group S.A.">
//
//    Copyright (C) 2019-2025 Starion Group S.A.
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
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
    using Microsoft.Extensions.Logging.Abstractions;

    using uml4net;
    using uml4net.Extensions;
    using uml4net.xmi.Extensions.EntrepriseArchitect.Structure;
    using uml4net.xmi.Readers;
    using uml4net.xmi.Settings;

    /// <summary>
    /// The purpose of the <see cref="TypeElementReader"/> is to read an instance of <see cref="ITypeElement"/>
    /// from the XMI document
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public partial class TypeElementReader : ExtensionContentReader<ITypeElement>
    {
        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<TypeElementReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeElementReader"/> class.
        /// </summary>
        /// <param name="extensionContentReaderFacade">The <see cref="IExtensionContentReaderFacade"/> that allow other <see cref="ExtensionContentReader{TContent}"/> read capabilities</param>
        /// <param name="xmiReaderSettings">
        /// The <see cref="IXmiReaderSettings"/> used to configure reading
        /// </param>
        /// <param name="nameSpaceResolver">
        /// The (injected) <see cref="INameSpaceResolver"/> used to resolve a namespace to one of the
        /// <see cref="KnowNamespacePrefixes"/>
        /// </param>
        /// <param name="cache">The <see cref="IXmiElementCache"/> that provides cached <see cref="IXmiElement"/> retriveal</param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public TypeElementReader(IExtensionContentReaderFacade extensionContentReaderFacade, IXmiReaderSettings xmiReaderSettings, INameSpaceResolver nameSpaceResolver, IXmiElementCache cache, ILoggerFactory loggerFactory)
        : base(extensionContentReaderFacade, xmiReaderSettings, nameSpaceResolver, cache, loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<TypeElementReader>.Instance : loggerFactory.CreateLogger<TypeElementReader>();
        }

        /// <summary>
        /// Reads the <see cref="ITypeElement"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">The name of the document that is currently read</param>
        /// <returns>
        /// an instance of <see cref="ITypeElement"/>
        /// </returns>
        public override ITypeElement Read(XmlReader xmlReader, string documentName)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            var xmlLineInfo = xmlReader as IXmlLineInfo;

            ITypeElement poco = new xmi.Extensions.EntrepriseArchitect.Structure.TypeElement();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.logger.LogTrace("reading TypeElement at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

                var concurrencyValue = xmlReader.GetAttribute("concurrency");
                poco.Concurrency = concurrencyValue;
                var constValue = xmlReader.GetAttribute("const");
                if (!string.IsNullOrWhiteSpace(constValue))
                {
                    poco.Const = bool.Parse(constValue);
                }

                var isAbstractValue = xmlReader.GetAttribute("isAbstract");
                if (!string.IsNullOrWhiteSpace(isAbstractValue))
                {
                    poco.IsAbstract = bool.Parse(isAbstractValue);
                }

                var isQueryValue = xmlReader.GetAttribute("isQuery");
                if (!string.IsNullOrWhiteSpace(isQueryValue))
                {
                    poco.IsQuery = bool.Parse(isQueryValue);
                }

                var pureValue = xmlReader.GetAttribute("pure");
                if (!string.IsNullOrWhiteSpace(pureValue))
                {
                    poco.Pure = int.Parse(pureValue);
                }

                var returnarrayValue = xmlReader.GetAttribute("returnarray");
                if (!string.IsNullOrWhiteSpace(returnarrayValue))
                {
                    poco.Returnarray = int.Parse(returnarrayValue);
                }

                var staticValue = xmlReader.GetAttribute("static");
                if (!string.IsNullOrWhiteSpace(staticValue))
                {
                    poco.Static = bool.Parse(staticValue);
                }

                var stereotypeValue = xmlReader.GetAttribute("stereotype");
                poco.Stereotype = stereotypeValue;
                var synchronisedValue = xmlReader.GetAttribute("synchronised");
                if (!string.IsNullOrWhiteSpace(synchronisedValue))
                {
                    poco.Synchronised = int.Parse(synchronisedValue);
                }

                var typeValue = xmlReader.GetAttribute("type");
                poco.Type = typeValue;


                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlReader.LocalName)
                        {
                            default:
                                if (this.XmiReaderSettings.UseStrictReading)
                                {
                                    throw new NotSupportedException($"TypeElementReader: {xmlReader.LocalName} at line:position {xmlLineInfo?.LineNumber}:{xmlLineInfo.LinePosition}");
                                }
                                else
                                {
                                    this.logger.LogWarning("Not Supported: TypeElementReader: {LocalName} at line:position {LineNumber}:{LinePosition}", xmlReader.LocalName, xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);
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
