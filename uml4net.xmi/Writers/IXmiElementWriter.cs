// -------------------------------------------------------------------------------------------------
// <copyright file="IXmiElementWriter.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Writers
{
    using System.Threading.Tasks;
    using System.Xml;

    /// <summary>
    /// The interface definition of an XMI element writer
    /// </summary>
    /// <typeparam name="TXmiElement">The type of the XMI element to be written.</typeparam>
    public interface IXmiElementWriter<in TXmiElement> where TXmiElement : IXmiElement
    {
        /// <summary>
        /// Writes the provided <typeparamref name="TXmiElement"/> to the <see cref="XmlWriter"/>.
        /// </summary>
        /// <param name="xmlWriter">
        /// The <see cref="XmlWriter"/> to write to
        /// </param>
        /// <param name="element">
        /// The <typeparamref name="TXmiElement"/> that is to be written
        /// </param>
        /// <param name="elementName">
        /// The name of the XML element that is written
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="IXmiWriteContext"/> that captures the state of the write operation
        /// </param>
        void Write(XmlWriter xmlWriter, TXmiElement element, string elementName, IXmiWriteContext writeContext);

        /// <summary>
        /// Asynchronously writes the provided <typeparamref name="TXmiElement"/> to the <see cref="XmlWriter"/>.
        /// </summary>
        /// <param name="xmlWriter">
        /// The <see cref="XmlWriter"/> to write to
        /// </param>
        /// <param name="element">
        /// The <typeparamref name="TXmiElement"/> that is to be written
        /// </param>
        /// <param name="elementName">
        /// The name of the XML element that is written
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="IXmiWriteContext"/> that captures the state of the write operation
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        Task WriteAsync(XmlWriter xmlWriter, TXmiElement element, string elementName, IXmiWriteContext writeContext);
    }
}
