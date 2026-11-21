// -------------------------------------------------------------------------------------------------
// <copyright file="BooleanHelper.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.HandleBars
{
    using System.Globalization;

    using HandlebarsDotNet;

    /// <summary>
    /// A block helper that supports operations on boolean data types
    /// </summary>
    public static class BooleanHelper
    {
        /// <summary>
        /// Registers the <see cref="BooleanHelper"/>
        /// </summary>
        /// <param name="handlebars">
        /// The <see cref="IHandlebars"/> context with which the helper needs to be registered
        /// </param>
        public static void RegisterBooleanHelper(this IHandlebars handlebars)
        {
            // writes the value of a Boolean to lower case
            handlebars.RegisterHelper("Boolean.ToLowerCase", (writer, _, parameters) =>
            {
                if (parameters.Length != 1)
                {
                    throw new HandlebarsException("{{#Boolean.ToLowerCase}} helper must have exactly one argument");
                }

                var value = (bool)parameters[0];

                writer.WriteSafeString(value.ToString(CultureInfo.InvariantCulture).ToLowerInvariant());
            });
        }
    }
}
