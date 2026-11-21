// -------------------------------------------------------------------------------------------------
// <copyright file="EnumHelper.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.HandleBars
{
    using System;
    using System.Globalization;
    using System.Linq;

    using HandlebarsDotNet;

    using uml4net.SimpleClassifiers;

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
            handlebars.RegisterHelper("Enum.ToString", (writer, _, parameters) =>
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

            // Writes the number of characters of the longest literal name of an Enumeration, 0 for an Enumeration
            // without named literals
            handlebars.RegisterHelper("Enumeration.WriteLengthLongestLiteral", (writer, _, parameters) =>
            {
                if (parameters.Length != 1)
                {
                    throw new HandlebarsException("{{#Enumeration.WriteLengthLongestLiteral}} helper must have exactly one argument");
                }

                if (!(parameters[0] is IEnumeration enumeration))
                {
                    throw new HandlebarsException("{{#Enumeration.WriteLengthLongestLiteral}} helper argument must be an Enumeration");
                }

                var length = enumeration.OwnedLiteral
                    .Where(x => !string.IsNullOrEmpty(x.Name))
                    .Select(x => x.Name.Length)
                    .DefaultIfEmpty(0)
                    .Max();

                writer.WriteSafeString(length.ToString(CultureInfo.InvariantCulture));
            });
        }
    }
}
