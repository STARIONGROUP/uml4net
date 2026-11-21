// -------------------------------------------------------------------------------------------------
// <copyright file="IExtenderReader.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Extender
{
    using System.Collections.Generic;

    /// <summary>
    /// The purpose of the <see cref="IExtenderReader"/> interface is to implement readers for tool-vendor specific
    /// <see cref="XmiExtension"/>s.
    /// </summary>
    public interface IExtenderReader
    {
        /// <summary>
        /// Reads the content of a xmi:Extension section 
        /// </summary>
        /// <param name="extensionXmi">The xmi:Extension section from where extension objects are stored</param>
        /// <param name="documentName">The name of the document that is currently read</param>
        /// <returns>A collection of extension <see cref="object"/></returns>
        List<object> ReadContent(string extensionXmi, string documentName);

        /// <summary>
        /// Performs post-processing of a UMl model using content of the extension
        /// </summary>
        /// <param name="readExtension">The <see cref="IXmiExtension"/> that has been read</param>
        void PostProcess(IXmiExtension readExtension);
    }
}
