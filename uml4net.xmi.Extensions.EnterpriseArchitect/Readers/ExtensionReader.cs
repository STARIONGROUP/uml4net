// -------------------------------------------------------------------------------------------------
//  <copyright file="ExtensionReader.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Extensions.EntrepriseArchitect.Structure.Readers
{
    using System.Xml;

    using uml4net.CommonStructure;
    using uml4net.Extensions;
    using uml4net.Packages;

    using IExtension = IExtension;

    public partial class ExtensionReader
    {
        /// <summary>
        /// Handles the read of XMI Element manually, when a specific case cannot be code-generated
        /// </summary>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="IXmiElement" />
        /// </param>
        /// <param name="namespaceUri">
        /// The namespaceUri of the parent <see cref="XmlReader" />>.
        /// Since <see cref="XmlReader.ReadSubtree" /> is used extensively the <see cref="XmlReader.NamespaceURI" />
        /// returns the empty string when reading from a subtree, therefore it is passed from the caller
        /// </param>
        /// <returns>
        /// True if the manual code could handle the Xmi read
        /// </returns>
        protected override bool HandleManualXmlRead(IExtension poco, XmlReader xmlReader, string documentName, string namespaceUri)
        {
            switch (xmlReader.LocalName.LowerCaseFirstLetter())
            {
                case "primitivetypes":
                case "profiles":
                {
                    xmlReader.Skip();
                    return true;
                }
                default:
                    return false;
            }
        }
    }
}
