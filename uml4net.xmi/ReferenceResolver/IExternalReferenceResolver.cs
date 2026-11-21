// -------------------------------------------------------------------------------------------------
// <copyright file="IExternalReferenceResolver.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.ReferenceResolver
{
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Defines a contract for resolving external references associated with XMI elements.
    /// </summary>
    public interface IExternalReferenceResolver
    {
        /// <summary>
        /// Asynchronously attempts to resolve external references and yields their context and stream.
        /// </summary>
        /// <param name="documentName">
        /// the name of the XMI document for which the external references are being resolved.
        /// </param>
        /// <returns>
        /// A read-only List of tuples containing the context and stream of resolved references
        /// </returns>
        IReadOnlyList<(string Context, Stream Stream)> TryResolve(string documentName);

        /// <summary>
        /// Registers the location of a document so that the relative <c>href</c>s of that document are resolved
        /// against it (XMI 2.5.1 clause 7.10.2, IETF RFC 2396) instead of against the
        /// <see cref="Settings.IXmiReaderSettings.LocalReferenceBasePath"/>
        /// </summary>
        /// <param name="documentName">
        /// The name of the document as used in the <see cref="IXmiElement.DocumentName"/> of its elements
        /// </param>
        /// <param name="location">
        /// The absolute path or absolute URI from which the document was read
        /// </param>
        void RegisterDocumentLocation(string documentName, string location);
    }
}
