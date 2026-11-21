// -------------------------------------------------------------------------------------------------
// <copyright file="XlReportCommand.cs" company="Starion Group S.A.">
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
    /// The <see cref="XlReportCommand"/> that generates Excel tabular report of
    /// Classes and Enums
    /// </summary>
    public class XlReportCommand : ReportCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XlReportCommand"/>
        /// </summary>
        public XlReportCommand() : base("excel-report", "Generates a tabular report of the UML model")
        {
            var reportFileOption = new Option<FileInfo>(name: "--output-report")
            {
                Description ="The path to the tabular report file. Supported extensions are '.xlsx', '.xlsm', '.xltx' and '.xltm'",
                DefaultValueFactory = parseResult => new FileInfo("tabular-report.xlsx"),
                Required = true
            };

            reportFileOption.Aliases.Add("-o");
            
            this.Options.Add(reportFileOption);
        }

        /// <summary>
        /// The Command Handler of the <see cref="XlReportCommand"/>
        /// </summary>
        public class Handler : ReportHandler
        {
            /// <summary>
            /// Initializes a nwe instance of the <see cref="Handler"/> class.
            /// </summary>
            /// <param name="xlReportGenerator">
            /// The (injected) <see cref="IXlReportGenerator"/> that is used to generate the
            /// excel report
            /// </param>
            /// <param name="versionChecker">
            /// The <see cref="IVersionChecker"/> used to check the github version
            /// </param>
            public Handler(IXlReportGenerator xlReportGenerator, IVersionChecker versionChecker)
                : base(xlReportGenerator, versionChecker)
            {
            }
        }
    }
}
