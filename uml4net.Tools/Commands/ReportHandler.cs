// -------------------------------------------------------------------------------------------------
//  <copyright file="ReportHandler.cs" company="Starion Group S.A.">
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

namespace uml4net.Tools.Commands
{
    using System;
    using System.Collections.Generic;
    using System.CommandLine;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    using Spectre.Console;

    using uml4net.Reporting.Generators;
    using uml4net.Tools.Resources;
    using uml4net.Tools.Services;

    /// <summary>
    /// Abstract super class from which all Report <see cref="ReportHandler"/>s need to derive
    /// </summary>
    public abstract class ReportHandler
    {
        /// <summary>
        /// The PathMap dictionary from which path maps can be resolved
        /// </summary>
        private readonly Dictionary<string, string> pathMap = [];

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportHandler"/>
        /// </summary>
        /// <param name="reportGenerator">
        /// The <see cref="IReportGenerator"/> used to generate a UML report
        /// </param>
        /// <param name="versionChecker">
        /// The <see cref="IVersionChecker"/> used to check the github version
        /// </param>
        protected ReportHandler(IReportGenerator reportGenerator, IVersionChecker versionChecker)
        {
            this.ReportGenerator = reportGenerator ?? throw new ArgumentNullException(nameof(reportGenerator));
            this.VersionChecker = versionChecker;
        }

        /// <summary>
        /// The <see cref="IReportGenerator"/> used to generate a UML report
        /// </summary>
        public IReportGenerator ReportGenerator { get; private set; }

        /// <summary>
        /// The <see cref="IVersionChecker"/> used to check the github version
        /// </summary>
        public IVersionChecker VersionChecker { get; private set; }

        /// <summary>
        /// The value indicating whether the logo should be shown or not
        /// </summary>
        private bool noLogo;

        /// <summary>
        /// The <see cref="FileInfo"/> where the UML model is located that is to be read
        /// </summary>
        private FileInfo inputModel;

        /// <summary>
        /// The unique identifier of the root package to report on
        /// </summary>
        private string rootPackageXmiId;

        /// <summary>
        /// The name of the root package to report on
        /// </summary>
        private string rootPackageName;

        /// <summary>
        /// The pathmap string
        /// </summary>
        private string[] pathMaps = [];

        /// <summary>
        /// The <see cref="FileInfo"/> where the inspection report is to be generated
        /// </summary>
        private FileInfo outputReport;

        /// <summary>
        /// The value indicating whether the generated report needs to be automatically be
        /// opened once generated.
        /// </summary>
        private bool autoOpenReport;

        /// <summary>
        /// A value indicating whether to use strict reading.
        /// </summary>
        /// <remarks>
        /// When Strict Reading is set to true the reader will throw an exception if it encounters an unknown element or attribute.
        /// Otherwise, it will ignore the unknown element or attribute and log a warning.
        /// </remarks>
        private bool useStrictReading;

        /// <summary>
        /// Asynchronously invokes the <see cref="ReportHandler"/>
        /// </summary>
        /// <param name="parseResult">
        /// The <see cref="ParseResult"/> that carries the parsed command line arguments
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used to cancel the operation
        /// </param>
        /// <returns>
        /// 0 when successful, another if not
        /// </returns>
        public async Task<int> InvokeAsync(ParseResult parseResult, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            await this.VersionChecker.ExecuteAsync(cancellationToken);

            this.ProcessParseResult(parseResult);

            if (!this.InputValidation())
            {
                return -1;
            }

            var isValidExtension = this.ReportGenerator.IsValidReportExtension(this.outputReport);
            if (!isValidExtension.Item1)
            {
                AnsiConsole.WriteLine("");
                AnsiConsole.MarkupLine($"[red] {isValidExtension.Item2} [/]");
                AnsiConsole.MarkupLine($"[purple]{this.inputModel.FullName}[/]");
                AnsiConsole.WriteLine("");
                return -1;
            }
            
            try
            {
                await AnsiConsole.Status()
                    .AutoRefresh(true)
                    .SpinnerStyle(Style.Parse("green bold"))
                    .Start($"Preparing Warp Engines for {this.ReportGenerator.QueryReportType()} reporting...", ctx =>
                    {
                        AnsiConsole.WriteLine();
                        AnsiConsole.MarkupLine("[yellow]Initializing report parameters...[/]");
                        AnsiConsole.WriteLine();
                        AnsiConsole.MarkupLine($"[green] --no-logo: {Markup.Escape(this.noLogo.ToString(CultureInfo.CurrentCulture))}[/]");
                        AnsiConsole.MarkupLine($"[green] --input-model: {Markup.Escape(this.inputModel.Name)}[/]");
                        AnsiConsole.MarkupLine($"[green] --auto-open-report: {Markup.Escape(this.autoOpenReport.ToString(CultureInfo.CurrentCulture))}[/]");
                        AnsiConsole.MarkupLine($"[green] --use-strict-reading: {Markup.Escape(this.useStrictReading.ToString(CultureInfo.CurrentCulture))}[/]");
                        AnsiConsole.WriteLine();
                        Task.Delay(500);

                        ctx.Status("[yellow]Generating UML Model report...[/]");
                        AnsiConsole.WriteLine();
                        Task.Delay(1000);
                        
                        this.ReportGenerator.GenerateReport(this.inputModel, this.inputModel.Directory, this.rootPackageXmiId, this.rootPackageName, this.useStrictReading, this.pathMap,this.outputReport);

                        AnsiConsole.MarkupLine($"[grey]LOG:[/] UML {this.ReportGenerator.QueryReportType()} report generated at [bold]{this.outputReport.FullName}[/]");
                        AnsiConsole.WriteLine();

                        this.ExecuteAutoOpen(ctx);

                        ctx.Status("[green]Dropping to impulse speed[/]");
                        Task.Delay(500);
                        
                        return Task.FromResult(0);
                    });
            }
            catch (IOException ex)
            {
                AnsiConsole.WriteLine();
                AnsiConsole.MarkupLine("[red]The report file could not be generated or opened. Make sure the file is not open and try again.[/]");
                AnsiConsole.WriteLine();
                AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
                AnsiConsole.WriteLine();
                AnsiConsole.MarkupLine("[green]Dropping to impulse speed[/]");
                AnsiConsole.WriteLine();
            }
            catch (Exception ex)
            {
                AnsiConsole.WriteLine();
                AnsiConsole.MarkupLine("[red]An exception occurred[/]");
                AnsiConsole.MarkupLine("[green]Dropping to impulse speed[/]");
                AnsiConsole.MarkupLine("[red]please report an issue at[/]");
                AnsiConsole.MarkupLine("[link] https://github.com/STARIONGROUP/uml4net/issues [/]");
                AnsiConsole.WriteLine();
                AnsiConsole.WriteException(ex);

                return -1;
            }

            return 0;
        }

