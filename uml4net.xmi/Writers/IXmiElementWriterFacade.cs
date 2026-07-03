// -------------------------------------------------------------------------------------------------
// <copyright file="IXmiElementWriterFacade.cs" company="Starion Group S.A.">
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
    using System.Threading.Tasks;
    using System.Xml;

    /// <summary>
    /// The purpose of the <see cref="IXmiElementWriterFacade"/> is to write an <see cref="IXmiElement"/> to an
    /// <see cref="XmlWriter"/> using the appropriate <see cref="IXmiElementWriter{TXmiElement}"/> based on the
    /// concrete type of the <see cref="IXmiElement"/>
    /// </summary>
    public interface IXmiElementWriterFacade
    {
        /// <summary>
        /// Writes the provided <see cref="IXmiElement"/> to the <see cref="XmlWriter"/> using the appropriate
        /// <see cref="IXmiElementWriter{TXmiElement}"/> based on the concrete type of the <see cref="IXmiElement"/>.
        /// </summary>
        /// <param name="xmlWriter">
        /// The <see cref="XmlWriter"/> to write to
        /// </param>
        /// <param name="element">
        /// The <see cref="IXmiElement"/> that is to be written
        /// </param>
        /// <param name="elementName">
        /// The name of the XML element that is written
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="IXmiWriteContext"/> that captures the state of the write operation
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// thrown when the concrete type of the <see cref="IXmiElement"/> is not supported and no
        /// <see cref="IXmiElementWriter{TXmiElement}"/> was found
        /// </exception>
        void Write(XmlWriter xmlWriter, IXmiElement element, string elementName, IXmiWriteContext writeContext);

        /// <summary>
        /// Writes the provided <see cref="IXmiElement"/> to the <see cref="XmlWriter"/> as a contained element. When
        /// the <see cref="IXmiElement"/> is not part of the document that is being written, an href reference element
        /// is written instead.
        /// </summary>
        /// <param name="xmlWriter">
        /// The <see cref="XmlWriter"/> to write to
        /// </param>
        /// <param name="element">
        /// The <see cref="IXmiElement"/> that is to be written
        /// </param>
        /// <param name="elementName">
        /// The name of the XML element that is written
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="IXmiWriteContext"/> that captures the state of the write operation
        /// </param>
        void WriteContainedElement(XmlWriter xmlWriter, IXmiElement element, string elementName, IXmiWriteContext writeContext);

        /// <summary>
        /// Writes the provided <see cref="IXmiElement"/> to the <see cref="XmlWriter"/> as a reference element. When the
        /// <see cref="IXmiElement"/> is part of the document that is being written an xmi:idref element is written,
        /// otherwise an href reference element is written.
        /// </summary>
        /// <param name="xmlWriter">
        /// The <see cref="XmlWriter"/> to write to
        /// </param>
        /// <param name="element">
        /// The <see cref="IXmiElement"/> that is referenced
        /// </param>
        /// <param name="elementName">
        /// The name of the XML element that is written
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="IXmiWriteContext"/> that captures the state of the write operation
        /// </param>
        void WriteReferenceElement(XmlWriter xmlWriter, IXmiElement element, string elementName, IXmiWriteContext writeContext);

        /// <summary>
        /// Asynchronously writes the provided <see cref="IXmiElement"/> to the <see cref="XmlWriter"/> using the appropriate
        /// <see cref="IXmiElementWriter{TXmiElement}"/> based on the concrete type of the <see cref="IXmiElement"/>.
        /// </summary>
        /// <param name="xmlWriter">
        /// The <see cref="XmlWriter"/> to write to
        /// </param>
        /// <param name="element">
        /// The <see cref="IXmiElement"/> that is to be written
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
        /// <exception cref="InvalidOperationException">
        /// thrown when the concrete type of the <see cref="IXmiElement"/> is not supported and no
        /// <see cref="IXmiElementWriter{TXmiElement}"/> was found
        /// </exception>
        Task WriteAsync(XmlWriter xmlWriter, IXmiElement element, string elementName, IXmiWriteContext writeContext);

        /// <summary>
        /// Asynchronously writes the provided <see cref="IXmiElement"/> to the <see cref="XmlWriter"/> as a contained element. When
        /// the <see cref="IXmiElement"/> is not part of the document that is being written, an href reference element
        /// is written instead.
        /// </summary>
        /// <param name="xmlWriter">
        /// The <see cref="XmlWriter"/> to write to
        /// </param>
        /// <param name="element">
        /// The <see cref="IXmiElement"/> that is to be written
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
        Task WriteContainedElementAsync(XmlWriter xmlWriter, IXmiElement element, string elementName, IXmiWriteContext writeContext);

        /// <summary>
        /// Asynchronously writes the provided <see cref="IXmiElement"/> to the <see cref="XmlWriter"/> as a reference element. When the
        /// <see cref="IXmiElement"/> is part of the document that is being written an xmi:idref element is written,
        /// otherwise an href reference element is written.
        /// </summary>
        /// <param name="xmlWriter">
        /// The <see cref="XmlWriter"/> to write to
        /// </param>
        /// <param name="element">
        /// The <see cref="IXmiElement"/> that is referenced
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
        Task WriteReferenceElementAsync(XmlWriter xmlWriter, IXmiElement element, string elementName, IXmiWriteContext writeContext);
    }
}
