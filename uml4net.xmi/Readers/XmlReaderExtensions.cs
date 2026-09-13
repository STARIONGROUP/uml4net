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
        /// Reads the text content of the current element, like <see cref="XmlReader.ReadElementContentAsString()"/>,
        /// but leaves the reader positioned on the end tag of the element instead of on the node that follows it.
        /// </summary>
        /// <param name="xmlReader">
        /// The <see cref="XmlReader"/> positioned on an element
        /// </param>
        /// <returns>
        /// the text content of the element, an empty string for an empty element
        /// </returns>
        public static string ReadElementContentAsStringInPlace(this XmlReader xmlReader)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
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
