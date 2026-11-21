// -------------------------------------------------------------------------------------------------
// <copyright file="NamedElementHelper.cs" company="Starion Group S.A.">
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
    using System.IO;
    using System.Linq;
    using System.Text;

    using HandlebarsDotNet;

    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.Extensions;
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;

    /// <summary>
    /// A handlebars block helper for the <see cref="INamedElement"/> interface
    /// </summary>
    public static class NamedElementHelper
    {
        /// <summary>
        /// Registers the <see cref="ClassHelper"/>
        /// </summary>
        /// <param name="handlebars">
        /// The <see cref="IHandlebars"/> context with which the helper needs to be registered
        /// </param>
        public static void RegisterNamedElementHelper(this IHandlebars handlebars)
        {
            handlebars.RegisterHelper("NamedElement.WriteNameSpace", (writer, context, _) =>
            {
                if (!(context.Value is INamedElement namedElement))
                {
                    throw new ArgumentException("supposed to be INamedElement");
                }

                var qualifiedNameSpaces = namedElement.QualifiedName.Split(new[] { "::" }, StringSplitOptions.None);
                var namespaces = qualifiedNameSpaces.Skip(1).Take(qualifiedNameSpaces.Length - 2);

                var nameSpace = string.Join(".", namespaces);

                writer.WriteSafeString(nameSpace);
            });

            // Writes the C# identifier for a NamedElement: its name, escaped when it is a reserved keyword of C#. The
            // optional second argument is the casing of the first letter: AsModelled (the default),
            // UpperCaseFirstLetter or LowerCaseFirstLetter
            handlebars.RegisterHelper("NamedElement.WriteCSharpIdentifier", (writer, _, arguments) =>
            {
                if (arguments.Length != 1 && arguments.Length != 2)
                {
                    throw new HandlebarsException("{{#NamedElement.WriteCSharpIdentifier}} helper must have one or two arguments");
                }

                if (!(arguments[0] is INamedElement namedElement))
                {
                    throw new ArgumentException("{{#NamedElement.WriteCSharpIdentifier}} - the first argument is supposed to be an INamedElement");
                }

                var casing = CSharpIdentifierCasing.AsModelled;

                if (arguments.Length == 2)
                {
                    var casingName = arguments[1] as string;

                    // Enum.TryParse also accepts a number and a comma separated list, only the names are accepted here
                    if (!Enum.GetNames(typeof(CSharpIdentifierCasing)).Contains(casingName, StringComparer.OrdinalIgnoreCase)
                        || !Enum.TryParse(casingName, true, out casing))
                    {
                        throw new ArgumentException("{{#NamedElement.WriteCSharpIdentifier}} - the second argument is supposed to be AsModelled, UpperCaseFirstLetter or LowerCaseFirstLetter");
                    }
                }

                writer.WriteSafeString(namedElement.QueryCSharpIdentifier(casing));
            });
        }
    }
}
