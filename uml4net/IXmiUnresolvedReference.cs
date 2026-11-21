// -------------------------------------------------------------------------------------------------
// <copyright file="IXmiUnresolvedReference.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net
{
    /// <summary>
    /// Defines the contract for objects representing a reference to an <see cref="IXmiElement"/> in another
    /// document that could not be resolved while reading.
    /// <para>
    /// A reference such as <c>&lt;appliedProfile xmi:type="uml:Profile" href="http://…#id"/&gt;</c> can only be
    /// turned into an object reference when the referenced document is available. When it is not - an
    /// Enterprise Architect profile identified by a <c>http://www.sparxsystems.com/profiles/…</c> URL for
    /// instance is not retrievable at all - the reference element is preserved in its original XMI form so
    /// that it is written back verbatim rather than silently lost.
    /// </para>
    /// </summary>
    public interface IXmiUnresolvedReference
    {
        /// <summary>
        /// Gets or sets the name of the reference property through which the referenced <see cref="IXmiElement"/>
        /// is reached, such as <c>appliedProfile</c>
        /// </summary>
        string PropertyName { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced <see cref="IXmiElement"/>, which is the value of
        /// the <c>href</c> attribute of the reference element
        /// </summary>
        string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the reference element in its original XMI form
        /// </summary>
        string ContentRawXmi { get; set; }
    }
}
