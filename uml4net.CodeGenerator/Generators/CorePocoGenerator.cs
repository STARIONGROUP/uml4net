// -------------------------------------------------------------------------------------------------
// <copyright file="CorePocoGenerator.cs" company="Starion Group S.A.">
//
//   Copyright 2019-2024 Starion Group S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, softwareUseCases
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.CodeGenerator.Generators
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using System.IO;
    using POCO.SimpleClassifiers;
    using uml4net.Extensions;

    using uml4net.POCO.Packages;
    using uml4net.POCO.StructuredClassifiers;
    using uml4net.xmi.Readers;

    /// <summary>
    /// A Handlebars based POCO code generator
    /// </summary>
    public class CorePocoGenerator : UmlHandleBarsGenerator
    {
        /// <summary>
        /// Generates the <see cref="Class"/> POCO instances
        /// that are in the provided <see cref="IPackage"/>
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
        public override async Task Generate(XmiReaderResult xmiReaderResult, DirectoryInfo outputDirectory)
        {
            await this.GenerateEnumerations(xmiReaderResult, outputDirectory);
            await this.GenerateInterfaces(xmiReaderResult, outputDirectory);
            await this.GenerateClasses(xmiReaderResult, outputDirectory);
        }

        /// <summary>
        /// Generates Enumeration
        /// </summary>
        /// <param name="xmiReaderResult">
        /// the <see cref="XmiReaderResult"/> that contains the UML model to generate from
        /// </param>
        /// <param name="outputDirectory">
        /// The target <see cref="DirectoryInfo"/>
        /// </param>
        /// <returns>
        /// an awaitable task
        /// </returns>
        public async Task GenerateEnumerations(XmiReaderResult xmiReaderResult, DirectoryInfo outputDirectory)
        {
            var template = this.Templates["core-enumeration-template"];

            var enumerations = xmiReaderResult.Root.QueryPackages()
                .SelectMany(x => x.PackagedElement.OfType<IEnumeration>())
                .ToList();

            foreach (var enumeration in enumerations)
            {
                var generatedEnumeration = template(enumeration);

                generatedEnumeration = CodeCleanup(generatedEnumeration);

                var fileName = $"{enumeration.Name.CapitalizeFirstLetter()}.cs";

                await Write(generatedEnumeration, outputDirectory, fileName);
            }
        }

        /// <summary>
        /// Generates POCO interfaces
        /// </summary>
        /// <param name="xmiReaderResult">
        /// the <see cref="XmiReaderResult"/> that contains the UML model to generate from
        /// </param>
        /// <param name="outputDirectory">
        /// The target <see cref="DirectoryInfo"/>
        /// </param>
        /// <returns>
        /// an awaitable task
        /// </returns>
        public async Task<string> GenerateEnumeration(XmiReaderResult xmiReaderResult, DirectoryInfo outputDirectory, string enumerationName)
        {
            var template = this.Templates["core-enumeration-template"];

            var enumerations = xmiReaderResult.Root.QueryPackages()
                .SelectMany(x => x.PackagedElement.OfType<IEnumeration>())
                .ToList();

            var enumeration = enumerations.Single(x => x.Name == enumerationName);

            var generatedEnumeration = template(enumeration);

            generatedEnumeration = CodeCleanup(generatedEnumeration);

            var fileName = $"{enumeration.Name.CapitalizeFirstLetter()}.cs";

            await Write(generatedEnumeration, outputDirectory, fileName);

            return generatedEnumeration;
        }

        /// <summary>
        /// Generates POCO interfaces
        /// </summary>
        /// <param name="xmiReaderResult">
        /// the <see cref="XmiReaderResult"/> that contains the UML model to generate from
        /// </param>
        /// <param name="outputDirectory">
        /// The target <see cref="DirectoryInfo"/>
        /// </param>
        /// <returns>
        /// an awaitable task
        /// </returns>
        public async Task GenerateInterfaces(XmiReaderResult xmiReaderResult, DirectoryInfo outputDirectory)
        {
            var template = this.Templates["core-poco-interface-template"];

            var classes = xmiReaderResult.Root.QueryPackages()
                .SelectMany(x => x.PackagedElement.OfType<IClass>())
                .ToList();

            foreach (var @class in classes)
            {
                var generatedInterface = template(@class);

                generatedInterface = CodeCleanup(generatedInterface);

                var fileName = $"I{@class.Name.CapitalizeFirstLetter()}.cs";

                await Write(generatedInterface, outputDirectory, fileName);
            }
        }

        /// <summary>
        /// Generates POCO interfaces
        /// </summary>
        /// <param name="xmiReaderResult">
        /// the <see cref="XmiReaderResult"/> that contains the UML model to generate from
        /// </param>
        /// <param name="outputDirectory">
        /// The target <see cref="DirectoryInfo"/>
        /// </param>
        /// <returns>
        /// an awaitable task
        /// </returns>
        public async Task<string> GenerateInterface(XmiReaderResult xmiReaderResult, DirectoryInfo outputDirectory, string className)
        {
            var template = this.Templates["core-poco-interface-template"];

            var classes = xmiReaderResult.Root.QueryPackages()
                .SelectMany(x => x.PackagedElement.OfType<IClass>())
                .ToList();

            var @class = classes.Single(x => x.Name == className);

            var generatedInterface = template(@class);

            generatedInterface = CodeCleanup(generatedInterface);

            var fileName = $"I{@class.Name.CapitalizeFirstLetter()}.cs";

            await Write(generatedInterface, outputDirectory, fileName);

            return generatedInterface;
        }

        /// <summary>
        /// Generates POCO classes
        /// </summary>
        /// <param name="xmiReaderResult">
        /// the <see cref="XmiReaderResult"/> that contains the UML model to generate from
        /// </param>
        /// <param name="outputDirectory">
        /// The target <see cref="DirectoryInfo"/>
        /// </param>
        /// <returns>
        /// an awaitable task
        /// </returns>
        public async Task GenerateClasses(XmiReaderResult xmiReaderResult, DirectoryInfo outputDirectory)
        {
            var template = this.Templates["core-poco-class-template"];

            var classes = xmiReaderResult.Root.QueryPackages()
                .SelectMany(x => x.PackagedElement.OfType<IClass>())
                .Where(x => !x.IsAbstract)
                .ToList();

            foreach (var @class in classes)
            {
                var generatedCode = template(@class);

                generatedCode = CodeCleanup(generatedCode);

                var fileName = $"{@class.Name.CapitalizeFirstLetter()}.cs";

                await Write(generatedCode, outputDirectory, fileName);
            }
        }

        /// <summary>
        /// Generates a named POCO class
        /// </summary>
        /// <param name="xmiReaderResult">
        /// the <see cref="XmiReaderResult"/> that contains the UML model to generate from
        /// </param>
        /// <param name="outputDirectory">
        /// The target <see cref="DirectoryInfo"/>
        /// </param>
        /// <param name="name">
        /// The name of the class that is to be generated
        /// </param>
        /// <returns>
        /// an awaitable task
        /// </returns>
        public async Task<string> GenerateClass(XmiReaderResult xmiReaderResult, DirectoryInfo outputDirectory, string name)
        {
            var template = this.Templates["core-poco-class-template"];

            var classes = xmiReaderResult.Root.QueryPackages()
                .SelectMany(x => x.PackagedElement.OfType<IClass>())
                .Where(x => !x.IsAbstract)
                .ToList();

            var @class = classes.Single(x => x.Name == name);

            if (@class.IsAbstract)
            {
                throw new InvalidOperationException("POCO should not be abstract");
            }

            var generatedCode = template(@class);

            generatedCode = CodeCleanup(generatedCode);

            var fileName = $"{@class.Name.CapitalizeFirstLetter()}.cs";

            await Write(generatedCode, outputDirectory, fileName);

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
            this.RegisterTemplate("core-poco-interface-template");
            this.RegisterTemplate("core-poco-class-template");
            this.RegisterTemplate("core-enumeration-template");
        }
    }
}