﻿// -------------------------------------------------------------------------------------------------
//  <copyright file="HtmlReportCommand.cs" company="Starion Group S.A.">
// 
//    Copyright (C) 2019-2025 Starion Group S.A.
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

namespace uml4net.Tools.Commands
{
    using System.CommandLine;
    using System.CommandLine.Invocation;
    using System.IO;

    using uml4net.Reporting.Generators;

    /// <summary>
    /// The <see cref="HtmlReportCommand"/> that generates an HTML report
    /// </summary>
    public class HtmlReportCommand : ReportCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlReportCommand"/>
        /// </summary>
        public HtmlReportCommand() : base("html-report", "Generates a html report of the UML model")
        {
            var reportFileOption = new Option<FileInfo>(
                name: "--output-report",
                description: "The path to the html report file. Supported extensions are '.html'",
                getDefaultValue: () => new FileInfo("html-report.html"));
            
            reportFileOption.AddAlias("-o");
            reportFileOption.IsRequired = true;
            this.AddOption(reportFileOption);

            var eaUsage = new Option<bool>(name: "--use-eareader", description: "Use the Enterprise Architect Reader.");
            eaUsage.AddAlias("-ea");
            this.AddOption(eaUsage);
        }

        /// <summary>
        /// The Command Handler of the <see cref="HtmlReportCommand"/>
        /// </summary>
        public new class Handler : ReportHandler, ICommandHandler
        {
            /// <summary>
            /// Initializes a nwe instance of the <see cref="Handler"/> class.
            /// </summary>
            /// <param name="htmlReportGenerator">
            /// The (injected) <see cref="IHtmlReportGenerator"/> that is used to generate the
            /// excel report
            /// </param>
            public Handler(IHtmlReportGenerator htmlReportGenerator) : base(htmlReportGenerator)
            {
            }
        }
    }
}
