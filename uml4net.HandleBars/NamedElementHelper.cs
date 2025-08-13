// -------------------------------------------------------------------------------------------------
//  <copyright file="NamedElementHelper.cs" company="Starion Group S.A.">
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

namespace uml4net.HandleBars
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;

    using HandlebarsDotNet;

    using uml4net.SimpleClassifiers;
    using uml4net.Extensions;
    using uml4net.Classification;
    using uml4net.CommonStructure;
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
        }
    }
}
