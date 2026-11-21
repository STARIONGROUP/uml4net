// -------------------------------------------------------------------------------------------------
// <copyright file="TypeNameHelper.cs" company="Starion Group S.A.">
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

    using uml4net.Classification;
    using uml4net.Extensions;
    using uml4net.StructuredClassifiers;

    /// <summary>
    /// A block helper that prints the name of the type of <see cref="IProperty"/>
    /// </summary>
    public static class TypeNameHelper
    {
        /// <summary>
        /// Registers the <see cref="TypeNameHelper"/>
        /// </summary>
        /// <param name="handlebars">
        /// The <see cref="IHandlebars"/> context with which the helper needs to be registered
        /// </param>
        public static void RegisterTypeNameHelper(this IHandlebars handlebars)
        {
            handlebars.RegisterHelper("POCO.TypeName", (writer, context, _) =>
            {
                if (!(context.Value is IProperty property))
                {
                    throw new ArgumentException("POCO.TypeName - supposed to be IProperty");
                }

                var typeName = property.QueryCSharpTypeName();

                var nullable = property.QueryIsNullable();

                var enumerable = property.QueryIsEnumerable();

                if (property.QueryIsValueType())
                {
                    if (enumerable)
                    {
                        writer.WriteSafeString($"List<{typeName}>");
                    }
                    else if (typeName != "string" && nullable)
                    {
                        writer.WriteSafeString($"{typeName}?");
                    }
                    else
                    {
                        writer.WriteSafeString($"{typeName}");
                    }
                }

                if (property.QueryIsReferenceType())
                {
                    var @class = property.Owner as IClass;

                    // an untyped property is typed as object, which has no generated interface
                    if (@class.IsAbstract && property.Type != null)
                    {
                        typeName = $"I{typeName}";
                    }

                    if (enumerable)
                    {
                        writer.WriteSafeString($"List<{typeName}>");
                    }
                    else
                    {
                        writer.WriteSafeString($"{typeName}");
                    }
                }
            });
        }
    }
}
