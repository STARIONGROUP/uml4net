// -------------------------------------------------------------------------------------------------
// <copyright file="XmiReferenceResolutionFailureKind.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net
{
    /// <summary>
    /// Specifies why a reference could not be resolved by the <see cref="IAssembler"/>
    /// </summary>
    public enum XmiReferenceResolutionFailureKind
    {
        /// <summary>
        /// The referenced <see cref="IXmiElement"/> was not found in the <see cref="IXmiElementCache"/>, for example
        /// because the document that contains it is not available or because its type is not supported
        /// </summary>
        NotFound = 0,

        /// <summary>
        /// The referenced <see cref="IXmiElement"/> was found but its type does not match the type of the property
        /// </summary>
        UnexpectedType = 1,

        /// <summary>
        /// The referenced <see cref="IXmiElement"/> is the target of a composite property proxy but is already owned by
        /// another element, and is therefore not taken away from its owner
        /// </summary>
        AlreadyOwned = 2,

        /// <summary>
        /// The referenced <see cref="IXmiElement"/> is the target of a composite property proxy but the composite property
        /// already holds as many values as the upper value of its multiplicity allows, for example a second value of
        /// the single-valued <c>Constraint::specification</c>
        /// </summary>
        MultiplicityExceeded = 3
    }
}
