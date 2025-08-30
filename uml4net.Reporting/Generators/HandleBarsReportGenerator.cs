// -------------------------------------------------------------------------------------------------
//  <copyright file="HandleBarsReportGenerator.cs" company="Starion Group S.A.">
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

namespace uml4net.Reporting.Generators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    using HandlebarsDotNet;
    using HandlebarsDotNet.Helpers;

    using Microsoft.Extensions.Logging;

    using uml4net.Extensions;
    using uml4net.StructuredClassifiers;
    using uml4net.SimpleClassifiers;
    using uml4net.Reporting.Payload;
    using uml4net.Reporting.Resources;
    using uml4net.xmi.Readers;

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
            uml4net.HandleBars.DocumentationHelper.RegisterDocumentationHelper(this.Handlebars);
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
    }
}
