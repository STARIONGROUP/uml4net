// -------------------------------------------------------------------------------------------------
// <copyright file="IXmiReader.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Readers
{
    using System;
    using System.IO;
    
    /// <summary>
    /// The purpose of the <see cref="IXmiReader"/> is to provide a means to read (deserialize)
    /// an UML 2.5.1 model from XMI
    /// </summary>
    public interface IXmiReader : IDisposable
    {
        /// <summary>
        /// Reads the content of a UML XMI 2.5.1 file
        /// </summary>
        /// <param name="fileUri">
        /// The URI of the XMI file to be read.
        /// </param>
        /// <returns>
        /// An <see cref="XmiReaderResult"/> representing the deserialized packages from the XMI file.
        /// </returns>
        XmiReaderResult Read(string fileUri);

        /// <summary>
        /// Reads the content of a UML XMI 2.5.1 stream.
        /// </summary>
        /// <param name="stream">
        /// The <see cref="Stream"/> that contains the XMI content to be read.
        /// </param>
        /// <param name="documentName">
        /// The name of the document that is being read from.
        /// </param>
        /// <returns>
        /// An <see cref="XmiReaderResult"/> representing the deserialized packages from the XMI stream.
        /// </returns>
        XmiReaderResult Read(Stream stream, string documentName);
    }
}
