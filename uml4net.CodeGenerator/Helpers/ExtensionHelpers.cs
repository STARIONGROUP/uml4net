// -------------------------------------------------------------------------------------------------
//  <copyright file="ExtensionHelpers.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2025 Starion Group S.A.
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

namespace uml4net.CodeGenerator.Helpers
{
    using System;
    using System.Linq;

    using HandlebarsDotNet;

    using uml4net.StructuredClassifiers;

    /// <summary>
    /// Provides Handlebars Helper registration for extension generation
    /// </summary>
    internal static class ExtensionHelpers
    {
        /// <summary>
        /// Register handlebars helper that should be use within the extension scope
        /// </summary>
        /// <param name="handlebars">The <see cref="IHandlebars" /></param>
        public static void RegisterExtensionsHelpers(this IHandlebars handlebars)
        {
            handlebars.RegisterHelper("Generalization.Interfaces", (writer, context, _) =>
            {
                if (!(context.Value is IClass @class))
                {
                    throw new ArgumentException("The context shall be a IClass");
                }

                var superClasses = @class.SuperClass.Select(x => $"I{x.Name}").ToList();

                if (@class.Namespace.Name.Contains("Extension"))
                {
                    superClasses.Add(@class.Name == "Extension"? "uml4net.Packages.IPackage": "uml4net.CommonStructure.IElement");
                }

                if (superClasses.Any())
                {
                    var result = $": {string.Join(", ", superClasses)}";

                    writer.WriteSafeString(result);
                }
            });

            handlebars.RegisterHelper("ExtensionHelper.IsExtensionClass", (context, _) =>
            {
                if (context.Value is not IClass umlClass)
                {
                    throw new ArgumentException("The context shall be an IClass");
                }

                return umlClass.Name == "Extension";
            });
        }
    }
}
