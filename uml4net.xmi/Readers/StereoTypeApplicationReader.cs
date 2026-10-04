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
    using System.Xml.Linq;

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
        /// The namespace of the attributes that declare a namespace (<c>xmlns</c> and <c>xmlns:prefix</c>)
        /// </summary>
        private const string XmlnsNamespaceUri = "http://www.w3.org/2000/xmlns/";

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
                var namespaceUri = xmlReader.NamespaceURI;
                var isStereoTypeApplication = false;

                for (var i = 0; i < xmlReader.AttributeCount; i++)
                {
                    xmlReader.MoveToAttribute(i);

                    if (xmlReader.NamespaceURI == XmlnsNamespaceUri)
                    {
                        // a namespace declaration (xmlns or xmlns:prefix) is not a tagged value; the subtree reader
                        // exposes the declarations that are in scope as attributes of the stereotype application
                        continue;
                    }

                    if (xmlReader.LocalName == "id" && XmlReaderExtensions.IsXmiNamespace(xmlReader.NamespaceURI))
                    {
                        stereoTypeApplication.XmiId = xmlReader.Value;
                    }
                    else if (xmlReader.LocalName == "uuid" && XmlReaderExtensions.IsXmiNamespace(xmlReader.NamespaceURI))
                    {
                        stereoTypeApplication.XmiUuid = xmlReader.Value;
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

                        // a property of the stereotype is serialized as an attribute without namespace; an attribute of
                        // another namespace, such as xmi:type or xmi:uuid, is not a tagged value
                        if (string.IsNullOrEmpty(xmlReader.NamespaceURI))
                        {
                            stereoTypeApplication.TaggedValues.Add(new TaggedValue { Name = xmlReader.LocalName, RawValues = [xmlReader.Value], IsReadAsAttribute = true });
                        }
                    }
                }

                xmlReader.MoveToElement();

                // XMI 2.5.1 clause 9.5.2: the base_ reference and the tagged values may also be serialized as child
                // elements, a reference with an xmi:idref or an href, for example <base_Package xmi:idref="..."/>
                if (!xmlReader.IsEmptyElement)
                {
                    isStereoTypeApplication |= this.ReadChildElements(xmlReader, stereoTypeApplication, isStereoTypeApplication);
                }

                if (!isStereoTypeApplication)
                {
                    this.logger.LogTrace("The XML Element {ProfileName}:{StereoTypeName} at line:position {LineNumber}:{LinePosition} does not appear to be a StereoTypeApplication", profileName, stereoTypeName, xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

                    stereoTypeApplication = null;
                    return false;
                }

                stereoTypeApplication.ProfileName = profileName;
                stereoTypeApplication.StereoTypeName = stereoTypeName;
                stereoTypeApplication.NamespaceUri = namespaceUri;
            }

            return true;
        }

        /// <summary>
        /// Reads the child elements of the stereotype application: the <c>base_</c> reference to the extended element,
        /// when it is not serialized as an attribute, and the tagged values
        /// </summary>
        /// <param name="xmlReader">
        /// The <see cref="XmlReader"/>, positioned on the stereotype application element
        /// </param>
        /// <param name="stereoTypeApplication">
        /// The <see cref="StereoTypeApplication"/> that is updated
        /// </param>
        /// <param name="isBaseReferenceRead">
        /// A value indicating whether the <c>base_</c> reference was read from an attribute already
        /// </param>
        /// <returns>
        /// true when a <c>base_</c> child element with an <c>xmi:idref</c> or an <c>href</c> was found
        /// </returns>
        private bool ReadChildElements(XmlReader xmlReader, StereoTypeApplication stereoTypeApplication, bool isBaseReferenceRead)
        {
            var depth = xmlReader.Depth;
            var isBaseElementRead = false;

            xmlReader.Read();

            while (!xmlReader.EOF && xmlReader.Depth > depth)
            {
                if (xmlReader.NodeType != XmlNodeType.Element || xmlReader.Depth != depth + 1)
                {
                    xmlReader.Read();
                    continue;
                }

                var name = xmlReader.LocalName;
                var reference = QueryReference(xmlReader);

                if (name.StartsWith(BasePropertyPrefix, StringComparison.Ordinal))
                {
                    if (!isBaseReferenceRead && !isBaseElementRead && !string.IsNullOrEmpty(reference))
                    {
                        stereoTypeApplication.MetaClass = name.Substring(BasePropertyPrefix.Length);
                        stereoTypeApplication.ElementIdentifier = reference;
                        isBaseElementRead = true;
                    }

                    xmlReader.Skip();
                    continue;
                }

                var xmlLineInfo = xmlReader as IXmlLineInfo;
                var element = (XElement)XNode.ReadFrom(xmlReader);

                if (string.IsNullOrEmpty(reference) && element.HasElements)
                {
                    this.logger.LogWarning("The tagged value {Name} at line:position {LineNumber}:{LinePosition} is an instance of a structured type, which is not supported, it is not read", name, xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);
                    continue;
                }

                var taggedValue = stereoTypeApplication.TaggedValues.Find(x => x.Name == name && !x.IsReadAsAttribute);

                if (taggedValue == null)
                {
                    taggedValue = new TaggedValue { Name = name };
                    stereoTypeApplication.TaggedValues.Add(taggedValue);
                }

                if (string.IsNullOrEmpty(reference))
                {
                    taggedValue.RawValues.Add(element.Value);
                }
                else
                {
                    taggedValue.RawValues.Add(reference);
                    taggedValue.IsReference = true;
                }
            }

            return isBaseElementRead;
        }

        /// <summary>
        /// Queries the reference that the element on which the <paramref name="xmlReader"/> is positioned carries, its
        /// <c>xmi:idref</c> or its <c>href</c>
        /// </summary>
        /// <param name="xmlReader">
        /// The <see cref="XmlReader"/>, positioned on an element; it is positioned back on the element afterwards
        /// </param>
        /// <returns>
        /// The reference, or null when the element carries none
        /// </returns>
        private static string QueryReference(XmlReader xmlReader)
        {
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

            return reference;
        }
    }
}
