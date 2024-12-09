// -------------------------------------------------------------------------------------------------
//  <copyright file="XmiReaderGenerator.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2024 Starion Group S.A.
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

namespace uml4net.CodeGenerator.Generators
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using uml4net.Extensions;
    using uml4net.StructuredClassifiers;
    using uml4net.xmi.Readers;

    /// <summary>
    /// A Handlebars based xmi-reader code generator
    /// </summary>
    public class XmiReaderGenerator : UmlHandleBarsGenerator
    {
        /// <summary>
        /// Generates the <see cref="Class"/> POCO instances
        /// that are in the provided <see cref="XmiReaderResult"/>
        /// </summary>
        /// <param name="xmiReaderResult">
        /// the <see cref="XmiReaderResult"/> that contains the UML model to generate from
        /// </param>
        /// <param name="outputDirectory">
        /// The target <see cref="DirectoryInfo"/>
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        public override async Task GenerateAsync(XmiReaderResult xmiReaderResult, DirectoryInfo outputDirectory)
        {
            ArgumentNullException.ThrowIfNull(xmiReaderResult);

            ArgumentNullException.ThrowIfNull(outputDirectory);

            var classes = xmiReaderResult.Root.QueryPackages()
                .SelectMany(x => x.PackagedElement.OfType<IClass>())
                .Where(x => !x.IsAbstract)
                .ToList();

            foreach (var cls in classes)
            {
                await this.GenerateXmiReaderAsync(outputDirectory, cls);
            }
        }

        /// <summary>
        /// Generates Xmi Reader classes for a concrete class
        /// </summary>
        /// <param name="outputDirectory"></param>
        /// <param name="class">
        /// The <see cref="IClass"/> for which the XmiReader is to be generated
        /// </param>
        /// <returns>
        /// a string representation of the generated code
        /// </returns>
        public async Task<string> GenerateXmiReaderAsync(DirectoryInfo outputDirectory, IClass @class)
        {
            ArgumentNullException.ThrowIfNull(outputDirectory);

            ArgumentNullException.ThrowIfNull(@class);

            var template = this.Templates["xmi-reader-template"];

            if (@class.IsAbstract)
            {
                throw new InvalidOperationException("XmiReader should not be abstract");
            }

            var generatedCode = template(@class);

            generatedCode = this.CodeCleanup(generatedCode);

            var fileName = $"{@class.Name}Reader.cs";

            await WriteAsync(generatedCode, outputDirectory, fileName);

            return generatedCode;
        }

        /// <summary>
        /// Register the custom helpers
        /// </summary>
        protected override void RegisterHelpers()
        {
            uml4net.HandleBars.StringHelper.RegisterStringHelper(this.Handlebars);
            uml4net.HandleBars.IEnumerableHelper.RegisterEnumerableHelper(this.Handlebars);
            uml4net.HandleBars.ClassHelper.RegisterClassHelper(this.Handlebars);
            uml4net.HandleBars.PropertyHelper.RegisterPropertyHelper(this.Handlebars);
            uml4net.HandleBars.GeneralizationHelper.RegisterGeneralizationHelper(this.Handlebars);
            uml4net.HandleBars.DocumentationHelper.RegisteredDocumentationHelper(this.Handlebars);
            uml4net.HandleBars.EnumHelper.RegisterEnumHelper(this.Handlebars);
            uml4net.HandleBars.DecoratorHelper.RegisterDecoratorHelper(this.Handlebars);
        }

        /// <summary>
        /// Register the code templates
        /// </summary>
        protected override void RegisterTemplates()
        {
            this.RegisterTemplate("xmi-reader-template");
        }
    }
}
