// -------------------------------------------------------------------------------------------------
// <copyright file="CapturedElementWriter.cs" company="Starion Group S.A.">
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
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using uml4net.xmi.Xmi;

    /// <summary>
    /// The purpose of the <see cref="CapturedElementWriter"/> is to write a <see cref="CapturedElement"/>, a document-level
    /// element that uml4net does not process, back to an XMI document as a sibling of the model content
    /// </summary>
    /// <remarks>
    /// The element is written as it was read. A namespace declaration of its raw XML is written only when the namespace
    /// is not already in scope with the same prefix, typically because the root element declares it, see
    /// <see cref="QueryRootNamespaceDeclarations"/>.
    /// </remarks>
    public class CapturedElementWriter
    {
        /// <summary>
        /// The namespace URI of namespace declarations, <c>http://www.w3.org/2000/xmlns/</c>
        /// </summary>
        private const string XmlnsNamespaceUri = "http://www.w3.org/2000/xmlns/";

        /// <summary>
        /// The (injected) logger
        /// </summary>
        private readonly ILogger<CapturedElementWriter> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CapturedElementWriter"/> class.
        /// </summary>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public CapturedElementWriter(ILoggerFactory loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<CapturedElementWriter>.Instance : loggerFactory.CreateLogger<CapturedElementWriter>();
        }

        /// <summary>
        /// Queries the namespace declarations of the provided <see cref="CapturedElement"/>s that can be declared on the
        /// root element of the document, so that the captured elements do not each repeat them
        /// </summary>
        /// <param name="capturedElements">
        /// The <see cref="CapturedElement"/>s that are written
        /// </param>
        /// <param name="declaredPrefixes">
        /// The prefixes that the root element already declares, such as <c>xmi</c> and <c>uml</c>
        /// </param>
        /// <returns>
        /// The additional namespace declarations, by prefix, in the order in which they are found. A prefix that the root
        /// element already declares, or that a previous captured element declares for another namespace, is left out:
        /// the captured element that uses it keeps its own declaration. The default namespace is never declared on the root
        /// </returns>
        public static IReadOnlyList<KeyValuePair<string, string>> QueryRootNamespaceDeclarations(IEnumerable<CapturedElement> capturedElements, IEnumerable<string> declaredPrefixes)
        {
            if (capturedElements == null)
            {
                throw new ArgumentNullException(nameof(capturedElements));
            }

            if (declaredPrefixes == null)
            {
                throw new ArgumentNullException(nameof(declaredPrefixes));
            }

            var result = new List<KeyValuePair<string, string>>();
            var prefixes = new HashSet<string>(declaredPrefixes);

            foreach (var namespaceDeclaration in capturedElements.SelectMany(x => x.NamespaceDeclarations))
            {
                if (namespaceDeclaration.Key.Length == 0 || string.IsNullOrEmpty(namespaceDeclaration.Value) || !prefixes.Add(namespaceDeclaration.Key))
                {
                    continue;
                }

                result.Add(namespaceDeclaration);
            }

            return result;
        }

        /// <summary>
        /// Writes the <see cref="CapturedElement"/> to the provided <see cref="XmlWriter"/>
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="capturedElement">
        /// The <see cref="CapturedElement"/> that is to be written
        /// </param>
        public void Write(XmlWriter xmlWriter, CapturedElement capturedElement)
        {
            if (xmlWriter == null)
            {
                throw new ArgumentNullException(nameof(xmlWriter));
            }

            if (capturedElement == null)
            {
                throw new ArgumentNullException(nameof(capturedElement));
            }

            this.logger.LogTrace("writing the captured element {Prefix}:{LocalName} with id {XmiId}", capturedElement.Prefix, capturedElement.LocalName, capturedElement.XmiId);

            using var xmlReader = CreateReader(capturedElement);

            while (xmlReader.Read())
            {
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        var isEmptyElement = xmlReader.IsEmptyElement;

                        xmlWriter.WriteStartElement(xmlReader.Prefix, xmlReader.LocalName, xmlReader.NamespaceURI);

                        foreach (var attribute in QueryAttributesToWrite(xmlReader, xmlWriter))
                        {
                            xmlWriter.WriteAttributeString(attribute.Prefix, attribute.LocalName, attribute.NamespaceUri, attribute.Value);
                        }

                        if (isEmptyElement)
                        {
                            xmlWriter.WriteEndElement();
                        }

                        break;
                    case XmlNodeType.EndElement:
                        xmlWriter.WriteFullEndElement();
                        break;
                    case XmlNodeType.Text:
                        xmlWriter.WriteString(xmlReader.Value);
                        break;
                    case XmlNodeType.CDATA:
                        xmlWriter.WriteCData(xmlReader.Value);
                        break;
                    case XmlNodeType.SignificantWhitespace:
                        xmlWriter.WriteWhitespace(xmlReader.Value);
                        break;
                    case XmlNodeType.Comment:
                        xmlWriter.WriteComment(xmlReader.Value);
                        break;
                }
            }
        }

        /// <summary>
        /// Asynchronously writes the <see cref="CapturedElement"/> to the provided <see cref="XmlWriter"/>
        /// </summary>
        /// <param name="xmlWriter">
        /// an instance of <see cref="XmlWriter"/>
        /// </param>
        /// <param name="capturedElement">
        /// The <see cref="CapturedElement"/> that is to be written
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        public async Task WriteAsync(XmlWriter xmlWriter, CapturedElement capturedElement)
        {
            if (xmlWriter == null)
            {
                throw new ArgumentNullException(nameof(xmlWriter));
            }

            if (capturedElement == null)
            {
                throw new ArgumentNullException(nameof(capturedElement));
            }

            this.logger.LogTrace("writing the captured element {Prefix}:{LocalName} with id {XmiId}", capturedElement.Prefix, capturedElement.LocalName, capturedElement.XmiId);

            using var xmlReader = CreateReader(capturedElement);

            while (xmlReader.Read())
            {
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        var isEmptyElement = xmlReader.IsEmptyElement;

                        await xmlWriter.WriteStartElementAsync(xmlReader.Prefix, xmlReader.LocalName, xmlReader.NamespaceURI);

                        foreach (var attribute in QueryAttributesToWrite(xmlReader, xmlWriter))
                        {
                            await xmlWriter.WriteAttributeStringAsync(attribute.Prefix, attribute.LocalName, attribute.NamespaceUri, attribute.Value);
                        }

                        if (isEmptyElement)
                        {
                            await xmlWriter.WriteEndElementAsync();
                        }

                        break;
                    case XmlNodeType.EndElement:
                        await xmlWriter.WriteFullEndElementAsync();
                        break;
                    case XmlNodeType.Text:
                        await xmlWriter.WriteStringAsync(xmlReader.Value);
                        break;
                    case XmlNodeType.CDATA:
                        await xmlWriter.WriteCDataAsync(xmlReader.Value);
                        break;
                    case XmlNodeType.SignificantWhitespace:
                        await xmlWriter.WriteWhitespaceAsync(xmlReader.Value);
                        break;
                    case XmlNodeType.Comment:
                        await xmlWriter.WriteCommentAsync(xmlReader.Value);
                        break;
                }
            }
        }

        /// <summary>
        /// Creates the <see cref="XmlReader"/> that reads the raw XML of the provided <see cref="CapturedElement"/>;
        /// whitespace that is not significant is left to the indentation of the writer
        /// </summary>
        /// <param name="capturedElement">
        /// The <see cref="CapturedElement"/> that is read
        /// </param>
        /// <returns>
        /// The created <see cref="XmlReader"/>
        /// </returns>
        private static XmlReader CreateReader(CapturedElement capturedElement)
        {
            if (string.IsNullOrEmpty(capturedElement.RawXml))
            {
                throw new ArgumentException($"The captured element {capturedElement.Prefix}:{capturedElement.LocalName} has no raw XML", nameof(capturedElement));
            }

            return XmlReader.Create(new StringReader(capturedElement.RawXml), new XmlReaderSettings { IgnoreWhitespace = true });
        }

        /// <summary>
        /// Queries the attributes of the element on which the <paramref name="xmlReader"/> is positioned that are to be
        /// written: a namespace declaration is left out when the namespace is already in scope of the
        /// <paramref name="xmlWriter"/> with the same prefix
        /// </summary>
        /// <param name="xmlReader">
        /// The <see cref="XmlReader"/>, positioned on an element; it is positioned back on the element afterwards
        /// </param>
        /// <param name="xmlWriter">
        /// The <see cref="XmlWriter"/>, on which the start tag of the element is written
        /// </param>
        /// <returns>
        /// The attributes that are to be written, in document order
        /// </returns>
        private static List<(string Prefix, string LocalName, string NamespaceUri, string Value)> QueryAttributesToWrite(XmlReader xmlReader, XmlWriter xmlWriter)
        {
            var attributes = new List<(string Prefix, string LocalName, string NamespaceUri, string Value)>();

            if (!xmlReader.MoveToFirstAttribute())
            {
                return attributes;
            }

            do
            {
                if (xmlReader.NamespaceURI == XmlnsNamespaceUri)
                {
                    var declaredPrefix = xmlReader.Prefix == "xmlns" ? xmlReader.LocalName : string.Empty;

                    if (xmlWriter.LookupPrefix(xmlReader.Value) == declaredPrefix)
                    {
                        continue;
                    }
                }

                attributes.Add((xmlReader.Prefix, xmlReader.LocalName, xmlReader.NamespaceURI, xmlReader.Value));
            }
            while (xmlReader.MoveToNextAttribute());

            xmlReader.MoveToElement();

            return attributes;
        }
    }
}
