// -------------------------------------------------------------------------------------------------
// <copyright file="Tag.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

#pragma warning disable IDE0130
namespace uml4net.Mof.Extension
{
    using System.Collections.Generic;

    /// <summary>
    /// A Tag represents a single piece of information that can be associated with any number of model elements. A model
    /// element can be associated with many Tags, and the same Tag can be associated with many model elements
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// Gets or sets the unique identifier of the Element in the XMI document
        /// </summary>
        public string XmiId { get; set; }

        /// <summary>
        /// Gets or sets the persistent identity of the Tag, its <c>xmi:uuid</c>, if any
        /// </summary>
        public string XmiUuid { get; set; }

        /// <summary>
        /// Gets or sets the name of the xmi type
        /// </summary>
        public string XmiType { get; set; }

        /// <summary>
        /// The name used to distinguish Tags associated with a model element.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The value of the Tag. MOF places no meaning on these values.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The elements that tag is applied to.
        /// </summary>
        public List<string> Element = [];
    }
}
