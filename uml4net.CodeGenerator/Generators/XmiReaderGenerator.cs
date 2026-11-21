// -------------------------------------------------------------------------------------------------
// <copyright file="XmiReaderGenerator.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

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
        /// <param name="rootPackageXmiId">
        /// the unique identifier of the root package to report in
        /// </param>
        /// <param name="rootPackageName">
        /// the name of the root package to report in
        /// </param>
        /// <param name="outputDirectory">
        /// The target <see cref="DirectoryInfo"/>
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        public override async Task GenerateAsync(XmiReaderResult xmiReaderResult, string rootPackageXmiId, string rootPackageName, DirectoryInfo outputDirectory)
        {
            ArgumentNullException.ThrowIfNull(xmiReaderResult);

            ArgumentNullException.ThrowIfNull(outputDirectory);

            var root = xmiReaderResult.QueryRoot(rootPackageXmiId, rootPackageName);

            var classes = root.QueryPackages()
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
        /// Generates the XmiElementReaderFacade based on the <see cref="IClass"/> instances
        /// that are in the provided <see cref="XmiReaderResult"/>
        /// </summary>
        /// <param name="xmiReaderResult">
        /// the <see cref="XmiReaderResult"/> that contains the UML model to generate from
        /// </param>
        /// <param name="rootPackageXmiId">
        /// the unique identifier of the root package to report in
        /// </param>
        /// <param name="rootPackageName">
        /// the name of the root package to report in
        /// </param>
        /// <param name="outputDirectory">
        /// The target <see cref="DirectoryInfo"/>
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        public async Task GenerateXmiElementReaderFacadeAsync(XmiReaderResult xmiReaderResult, string rootPackageXmiId, string rootPackageName, DirectoryInfo outputDirectory)
        {
            ArgumentNullException.ThrowIfNull(xmiReaderResult);

            ArgumentNullException.ThrowIfNull(outputDirectory);

            var root = xmiReaderResult.QueryRoot(rootPackageXmiId, rootPackageName);

            var classes = root.QueryPackages()
                .SelectMany(x => x.PackagedElement.OfType<IClass>())
                .Where(x => !x.IsAbstract)
                .ToList();

            var template = this.Templates["XmiElementReaderFacade-template"];

            var generatedCode = template(classes);

            generatedCode = this.CodeCleanup(generatedCode);

            const string fileName = "XmiElementReaderFacade.cs";

            await WriteAsync(generatedCode, outputDirectory, fileName);
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
        /// Register the handlebars templates
        /// </summary>
        protected override void RegisterTemplates()
        {
            this.RegisterTemplate("xmi-reader-template");
            this.RegisterTemplate("XmiElementReaderFacade-template");
        }
    }
}
