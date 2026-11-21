// -------------------------------------------------------------------------------------------------
// <copyright file="DefaultWriterSettings.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Settings
{
    /// <summary>
    /// Represents the default settings for the XMI writer.
    /// </summary>
    public class DefaultWriterSettings : IXmiWriterSettings
    {
        /// <summary>
        /// Gets or sets the <see cref="ExternalReferenceResolutionKind"/> that specifies how references to elements
        /// that are not contained by the selected <see cref="uml4net.Packages.IPackage"/> are serialized.
        /// </summary>
        public ExternalReferenceResolutionKind ExternalReferenceResolution { get; set; } = ExternalReferenceResolutionKind.Href;

        /// <summary>
        /// Gets or sets the namespace URI used for the uml namespace declaration on the root element.
        /// </summary>
        public string UmlNamespaceUri { get; set; } = "http://www.omg.org/spec/UML/20131001";

        /// <summary>
        /// Gets or sets the namespace URI used for the xmi namespace declaration on the root element.
        /// </summary>
        public string XmiNamespaceUri { get; set; } = "http://www.omg.org/spec/XMI/20131001";

        /// <summary>
        /// Gets or sets the namespace URI used for the mofext namespace declaration on the root element, which is
        /// declared when MOF tags (<c>mofext:Tag</c>) are written.
        /// </summary>
        public string MofExtNamespaceUri { get; set; } = "http://www.omg.org/spec/MOF/20131001";

        /// <summary>
        /// Gets or sets a value indicating whether the written XML is indented.
        /// </summary>
        public bool Indent { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether the document is written as Canonical XMI (XMI 2.5.1 Annex B): every
        /// property as an XML element in the canonical order, an <c>xmi:id</c> derived from the model and an
        /// <c>xmi:uuid</c> on every object, reference elements without <c>xmi:type</c>, and no documentation, extensions
        /// or captured content. When false, the default, the identifiers are written as read.
        /// </summary>
        public bool UseCanonicalXmi { get; set; }
    }
}
