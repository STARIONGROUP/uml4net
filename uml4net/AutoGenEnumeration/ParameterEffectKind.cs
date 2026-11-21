// -------------------------------------------------------------------------------------------------
// <copyright file="ParameterEffectKind.cs" company="Starion Group S.A.">
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
    /// ParameterEffectKind is an Enumeration that indicates the effect of a Behavior on values passed in or
    /// out of its parameters.
    /// </summary>
    public enum ParameterEffectKind
    {
        /// <summary>
        /// Indicates that the behavior creates values.
        /// </summary>
        Create,

        /// <summary>
        /// Indicates objects that are values of the parameter have values of their properties, or links in
        /// which they participate, or their classifiers retrieved during executions of the behavior.
        /// </summary>
        Read,

        /// <summary>
        /// Indicates objects that are values of the parameter have values of their properties, or links in
        /// which they participate, or their classification changed during executions of the behavior.
        /// </summary>
        Update,

        /// <summary>
        /// Indicates objects that are values of the parameter do not exist after executions of the behavior are
        /// finished.
        /// </summary>
        Delete
    }

    /// <summary>
    /// Extension methods for the <see cref="ParameterEffectKind"/> enumeration
    /// </summary>
    public static class ParameterEffectKindExtensions
    {
        /// <summary>
        /// Queries the name of the enumeration literal as defined in the UML metamodel, which is the value that
        /// represents the <paramref name="value"/> in an XMI document (XMI 2.5.1 clause 9.5.2, rule 2i)
        /// </summary>
        /// <param name="value">
        /// The <see cref="ParameterEffectKind"/> value
        /// </param>
        /// <returns>
        /// the name of the enumeration literal
        /// </returns>
        public static string QueryXmiLiteral(this ParameterEffectKind value)
        {
            return value switch
            {
                ParameterEffectKind.Create => "create",
                ParameterEffectKind.Read => "read",
                ParameterEffectKind.Update => "update",
                ParameterEffectKind.Delete => "delete",
                _ => throw new ArgumentOutOfRangeException(nameof(value), value, $"{value} is not a literal of ParameterEffectKind")
            };
        }

        /// <summary>
        /// Tries to map the name of an enumeration literal as it appears in an XMI document (XMI 2.5.1 clause 9.5.2,
        /// rule 2i) to the <see cref="ParameterEffectKind"/> value; the name must match the literal of the UML metamodel
        /// exactly, numeric values and other spellings are not literals
        /// </summary>
        /// <param name="literal">
        /// The name of the enumeration literal
        /// </param>
        /// <param name="value">
        /// The <see cref="ParameterEffectKind"/> value, the default value when the literal is not known
        /// </param>
        /// <returns>
        /// true when the literal is a literal of <see cref="ParameterEffectKind"/>, false otherwise
        /// </returns>
        public static bool TryParseXmiLiteral(string literal, out ParameterEffectKind value)
        {
            switch (literal)
            {
                case "create":
                    value = ParameterEffectKind.Create;
                    return true;
                case "read":
                    value = ParameterEffectKind.Read;
                    return true;
                case "update":
                    value = ParameterEffectKind.Update;
                    return true;
                case "delete":
                    value = ParameterEffectKind.Delete;
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
