// -------------------------------------------------------------------------------------------------
//  <copyright file="ModelInspectorTestFixture.cs" company="Starion Group S.A.">
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
    using System;
    using System.IO;
    using System.Linq;
    using Microsoft.Extensions.Logging;

    using NUnit.Framework;
    using POCO.Packages;
    using Reporting.Generators;
    using Serilog;
    using xmi;

    [TestFixture]
    public class ModelInspectorTestFixture
    {
        private ILoggerFactory loggerFactory;

        private ModelInspector modelInspector;

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

            var reportPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "inspection-report.txt");
            this.reportFileInfo = new FileInfo(reportPath);
        }

        [Test]
        public void Verify_that_Inspection_report_can_be_executed()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = rootPath)
                .WithLogger(this.loggerFactory)
                .Build();

            var packages = reader.Read(Path.Combine(rootPath, "UML.xmi"));

            var rootPackage = packages.Single();

            this.modelInspector = new ModelInspector(this.loggerFactory);

            var report = this.modelInspector.Inspect(rootPackage, true);

            Log.Logger.Information(report);

            Assert.That(report, Is.Not.Null.Or.Empty);
        }

        [Test]
        public void Verify_that_Inspection_report_can_be_generated()
        {
            this.modelInspector = new ModelInspector(this.loggerFactory);

            Assert.That(() => this.modelInspector.GenerateReport(this.modelFileInfo, this.reportFileInfo), Throws.Nothing);
        }

        [Test]
        public void Verify_that_inspect_class_returns_expected_result()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = rootPath)
                .WithLogger(this.loggerFactory)
                .Build();

            var packages = reader.Read(Path.Combine(rootPath, "UML.xmi"));

            var rootPackage = packages.Single();

            var classificationPackage = rootPackage.PackagedElement.OfType<IPackage>().Single(x => x.Name == "Classification") ;

            this.modelInspector = new ModelInspector(this.loggerFactory);

            var inspectionReport = this.modelInspector.Inspect(classificationPackage, "Property");

            Assert.That(inspectionReport, Is.Not.Empty);

            Log.Logger.Information(inspectionReport);
        }
    }
}