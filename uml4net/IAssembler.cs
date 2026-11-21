// -------------------------------------------------------------------------------------------------
// <copyright file="IAssembler.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net
{
    using System.Collections.Generic;

    /// <summary>
    /// The <see cref="IAssembler"/> is the interface definition for the <see cref="Assembler"/>
    /// </summary>
    public interface IAssembler
    {
        /// <summary>
        /// Gets the references that could not be resolved by the most recent <see cref="Synchronize"/>
        /// </summary>
        IReadOnlyList<XmiReferenceResolutionFailure> ResolutionFailures { get; }

        /// <summary>
        /// Synchronizes the <see cref="IXmiElement"/>s in the <see cref="IXmiElementCache"/> by assigning
        /// the reference properties that are encoded by <see cref="IXmiElement.SingleValueReferencePropertyIdentifiers"/>
        /// and by <see cref="IXmiElement.MultiValueReferencePropertyIdentifiers"/>
        /// </summary>
        void Synchronize();
    }
}
