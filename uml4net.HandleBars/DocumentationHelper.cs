﻿// -------------------------------------------------------------------------------------------------
//  <copyright file="DocumentationHelper.cs" company="Starion Group S.A.">
// 
//    Copyright (C) 2019-2025 Starion Group S.A.
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

    using HandlebarsDotNet;

    using uml4net.Extensions;
    using uml4net.CommonStructure;

    /// <summary>
    /// a block helper 
    /// </summary>
    public static class DocumentationHelper
    {
        /// <summary>
        /// Registers the <see cref="DocumentationHelper"/>
        /// </summary>
        /// <param name="handlebars">
        /// The <see cref="IHandlebars"/> context with which the helper needs to be registered
        /// </param>
        public static void RegisterDocumentationHelper(this IHandlebars handlebars)
        {
            handlebars.RegisterHelper("Documentation", (writer, context, _) =>
            {
                if (!(context.Value is IElement eModelElement))
                {
                    throw new ArgumentException("supposed to be IElement");
                }

                writer.WriteSafeString($"/// <summary>{Environment.NewLine}");
                foreach (var line in eModelElement.QueryDocumentation())
                {
                    writer.WriteSafeString($"/// {line}{Environment.NewLine}");
                }
                writer.WriteSafeString($"/// </summary>{Environment.NewLine}");
            });

            handlebars.RegisterHelper("RawDocumentation", (writer, context, _) =>
            {
                if (!(context.Value is IElement element))
                {
                    throw new ArgumentException("supposed to be IElement");
                }

                var rawDocumentation = element.QueryRawDocumentation();

                if (string.IsNullOrEmpty(rawDocumentation))
                {
                    rawDocumentation = "No Documentation Provided";
                }

                writer.WriteSafeString(rawDocumentation);
            });
        }
    }
}
