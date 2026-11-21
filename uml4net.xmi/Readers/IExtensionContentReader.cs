// -------------------------------------------------------------------------------------------------
// <copyright file="IExtensionContentReader.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Readers
{
    using System.Xml;

    /// <summary>
    /// The <see cref="IExtensionContentReader{TContent}"/> provides XML content read for elements that are part of an extension
    /// </summary>
    /// <typeparam name="TContent">Any type</typeparam>
    public interface IExtensionContentReader<out TContent>
    {
        /// <summary>
        /// Reads the <typeparamref name="TContent"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">The name of the document that is currently read</param>
        /// <returns>
        /// an instance of <typeparamref name="TContent"/>
        /// </returns>
        public TContent Read(XmlReader xmlReader, string documentName);
    }
}
