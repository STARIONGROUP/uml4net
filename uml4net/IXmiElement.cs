﻿// -------------------------------------------------------------------------------------------------
// <copyright file="IPackage.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2025 Starion Group S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, softwareUseCases
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net
{
    using System.Collections.Generic;

    using uml4net.CommonStructure;

    /// <summary>
    /// The <see cref="IXmiElement"/> captures the XMI properties of each element in the
    /// XMI document
    /// </summary>
    public interface IXmiElement
    {
        /// <summary>
        /// Gets or sets the unique identifier of the Element in the XMI document
        /// </summary>
        public string XmiId { get; set; }

        /// <summary>
        /// Gets or sets the name of the document that contains the element
        /// </summary>
        public string DocumentName { get; set; }

        /// <summary>
        /// Gets or sets the namespace Uri of the XMi element that this <see cref="IXmiElement"/>
        /// belongs to.
        /// </summary>
        public string XmiNamespaceUri { get; set; }

        /// <summary>
        /// Gets or sets the GUID unique identifier of the Element in the XMI document
        /// </summary>
        public string XmiGuid { get; set; }

        /// <summary>
        /// Gets or sets the name of the xmi type
        /// </summary>
        public string XmiType { get; set; }

        /// <summary>
        /// Gets the Fully Qualified Identifier which is the concatenation of the
        /// <see cref="DocumentName"/> and the <see cref="XmiId"/> seperated by a pound sign #
        /// </summary>
        /// <remarks>
        /// In case the <see cref="DocumentName"/> is empty then FQN uses the underscore _ as <see cref="DocumentName"/>
        /// </remarks>
        public string FullyQualifiedIdentifier { get; }

        /// <summary>
        /// Gets or sets a dictionary of single-valued reference properties and the associated unique identifiers
        /// </summary>
        public Dictionary<string, string> SingleValueReferencePropertyIdentifiers { get; set; }

        /// <summary>
        /// Gets or sets a dictionary of multivalued reference properties and the associated unique identifiers
        /// </summary>
        public Dictionary<string, List<string>> MultiValueReferencePropertyIdentifiers { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IXmiElementCache"/>
        /// </summary>
        public IXmiElementCache Cache { get; set; }

        /// <summary>
        /// Gets or sets the extensions defined of this <see cref="IElement" />
        /// </summary>
        List<IElement> Extensions { get; set; }
    }
}
