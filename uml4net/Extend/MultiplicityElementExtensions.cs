﻿// -------------------------------------------------------------------------------------------------
//  <copyright file="MultiplicityElementExtensions.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2024 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, softwareUseCases
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
//  </copyright>
//  ------------------------------------------------------------------------------------------------

namespace uml4net.Extend
{
    using System;
    using POCO.Values;

    using uml4net.POCO.CommonStructure;

    /// <summary>
    /// Extension methods for <see cref="IMultiplicityElement"/> interface
    /// </summary>
    public static class MultiplicityElementExtensions
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
        public static int QueryLower(this IMultiplicityElement multiplicityElement)
        {
            switch (multiplicityElement.LowerValue)
            {
                case null:
                    return 0;

                case ILiteralInteger literalInteger:
                    return literalInteger.Value;

                default:
                    throw new NotSupportedException("");
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
        public static ILiteralUnlimitedNatural QueryUpper(this IMultiplicityElement multiplicityElement)
        {
            switch (multiplicityElement.UpperValue)
            {
                case null:
                    return null;

                case ILiteralUnlimitedNatural literalUnlimitedNatural:
                    return literalUnlimitedNatural;

                default:
                    throw new NotSupportedException("UpperValue is not of type ILiteralUnlimitedNatural.");
            }

        }
    }
}