// -------------------------------------------------------------------------------------------------
// <copyright file="CorePocoGenerator.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2025 Starion Group S.A.
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
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using uml4net.SimpleClassifiers;
    using uml4net.Extensions;
    using uml4net.Packages;
    using uml4net.StructuredClassifiers;
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
        public override async Task GenerateAsync(XmiReaderResult xmiReaderResult, DirectoryInfo outputDirectory)
        {
            await this.GenerateEnumerationsAsync(xmiReaderResult, outputDirectory);
            await this.GenerateInterfacesAsync(xmiReaderResult, outputDirectory);
            await this.GenerateClassesAsync(xmiReaderResult, outputDirectory);
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
        public Task GenerateEnumerationsAsync(XmiReaderResult xmiReaderResult, DirectoryInfo outputDirectory)
        {
            ArgumentNullException.ThrowIfNull(xmiReaderResult);

            ArgumentNullException.ThrowIfNull(outputDirectory);

            return this.GenerateEnumerationsInternalAsync(xmiReaderResult, outputDirectory);
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
        private async Task GenerateEnumerationsInternalAsync(XmiReaderResult xmiReaderResult, DirectoryInfo outputDirectory)
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

                await WriteAsync(generatedEnumeration, outputDirectory, fileName);
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
        /// <param name="name">
        /// The name of the Enumeration to generate
        /// </param>
        /// <returns>
        /// an awaitable task
        /// </returns>
        public Task<string> GenerateEnumerationAsync(XmiReaderResult xmiReaderResult, DirectoryInfo outputDirectory, string name)
        {
            ArgumentNullException.ThrowIfNull(xmiReaderResult);

            ArgumentNullException.ThrowIfNull(outputDirectory);

            ArgumentNullException.ThrowIfNullOrEmpty(name);

            return this.GenerateEnumerationInternalAsync(xmiReaderResult, outputDirectory, name);
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
        /// <param name="name">
        /// The name of the Enumeration to generate
        /// </param>
        /// <returns>
        /// an awaitable task
        /// </returns>
        private async Task<string> GenerateEnumerationInternalAsync(XmiReaderResult xmiReaderResult, DirectoryInfo outputDirectory, string name)
        {
            var template = this.Templates["core-enumeration-template"];

            var enumerations = xmiReaderResult.Root.QueryPackages()
                .SelectMany(x => x.PackagedElement.OfType<IEnumeration>())
                .ToList();

            var enumeration = enumerations.Single(x => x.Name == name);

            var generatedEnumeration = template(enumeration);

            generatedEnumeration = CodeCleanup(generatedEnumeration);

            var fileName = $"{enumeration.Name.CapitalizeFirstLetter()}.cs";

            await WriteAsync(generatedEnumeration, outputDirectory, fileName);

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
        public Task GenerateInterfacesAsync(XmiReaderResult xmiReaderResult, DirectoryInfo outputDirectory)
        {
            ArgumentNullException.ThrowIfNull(xmiReaderResult);

            ArgumentNullException.ThrowIfNull(outputDirectory);
            
            return this.GenerateInterfacesInternalAsync(xmiReaderResult, outputDirectory);
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
        private async Task GenerateInterfacesInternalAsync(XmiReaderResult xmiReaderResult, DirectoryInfo outputDirectory)
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

                await WriteAsync(generatedInterface, outputDirectory, fileName);
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
        /// <param name="name">
        /// The name of the interface that is to be generated
        /// </param>
        /// <returns>
        /// an awaitable task
        /// </returns>
        public Task<string> GenerateInterfaceAsync(XmiReaderResult xmiReaderResult, DirectoryInfo outputDirectory, string name)
        {
            ArgumentNullException.ThrowIfNull(xmiReaderResult);

            ArgumentNullException.ThrowIfNull(outputDirectory);

            ArgumentNullException.ThrowIfNullOrEmpty(name);

            return this.GenerateInterfaceInternalAsync(xmiReaderResult, outputDirectory, name);
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
        /// <param name="name">
        /// The name of the interface that is to be generated
        /// </param>
        /// <returns>
        /// an awaitable task
        /// </returns>
        private async Task<string> GenerateInterfaceInternalAsync(XmiReaderResult xmiReaderResult, DirectoryInfo outputDirectory, string name)
        {
            var template = this.Templates["core-poco-interface-template"];

            var classes = xmiReaderResult.Root.QueryPackages()
                .SelectMany(x => x.PackagedElement.OfType<IClass>())
                .ToList();

            var @class = classes.Single(x => x.Name == name);

            var generatedInterface = template(@class);

            generatedInterface = this.CodeCleanup(generatedInterface);

            var fileName = $"I{@class.Name.CapitalizeFirstLetter()}.cs";

            await WriteAsync(generatedInterface, outputDirectory, fileName);

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
        public Task GenerateClassesAsync(XmiReaderResult xmiReaderResult, DirectoryInfo outputDirectory)
        {
            ArgumentNullException.ThrowIfNull(xmiReaderResult);

            ArgumentNullException.ThrowIfNull(outputDirectory);
            
            return this.GenerateClassesInternalAsync(xmiReaderResult, outputDirectory);
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
        private async Task GenerateClassesInternalAsync(XmiReaderResult xmiReaderResult, DirectoryInfo outputDirectory)
        {
            var template = this.Templates["core-poco-class-template"];

            var classes = xmiReaderResult.Root.QueryPackages()
                .SelectMany(x => x.PackagedElement.OfType<IClass>())
                .Where(x => !x.IsAbstract)
                .ToList();

            foreach (var cls in classes)
            {
                var generatedCode = template(cls);

                generatedCode = this.CodeCleanup(generatedCode);

                var fileName = $"{cls.Name.CapitalizeFirstLetter()}.cs";

                await WriteAsync(generatedCode, outputDirectory, fileName);
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
        public Task<string> GenerateClassAsync(XmiReaderResult xmiReaderResult, DirectoryInfo outputDirectory, string name)
        {
            ArgumentNullException.ThrowIfNull(xmiReaderResult);

            ArgumentNullException.ThrowIfNull(outputDirectory);

            ArgumentNullException.ThrowIfNullOrEmpty(name);

            return this.GenerateClassInternalAsync(xmiReaderResult, outputDirectory, name);
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
        private async Task<string> GenerateClassInternalAsync(XmiReaderResult xmiReaderResult, DirectoryInfo outputDirectory, string name)
        {
            var template = this.Templates["core-poco-class-template"];

            var classes = xmiReaderResult.Root.QueryPackages()
                .SelectMany(x => x.PackagedElement.OfType<IClass>())
                .Where(x => !x.IsAbstract)
                .ToList();

            var cls = classes.Single(x => x.Name == name);

            if (cls.IsAbstract)
            {
                throw new InvalidOperationException("POCO should not be abstract");
            }

            var generatedCode = template(cls);

            generatedCode = this.CodeCleanup(generatedCode);

            var fileName = $"{cls.Name.CapitalizeFirstLetter()}.cs";

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
            uml4net.HandleBars.DocumentationHelper.RegisterDocumentationHelper(this.Handlebars);
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
