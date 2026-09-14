// -------------------------------------------------------------------------------------------------
// <copyright file="CallConcurrencyKind.cs" company="Starion Group S.A.">
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
    /// CallConcurrencyKind is an Enumeration used to specify the semantics of concurrent calls to a
    /// BehavioralFeature.
    /// </summary>
    public enum CallConcurrencyKind
    {
        /// <summary>
        /// No concurrency management mechanism is associated with the BehavioralFeature and, therefore,
        /// concurrency conflicts may occur. Instances that invoke a BehavioralFeature need to coordinate so
        /// that only one invocation to a target on any BehavioralFeature occurs at once.
        /// </summary>
        Sequential,

        /// <summary>
        /// Multiple invocations of a BehavioralFeature that overlap in time may occur to one instance, but only
        /// one is allowed to commence. The others are blocked until the performance of the currently executing
        /// BehavioralFeature is complete. It is the responsibility of the system designer to ensure that
        /// deadlocks do not occur due to simultaneous blocking.
        /// </summary>
        Guarded,

        /// <summary>
        /// Multiple invocations of a BehavioralFeature that overlap in time may occur to one instance and all
        /// of them may proceed concurrently.
        /// </summary>
        Concurrent
    }

    /// <summary>
    /// Extension methods for the <see cref="CallConcurrencyKind"/> enumeration
    /// </summary>
    public static class CallConcurrencyKindExtensions
    {
        /// <summary>
        /// Queries the name of the enumeration literal as defined in the UML metamodel, which is the value that
        /// represents the <paramref name="value"/> in an XMI document (XMI 2.5.1 clause 9.5.2, rule 2i)
        /// </summary>
        /// <param name="value">
        /// The <see cref="CallConcurrencyKind"/> value
        /// </param>
        /// <returns>
        /// the name of the enumeration literal
        /// </returns>
        public static string QueryXmiLiteral(this CallConcurrencyKind value)
        {
            return value switch
            {
                CallConcurrencyKind.Sequential => "sequential",
                CallConcurrencyKind.Guarded => "guarded",
                CallConcurrencyKind.Concurrent => "concurrent",
                _ => throw new ArgumentOutOfRangeException(nameof(value), value, $"{value} is not a literal of CallConcurrencyKind")
            };
        }

        /// <summary>
        /// Tries to map the name of an enumeration literal as it appears in an XMI document (XMI 2.5.1 clause 9.5.2,
        /// rule 2i) to the <see cref="CallConcurrencyKind"/> value; the name must match the literal of the UML metamodel
        /// exactly, numeric values and other spellings are not literals
        /// </summary>
        /// <param name="literal">
        /// The name of the enumeration literal
        /// </param>
        /// <param name="value">
        /// The <see cref="CallConcurrencyKind"/> value, the default value when the literal is not known
        /// </param>
        /// <returns>
        /// true when the literal is a literal of <see cref="CallConcurrencyKind"/>, false otherwise
        /// </returns>
        public static bool TryParseXmiLiteral(string literal, out CallConcurrencyKind value)
        {
            switch (literal)
            {
                case "sequential":
                    value = CallConcurrencyKind.Sequential;
                    return true;
                case "guarded":
                    value = CallConcurrencyKind.Guarded;
                    return true;
                case "concurrent":
                    value = CallConcurrencyKind.Concurrent;
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
