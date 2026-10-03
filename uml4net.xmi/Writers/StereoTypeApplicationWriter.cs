// -------------------------------------------------------------------------------------------------
// <copyright file="StereoTypeApplicationWriter.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Writers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using uml4net.CommonStructure;
    using uml4net.Packages;
    using uml4net.Profiling;
    using uml4net.SimpleClassifiers;
    using uml4net.xmi.Readers;
    using uml4net.xmi.Settings;

    /// <summary>
    /// The purpose of the <see cref="StereoTypeApplicationWriter"/> is to write a <see cref="StereoTypeApplication"/> to an
    /// XMI document, as a sibling of the model content (UML 2.5.1 clause 12.3.3)
    /// </summary>
    /// <remarks>
    /// The application is written from its resolved state, so that an application created or changed in code is written:
    /// <list type="bullet">
    /// <item>the element is named after the stereotype, in the namespace of the profile: the <see cref="StereoTypeApplication.NamespaceUri"/>
    /// and <see cref="StereoTypeApplication.ProfileName"/> that were read or, for an application created in code, the URI and the
    /// name of the profile of the <see cref="StereoTypeApplication.Stereotype"/>;</item>
    /// <item>the <c>base_</c> reference to the extended element is an attribute when the element is written in the document, and a
    /// child element with an <c>href</c> otherwise;</item>
    /// <item>a typed tagged value is an attribute when it holds one value that is not a reference, or references to elements of
    /// the document only, and child elements otherwise; a tagged value that could not be typed is written as it was read.</item>
    /// </list>
    /// </remarks>
    public class StereoTypeApplicationWriter
    {
        /// <summary>
        /// The prefix of the name of the property of a stereotype that references the extended element
        /// </summary>
        private const string BasePropertyPrefix = "base_";

        /// <summary>
        /// The <see cref="IXmiWriterSettings"/> used to configure writing
        /// </summary>
        private readonly IXmiWriterSettings xmiWriterSettings;

        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<StereoTypeApplicationWriter> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="StereoTypeApplicationWriter"/> class.
        /// </summary>
        /// <param name="xmiWriterSettings">
        /// The <see cref="IXmiWriterSettings"/> used to configure writing
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public StereoTypeApplicationWriter(IXmiWriterSettings xmiWriterSettings, ILoggerFactory loggerFactory)
        {
            this.xmiWriterSettings = xmiWriterSettings ?? throw new ArgumentNullException(nameof(xmiWriterSettings));
            this.logger = loggerFactory == null ? NullLogger<StereoTypeApplicationWriter>.Instance : loggerFactory.CreateLogger<StereoTypeApplicationWriter>();
        }

        /// <summary>
        /// Queries the namespace prefix and URI with which the provided <see cref="StereoTypeApplication"/> is written
        /// </summary>
        /// <param name="stereoTypeApplication">
        /// The <see cref="StereoTypeApplication"/>
        /// </param>
        /// <returns>
        /// The prefix and the namespace URI
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// thrown when neither the application nor the profile of its stereotype provides a prefix and a namespace URI
        /// </exception>
        public static (string Prefix, string NamespaceUri) QueryNamespace(StereoTypeApplication stereoTypeApplication)
        {
            if (stereoTypeApplication == null)
            {
                throw new ArgumentNullException(nameof(stereoTypeApplication));
            }

            var profile = QueryProfile(stereoTypeApplication.Stereotype);

            var prefix = string.IsNullOrEmpty(stereoTypeApplication.ProfileName) ? XmlNameConverter.ToXmlName(profile?.Name) : stereoTypeApplication.ProfileName;
            var namespaceUri = string.IsNullOrEmpty(stereoTypeApplication.NamespaceUri) ? profile?.URI : stereoTypeApplication.NamespaceUri;

            if (string.IsNullOrEmpty(prefix) || string.IsNullOrEmpty(namespaceUri))
            {
                throw new InvalidOperationException($"The stereotype application {stereoTypeApplication.XmiId} cannot be written: neither the application nor the profile of its stereotype provides a namespace prefix and URI");
            }

            return (prefix, namespaceUri);
        }

        /// <summary>
        /// Writes the <see cref="StereoTypeApplication"/> to its XML representation
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="stereoTypeApplication">
        /// The <see cref="StereoTypeApplication"/> that is to be written
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="IXmiWriteContext"/> that tells which elements are written in the document
        /// </param>
        public void Write(XmlWriter xmlWriter, StereoTypeApplication stereoTypeApplication, IXmiWriteContext writeContext)
        {
            if (xmlWriter == null)
            {
                throw new ArgumentNullException(nameof(xmlWriter));
            }

            var serialization = this.CreateSerialization(stereoTypeApplication, writeContext);

            xmlWriter.WriteStartElement(serialization.Prefix, serialization.LocalName, serialization.NamespaceUri);

            foreach (var attribute in serialization.Attributes)
            {
                xmlWriter.WriteAttributeString(attribute.Prefix, attribute.LocalName, attribute.NamespaceUri, attribute.Value);
            }

            foreach (var childElement in serialization.ChildElements)
            {
                xmlWriter.WriteStartElement(childElement.Name);

                if (childElement.Attribute.HasValue)
                {
                    var attribute = childElement.Attribute.Value;
                    xmlWriter.WriteAttributeString(attribute.Prefix, attribute.LocalName, attribute.NamespaceUri, attribute.Value);
                }
                else
                {
                    xmlWriter.WriteString(childElement.Text);
                }

                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();
        }

        /// <summary>
        /// Asynchronously writes the <see cref="StereoTypeApplication"/> to its XML representation
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="stereoTypeApplication">
        /// The <see cref="StereoTypeApplication"/> that is to be written
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="IXmiWriteContext"/> that tells which elements are written in the document
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        public async Task WriteAsync(XmlWriter xmlWriter, StereoTypeApplication stereoTypeApplication, IXmiWriteContext writeContext)
        {
            if (xmlWriter == null)
            {
                throw new ArgumentNullException(nameof(xmlWriter));
            }

            var serialization = this.CreateSerialization(stereoTypeApplication, writeContext);

            await xmlWriter.WriteStartElementAsync(serialization.Prefix, serialization.LocalName, serialization.NamespaceUri);

            foreach (var attribute in serialization.Attributes)
            {
                await xmlWriter.WriteAttributeStringAsync(attribute.Prefix, attribute.LocalName, attribute.NamespaceUri, attribute.Value);
            }

            foreach (var childElement in serialization.ChildElements)
            {
                await xmlWriter.WriteStartElementAsync(null, childElement.Name, null);

                if (childElement.Attribute.HasValue)
                {
                    var attribute = childElement.Attribute.Value;
                    await xmlWriter.WriteAttributeStringAsync(attribute.Prefix, attribute.LocalName, attribute.NamespaceUri, attribute.Value);
                }
                else
                {
                    await xmlWriter.WriteStringAsync(childElement.Text);
                }

                await xmlWriter.WriteEndElementAsync();
            }

            await xmlWriter.WriteEndElementAsync();
        }

        /// <summary>
        /// Creates the <see cref="Serialization"/> of the provided <see cref="StereoTypeApplication"/>: its name, its
        /// attributes and its child elements
        /// </summary>
        /// <param name="stereoTypeApplication">
        /// The <see cref="StereoTypeApplication"/> that is to be written
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="IXmiWriteContext"/> that tells which elements are written in the document
        /// </param>
        /// <returns>
        /// The <see cref="Serialization"/>
        /// </returns>
        private Serialization CreateSerialization(StereoTypeApplication stereoTypeApplication, IXmiWriteContext writeContext)
        {
            if (stereoTypeApplication == null)
            {
                throw new ArgumentNullException(nameof(stereoTypeApplication));
            }

            if (writeContext == null)
            {
                throw new ArgumentNullException(nameof(writeContext));
            }

            var (prefix, namespaceUri) = QueryNamespace(stereoTypeApplication);

            var localName = stereoTypeApplication.Stereotype != null ? XmlNameConverter.ToXmlName(stereoTypeApplication.Stereotype.Name) : stereoTypeApplication.StereoTypeName;

            if (string.IsNullOrEmpty(localName))
            {
                throw new InvalidOperationException($"The stereotype application {stereoTypeApplication.XmiId} cannot be written: it has no stereotype name");
            }

            this.logger.LogTrace("writing the stereotype application {Prefix}:{StereoTypeName} with id {XmiId}", prefix, localName, stereoTypeApplication.XmiId);

            var serialization = new Serialization(prefix, localName, namespaceUri);

            if (!string.IsNullOrEmpty(stereoTypeApplication.XmiId))
            {
                serialization.Attributes.Add(this.CreateXmiAttribute("id", stereoTypeApplication.XmiId));
            }

            this.AddBaseReference(serialization, stereoTypeApplication, writeContext);

            foreach (var taggedValue in stereoTypeApplication.TaggedValues)
            {
                if (taggedValue.Values.Count > 0)
                {
                    this.AddTypedTaggedValue(serialization, taggedValue, writeContext);
                }
                else
                {
                    this.AddRawTaggedValue(serialization, taggedValue);
                }
            }

            return serialization;
        }

        /// <summary>
        /// Adds the <c>base_</c> reference to the extended element
        /// </summary>
        /// <param name="serialization">
        /// The <see cref="Serialization"/> to which the reference is added
        /// </param>
        /// <param name="stereoTypeApplication">
        /// The <see cref="StereoTypeApplication"/> that is written
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="IXmiWriteContext"/> that tells which elements are written in the document
        /// </param>
        private void AddBaseReference(Serialization serialization, StereoTypeApplication stereoTypeApplication, IXmiWriteContext writeContext)
        {
            var extendedElement = stereoTypeApplication.ExtendedElement;
            var metaClass = string.IsNullOrEmpty(stereoTypeApplication.MetaClass) ? extendedElement?.GetType().Name : stereoTypeApplication.MetaClass;

            if (string.IsNullOrEmpty(metaClass))
            {
                throw new InvalidOperationException($"The stereotype application {stereoTypeApplication.XmiId} cannot be written: it extends no element");
            }

            var name = BasePropertyPrefix + metaClass;

            if (extendedElement != null)
            {
                this.AddReferences(serialization, name, [extendedElement], writeContext);
                return;
            }

            this.AddRawReference(serialization, name, stereoTypeApplication.ElementIdentifier, asAttribute: true);
        }

        /// <summary>
        /// Adds a tagged value that holds typed <see cref="TaggedValue.Values"/>
        /// </summary>
        /// <param name="serialization">
        /// The <see cref="Serialization"/> to which the tagged value is added
        /// </param>
        /// <param name="taggedValue">
        /// The <see cref="TaggedValue"/> that is written
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="IXmiWriteContext"/> that tells which elements are written in the document
        /// </param>
        private void AddTypedTaggedValue(Serialization serialization, TaggedValue taggedValue, IXmiWriteContext writeContext)
        {
            var name = taggedValue.Property != null ? XmlNameConverter.ToXmlName(taggedValue.Property.Name) : taggedValue.Name;

            // a property typed by a data type, enumerations and primitive types included, holds values; any other
            // property holds references. Without a typed property, an element other than an enumeration literal is a reference
            var isReference = taggedValue.Property?.Type != null
                ? taggedValue.Property.Type is not IDataType
                : taggedValue.Values.All(x => x is IXmiElement && x is not IEnumerationLiteral);

            if (isReference)
            {
                this.AddReferences(serialization, name, taggedValue.Values.Cast<IXmiElement>().ToList(), writeContext);
                return;
            }

            var formattedValues = taggedValue.Values.Select(x => TaggedValueConverter.Format(x, taggedValue.Property)).ToList();

            if (formattedValues.Count == 1)
            {
                serialization.Attributes.Add((null, name, null, formattedValues[0]));
                return;
            }

            foreach (var formattedValue in formattedValues)
            {
                serialization.ChildElements.Add(new ChildElement(name, formattedValue));
            }
        }

        /// <summary>
        /// Adds a tagged value that could not be typed, as it was read
        /// </summary>
        /// <param name="serialization">
        /// The <see cref="Serialization"/> to which the tagged value is added
        /// </param>
        /// <param name="taggedValue">
        /// The <see cref="TaggedValue"/> that is written
        /// </param>
        private void AddRawTaggedValue(Serialization serialization, TaggedValue taggedValue)
        {
            if (taggedValue.IsReadAsAttribute)
            {
                serialization.Attributes.Add((null, taggedValue.Name, null, string.Join(" ", taggedValue.RawValues)));
                return;
            }

            foreach (var rawValue in taggedValue.RawValues)
            {
                if (taggedValue.IsReference)
                {
                    this.AddRawReference(serialization, taggedValue.Name, rawValue, asAttribute: false);
                }
                else
                {
                    serialization.ChildElements.Add(new ChildElement(taggedValue.Name, rawValue));
                }
            }
        }

        /// <summary>
        /// Adds references to elements: an attribute that lists the identifiers when all the elements are written in the
        /// document, and else a child element per element, with an <c>xmi:idref</c> or an <c>href</c>
        /// </summary>
        /// <param name="serialization">
        /// The <see cref="Serialization"/> to which the references are added
        /// </param>
        /// <param name="name">
        /// The name of the property
        /// </param>
        /// <param name="elements">
        /// The referenced elements
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="IXmiWriteContext"/> that tells which elements are written in the document
        /// </param>
        private void AddReferences(Serialization serialization, string name, IReadOnlyList<IXmiElement> elements, IXmiWriteContext writeContext)
        {
            if (elements.All(writeContext.IsLocal))
            {
                serialization.Attributes.Add((null, name, null, string.Join(" ", elements.Select(x => x.XmiId))));
                return;
            }

            foreach (var element in elements)
            {
                serialization.ChildElements.Add(writeContext.IsLocal(element)
                    ? new ChildElement(name, this.CreateXmiAttribute("idref", element.XmiId))
                    : new ChildElement(name, (null, "href", null, writeContext.QueryHref(element))));
            }
        }

        /// <summary>
        /// Adds a reference that could not be resolved, as it was read: an <c>href</c> when it names a document, and else an
        /// identifier of the document
        /// </summary>
        /// <param name="serialization">
        /// The <see cref="Serialization"/> to which the reference is added
        /// </param>
        /// <param name="name">
        /// The name of the property
        /// </param>
        /// <param name="reference">
        /// The reference as it was read
        /// </param>
        /// <param name="asAttribute">
        /// A value indicating whether an identifier of the document is written as an attribute rather than as a child element
        /// </param>
        private void AddRawReference(Serialization serialization, string name, string reference, bool asAttribute)
        {
            if (string.IsNullOrEmpty(reference))
            {
                return;
            }

            if (reference.IndexOf('#') > 0)
            {
                serialization.ChildElements.Add(new ChildElement(name, (null, "href", null, reference)));
            }
            else if (asAttribute)
            {
                serialization.Attributes.Add((null, name, null, reference));
            }
            else
            {
                serialization.ChildElements.Add(new ChildElement(name, this.CreateXmiAttribute("idref", reference)));
            }
        }

        /// <summary>
        /// Creates an attribute of the XMI namespace
        /// </summary>
        /// <param name="localName">
        /// The local name of the attribute, for example <c>id</c>
        /// </param>
        /// <param name="value">
        /// The value of the attribute
        /// </param>
        /// <returns>
        /// The attribute
        /// </returns>
        private (string Prefix, string LocalName, string NamespaceUri, string Value) CreateXmiAttribute(string localName, string value)
        {
            return ("xmi", localName, this.xmiWriterSettings.XmiNamespaceUri, value);
        }

        /// <summary>
        /// Queries the <see cref="IProfile"/> that owns the provided <see cref="IStereotype"/>, directly or through nested
        /// packages
        /// </summary>
        /// <param name="stereotype">
        /// The <see cref="IStereotype"/>, may be null
        /// </param>
        /// <returns>
        /// The <see cref="IProfile"/>, or null when there is none
        /// </returns>
        private static IProfile QueryProfile(IStereotype stereotype)
        {
            for (var owner = stereotype?.Owner; owner != null; owner = owner.Owner)
            {
                if (owner is IProfile profile)
                {
                    return profile;
                }
            }

            return null;
        }

        /// <summary>
        /// The serialization of a stereotype application: its name, attributes and child elements
        /// </summary>
        private sealed class Serialization
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Serialization"/> class.
            /// </summary>
            /// <param name="prefix">The namespace prefix</param>
            /// <param name="localName">The local name</param>
            /// <param name="namespaceUri">The namespace URI</param>
            public Serialization(string prefix, string localName, string namespaceUri)
            {
                this.Prefix = prefix;
                this.LocalName = localName;
                this.NamespaceUri = namespaceUri;
            }

            /// <summary>Gets the namespace prefix</summary>
            public string Prefix { get; }

            /// <summary>Gets the local name</summary>
            public string LocalName { get; }

            /// <summary>Gets the namespace URI</summary>
            public string NamespaceUri { get; }

            /// <summary>Gets the attributes, in order</summary>
            public List<(string Prefix, string LocalName, string NamespaceUri, string Value)> Attributes { get; } = [];

            /// <summary>Gets the child elements, in order</summary>
            public List<ChildElement> ChildElements { get; } = [];
        }

        /// <summary>
        /// A child element of a stereotype application, without namespace, that holds either one attribute, a reference,
        /// or text
        /// </summary>
        private sealed class ChildElement
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ChildElement"/> class that holds text
            /// </summary>
            /// <param name="name">The name of the element</param>
            /// <param name="text">The text</param>
            public ChildElement(string name, string text)
            {
                this.Name = name;
                this.Text = text;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="ChildElement"/> class that holds a reference attribute
            /// </summary>
            /// <param name="name">The name of the element</param>
            /// <param name="attribute">The attribute</param>
            public ChildElement(string name, (string Prefix, string LocalName, string NamespaceUri, string Value) attribute)
            {
                this.Name = name;
                this.Attribute = attribute;
            }

            /// <summary>Gets the name of the element</summary>
            public string Name { get; }

            /// <summary>Gets the text, when the element holds no attribute</summary>
            public string Text { get; }

            /// <summary>Gets the attribute, if any</summary>
            public (string Prefix, string LocalName, string NamespaceUri, string Value)? Attribute { get; }
        }
    }
}
