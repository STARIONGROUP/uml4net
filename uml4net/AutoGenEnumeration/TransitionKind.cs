// -------------------------------------------------------------------------------------------------
// <copyright file="TransitionKind.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace uml4net.StateMachines
{
    using System;

    /// <summary>
    /// TransitionKind is an Enumeration type used to differentiate the various kinds of Transitions.
    /// </summary>
    public enum TransitionKind
    {
        /// <summary>
        /// Implies that the Transition, if triggered, occurs without exiting or entering the source State
        /// (i.e., it does not cause a state change). This means that the entry or exit condition of the source
        /// State will not be invoked. An internal Transition can be taken even if the SateMachine is in one or
        /// more Regions nested within the associated State.
        /// </summary>
        Internal,

        /// <summary>
        /// Implies that the Transition, if triggered, will not exit the composite (source) State, but it will
        /// exit and re-enter any state within the composite State that is in the current state configuration.
        /// </summary>
        Local,

        /// <summary>
        /// Implies that the Transition, if triggered, will exit the composite (source) State.
        /// </summary>
        External
    }

    /// <summary>
    /// Extension methods for the <see cref="TransitionKind"/> enumeration
    /// </summary>
    public static class TransitionKindExtensions
    {
        /// <summary>
        /// Queries the name of the enumeration literal as defined in the UML metamodel, which is the value that
        /// represents the <paramref name="value"/> in an XMI document (XMI 2.5.1 clause 9.5.2, rule 2i)
        /// </summary>
        /// <param name="value">
        /// The <see cref="TransitionKind"/> value
        /// </param>
        /// <returns>
        /// the name of the enumeration literal
        /// </returns>
        public static string QueryXmiLiteral(this TransitionKind value)
        {
            return value switch
            {
                TransitionKind.Internal => "internal",
                TransitionKind.Local => "local",
                TransitionKind.External => "external",
                _ => throw new ArgumentOutOfRangeException(nameof(value), value, $"{value} is not a literal of TransitionKind")
            };
        }

        /// <summary>
        /// Tries to map the name of an enumeration literal as it appears in an XMI document (XMI 2.5.1 clause 9.5.2,
        /// rule 2i) to the <see cref="TransitionKind"/> value; the name must match the literal of the UML metamodel
        /// exactly, numeric values and other spellings are not literals
        /// </summary>
        /// <param name="literal">
        /// The name of the enumeration literal
        /// </param>
        /// <param name="value">
        /// The <see cref="TransitionKind"/> value, the default value when the literal is not known
        /// </param>
        /// <returns>
        /// true when the literal is a literal of <see cref="TransitionKind"/>, false otherwise
        /// </returns>
        public static bool TryParseXmiLiteral(string literal, out TransitionKind value)
        {
            switch (literal)
            {
                case "internal":
                    value = TransitionKind.Internal;
                    return true;
                case "local":
                    value = TransitionKind.Local;
                    return true;
                case "external":
                    value = TransitionKind.External;
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
