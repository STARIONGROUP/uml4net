// -------------------------------------------------------------------------------------------------
// <copyright file="StringHelper.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.HandleBars
{
    using HandlebarsDotNet;

    using uml4net.Extensions;

    /// <summary>
    /// A block helper that prints the name of the type of <see cref="string"/>
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// Registers the <see cref="string"/>
        /// </summary>
        /// <param name="handlebars">
        /// The <see cref="IHandlebars"/> context with which the helper needs to be registered
        /// </param>
        public static void RegisterStringHelper(this IHandlebars handlebars)
        {
            handlebars.RegisterHelper("String.CapitalizeFirstLetter", (writer, _, parameters) =>
            {
                if (parameters.Length != 1)
                {
                    throw new HandlebarsException("{{#String.CapitalizeFirstLetter}} helper must have exactly one argument");
                }

                var value = parameters[0] as string;

                writer.WriteSafeString(value.CapitalizeFirstLetter());
            });

            handlebars.RegisterHelper("String.LowerCaseFirstLetter", (writer, _, parameters) =>
            {
                if (parameters.Length != 1)
                {
                    throw new HandlebarsException("{{#String.LowerCaseFirstLetter}} helper must have exactly one argument");
                }

                var value = parameters[0] as string;

                writer.WriteSafeString(value.LowerCaseFirstLetter());
            });

            handlebars.RegisterHelper("String.Length", (writer, _, parameters) =>
            {
                if (parameters.Length != 1)
                {
                    throw new HandlebarsException("{{#String.Length}} helper must have exactly one argument");
                }

                var value = parameters[0] as string;

                writer.WriteSafeString(value.Length);
            });

            // Writes the string, prefixed with @ when it is a reserved keyword of C#
            handlebars.RegisterHelper("String.EscapeCSharpKeyword", (writer, _, parameters) =>
            {
                if (parameters.Length != 1)
                {
                    throw new HandlebarsException("{{#String.EscapeCSharpKeyword}} helper must have exactly one argument");
                }

                if (!(parameters[0] is string value))
                {
                    throw new HandlebarsException("{{#String.EscapeCSharpKeyword}} helper argument must be a string");
                }

                writer.WriteSafeString(value.EscapeCSharpKeyword());
            });
        }
    }
}
