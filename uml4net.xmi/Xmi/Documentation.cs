// -------------------------------------------------------------------------------------------------
// <copyright file="Documentation.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Xmi
{
    using System;
    using System.Collections.Generic;

    using uml4net;

    /// <summary>
    /// The Documentation class contains information about the XMI document or stream being transmitted,
    /// </summary>
    public class Documentation
    {
        /// <summary>
        /// Name or details for a document contact person or point of contact.
        /// </summary>
        public string Contact { get; set; }

        /// <summary>
        /// Human-readable name of the exporting tool or system.
        /// </summary>
        public string Exporter { get; set; }

        /// <summary>
        /// Version string of the exporting tool.
        /// </summary>
        public string ExporterVersion { get; set; }

        /// <summary>
        /// Identifier of the exporting tool, for example the build number that Enterprise Architect writes
        /// (<c>exporterID="1704"</c>).
        /// </summary>
        /// <remarks>
        /// <c>exporterID</c> is not part of the XMI 2.5.1 Documentation class (clause 7.5.5), which defines contact,
        /// exporter, exporterVersion, longDescription, shortDescription, notice, owner and timestamp. Enterprise
        /// Architect writes it in the Documentation of every export, and its <c>UML_EA.DTD</c> declares
        /// <c>XMI.exporterID</c>. uml4net reads it, from an attribute or a child element, and writes it back as an
        /// attribute when it is set, so that the Documentation of an Enterprise Architect model survives a read-write
        /// cycle. Leave it null or empty to write a Documentation with the XMI 2.5.1 attributes only.
        /// </remarks>
        public string ExporterID { get; set; }

        /// <summary>
        /// Zero or more long, free-text descriptions of the document.
        /// </summary>
        public List<string> LongDescription { get; set; } = [];

        /// <summary>
        /// Zero or more short descriptions or summaries of the document.
        /// </summary>
        public List<string> ShortDescription { get; set; } = [];

        /// <summary>
        /// Zero or more copyright or legal notices associated with the document.
        /// </summary>
        public List<string> Notice { get; set; } = [];

        /// <summary>
        /// Zero or more owners (individuals or organizations) of the document.
        /// </summary>
        public List<string> Owner { get; set; } = [];

        /// <summary>
        /// <see cref="DateTime"/> at which the document was created or exported 
        /// </summary>
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="XmiExtension"/>s that are contained by the <see cref="Documentation"/>
        /// (XMI 2.5.1 clause 7.5.5), preserved so that they can be written back
        /// </summary>
        public List<XmiExtension> Extensions { get; set; } = [];
    }
}
