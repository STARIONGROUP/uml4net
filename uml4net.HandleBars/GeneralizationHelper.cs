// -------------------------------------------------------------------------------------------------
// <copyright file="GeneralizationHelper.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.HandleBars
{
    using System;
    using System.Linq;

    using HandlebarsDotNet;

    using uml4net.Extensions;
    using uml4net.StructuredClassifiers;

    /// <summary>
    /// A block helper that prints the generalization (super-type) information of an <see cref="IClass"/>
    /// </summary>
    public static class GeneralizationHelper
    {
        /// <summary>
        /// Registers the <see cref="GeneralizationHelper"/>
        /// </summary>
        /// <param name="handlebars">
        /// The <see cref="IHandlebars"/> context with which the helper needs to be registered
        /// </param>
        public static void RegisterGeneralizationHelper(this IHandlebars handlebars)
        {
            handlebars.RegisterHelper("Generalization.Interfaces", (writer, context, _) =>
            {
                if (!(context.Value is IClass @class))
                {
                    throw new ArgumentException("The context shall be a IClass");
                }

                var superClasses = @class.SuperClass.Select(x => $"I{x.Name}").ToList();

                if (superClasses.Any())
                {
                    var result = $": {string.Join(", ", superClasses)}";

                    writer.WriteSafeString(result);
                }
            });

            handlebars.RegisterHelper("Generalization.InterfaceImplementationAndInterfaces", (writer, context, _) =>
            {
                if (!(context.Value is IClass @class))
                {
                    throw new ArgumentException("The context shall be a IClass");
                }

                if (@class.Generalization.Any() || @class.QueryInterfaces().Any() )
                {
                    var superClassNames = @class.SuperClass.Select(x => $"I{x.Name}");
                    var interfaceRealizationNames = @class.QueryInterfaces().Select(x => $"I{x.Name}");

                    var names = superClassNames.ToList();
                    names.AddRange(interfaceRealizationNames);

                    var result = $": {string.Join(", ", names)}";

                    writer.WriteSafeString(result);
                }
            });

            handlebars.RegisterHelper("Generalization.Classes", (writer, context, _) =>
            {
                if (!(context.Value is IClass @class))
                {
                    throw new ArgumentException("The context shall be a IClass");
                }

                if (@class.General.Any())
                {
                    writer.WriteSafeString($": {@class.General[0].Name}, I{@class.Name}");
                    return;
                }

                writer.WriteSafeString($": I{@class.Name}");
            });
        }
    }
}
