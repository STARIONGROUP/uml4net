// -------------------------------------------------------------------------------------------------
// <copyright file="XmlReaderExtensions.cs" company="Starion Group S.A.">
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

    /// <summary>
    /// Extension methods for <see cref="XmlReader"/> that consume an element without moving past it.
    /// </summary>
    /// <remarks>
    /// The readers iterate the children of an element with <c>while (xmlReader.Read())</c>.
    /// <see cref="XmlReader.ReadElementContentAsString()"/> and <see cref="XmlReader.Skip"/> position the reader
    /// on the node that follows the element, which the loop then skips with its next <c>Read()</c>. When there is
    /// no whitespace between elements (compact XMI) that following node is the next sibling element, which is
    /// therefore lost. These methods leave the reader on the end tag of the element (or on the element itself
    /// when it is empty), so that the loop advances to the next sibling.
    /// </remarks>
    public static class XmlReaderExtensions
    {
        /// <summary>
        /// The start of every OMG XMI namespace URI (http), whatever the XMI version
        /// </summary>
        private const string XmiNamespaceUriStartHttp = "http://www.omg.org/spec/XMI/";

        /// <summary>
        /// The start of every OMG XMI namespace URI (https), whatever the XMI version
        /// </summary>
        private const string XmiNamespaceUriStartHttps = "https://www.omg.org/spec/XMI/";

        /// <summary>
        /// Queries whether the provided namespace URI is an OMG XMI namespace, whatever the XMI version
        /// </summary>
        /// <param name="namespaceUri">
        /// The namespace URI that is checked
        /// </param>
        /// <returns>
        /// true when the namespace URI is an XMI namespace URI, false otherwise
        /// </returns>
        public static bool IsXmiNamespace(string namespaceUri)
        {
            return !string.IsNullOrEmpty(namespaceUri)
                   && (namespaceUri.StartsWith(XmiNamespaceUriStartHttp, StringComparison.Ordinal)
                       || namespaceUri.StartsWith(XmiNamespaceUriStartHttps, StringComparison.Ordinal));
        }

        /// <summary>
        /// Gets the value of the attribute with the provided local name in the XMI namespace, whatever prefix the
        /// document binds the XMI namespace to (XMI 2.5.1 clause 9.5.1 leaves the choice of prefixes to the document).
        /// </summary>
        /// <param name="xmlReader">
        /// The <see cref="XmlReader"/> positioned on an element
        /// </param>
        /// <param name="localName">
        /// The local name of the attribute, such as <c>type</c>, <c>id</c> or <c>idref</c>
        /// </param>
        /// <returns>
        /// the value of the attribute, or null when the element has no such attribute
        /// </returns>
        public static string GetXmiAttribute(this XmlReader xmlReader, string localName)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            if (string.IsNullOrEmpty(localName))
            {
                throw new ArgumentException("The local name of the attribute is to be provided", nameof(localName));
            }

            string result = null;

            if (xmlReader.MoveToFirstAttribute())
            {
                do
                {
                    if (xmlReader.LocalName == localName && IsXmiNamespace(xmlReader.NamespaceURI))
                    {
                        result = xmlReader.Value;
                        break;
                    }
                }
                while (xmlReader.MoveToNextAttribute());

                xmlReader.MoveToElement();
            }

            return result;
        }

        /// <summary>
        /// The namespace of the XLink attributes (W3C XLink 1.1)
        /// </summary>
        public const string XLinkNamespace = "http://www.w3.org/1999/xlink";

        /// <summary>
        /// Gets the link of a proxy element: the value of the XMI <c>href</c> attribute, or of the XLink simple
        /// link <c>xlink:href</c> attribute that XMI 2.5.1 clause 7.10.2 allows as an alternative. The XLink namespace
        /// is matched without regard to case since the XMI specification itself spells it <c>.../XLink</c>.
        /// </summary>
        /// <param name="xmlReader">
        /// The <see cref="XmlReader"/> positioned on an element
        /// </param>
        /// <returns>
        /// the value of the link attribute, or null when the element has neither
        /// </returns>
        public static string GetHrefAttribute(this XmlReader xmlReader)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            var href = xmlReader.GetAttribute("href");

            if (href != null)
            {
                return href;
            }

            string result = null;

            if (xmlReader.MoveToFirstAttribute())
            {
                do
                {
                    if (xmlReader.LocalName == "href" && string.Equals(xmlReader.NamespaceURI, XLinkNamespace, StringComparison.OrdinalIgnoreCase))
                    {
                        result = xmlReader.Value;
                        break;
                    }
                }
                while (xmlReader.MoveToNextAttribute());

                xmlReader.MoveToElement();
            }

            return result;
        }

        /// <summary>
        /// Resolves the prefix of a qualified name found in the document, such as the value of an <c>xmi:type</c>
        /// attribute, to the prefix that uml4net uses for that namespace (<c>uml</c>, <c>xmi</c>, ...), so that a
        /// document that binds the UML namespace to another prefix, or to the default namespace, is read as well
        /// (XMI 2.5.1 clause 9.5.2, rule 2g).
        /// </summary>
        /// <param name="xmlReader">
        /// The <see cref="XmlReader"/> whose in-scope namespace declarations are used to resolve the prefix
        /// </param>
        /// <param name="qualifiedName">
        /// The qualified name as found in the document, such as <c>UML:Class</c> or <c>Class</c>
        /// </param>
        /// <param name="nameSpaceResolver">
        /// The <see cref="INameSpaceResolver"/> that maps namespace URIs to the prefixes uml4net uses
        /// </param>
        /// <returns>
        /// the qualified name with the prefix uml4net uses, such as <c>uml:Class</c>; the
        /// <paramref name="qualifiedName"/> unchanged when its prefix is neither resolvable by the reader nor
        /// registered as a document prefix (<see cref="INameSpaceResolver.RegisterDocumentPrefix"/>), or is bound
        /// to a namespace that is not known
        /// </returns>
        public static string ResolveQualifiedName(this XmlReader xmlReader, string qualifiedName, INameSpaceResolver nameSpaceResolver)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            if (nameSpaceResolver == null)
            {
                throw new ArgumentNullException(nameof(nameSpaceResolver));
            }

            if (string.IsNullOrEmpty(qualifiedName))
            {
                return qualifiedName;
            }

            var separatorIndex = qualifiedName.IndexOf(':');
            var prefix = separatorIndex < 0 ? string.Empty : qualifiedName.Substring(0, separatorIndex);
            var localName = separatorIndex < 0 ? qualifiedName : qualifiedName.Substring(separatorIndex + 1);

            // a subtree reader only resolves the prefixes declared on its own root element or inside the subtree,
            // so a prefix declared on an ancestor (typically on xmi:XMI) is resolved through the prefixes that were
            // registered for the document
            var namespaceUri = xmlReader.LookupNamespace(prefix);

            var knownPrefix = string.IsNullOrEmpty(namespaceUri)
                ? nameSpaceResolver.ResolveDocumentPrefix(prefix)
                : nameSpaceResolver.ResolvePrefix(namespaceUri);

            return knownPrefix == KnowNamespacePrefixes.Other ? qualifiedName : $"{knownPrefix}:{localName}";
        }

        /// <summary>
        /// The namespace of the XML Schema instance attributes, such as <c>xsi:nil</c>
        /// </summary>
        public const string XmlSchemaInstanceNamespace = "http://www.w3.org/2001/XMLSchema-instance";

        /// <summary>
        /// Queries whether the current element carries <c>xsi:nil="true"</c>, which serializes a null value
        /// (XMI 2.5.1 clause 9.5.2, rule 2b)
        /// </summary>
        /// <param name="xmlReader">
        /// The <see cref="XmlReader"/> positioned on an element
        /// </param>
        /// <returns>
        /// true when the element is nil, false otherwise
        /// </returns>
        public static bool IsNil(this XmlReader xmlReader)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            var nil = xmlReader.GetAttribute("nil", XmlSchemaInstanceNamespace);

            // the XML Schema lexical forms of a true boolean
            return nil != null && (nil.Trim() == "true" || nil.Trim() == "1");
        }

        /// <summary>
        /// Reads the text content of the current element, like <see cref="XmlReader.ReadElementContentAsString()"/>,
        /// but leaves the reader positioned on the end tag of the element instead of on the node that follows it.
        /// </summary>
        /// <param name="xmlReader">
        /// The <see cref="XmlReader"/> positioned on an element
        /// </param>
        /// <returns>
        /// the text content of the element, an empty string for an empty element and null for an element
        /// that carries <c>xsi:nil="true"</c>
        /// </returns>
        public static string ReadElementContentAsStringInPlace(this XmlReader xmlReader)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            if (xmlReader.IsNil())
            {
                xmlReader.SkipInPlace();
                return null;
            }

            using var subtreeReader = xmlReader.ReadSubtree();

            subtreeReader.MoveToContent();

            return subtreeReader.ReadElementContentAsString();
        }

        /// <summary>
        /// Skips the current element and its children, like <see cref="XmlReader.Skip"/>, but leaves the reader
        /// positioned on the end tag of the element instead of on the node that follows it.
        /// </summary>
        /// <param name="xmlReader">
        /// The <see cref="XmlReader"/> positioned on an element
        /// </param>
        public static void SkipInPlace(this XmlReader xmlReader)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            // closing the subtree reader consumes the subtree and positions the reader on the end tag
            using (xmlReader.ReadSubtree())
            {
            }
        }
    }
}
