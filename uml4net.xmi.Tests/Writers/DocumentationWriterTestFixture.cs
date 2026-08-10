// -------------------------------------------------------------------------------------------------
// <copyright file="DocumentationWriterTestFixture.cs" company="Starion Group S.A.">
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
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Linq;

    using Microsoft.Extensions.Logging.Abstractions;

    using NUnit.Framework;

    using uml4net.xmi.Settings;
    using uml4net.xmi.Writers;
    using uml4net.xmi.Xmi;

    [TestFixture]
    public class DocumentationWriterTestFixture
    {
        private IXmiWriterSettings xmiWriterSettings;

        private DocumentationWriter documentationWriter;

        [SetUp]
        public void SetUp()
        {
            this.xmiWriterSettings = new DefaultWriterSettings();

            this.documentationWriter = new DocumentationWriter(this.xmiWriterSettings, NullLoggerFactory.Instance);
        }

        [Test]
        public void Verify_that_Write_throws_when_arguments_are_null()
        {
            using var stringWriter = new StringWriter();
            using var xmlWriter = XmlWriter.Create(stringWriter);

            Assert.That(() => this.documentationWriter.Write(null, new Documentation()), Throws.TypeOf<ArgumentNullException>());
            Assert.That(() => this.documentationWriter.Write(xmlWriter, null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Verify_that_WriteAsync_throws_when_arguments_are_null()
        {
            using var stringWriter = new StringWriter();
            using var xmlWriter = XmlWriter.Create(stringWriter);

            Assert.That(async () => await this.documentationWriter.WriteAsync(null, new Documentation()), Throws.TypeOf<ArgumentNullException>());
            Assert.That(async () => await this.documentationWriter.WriteAsync(xmlWriter, null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Verify_that_a_fully_populated_Documentation_is_written_as_expected()
        {
            var documentation = new Documentation
            {
                Contact = "info@stariongroup.eu",
                Exporter = "uml4net",
                ExporterID = "4.5.6",
                ExporterVersion = "1.0.0",
                TimeStamp = new DateTime(2025, 10, 12)
            };

            documentation.LongDescription.Add("long description 1");
            documentation.LongDescription.Add("long description 2");
            documentation.ShortDescription.Add("short description");
            documentation.Notice.Add("notice");
            documentation.Owner.Add("Starion Group S.A.");

            var element = this.WriteAndParse(documentation);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(element.Name.LocalName, Is.EqualTo("Documentation"));
                Assert.That(element.Attribute("contact")?.Value, Is.EqualTo("info@stariongroup.eu"));
                Assert.That(element.Attribute("exporter")?.Value, Is.EqualTo("uml4net"));
                Assert.That(element.Attribute("exporterID")?.Value, Is.EqualTo("4.5.6"));
                Assert.That(element.Attribute("exporterVersion")?.Value, Is.EqualTo("1.0.0"));
                Assert.That(element.Attribute("timestamp")?.Value, Is.EqualTo(XmlConvert.ToString(documentation.TimeStamp, XmlDateTimeSerializationMode.RoundtripKind)));

                var xmiNamespace = XNamespace.Get(this.xmiWriterSettings.XmiNamespaceUri);

                Assert.That(element.Elements(xmiNamespace + "longDescription").Select(x => x.Value), Is.EqualTo(new[] { "long description 1", "long description 2" }));
                Assert.That(element.Elements(xmiNamespace + "shortDescription").Select(x => x.Value), Is.EqualTo(new[] { "short description" }));
                Assert.That(element.Elements(xmiNamespace + "notice").Select(x => x.Value), Is.EqualTo(new[] { "notice" }));
                Assert.That(element.Elements(xmiNamespace + "owner").Select(x => x.Value), Is.EqualTo(new[] { "Starion Group S.A." }));
            }
        }

        [Test]
        public void Verify_that_an_empty_Documentation_is_written_without_optional_attributes_or_elements()
        {
            var element = this.WriteAndParse(new Documentation());

            using (Assert.EnterMultipleScope())
            {
                Assert.That(element.Attributes(), Is.Empty);
                Assert.That(element.Elements(), Is.Empty);
            }
        }

        [Test]
        public async Task Verify_that_WriteAsync_writes_the_same_content_as_Write()
        {
            var documentation = new Documentation
            {
                Exporter = "Enterprise Architect",
                ExporterVersion = "6.5",
                ExporterID = "1704"
            };

            using var stream = new MemoryStream();

            await using (var xmlWriter = XmlWriter.Create(stream, new XmlWriterSettings { Async = true, OmitXmlDeclaration = true }))
            {
                await xmlWriter.WriteStartElementAsync("xmi", "XMI", this.xmiWriterSettings.XmiNamespaceUri);

                await this.documentationWriter.WriteAsync(xmlWriter, documentation);

                await xmlWriter.WriteEndElementAsync();
            }

            stream.Position = 0;

            var xmiNamespace = XNamespace.Get(this.xmiWriterSettings.XmiNamespaceUri);
            var element = XDocument.Load(stream).Root!.Element(xmiNamespace + "Documentation");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(element, Is.Not.Null);
                Assert.That(element.Attribute("exporter")?.Value, Is.EqualTo("Enterprise Architect"));
                Assert.That(element.Attribute("exporterVersion")?.Value, Is.EqualTo("6.5"));
                Assert.That(element.Attribute("exporterID")?.Value, Is.EqualTo("1704"));
            }
        }

        /// <summary>
        /// Writes the provided <see cref="Documentation"/> as the sole child of a synthetic root element and
        /// returns the resulting <see cref="XElement"/> for the <c>xmi:Documentation</c> element.
        /// </summary>
        private XElement WriteAndParse(Documentation documentation)
        {
            using var stream = new MemoryStream();

            using (var xmlWriter = XmlWriter.Create(stream, new XmlWriterSettings { OmitXmlDeclaration = true }))
            {
                xmlWriter.WriteStartElement("xmi", "XMI", this.xmiWriterSettings.XmiNamespaceUri);

                this.documentationWriter.Write(xmlWriter, documentation);

                xmlWriter.WriteEndElement();
            }

            stream.Position = 0;

            var xmiNamespace = XNamespace.Get(this.xmiWriterSettings.XmiNamespaceUri);

            return XDocument.Load(stream).Root!.Element(xmiNamespace + "Documentation");
        }
    }
}
