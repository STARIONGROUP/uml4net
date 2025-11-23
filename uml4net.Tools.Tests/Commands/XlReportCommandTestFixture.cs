// -------------------------------------------------------------------------------------------------
//  <copyright file="XlReportCommandTestFixture.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2025 Starion Group S.A.
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
    using System;
    using System.Collections.Generic;
    using System.CommandLine;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    using Moq;

    using NUnit.Framework;

    using uml4net.Reporting.Generators;
    using uml4net.Tools.Commands;
    using uml4net.Tools.Services;

    /// <summary>
    /// Suite of tests for the <see cref="XlReportCommand"/> class.
    /// </summary>
    [TestFixture]
    public class XlReportCommandTestFixture
    {
        private RootCommand rootCommand;

        private Mock<IXlReportGenerator> xlReportGenerator;

        private Mock<IVersionChecker> versionChecker;

        private XlReportCommand.Handler handler;

        private CancellationTokenSource cts;

        [SetUp]
        public void SetUp()
        {
            this.cts = new CancellationTokenSource();

            var xlReportCommand = new XlReportCommand();
            this.rootCommand = new RootCommand();
            this.rootCommand.Add(xlReportCommand);

            this.xlReportGenerator = new Mock<IXlReportGenerator>();
            this.versionChecker = new Mock<IVersionChecker>();

            this.xlReportGenerator.Setup(x => x.IsValidReportExtension(It.IsAny<FileInfo>()))
                .Returns(new Tuple<bool, string>(true, "valid extension"));

            this.handler = new XlReportCommand.Handler(this.xlReportGenerator.Object, this.versionChecker.Object);
        }

        [Test]
        public void Verify_that_inspect_command_can_be_constructed()
        {
            Assert.That(() =>
            {
                var xlReportCommand = new XlReportCommand();
            }, Throws.Nothing);
        }

        [Test]
        public async Task Verify_that_InvokeAsync_returns_0_for_UML_xmi()
        {
            var args = new[]
            {
                "excel-report",
                "--no-logo",
                "--input-model", Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "UML.xmi"),
                "--output-report","xl-report.xlsx",
                "--root-package-xmi-id", "_0",
                "--root-package-name", "UML"
            };

            var parseResult = this.rootCommand.Parse(args);

            var result = await this.handler.InvokeAsync(parseResult, this.cts.Token);

            this.xlReportGenerator.Verify(x => x.GenerateReport(It.IsAny<FileInfo>(), It.IsAny<DirectoryInfo>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<Dictionary<string, string>>(), It.IsAny<FileInfo>(), It.IsAny<String>()), Times.Once);

            this.versionChecker.Verify(x => x.ExecuteAsync(It.IsAny<CancellationToken>()), Times.Once);

            Assert.That(result, Is.EqualTo(0), "InvokeAsync should return 0 upon success.");
        }

        [Test]
        public async Task Verify_that_InvokeAsync_returns_0_for_SysML_xmi()
        {
            var args = new[]
            {
                "excel-report",
                "--no-logo",
                "--input-model", Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "SysML.uml"),
                "--output-report","xl-report.xlsx",
                "--root-package-xmi-id", "_kUROkM9FEe6Zc_le1peNgQ",
                "--pathmaps", $"pathmap://UML_LIBRARIES/UMLPrimitiveTypes.library.uml={Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "PrimitiveTypes.xmi")}"
            };

            var parseResult = this.rootCommand.Parse(args);

            var result = await this.handler.InvokeAsync(parseResult, this.cts.Token);

            this.xlReportGenerator.Verify(x => x.GenerateReport(It.IsAny<FileInfo>(), It.IsAny<DirectoryInfo>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<Dictionary<string, string>>(), It.IsAny<FileInfo>(), It.IsAny<String>()), Times.Once);

            Assert.That(result, Is.EqualTo(0), "InvokeAsync should return 0 upon success.");
        }

        [Test]
        public async Task Verify_that_when_the_input_ecore_model_does_not_exists_returns_not_0()
        {
            var args = new[]
            {
                "excel-report",
                "--no-logo",
                "--input-model", Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "non-existent.xmi"),
                "--output-report","xl-report.xlsx"
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
                "excel-report",
                "--no-logo",
                "--input-model", Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "UML.xmi"),
                "--root-package-xmi-id", "_0",
                "--root-package-name", "UML"
            };

            var parseResult = this.rootCommand.Parse(args);

            this.xlReportGenerator.Setup(x => x.IsValidReportExtension(It.IsAny<FileInfo>()))
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
