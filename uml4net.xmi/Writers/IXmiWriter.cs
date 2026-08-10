// -------------------------------------------------------------------------------------------------
// <copyright file="IXmiWriter.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Writers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    using uml4net.Packages;
    using uml4net.xmi.Xmi;

    /// <summary>
    /// The purpose of the <see cref="IXmiWriter"/> is to provide a means to write (serialize)
    /// a UML 2.5.1 model to XMI
    /// </summary>
    public interface IXmiWriter : IDisposable
    {
        /// <summary>
        /// Writes the provided <see cref="IPackage"/> to a UML XMI 2.5.1 file.
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> that is to be written
        /// </param>
        /// <param name="fileUri">
        /// The URI of the XMI file that is to be written.
        /// </param>
        void Write(IPackage package, string fileUri);

        /// <summary>
        /// Writes the provided <see cref="IPackage"/> to a UML XMI 2.5.1 stream.
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> that is to be written
        /// </param>
        /// <param name="stream">
        /// The <see cref="Stream"/> to which the XMI content is written.
        /// </param>
        /// <param name="documentName">
        /// The name of the document that is being written.
        /// </param>
        void Write(IPackage package, Stream stream, string documentName);

        /// <summary>
        /// Asynchronously writes the provided <see cref="IPackage"/> to a UML XMI 2.5.1 file.
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> that is to be written
        /// </param>
        /// <param name="fileUri">
        /// The URI of the XMI file that is to be written.
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used to cancel the write operation
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        Task WriteAsync(IPackage package, string fileUri, CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously writes the provided <see cref="IPackage"/> to a UML XMI 2.5.1 stream.
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> that is to be written
        /// </param>
        /// <param name="stream">
        /// The <see cref="Stream"/> to which the XMI content is written.
        /// </param>
        /// <param name="documentName">
        /// The name of the document that is being written.
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used to cancel the write operation
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        Task WriteAsync(IPackage package, Stream stream, string documentName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Writes the provided <see cref="IPackage"/> and <see cref="XmiExtension"/>s to a UML XMI 2.5.1 file.
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> that is to be written
        /// </param>
        /// <param name="fileUri">
        /// The URI of the XMI file that is to be written.
        /// </param>
        /// <param name="documentExtensions">
        /// The <see cref="XmiExtension"/>s that are to be written as a sibling of the <paramref name="package"/>,
        /// typically the <c>Extensions</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        void Write(IPackage package, string fileUri, IEnumerable<XmiExtension> documentExtensions);

        /// <summary>
        /// Writes the provided <see cref="IPackage"/> and <see cref="XmiExtension"/>s to a UML XMI 2.5.1 stream.
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> that is to be written
        /// </param>
        /// <param name="stream">
        /// The <see cref="Stream"/> to which the XMI content is written.
        /// </param>
        /// <param name="documentName">
        /// The name of the document that is being written.
        /// </param>
        /// <param name="documentExtensions">
        /// The <see cref="XmiExtension"/>s that are to be written as a sibling of the <paramref name="package"/>,
        /// typically the <c>Extensions</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        void Write(IPackage package, Stream stream, string documentName, IEnumerable<XmiExtension> documentExtensions);

        /// <summary>
        /// Asynchronously writes the provided <see cref="IPackage"/> and <see cref="XmiExtension"/>s to a
        /// UML XMI 2.5.1 file.
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> that is to be written
        /// </param>
        /// <param name="fileUri">
        /// The URI of the XMI file that is to be written.
        /// </param>
        /// <param name="documentExtensions">
        /// The <see cref="XmiExtension"/>s that are to be written as a sibling of the <paramref name="package"/>,
        /// typically the <c>Extensions</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used to cancel the write operation
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        Task WriteAsync(IPackage package, string fileUri, IEnumerable<XmiExtension> documentExtensions, CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously writes the provided <see cref="IPackage"/> and <see cref="XmiExtension"/>s to a
        /// UML XMI 2.5.1 stream.
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> that is to be written
        /// </param>
        /// <param name="stream">
        /// The <see cref="Stream"/> to which the XMI content is written.
        /// </param>
        /// <param name="documentName">
        /// The name of the document that is being written.
        /// </param>
        /// <param name="documentExtensions">
        /// The <see cref="XmiExtension"/>s that are to be written as a sibling of the <paramref name="package"/>,
        /// typically the <c>Extensions</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used to cancel the write operation
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        Task WriteAsync(IPackage package, Stream stream, string documentName, IEnumerable<XmiExtension> documentExtensions, CancellationToken cancellationToken = default);

        /// <summary>
        /// Writes the provided <see cref="IPackage"/>, <see cref="Documentation"/> and <see cref="XmiExtension"/>s to
        /// a UML XMI 2.5.1 file.
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> that is to be written
        /// </param>
        /// <param name="fileUri">
        /// The URI of the XMI file that is to be written.
        /// </param>
        /// <param name="documentation">
        /// The <see cref="Documentation"/> that is to be written as a sibling of the <paramref name="package"/>,
        /// typically the <c>Documentation</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        /// <param name="documentExtensions">
        /// The <see cref="XmiExtension"/>s that are to be written as a sibling of the <paramref name="package"/>,
        /// typically the <c>Extensions</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        void Write(IPackage package, string fileUri, Documentation documentation, IEnumerable<XmiExtension> documentExtensions);

        /// <summary>
        /// Writes the provided <see cref="IPackage"/>, <see cref="Documentation"/> and <see cref="XmiExtension"/>s to
        /// a UML XMI 2.5.1 stream.
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> that is to be written
        /// </param>
        /// <param name="stream">
        /// The <see cref="Stream"/> to which the XMI content is written.
        /// </param>
        /// <param name="documentName">
        /// The name of the document that is being written.
        /// </param>
        /// <param name="documentation">
        /// The <see cref="Documentation"/> that is to be written as a sibling of the <paramref name="package"/>,
        /// typically the <c>Documentation</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        /// <param name="documentExtensions">
        /// The <see cref="XmiExtension"/>s that are to be written as a sibling of the <paramref name="package"/>,
        /// typically the <c>Extensions</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        void Write(IPackage package, Stream stream, string documentName, Documentation documentation, IEnumerable<XmiExtension> documentExtensions);

        /// <summary>
        /// Asynchronously writes the provided <see cref="IPackage"/>, <see cref="Documentation"/> and
        /// <see cref="XmiExtension"/>s to a UML XMI 2.5.1 file.
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> that is to be written
        /// </param>
        /// <param name="fileUri">
        /// The URI of the XMI file that is to be written.
        /// </param>
        /// <param name="documentation">
        /// The <see cref="Documentation"/> that is to be written as a sibling of the <paramref name="package"/>,
        /// typically the <c>Documentation</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        /// <param name="documentExtensions">
        /// The <see cref="XmiExtension"/>s that are to be written as a sibling of the <paramref name="package"/>,
        /// typically the <c>Extensions</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used to cancel the write operation
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        Task WriteAsync(IPackage package, string fileUri, Documentation documentation, IEnumerable<XmiExtension> documentExtensions, CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously writes the provided <see cref="IPackage"/>, <see cref="Documentation"/> and
        /// <see cref="XmiExtension"/>s to a UML XMI 2.5.1 stream.
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> that is to be written
        /// </param>
        /// <param name="stream">
        /// The <see cref="Stream"/> to which the XMI content is written.
        /// </param>
        /// <param name="documentName">
        /// The name of the document that is being written.
        /// </param>
        /// <param name="documentation">
        /// The <see cref="Documentation"/> that is to be written as a sibling of the <paramref name="package"/>,
        /// typically the <c>Documentation</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        /// <param name="documentExtensions">
        /// The <see cref="XmiExtension"/>s that are to be written as a sibling of the <paramref name="package"/>,
        /// typically the <c>Extensions</c> of the <c>XmiRoot</c> that was read. May be null.
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used to cancel the write operation
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        Task WriteAsync(IPackage package, Stream stream, string documentName, Documentation documentation, IEnumerable<XmiExtension> documentExtensions, CancellationToken cancellationToken = default);
    }
}
