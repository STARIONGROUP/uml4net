// -------------------------------------------------------------------------------------------------
// <copyright file="IXmiElementWriter.cs" company="Starion Group S.A.">
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
