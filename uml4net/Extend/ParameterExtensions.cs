// -------------------------------------------------------------------------------------------------
// <copyright file="ParameterExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.Classification
{
    using System;
    using System.Globalization;
    using System.Linq;

    using uml4net.Values;

    /// <summary>
    /// The <see cref="ParameterExtensions"/> class provides extensions methods for <see cref="IParameter"/>
    /// </summary>
    internal static class ParameterExtensions
    {
        /// <summary>
        /// Queries A String that represents a value to be used when no argument is supplied for the Parameter.
        /// </summary>
        /// <param name="parameter">
        /// The subject <see cref="IParameter"/>
        /// </param>
        /// <returns>
        /// A String that represents a value to be used when no argument is supplied for the Parameter, or
        /// <c>null</c> if the Parameter has no <see cref="IParameter.DefaultValue"/> or its <see cref="IParameter.DefaultValue"/>
        /// is not an <see cref="ILiteralSpecification"/>.
        /// </returns>
        internal static string QueryDefault(this IParameter parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(nameof(parameter));
            }

            return parameter.DefaultValue.FirstOrDefault() switch
            {
                ILiteralBoolean literalBoolean => literalBoolean.Value.ToString(CultureInfo.InvariantCulture),
                ILiteralInteger literalInteger => literalInteger.Value.ToString(CultureInfo.InvariantCulture),
                ILiteralReal literalReal => literalReal.Value.ToString(CultureInfo.InvariantCulture),
                ILiteralString literalString => literalString.Value,
                ILiteralUnlimitedNatural literalUnlimitedNatural => literalUnlimitedNatural.Value,
                _ => null
            };
        }
    }
}
