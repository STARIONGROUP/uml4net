// -------------------------------------------------------------------------------------------------
// <copyright file="XmiCompositeReference.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net
{
    /// <summary>
    /// A proxy, read from a composite property, that refers to the definition of the owned element by
    /// <c>xmi:idref</c> or <c>href</c> instead of containing it (XMI 2.5.1 clause 7.10.1)
    /// </summary>
    public class XmiCompositeReference
    {
        /// <summary>
        /// Gets or sets the value of the <c>href</c> or <c>xmi:idref</c> attribute of the proxy
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the index, in document order, of the proxy among all the elements of the composite
        /// property, counting both contained definitions and proxies
        /// </summary>
        public int Position { get; set; }
    }
}
