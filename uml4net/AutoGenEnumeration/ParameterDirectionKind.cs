// -------------------------------------------------------------------------------------------------
// <copyright file="ParameterDirectionKind.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
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
    /// ParameterDirectionKind is an Enumeration that defines literals used to specify direction of
    /// parameters.
    /// </summary>
    public enum ParameterDirectionKind
    {
        /// <summary>
        /// Indicates that Parameter values are passed in by the caller.
        /// </summary>
        In,

        /// <summary>
        /// Indicates that Parameter values are passed in by the caller and (possibly different) values passed
        /// out to the caller.
        /// </summary>
        Inout,

        /// <summary>
        /// Indicates that Parameter values are passed out to the caller.
        /// </summary>
        Out,

        /// <summary>
        /// Indicates that Parameter values are passed as return values back to the caller.
        /// </summary>
        Return
    }

    /// <summary>
    /// Extension methods for the <see cref="ParameterDirectionKind"/> enumeration
    /// </summary>
    public static class ParameterDirectionKindExtensions
    {
        /// <summary>
        /// Queries the name of the enumeration literal as defined in the UML metamodel, which is the value that
        /// represents the <paramref name="value"/> in an XMI document (XMI 2.5.1 clause 9.5.2, rule 2i)
        /// </summary>
        /// <param name="value">
        /// The <see cref="ParameterDirectionKind"/> value
        /// </param>
        /// <returns>
        /// the name of the enumeration literal
        /// </returns>
        public static string QueryXmiLiteral(this ParameterDirectionKind value)
        {
            return value switch
            {
                ParameterDirectionKind.In => "in",
                ParameterDirectionKind.Inout => "inout",
                ParameterDirectionKind.Out => "out",
                ParameterDirectionKind.Return => "return",
                _ => throw new ArgumentOutOfRangeException(nameof(value), value, $"{value} is not a literal of ParameterDirectionKind")
            };
        }

        /// <summary>
        /// Tries to map the name of an enumeration literal as it appears in an XMI document (XMI 2.5.1 clause 9.5.2,
        /// rule 2i) to the <see cref="ParameterDirectionKind"/> value; the name must match the literal of the UML metamodel
        /// exactly, numeric values and other spellings are not literals
        /// </summary>
        /// <param name="literal">
        /// The name of the enumeration literal
        /// </param>
        /// <param name="value">
        /// The <see cref="ParameterDirectionKind"/> value, the default value when the literal is not known
        /// </param>
        /// <returns>
        /// true when the literal is a literal of <see cref="ParameterDirectionKind"/>, false otherwise
        /// </returns>
        public static bool TryParseXmiLiteral(string literal, out ParameterDirectionKind value)
        {
            switch (literal)
            {
                case "in":
                    value = ParameterDirectionKind.In;
                    return true;
                case "inout":
                    value = ParameterDirectionKind.Inout;
                    return true;
                case "out":
                    value = ParameterDirectionKind.Out;
                    return true;
                case "return":
                    value = ParameterDirectionKind.Return;
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
