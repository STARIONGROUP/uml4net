// -------------------------------------------------------------------------------------------------
// <copyright file="ParameterEffectKind.cs" company="Starion Group S.A.">
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
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
