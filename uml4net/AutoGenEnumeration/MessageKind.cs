// -------------------------------------------------------------------------------------------------
// <copyright file="MessageKind.cs" company="Starion Group S.A.">
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

namespace uml4net.Interactions
{
    using System;

    /// <summary>
    /// This is an enumerated type that identifies the type of Message.
    /// </summary>
    public enum MessageKind
    {
        /// <summary>
        /// sendEvent and receiveEvent are present
        /// </summary>
        Complete,

        /// <summary>
        /// sendEvent present and receiveEvent absent
        /// </summary>
        Lost,

        /// <summary>
        /// sendEvent absent and receiveEvent present
        /// </summary>
        Found,

        /// <summary>
        /// sendEvent and receiveEvent absent (should not appear)
        /// </summary>
        Unknown
    }

    /// <summary>
    /// Extension methods for the <see cref="MessageKind"/> enumeration
    /// </summary>
    public static class MessageKindExtensions
    {
        /// <summary>
        /// Queries the name of the enumeration literal as defined in the UML metamodel, which is the value that
        /// represents the <paramref name="value"/> in an XMI document (XMI 2.5.1 clause 9.5.2, rule 2i)
        /// </summary>
        /// <param name="value">
        /// The <see cref="MessageKind"/> value
        /// </param>
        /// <returns>
        /// the name of the enumeration literal
        /// </returns>
        public static string QueryXmiLiteral(this MessageKind value)
        {
            return value switch
            {
                MessageKind.Complete => "complete",
                MessageKind.Lost => "lost",
                MessageKind.Found => "found",
                MessageKind.Unknown => "unknown",
                _ => throw new ArgumentOutOfRangeException(nameof(value), value, $"{value} is not a literal of MessageKind")
            };
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
