// -------------------------------------------------------------------------------------------------
// <copyright file="ConstraintStatus.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Extensions.EnterpriseArchitect.Structure
{
    using System;

    /// <summary>
    /// </summary>
    public enum ConstraintStatus
    {
        /// <summary>
        /// </summary>
        Build,

        /// <summary>
        /// </summary>
        Validated,

        /// <summary>
        /// </summary>
        Proposed,

        /// <summary>
        /// </summary>
        Approved,

        /// <summary>
        /// </summary>
        Mandatory,

        /// <summary>
        /// </summary>
        Implemented
    }

    /// <summary>
    /// Extension methods for the <see cref="ConstraintStatus"/> enumeration
    /// </summary>
    public static class ConstraintStatusExtensions
    {
        /// <summary>
        /// Queries the name of the enumeration literal as defined in the UML metamodel, which is the value that
        /// represents the <paramref name="value"/> in an XMI document (XMI 2.5.1 clause 9.5.2, rule 2i)
        /// </summary>
        /// <param name="value">
        /// The <see cref="ConstraintStatus"/> value
        /// </param>
        /// <returns>
        /// the name of the enumeration literal
        /// </returns>
        public static string QueryXmiLiteral(this ConstraintStatus value)
        {
            return value switch
            {
                ConstraintStatus.Build => "Build",
                ConstraintStatus.Validated => "Validated",
                ConstraintStatus.Proposed => "Proposed",
                ConstraintStatus.Approved => "Approved",
                ConstraintStatus.Mandatory => "Mandatory",
                ConstraintStatus.Implemented => "Implemented",
                _ => throw new ArgumentOutOfRangeException(nameof(value), value, $"{value} is not a literal of ConstraintStatus")
            };
        }

        /// <summary>
        /// Tries to map the name of an enumeration literal as it appears in an XMI document (XMI 2.5.1 clause 9.5.2,
        /// rule 2i) to the <see cref="ConstraintStatus"/> value; the name must match the literal of the UML metamodel
        /// exactly, numeric values and other spellings are not literals
        /// </summary>
        /// <param name="literal">
        /// The name of the enumeration literal
        /// </param>
        /// <param name="value">
        /// The <see cref="ConstraintStatus"/> value, the default value when the literal is not known
        /// </param>
        /// <returns>
        /// true when the literal is a literal of <see cref="ConstraintStatus"/>, false otherwise
        /// </returns>
        public static bool TryParseXmiLiteral(string literal, out ConstraintStatus value)
        {
            switch (literal)
            {
                case "Build":
                    value = ConstraintStatus.Build;
                    return true;
                case "Validated":
                    value = ConstraintStatus.Validated;
                    return true;
                case "Proposed":
                    value = ConstraintStatus.Proposed;
                    return true;
                case "Approved":
                    value = ConstraintStatus.Approved;
                    return true;
                case "Mandatory":
                    value = ConstraintStatus.Mandatory;
                    return true;
                case "Implemented":
                    value = ConstraintStatus.Implemented;
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
