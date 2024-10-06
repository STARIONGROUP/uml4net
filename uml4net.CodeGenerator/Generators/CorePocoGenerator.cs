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

    using uml4net.Extensions;

    using uml4net.POCO.Packages;
    using uml4net.POCO.StructuredClassifiers;

    /// <summary>
    /// A Handlebars based POCO code generator
    /// </summary>
    public class CorePocoGenerator : UmlHandleBarsGenerator
    {
        /// <summary>
        /// Generates the <see cref="Class"/> POCO instances
        /// that are in the provided <see cref="IPackage"/>
        /// </summary>
        /// <param name="package">
        /// the <see cref="IPackage"/> that contains the <see cref="Class"/> to generate
        /// </param>
        /// <param name="outputDirectory">
        /// The target <see cref="DirectoryInfo"/>
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        public override async Task Generate(IPackage package, DirectoryInfo outputDirectory)
        {
            await this.GenerateInterfaces(package, outputDirectory);
            await this.GenerateClasses(package, outputDirectory);
        }

        /// <summary>
        /// Generates POCO interfaces
        /// </summary>
        /// <param name="package">
        /// the <see cref="IPackage"/> that contains the <see cref="Class"/> to generate
        /// </param>
        /// <param name="outputDirectory">
        /// The target <see cref="DirectoryInfo"/>
        /// </param>
        /// <returns>
        /// an awaitable task
        /// </returns>
        public async Task GenerateInterfaces(IPackage package, DirectoryInfo outputDirectory)
        {
            var template = this.Templates["core-poco-interface-template"];

            foreach (var eClass in package.OwnedType.OfType<Class>())
            {
                var generatedInterface = template(eClass);

                generatedInterface = CodeCleanup(generatedInterface);

                var fileName = $"I{eClass.Name.CapitalizeFirstLetter()}.cs";

                await Write(generatedInterface, outputDirectory, fileName);
            }
        }

        /// <summary>
        /// Generates POCO interfaces
        /// </summary>
        /// <param name="package">
        /// the <see cref="IPackage"/> that contains the <see cref="Class"/> to generate
        /// </param>
        /// <param name="outputDirectory">
        /// The target <see cref="DirectoryInfo"/>
        /// </param>
        /// <returns>
        /// an awaitable task
        /// </returns>
        public async Task<string> GenerateInterface(IPackage package, DirectoryInfo outputDirectory, string className)
        {
            var template = this.Templates["core-poco-interface-template"];

            var @class = package.OwnedType.OfType<Class>().Single(x => x.Name == className);

            var generatedInterface = template(@class);

            generatedInterface = CodeCleanup(generatedInterface);

            var fileName = $"I{@class.Name.CapitalizeFirstLetter()}.cs";

            await Write(generatedInterface, outputDirectory, fileName);

            return generatedInterface;
        }

        /// <summary>
        /// Generates POCO classes
        /// </summary>
        /// <param name="package">
        /// the <see cref="IPackage"/> that contains the <see cref="Class"/> to generate
        /// </param>
        /// <param name="outputDirectory">
        /// The target <see cref="DirectoryInfo"/>
        /// </param>
        /// <returns>
        /// an awaitable task
        /// </returns>
        public async Task GenerateClasses(IPackage package, DirectoryInfo outputDirectory)
        {
            var template = this.Templates["core-poco-class-template"];

            foreach (var @class in package.OwnedType.OfType<Class>().Where(x => !x.IsAbstract))
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
        /// <param name="package">
        /// the <see cref="IPackage"/> that contains the <see cref="Class"/> to generate
        /// </param>
        /// <param name="outputDirectory">
        /// The target <see cref="DirectoryInfo"/>
        /// </param>
        /// <returns>
        /// an awaitable task
        /// </returns>
        public async Task<string> GenerateClass(IPackage package, DirectoryInfo outputDirectory, string className)
        {
            var template = this.Templates["core-poco-class-template"];

            var @class = package.OwnedType.OfType<Class>().Single(x => x.Name == className);

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
            uml4net.HandleBars.BooleanHelper.RegisterBooleanHelper(this.Handlebars);
            uml4net.HandleBars.StringHelper.RegisterStringHelper(this.Handlebars);
            uml4net.HandleBars.PropertyHelper.RegisterStructuralFeatureHelper(this.Handlebars);
            uml4net.HandleBars.GeneralizationHelper.RegisterGeneralizationHelper(this.Handlebars);

            //this.Handlebars.RegisteredDocumentationHelper();
            //this.Handlebars.RegisterTypeNameHelper();
            //this.Handlebars.RegisterStructuralFeatureHelper();
        }

        /// <summary>
        /// Register the code templates
        /// </summary>
        protected override void RegisterTemplates()
        {
            this.RegisterTemplate("core-poco-interface-template");
            this.RegisterTemplate("core-poco-class-template");
        }
    }
}