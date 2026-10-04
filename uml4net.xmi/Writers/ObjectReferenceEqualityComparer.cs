// -------------------------------------------------------------------------------------------------
// <copyright file="ObjectReferenceEqualityComparer.cs" company="Starion Group S.A.">
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
