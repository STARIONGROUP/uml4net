// -------------------------------------------------------------------------------------------------
//  <copyright file="GeneralizationHelper.cs" company="Starion Group S.A.">
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

    using uml4net.POCO;
    using uml4net.POCO.StructuredClassifiers;

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
            handlebars.RegisterHelper("Generalization.Interfaces", (writer, context, parameters) =>
            {
                if (!(context.Value is IClass @class))
                    throw new ArgumentException("The context shall be a Class");

                if (@class.Generalization.Any())
                {
                    var result = $": {string.Join(", ", @class.General.Select(x => $"I{x.Name}"))}";

                    writer.WriteSafeString(result);
                }
            });

            handlebars.RegisterHelper("Generalization.Classes", (writer, context, parameters) =>
            {
                if (!(context.Value is IClass @class))
                    throw new ArgumentException("The context shall be a Class");

                if (@class.Generalization.Any())
                {
                    writer.WriteSafeString($": I{@class.Name}");
                    return;
                }

                writer.WriteSafeString($": {@class.General.First().Name}, I{@class.Name}");
            });
        }
    }
}