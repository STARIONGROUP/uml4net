// -------------------------------------------------------------------------------------------------
// <copyright file="XmiWriterGeneratorTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2026 Starion Group S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.CodeGenerator.Tests.Generators
{
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    using Serilog;

    using uml4net.CodeGenerator.Generators;
    using uml4net.CodeGenerator.Transformers;
    using uml4net.Extensions;
    using uml4net.StructuredClassifiers;
    using uml4net.xmi;
    using uml4net.xmi.Readers;

    [TestFixture]
    public class XmiWriterGeneratorTestFixture
    {
        private DirectoryInfo xmiWriterDirectoryInfo;

        private XmiWriterGenerator xmiWriterGenerator;

        private XmiReaderResult xmiReaderResult;

        private ILoggerFactory loggerFactory;

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

            var modelTransformer = new ModelTransformer(loggerFactory);
            modelTransformer.TryTransform(this.xmiReaderResult, "_0", "UML", out var updatedElements);

            var directoryInfo = new DirectoryInfo(TestContext.CurrentContext.TestDirectory);

            this.xmiWriterDirectoryInfo = directoryInfo.CreateSubdirectory("_uml4net.xmi.AutoGenWriters");

            this.xmiWriterGenerator = new XmiWriterGenerator();
        }

        [Test]
        public async Task Verify_that_concrete_classes_are_generated([Values(
            "Activity","Association",
            "Class", "Connector",
            "DurationConstraint", "DurationObservation",
            "ExceptionHandler", "Expression",
            "Generalization",
            "LiteralInteger","LiteralReal","LiteralUnlimitedNatural",
            "OpaqueExpression",
            "Property",
            "StateMachine",
            "TimeConstraint")] string className)
        {
            var root = this.xmiReaderResult.QueryRoot(xmiId:"_0", name: "UML");

            var classes = root.QueryPackages()
                .SelectMany(x => x.PackagedElement.OfType<IClass>())
                .Where(x => !x.IsAbstract)
                .ToList();

            var @class = classes.Single(x => x.Name == className);

            var generatedCode = await this.xmiWriterGenerator.GenerateXmiWriterAsync(this.xmiWriterDirectoryInfo, @class);

            var expected = await File.ReadAllTextAsync(Path.Combine(TestContext.CurrentContext.TestDirectory, $"Expected/AutoGenXmiWriters/{className}Writer.cs"));

            Assert.That(generatedCode, Is.EqualTo(expected));
        }

        [Test]
        public void Verify_that_concrete_xmi_writer_classes_are_generated()
        {
            Assert.That(async () => await this.xmiWriterGenerator.GenerateAsync(xmiReaderResult, "_0", "UML", this.xmiWriterDirectoryInfo),
                Throws.Nothing);
        }

        [Test]
        public void Verify_that_GenerateXmiElementWriterFacade_is_generated()
        {
            Assert.That(async () => await this.xmiWriterGenerator.GenerateXmiElementWriterFacadeAsync(xmiReaderResult, "_0", "UML", this.xmiWriterDirectoryInfo),
                Throws.Nothing);
        }

        [Test]
        [Explicit("Regenerates the AutoGenXmiWriters of the uml4net.xmi project - the production code")]
        public async Task Regenerate_AutoGenXmiWriters_of_uml4net_xmi()
        {
            var solutionDirectory = new DirectoryInfo(TestContext.CurrentContext.TestDirectory)
                .Parent.Parent.Parent.Parent;

            var autoGenXmiWritersDirectory = new DirectoryInfo(Path.Combine(solutionDirectory.FullName, "uml4net.xmi", "AutoGenXmiWriters"));

            Assert.That(autoGenXmiWritersDirectory.Exists, Is.True, $"the {autoGenXmiWritersDirectory.FullName} directory does not exist");

            await this.xmiWriterGenerator.GenerateAsync(this.xmiReaderResult, "_0", "UML", autoGenXmiWritersDirectory);

            await this.xmiWriterGenerator.GenerateXmiElementWriterFacadeAsync(this.xmiReaderResult, "_0", "UML", autoGenXmiWritersDirectory);
        }
    }
}
