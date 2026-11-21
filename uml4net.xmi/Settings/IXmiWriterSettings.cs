// -------------------------------------------------------------------------------------------------
// <copyright file="IXmiWriterSettings.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Settings
{
    /// <summary>
    /// The <see cref="IXmiWriterSettings"/> interface defines settings the <see cref="Writers.XmiWriter"/> requires in order to properly write
    /// </summary>
    public interface IXmiWriterSettings
    {
        /// <summary>
        /// Gets or sets the <see cref="ExternalReferenceResolutionKind"/> that specifies how references to elements
        /// that are not contained by the selected <see cref="uml4net.Packages.IPackage"/> are serialized.
        /// </summary>
        ExternalReferenceResolutionKind ExternalReferenceResolution { get; set; }

        /// <summary>
        /// Gets or sets the namespace URI used for the uml namespace declaration on the root element.
        /// </summary>
        string UmlNamespaceUri { get; set; }

        /// <summary>
        /// Gets or sets the namespace URI used for the xmi namespace declaration on the root element.
        /// </summary>
        string XmiNamespaceUri { get; set; }

        /// <summary>
        /// Gets or sets the namespace URI used for the mofext namespace declaration on the root element, which is
        /// declared when MOF tags (<c>mofext:Tag</c>) are written.
        /// </summary>
        string MofExtNamespaceUri { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the written XML is indented.
        /// </summary>
        bool Indent { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the document is written as Canonical XMI (XMI 2.5.1 Annex B): every
        /// property as an XML element in the canonical order, an <c>xmi:id</c> derived from the model and an
        /// <c>xmi:uuid</c> on every object, reference elements without <c>xmi:type</c>, and no documentation, extensions
        /// or captured content. When false, the default, the identifiers are written as read.
        /// </summary>
        bool UseCanonicalXmi { get; set; }
    }
}
