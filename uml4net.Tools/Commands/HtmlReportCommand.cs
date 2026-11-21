// -------------------------------------------------------------------------------------------------
// <copyright file="HtmlReportCommand.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Tools.Commands
{
    using System.CommandLine;
    using System.IO;

    using uml4net.Reporting.Generators;
    using uml4net.Tools.Services;

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
            var reportFileOption = new Option<FileInfo>(name: "--output-report")
            {
                Description = "The path to the html report file. Supported extensions are '.html'",
                DefaultValueFactory = parseResult => new FileInfo("html-report.html"),
                Required = true
            };

            reportFileOption.Aliases.Add("-o");

            this.Options.Add(reportFileOption);
        }

        /// <summary>
        /// The Command Handler of the <see cref="HtmlReportCommand"/>
        /// </summary>
        public class Handler : ReportHandler
        {
            /// <summary>
            /// Initializes a nwe instance of the <see cref="Handler"/> class.
            /// </summary>
            /// <param name="htmlReportGenerator">
            /// The (injected) <see cref="IHtmlReportGenerator"/> that is used to generate the
            /// excel report
            /// </param>
            /// <param name="versionChecker">
            /// The <see cref="IVersionChecker"/> used to check the github version
            /// </param>
            public Handler(IHtmlReportGenerator htmlReportGenerator, IVersionChecker versionChecker) 
                : base(htmlReportGenerator, versionChecker)
            {
            }
        }
    }
}
