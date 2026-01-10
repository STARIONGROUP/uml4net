// -------------------------------------------------------------------------------------------------
//  <copyright file="ValueSpecificationHelper.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2026 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
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
