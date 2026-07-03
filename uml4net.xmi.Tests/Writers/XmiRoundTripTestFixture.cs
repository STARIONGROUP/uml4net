// -------------------------------------------------------------------------------------------------
// <copyright file="XmiRoundTripTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Tests.Writers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using NUnit.Framework;

    using Serilog;

    using uml4net.CommonStructure;
    using uml4net.Packages;
    using uml4net.StructuredClassifiers;
    using uml4net.xmi;
    using uml4net.xmi.Readers;
    using uml4net.xmi.Settings;
    using uml4net.xmi.Writers;

    [TestFixture]
    public class XmiRoundTripTestFixture
    {
        private string rootPath;

        private ReferenceClosureCalculator referenceClosureCalculator;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .CreateLogger();
        }

        [SetUp]
        public void SetUp()
        {
            this.rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            this.referenceClosureCalculator = new ReferenceClosureCalculator(NullLogger<ReferenceClosureCalculator>.Instance);
        }

        [Test]
        public void Verify_that_the_UML_model_round_trips_with_href_references()
        {
            var originalRoot = this.ReadUmlModel().QueryRoot("_0", "UML");

            using var stream = new MemoryStream();

            var writer = XmiWriterBuilder.Create()
                .WithLogger(this.CreateLoggerFactory())
                .Build();

            writer.Write(originalRoot, stream, "UML.xmi");

            stream.Position = 0;

            var rereadRoot = this.ReadUmlModel(stream).QueryRoot("_0", "UML");

            this.AssertContainmentTreesAreEquivalent(originalRoot, rereadRoot, "UML.xmi");

            var activity = rereadRoot.NestedPackage.Single(x => x.Name == "Activities")
                .PackagedElement.OfType<IClass>().Single(x => x.Name == "Activity");

            Assert.That(activity.IsAbstract, Is.False);
            Assert.That(activity.Visibility, Is.EqualTo(VisibilityKind.Public));
            Assert.That(activity.Generalization.Single().General.Name, Is.EqualTo("Behavior"));
            Assert.That(activity.OwnedRule, Is.Not.Empty);

            var classifier = rereadRoot.NestedPackage.Single(x => x.Name == "Classification")
                .PackagedElement.OfType<IClass>().Single(x => x.Name == "Classifier");

            Assert.That(classifier.IsAbstract, Is.True);

            var isAbstract = classifier.OwnedAttribute.Single(x => x.Name == "isAbstract");

            Assert.That(isAbstract.Type.Name, Is.EqualTo("Boolean"));
            Assert.That(isAbstract.Type.DocumentName, Does.EndWith("PrimitiveTypes.xmi"),
                "the href reference to the PrimitiveTypes document was expected to be resolved from the written document");
        }

        [Test]
        public async Task Verify_that_the_UML_model_round_trips_asynchronously()
        {
            var originalRoot = this.ReadUmlModel().QueryRoot("_0", "UML");

            using var syncStream = new MemoryStream();
            using var asyncStream = new MemoryStream();

            var writer = XmiWriterBuilder.Create()
                .WithLogger(this.CreateLoggerFactory())
                .Build();

            writer.Write(originalRoot, syncStream, "UML.xmi");

            await writer.WriteAsync(originalRoot, asyncStream, "UML.xmi");

            Assert.That(asyncStream.ToArray(), Is.EqualTo(syncStream.ToArray()),
                "the synchronous and asynchronous write are expected to produce identical documents");
        }

        [Test]
        public void Verify_that_the_UML_model_round_trips_with_include_mode()
        {
            var originalRoot = this.ReadUmlModel().QueryRoot("_0", "UML");

            using var stream = new MemoryStream();

            var writer = XmiWriterBuilder.Create()
                .UsingSettings(x => x.ExternalReferenceResolution = ExternalReferenceResolutionKind.Include)
                .WithLogger(this.CreateLoggerFactory())
                .Build();

            writer.Write(originalRoot, stream, "UML-include.xmi");

            stream.Position = 0;

            var reader = XmiReaderBuilder.Create()
                .WithLogger(this.CreateLoggerFactory())
                .Build();

            var rereadResult = reader.Read(stream, "UML-include.xmi");

            Assert.That(rereadResult.Packages, Has.Count.EqualTo(2),
                "the written document is expected to contain the UML package and the included PrimitiveTypes package");

            var rereadRoot = rereadResult.QueryRoot("_0", "UML");

            var classifier = rereadRoot.NestedPackage.Single(x => x.Name == "Classification")
                .PackagedElement.OfType<IClass>().Single(x => x.Name == "Classifier");

            var isAbstract = classifier.OwnedAttribute.Single(x => x.Name == "isAbstract");

            Assert.That(isAbstract.Type, Is.Not.Null);
            Assert.That(isAbstract.Type.Name, Is.EqualTo("Boolean"));
            Assert.That(isAbstract.Type.DocumentName, Is.EqualTo("UML-include.xmi"),
                "the PrimitiveTypes package was expected to be included in the written document");
        }

        [Test]
        public void Verify_that_a_mutated_model_round_trips()
        {
            var originalRoot = this.ReadUmlModel().QueryRoot("_0", "UML");

            var activity = originalRoot.NestedPackage.Single(x => x.Name == "Activities")
                .PackagedElement.OfType<IClass>().Single(x => x.Name == "Activity");

            activity.Name = "RenamedActivity";

            using var stream = new MemoryStream();

            var writer = XmiWriterBuilder.Create()
                .WithLogger(this.CreateLoggerFactory())
                .Build();

            writer.Write(originalRoot, stream, "UML.xmi");

            stream.Position = 0;

            var rereadRoot = this.ReadUmlModel(stream).QueryRoot("_0", "UML");

            var renamedActivity = rereadRoot.NestedPackage.Single(x => x.Name == "Activities")
                .PackagedElement.OfType<IClass>().Single(x => x.XmiId == activity.XmiId);

            Assert.That(renamedActivity.Name, Is.EqualTo("RenamedActivity"));
        }

        [Test]
        public void Verify_that_the_SysML_model_round_trips()
        {
            var pathMaps = new Dictionary<string, string>
            {
                ["pathmap://UML_LIBRARIES/UMLPrimitiveTypes.library.uml"] = Path.Combine("TestData", "PrimitiveTypes.xmi")
            };

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x =>
                {
                    x.LocalReferenceBasePath = this.rootPath;
                    x.PathMaps = pathMaps;
                })
                .WithLogger(this.CreateLoggerFactory())
                .Build();

            var originalResult = reader.Read(Path.Combine(this.rootPath, "SysML.uml"));

            var originalRoot = originalResult.Packages.First();

            using var stream = new MemoryStream();

            var writer = XmiWriterBuilder.Create()
                .WithLogger(this.CreateLoggerFactory())
                .Build();

            writer.Write(originalRoot, stream, "SysML.uml");

            stream.Position = 0;

            var rereadReader = XmiReaderBuilder.Create()
                .UsingSettings(x =>
                {
                    x.LocalReferenceBasePath = this.rootPath;
                    x.PathMaps = pathMaps;
                })
                .WithLogger(this.CreateLoggerFactory())
                .Build();

            var rereadResult = rereadReader.Read(stream, "SysML.uml");

            var rereadRoot = rereadResult.Packages.First();

            this.AssertContainmentTreesAreEquivalent(originalRoot, rereadRoot, "SysML.uml");
        }

        /// <summary>
        /// Asserts that the containment trees of the provided packages contain the same elements by
        /// comparing the <see cref="IXmiElement.FullyQualifiedIdentifier"/>s of the calculated write plans
        /// </summary>
        /// <param name="originalRoot">
        /// The root <see cref="IPackage"/> of the original model
        /// </param>
        /// <param name="rereadRoot">
        /// The root <see cref="IPackage"/> of the model that was read from the written document
        /// </param>
        /// <param name="documentName">
        /// The name of the document that was written
        /// </param>
        private void AssertContainmentTreesAreEquivalent(IPackage originalRoot, IPackage rereadRoot, string documentName)
        {
            var originalPlan = this.referenceClosureCalculator.CalculateWritePlan(originalRoot, ExternalReferenceResolutionKind.Href, documentName);
            var rereadPlan = this.referenceClosureCalculator.CalculateWritePlan(rereadRoot, ExternalReferenceResolutionKind.Href, documentName);

            var missing = originalPlan.LocalIdentifiers.Except(rereadPlan.LocalIdentifiers).Take(10).ToList();
            var extra = rereadPlan.LocalIdentifiers.Except(originalPlan.LocalIdentifiers).Take(10).ToList();

            Assert.That(rereadPlan.LocalIdentifiers.SetEquals(originalPlan.LocalIdentifiers), Is.True,
                $"the containment trees are not equivalent; missing: [{string.Join(", ", missing)}]; extra: [{string.Join(", ", extra)}]");
        }

        /// <summary>
        /// Reads the UML model from the TestData directory
        /// </summary>
        /// <returns>
        /// The <see cref="XmiReaderResult"/>
        /// </returns>
        private XmiReaderResult ReadUmlModel()
        {
            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = this.rootPath)
                .WithLogger(this.CreateLoggerFactory())
                .Build();

            return reader.Read(Path.Combine(this.rootPath, "UML.xmi"));
        }

        /// <summary>
        /// Reads a UML model from the provided <see cref="Stream"/>, resolving external references
        /// from the TestData directory
        /// </summary>
        /// <param name="stream">
        /// The <see cref="Stream"/> that contains the XMI content
        /// </param>
        /// <returns>
        /// The <see cref="XmiReaderResult"/>
        /// </returns>
        private XmiReaderResult ReadUmlModel(Stream stream)
        {
            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = this.rootPath)
                .WithLogger(this.CreateLoggerFactory())
                .Build();

            return reader.Read(stream, "UML.xmi");
        }

        /// <summary>
        /// Creates a new <see cref="ILoggerFactory"/>. Each reader, writer and scope receives its own
        /// instance since disposing a scope also disposes the registered <see cref="ILoggerFactory"/>
        /// </summary>
        /// <returns>
        /// The created <see cref="ILoggerFactory"/>
        /// </returns>
        private ILoggerFactory CreateLoggerFactory()
        {
            return LoggerFactory.Create(builder => builder.AddSerilog());
        }
    }
}
