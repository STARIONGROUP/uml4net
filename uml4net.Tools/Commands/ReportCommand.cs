// -------------------------------------------------------------------------------------------------
// <copyright file="ReportCommand.cs" company="Starion Group S.A.">
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

    using Serilog.Events;

    /// <summary>
    /// Abstract super class from which all report commands shall inherit
    /// </summary>
    public abstract class ReportCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportCommand"/>
        /// </summary>
        /// <param name="name">The name of the command.</param>
        /// <param name="description">The description of the command, shown in help.</param>
        protected ReportCommand(string name, string description = null) : base(name, description)
        {
            var noLogoOption = new Option<bool>(name: "--no-logo")
            {
                Description = "Suppress the logo",
                DefaultValueFactory = parseResult => false
            };
            noLogoOption.AcceptOnlyFromAmong("Verbose", "Debug", "Information", "Warning", "Error", "Fatal");

            this.Options.Add(noLogoOption);

            var logLevelOption = new Option<LogEventLevel>("--log-level")
            {
                Description = "Sets the logging level (Trace, Debug, Information, Warning, Error, Critical)",
                Required = false,
                DefaultValueFactory = parseResult => LogEventLevel.Information
            };

            this.Options.Add(logLevelOption);

            var inputModelFileOption = new Option<FileInfo>(name: "--input-model")
            {
                Description = "The path to the UML XMI file",
                DefaultValueFactory = parseResult => new FileInfo("model.xmi"),
                Required = true
            };
    
            inputModelFileOption.Aliases.Add("-i");

            this.Options.Add(inputModelFileOption);

            var pathMaps = new Option<string[]>(name: "--pathmaps")
            {
                Description = "Add pathmap key-value pairs",
                AllowMultipleArgumentsPerToken = true
            };
            pathMaps.Aliases.Add("-m");
            
            this.Options.Add(pathMaps);

            var autoOpenReportOption = new Option<bool>(name: "--auto-open-report")
            {
                Description = "Open the generated report with its default application",
                DefaultValueFactory = parseResult => false,
                Required = true
            };

            autoOpenReportOption.Aliases.Add("-a");

            this.Options.Add(autoOpenReportOption);

            var useStrictReadingOption = new Option<bool>(name: "--use-strict-reading")
            {
                Description = "When Strict Reading is set to true the reader will throw an exception if it encounters an unknown element or attribute. Otherwise, it will ignore the unknown element or attribute and log a warning.",
                DefaultValueFactory = parseResult => true,
                Required = false
            };
            useStrictReadingOption.Aliases.Add("-s");

            this.Options.Add(useStrictReadingOption);

            var xmiIdOption = new Option<string>(name: "--root-package-xmi-id")
            {
                Description = "The unique identifier of the of the root package to report on",
                DefaultValueFactory = parseResult => "",
                Required = false
            };

            xmiIdOption.Aliases.Add("-rmi");

            this.Options.Add(xmiIdOption);

            var rootPackageNameOption = new Option<string>(name: "--root-package-name")
            {
                Description = "The name of the of the root package to report on",
                DefaultValueFactory = parseResult => "",
                Required = false
            };

            rootPackageNameOption.Aliases.Add("-rn");

            this.Options.Add(rootPackageNameOption);
        }
    }
}
