// -------------------------------------------------------------------------------------------------
// <copyright file="CanonicalXmlElement.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Xml;

    /// <summary>
    /// A top-level object serialized as Canonical XMI (XMI 2.5.1 Annex B) that is not written by a generated writer, such as
    /// a MOF tag or a stereotype application: its <c>xmi:id</c>, <c>xmi:uuid</c> and <c>xmi:type</c> attributes, then its
    /// properties as child elements, each one holding either a value or a link
    /// </summary>
    internal sealed class CanonicalXmlElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CanonicalXmlElement"/> class.
        /// </summary>
        /// <param name="prefix">The namespace prefix of the element</param>
        /// <param name="localName">The local name of the element</param>
        /// <param name="namespaceUri">The namespace URI of the element</param>
        /// <param name="xmiNamespaceUri">The namespace URI of XMI</param>
        public CanonicalXmlElement(string prefix, string localName, string namespaceUri, string xmiNamespaceUri)
        {
            this.Prefix = prefix;
            this.LocalName = localName;
            this.NamespaceUri = namespaceUri;
            this.XmiNamespaceUri = xmiNamespaceUri;
        }

        /// <summary>Gets the namespace prefix of the element</summary>
        public string Prefix { get; }

        /// <summary>Gets the local name of the element</summary>
        public string LocalName { get; }

        /// <summary>Gets the namespace URI of the element</summary>
        public string NamespaceUri { get; }

        /// <summary>Gets the namespace URI of XMI</summary>
        public string XmiNamespaceUri { get; }

        /// <summary>Gets or sets the <c>xmi:id</c></summary>
        public string XmiId { get; set; }

        /// <summary>Gets or sets the <c>xmi:uuid</c></summary>
        public string XmiUuid { get; set; }

        /// <summary>Gets the qualified name of the element, the value of its <c>xmi:type</c></summary>
        public string XmiType => $"{this.Prefix}:{this.LocalName}";

        /// <summary>Gets the child elements, in order: the name of the property, and its value or its link</summary>
        public List<(string Name, string Value, bool IsIdRef, bool IsHref)> Children { get; } = [];

        /// <summary>
        /// Adds a property value
        /// </summary>
        /// <param name="name">The name of the property</param>
        /// <param name="value">The XMI representation of the value</param>
        public void AddValue(string name, string value) => this.Children.Add((name, value, false, false));

        /// <summary>
        /// Adds a link to an element of the document
        /// </summary>
        /// <param name="name">The name of the property</param>
        /// <param name="xmiId">The <c>xmi:id</c> of the referenced element</param>
        public void AddIdRef(string name, string xmiId) => this.Children.Add((name, xmiId, true, false));

        /// <summary>
        /// Adds a link to an element of another document
        /// </summary>
        /// <param name="name">The name of the property</param>
        /// <param name="href">The href of the referenced element</param>
        public void AddHref(string name, string href) => this.Children.Add((name, href, false, true));

        /// <summary>
        /// Writes the element to the provided <see cref="XmlWriter"/>
        /// </summary>
        /// <param name="xmlWriter">The <see cref="XmlWriter"/></param>
        public void Write(XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement(this.Prefix, this.LocalName, this.NamespaceUri);
            xmlWriter.WriteAttributeString("xmi", "id", this.XmiNamespaceUri, this.XmiId);

            if (!string.IsNullOrEmpty(this.XmiUuid))
            {
                xmlWriter.WriteAttributeString("xmi", "uuid", this.XmiNamespaceUri, this.XmiUuid);
            }

            xmlWriter.WriteAttributeString("xmi", "type", this.XmiNamespaceUri, this.XmiType);

            foreach (var child in this.Children)
            {
                xmlWriter.WriteStartElement(child.Name);

                if (child.IsIdRef)
                {
                    xmlWriter.WriteAttributeString("xmi", "idref", this.XmiNamespaceUri, child.Value);
                    xmlWriter.WriteEndElement();
                }
                else if (child.IsHref)
                {
                    xmlWriter.WriteAttributeString("href", child.Value);
                    xmlWriter.WriteEndElement();
                }
                else
                {
                    xmlWriter.WriteString(child.Value ?? string.Empty);
                    xmlWriter.WriteFullEndElement();
                }
            }

            xmlWriter.WriteFullEndElement();
        }

        /// <summary>
        /// Asynchronously writes the element to the provided <see cref="XmlWriter"/>
        /// </summary>
        /// <param name="xmlWriter">The <see cref="XmlWriter"/></param>
        /// <returns>an awaitable <see cref="Task"/></returns>
        public async Task WriteAsync(XmlWriter xmlWriter)
        {
            await xmlWriter.WriteStartElementAsync(this.Prefix, this.LocalName, this.NamespaceUri);
            await xmlWriter.WriteAttributeStringAsync("xmi", "id", this.XmiNamespaceUri, this.XmiId);

            if (!string.IsNullOrEmpty(this.XmiUuid))
            {
                await xmlWriter.WriteAttributeStringAsync("xmi", "uuid", this.XmiNamespaceUri, this.XmiUuid);
            }

            await xmlWriter.WriteAttributeStringAsync("xmi", "type", this.XmiNamespaceUri, this.XmiType);

            foreach (var child in this.Children)
            {
                await xmlWriter.WriteStartElementAsync(null, child.Name, null);

                if (child.IsIdRef)
                {
                    await xmlWriter.WriteAttributeStringAsync("xmi", "idref", this.XmiNamespaceUri, child.Value);
                    await xmlWriter.WriteEndElementAsync();
                }
                else if (child.IsHref)
                {
                    await xmlWriter.WriteAttributeStringAsync(null, "href", null, child.Value);
                    await xmlWriter.WriteEndElementAsync();
                }
                else
                {
                    await xmlWriter.WriteStringAsync(child.Value ?? string.Empty);
                    await xmlWriter.WriteFullEndElementAsync();
                }
            }

            await xmlWriter.WriteFullEndElementAsync();
        }
    }
}
