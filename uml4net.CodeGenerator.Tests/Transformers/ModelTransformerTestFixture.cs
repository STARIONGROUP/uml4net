// -------------------------------------------------------------------------------------------------
// <copyright file="ModelTransformerTestFixture.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.CodeGenerator.Tests.Transformers
{
    using System.IO;
    using System.Linq;

    using Microsoft.Extensions.Logging;
    using NUnit.Framework;
    using Serilog;

    using uml4net.Classification;
    using uml4net.CodeGenerator.Generators;
    using uml4net.CodeGenerator.Transformers;
    using uml4net.CommonStructure;
    using uml4net.xmi;
    using uml4net.xmi.Readers;

    [TestFixture]
    public class ModelTransformerTestFixture
    {
        private ILoggerFactory loggerFactory;

        private XmiReaderResult xmiReaderResult;

        private ModelTransformer modelTransformer;

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

            this.modelTransformer = new ModelTransformer(this.loggerFactory);
        }

        [Test]
        public void Verify_that_ModelTransformer_can_be_executed()
        {
            Assert.That(this.modelTransformer.TryTransform(this.xmiReaderResult, "_0", "UML", out var updatedElements), Is.True) ;

            var property = updatedElements.OfType<IProperty>().Single(x => x.XmiId == "Classifier-useCase");

            Assert.That(property.Name, Is.EqualTo("useCases"));
        }
    }
}