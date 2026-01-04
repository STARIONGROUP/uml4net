// -------------------------------------------------------------------------------------------------
//  <copyright file="XlReportGeneratorTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.Reporting.Tests.Generators
{
    using System.Collections.Generic;
    using System.IO;

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    using Reporting.Generators;

    using Serilog;

    [TestFixture]
    public class XlReportGeneratorTestFixture
    {
        private ILoggerFactory loggerFactory;

        private XlReportGenerator xlReportGenerator;

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
            this.xlReportGenerator = new XlReportGenerator(this.loggerFactory);

            var reportFileInfo = new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, "uml-xl-report.xlsx"));

            var pathmap = new Dictionary<string, string>();

            Assert.That(() => this.xlReportGenerator.GenerateReport(this.umlModelFileInfo, this.umlModelFileInfo.Directory, "_0", "UML",true, pathmap, reportFileInfo), Throws.Nothing);
        }

        [Test]
        public void Verify_that_the_report_generator_generates_a_report_of_sysml2()
        {
            this.xlReportGenerator = new XlReportGenerator(this.loggerFactory);

            var reportFileInfo = new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, "sysml2-xl-report.xlsx"));

            var pathmap = new Dictionary<string, string>();
            pathmap.Add("pathmap://UML_LIBRARIES/UMLPrimitiveTypes.library.uml", Path.Combine("TestData", "PrimitiveTypes.xmi"));

            Assert.That(() => this.xlReportGenerator.GenerateReport(this.sysml2ModelFileInfo, this.umlModelFileInfo.Directory, "_kUROkM9FEe6Zc_le1peNgQ", "sysml", true, pathmap, reportFileInfo), Throws.Nothing);
        }

        [Test]
        public void Verify_that_when_inputfile_or_rootdirectory_or_outputPath_are_null_ArgumentNullException_is_thrown()
        {
            this.xlReportGenerator = new XlReportGenerator(this.loggerFactory);

            var pathmap = new Dictionary<string, string>();

            var reportFileInfo = new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, "sysml2-xl-report.xlsx"));

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => this.xlReportGenerator.GenerateReport(null, this.umlModelFileInfo.Directory, "_0", "UML", true, pathmap, reportFileInfo), Throws.ArgumentNullException);

                Assert.That(() => this.xlReportGenerator.GenerateReport(this.sysml2ModelFileInfo, null, "_0", "UML", true, pathmap, reportFileInfo), Throws.ArgumentNullException);

                Assert.That(() => this.xlReportGenerator.GenerateReport(this.sysml2ModelFileInfo, this.umlModelFileInfo.Directory, "_0", "UML", true, pathmap, null), Throws.ArgumentNullException);
            }
        }
    }
}