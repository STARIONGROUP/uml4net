// -------------------------------------------------------------------------------------------------
// <copyright file="Status.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Extensions.EnterpriseArchitect.Structure
{
    using System;

    /// <summary>
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// </summary>
        Approved,

        /// <summary>
        /// </summary>
        Implemented,

        /// <summary>
        /// </summary>
        Mandatory,

        /// <summary>
        /// </summary>
        Proposed,

        /// <summary>
        /// </summary>
        Validated
    }

    /// <summary>
    /// Extension methods for the <see cref="Status"/> enumeration
    /// </summary>
    public static class StatusExtensions
    {
        /// <summary>
        /// Queries the name of the enumeration literal as defined in the UML metamodel, which is the value that
        /// represents the <paramref name="value"/> in an XMI document (XMI 2.5.1 clause 9.5.2, rule 2i)
        /// </summary>
        /// <param name="value">
        /// The <see cref="Status"/> value
        /// </param>
        /// <returns>
        /// the name of the enumeration literal
        /// </returns>
        public static string QueryXmiLiteral(this Status value)
        {
            return value switch
            {
                Status.Approved => "Approved",
                Status.Implemented => "Implemented",
                Status.Mandatory => "Mandatory",
                Status.Proposed => "Proposed",
                Status.Validated => "Validated",
                _ => throw new ArgumentOutOfRangeException(nameof(value), value, $"{value} is not a literal of Status")
            };
        }

        /// <summary>
        /// Tries to map the name of an enumeration literal as it appears in an XMI document (XMI 2.5.1 clause 9.5.2,
        /// rule 2i) to the <see cref="Status"/> value; the name must match the literal of the UML metamodel
        /// exactly, numeric values and other spellings are not literals
        /// </summary>
        /// <param name="literal">
        /// The name of the enumeration literal
        /// </param>
        /// <param name="value">
        /// The <see cref="Status"/> value, the default value when the literal is not known
        /// </param>
        /// <returns>
        /// true when the literal is a literal of <see cref="Status"/>, false otherwise
        /// </returns>
        public static bool TryParseXmiLiteral(string literal, out Status value)
        {
            switch (literal)
            {
                case "Approved":
                    value = Status.Approved;
                    return true;
                case "Implemented":
                    value = Status.Implemented;
                    return true;
                case "Mandatory":
                    value = Status.Mandatory;
                    return true;
                case "Proposed":
                    value = Status.Proposed;
                    return true;
                case "Validated":
                    value = Status.Validated;
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
