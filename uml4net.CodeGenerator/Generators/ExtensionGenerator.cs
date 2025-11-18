// -------------------------------------------------------------------------------------------------
//  <copyright file="ExtensionGenerator.cs" company="Starion Group S.A.">
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

namespace uml4net.CodeGenerator.Generators
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using uml4net.CodeGenerator.Helpers;
    using uml4net.Extensions;
    using uml4net.StructuredClassifiers;
    using uml4net.xmi.Readers;

    /// <summary>
    /// A Handlebars based extension code generator
    /// </summary>
    public class ExtensionGenerator : CorePocoGenerator
    {
        /// <summary>
        /// Generates POCO classes
        /// </summary>
        /// <param name="xmiReaderResult">
        /// the <see cref="XmiReaderResult" /> that contains the UML model to generate from
        /// </param>
        /// <param name="rootPackageXmiId">
        /// the unique identifier of the root package to report in
        /// </param>
        /// <param name="rootPackageName">
        /// the name of the root package to report in
        /// </param>
        /// <param name="outputDirectory">
        /// The target <see cref="DirectoryInfo" />
        /// </param>
        /// <returns>
        /// an awaitable task
        /// </returns>
        public Task GenerateExtensionClassesAsync(XmiReaderResult xmiReaderResult, string rootPackageXmiId, string rootPackageName, DirectoryInfo outputDirectory)
        {
            ArgumentNullException.ThrowIfNull(xmiReaderResult);
            ArgumentNullException.ThrowIfNull(outputDirectory);
            
            return this.GenerateExtensionClassesInternalAsync(xmiReaderResult, rootPackageXmiId, rootPackageName, outputDirectory);
        }

        /// <summary>
        /// Generates the XmiElementExtensionReaderFacade based on the <see cref="IClass" /> instances
        /// that are in the provided <see cref="XmiReaderResult" />
        /// </summary>
        /// <param name="xmiReaderResult">
        /// the <see cref="XmiReaderResult" /> that contains the UML model to generate from
        /// </param>
        /// <param name="rootPackageXmiId">
        /// the unique identifier of the root package to report in
        /// </param>
        /// <param name="rootPackageName">
        /// the name of the root package to report in
        /// </param>
        /// <param name="extender">The name of the extender that the ExtensionContentReaderFacade will cover</param>
        /// <param name="extenderId">The id of the extender that the ExtensionContentReaderFacade will cover</param>
        /// <param name="outputDirectory">
        /// The target <see cref="DirectoryInfo" />
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task" />
        /// </returns>
        public Task GenerateExtensionContentReaderFacadeAsync(XmiReaderResult xmiReaderResult, string rootPackageXmiId, string rootPackageName, string extender, string extenderId, DirectoryInfo outputDirectory)
        {
            ArgumentNullException.ThrowIfNull(xmiReaderResult);
            ArgumentNullException.ThrowIfNull(outputDirectory);
            ArgumentException.ThrowIfNullOrWhiteSpace(extender);

            if (string.IsNullOrWhiteSpace(extenderId))
            {
                extenderId = string.Empty;
            }
            
            return this.GenerateExtensionContentReaderFacadeInternalAsync(xmiReaderResult, rootPackageXmiId, rootPackageName, extender, extenderId,outputDirectory);
        }

        /// <summary>
        /// Generates the <see cref="Class" /> XMI Reader instances for extension
        /// that are in the provided <see cref="XmiReaderResult" />
        /// </summary>
        /// <param name="xmiReaderResult">
        /// the <see cref="XmiReaderResult" /> that contains the UML model to generate from
        /// </param>
        /// <param name="rootPackageXmiId">
        /// the unique identifier of the root package to report in
        /// </param>
        /// <param name="rootPackageName">
        /// the name of the root package to report in
        /// </param>
        /// <param name="extender">The name of the extender that the ExtensionContentReaderFacade will cover</param>
        /// <param name="extenderId">The id of the extender that the ExtensionContentReaderFacade will cover</param>
        /// <param name="outputDirectory">
        /// The target <see cref="DirectoryInfo" />
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task" />
        /// </returns>
        public async Task GenerateExtensionReadersAsync(XmiReaderResult xmiReaderResult, string rootPackageXmiId, string rootPackageName, string extender, string extenderId, DirectoryInfo outputDirectory)
        {
            ArgumentNullException.ThrowIfNull(xmiReaderResult);
            ArgumentNullException.ThrowIfNull(outputDirectory);
            ArgumentException.ThrowIfNullOrWhiteSpace(extender);

            if (string.IsNullOrWhiteSpace(extenderId))
            {
                extenderId = string.Empty;
            }
            
            await this.GenerateExtensionReadersInternalAsync(xmiReaderResult, rootPackageXmiId, rootPackageName, extender, extenderId, outputDirectory);
        }

        /// <summary>
        /// Generates code specific to the concrete implementation
        /// </summary>
        /// <param name="xmiReaderResult">
        /// the <see cref="XmiReaderResult" /> that contains the UML model to generate from
        /// </param>
        /// <param name="rootPackageXmiId">
        /// the unique identifier of the root package to report in
        /// </param>
        /// <param name="rootPackageName">
        /// the name of the root package to report in
        /// </param>
        /// <param name="outputDirectory">
        /// The target <see cref="DirectoryInfo" />
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task" />
        /// </returns>
        public override Task GenerateAsync(XmiReaderResult xmiReaderResult, string rootPackageXmiId, string rootPackageName,  DirectoryInfo outputDirectory)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Register the code templates
        /// </summary>
        protected override void RegisterTemplates()
        {
            base.RegisterTemplates();
            this.RegisterTemplate("extension-core-poco-class-template");
            this.RegisterTemplate("extension-xmi-reader-template");
            this.RegisterTemplate("extension-reader-facade-template");
        }

        /// <summary>
        /// Register the custom helpers
        /// </summary>
        protected override void RegisterHelpers()
        {
            base.RegisterHelpers();
            this.Handlebars.RegisterExtensionsHelpers();
        }

        /// <summary>
        /// Generates POCO classes
        /// </summary>
        /// <param name="xmiReaderResult">
        /// the <see cref="XmiReaderResult" /> that contains the UML model to generate from
        /// </param>
        /// <param name="rootPackageXmiId">The XmiId of the root packagethat is queried</param>
        /// <param name="rootPackageName">the name of the name package that is queried</param>
        /// <param name="outputDirectory">
        /// The target <see cref="DirectoryInfo" />
        /// </param>
        /// <returns>
        /// an awaitable task
        /// </returns>
        private async Task GenerateExtensionClassesInternalAsync(XmiReaderResult xmiReaderResult, string rootPackageXmiId, string rootPackageName, DirectoryInfo outputDirectory)
        {
            var template = this.Templates["extension-core-poco-class-template"];

            var root = xmiReaderResult.QueryRoot(rootPackageXmiId, rootPackageName);

            var classes = root.QueryPackages()
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
        /// Generates the XmiElementExtensionReaderFacade based on the <see cref="IClass" /> instances
        /// that are in the provided <see cref="XmiReaderResult" />
        /// </summary>
        /// <param name="xmiReaderResult">
        /// the <see cref="XmiReaderResult" /> that contains the UML model to generate from
        /// </param>
        /// <param name="rootPackageXmiId">The XmiId of the root packagethat is queried</param>
        /// <param name="rootPackageName">the name of the name package that is queried</param>
        /// <param name="extender">The name of the extender that the ExtensionContentReaderFacade will cover</param>
        /// <param name="extenderId">The id of the extender that the ExtensionContentReaderFacade will cover</param>
        /// <param name="outputDirectory">
        /// The target <see cref="DirectoryInfo" />
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task" />
        /// </returns>
        private async Task GenerateExtensionContentReaderFacadeInternalAsync(XmiReaderResult xmiReaderResult, string rootPackageXmiId, string rootPackageName, string extender, string extenderId, DirectoryInfo outputDirectory)
        {
            var root = xmiReaderResult.QueryRoot(rootPackageXmiId, rootPackageName);

            var classes = root.QueryPackages()
                .SelectMany(x => x.PackagedElement.OfType<IClass>())
                .Where(x => !x.IsAbstract)
                .ToList();

            var template = this.Templates["extension-reader-facade-template"];

            var generatedCode = template(new { Namespace = classes[0].Namespace.Name, Classes = classes, Extender = extender, ExtenderId = extenderId });
            generatedCode = this.CodeCleanup(generatedCode);

            const string fileName = "ExtensionContentReaderFacade.cs";

            await WriteAsync(generatedCode, outputDirectory, fileName);
        }

        /// <summary>
        /// Generates the <see cref="Class" /> XMI Reader instances for extension
        /// that are in the provided <see cref="XmiReaderResult" />
        /// </summary>
        /// <param name="xmiReaderResult">
        /// the <see cref="XmiReaderResult" /> that contains the UML model to generate from
        /// </param>
        /// <param name="rootPackageXmiId">The XmiId of the root packagethat is queried</param>
        /// <param name="rootPackageName">the name of the name package that is queried</param>
        /// <param name="extender">The name of the extender that the ExtensionContentReaderFacade will cover</param>
        /// <param name="extenderId">The id of the extender that the ExtensionContentReaderFacade will cover</param>
        /// <param name="outputDirectory">
        /// The target <see cref="DirectoryInfo" />
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task" />
        /// </returns>
        private async Task GenerateExtensionReadersInternalAsync(XmiReaderResult xmiReaderResult, string rootPackageXmiId, string rootPackageName, string extender, string extenderId, DirectoryInfo outputDirectory)
        {
            var root = xmiReaderResult.QueryRoot(rootPackageXmiId, rootPackageName);

            var classes = root.QueryPackages()
                .SelectMany(x => x.PackagedElement.OfType<IClass>())
                .Where(x => !x.IsAbstract)
                .ToList();

            var template = this.Templates["extension-xmi-reader-template"];

            foreach (var @class in classes)
            {
                var generatedCode = template(new { Class = @class, Extender = extender, ExtenderId = extenderId });
                generatedCode = this.CodeCleanup(generatedCode);
                var fileName = $"{@class.Name}Reader.cs";
                await WriteAsync(generatedCode, outputDirectory, fileName);
            }
        }
    }
}
