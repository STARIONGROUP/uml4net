// -------------------------------------------------------------------------------------------------
// <copyright file="ObjectReferenceEqualityComparer.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Writers
{
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// An <see cref="IEqualityComparer{T}"/> that compares objects by reference, whatever their equality semantics
    /// </summary>
    internal sealed class ObjectReferenceEqualityComparer : IEqualityComparer<object>
    {
        /// <summary>
        /// Gets the single instance of the <see cref="ObjectReferenceEqualityComparer"/>
        /// </summary>
        public static ObjectReferenceEqualityComparer Instance { get; } = new();

        /// <summary>
        /// Determines whether the provided objects are the same instance
        /// </summary>
        /// <param name="x">The first object</param>
        /// <param name="y">The second object</param>
        /// <returns>true when both are the same instance</returns>
        public new bool Equals(object x, object y) => ReferenceEquals(x, y);

        /// <summary>
        /// Returns the hash code of the instance, regardless of an override of <see cref="object.GetHashCode"/>
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>The hash code</returns>
        public int GetHashCode(object obj) => RuntimeHelpers.GetHashCode(obj);
    }
}
