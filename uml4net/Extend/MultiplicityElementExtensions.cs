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

namespace uml4net.CommonStructure
{
    using System;
    using System.Globalization;
    using System.Linq;

    using uml4net.Values;

    /// <summary>
    /// The <see cref="MultiplicityElementExtensions"/> class provides extensions methods for <see cref="IMultiplicityElement"/>
    /// </summary>
    internal static class MultiplicityElementExtensions
    {
        /// <summary>
        /// Queries the lower value of the <paramref name="multiplicityElement"/>
        /// </summary>
        /// <param name="multiplicityElement">
        /// The <see cref="IMultiplicityElement"/> for which the lower value is queried
        /// </param>
        /// <returns>
        /// an integer
        /// </returns>
        internal static int QueryLower(this IMultiplicityElement multiplicityElement)
        {
            if (multiplicityElement == null)
            {
                throw new ArgumentNullException(nameof(multiplicityElement));
            }

            // lowerBound(): if (lowerValue = null or lowerValue.integerValue() = null) then 1 else lowerValue.integerValue()
            return TryQueryIntegerValue(multiplicityElement.LowerValue.SingleOrDefault(), out var lower) ? lower : 1;
        }

        /// <summary>
        /// Tries to query the integer value of a <see cref="IValueSpecification"/> as defined by the operation
        /// <c>ValueSpecification::integerValue</c>, which is null for everything but a <see cref="ILiteralInteger"/>
        /// </summary>
        /// <param name="valueSpecification">
        /// The <see cref="IValueSpecification"/>, may be null
        /// </param>
        /// <param name="value">
        /// The integer value when there is one
        /// </param>
        /// <returns>
        /// true for a <see cref="ILiteralInteger"/> and, as a tolerance for tool exports, for a
        /// <see cref="ILiteralUnlimitedNatural"/> whose value is a number; false otherwise, for example for an
        /// OpaqueExpression, an Expression or an InstanceValue, whose value cannot be computed
        /// </returns>
        internal static bool TryQueryIntegerValue(IValueSpecification valueSpecification, out int value)
        {
            switch (valueSpecification)
            {
                case ILiteralInteger literalInteger:
                    value = literalInteger.Value;
                    return true;

                case ILiteralUnlimitedNatural literalUnlimitedNatural:
                    return int.TryParse(literalUnlimitedNatural.Value, NumberStyles.None, CultureInfo.InvariantCulture, out value);

                default:
                    value = 0;
                    return false;
            }
        }

        /// <summary>
        /// Tries to query the unlimited natural value of a <see cref="IValueSpecification"/> as defined by the
        /// operation <c>ValueSpecification::unlimitedValue</c>, which is null for everything but a
        /// <see cref="ILiteralUnlimitedNatural"/>
        /// </summary>
        /// <param name="valueSpecification">
        /// The <see cref="IValueSpecification"/>, may be null
        /// </param>
        /// <param name="value">
        /// The unlimited natural value, a number or <c>*</c>, when there is one
        /// </param>
        /// <returns>
        /// true for a <see cref="ILiteralUnlimitedNatural"/> and, as a tolerance for tool exports that
        /// write an upper bound as a LiteralInteger, for a non-negative <see cref="ILiteralInteger"/>; false otherwise
        /// </returns>
        internal static bool TryQueryUnlimitedValue(IValueSpecification valueSpecification, out string value)
        {
            switch (valueSpecification)
            {
                case ILiteralUnlimitedNatural literalUnlimitedNatural:
                    value = literalUnlimitedNatural.Value;
                    return true;

                case ILiteralInteger literalInteger when literalInteger.Value >= 0:
                    value = literalInteger.Value.ToString(CultureInfo.InvariantCulture);
                    return true;

                default:
                    value = null;
                    return false;
            }
        }

        /// <summary>
        /// Queries the upper value of the <paramref name="multiplicityElement"/>
        /// </summary>
        /// <param name="multiplicityElement">
        /// The <see cref="IMultiplicityElement"/> for which the upper value is queried
        /// </param>
        /// <returns>
        /// an instance of <see cref="ILiteralUnlimitedNatural"/> or null
        /// </returns>
        internal static string QueryUpper(this IMultiplicityElement multiplicityElement)
        {
            if (multiplicityElement == null)
            {
                throw new ArgumentNullException(nameof(multiplicityElement));
            }

            // upperBound(): if (upperValue = null or upperValue.unlimitedValue() = null) then 1 else upperValue.unlimitedValue()
            return TryQueryUnlimitedValue(multiplicityElement.UpperValue.SingleOrDefault(), out var upper) ? upper : "1";
        }
    }
}
