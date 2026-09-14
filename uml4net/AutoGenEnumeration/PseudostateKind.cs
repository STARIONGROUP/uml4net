// -------------------------------------------------------------------------------------------------
// <copyright file="PseudostateKind.cs" company="Starion Group S.A.">
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

namespace uml4net.StateMachines
{
    using System;

    /// <summary>
    /// PseudostateKind is an Enumeration type that is used to differentiate various kinds of Pseudostates.
    /// </summary>
    public enum PseudostateKind
    {
        /// <summary>
        /// </summary>
        Initial,

        /// <summary>
        /// </summary>
        DeepHistory,

        /// <summary>
        /// </summary>
        ShallowHistory,

        /// <summary>
        /// </summary>
        Join,

        /// <summary>
        /// </summary>
        Fork,

        /// <summary>
        /// </summary>
        Junction,

        /// <summary>
        /// </summary>
        Choice,

        /// <summary>
        /// </summary>
        EntryPoint,

        /// <summary>
        /// </summary>
        ExitPoint,

        /// <summary>
        /// </summary>
        Terminate
    }

    /// <summary>
    /// Extension methods for the <see cref="PseudostateKind"/> enumeration
    /// </summary>
    public static class PseudostateKindExtensions
    {
        /// <summary>
        /// Queries the name of the enumeration literal as defined in the UML metamodel, which is the value that
        /// represents the <paramref name="value"/> in an XMI document (XMI 2.5.1 clause 9.5.2, rule 2i)
        /// </summary>
        /// <param name="value">
        /// The <see cref="PseudostateKind"/> value
        /// </param>
        /// <returns>
        /// the name of the enumeration literal
        /// </returns>
        public static string QueryXmiLiteral(this PseudostateKind value)
        {
            return value switch
            {
                PseudostateKind.Initial => "initial",
                PseudostateKind.DeepHistory => "deepHistory",
                PseudostateKind.ShallowHistory => "shallowHistory",
                PseudostateKind.Join => "join",
                PseudostateKind.Fork => "fork",
                PseudostateKind.Junction => "junction",
                PseudostateKind.Choice => "choice",
                PseudostateKind.EntryPoint => "entryPoint",
                PseudostateKind.ExitPoint => "exitPoint",
                PseudostateKind.Terminate => "terminate",
                _ => throw new ArgumentOutOfRangeException(nameof(value), value, $"{value} is not a literal of PseudostateKind")
            };
        }

        /// <summary>
        /// Tries to map the name of an enumeration literal as it appears in an XMI document (XMI 2.5.1 clause 9.5.2,
        /// rule 2i) to the <see cref="PseudostateKind"/> value; the name must match the literal of the UML metamodel
        /// exactly, numeric values and other spellings are not literals
        /// </summary>
        /// <param name="literal">
        /// The name of the enumeration literal
        /// </param>
        /// <param name="value">
        /// The <see cref="PseudostateKind"/> value, the default value when the literal is not known
        /// </param>
        /// <returns>
        /// true when the literal is a literal of <see cref="PseudostateKind"/>, false otherwise
        /// </returns>
        public static bool TryParseXmiLiteral(string literal, out PseudostateKind value)
        {
            switch (literal)
            {
                case "initial":
                    value = PseudostateKind.Initial;
                    return true;
                case "deepHistory":
                    value = PseudostateKind.DeepHistory;
                    return true;
                case "shallowHistory":
                    value = PseudostateKind.ShallowHistory;
                    return true;
                case "join":
                    value = PseudostateKind.Join;
                    return true;
                case "fork":
                    value = PseudostateKind.Fork;
                    return true;
                case "junction":
                    value = PseudostateKind.Junction;
                    return true;
                case "choice":
                    value = PseudostateKind.Choice;
                    return true;
                case "entryPoint":
                    value = PseudostateKind.EntryPoint;
                    return true;
                case "exitPoint":
                    value = PseudostateKind.ExitPoint;
                    return true;
                case "terminate":
                    value = PseudostateKind.Terminate;
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
