// -------------------------------------------------------------------------------------------------
// <copyright file="ExpansionKind.cs" company="Starion Group S.A.">
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

namespace uml4net.Actions
{
    using System;

    /// <summary>
    /// ExpansionKind is an enumeration type used to specify how an ExpansionRegion executes its contents.
    /// </summary>
    public enum ExpansionKind
    {
        /// <summary>
        /// The content of the ExpansionRegion is executed concurrently for the elements of the input
        /// collections.
        /// </summary>
        Parallel,

        /// <summary>
        /// The content of the ExpansionRegion is executed iteratively for the elements of the input
        /// collections, in the order of the input elements, if the collections are ordered.
        /// </summary>
        Iterative,

        /// <summary>
        /// A stream of input collection elements flows into a single execution of the content of the
        /// ExpansionRegion, in the order of the collection elements if the input collections are ordered.
        /// </summary>
        Stream
    }

    /// <summary>
    /// Extension methods for the <see cref="ExpansionKind"/> enumeration
    /// </summary>
    public static class ExpansionKindExtensions
    {
        /// <summary>
        /// Queries the name of the enumeration literal as defined in the UML metamodel, which is the value that
        /// represents the <paramref name="value"/> in an XMI document (XMI 2.5.1 clause 9.5.2, rule 2i)
        /// </summary>
        /// <param name="value">
        /// The <see cref="ExpansionKind"/> value
        /// </param>
        /// <returns>
        /// the name of the enumeration literal
        /// </returns>
        public static string QueryXmiLiteral(this ExpansionKind value)
        {
            return value switch
            {
                ExpansionKind.Parallel => "parallel",
                ExpansionKind.Iterative => "iterative",
                ExpansionKind.Stream => "stream",
                _ => throw new ArgumentOutOfRangeException(nameof(value), value, $"{value} is not a literal of ExpansionKind")
            };
        }

        /// <summary>
        /// Tries to map the name of an enumeration literal as it appears in an XMI document (XMI 2.5.1 clause 9.5.2,
        /// rule 2i) to the <see cref="ExpansionKind"/> value; the name must match the literal of the UML metamodel
        /// exactly, numeric values and other spellings are not literals
        /// </summary>
        /// <param name="literal">
        /// The name of the enumeration literal
        /// </param>
        /// <param name="value">
        /// The <see cref="ExpansionKind"/> value, the default value when the literal is not known
        /// </param>
        /// <returns>
        /// true when the literal is a literal of <see cref="ExpansionKind"/>, false otherwise
        /// </returns>
        public static bool TryParseXmiLiteral(string literal, out ExpansionKind value)
        {
            switch (literal)
            {
                case "parallel":
                    value = ExpansionKind.Parallel;
                    return true;
                case "iterative":
                    value = ExpansionKind.Iterative;
                    return true;
                case "stream":
                    value = ExpansionKind.Stream;
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
