// -------------------------------------------------------------------------------------------------
//  <copyright file="IXmiElementReaderFacade.cs" company="Starion Group S.A.">
// 
//    Copyright (C) 2019-2026 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
//  </copyright>
//  ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Readers
{
    using System;
    using System.Xml;

    using Microsoft.Extensions.Logging;

    using uml4net.xmi.Extender;
    using uml4net.xmi.Settings;

    /// <summary>
    /// The purpose of the <see cref="XmiElementReaderFacade"/> is to read an <see cref="IXmiElement"/> from an
    /// <see cref="XmlReader"/>
    /// </summary>
    public interface IXmiElementReaderFacade
    {
        /// <summary>
        /// Queries an instance of an <see cref="IXmiElement"/> based on the position of the <see cref="XmlReader"/>. When the reader
        /// is at an XML Element and has an attribute of xmi:type, the value of that attribute is used to select the appropriate
        /// XmiElementReader from which the <see cref="IXmiElement"/> is returned.
        /// </summary>
        /// <param name="xmlReader">
        /// An instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="IXmiElement"/>
        /// </param>
        /// <param name="namespaceUri">
        /// the namespace that the <see cref="IXmiElement"/> belongs to
        /// </param>
        /// <param name="cache">
        /// The <see cref="IXmiElementCache"/> in which all model instances are registered
        /// </param>
        /// <param name = "xmiReaderSettings" >
        /// The <see cref="IXmiReaderSettings"/> used to configure reading
        /// </param>
        /// <param name="nameSpaceResolver">
        /// The (injected) <see cref="INameSpaceResolver"/> used to resolve a namespace to one of the
        /// <see cref="KnowNamespacePrefixes"/> constants
        /// </param>
        /// <param name="loggerFactory">
        /// The <see cref="ILoggerFactory"/> to set up logging
        /// </param>
        /// <param name="explicitTypeName">
        /// the name of the type using the convention of the XMI file. This must be specified in case the XMI document does not include the
        /// xmi:type attribute since the type can be inferred from the property itself.
        /// </param>
        /// <param name="ignoreXmiType">
        /// Asserts that the xmi:type value should be ignored even if the attribute is present inside the XMI element.
        /// Should be used in case of extension part reading.
        /// </param>
        /// <param name="extenderReaderRegistry">
        /// The <see cref="IExtenderReaderRegistry" /> that provides <see cref="IExtenderReader" /> resolve
        /// </param>
        /// <returns>
        /// an instance of <see cref="IXmiElement"/>
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// thrown when the xmi:type is not supported and noXmiElementReader was found
        /// </exception>
        IXmiElement QueryXmiElement(XmlReader xmlReader, string documentName, string namespaceUri, IXmiElementCache cache, IXmiReaderSettings xmiReaderSettings, INameSpaceResolver nameSpaceResolver, IExtenderReaderRegistry extenderReaderRegistry, ILoggerFactory loggerFactory, string explicitTypeName = null, bool ignoreXmiType = false);
    }
}
