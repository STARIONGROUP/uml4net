// -------------------------------------------------------------------------------------------------
//  <copyright file="EnumHelper.cs" company="Starion Group S.A.">
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

namespace uml4net.HandleBars
{
    using HandlebarsDotNet;
    using System;
    using System.Globalization;

    /// <summary>
    /// A enum helper
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Converts the enum value to a string
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enumValue">
        /// the enumeration literal
        /// </param>
        /// <returns>
        /// The string value of the enu,
        /// </returns>
        public static string EnumToString<TEnum>(TEnum enumValue) where TEnum : Enum
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("TEnum must be an enum type");
            }

            return enumValue.ToString();
        }

        /// <summary>
        /// Registers the <see cref="string"/>
        /// </summary>
        /// <param name="handlebars">
        /// The <see cref="IHandlebars"/> context with which the helper needs to be registered
        /// </param>
        public static void RegisterEnumHelper(this IHandlebars handlebars)
        {
            handlebars.RegisterHelper("Enum.ToString", (writer, context, parameters) =>
            {
                if (parameters.Length != 1)
                {
                    throw new HandlebarsException("{{#Enum.ToString}} helper must have exactly one argument");
                }

                if (parameters[0] is Enum enumValue)
                {
                    var value = enumValue.ToString().ToLower(CultureInfo.InvariantCulture);

                    writer.WriteSafeString(value);
                }
                else
                {
                    throw new HandlebarsException("{{Enum.ToString}} helper argument must be an Enum");
                }
            });
        }
    }
}
