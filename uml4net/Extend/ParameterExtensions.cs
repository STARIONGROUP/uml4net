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
    using System.Linq;

    using uml4net.SimpleClassifiers;
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
        /// A String that represents a value to be used when no argument is supplied for the Parameter. Per the
        /// OCL body of the <c>Parameter::default()</c> derivation operation (<c>result = (if self.type = String
        /// then defaultValue.stringValue() else null endif)</c>), this is only non-null when the Parameter's own
        /// <see cref="IParameter.Type"/> is the primitive type <c>String</c>; for every other <see cref="IParameter.Type"/>
        /// this is <c>null</c>, regardless of what <see cref="IParameter.DefaultValue"/> is set to.
        /// </returns>
        internal static string QueryDefault(this IParameter parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(nameof(parameter));
            }

            if (parameter.Type is not IPrimitiveType primitiveType || primitiveType.Name != "String")
            {
                return null;
            }

            return parameter.DefaultValue.FirstOrDefault().QueryStringValue();
        }

        /// <summary>
        /// Queries the <c>ValueSpecification::stringValue()</c> of the <paramref name="valueSpecification"/>. Per the
        /// UML 2.5.1 metamodel, this base operation is <c>null</c> for every kind of <see cref="IValueSpecification"/>
        /// except <see cref="ILiteralString"/> (its own value) and <see cref="IStringExpression"/> (the concatenation
        /// of its sub-expressions, or its operands when it has none).
        /// </summary>
        /// <param name="valueSpecification">
        /// The <see cref="IValueSpecification"/> for which the string value is queried, or <c>null</c>.
        /// </param>
        /// <returns>
        /// The string value of the <paramref name="valueSpecification"/>, or <c>null</c>.
        /// </returns>
        private static string QueryStringValue(this IValueSpecification valueSpecification)
        {
            switch (valueSpecification)
            {
                case null:
                    return null;
                case ILiteralString literalString:
                    return literalString.Value;
                case IStringExpression stringExpression when stringExpression.SubExpression.Count > 0:
                    return string.Concat(stringExpression.SubExpression.Select(x => x.QueryStringValue()));
                case IStringExpression stringExpression:
                    return string.Concat(stringExpression.Operand.Select(x => x.QueryStringValue()));
                default:
                    return null;
            }
        }
    }
}
