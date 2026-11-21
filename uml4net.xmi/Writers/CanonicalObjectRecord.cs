// -------------------------------------------------------------------------------------------------
// <copyright file="CanonicalObjectRecord.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Writers
{
    using System.Collections.Generic;

    /// <summary>
    /// The record of an object serialized as Canonical XMI, from which its <c>xmi:id</c> is derived (XMI 2.5.1 Annex B.6)
    /// </summary>
    public class CanonicalObjectRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CanonicalObjectRecord"/> class.
        /// </summary>
        /// <param name="element">
        /// The object that is serialized
        /// </param>
        /// <param name="elementName">
        /// The name of the XML element that serializes the object
        /// </param>
        /// <param name="name">
        /// The name of the object, null or empty when it has none
        /// </param>
        /// <param name="isTopLevel">
        /// A value indicating whether the object is a direct child of <c>xmi:XMI</c>
        /// </param>
        public CanonicalObjectRecord(object element, string elementName, string name, bool isTopLevel)
        {
            this.Element = element;
            this.ElementName = elementName;
            this.Name = name;
            this.IsTopLevel = isTopLevel;
        }

        /// <summary>
        /// Gets the object that is serialized
        /// </summary>
        public object Element { get; }

        /// <summary>
        /// Gets the name of the XML element that serializes the object: the name of the property that contains it for a
        /// nested object
        /// </summary>
        public string ElementName { get; }

        /// <summary>
        /// Gets the name of the object, its identifier in the sense of Annex B.6, null or empty when it has none
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets a value indicating whether the object is a direct child of <c>xmi:XMI</c>
        /// </summary>
        public bool IsTopLevel { get; }

        /// <summary>
        /// Gets the records of the objects nested in the object, in the order of serialization
        /// </summary>
        public List<CanonicalObjectRecord> Children { get; } = [];
    }
}
