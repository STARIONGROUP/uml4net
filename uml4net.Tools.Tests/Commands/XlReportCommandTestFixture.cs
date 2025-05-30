﻿// -------------------------------------------------------------------------------------------------
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
    using System.CommandLine.Invocation;
    using System.IO;
    using System.Threading.Tasks;

    using uml4net.Reporting.Generators;
    using uml4net.Tools.Commands;

    using Moq;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="XlReportCommand"/> class.
    /// </summary>
    [TestFixture]
    public class XlReportCommandTestFixture
    {
        private Mock<IXlReportGenerator> xlReportGenerator;

        private XlReportCommand.Handler handler;

        [SetUp]
        public void SetUp()
        {
            this.xlReportGenerator = new Mock<IXlReportGenerator>();

            this.xlReportGenerator.Setup(x => x.IsValidReportExtension(It.IsAny<FileInfo>()))
                .Returns(new Tuple<bool, string>(true, "valid extension"));

            this.handler = new XlReportCommand.Handler(
                this.xlReportGenerator.Object);
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
            var invocationContext = new InvocationContext(null!);

            this.handler.InputModel = new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "UML.xmi"));
            this.handler.OutputReport = new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, "xl-report.xlsx"));

            var result = await this.handler.InvokeAsync(invocationContext);

            this.xlReportGenerator.Verify(x => x.GenerateReport(It.IsAny<FileInfo>(), It.IsAny<DirectoryInfo>(), It.IsAny<bool>(), It.IsAny<Dictionary<string, string>>(), It.IsAny<FileInfo>()), Times.Once);

            Assert.That(result, Is.EqualTo(0), "InvokeAsync should return 0 upon success.");
        }

        [Test]
        public async Task Verify_that_InvokeAsync_returns_0_for_SysML_xmi()
        {
            var invocationContext = new InvocationContext(null!);

            this.handler.InputModel = new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "SysML.uml"));
            this.handler.OutputReport = new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, "xl-report.xlsx"));
            this.handler.PathMaps = new[] { $"pathmap://UML_LIBRARIES/UMLPrimitiveTypes.library.uml={Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "PrimitiveTypes.xmi")}" };

            var result = await this.handler.InvokeAsync(invocationContext);

            this.xlReportGenerator.Verify(x => x.GenerateReport(It.IsAny<FileInfo>(), It.IsAny<DirectoryInfo>(), It.IsAny<bool>(), It.IsAny<Dictionary<string, string>>(), It.IsAny<FileInfo>()), Times.Once);

            Assert.That(result, Is.EqualTo(0), "InvokeAsync should return 0 upon success.");
        }

        [Test]
        public async Task Verify_that_when_the_input_ecore_model_does_not_exists_returns_not_0()
        {
            var invocationContext = new InvocationContext(null!);

            this.handler.InputModel = new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "non-existent.xmi"));
            this.handler.OutputReport = new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, "xl-report.xlsx"));

            var result = await this.handler.InvokeAsync(invocationContext);

            Assert.That(result, Is.EqualTo(-1), "InvokeAsync should return -1 upon failure.");
        }

        [Test]
        public async Task Verify_that_when_the_output_extensions_is_not_supported_returns_not_0()
        {
            var invocationContext = new InvocationContext(null!);

            this.xlReportGenerator.Setup(x => x.IsValidReportExtension(It.IsAny<FileInfo>()))
                .Returns(new Tuple<bool, string>(false, "invalid extension"));

            this.handler.InputModel = new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "UML.xmi"));

            var result = await this.handler.InvokeAsync(invocationContext);

            Assert.That(result, Is.EqualTo(-1), "InvokeAsync should return -1 upon failure.");
        }
    }
}