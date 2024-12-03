﻿// -------------------------------------------------------------------------------------------------
//  <copyright file="TypeNameHelper.cs" company="Starion Group S.A.">
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
    using uml4net.Extensions;

    using HandlebarsDotNet;
    using uml4net.StructuredClassifiers;
    using uml4net.Classification;

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
            handlebars.RegisterHelper("POCO.TypeName", (writer, context, parameters) =>
            {
                if (!(context.Value is IProperty property))
                    throw new ArgumentException("POCO.TypeName - supposed to be IProperty");

                var typeName = property.QueryCSharpTypeName();

                var nullable = property.QueryIsNullable();

                var enumerable = property.QueryIsEnumerable();

                if (property.QueryIsValueProperty())
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

                if (property.QueryIsReferenceProperty())
                {
                    var @class = property.Owner as IClass;

                    if (@class.IsAbstract)
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
