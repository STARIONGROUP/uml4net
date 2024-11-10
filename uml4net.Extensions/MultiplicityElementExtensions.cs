// -------------------------------------------------------------------------------------------------
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

namespace uml4net.Extensions
{
    using System;

    using uml4net.POCO.CommonStructure;
    using uml4net.POCO.Values;

    /// <summary>
    /// Extension methods for <see cref="IMultiplicityElement"/> interface
    /// </summary>
    public static class MultiplicityElementExtensions
    {
        /// <summary>
        /// Queries the upper value of the <paramref name="multiplicityElement"/>
        /// </summary>
        /// <param name="multiplicityElement">
        /// The <see cref="IMultiplicityElement"/> for which the lower value is queried
        /// </param>
        /// <returns>
        /// an integer
        /// </returns>
        public static string QueryUpperValue(this IMultiplicityElement multiplicityElement)
        {
            switch (multiplicityElement.UpperValue)
            {
                case null:
                    return "1";

                case ILiteralInteger literalInteger:

                    return literalInteger.Value.ToString();

                case ILiteralUnlimitedNatural unlimitedNatural:

                    if (!unlimitedNatural.Value.HasValue)
                    {
                        return "0";
                    }
                    else
                    {
                        if (unlimitedNatural.Value == int.MaxValue)
                        {
                            return "*";
                        }
                        else
                        {
                            return unlimitedNatural.Value.ToString();
                        }
                    }

                default:
                    throw new NotSupportedException("");
            }

        }
    }
}