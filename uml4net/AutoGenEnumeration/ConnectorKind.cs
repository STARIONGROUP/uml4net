// -------------------------------------------------------------------------------------------------
// <copyright file="ConnectorKind.cs" company="Starion Group S.A.">
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

namespace uml4net.StructuredClassifiers
{
    using System;

    /// <summary>
    /// ConnectorKind is an enumeration that defines whether a Connector is an assembly or a delegation.
    /// </summary>
    public enum ConnectorKind
    {
        /// <summary>
        /// Indicates that the Connector is an assembly Connector.
        /// </summary>
        Assembly,

        /// <summary>
        /// Indicates that the Connector is a delegation Connector.
        /// </summary>
        Delegation
    }

    /// <summary>
    /// Extension methods for the <see cref="ConnectorKind"/> enumeration
    /// </summary>
    public static class ConnectorKindExtensions
    {
        /// <summary>
        /// Queries the name of the enumeration literal as defined in the UML metamodel, which is the value that
        /// represents the <paramref name="value"/> in an XMI document (XMI 2.5.1 clause 9.5.2, rule 2i)
        /// </summary>
        /// <param name="value">
        /// The <see cref="ConnectorKind"/> value
        /// </param>
        /// <returns>
        /// the name of the enumeration literal
        /// </returns>
        public static string QueryXmiLiteral(this ConnectorKind value)
        {
            return value switch
            {
                ConnectorKind.Assembly => "assembly",
                ConnectorKind.Delegation => "delegation",
                _ => throw new ArgumentOutOfRangeException(nameof(value), value, $"{value} is not a literal of ConnectorKind")
            };
        }

        /// <summary>
        /// Tries to map the name of an enumeration literal as it appears in an XMI document (XMI 2.5.1 clause 9.5.2,
        /// rule 2i) to the <see cref="ConnectorKind"/> value; the name must match the literal of the UML metamodel
        /// exactly, numeric values and other spellings are not literals
        /// </summary>
        /// <param name="literal">
        /// The name of the enumeration literal
        /// </param>
        /// <param name="value">
        /// The <see cref="ConnectorKind"/> value, the default value when the literal is not known
        /// </param>
        /// <returns>
        /// true when the literal is a literal of <see cref="ConnectorKind"/>, false otherwise
        /// </returns>
        public static bool TryParseXmiLiteral(string literal, out ConnectorKind value)
        {
            switch (literal)
            {
                case "assembly":
                    value = ConnectorKind.Assembly;
                    return true;
                case "delegation":
                    value = ConnectorKind.Delegation;
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
