// -------------------------------------------------------------------------------------------------
// <copyright file="IXmiExtension.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// ------------------------------------------------------------------------------------------------

namespace uml4net
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the contract for objects representing an <c>xmi:Extension</c> element in an XMI document.
    /// <para>
    /// Extensions allow XMI producers to embed tool-specific metadata or out-of-band model content
    /// in a way that preserves compliance with the core XMI schema.
    /// </para>
    /// <para>
    /// This interface reflects the structure defined in the XMI 2.5.1 specification (section 7.5.4),
    /// including both structured content and raw XMI.
    /// </para>
    /// </summary>
    public interface IXmiExtension
    {
        /// <summary>
        /// Gets or sets the unique identifier of the extension element in the XMI document (<c>xmi:id</c>).
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// Gets or sets the fully qualified XMI type of the extension element (<c>xmi:type</c>).
        /// </summary>
        string Type { get; set; }

        /// <summary>
        /// Gets or sets the UUID of the extension element, if provided (<c>xmi:uuid</c>).
        /// </summary>
        string Uuid { get; set; }

        /// <summary>
        /// Gets or sets the name of the tool that generated the extension (<c>extender</c> attribute).
        /// </summary>
        string Extender { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the tool that generated the extension (<c>extenderID</c> attribute).
        /// </summary>
        string ExtenderId { get; set; }

        /// <summary>
        /// Gets or sets the parsed content of the extension element.
        /// This may contain arbitrary tool-specific structures.
        /// </summary>
        List<object> Content { get; set; }

        /// <summary>
        /// Gets or sets the raw XML/XMI string content of the extension.
        /// </summary>
        string ContentRawXmi { get; set; }

        /// <summary>
        /// Gets or sets the name of the document that contains the element
        /// </summary>
        public string DocumentName { get; set; }
    }
}
