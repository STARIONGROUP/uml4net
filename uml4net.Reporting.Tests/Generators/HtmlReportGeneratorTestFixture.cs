// -------------------------------------------------------------------------------------------------
//  <copyright file="HtmlReportGeneratorTestFixture.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2024 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, softwareUseCases
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
//  </copyright>
//  ------------------------------------------------------------------------------------------------

namespace uml4net.Reporting.Tests.Generators
{
    using System.IO;
    using System.Linq;
    using Microsoft.Extensions.Logging;

    using NUnit.Framework;
    using POCO.Packages;
    using Reporting.Generators;
    using Serilog;
    using xmi;

    [TestFixture]
    public class HtmlReportGeneratorTestFixture
    {
        private ILoggerFactory loggerFactory;

        private HtmlReportGenerator htmlReportGenerator;

        private string modelPath;

        private FileInfo modelFileInfo;

        private FileInfo reportFileInfo;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console()
                .CreateLogger();

            this.loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSerilog();
            });
        }

        [SetUp]
        public void SetUp()
        {
            this.modelPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "UML.xmi");
            this.modelFileInfo = new FileInfo(modelPath);

            var reportPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "html-report.html");
            this.reportFileInfo = new FileInfo(reportPath);
        }

        [Test]
        public void Verify_that_the_report_generator_generates_a_report()
        {
            this.htmlReportGenerator = new HtmlReportGenerator(this.loggerFactory);

            Assert.That(() => this.htmlReportGenerator.GenerateReport(modelFileInfo, reportFileInfo), Throws.Nothing);
        }
    }
}