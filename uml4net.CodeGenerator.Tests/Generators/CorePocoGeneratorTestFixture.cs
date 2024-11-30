// -------------------------------------------------------------------------------------------------
//  <copyright file="CorePocoGeneratorTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.CodeGenerator.Tests.Generators
{
    using System.IO;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    using Serilog;

    using uml4net.CodeGenerator.Generators;
    using uml4net.xmi;
    using uml4net.xmi.Readers;

    [TestFixture]
    public class CorePocoGeneratorTestFixture
    {
        private DirectoryInfo interfaceDirectoryInfo;

        private DirectoryInfo enumerationDirectoryInfo;

        private CorePocoGenerator pocoGenerator;

        private ILoggerFactory loggerFactory;

        private XmiReaderResult xmiReaderResult;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
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
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = rootPath)
                .WithLogger(this.loggerFactory)
                .Build();

            this.xmiReaderResult = reader.Read(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "UML.xmi"));

            var directoryInfo = new DirectoryInfo(TestContext.CurrentContext.TestDirectory);

            this.interfaceDirectoryInfo = directoryInfo.CreateSubdirectory("_uml4net.AutoGenInterfaces");
            this.enumerationDirectoryInfo = directoryInfo.CreateSubdirectory("_uml4net.AutoGenEnumeration");

            this.pocoGenerator = new CorePocoGenerator();
        }

        [Test, TestCaseSource(typeof(Expected.ExpectedAllClasses)), Category("Expected")]
        public async Task Verify_that_expected_poco_interfaces_are_generated_correctly(string className)
        {
            var generatedCode = await this.pocoGenerator.GenerateInterface(this.xmiReaderResult, this.interfaceDirectoryInfo, className);

            var expected = await File.ReadAllTextAsync(Path.Combine(TestContext.CurrentContext.TestDirectory, $"Expected/AutoGenInterfaces/I{className}.cs"));

            Assert.That(generatedCode, Is.EqualTo(expected));
        }

        [Test]
        public void Verify_that_interfaces_are_generated()
        {
            Assert.That(
                async () => await this.pocoGenerator.GenerateInterfaces(this.xmiReaderResult, this.interfaceDirectoryInfo),
                Throws.Nothing);
        }

        [Test]
        public async Task Verify_that_expected_enumerations_are_generated_correctly()
        {
            var enumerationName = "ConnectorKind";

            var generatedCode = await this.pocoGenerator.GenerateEnumeration(this.xmiReaderResult, this.enumerationDirectoryInfo, enumerationName);

            var expected = await File.ReadAllTextAsync(Path.Combine(TestContext.CurrentContext.TestDirectory, $"Expected/AutoGenEnumeration/{enumerationName}.cs"));

            Assert.That(generatedCode, Is.EqualTo(expected));
        }

        [Test]
        public void Verify_that_enumerations_are_generated()
        {
            Assert.That(
                async () => await this.pocoGenerator.GenerateEnumerations(this.xmiReaderResult, this.enumerationDirectoryInfo),
                Throws.Nothing);
        }
    }
}