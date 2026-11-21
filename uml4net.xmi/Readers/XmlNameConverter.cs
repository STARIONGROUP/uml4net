// -------------------------------------------------------------------------------------------------
// <copyright file="XmlNameConverter.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
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
