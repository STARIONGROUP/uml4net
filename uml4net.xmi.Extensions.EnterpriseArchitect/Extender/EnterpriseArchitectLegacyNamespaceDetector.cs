// -------------------------------------------------------------------------------------------------
// <copyright file="EnterpriseArchitectLegacyNamespaceDetector.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Extensions.EnterpriseArchitect.Extender
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;

    /// <summary>
    /// Detects whether an XMI document was produced by an older Enterprise Architect version that used
    /// the pre-2.5.1 OMG namespace URIs (XMI 2.1 / UML 2.1) instead of the current
    /// <c>20131001</c> / <c>20161101</c> namespaces.
    /// </summary>
    /// <remarks>
    /// Detection is performed by peeking at only the root element and its <c>xmi:Documentation</c>
    /// sibling, using a forward-only <see cref="XmlReader"/>. The document is never modified: this is a
    /// read-only check that is cheap regardless of the overall size of the document, since it never reads
    /// past the first couple of elements.
    /// </remarks>
    public static class EnterpriseArchitectLegacyNamespaceDetector
    {
        /// <summary>
        /// The legacy (pre-2.5.1) XMI namespace used by older Enterprise Architect exports.
        /// </summary>
        public const string LegacyXmiNamespace = "http://schema.omg.org/spec/XMI/2.1";

        /// <summary>
        /// The legacy (pre-2.5.1) UML namespace used by older Enterprise Architect exports.
        /// </summary>
        public const string LegacyUmlNamespace = "http://schema.omg.org/spec/UML/2.1";

        /// <summary>
        /// Determines whether the XMI document located at <paramref name="fileUri"/> is an Enterprise
        /// Architect export that uses the legacy <see cref="LegacyXmiNamespace"/>.
        /// </summary>
        /// <param name="fileUri">
        /// The path of the XMI file to inspect.
        /// </param>
        /// <returns>
        /// true when the document's root element uses <see cref="LegacyXmiNamespace"/> and its first
        /// child is an <c>xmi:Documentation</c> element with <c>exporter="Enterprise Architect"</c>;
        /// false otherwise, including when the file does not exist or is not well-formed XML.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="fileUri"/> is null or empty.
        /// </exception>
        public static bool IsLegacyEnterpriseArchitectExport(string fileUri)
        {
            if (string.IsNullOrWhiteSpace(fileUri))
            {
                throw new ArgumentException(nameof(fileUri));
            }

            if (!File.Exists(fileUri))
            {
                return false;
            }

            try
            {
                // Older Enterprise Architect exports commonly declare an <?xml encoding="windows-1252"?>
                // prolog. .NET (Core) does not register that code page by default, so letting XmlReader
                // resolve the declared encoding itself throws. Everything this peek inspects (namespace
                // URIs, element/attribute names, the "Enterprise Architect" exporter value) is plain ASCII
                // regardless of the document's true encoding, so decoding as Latin-1 sidesteps the problem:
                // every byte maps to a character, nothing throws, and ASCII content decodes identically.
                using var stream = File.OpenRead(fileUri);
                using var textReader = new StreamReader(stream, Encoding.GetEncoding("ISO-8859-1"));
                using var xmlReader = XmlReader.Create(textReader);

                if (xmlReader.MoveToContent() != XmlNodeType.Element)
                {
                    return false;
                }

                if (xmlReader.NamespaceURI != LegacyXmiNamespace)
                {
                    return false;
                }

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType != XmlNodeType.Element)
                    {
                        continue;
                    }

                    return xmlReader.LocalName == "Documentation"
                           && xmlReader.GetAttribute("exporter") == "Enterprise Architect";
                }

                return false;
            }
            catch (XmlException)
            {
                return false;
            }
        }
    }
}
