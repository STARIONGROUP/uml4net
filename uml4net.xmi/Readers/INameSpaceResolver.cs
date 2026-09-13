// -------------------------------------------------------------------------------------------------
// <copyright file="INameSpaceResolver.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Readers
{
    /// <summary>
    /// The purpose of the <see cref="INameSpaceResolver"/> is to resolve the namespace uri's of the
    /// supported namespaces to support parsing of a UML model from an XMI document
    /// </summary>
    public interface INameSpaceResolver
    {
        /// <summary>
        /// Resolves the supported prefix from the provided <paramref name="namespaceUri"/>
        /// </summary>
        /// <param name="namespaceUri">
        /// the namespace URI to resolve the supported prefix. In case this is an un-registered
        /// one, the prefix "other" is returned
        /// </param>
        /// <returns>
        /// a namespace prefix (string based such as xmi, mofext, uml. etc...)
        /// </returns>
        string ResolvePrefix(string namespaceUri);
        
        /// <summary>
        /// Registers a mapping between a namespace name (URI) and a namespace prefix.
        /// </summary>
        /// <param name="namespaceUri">
        /// The namespace name (also known as the namespace URI) that uniquely identifies the XML namespace.
        /// </param>
        /// <param name="prefix">
        /// The namespace prefix to associate with the specified namespace URI. 
        /// The prefix is a shorthand alias used in XML element and attribute names within this scope.
        /// </param>
        public void Register(string namespaceUri, string prefix);

        /// <summary>
        /// use the <see cref="INameSpaceResolver"/> to resolve and sets the namespaces said <see cref="INameSpaceResolver"/>
        /// </summary>
        /// <param name="namespaceUri">
        /// the subject namespace URI
        /// </param>
        void ResolveAndSetNamespace(string namespaceUri);

        /// <summary>
        /// Registers a namespace prefix that the document being processed binds to a namespace, so that qualified
        /// names found in the document (such as the value of an <c>xmi:type</c> attribute) can be resolved when the
        /// <see cref="System.Xml.XmlReader"/> at hand cannot resolve the prefix itself, which is the case for a
        /// subtree reader whose subtree does not contain the declaration
        /// </summary>
        /// <param name="prefix">
        /// The prefix as declared in the document; an empty string for the default namespace
        /// </param>
        /// <param name="namespaceUri">
        /// The namespace URI the document binds the <paramref name="prefix"/> to
        /// </param>
        void RegisterDocumentPrefix(string prefix, string namespaceUri);

        /// <summary>
        /// Resolves a prefix declared in the document being processed to the supported prefix of the namespace
        /// it is bound to (such as xmi, uml, ...)
        /// </summary>
        /// <param name="prefix">
        /// The prefix as declared in the document; an empty string for the default namespace
        /// </param>
        /// <returns>
        /// the supported prefix, or "other" when the prefix is not registered or is bound to a namespace that is not supported
        /// </returns>
        string ResolveDocumentPrefix(string prefix);

        /// <summary>
        /// Gets or sets the XMI namespace for the document that is being processed
        /// </summary>
        string XmiNameSpace { get; set; }

        /// <summary>
        /// Gets or sets the Mofext namespace for the document that is being processed
        /// </summary>
        string MofextNameSpace { get; set; }

        /// <summary>
        /// Gets or sets the UML namespace for the document that is being processed
        /// </summary>
        string UmlNameSpace { get; set; }

        /// <summary>
        /// Gets or sets the UmlDiagramInterchange namespace for the document that is being processed
        /// </summary>
        string UmlDiagramInterchangeNameSpace { get; set; }

        /// <summary>
        /// Gets or sets the PrimitiveTypes namespace for the document that is being processed
        /// </summary>
        string PrimitiveTypesNameSpace { get; set; }
    }
}
