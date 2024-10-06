// -------------------------------------------------------------------------------------------------
//  <copyright file="PropertyHelper.cs" company="Starion Group S.A.">
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
    using System;
    using System.Linq;

    using HandlebarsDotNet;

    using uml4net.Extensions;

    using uml4net.POCO.Classification;
    using uml4net.POCO.StructuredClassifiers;

    /// <summary>
    /// A handlebars block helper for the <see cref="IProperty"/> interface
    /// </summary>
    public static class PropertyHelper
    {
        /// <summary>
        /// Registers the <see cref="PropertyHelper"/>
        /// </summary>
        /// <param name="handlebars">
        /// The <see cref="IHandlebars"/> context with which the helper needs to be registered
        /// </param>
        public static void RegisterStructuralFeatureHelper(this IHandlebars handlebars)
        {
            handlebars.RegisterHelper("Property.QueryIsEnumerable", (context, arguments) =>
            {
                if (arguments.Length != 1)
                {
                    throw new HandlebarsException("{{#Property.QueryIsEnumerable}} helper must have exactly one argument");
                }

                var property = arguments.Single() as IProperty;

                return property.QueryIsEnumerable();
            });

            handlebars.RegisterHelper("Property.IsEnumerable", (output, options, context, arguments) =>
            {
                if (arguments.Length != 1)
                {
                    throw new HandlebarsException("{{#Property.IsEnumerable}} helper must have exactly one argument");
                }

                var property = arguments.Single() as IProperty;

                var isEnumerable = property.QueryIsEnumerable();

                if (isEnumerable)
                {
                    options.Template(output, context);
                }
            });

            handlebars.RegisterHelper("Property.QueryStructuralFeatureNameEqualsEnclosingType", (context, arguments) =>
            {
                if (arguments.Length != 2)
                {
                    throw new HandlebarsException("{{#Property.QueryStructuralFeatureNameEqualsEnclosingType}} helper must have exactly two arguments");
                }

                var property = arguments.Single() as IProperty;
                var @class = arguments[1] as IClass;

                return property.QueryStructuralFeatureNameEqualsEnclosingType(@class);
            });

            handlebars.RegisterHelper("Property.NameEqualsEnclosingType", (output, options, context, arguments) =>
            {
                if (arguments.Length != 1)
                {
                    throw new HandlebarsException("{{#Property.NameEqualsEnclosingType}} helper must have exactly two arguments");
                }

                var property = arguments.Single() as IProperty;
                var @class = arguments[1] as IClass;

                var nameEqualsEnclosingType = property.QueryStructuralFeatureNameEqualsEnclosingType(@class);

                if (nameEqualsEnclosingType)
                {
                    options.Template(output, context);
                }
            });

            handlebars.RegisterHelper("Property.QueryIsEnum", (context, arguments) =>
            {
                if (arguments.Length != 1)
                {
                    throw new HandlebarsException("{{#Property.QueryIsEnum}} helper must have exactly one argument");
                }

                var property = arguments.Single() as IProperty;

                return property.QueryIsEnum();
            });

            handlebars.RegisterHelper("Property.IsEnum", (output, options, context, arguments) =>
            {
                if (arguments.Length != 1)
                {
                    throw new HandlebarsException("{{#Property.IsEnum}} helper must have exactly one argument");
                }

                var property = arguments.Single() as IProperty;

                var isEnum = property.QueryIsEnum();

                if (isEnum)
                {
                    options.Template(output, context);
                }
            });

            handlebars.RegisterHelper("Property.QueryHasDefaultValue", (context, arguments) =>
            {
                if (arguments.Length != 1)
                {
                    throw new HandlebarsException("{{#Property.QueryHasDefaultValue}} helper must have exactly one argument");
                }

                var property = arguments.Single() as IProperty;

                return property.QueryHasDefaultValue();
            });

            handlebars.RegisterHelper("Property.QueryIsContainment", (context, arguments) =>
            {
                if (arguments.Length != 1)
                {
                    throw new HandlebarsException("{{#Property.QueryIsContainment}} helper must have exactly one argument");
                }

                var property = arguments.Single() as IProperty;

                return property.QueryIsContainment();
            });

            handlebars.RegisterHelper("Property.QueryTypeName", (writer, context, parameters) =>
            {
                if (!(context.Value is IProperty property))
                    throw new ArgumentException("supposed to be IStructuralFeature");

                var typeName = property.QueryTypeName();

                writer.WriteSafeString($"{typeName}");
            });
        }
    }
}