// -------------------------------------------------------------------------------------------------
//  <copyright file="DocumentationReaderTestFixture.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2025 Starion Group S.A.
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

namespace uml4net.xmi.Tests.Readers
{
    using System;
    using System.IO;
    using System.Linq;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using NUnit.Framework;

    using Serilog;

    using uml4net.xmi.Readers;
    using uml4net.xmi.Settings;

    [TestFixture]
    public class DocumentationReaderTestFixture
    {
        private IXmiReaderSettings xmiReaderSettings;

        private NameSpaceResolver nameSpaceResolver;

        private DocumentationReader documentationReader;

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
            this.xmiReaderSettings = new DefaultSettings();
            this.nameSpaceResolver = new NameSpaceResolver();

            this.documentationReader = new DocumentationReader(this.xmiReaderSettings, this.nameSpaceResolver,NullLoggerFactory.Instance);
        }

        [Test]
        public void Verify_that_null_arguments_throws_exception()
        {
            Assert.That(() => this.documentationReader.Read(null, ""), Throws.TypeOf<ArgumentNullException>() );
        }

        [Test]
        public void Verify_that_documentation_can_be_read_as_attributes()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = rootPath)
                .WithLogger(this.loggerFactory)
                .Build();

            var xmiReaderResult = reader.Read(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "documentation-as-attributes.xmi"));

            var documentation = xmiReaderResult.XmiRoot.Documentation;

            Assert.That(documentation.Contact, Is.EqualTo("info@stariongroup.eu"));
            Assert.That(documentation.Exporter, Is.EqualTo("uml4net"));
            Assert.That(documentation.ExporterVersion, Is.EqualTo("1.0.0"));
            Assert.That(documentation.ExporterID, Is.EqualTo("4.5.6"));
            Assert.That(documentation.LongDescription.First(), Is.EqualTo("long description"));
            Assert.That(documentation.ShortDescription.First(), Is.EqualTo("short description"));
            Assert.That(documentation.Notice.First(), Is.EqualTo("notice"));
            Assert.That(documentation.Owner.First(), Is.EqualTo("Starion Group S.A."));
            Assert.That(documentation.TimeStamp, Is.EqualTo(new DateTime(2025,10,12)));
        }

        [Test]
        public void Verify_that_documentation_can_be_read_as_attributes_with_invalid_Date()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = rootPath)
                .WithLogger(this.loggerFactory)
                .Build();

            var xmiReaderResult = reader.Read(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "documentation-as-attributes-invalid-datetime.xmi"));

            var documentation = xmiReaderResult.XmiRoot.Documentation;

            Assert.That(documentation.Contact, Is.EqualTo("info@stariongroup.eu"));
            Assert.That(documentation.Exporter, Is.EqualTo("uml4net"));
            Assert.That(documentation.ExporterVersion, Is.EqualTo("1.0.0"));
            Assert.That(documentation.ExporterID, Is.EqualTo("4.5.6"));
            Assert.That(documentation.LongDescription.First(), Is.EqualTo("long description"));
            Assert.That(documentation.ShortDescription.First(), Is.EqualTo("short description"));
            Assert.That(documentation.Notice.First(), Is.EqualTo("notice"));
            Assert.That(documentation.Owner.First(), Is.EqualTo("Starion Group S.A."));
            Assert.That(documentation.TimeStamp, Is.EqualTo(DateTime.MinValue));
        }

        [Test]
        public void Verify_that_documentation_can_be_read_as_elements()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = rootPath)
                .WithLogger(this.loggerFactory)
                .Build();

            var xmiReaderResult = reader.Read(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "documentation-as-elements.xmi"));

            var documentation = xmiReaderResult.XmiRoot.Documentation;

            Assert.That(documentation.Contact, Is.EqualTo("info@stariongroup.eu"));
            Assert.That(documentation.Exporter, Is.EqualTo("uml4net"));
            Assert.That(documentation.ExporterVersion, Is.EqualTo("1.0.0"));
            Assert.That(documentation.ExporterID, Is.EqualTo("4.5.6"));
            Assert.That(documentation.LongDescription.First(), Is.EqualTo("long description"));
            Assert.That(documentation.ShortDescription.First(), Is.EqualTo("short description"));
            Assert.That(documentation.Notice.First(), Is.EqualTo("notice"));
            Assert.That(documentation.Owner.First(), Is.EqualTo("Starion Group S.A."));
            Assert.That(documentation.TimeStamp, Is.EqualTo(new DateTime(2025, 10, 12)));
        }

        [Test]
        public void Verify_that_documentation_can_be_read_as_elements_with_invalid_Date()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = rootPath)
                .WithLogger(this.loggerFactory)
                .Build();

            var xmiReaderResult = reader.Read(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "documentation-as-elements-invalid-datetime.xmi"));

            var documentation = xmiReaderResult.XmiRoot.Documentation;

            Assert.That(documentation.Contact, Is.EqualTo("info@stariongroup.eu"));
            Assert.That(documentation.Exporter, Is.EqualTo("uml4net"));
            Assert.That(documentation.ExporterVersion, Is.EqualTo("1.0.0"));
            Assert.That(documentation.ExporterID, Is.EqualTo("4.5.6"));
            Assert.That(documentation.LongDescription.First(), Is.EqualTo("long description"));
            Assert.That(documentation.ShortDescription.First(), Is.EqualTo("short description"));
            Assert.That(documentation.Notice.First(), Is.EqualTo("notice"));
            Assert.That(documentation.Owner.First(), Is.EqualTo("Starion Group S.A."));
            Assert.That(documentation.TimeStamp, Is.EqualTo(DateTime.MinValue));
        }
    }
}
