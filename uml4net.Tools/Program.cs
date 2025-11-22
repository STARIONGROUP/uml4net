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
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using Autofac.Extensions.DependencyInjection;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    using Serilog;
    using Serilog.Events;

    using uml4net.Reporting.Drawing;
    using uml4net.Reporting.Generators;
    using uml4net.Tools.Commands;

    /// <summary>
    /// Main entry point for the command line application
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class Program
    {
        /// <summary>
        /// Main entry point for the command line application
        /// </summary>
        /// <param name="args">
        /// command line arguments
        /// </param>
        public static async Task<int> Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            var rootCommand = CreateCommandChain(host);
            
            var parseResult = rootCommand.Parse(args);

            var result = await parseResult.InvokeAsync();

            return result;
        }

        /// <summary>
        /// Creates the <see cref="IHostBuilder"/>
        /// </summary>
        /// <param name="args">
        /// the command line arguments
        /// </param>
        /// <returns>
        /// a configured instance of <see cref="IHostBuilder"/>
        /// </returns>
        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureLogging(loggingBuilder =>
                {
                    loggingBuilder.ClearProviders();
                    var template = "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}] [{Level:u3}] ({SourceContext}) {Message:lj}{NewLine}{Exception}";
                    var loggerConfig = new LoggerConfiguration()
                        .Enrich.FromLogContext()
                        .MinimumLevel.Is(Map(LogLevel.Information))
                        .WriteTo.File("uml4net.logs",
                            rollingInterval: RollingInterval.Day,
                            outputTemplate: template);

                    var serilogLogger = loggerConfig.CreateLogger();
                    loggingBuilder.AddSerilog(serilogLogger, dispose: true);

                    loggingBuilder.SetMinimumLevel(LogLevel.Information);
                })
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IInheritanceDiagramRenderer, InheritanceDiagramRenderer>();
                    services.AddSingleton<IXlReportGenerator, XlReportGenerator>();
                    services.AddSingleton<IModelInspector, ModelInspector>();
                    services.AddSingleton<IHtmlReportGenerator, HtmlReportGenerator>();
                    services.AddSingleton<IMarkdownReportGenerator, MarkdownReportGenerator>();
                });

            return host;
        }

        /// <summary>
        /// Creates the root and sub commands
        /// </summary>
        /// <returns>
        /// returns an instance of <see cref="RootCommand"/>
        /// </returns>
        private static RootCommand CreateCommandChain(IHost host)
        {
            var root = new RootCommand("uml4net Tools");

            var reportCommand = new XlReportCommand();
            reportCommand.SetAction(async parseResult =>
            {
                using var scope = host.Services.CreateScope();
                var generator = scope.ServiceProvider.GetService<IXlReportGenerator>();
                var handler = new XlReportCommand.Handler(generator);
                await handler.InvokeAsync(parseResult);
            });
            root.Add(reportCommand);

            var modelInspectionCommand = new ModelInspectionCommand();
            modelInspectionCommand.SetAction(async parseResult =>
            {
                using var scope = host.Services.CreateScope();
                var generator = scope.ServiceProvider.GetService<IModelInspector>();
                var handler = new ModelInspectionCommand.Handler(generator);
                await handler.InvokeAsync(parseResult);
            });
            root.Add(modelInspectionCommand);

            var htmlReportCommand = new HtmlReportCommand();
            htmlReportCommand.SetAction(async parseResult =>
            {
                using var scope = host.Services.CreateScope();
                var generator = scope.ServiceProvider.GetService<IHtmlReportGenerator>();
                var handler = new HtmlReportCommand.Handler(generator);
                await handler.InvokeAsync(parseResult);
            });
            root.Add(htmlReportCommand);

            var markdownReportCommand = new MarkdownReportCommand();
            markdownReportCommand.SetAction(async parseResult =>
            {
                using var scope = host.Services.CreateScope();
                var generator = scope.ServiceProvider.GetService<IMarkdownReportGenerator>();
                var handler = new MarkdownReportCommand.Handler(generator);
                await handler.InvokeAsync(parseResult);
            });
            root.Add(markdownReportCommand);

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
