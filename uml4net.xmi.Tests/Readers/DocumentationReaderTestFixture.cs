// -------------------------------------------------------------------------------------------------
// <copyright file="DocumentationReaderTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Tests.Readers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml;

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
        public void Verify_that_extensions_inside_the_documentation_are_read_and_preserved_as_raw_xmi()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "Documentation");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = rootPath)
                .WithLogger(this.loggerFactory)
                .Build();

            var xmiReaderResult = reader.Read(Path.Combine(rootPath, "documentation-with-extensions.xmi"));

            var documentation = xmiReaderResult.XmiRoot.Documentation;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(documentation.Extensions, Has.Count.EqualTo(2), "xmi:Extension and xmi:extension");
                Assert.That(documentation.Extensions[0].Extender, Is.EqualTo("uml4net tests"));
                Assert.That(documentation.Extensions[0].ExtenderId, Is.EqualTo("1"));
                Assert.That(documentation.Extensions[0].DocumentName, Is.EqualTo("documentation-with-extensions.xmi"));
                Assert.That(documentation.Extensions[0].ContentRawXmi, Does.Contain("<tool:info").And.Contain("version=\"42\"").And.Contain("<tool:note>kept</tool:note>"));
                Assert.That(documentation.Extensions[1].Extender, Is.EqualTo("other tool"));
                Assert.That(documentation.Extensions[1].ContentRawXmi, Does.Contain("<other:data").And.Contain(">x</other:data>"));
                Assert.That(documentation.Notice, Is.EqualTo(new[] { "after the extensions" }), "the sibling after the extensions is still read");
                Assert.That(documentation.Exporter, Is.EqualTo("uml4net tests"));
            }
        }

        [Test]
        public void Verify_that_the_Read_overload_without_a_document_name_records_the_unknown_document_name()
        {
            const string xml = "<xmi:Documentation xmlns:xmi='http://www.omg.org/spec/XMI/20131001' exporter='e'><xmi:Extension extender='x'><a/></xmi:Extension></xmi:Documentation>";

            using var xmlReader = XmlReader.Create(new StringReader(xml));

            var documentation = this.documentationReader.Read(xmlReader, "http://www.omg.org/spec/XMI/20131001");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(documentation.Exporter, Is.EqualTo("e"));
                Assert.That(documentation.Extensions.Single().DocumentName, Is.EqualTo(DocumentationReader.UnknownDocumentName));
                Assert.That(documentation.Extensions.Single().ContentRawXmi, Is.EqualTo("<a />"));
            }
        }

        [Test]
        public void Verify_that_Read_throws_when_the_document_name_is_empty()
        {
            using var xmlReader = XmlReader.Create(new StringReader("<xmi:Documentation xmlns:xmi='http://www.omg.org/spec/XMI/20131001'/>"));

            Assert.That(() => this.documentationReader.Read(xmlReader, "", "http://www.omg.org/spec/XMI/20131001"), Throws.ArgumentException);
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

            using (Assert.EnterMultipleScope())
            {
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
        }

        [Test]
        public void Verify_that_documentation_can_be_read_as_attributes_with_invalid_Date()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = rootPath)
                .WithLogger(this.loggerFactory)
                .Build();

            var xmiReaderResult = reader.Read(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData",
                "documentation-as-attributes-invalid-datetime.xmi"));

            var documentation = xmiReaderResult.XmiRoot.Documentation;

            using (Assert.EnterMultipleScope())
            {
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

        [Test]
        public void Verify_that_documentation_can_be_read_as_elements()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = rootPath)
                .WithLogger(this.loggerFactory)
                .Build();

            var xmiReaderResult = reader.Read(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData",
                "documentation-as-elements.xmi"));

            var documentation = xmiReaderResult.XmiRoot.Documentation;

            using (Assert.EnterMultipleScope())
            {
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
        }

        [Test]
        public void Verify_that_documentation_can_be_read_as_elements_with_invalid_Date()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = rootPath)
                .WithLogger(this.loggerFactory)
                .Build();

            var xmiReaderResult = reader.Read(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData",
                "documentation-as-elements-invalid-datetime.xmi"));

            var documentation = xmiReaderResult.XmiRoot.Documentation;

            using (Assert.EnterMultipleScope())
            {
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
}
