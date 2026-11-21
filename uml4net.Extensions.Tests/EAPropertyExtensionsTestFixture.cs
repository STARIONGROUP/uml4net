// -------------------------------------------------------------------------------------------------
// <copyright file="EAPropertyExtensionsTestFixture.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Extensions.Tests
{
    using System.IO;
    using System.Linq;

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    using Serilog;

    using uml4net.StructuredClassifiers;
    using uml4net.xmi;
    
    using xmi.Readers;

    [TestFixture]
    public class EAPropertyExtensionsTestFixture
    {
        private ILoggerFactory loggerFactory;

        private XmiReaderResult xmiReaderResult;

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
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x =>
                {
                    x.UseStrictReading = false;
                    x.LocalReferenceBasePath = rootPath;
                })
                .WithLogger(this.loggerFactory)
                .Build();

            this.xmiReaderResult = reader.Read(Path.Combine(rootPath, "EnterpriseArchitectAggregation.xmi"));
        }

        [Test]
        public void Verify_that_QueryIsContainment_returns_expected_Result()
        {
            var root = this.xmiReaderResult.QueryRoot(xmiId: null, name: "EA_Model");

            var package1 = root.NestedPackage.Single(x => x.Name == "Package1");
            
            var class2 = package1.PackagedElement.OfType<IClass>().Single(x => x.Name == "Class2");

            var prop = class2.OwnedAttribute.Single();

            Assert.That(prop.QueryIsContainment(), Is.True, "Enterprise Architect stores the composite aggregation on the end owned by the association");
            Assert.That(prop.IsComposite, Is.False, "Property::isComposite is aggregation = composite only (UML 2.5.1)");

            var class4 = package1.PackagedElement.OfType<IClass>().Single(x => x.Name == "Class4");
            prop = class4.OwnedAttribute.Single();

            Assert.That(prop.QueryIsContainment(), Is.False);
            Assert.That(prop.IsComposite, Is.False);
        }
    }
}
