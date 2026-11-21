// -------------------------------------------------------------------------------------------------
// <copyright file="XmiExtension.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents an <c>xmi:Extension</c> element in an XMI document.
    /// <para>
    /// The XMI Extension mechanism enables tools to attach additional, tool-specific information
    /// to a model or model element, without altering the base metamodel. Extensions are preserved
    /// across import/export cycles and can be used to support round-trip engineering.
    /// </para>
    /// <para>
    /// This class corresponds to the <c>Extension</c> type defined in the XMI 2.5.1 specification,
    /// section 7.5.4, and is intended to encapsulate any valid XML content defined outside the XMI namespace.
    /// </para>
    /// </summary>
    public class XmiExtension : IXmiExtension
    {
        /// <summary>
        /// Gets or sets the unique identifier of the Element in the XMI document
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the xmi type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the GUID unique identifier of the Element in the XMI document
        /// </summary>
        public string Uuid { get; set; }

        /// <summary>
        /// Gets or sets the name of the tool that generated the extension
        /// </summary>
        public string Extender { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the tool that generated the extension
        /// </summary>
        public string ExtenderId { get; set; }

        /// <summary>
        /// Gets or sets the contents
        /// </summary>
        public List<object> Content { get; set; } = [];

        /// <summary>
        /// Gets or sets the content in its original XMI form
        /// </summary>
        public string ContentRawXmi { get; set; }

        /// <summary>
        /// Gets or sets the name of the document that contains the element
        /// </summary>
        public string DocumentName { get; set; }
    }
}
