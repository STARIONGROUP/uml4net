// -------------------------------------------------------------------------------------------------
//  <copyright file="MarkdownReportCommandTestFixture.cs" company="Starion Group S.A.">
// 
//    Copyright (C) 2019-2026 Starion Group S.A.
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

namespace uml4net.Tools.Tests.Commands
{
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.CommandLine;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using uml4net.Reporting.Generators;
    using uml4net.Tools.Commands;
    using uml4net.Tools.Services;

    /// <summary>
    /// Suite of tests for the <see cref="MarkdownReportCommand"/> class.
    /// </summary>
    [TestFixture]
    public class MarkdownReportCommandTestFixture
    {
        private RootCommand rootCommand;

        private Mock<IMarkdownReportGenerator> markdownReportGenerator;

        private Mock<IVersionChecker> versionChecker;

        private MarkdownReportCommand.Handler handler;

        private CancellationTokenSource cts;

        [SetUp]
        public void SetUp()
        {
            this.cts = new CancellationTokenSource();

            var reportCommand = new MarkdownReportCommand();
            this.rootCommand = new RootCommand();
            this.rootCommand.Add(reportCommand);

            this.markdownReportGenerator = new Mock<IMarkdownReportGenerator>();
            this.versionChecker = new Mock<IVersionChecker>();

            this.markdownReportGenerator.Setup(x => x.IsValidReportExtension(It.IsAny<FileInfo>()))
                .Returns(new Tuple<bool, string>(true, "valid extension"));

            this.handler = new MarkdownReportCommand.Handler(this.markdownReportGenerator.Object, this.versionChecker.Object);
        }

        [Test]
        public void Verify_that_inspect_command_can_be_constructed()
        {
            Assert.That(() =>
            {
                var markdownReportCommand = new MarkdownReportCommand();
            }, Throws.Nothing);
        }

        [Test]
        public async Task Verify_that_InvokeAsync_returns_0()
        {
            var args = new[]
            {
                "md-report",
                "--no-logo",
                "--input-model", Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "UML.xmi"),
                "--output-report", Path.Combine(TestContext.CurrentContext.TestDirectory, "md-report.md"),
                "--root-package-xmi-id", "_0",
                "--root-package-name", "UML"
            };

            var parseResult = this.rootCommand.Parse(args);

            var result = await this.handler.InvokeAsync(parseResult, this.cts.Token);

            this.markdownReportGenerator.Verify(x => x.GenerateReport(It.IsAny<FileInfo>(), It.IsAny<DirectoryInfo>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<Dictionary<string, string>>(), It.IsAny<FileInfo>(), It.IsAny<String>()),
                Times.Once);

            this.versionChecker.Verify(x => x.ExecuteAsync(It.IsAny<CancellationToken>()), Times.Once);

            Assert.That(result, Is.EqualTo(0), "InvokeAsync should return 0 upon success.");
        }

        [Test]
        public async Task Verify_that_when_the_input_ecore_model_does_not_exists_returns_not_0()
        {
            var args = new[]
            {
                "md-report",
                "--no-logo",
                "--input-model", Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "non-existent.xmi"),
                "--output-report", Path.Combine(TestContext.CurrentContext.TestDirectory, "md-report.md"),
            };

            var parseResult = this.rootCommand.Parse(args);

            var result = await this.handler.InvokeAsync(parseResult, this.cts.Token);

            Assert.That(result, Is.EqualTo(-1), "InvokeAsync should return -1 upon failure.");
        }

        [Test]
        public async Task Verify_that_when_the_output_extensions_is_not_supported_returns_not_0()
        {
            var args = new[]
            {
                "md-report",
                "--no-logo",
                "--input-model", Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "UML.xmi"),
            };

            var parseResult = this.rootCommand.Parse(args);

            this.markdownReportGenerator.Setup(x => x.IsValidReportExtension(It.IsAny<FileInfo>()))
                .Returns(new Tuple<bool, string>(false, "invalid extension"));

            var result = await this.handler.InvokeAsync(parseResult, this.cts.Token);

            Assert.That(result, Is.EqualTo(-1), "InvokeAsync should return -1 upon failure.");
        }

        [Test]
        public async Task Verify_that_when_operation_cancelled_OperationCanceledException_is_thrown()
        {
            var args = new[]
            {
                "html-report",
                "--no-logo",
                "--input-model", Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "UML.xmi"),
                "--root-package-xmi-id", "_0",
                "--root-package-name", "UML"
            };

            var parseResult = this.rootCommand.Parse(args);

            await this.cts.CancelAsync();

            await Assert.ThatAsync(() => this.handler.InvokeAsync(parseResult, this.cts.Token),
                Throws.TypeOf<OperationCanceledException>());
        }
    }
}
