// -------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Starion Group S.A">
// 
//   Copyright (C) 2019-2025 Starion Group S.A.
// 
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Tools
{
    using System.CommandLine;
    using System.CommandLine.Builder;
    using System.CommandLine.Help;
    using System.CommandLine.Hosting;
    using System.CommandLine.Parsing;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Hosting;

    using Serilog;
    using Serilog.Events;

    using Spectre.Console;

    using uml4net.Reporting.Drawing;
    using uml4net.Reporting.Generators;
    using uml4net.Tools.Commands;
    using uml4net.Tools.Middlewares;
    using uml4net.Tools.Resources;

    /// <summary>
    /// Main entry point for the command line application
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class Program
    {
        /// <summary>
        /// log level option
        /// </summary>
        private static readonly Option<LogLevel> LogLevelOption = new(
            new[] { "--log-level", "-ll" },
            getDefaultValue: () => LogLevel.None,
            description: "Specifies minimum logging level. Accepted values: Trace, Debug, Information, Warning, Error, Critical, None.");

        /// <summary>
        /// Main entry point for the command line application
        /// </summary>
        /// <param name="args">
        /// command line arguments
        /// </param>
        public static int Main(string[] args)
        {
            var commandLineBuilder = BuildCommandLine()
                .UseHost(_ => Host.CreateDefaultBuilder(args)
                        .ConfigureLogging((context, loggingBuilder) =>
                        {
                            var invocation = context.GetInvocationContext();
                            var parsedLevel = invocation.ParseResult.GetValueForOption(LogLevelOption);

                            loggingBuilder.ClearProviders();

                            var template =
                                "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}] [{Level:u3}] ({SourceContext}) {Message:lj}{NewLine}{Exception}";

                            var loggerConfig = new LoggerConfiguration()
                                .Enrich.FromLogContext()
                                .MinimumLevel.Is(Map(parsedLevel))
                                .WriteTo.File("uml4net.logs",
                                    rollingInterval: RollingInterval.Day,
                                    outputTemplate: template);

                            var serilogLogger = loggerConfig.CreateLogger();
                            loggingBuilder.AddSerilog(serilogLogger, dispose: true);

                            loggingBuilder.SetMinimumLevel(parsedLevel);
                        })
                    , builder => builder
                        .ConfigureServices((services) =>
                        {
                            services.AddSingleton<IInheritanceDiagramRenderer, InheritanceDiagramRenderer>();
                            services.AddSingleton<IXlReportGenerator, XlReportGenerator>();
                            services.AddSingleton<IModelInspector, ModelInspector>();
                            services.AddSingleton<IHtmlReportGenerator, HtmlReportGenerator>();
                            services.AddSingleton<IMarkdownReportGenerator, MarkdownReportGenerator>();

                        })
                        .UseCommandHandler<XlReportCommand, XlReportCommand.Handler>()
                        .UseCommandHandler<ModelInspectionCommand, ModelInspectionCommand.Handler>()
                        .UseCommandHandler<HtmlReportCommand, HtmlReportCommand.Handler>()
                        .UseCommandHandler<MarkdownReportCommand, MarkdownReportCommand.Handler>()
                    )
                .UseDefaults()

                .Build();

            return commandLineBuilder.Invoke(args);
        }

        /// <summary>
        /// builds the root command
        /// </summary>
        /// <returns>
        /// The <see cref="CommandLineBuilder"/> with the root command set
        /// </returns>
        private static CommandLineBuilder BuildCommandLine()
        {
            var root = CreateCommandChain();

            return new CommandLineBuilder(root)
                .UseHelp(ctx =>
                {
                    ctx.HelpBuilder.CustomizeLayout(_ =>
                        HelpBuilder.Default
                            .GetLayout()
                            .Skip(1) // Skip the default command description section.
                            .Prepend(
                                _ =>
                                {
                                    AnsiConsole.Markup($"[blue]{ResourceLoader.QueryLogo()}[/]");
                                }
                            ));
                })
                .UseVersionChecker();
        }

        /// <summary>
        /// Creates the root and sub commands
        /// </summary>
        /// <returns>
        /// returns an instance of <see cref="RootCommand"/>
        /// </returns>
        private static RootCommand CreateCommandChain()
        {
            var root = new RootCommand("uml4net Tools");
            root.AddGlobalOption(LogLevelOption);

            var reportCommand = new XlReportCommand();
            root.AddCommand(reportCommand);

            var modelInspectionCommand = new ModelInspectionCommand();
            root.AddCommand(modelInspectionCommand);

            var htmlReportCommand = new HtmlReportCommand();
            root.AddCommand(htmlReportCommand);

            var markdownReportCommand = new MarkdownReportCommand();
            root.AddCommand(markdownReportCommand);

            return root;
        }

        /// <summary>
        /// Maps a microsoft <see cref="LogLevel"/> to a serilog <see cref="LogEventLevel"/>
        /// </summary>
        /// <param name="lvl">
        /// microsoft <see cref="LogLevel"/> that is to be mapped
        /// </param>
        /// <returns>
        /// the mapped (resulting) serilog <see cref="LogEventLevel"/>
        /// </returns>
        private static LogEventLevel Map(LogLevel lvl) => lvl switch
        {
            LogLevel.Trace => LogEventLevel.Verbose,
            LogLevel.Debug => LogEventLevel.Debug,
            LogLevel.Information => LogEventLevel.Information,
            LogLevel.Warning => LogEventLevel.Warning,
            LogLevel.Error => LogEventLevel.Error,
            LogLevel.Critical => LogEventLevel.Fatal,
            LogLevel.None => LogEventLevel.Information, // pick a sensible default
            _ => LogEventLevel.Information
        };
    }
}
