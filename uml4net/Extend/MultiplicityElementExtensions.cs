﻿// -------------------------------------------------------------------------------------------------
// <copyright file="MultiplicityElementExtensions.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2025 Starion Group S.A.
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

            switch (multiplicityElement.LowerValue.SingleOrDefault())
            {
                case null:
                    return 1;

                case ILiteralInteger literalInteger:
                    return literalInteger.Value;

                default:
                    throw new NotSupportedException("LowerValue is not of type ILiteralInteger.");
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

            switch (multiplicityElement.UpperValue.SingleOrDefault())
            {
                case null:
                    return "1";

                case ILiteralUnlimitedNatural literalUnlimitedNatural:

                    return literalUnlimitedNatural.Value;
                    
                default:
                    throw new NotSupportedException("UpperValue is not of type ILiteralUnlimitedNatural.");
            }
        }
    }
}
