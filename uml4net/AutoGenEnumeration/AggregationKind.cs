// -------------------------------------------------------------------------------------------------
// <copyright file="AggregationKind.cs" company="Starion Group S.A.">
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

namespace uml4net.Classification
{
    using System;

    /// <summary>
    /// AggregationKind is an Enumeration for specifying the kind of aggregation of a Property.
    /// </summary>
    public enum AggregationKind
    {
        /// <summary>
        /// Indicates that the Property has no aggregation.
        /// </summary>
        None,

        /// <summary>
        /// Indicates that the Property has shared aggregation.
        /// </summary>
        Shared,

        /// <summary>
        /// Indicates that the Property is aggregated compositely, i.e., the composite object has responsibility
        /// for the existence and storage of the composed objects (parts).
        /// </summary>
        Composite
    }

    /// <summary>
    /// Extension methods for the <see cref="AggregationKind"/> enumeration
    /// </summary>
    public static class AggregationKindExtensions
    {
        /// <summary>
        /// Queries the name of the enumeration literal as defined in the UML metamodel, which is the value that
        /// represents the <paramref name="value"/> in an XMI document (XMI 2.5.1 clause 9.5.2, rule 2i)
        /// </summary>
        /// <param name="value">
        /// The <see cref="AggregationKind"/> value
        /// </param>
        /// <returns>
        /// the name of the enumeration literal
        /// </returns>
        public static string QueryXmiLiteral(this AggregationKind value)
        {
            return value switch
            {
                AggregationKind.None => "none",
                AggregationKind.Shared => "shared",
                AggregationKind.Composite => "composite",
                _ => throw new ArgumentOutOfRangeException(nameof(value), value, $"{value} is not a literal of AggregationKind")
            };
        }

        /// <summary>
        /// Tries to map the name of an enumeration literal as it appears in an XMI document (XMI 2.5.1 clause 9.5.2,
        /// rule 2i) to the <see cref="AggregationKind"/> value; the name must match the literal of the UML metamodel
        /// exactly, numeric values and other spellings are not literals
        /// </summary>
        /// <param name="literal">
        /// The name of the enumeration literal
        /// </param>
        /// <param name="value">
        /// The <see cref="AggregationKind"/> value, the default value when the literal is not known
        /// </param>
        /// <returns>
        /// true when the literal is a literal of <see cref="AggregationKind"/>, false otherwise
        /// </returns>
        public static bool TryParseXmiLiteral(string literal, out AggregationKind value)
        {
            switch (literal)
            {
                case "none":
                    value = AggregationKind.None;
                    return true;
                case "shared":
                    value = AggregationKind.Shared;
                    return true;
                case "composite":
                    value = AggregationKind.Composite;
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
