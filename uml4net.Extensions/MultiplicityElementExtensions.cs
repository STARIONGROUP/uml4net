﻿// -------------------------------------------------------------------------------------------------
//  <copyright file="MultiplicityElementExtensions.cs" company="Starion Group S.A.">
// 
//    Copyright (C) 2019-2025 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
//  </copyright>
//  ------------------------------------------------------------------------------------------------

namespace uml4net.Extensions
{
    using System;
    using System.Globalization;
    using System.Linq;

    using uml4net.CommonStructure;
    using uml4net.Values;

    /// <summary>
    /// Extension methods for <see cref="IMultiplicityElement"/> interface
    /// </summary>
    public static class MultiplicityElementExtensions
    {
        /// <summary>
        /// Queries the upper value of the <paramref name="multiplicityElement"/>
        /// </summary>
        /// <param name="multiplicityElement">
        /// The <see cref="IMultiplicityElement"/> for which the upper value is queried
        /// </param>
        /// <returns>
        /// an instance of <see cref="ILiteralUnlimitedNatural"/> or null
        /// </returns>
        public static int QueryUpperValue(this IMultiplicityElement multiplicityElement)
        {
            if (multiplicityElement == null)
            {
                throw new ArgumentNullException(nameof(multiplicityElement));
            }

            switch (multiplicityElement.UpperValue.SingleOrDefault())
            {
                case null:
                    return 1;

                case ILiteralUnlimitedNatural literalUnlimitedNatural:

                    if (literalUnlimitedNatural.Value == "*")
                    {
                        return int.MaxValue;
                    }

                    return int.Parse(literalUnlimitedNatural.Value, CultureInfo.InvariantCulture);

                default:
                    throw new NotSupportedException("UpperValue is not of type ILiteralUnlimitedNatural.");
            }
        }
    }
}
