// -------------------------------------------------------------------------------------------------
// <copyright file="XmlNameConverter.cs" company="Starion Group S.A.">
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
    using System.Linq;
    using System.Xml;

    /// <summary>
    /// Converts the name of a model element, such as a profile, a stereotype or a stereotype property, to the name of the
    /// XML element or attribute that serializes its instances
    /// </summary>
    /// <remarks>
    /// UML 2.5.1 clause 12.3.3 recommends the name of the profile, with the characters that are illegal in an XML name
    /// removed, as namespace prefix; tools apply the same rule to the names of stereotypes and their properties, for
    /// example an Eclipse UML2 export serializes the property <c>Segment Name</c> as the attribute <c>SegmentName</c>
    /// </remarks>
    public static class XmlNameConverter
    {
        /// <summary>
        /// Removes the characters that are illegal in an XML name from the provided name
        /// </summary>
        /// <param name="name">
        /// The name, may be null
        /// </param>
        /// <returns>
        /// The name without the characters that are illegal in an XML name; null or empty when the provided name is
        /// </returns>
        public static string ToXmlName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return name;
            }

            return new string(name.Where(XmlConvert.IsNCNameChar).ToArray());
        }
    }
}
