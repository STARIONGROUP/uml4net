// -------------------------------------------------------------------------------------------------
// <copyright file="XmiElementWriter.cs" company="Starion Group S.A.">
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
    using System.Threading.Tasks;
    using System.Xml;

    using Microsoft.Extensions.Logging;

    using uml4net;
    using uml4net.xmi.Settings;

    /// <summary>
    /// The abstract super class from which each XMI writer needs to derive
    /// </summary>
    /// <typeparam name="TXmiElement">The type of the XMI element to be written.</typeparam>
    public abstract class XmiElementWriter<TXmiElement> where TXmiElement : IXmiElement
    {
        /// <summary>
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </summary>
        protected readonly ILoggerFactory LoggerFactory;

        /// <summary>
        /// The (injected) <see cref="IXmiElementWriterFacade"/> used to write contained and referenced
        /// <see cref="IXmiElement"/>s
        /// </summary>
        protected readonly IXmiElementWriterFacade XmiElementWriterFacade;

        /// <summary>
        /// The injected <see cref="IXmiWriterSettings" /> that provides XMI writer settings
        /// </summary>
        protected readonly IXmiWriterSettings XmiWriterSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiElementWriter{T}"/> class.
        /// </summary>
        /// <param name="xmiElementWriterFacade">
        /// The (injected) <see cref="IXmiElementWriterFacade"/> used to write contained and referenced
        /// <see cref="IXmiElement"/>s
        /// </param>
        /// <param name="xmiWriterSettings">
        /// The injected <see cref="IXmiWriterSettings" /> that provides XMI writer settings
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        protected XmiElementWriter(IXmiElementWriterFacade xmiElementWriterFacade, IXmiWriterSettings xmiWriterSettings, ILoggerFactory loggerFactory)
        {
            this.XmiElementWriterFacade = xmiElementWriterFacade;
            this.XmiWriterSettings = xmiWriterSettings;
            this.LoggerFactory = loggerFactory;
        }

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
        public abstract void Write(XmlWriter xmlWriter, TXmiElement element, string elementName, IXmiWriteContext writeContext);

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
        public abstract Task WriteAsync(XmlWriter xmlWriter, TXmiElement element, string elementName, IXmiWriteContext writeContext);

        /// <summary>
        /// Writes the start element to the <see cref="XmlWriter"/>. The <paramref name="elementName"/> may be
        /// a qualified name such as <code>uml:Package</code>, in which case the appropriate namespace is used,
        /// or a plain property name such as <code>packagedElement</code>.
        /// </summary>
        /// <param name="xmlWriter">
        /// The <see cref="XmlWriter"/> to write to
        /// </param>
        /// <param name="elementName">
        /// The name of the XML element that is written
        /// </param>
        protected void WriteStartElement(XmlWriter xmlWriter, string elementName)
        {
            var separatorIndex = elementName.IndexOf(':');

            if (separatorIndex > 0)
            {
                var prefix = elementName.Substring(0, separatorIndex);
                var localName = elementName.Substring(separatorIndex + 1);
                var namespaceUri = prefix == "xmi" ? this.XmiWriterSettings.XmiNamespaceUri : this.XmiWriterSettings.UmlNamespaceUri;

                xmlWriter.WriteStartElement(prefix, localName, namespaceUri);
            }
            else
            {
                xmlWriter.WriteStartElement(elementName);
            }
        }

        /// <summary>
        /// Asynchronously writes the start element to the <see cref="XmlWriter"/>. The <paramref name="elementName"/> may be
        /// a qualified name such as <code>uml:Package</code>, in which case the appropriate namespace is used,
        /// or a plain property name such as <code>packagedElement</code>.
        /// </summary>
        /// <param name="xmlWriter">
        /// The <see cref="XmlWriter"/> to write to
        /// </param>
        /// <param name="elementName">
        /// The name of the XML element that is written
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        protected Task WriteStartElementAsync(XmlWriter xmlWriter, string elementName)
        {
            var separatorIndex = elementName.IndexOf(':');

            if (separatorIndex > 0)
            {
                var prefix = elementName.Substring(0, separatorIndex);
                var localName = elementName.Substring(separatorIndex + 1);
                var namespaceUri = prefix == "xmi" ? this.XmiWriterSettings.XmiNamespaceUri : this.XmiWriterSettings.UmlNamespaceUri;

                return xmlWriter.WriteStartElementAsync(prefix, localName, namespaceUri);
            }

            return xmlWriter.WriteStartElementAsync(null, elementName, null);
        }

        /// <summary>
        /// Writes the <see cref="XmiExtension"/>s of an <see cref="IXmiElement"/> to the <see cref="XmlWriter"/>.
        /// </summary>
        /// <param name="xmlWriter">
        /// The <see cref="XmlWriter"/> to write to
        /// </param>
        /// <param name="extensions">
        /// The <see cref="XmiExtension"/>s that are to be written
        /// </param>
        protected void WriteExtensions(XmlWriter xmlWriter, List<XmiExtension> extensions)
        {
            if (extensions == null || extensions.Count == 0)
            {
                return;
            }

            var xmiExtensionWriter = new XmiExtensionWriter(this.XmiWriterSettings, this.LoggerFactory);

            foreach (var extension in extensions)
            {
                xmiExtensionWriter.Write(xmlWriter, extension);
            }
        }

        /// <summary>
        /// Asynchronously writes the <see cref="XmiExtension"/>s of an <see cref="IXmiElement"/> to the
        /// <see cref="XmlWriter"/>.
        /// </summary>
        /// <param name="xmlWriter">
        /// The <see cref="XmlWriter"/> to write to
        /// </param>
        /// <param name="extensions">
        /// The <see cref="XmiExtension"/>s that are to be written
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        protected async Task WriteExtensionsAsync(XmlWriter xmlWriter, List<XmiExtension> extensions)
        {
            if (extensions == null || extensions.Count == 0)
            {
                return;
            }

            var xmiExtensionWriter = new XmiExtensionWriter(this.XmiWriterSettings, this.LoggerFactory);

            foreach (var extension in extensions)
            {
                await xmiExtensionWriter.WriteAsync(xmlWriter, extension);
            }
        }

        /// <summary>
        /// Returns the provided value with the first letter converted to lower case, which is used to
        /// serialize enumeration literals.
        /// </summary>
        /// <param name="value">
        /// the value that is to be converted
        /// </param>
        /// <returns>
        /// the converted value
        /// </returns>
        protected static string LowerCaseFirstLetter(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            return char.ToLowerInvariant(value[0]) + value.Substring(1);
        }
    }
}
