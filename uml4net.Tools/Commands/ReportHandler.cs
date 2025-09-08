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
    using System.CommandLine.Invocation;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    using uml4net.Reporting.Generators;
    using uml4net.Tools.Resources;

    using Spectre.Console;

    /// <summary>
    /// Abstract super class from which all Report <see cref="ICommandHandler"/>s need to derive
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
        protected ReportHandler(IReportGenerator reportGenerator)
        {
            this.ReportGenerator = reportGenerator ?? throw new ArgumentNullException(nameof(reportGenerator));
        }

        /// <summary>
        /// Gets or sets the <see cref="IReportGenerator"/> used to generate a UML report
        /// </summary>
        public IReportGenerator ReportGenerator { get; private set; }

        /// <summary>
        /// Gets or sets the value indicating whether the logo should be shown or not
        /// </summary>
        public bool NoLogo { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="FileInfo"/> where the UML model is located that is to be read
        /// </summary>
        public FileInfo InputModel { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the root package to report on
        /// </summary>
        public string RootPackageXmiId { get; set; }

        /// <summary>
        /// Gets or sets the name of the root package to report on
        /// </summary>
        public string RootPackageName { get; set; }

        /// <summary>
        /// Gets or sets the pathmap string
        /// </summary>
        public string[] PathMaps { get; set; } = [];

        /// <summary>
        /// Gets or sets the <see cref="FileInfo"/> where the inspection report is to be generated
        /// </summary>
        public FileInfo OutputReport { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the generated report needs to be automatically be
        /// opened once generated.
        /// </summary>
        public bool AutoOpenReport { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use strict reading.
        /// </summary>
        /// <remarks>
        /// When Strict Reading is set to true the reader will throw an exception if it encounters an unknown element or attribute.
        /// Otherwise, it will ignore the unknown element or attribute and log a warning.
        /// </remarks>
        public bool UseStrictReading { get; set; }
        
        /// <summary>
        /// Asserts that the reader to be used should be the Enterprise Architect extension one
        /// </summary>
        public bool UseEaReader { get; set; }

        /// <summary>
        /// Invokes the <see cref="ICommandHandler"/>
        /// </summary>
        /// <param name="context">
        /// The <see cref="InvocationContext"/> 
        /// </param>
        /// <returns>
        /// 0 when successful, another if not
        /// </returns>
        public int Invoke(InvocationContext context)
        {
            throw new NotSupportedException("Please use InvokeAsync");
        }

        /// <summary>
        /// Asynchronously invokes the <see cref="ICommandHandler"/>
        /// </summary>
        /// <param name="context">
        /// The <see cref="InvocationContext"/> 
        /// </param>
        /// <returns>
        /// 0 when successful, another if not
        /// </returns>
        public async Task<int> InvokeAsync(InvocationContext context)
        {
            if (!this.InputValidation())
            {
                return -1;
            }

            var isValidExtension = this.ReportGenerator.IsValidReportExtension(this.OutputReport);
            if (!isValidExtension.Item1)
            {
                AnsiConsole.WriteLine("");
                AnsiConsole.MarkupLine($"[red] {isValidExtension.Item2} [/]");
                AnsiConsole.MarkupLine($"[purple]{this.InputModel.FullName}[/]");
                AnsiConsole.WriteLine("");
                return -1;
            }
            
            try
            {
                this.ReportGenerator.ShouldUseEnterpriseArchitectReader = this.UseEaReader;
                
                await AnsiConsole.Status()
                    .AutoRefresh(true)
                    .SpinnerStyle(Style.Parse("green bold"))
                    .Start($"Preparing Warp Engines for {this.ReportGenerator.QueryReportType()} reporting...", ctx =>
                    {
                        AnsiConsole.WriteLine();
                        AnsiConsole.MarkupLine("[yellow]Initializing report parameters...[/]");
                        AnsiConsole.WriteLine();
                        AnsiConsole.MarkupLine($"[green] --no-logo: {Markup.Escape(this.NoLogo.ToString(CultureInfo.CurrentCulture))}[/]");
                        AnsiConsole.MarkupLine($"[green] --input-model: {Markup.Escape(this.InputModel.Name)}[/]");
                        AnsiConsole.MarkupLine($"[green] --auto-open-report: {Markup.Escape(this.AutoOpenReport.ToString(CultureInfo.CurrentCulture))}[/]");
                        AnsiConsole.MarkupLine($"[green] --use-strict-reading: {Markup.Escape(this.UseStrictReading.ToString(CultureInfo.CurrentCulture))}[/]");
                        AnsiConsole.WriteLine();
                        Task.Delay(500);

                        ctx.Status("[yellow]Generating UML Model report...[/]");
                        AnsiConsole.WriteLine();
                        Task.Delay(1000);
                        
                        this.ReportGenerator.GenerateReport(this.InputModel, this.InputModel.Directory, this.RootPackageXmiId, this.RootPackageName, this.UseStrictReading, this.pathMap,this.OutputReport);

                        AnsiConsole.MarkupLine($"[grey]LOG:[/] UML {this.ReportGenerator.QueryReportType()} report generated at [bold]{this.OutputReport.FullName}[/]");
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
        /// validates the options
        /// </summary>
        /// <returns>
        /// 0 when successful, -1 when not
        /// </returns>
        protected bool InputValidation()
        {
            if (!this.NoLogo)
            {
                AnsiConsole.Markup($"[blue]{ResourceLoader.QueryLogo()}[/]");
            }

            if (!this.InputModel.Exists)
            {
                AnsiConsole.WriteLine("");
                AnsiConsole.MarkupLine($"[red]The specified input UML model does not exist[/]");
                AnsiConsole.MarkupLine($"[purple]{this.InputModel.FullName}[/]");
                AnsiConsole.WriteLine("");
                return false;
            }

            foreach (var pair in this.PathMaps)
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

            if (string.IsNullOrEmpty(this.RootPackageXmiId) && string.IsNullOrEmpty(this.RootPackageName))
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
            if (this.AutoOpenReport)
            {
                ctx.Status("Opening generated report");
                Thread.Sleep(1500);

                try
                {
                    Process.Start(new ProcessStartInfo(this.OutputReport.FullName)
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
