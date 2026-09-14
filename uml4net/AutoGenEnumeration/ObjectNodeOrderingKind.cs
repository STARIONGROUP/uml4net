// -------------------------------------------------------------------------------------------------
// <copyright file="ObjectNodeOrderingKind.cs" company="Starion Group S.A.">
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

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace uml4net.Activities
{
    using System;

    /// <summary>
    /// ObjectNodeOrderingKind is an enumeration indicating queuing order for offering the tokens held by an
    /// ObjectNode.
    /// </summary>
    public enum ObjectNodeOrderingKind
    {
        /// <summary>
        /// Indicates that tokens are unordered.
        /// </summary>
        Unordered,

        /// <summary>
        /// Indicates that tokens are ordered.
        /// </summary>
        Ordered,

        /// <summary>
        /// Indicates that tokens are queued in a last in, first out manner.
        /// </summary>
        LIFO,

        /// <summary>
        /// Indicates that tokens are queued in a first in, first out manner.
        /// </summary>
        FIFO
    }

    /// <summary>
    /// Extension methods for the <see cref="ObjectNodeOrderingKind"/> enumeration
    /// </summary>
    public static class ObjectNodeOrderingKindExtensions
    {
        /// <summary>
        /// Queries the name of the enumeration literal as defined in the UML metamodel, which is the value that
        /// represents the <paramref name="value"/> in an XMI document (XMI 2.5.1 clause 9.5.2, rule 2i)
        /// </summary>
        /// <param name="value">
        /// The <see cref="ObjectNodeOrderingKind"/> value
        /// </param>
        /// <returns>
        /// the name of the enumeration literal
        /// </returns>
        public static string QueryXmiLiteral(this ObjectNodeOrderingKind value)
        {
            return value switch
            {
                ObjectNodeOrderingKind.Unordered => "unordered",
                ObjectNodeOrderingKind.Ordered => "ordered",
                ObjectNodeOrderingKind.LIFO => "LIFO",
                ObjectNodeOrderingKind.FIFO => "FIFO",
                _ => throw new ArgumentOutOfRangeException(nameof(value), value, $"{value} is not a literal of ObjectNodeOrderingKind")
            };
        }

        /// <summary>
        /// Tries to map the name of an enumeration literal as it appears in an XMI document (XMI 2.5.1 clause 9.5.2,
        /// rule 2i) to the <see cref="ObjectNodeOrderingKind"/> value; the name must match the literal of the UML metamodel
        /// exactly, numeric values and other spellings are not literals
        /// </summary>
        /// <param name="literal">
        /// The name of the enumeration literal
        /// </param>
        /// <param name="value">
        /// The <see cref="ObjectNodeOrderingKind"/> value, the default value when the literal is not known
        /// </param>
        /// <returns>
        /// true when the literal is a literal of <see cref="ObjectNodeOrderingKind"/>, false otherwise
        /// </returns>
        public static bool TryParseXmiLiteral(string literal, out ObjectNodeOrderingKind value)
        {
            switch (literal)
            {
                case "unordered":
                    value = ObjectNodeOrderingKind.Unordered;
                    return true;
                case "ordered":
                    value = ObjectNodeOrderingKind.Ordered;
                    return true;
                case "LIFO":
                    value = ObjectNodeOrderingKind.LIFO;
                    return true;
                case "FIFO":
                    value = ObjectNodeOrderingKind.FIFO;
                    return true;
                default:
                    value = default;
                    return false;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
