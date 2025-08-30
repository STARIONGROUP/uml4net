// -------------------------------------------------------------------------------------------------
//  <copyright file="GeneralizationHelper.cs" company="Starion Group S.A.">
// 
//    Copyright (C) 2019-2025 Starion Group S.A.
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
    using System.Linq;
    
    using uml4net.Extensions;
    using uml4net.StructuredClassifiers;

    using HandlebarsDotNet;

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

                if (@class.Generalization.Any())
                {
                    writer.WriteSafeString($": I{@class.Name}");
                    return;
                }

                writer.WriteSafeString($": {@class.General[0].Name}, I{@class.Name}");
            });
        }
    }
}
