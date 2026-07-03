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

    using uml4net.Packages;

    /// <summary>
    /// The <see cref="XmiWritePlan"/> represents the result of a reference closure calculation and captures
    /// which <see cref="IPackage"/>s are written as root packages of the XMI document and which elements
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
        {
            this.RootPackages = rootPackages ?? throw new ArgumentNullException(nameof(rootPackages));
            this.LocalIdentifiers = localIdentifiers ?? throw new ArgumentNullException(nameof(localIdentifiers));
            this.ElementsMissingXmiId = elementsMissingXmiId ?? throw new ArgumentNullException(nameof(elementsMissingXmiId));
        }

        /// <summary>
        /// Gets the <see cref="IPackage"/>s that are written as root packages of the XMI document. The selected
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
    }
}
