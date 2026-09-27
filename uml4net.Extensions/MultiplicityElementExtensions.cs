// -------------------------------------------------------------------------------------------------
// <copyright file="MultiplicityElementExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.Extensions
{
    using System;
    using System.Globalization;
    using System.Linq;

    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.Values;

    /// <summary>
    /// Extension methods for <see cref="IMultiplicityElement"/> interface
    /// </summary>
    public static class MultiplicityElementExtensions
    {
        /// <summary>
        /// Queries the upper bound of the <paramref name="multiplicityElement"/> as an integer
        /// </summary>
        /// <param name="multiplicityElement">
        /// The <see cref="IMultiplicityElement"/> for which the upper value is queried
        /// </param>
        /// <returns>
        /// the upper bound, <see cref="int.MaxValue"/> when it is unlimited
        /// </returns>
        /// <remarks>
        /// Follows <c>MultiplicityElement::upperBound()</c>: <c>if (upperValue=null or upperValue.unlimitedValue()=null)
        /// then 1 else upperValue.unlimitedValue() endif</c>. As a tolerance for tool exports, an upper value written as
        /// a <see cref="ILiteralInteger"/> is accepted, and <c>-1</c> denotes an unlimited upper bound. Any other
        /// ValueSpecification, such as an OpaqueExpression whose value cannot be computed, yields 1.
        /// </remarks>
        public static int QueryUpperValue(this IMultiplicityElement multiplicityElement)
        {
            if (multiplicityElement == null)
            {
                throw new ArgumentNullException(nameof(multiplicityElement));
            }

            switch (multiplicityElement.UpperValue.SingleOrDefault())
            {
                case ILiteralUnlimitedNatural { Value: "*" }:
                    return int.MaxValue;

                case ILiteralUnlimitedNatural literalUnlimitedNatural when int.TryParse(literalUnlimitedNatural.Value, NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out var value):
                    return QueryUpperBound(value);

                case ILiteralInteger literalInteger:
                    return QueryUpperBound(literalInteger.Value);

                default:
                    return 1;
            }
        }

        /// <summary>
        /// Queries the upper bound that a numeric upper value denotes
        /// </summary>
        /// <param name="value">
        /// The numeric upper value
        /// </param>
        /// <returns>
        /// <see cref="int.MaxValue"/> for <c>-1</c>, the tool convention for an unlimited upper bound; the
        /// <paramref name="value"/> when it is not negative; 1 otherwise, since a negative value is no unlimited natural
        /// </returns>
        private static int QueryUpperBound(int value)
        {
            return value switch
            {
                -1 => int.MaxValue,
                >= 0 => value,
                _ => 1
            };
        }

        /// <summary>
        /// Queries whether the <see cref="IMultiplicityElement"/> is Enumerable
        /// </summary>
        /// <param name="multiplicityElement">
        /// The subject <see cref="IStructuralFeature"/>
        /// </param>
        /// <returns>
        /// true when the upper bound, as queried by <see cref="QueryUpperValue"/>, is greater than 1
        /// </returns>
        public static bool QueryIsEnumerable(this IMultiplicityElement multiplicityElement)
        {
            if (multiplicityElement == null)
            {
                throw new ArgumentNullException(nameof(multiplicityElement));
            }

            return multiplicityElement.QueryUpperValue() > 1;
        }
        
        /// <summary>
        /// Queries whether the <see cref="IMultiplicityElement"/> is nullable
        /// </summary>
        /// <param name="multiplicityElement">
        /// The subject <see cref="IMultiplicityElement"/>
        /// </param>
        /// <returns>
        /// true if IMultiplicityElement.Lower = 0, false if not
        /// </returns>
        public static bool QueryIsNullable(this IMultiplicityElement multiplicityElement)
        {
            if (multiplicityElement == null)
            {
                throw new ArgumentNullException(nameof(multiplicityElement));
            }

            return multiplicityElement.Lower == 0 && !multiplicityElement.QueryIsEnumerable();
        }
        
        /// <summary>
        /// Queries whether the <see cref="IMultiplicityElement"/> is a scalar
        /// </summary>
        /// <param name="multiplicityElement">
        /// The subject <see cref="IMultiplicityElement"/>
        /// </param>
        /// <returns>
        /// true if <see cref="IMultiplicityElement.Lower"/> and <see cref="IMultiplicityElement.Upper"/> = 1, false if not
        /// </returns>
        public static bool QueryIsScalar(this IMultiplicityElement multiplicityElement)
        {
            return multiplicityElement.Lower == 1 && multiplicityElement.Upper == "1";
        }
        
        /// <summary>
        /// Returns the UML multiplicity of the specified <see cref="IMultiplicityElement"/>
        /// formatted using standard bracket notation.
        /// </summary>
        /// <param name="multiplicityElement">
        /// The <see cref="IMultiplicityElement"/> for which the multiplicity is queried.
        /// </param>
        /// <returns>
        /// A string representation of the multiplicity in the form
        /// <c>[lower..upper]</c>, where <c>lower</c> and <c>upper</c> correspond
        /// to the property's lower and upper bounds.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="multiplicityElement"/> is <see langword="null"/>.
        /// </exception>
        /// <remarks>
        /// <para>
        /// The method performs no validation of the bounds and assumes that
        /// <see cref="IMultiplicityElement.Lower"/> and <see cref="IMultiplicityElement.Upper"/> already
        /// reflect valid UML multiplicity values.
        /// </para>
        /// <para>
        /// This is a formatting helper intended for documentation, diagnostics,
        /// and code-generation scenarios.
        /// </para>
        /// </remarks>
        public static string QueryFormattedMultiplicity(this IMultiplicityElement multiplicityElement)
        {
            if (multiplicityElement == null)
            {
                throw new ArgumentNullException(nameof(multiplicityElement));
            }

            return $"[{multiplicityElement.Lower}..{multiplicityElement.Upper}]";
        }
    }
}
