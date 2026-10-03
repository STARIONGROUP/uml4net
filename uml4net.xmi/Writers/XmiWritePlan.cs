// -------------------------------------------------------------------------------------------------
// <copyright file="XmiWritePlan.cs" company="Starion Group S.A.">
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
    using System.Linq;

    using uml4net.Packages;

    /// <summary>
    /// The <see cref="XmiWritePlan"/> represents the result of a reference closure calculation and captures
    /// which <see cref="IXmiElement"/>s are written as top-level elements of the XMI document and which elements
    /// are serialized inside the document.
    /// </summary>
    public class XmiWritePlan
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XmiWritePlan"/> class.
        /// </summary>
        /// <param name="rootPackages">
        /// The <see cref="IPackage"/>s that are written as root packages of the XMI document
        /// </param>
        /// <param name="localIdentifiers">
        /// The <see cref="IXmiElement.FullyQualifiedIdentifier"/>s of the elements that are serialized inside the XMI document
        /// </param>
        /// <param name="elementsMissingXmiId">
        /// The elements that are part of the document but do not have an <see cref="IXmiElement.XmiId"/>
        /// </param>
        public XmiWritePlan(IReadOnlyList<IPackage> rootPackages, HashSet<string> localIdentifiers, IReadOnlyList<IXmiElement> elementsMissingXmiId)
            : this((IReadOnlyList<IXmiElement>)(rootPackages ?? throw new ArgumentNullException(nameof(rootPackages))), localIdentifiers, elementsMissingXmiId)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiWritePlan"/> class.
        /// </summary>
        /// <param name="rootElements">
        /// The <see cref="IXmiElement"/>s that are written as top-level elements of the XMI document, in document order
        /// </param>
        /// <param name="localIdentifiers">
        /// The <see cref="IXmiElement.FullyQualifiedIdentifier"/>s of the elements that are serialized inside the XMI document
        /// </param>
        /// <param name="elementsMissingXmiId">
        /// The elements that are part of the document but do not have an <see cref="IXmiElement.XmiId"/>
        /// </param>
        public XmiWritePlan(IReadOnlyList<IXmiElement> rootElements, HashSet<string> localIdentifiers, IReadOnlyList<IXmiElement> elementsMissingXmiId)
            : this(rootElements, localIdentifiers, elementsMissingXmiId, [])
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiWritePlan"/> class.
        /// </summary>
        /// <param name="rootElements">
        /// The <see cref="IXmiElement"/>s that are written as top-level elements of the XMI document, in document order
        /// </param>
        /// <param name="localIdentifiers">
        /// The <see cref="IXmiElement.FullyQualifiedIdentifier"/>s of the elements that are serialized inside the XMI document
        /// </param>
        /// <param name="elementsMissingXmiId">
        /// The elements that are part of the document but do not have an <see cref="IXmiElement.XmiId"/>
        /// </param>
        /// <param name="elementsMissingDocumentName">
        /// The elements that are referenced from the document, are not written in the document and do not have an
        /// <see cref="IXmiElement.DocumentName"/>
        /// </param>
        public XmiWritePlan(IReadOnlyList<IXmiElement> rootElements, HashSet<string> localIdentifiers, IReadOnlyList<IXmiElement> elementsMissingXmiId, IReadOnlyList<IXmiElement> elementsMissingDocumentName)
        {
            this.RootElements = rootElements ?? throw new ArgumentNullException(nameof(rootElements));
            this.RootPackages = rootElements.OfType<IPackage>().ToList();
            this.LocalIdentifiers = localIdentifiers ?? throw new ArgumentNullException(nameof(localIdentifiers));
            this.ElementsMissingXmiId = elementsMissingXmiId ?? throw new ArgumentNullException(nameof(elementsMissingXmiId));
            this.ElementsMissingDocumentName = elementsMissingDocumentName ?? throw new ArgumentNullException(nameof(elementsMissingDocumentName));
        }

        /// <summary>
        /// Gets the <see cref="IXmiElement"/>s that are written as top-level elements of the XMI document, in document
        /// order. The selected root elements come first, followed by the packages that are included as a result of
        /// <see cref="uml4net.xmi.Settings.ExternalReferenceResolutionKind.Include"/>.
        /// </summary>
        public IReadOnlyList<IXmiElement> RootElements { get; }

        /// <summary>
        /// Gets the <see cref="IPackage"/>s of the <see cref="RootElements"/>. The selected
        /// package comes first, followed by the packages that are included as a result of
        /// <see cref="uml4net.xmi.Settings.ExternalReferenceResolutionKind.Include"/>.
        /// </summary>
        public IReadOnlyList<IPackage> RootPackages { get; }

        /// <summary>
        /// Gets the <see cref="IXmiElement.FullyQualifiedIdentifier"/>s of the elements that are serialized inside the XMI document.
        /// </summary>
        public HashSet<string> LocalIdentifiers { get; }

        /// <summary>
        /// Gets the elements that are part of the document but do not have an <see cref="IXmiElement.XmiId"/>.
        /// </summary>
        public IReadOnlyList<IXmiElement> ElementsMissingXmiId { get; }

        /// <summary>
        /// Gets the elements that are referenced from the document, are not written in the document and do not have an
        /// <see cref="IXmiElement.DocumentName"/>. A reference to such an element is written as an href, and an href
        /// without document name, <c>href="#id"</c>, resolves against the document that is being written, where the
        /// element is not (XMI 2.5.1 clause 7.10.2).
        /// </summary>
        public IReadOnlyList<IXmiElement> ElementsMissingDocumentName { get; }
    }
}
