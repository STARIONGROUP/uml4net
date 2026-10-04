// -------------------------------------------------------------------------------------------------
// <copyright file="CanonicalIdentifierCalculator.cs" company="Starion Group S.A.">
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
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Xml;

    /// <summary>
    /// Derives the <c>xmi:id</c>s of the objects of a Canonical XMI document from the model (XMI 2.5.1 Annex B.6)
    /// </summary>
    /// <remarks>
    /// <list type="number">
    /// <item>The identifier of an object is the value of its first property with <c>isID = true</c>; no UML metaclass has
    /// one, so it is the value of its <c>name</c> property.</item>
    /// <item>The base name of an object is its identifier; without identifier it is <c>_</c> for a top-level object and the
    /// name of the property that contains it otherwise.</item>
    /// <item>The characters that are not valid in an XML name, and hyphens, are replaced by <c>_</c>; a top-level base name
    /// that does not start with a letter or <c>_</c> is prefixed with <c>_</c>.</item>
    /// <item>When the object has no identifier, or its base name duplicates the base name of an earlier sibling, <c>_</c>
    /// and a sequence number are appended: from 1 for an object without name, from 2 otherwise, incremented until it is
    /// unique among the siblings.</item>
    /// <item>The <c>xmi:id</c> of a top-level object is its base name, that of a nested object is the <c>xmi:id</c> of its
    /// parent, <c>-</c> and its base name.</item>
    /// </list>
    /// </remarks>
    public static class CanonicalIdentifierCalculator
    {
        /// <summary>
        /// Calculates the <c>xmi:id</c>s of the recorded objects
        /// </summary>
        /// <param name="topLevelRecords">
        /// The records of the top-level objects, in the order of serialization, with their nested objects
        /// </param>
        /// <returns>
        /// The <c>xmi:id</c>s, by object
        /// </returns>
        public static Dictionary<object, string> Calculate(IReadOnlyList<CanonicalObjectRecord> topLevelRecords)
        {
            if (topLevelRecords == null)
            {
                throw new ArgumentNullException(nameof(topLevelRecords));
            }

            var result = new Dictionary<object, string>(ObjectReferenceEqualityComparer.Instance);

            CalculateSiblings(topLevelRecords, null, result);

            return result;
        }

        /// <summary>
        /// Calculates the <c>xmi:id</c>s of a set of siblings and, recursively, of their nested objects
        /// </summary>
        /// <param name="siblings">
        /// The records of the siblings, in the order of serialization
        /// </param>
        /// <param name="parentIdentifier">
        /// The <c>xmi:id</c> of their parent, null for the top-level objects
        /// </param>
        /// <param name="result">
        /// The <c>xmi:id</c>s, by object, to which the calculated ones are added
        /// </param>
        private static void CalculateSiblings(IEnumerable<CanonicalObjectRecord> siblings, string parentIdentifier, Dictionary<object, string> result)
        {
            var usedBaseNames = new HashSet<string>(StringComparer.Ordinal);

            foreach (var record in siblings)
            {
                var hasIdentifier = !string.IsNullOrEmpty(record.Name);

                var baseName = hasIdentifier
                    ? record.Name
                    : record.IsTopLevel ? "_" : QueryLocalName(record.ElementName);

                baseName = Sanitize(baseName, record.IsTopLevel);

                if (!hasIdentifier || usedBaseNames.Contains(baseName))
                {
                    if (!baseName.EndsWith("_", StringComparison.Ordinal))
                    {
                        baseName += "_";
                    }

                    var sequenceNumber = hasIdentifier ? 2 : 1;

                    while (usedBaseNames.Contains(baseName + sequenceNumber.ToString(CultureInfo.InvariantCulture)))
                    {
                        sequenceNumber++;
                    }

                    baseName += sequenceNumber.ToString(CultureInfo.InvariantCulture);
                }

                usedBaseNames.Add(baseName);

                var identifier = parentIdentifier == null ? baseName : $"{parentIdentifier}-{baseName}";

                if (record.Element != null)
                {
                    result[record.Element] = identifier;
                }

                CalculateSiblings(record.Children, identifier, result);
            }
        }

        /// <summary>
        /// Replaces the characters that are not valid in an XML name, and hyphens, by <c>_</c>, and prefixes a top-level base
        /// name that does not start with a letter or <c>_</c> with <c>_</c>
        /// </summary>
        /// <param name="baseName">
        /// The base name
        /// </param>
        /// <param name="isTopLevel">
        /// A value indicating whether the object is a top-level object
        /// </param>
        /// <returns>
        /// The sanitized base name
        /// </returns>
        private static string Sanitize(string baseName, bool isTopLevel)
        {
            var sb = new StringBuilder(baseName.Length + 1);

            foreach (var character in baseName)
            {
                sb.Append(character == '-' || !XmlConvert.IsNCNameChar(character) ? '_' : character);
            }

            if (isTopLevel && (sb.Length == 0 || !(char.IsLetter(sb[0]) || sb[0] == '_')))
            {
                sb.Insert(0, '_');
            }

            return sb.ToString();
        }

        /// <summary>
        /// Queries the local name of an XML element name, the part after the prefix
        /// </summary>
        /// <param name="elementName">
        /// The XML element name, with or without prefix
        /// </param>
        /// <returns>
        /// The local name
        /// </returns>
        private static string QueryLocalName(string elementName)
        {
            var separatorIndex = elementName?.IndexOf(':') ?? -1;

            return separatorIndex >= 0 ? elementName.Substring(separatorIndex + 1) : elementName ?? string.Empty;
        }
    }
}
