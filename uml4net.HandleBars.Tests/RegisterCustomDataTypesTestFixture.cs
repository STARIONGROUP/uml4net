// -------------------------------------------------------------------------------------------------
// <copyright file="RegisterCustomDataTypesTestFixture.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.HandleBars.Tests
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    using HandlebarsDotNet;
    using Microsoft.Extensions.Logging;
    using NUnit.Framework;
    using Serilog;

    using uml4net.Classification;
    using uml4net.StructuredClassifiers;
    using uml4net.xmi;
    using uml4net.xmi.Readers;

    /// <summary>
    /// Suite of tests not specific tio a class, but to check custom C# datatype registration and templates
    /// </summary>
    [TestFixture]
    public class RegisterCustomDataTypesTestFixture
    {
        private IHandlebars handlebarsContext;

        private ILoggerFactory loggerFactory;

        private XmiReaderResult xmiReaderResult;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console()
                .CreateLogger();

            this.loggerFactory = LoggerFactory.Create(builder => { builder.AddSerilog(); });
        }

        [SetUp]
        public void SetUp()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = rootPath)
                .WithLogger(this.loggerFactory)
                .Build();

            this.xmiReaderResult = reader.Read(Path.Combine(rootPath, "SystemsModelingAPIandServicesPIM.xmi"));

            this.handlebarsContext = Handlebars.Create();
            this.handlebarsContext.Configuration.FormatProvider = CultureInfo.InvariantCulture;

            PropertyHelper.RegisterPropertyHelper(this.handlebarsContext);
        }

        [TearDown]
        public void TearDown()
        {
            this.handlebarsContext = null;
            this.xmiReaderResult = null;

            // Reset the custom datatype mappings, because Extensions.PropertyExtensions is static and settings will be shared between unit tests
            Extensions.TypedElementExtensions.ResetCSharpTypeMappingsToDefault();
        }

        [Test]
        public void Verify_that_property_is_written_as_expected_for_interface_without_custom_datatype_mapping()
        {
            var template = "{{ #Property.WriteForInterface this }}";

            var handlebarsTemplate = this.handlebarsContext.Compile(template);

            var root = this.xmiReaderResult.QueryRoot("_19_0_4_3fa0198_1689000259946_865221_0");

            // var apiModelPackage = this.xmiReaderResult.Root.NestedPackage.Single(x => x.Name == "API_Model");
            var apiModelPackage = root.NestedPackage.Single(x => x.Name == "API_Model");

            var commitReferenceElement = apiModelPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "CommitReference");

            var created = commitReferenceElement.OwnedAttribute.OfType<IProperty>().Single(x => x.Name == "created");

            var createdProperty = handlebarsTemplate(created);

            Assert.That(createdProperty, Is.EqualTo("public ISO8601DateTime Created { get; set; }" + Environment.NewLine));
        }

        [Test]
        public void Verify_that_property_is_written_as_expected_for_interface_with_custom_datatype_mapping()
        {
            Extensions.TypedElementExtensions.AddOrOverwriteCSharpTypeMappings(("ISO8601DateTime", "DateTime"));

            var template = "{{ #Property.WriteForInterface this }}";

            var handlebarsTemplate = this.handlebarsContext.Compile(template);

            // var apiModelPackage = this.xmiReaderResult.Root.NestedPackage.Single(x => x.Name == "API_Model");

            var root = this.xmiReaderResult.QueryRoot("_19_0_4_3fa0198_1689000259946_865221_0");
            var apiModelPackage = root.NestedPackage.Single(x => x.Name == "API_Model");

            var commitReferenceElement = apiModelPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "CommitReference");

            var created = commitReferenceElement.OwnedAttribute.OfType<IProperty>().Single(x => x.Name == "created");

            var createdProperty = handlebarsTemplate(created);

            Assert.That(createdProperty, Is.EqualTo("public DateTime Created { get; set; }" + Environment.NewLine));
        }
    }
}
