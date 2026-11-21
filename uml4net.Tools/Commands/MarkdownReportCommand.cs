// -------------------------------------------------------------------------------------------------
// <copyright file="MarkdownReportCommand.cs" company="Starion Group S.A.">
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
    /// The <see cref="MarkdownReportCommand"/> that generates a Markdown report
    /// </summary>
    public class MarkdownReportCommand : ReportCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MarkdownReportCommand"/>
        /// </summary>
        public MarkdownReportCommand() : base("md-report", "Generates a Markdown report of the UML model")
        {
            var reportFileOption = new Option<FileInfo>(name: "--output-report")
            {
                Description = "The path to the markdown report file. Supported extensions are '.md'",
                DefaultValueFactory = parseResult => new FileInfo("md-report.md"),
                Required = true
            };

            reportFileOption.Aliases.Add("-o");

            this.Options.Add(reportFileOption);
        }

        /// <summary>
        /// The Command Handler of the <see cref="MarkdownReportCommand"/>
        /// </summary>
        public class Handler : ReportHandler
        {
            /// <summary>
            /// Initializes a nwe instance of the <see cref="Handler"/> class.
            /// </summary>
            /// <param name="markdownReportGenerator">
            /// The (injected) <see cref="IMarkdownReportGenerator"/> that is used to generate the
            /// excel report
            /// </param>
            /// <param name="versionChecker">
            /// The <see cref="IVersionChecker"/> used to check the github version
            /// </param>
            public Handler(IMarkdownReportGenerator markdownReportGenerator, IVersionChecker versionChecker)
                : base(markdownReportGenerator, versionChecker)
            {
            }
        }
    }
}
