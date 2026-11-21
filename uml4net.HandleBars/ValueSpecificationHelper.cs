// -------------------------------------------------------------------------------------------------
// <copyright file="ValueSpecificationHelper.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.HandleBars
{
    using System;

    using HandlebarsDotNet;

    using uml4net.Extensions;
    using uml4net.StructuredClassifiers;
    using uml4net.Values;

    /// <summary>
    /// A block helper that supports codegen for <see cref="IClass"/>
    /// </summary>
    public static class ValueSpecificationHelper
    {
        /// <summary>
        /// Registers the <see cref="ValueSpecificationHelper"/>
        /// </summary>
        /// <param name="handlebars">
        /// The <see cref="IHandlebars"/> context with which the helper needs to be registered
        /// </param>
        public static void RegisterValueSpecificationHelper(this IHandlebars handlebars)
        {
            // writes the language and body of an IValueSpecification
            handlebars.RegisterHelper("ValueSpecification.WriteLanguageAndBody", (writer, context, _) =>
            {
                if (!(context.Value is IValueSpecification valueSpecification))
                {
                    throw new ArgumentException("#ValueSpecification.WriteLanguageAndBody: supposed to be IValueSpecification");
                }

                var languageAndBody = valueSpecification.QueryLanguageAndBody();

                writer.WriteSafeString(languageAndBody);
            });
        }
    }
}
