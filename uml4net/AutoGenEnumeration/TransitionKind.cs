// -------------------------------------------------------------------------------------------------
// <copyright file="TransitionKind.cs" company="Starion Group S.A.">
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
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
