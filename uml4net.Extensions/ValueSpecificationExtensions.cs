// -------------------------------------------------------------------------------------------------
//  <copyright file="ValueSpecificationExtensions.cs" company="Starion Group S.A.">
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
    using System.Globalization;
    using uml4net.Classification;
    using uml4net.Values;
    using uml4net.Utils;

    /// <summary>
    /// The <see cref="ValueSpecificationExtensions"/> class provides extensions methods for the <see cref="IValueSpecification"/>
    /// </summary>
    public static class ValueSpecificationExtensions
    {
        /// <summary>
        /// Queries the 
        /// </summary>
        /// <param name="valueSpecification"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public static string QueryDefaultValueAsString(this IValueSpecification valueSpecification)
        {
            Guard.ThrowIfNull(valueSpecification);

            switch (valueSpecification)
            {
                case ILiteralBoolean literalBoolean:
                    return literalBoolean.Value.ToString(CultureInfo.InvariantCulture).ToLower(CultureInfo.InvariantCulture);
                case ILiteralInteger literalInteger:
                    return literalInteger.Value.ToString(CultureInfo.InvariantCulture);
                case ILiteralNull:
                    return "null";
                case ILiteralString literalString:
                    return literalString.Value;
                case ILiteralUnlimitedNatural literalUnlimitedNatural:

                    if (literalUnlimitedNatural.Value == int.MaxValue)
                    {
                        return "int.MaxValue";
                    }
                    
                    return literalUnlimitedNatural.Value.ToString();
                case IInstanceValue instanceValue:
                    return instanceValue.Instance.Name;
                default:
                    throw new NotSupportedException($"The {valueSpecification.GetType()} is not supported");
            }

        }
    }
}
