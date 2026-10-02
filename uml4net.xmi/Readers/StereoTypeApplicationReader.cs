// -------------------------------------------------------------------------------------------------
// <copyright file="StereoTypeApplicationReader.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2026 Starion Group S.A.
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

namespace uml4net.xmi.Readers
{
    using System;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;
    
    using uml4net.Profiling;
    
    /// <summary>
    /// The purpose of the <see cref="StereoTypeApplicationReader"/> is to read an instance
    /// of <see cref="StereoTypeApplication"/> from the XMI document
    /// </summary>
    public class StereoTypeApplicationReader
    {
        /// <summary>
        /// The prefix of the name of the property of a stereotype that references the extended element, for example
        /// <c>base_Class</c> (UML 2.5.1 clause 12.3.3)
        /// </summary>
        private const string BasePropertyPrefix = "base_";

        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<StereoTypeApplicationReader> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="StereoTypeApplicationReader"/> class.
        /// </summary>>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public StereoTypeApplicationReader(ILoggerFactory loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<StereoTypeApplicationReader>.Instance : loggerFactory.CreateLogger<StereoTypeApplicationReader>();
        }

        /// <summary>
        /// Reads the <see cref="StereoTypeApplication"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="stereoTypeApplication">
        /// The <see cref="StereoTypeApplication"/> that is being read.
        /// </param>
        /// <returns>
        /// an instance of <see cref="StereoTypeApplication"/>
        /// </returns>
        public bool TryRead(XmlReader xmlReader, out StereoTypeApplication stereoTypeApplication)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            var xmlLineInfo = xmlReader as IXmlLineInfo;

            stereoTypeApplication = new StereoTypeApplication();

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.logger.LogTrace("reading StereoTypeApplication at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

                var profileName = xmlReader.Prefix;
                var stereoTypeName = xmlReader.LocalName;
                var isStereoTypeApplication = false;

                for (var i = 0; i < xmlReader.AttributeCount; i++)
                {
                    xmlReader.MoveToAttribute(i);

                    if (xmlReader.LocalName == "id" && XmlReaderExtensions.IsXmiNamespace(xmlReader.NamespaceURI))
                    {
                        stereoTypeApplication.XmiId = xmlReader.Value;
                    }
                    else if (xmlReader.LocalName.StartsWith(BasePropertyPrefix, StringComparison.Ordinal))
                    {
                        stereoTypeApplication.MetaClass = xmlReader.LocalName.Substring(BasePropertyPrefix.Length);
                        stereoTypeApplication.ElementIdentifier = xmlReader.Value;

                        isStereoTypeApplication = true;
                    }
                    else
                    {
                        stereoTypeApplication.Attributes.Add(xmlReader.LocalName, xmlReader.Value);
                    }
                }

                xmlReader.MoveToElement();

                // XMI 2.5.1 clause 9.5.2: a reference may also be serialized as a child element that carries an
                // xmi:idref or an href, for example <base_Package xmi:idref="..."/>
                if (!isStereoTypeApplication && !xmlReader.IsEmptyElement)
                {
                    isStereoTypeApplication = TryReadBaseElement(xmlReader, stereoTypeApplication);
                }

                if (!isStereoTypeApplication)
                {
                    this.logger.LogTrace("The XML Element {ProfileName}:{StereoTypeName} at line:position {LineNumber}:{LinePosition} does not appear to be a StereoTypeApplication", profileName, stereoTypeName, xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

                    stereoTypeApplication = null;
                    return false;
                }

                stereoTypeApplication.ProfileName = profileName;
                stereoTypeApplication.StereoTypeName = stereoTypeName;
            }

            return true;
        }

        /// <summary>
        /// Reads the reference to the extended element from a child element of the stereotype application whose name
        /// starts with <c>base_</c>
        /// </summary>
        /// <param name="xmlReader">
        /// The <see cref="XmlReader"/>, positioned on the stereotype application element
        /// </param>
        /// <param name="stereoTypeApplication">
        /// The <see cref="StereoTypeApplication"/> that is updated with the meta class and the element identifier
        /// </param>
        /// <returns>
        /// true when a <c>base_</c> child element with an <c>xmi:idref</c> or an <c>href</c> was found
        /// </returns>
        private static bool TryReadBaseElement(XmlReader xmlReader, StereoTypeApplication stereoTypeApplication)
        {
            var depth = xmlReader.Depth;

            while (xmlReader.Read() && xmlReader.Depth > depth)
            {
                if (xmlReader.NodeType != XmlNodeType.Element || xmlReader.Depth != depth + 1 || !xmlReader.LocalName.StartsWith(BasePropertyPrefix, StringComparison.Ordinal))
                {
                    continue;
                }

                var metaClass = xmlReader.LocalName.Substring(BasePropertyPrefix.Length);
                string reference = null;

                for (var i = 0; i < xmlReader.AttributeCount; i++)
                {
                    xmlReader.MoveToAttribute(i);

                    if ((xmlReader.LocalName == "idref" && XmlReaderExtensions.IsXmiNamespace(xmlReader.NamespaceURI))
                        || (xmlReader.LocalName == "href" && string.IsNullOrEmpty(xmlReader.NamespaceURI)))
                    {
                        reference = xmlReader.Value;
                    }
                }

                xmlReader.MoveToElement();

                if (!string.IsNullOrEmpty(reference))
                {
                    stereoTypeApplication.MetaClass = metaClass;
                    stereoTypeApplication.ElementIdentifier = reference;
                    return true;
                }
            }

            return false;
        }
    }
}
