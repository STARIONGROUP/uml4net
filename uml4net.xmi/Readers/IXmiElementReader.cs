// -------------------------------------------------------------------------------------------------
// <copyright file="IXmiElementReader.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Readers
{
    using System.Xml;

    using uml4net;
    
    /// <summary>
    /// Defines a contract for reading <typeparamref name="TXmiElement"/> objects
    /// from their XML representation.
    /// </summary>
    /// <typeparam name="TXmiElement">The type of the XMI element to be read.</typeparam>
    public interface IXmiElementReader<out TXmiElement> where TXmiElement : IXmiElement
    {
        /// <summary>
        /// Reads the <typeparamref name="TXmiElement"/> object from its XML representation
        /// </summary>
        /// <param name="xmlReader">
        /// an instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="namespaceUri">
        /// The namespaceUri of the parent <see cref="XmlReader"/>>.
        /// Since <see cref="XmlReader.ReadSubtree"/> is used extensively the <see cref="XmlReader.NamespaceURI"/>
        /// returns the empty string when reading from a subtree, therefore it is passed from the caller
        /// </param>
        /// <param name="xmiNamespace">
        /// The xmiNamespace of the parent <see cref="XmlReader"/>>.
        /// </param>
        /// <returns>
        /// an instance of <typeparamref name="TXmiElement"/>
        /// </returns>
        public TXmiElement Read(XmlReader xmlReader, string namespaceUri = "", string xmiNamespace = "");
    }
}
