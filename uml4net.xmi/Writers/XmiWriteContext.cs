// -------------------------------------------------------------------------------------------------
// <copyright file="XmiWriteContext.cs" company="Starion Group S.A.">
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

    /// <summary>
    /// The <see cref="XmiWriteContext"/> represents the state of a single write operation that is
    /// shared by all <see cref="XmiElementWriter{TXmiElement}"/> instances while writing an XMI document.
    /// </summary>
    public class XmiWriteContext : IXmiWriteContext
    {
        /// <summary>
        /// The <see cref="IXmiElement.FullyQualifiedIdentifier"/>s of the elements that are serialized
        /// inside the document that is being written.
        /// </summary>
        private readonly HashSet<string> localIdentifiers;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiWriteContext"/> class.
        /// </summary>
        /// <param name="documentName">
        /// The name of the document that is being written
        /// </param>
        /// <param name="localIdentifiers">
        /// The <see cref="IXmiElement.FullyQualifiedIdentifier"/>s of the elements that are serialized
        /// inside the document that is being written
        /// </param>
        public XmiWriteContext(string documentName, HashSet<string> localIdentifiers)
        {
            this.DocumentName = documentName ?? throw new ArgumentNullException(nameof(documentName));
            this.localIdentifiers = localIdentifiers ?? throw new ArgumentNullException(nameof(localIdentifiers));
        }

        /// <summary>
        /// Gets the name of the document that is being written.
        /// </summary>
        public string DocumentName { get; }

        /// <summary>
        /// Queries whether the provided <see cref="IXmiElement"/> is serialized inside the document that is being written.
        /// </summary>
        /// <param name="element">
        /// The <see cref="IXmiElement"/> that is to be checked
        /// </param>
        /// <returns>
        /// true when the <paramref name="element"/> is part of the document that is being written, false otherwise
        /// </returns>
        public bool IsLocal(IXmiElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            return this.localIdentifiers.Contains(element.FullyQualifiedIdentifier);
        }

        /// <summary>
        /// Queries the href reference to the provided <see cref="IXmiElement"/>, which is the concatenation
        /// of the <see cref="IXmiElement.DocumentName"/> and the <see cref="IXmiElement.XmiId"/> separated by a pound sign #
        /// </summary>
        /// <param name="element">
        /// The <see cref="IXmiElement"/> for which the href reference is queried
        /// </param>
        /// <returns>
        /// the href reference to the <paramref name="element"/>
        /// </returns>
        public string QueryHref(IXmiElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            return $"{element.DocumentName}#{element.XmiId}";
        }
    }
}
