// -------------------------------------------------------------------------------------------------
// <copyright file="CapturedElement.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Xmi
{
    using System.Collections.Generic;

    /// <summary>
    /// A document-level element, a child of <c>xmi:XMI</c>, that uml4net does not process and that is captured verbatim
    /// so that it can be written back, for example a UML Diagram Interchange element such as <c>umldi:UMLClassDiagram</c>
    /// </summary>
    public class CapturedElement
    {
        /// <summary>
        /// Gets or sets the namespace URI of the element
        /// </summary>
        public string NamespaceUri { get; set; }

        /// <summary>
        /// Gets or sets the namespace prefix of the element as it was read, for example <c>umldi</c>
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// Gets or sets the local name of the element, for example <c>UMLClassDiagram</c>
        /// </summary>
        public string LocalName { get; set; }

        /// <summary>
        /// Gets or sets the <c>xmi:id</c> of the element, null when it has none
        /// </summary>
        public string XmiId { get; set; }

        /// <summary>
        /// Gets or sets the zero-based position of the element among the top-level elements of the document that was
        /// read; the writer writes the captured elements in the order of their position
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// Gets or sets the namespace declarations that are in scope of the element, by prefix, including those that
        /// are declared on an ancestor such as <c>xmi:XMI</c>; the default namespace has the empty prefix
        /// </summary>
        /// <remarks>
        /// A prefix can be used in a value only, such as <c>dc</c> in <c>xmi:type="dc:Bounds"</c>; keeping all the
        /// declarations in scope keeps such a value resolvable when the element is written into another document
        /// </remarks>
        public Dictionary<string, string> NamespaceDeclarations { get; set; } = [];

        /// <summary>
        /// Gets or sets the element, with its content, as raw XML. Its start tag declares all the
        /// <see cref="NamespaceDeclarations"/>, so that the raw XML can be parsed on its own
        /// </summary>
        public string RawXml { get; set; }
    }
}
