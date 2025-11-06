// -------------------------------------------------------------------------------------------------
//  <copyright file="EnterpriseArchitectXmiReader.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2025 Starion Group S.A.
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

namespace uml4net.xmi.Extensions.EnterpriseArchitect.Readers
{
    using Microsoft.Extensions.Logging;
    using System.Linq;
    using System.Xml;
    using uml4net.Packages;
    using uml4net.xmi;
    using uml4net.xmi.Extender;
    using uml4net.xmi.Extensions.EntrepriseArchitect.Structure;
    using uml4net.xmi.Readers;
    using uml4net.xmi.ReferenceResolver;
    using uml4net.xmi.Settings;
    using Extension = uml4net.xmi.Extensions.EntrepriseArchitect.Structure.Extension;
    using IExtension = uml4net.xmi.Extensions.EntrepriseArchitect.Structure.IExtension;

    /// <summary>
    /// The <see cref="EnterpriseArchitectXmiReader" /> class reads XMI extensions nodes.
    /// </summary>
    public class EnterpriseArchitectXmiReader: XmiReader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XmiReader"/> class.
        /// </summary>
        /// <param name="assembler">
        /// The (injected) <see cref="IAssembler"/> used to assemble a UML object graph
        /// </param>
        /// <param name="cache">
        /// The (injected) <see cref="IXmiElementCache"/> used to cache all the <see cref="IXmiElement"/>s
        /// </param>
        /// <param name="xmiElementReaderFacade">
        /// The (injected) <see cref="IXmiElementReaderFacade"/> used to resolve any
        /// required <see cref="IXmiElementReader{T}"/>
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        /// <param name="externalReferenceResolver">The <see cref="IExternalReferenceResolver"/></param>
        /// <param name="scope">The <see cref="IXmiReaderScope"/></param>
        /// <param name="xmiReaderSettings">The injected <see cref="IXmiReaderSettings"/> that provides reading setting for XMI</param>
        /// <param name="nameSpaceResolver">
        /// The (injected) <see cref="INameSpaceResolver"/> used to resolve a namespace to one of the
        /// <see cref="KnowNamespacePrefixes"/>
        /// </param>
        /// <param name="extenderReaderRegistry">The injected <see cref="IExtenderReaderRegistry"/> that provides <see cref="IExtenderReader"/> resolve features</param>
        public EnterpriseArchitectXmiReader(IAssembler assembler, IXmiElementCache cache, IXmiElementReaderFacade xmiElementReaderFacade, ILoggerFactory loggerFactory,
            IExternalReferenceResolver externalReferenceResolver, IXmiReaderScope scope, IXmiReaderSettings xmiReaderSettings, INameSpaceResolver nameSpaceResolver, IExtenderReaderRegistry extenderReaderRegistry) : base(assembler, cache, xmiElementReaderFacade, loggerFactory, externalReferenceResolver, scope, xmiReaderSettings, nameSpaceResolver, extenderReaderRegistry)
        {
        }

        /// <summary>
        /// Reads an XMI extension from the provided <see cref="XmlReader" /> and returns an instance of
        /// <see cref="IExtension" /> populated with the extension data.
        /// </summary>
        /// <param name="xmlReader">
        /// The <see cref="XmlReader" /> instance used to parse the XMI data.
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="IXmiElement" />
        /// </param>
        /// <param name="namespaceUri">
        /// The namespaceUri of the parent <see cref="XmlReader" />>.
        /// Since <see cref="XmlReader.ReadSubtree" /> is used extensively the <see cref="XmlReader.NamespaceURI" />
        /// returns the empty string when reading from a subtree, therefore it is passed from the caller
        /// </param>     
        /// <returns>
        /// An instance of <see cref="IPackage" />, specifically an <see cref="IExtension" />
        /// containing the extension information.
        /// </returns>
        /// <remarks>
        /// The method processes the XML structure for an extension, including its extender attributes
        /// and nested elements, while logging warnings for unrecognized XML nodes.
        /// </remarks>
        public override IPackage ReadXmiExtension(XmlReader xmlReader, string documentName, string namespaceUri)
        {
            return new Package();
            /*if (xmlReader.MoveToContent() != XmlNodeType.Element)
            {
                return new Extension();
            }

            var extensionElement = (IExtension)this.XmiElementReaderFacade.QueryXmiElement(xmlReader, documentName, namespaceUri, this.Cache, this.XmiReaderSettings, this.nameSpaceResolver, this .LoggerFactory, "Extension");

            foreach (var elementReference in this.Cache.Values.OfType<IElementReference>().Where(x => x.SingleValueReferencePropertyIdentifiers.Count != 0))
            {
                if (!this.Cache.TryGetValue(elementReference.SingleValueReferencePropertyIdentifiers.Single().Value, out var extendedElement))
                {
                    continue;
                }

                elementReference.ExtendedElement = extendedElement;
                extendedElement.Extensions.Add(elementReference);
            }

            return extensionElement;*/
        }
    }
}
