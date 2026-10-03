// -------------------------------------------------------------------------------------------------
// <copyright file="DocumentationRoundTripTestFixture.cs" company="Starion Group S.A.">
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
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    using Microsoft.Extensions.Logging.Abstractions;

    using NUnit.Framework;

    using uml4net.xmi.Readers;
    using uml4net.xmi.Writers;

    /// <summary>
    /// Verifies that the <c>xmi:documentation</c> header of an XMI document survives a
    /// read - write - read cycle (issue #210).
    /// </summary>
    [TestFixture]
    public class DocumentationRoundTripTestFixture
    {
        private string rootPath;

        [SetUp]
        public void SetUp()
        {
            this.rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");
        }

        [Test]
        public void Verify_that_the_Documentation_of_a_document_round_trips()
        {
            var originalResult = this.CreateReader().Read(Path.Combine(this.rootPath, "documentation-as-attributes.xmi"));

            var originalRoot = originalResult.QueryRoot("_P1");
            var originalDocumentation = originalResult.XmiRoot.Documentation;

            using var stream = new MemoryStream();

            var writer = XmiWriterBuilder.Create()
                .WithLogger(NullLoggerFactory.Instance)
                .Build();

            writer.Write(originalRoot, stream, "documentation-as-attributes.xmi", originalDocumentation, null);

            stream.Position = 0;

            var rereadResult = this.CreateReader().Read(stream, "documentation-as-attributes.xmi");

            var rereadDocumentation = rereadResult.XmiRoot.Documentation;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(rereadDocumentation, Is.Not.Null);
                Assert.That(rereadDocumentation.Contact, Is.EqualTo(originalDocumentation.Contact));
                Assert.That(rereadDocumentation.Exporter, Is.EqualTo(originalDocumentation.Exporter));
                Assert.That(rereadDocumentation.ExporterID, Is.EqualTo(originalDocumentation.ExporterID));
                Assert.That(rereadDocumentation.ExporterVersion, Is.EqualTo(originalDocumentation.ExporterVersion));
                Assert.That(rereadDocumentation.TimeStamp, Is.EqualTo(originalDocumentation.TimeStamp));
                Assert.That(rereadDocumentation.LongDescription, Is.EqualTo(originalDocumentation.LongDescription));
                Assert.That(rereadDocumentation.ShortDescription, Is.EqualTo(originalDocumentation.ShortDescription));
                Assert.That(rereadDocumentation.Notice, Is.EqualTo(originalDocumentation.Notice));
                Assert.That(rereadDocumentation.Owner, Is.EqualTo(originalDocumentation.Owner));
            }
        }

        [Test]
        public void Verify_that_the_exporterID_of_an_Enterprise_Architect_export_is_written_back()
        {
            // <xmi:Documentation exporter="Enterprise Architect" exporterVersion="6.5" exporterID="1704"/>
            var originalResult = this.CreateReader().Read(Path.Combine(this.rootPath, "EAExport.xmi"));

            using var stream = new MemoryStream();

            var writer = XmiWriterBuilder.Create()
                .WithLogger(NullLoggerFactory.Instance)
                .Build();

            writer.Write(originalResult.DocumentRootElements, stream, "EAExport.xmi", originalResult.XmiRoot.Documentation, null);

            stream.Position = 0;

            var documentation = XDocument.Load(stream).Root!.Elements().Single(x => x.Name.LocalName.Equals("Documentation", StringComparison.OrdinalIgnoreCase));

            using (Assert.EnterMultipleScope())
            {
                Assert.That(documentation.Attribute("exporter")?.Value, Is.EqualTo("Enterprise Architect"));
                Assert.That(documentation.Attribute("exporterVersion")?.Value, Is.EqualTo("6.5"));
                Assert.That(documentation.Attribute("exporterID")?.Value, Is.EqualTo("1704"));
            }
        }

        [Test]
        public void Verify_that_the_extensions_of_the_Documentation_round_trip()
        {
            var documentationPath = Path.Combine(this.rootPath, "Documentation", "documentation-with-extensions.xmi");

            var originalResult = this.CreateReader().Read(documentationPath);
            var originalDocumentation = originalResult.XmiRoot.Documentation;

            using var stream = new MemoryStream();

            var writer = XmiWriterBuilder.Create()
                .WithLogger(NullLoggerFactory.Instance)
                .Build();

            writer.Write(originalResult.QueryRoot("p"), stream, "documentation-with-extensions.xmi", originalDocumentation, null);

            stream.Position = 0;

            var rereadDocumentation = this.CreateReader().Read(stream, "documentation-with-extensions.xmi").XmiRoot.Documentation;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(originalDocumentation.Extensions, Has.Count.EqualTo(2));
                Assert.That(rereadDocumentation.Extensions, Has.Count.EqualTo(2));
                Assert.That(rereadDocumentation.Extensions.Select(x => x.Extender), Is.EqualTo(originalDocumentation.Extensions.Select(x => x.Extender)));
                Assert.That(rereadDocumentation.Extensions.Select(x => x.ExtenderId), Is.EqualTo(originalDocumentation.Extensions.Select(x => x.ExtenderId)));
                Assert.That(rereadDocumentation.Extensions.Select(x => x.ContentRawXmi), Is.EqualTo(originalDocumentation.Extensions.Select(x => x.ContentRawXmi)));
                Assert.That(rereadDocumentation.Notice, Is.EqualTo(originalDocumentation.Notice));
            }
        }

        [Test]
        public void Verify_that_the_Documentation_is_written_as_the_first_child_of_the_root()
        {
            var originalResult = this.CreateReader().Read(Path.Combine(this.rootPath, "documentation-as-attributes.xmi"));

            var originalRoot = originalResult.QueryRoot("_P1");

            using var stream = new MemoryStream();

            var writer = XmiWriterBuilder.Create()
                .WithLogger(NullLoggerFactory.Instance)
                .Build();

            writer.Write(originalRoot, stream, "documentation-as-attributes.xmi", originalResult.XmiRoot.Documentation, null);

            stream.Position = 0;

            var document = XDocument.Load(stream);

            var xmiNamespace = XNamespace.Get("http://www.omg.org/spec/XMI/20131001");

            var children = document.Root.Elements().ToList();
            var documentationElement = children.SingleOrDefault(x => x.Name == xmiNamespace + "documentation");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(documentationElement, Is.Not.Null, "an xmi:documentation was expected as a child of xmi:XMI");
                Assert.That(documentationElement.Attribute("exporter")?.Value, Is.EqualTo("uml4net"));
                Assert.That(children.First(), Is.EqualTo(documentationElement),
                    "the xmi:documentation was expected to be written before the model content");
            }
        }

        [Test]
        public void Verify_that_no_Documentation_is_written_when_none_is_provided()
        {
            var originalResult = this.CreateReader().Read(Path.Combine(this.rootPath, "documentation-as-attributes.xmi"));

            var originalRoot = originalResult.QueryRoot("_P1");

            using var stream = new MemoryStream();

            var writer = XmiWriterBuilder.Create()
                .WithLogger(NullLoggerFactory.Instance)
                .Build();

            writer.Write(originalRoot, stream, "documentation-as-attributes.xmi", (System.Collections.Generic.IEnumerable<XmiExtension>)null);

            stream.Position = 0;

            var document = XDocument.Load(stream);

            var xmiNamespace = XNamespace.Get("http://www.omg.org/spec/XMI/20131001");

            Assert.That(document.Root.Elements().Any(x => x.Name == xmiNamespace + "documentation"), Is.False,
                "the pre-existing overloads are expected to remain behaviour preserving and write no xmi:documentation");
        }

        /// <summary>
        /// Creates an <see cref="IXmiReader"/>
        /// </summary>
        private IXmiReader CreateReader()
        {
            return XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = this.rootPath)
                .WithLogger(NullLoggerFactory.Instance)
                .Build();
        }
    }
}
