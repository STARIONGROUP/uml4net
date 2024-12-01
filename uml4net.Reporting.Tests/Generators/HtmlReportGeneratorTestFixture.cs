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
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Microsoft.Extensions.Logging;

    using NUnit.Framework;
    using uml4net.Packages;
    using Reporting.Generators;
    using Serilog;
    using xmi;

    [TestFixture]
    public class HtmlReportGeneratorTestFixture
    {
        private ILoggerFactory loggerFactory;

        private HtmlReportGenerator htmlReportGenerator;

        private FileInfo umlModelFileInfo;

        private FileInfo sysml2ModelFileInfo;

        [SetUp]
        public void SetUp()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console()
                .CreateLogger();

            this.loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSerilog();
            });

            this.umlModelFileInfo = new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "UML.xmi"));
            this.sysml2ModelFileInfo = new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "SysML.uml"));
        }

        [Test]
        public void Verify_that_the_report_generator_generates_a_report_of_uml()
        {
            this.htmlReportGenerator = new HtmlReportGenerator(this.loggerFactory);

            var reportFileInfo = new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, "uml-html-report.html"));

            var pathmap = new Dictionary<string, string>();

            Assert.That(() => this.htmlReportGenerator.GenerateReport(this.umlModelFileInfo, this.umlModelFileInfo.Directory, pathmap, reportFileInfo), Throws.Nothing);
        }

        [Test]
        public void Verify_that_the_report_generator_generates_a_report_of_sysml2()
        {
            this.htmlReportGenerator = new HtmlReportGenerator(this.loggerFactory);

            var reportFileInfo = new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, "sysml2-html-report.html"));

            var pathmap = new Dictionary<string, string>();
            pathmap.Add("pathmap://UML_LIBRARIES/UMLPrimitiveTypes.library.uml", Path.Combine("TestData", "PrimitiveTypes.xmi"));

            Assert.That(() => this.htmlReportGenerator.GenerateReport(this.sysml2ModelFileInfo, this.umlModelFileInfo.Directory, pathmap, reportFileInfo), Throws.Nothing);
        }
    }
}