        /// <summary>
        /// Process the <see cref="ParseResult"/> and set to the associated properties
        /// </summary>
        /// <param name="parseResult">
        /// The instance of <see cref="ParseResult"/> that contains the parsed commandline arguments
        /// </param>
        private void ProcessParseResult(ParseResult parseResult)
        {
            this.noLogo = parseResult.GetValue<bool>("--no-logo");
            this.inputModel = parseResult.GetValue<FileInfo>("--input-model");
            this.pathMaps = parseResult.GetValue<string[]>("--pathmaps");
            this.autoOpenReport = parseResult.GetValue<bool>("--auto-open-report");
            this.useStrictReading = parseResult.GetValue<bool>("--use-strict-reading");
            this.rootPackageXmiId = parseResult.GetValue<string>("--root-package-xmi-id");
            this.rootPackageName = parseResult.GetValue<string>("--root-package-name");
            this.outputReport = parseResult.GetValue<FileInfo>("--output-report");
        }

        /// <summary>
        /// validates the options
        /// </summary>
        /// <returns>
        /// 0 when successful, -1 when not
        /// </returns>
        protected bool InputValidation()
        {
            if (!this.noLogo)
            {
                AnsiConsole.Markup($"[blue]{ResourceLoader.QueryLogo()}[/]");
            }

            if (!this.inputModel.Exists)
            {
                AnsiConsole.WriteLine("");
                AnsiConsole.MarkupLine($"[red]The specified input UML model does not exist[/]");
                AnsiConsole.MarkupLine($"[purple]{this.inputModel.FullName}[/]");
                AnsiConsole.WriteLine("");
                return false;
            }

            foreach (var pair in this.pathMaps)
            {
                var parts = pair.Split('=', 2);
                if (parts.Length != 2)
                {
                    continue;
                }

                if (!Path.Exists(parts[1]))
                {
                    AnsiConsole.WriteLine("");
                    AnsiConsole.MarkupLine($"[red]The specified Path Map does not exist[/]");
                    AnsiConsole.MarkupLine($"[purple]{pair}[/]");
                    AnsiConsole.WriteLine("");
                    return false;
                }

                this.pathMap[parts[0]] = parts[1];
            }

            if (string.IsNullOrEmpty(this.rootPackageXmiId) && string.IsNullOrEmpty(this.rootPackageName))
            {
                AnsiConsole.WriteLine("");
                AnsiConsole.MarkupLine($"[red]Both xmi-id and root-namespace are empty. Provide at least one[/]");
                AnsiConsole.WriteLine("");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Automatically opens the generated report
        /// </summary>
        /// <param name="ctx">
        /// Spectre Console <see cref="StatusContext"/>
        /// </param>
        protected void ExecuteAutoOpen(StatusContext ctx)
        {
            if (this.autoOpenReport)
            {
                ctx.Status("Opening generated report");
                Thread.Sleep(1500);

                try
                {
                    Process.Start(new ProcessStartInfo(this.outputReport.FullName)
                    { UseShellExecute = true });
                    ctx.Status("Generated report opened");
                }
                catch
                {
                    ctx.Status("Opening of generated report failed, please open manually");
                    Thread.Sleep(1500);
                }
            }
        }
    }
}
