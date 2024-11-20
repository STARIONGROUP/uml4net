// -------------------------------------------------------------------------------------------------
//  <copyright file="HandleBarsReportGenerator.cs" company="Starion Group S.A.">
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

namespace uml4net.Reporting.Generators
{
    using System.Collections.Generic;
    using System.Linq;
    using Extensions;
    using HandlebarsDotNet;
    using HandlebarsDotNet.Helpers;

    using Microsoft.Extensions.Logging;

    using uml4net.POCO.Packages;
    using uml4net.POCO.StructuredClassifiers;
    using uml4net.POCO.SimpleClassifiers;

    using uml4net.Reporting.Payload;
    using uml4net.Reporting.Resources;
    using uml4net.xmi.Readers;
    using uml4net.HandleBars;

    /// <summary>
    /// Abstract super class from which all <see cref="HandlebarsDotNet"/> generators
    /// need to derive
    /// </summary>
    public abstract class HandleBarsReportGenerator : ReportGenerator
    {
        /// <summary>
        /// The <see cref="IHandlebars"/> instance used to generate code with
        /// </summary>
        protected IHandlebars Handlebars;

        /// <summary>
        /// Initializes a new instance of the <see cref="HandleBarsReportGenerator"/> class
        /// </summary>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        protected HandleBarsReportGenerator(ILoggerFactory loggerFactory = null) : base(loggerFactory)
        {
            this.Templates = new Dictionary<string, HandlebarsTemplate<object, object>>();

            this.Handlebars = HandlebarsDotNet.Handlebars.CreateSharedEnvironment();
            HandlebarsHelpers.Register(Handlebars);

            this.RegisterHelpers();
            this.RegisterTemplates();
        }

        /// <summary>
        /// Gets the registered <see cref="HandlebarsTemplate{TContext,TData}"/>
        /// </summary>
        public Dictionary<string, HandlebarsTemplate<object, object>> Templates { get; private set; }

        /// <summary>
        /// Register the custom helpers
        /// </summary>
        protected virtual void RegisterHelpers()
        {
            uml4net.HandleBars.StringHelper.RegisterStringHelper(this.Handlebars);
            uml4net.HandleBars.IEnumerableHelper.RegisterEnumerableHelper(this.Handlebars);
            uml4net.HandleBars.ClassHelper.RegisterClassHelper(this.Handlebars);
            uml4net.HandleBars.PropertyHelper.RegisterPropertyHelper(this.Handlebars);
            uml4net.HandleBars.GeneralizationHelper.RegisterGeneralizationHelper(this.Handlebars);
            uml4net.HandleBars.DocumentationHelper.RegisteredDocumentationHelper(this.Handlebars);
        }

        /// <summary>
        /// Register the code templates
        /// </summary>
        protected abstract void RegisterTemplates();

        /// <summary>
        /// Register handle-bars templates based on the template (file) name (without extension)
        /// </summary>
        /// <param name="name">
        /// (file) name (without extension)
        /// </param>
        protected void RegisterEmbeddedTemplate(string name)
        {
            var templatePath = $"uml4net.Reporting.Templates.{name}.hbs";

            var template = ResourceLoader.LoadEmbeddedResource(templatePath);

            var compiledTemplate = Handlebars.Compile(template);

            this.Templates.Add(name, compiledTemplate);
        }

        /// <summary>
        /// Creates a <see cref="HandlebarsPayload"/> based on the provided root <see cref="XmiReaderResult"/>
        /// </summary>
        /// <param name="xmiReaderResult">
        /// the subject <see cref="XmiReaderResult"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="HandlebarsPayload"/>
        /// </returns>
        protected static HandlebarsPayload CreateHandlebarsPayload(XmiReaderResult xmiReaderResult)
        {
            var enumerations = new List<IEnumeration>();
            var primitiveTypes = new List<IPrimitiveType>();
            var dataTypes = new List<IDataType>();
            var classes = new List<IClass>();
            var interfaces = new List<IInterface>();

            foreach (var package in xmiReaderResult.Packages)
            {
                var containedPackages = package.QueryPackages();

                foreach (var containedPackage in containedPackages)
                {
                    enumerations.AddRange(containedPackage.PackagedElement.OfType<IEnumeration>());

                    primitiveTypes.AddRange(containedPackage.PackagedElement.OfType<IPrimitiveType>());

                    dataTypes.AddRange(containedPackage.PackagedElement
                        .OfType<IDataType>()
                        .Where(x => x is not IEnumeration && x is not IPrimitiveType));

                    classes.AddRange(containedPackage.PackagedElement.OfType<IClass>());

                    interfaces.AddRange(containedPackage.PackagedElement.OfType<IInterface>());
                }
            }

            var orderedEnumerations = enumerations.OrderBy(x => x.Name);
            var orderedPrimitiveTypes = primitiveTypes.OrderBy(x => x.Name);
            var orderedDataTypes = dataTypes.OrderBy(x => x.Name);
            var orderedClasses = classes.OrderBy(x => x.Name);
            var orderedInterfaces = interfaces.OrderBy(x => x.Name);

            var payload = new HandlebarsPayload(xmiReaderResult.Root, xmiReaderResult.Packages, orderedEnumerations, orderedPrimitiveTypes, orderedDataTypes, orderedClasses, orderedInterfaces);

            return payload;
        }
    }
}