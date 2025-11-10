// -------------------------------------------------------------------------------------------------
//  <copyright file="XmiRoot.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Xmi
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents the XMI 2.5.1 <c>xmi:XMI</c> root element — the container for model content
    /// (e.g., UML elements) and optional XMI metadata.
    /// </summary>
    /// <remarks>
    /// <para>
    /// According to the XMI specification, <c>xmi:XMI</c> may contain zero or more
    /// top-level model objects (instances from one or more metamodels) and, when used,
    /// XMI-defined metadata such as documentation, differences, and extensions.
    /// Child model objects are validated against their own schemas/namespaces
    /// (<c>processContents="strict"</c>), and may carry XMI identity/linking attributes
    /// (e.g., <c>xmi:id</c>, <c>xmi:uuid</c>, <c>xmi:type</c>).
    /// </para>
    /// <para>
    /// Use this type as the document root when the file uses an <c>xmi:XMI</c> wrapper.
    /// If a file instead has a single UML package-like root (<c>uml:Model</c>,
    /// <c>uml:Package</c>, or <c>uml:Profile</c>) without the wrapper, handle that via
    /// your UML root reader.
    /// </para>
    /// <para>
    /// Canonical XMI note: when exporting Canonical XMI, <c>xmi:XMI</c> must be the root,
    /// and header elements such as <c>xmi:documentation</c>, <c>xmi:difference</c>, and
    /// <c>xmi:extension</c> are not emitted.
    /// </para>
    /// </remarks>
    /// <example>
    /// <code>
    /// <xmi:XMI xmlns:xmi="http://www.omg.org/spec/XMI/20110701"
    ///          xmlns:uml="http://www.omg.org/spec/UML/20110701">
    ///   <!-- Top-level model objects ("Content") -->
    ///   <uml:Model xmi:id="_m1" xmi:type="uml:Model"/>
    ///
    ///   <!-- Optional XMI metadata -->
    ///   <xmi:documentation>
    ///     <exporter>uml4net</exporter>
    ///     <exporterVersion>1.0</exporterVersion>
    ///   </xmi:documentation>
    /// </xmi:XMI>
    /// </code>
    /// </example>
    public class XmiRoot
    {
        /// <summary>
        /// The content of the xmi document
        /// </summary>
        public List<IXmiElement> Content { get; set; } = [];

        /// <summary>
        /// Optional XMI <c>xmi:documentation</c> block that carries human-readable
        /// metadata about the document (e.g., contact, exporter, exporterVersion,
        /// long/short descriptions, notice, owner, timestamp). It may also include
        /// tool-specific <c>xmi:Extension</c> children.
        /// </summary>
        /// <remarks>
        /// This element is used when the file employs an <c>xmi:XMI</c> wrapper.  
        /// For Canonical XMI exports, <c>xmi:documentation</c> is not emitted.
        /// </remarks>
        public Documentation Documentation { get; set; }

        /// <summary>
        /// Gets or sets the extensions defined of this <see cref="XmiRoot" />
        /// </summary>
        public List<XmiExtension> Extensions { get; set; } = [];
    }
}
