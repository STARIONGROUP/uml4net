// -------------------------------------------------------------------------------------------------
// <copyright file="XmiSchemaConformanceTestFixture.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using System.Xml.Schema;

    using Microsoft.Extensions.Logging.Abstractions;

    using NUnit.Framework;

    using uml4net.Packages;
    using uml4net.StructuredClassifiers;
    using uml4net.xmi.Xmi;

    /// <summary>
    /// Validates the XMI constructs of a written document against the normative XMI 2.5.1 schema, <c>XMI.xsd</c>
    /// </summary>
    /// <remarks>
    /// The <c>XMI</c> type of the schema allows any content, validated strictly, and OMG publishes no normative schema
    /// for the UML 2.5.1 content. The UML content is therefore removed before validation: the <c>xmi:XMI</c> root is
    /// validated with its XMI children only (<c>xmi:documentation</c>, <c>xmi:extension</c>), and every
    /// <c>xmi:extension</c> of a model element is validated on its own.
    /// </remarks>
    [TestFixture]
    public class XmiSchemaConformanceTestFixture
    {
        private static readonly XNamespace XmiNamespace = "http://www.omg.org/spec/XMI/20131001";

        /// <summary>
        /// Whether the content of <c>xmi:documentation</c> is validated; it is not yet schema-valid (#461)
        /// </summary>
        private const bool DocumentationIsValidated = false;

        private XmlSchemaSet schemaSet;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.schemaSet = new XmlSchemaSet();
            this.schemaSet.Add(XmiNamespace.NamespaceName, Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "XMI.xsd"));
            this.schemaSet.Compile();
        }

        private static (IPackage Package, Documentation Documentation, List<XmiExtension> Extensions) CreateContent()
        {
            var package = new Package { XmiId = "package", Name = "Package" };
            var @class = new Class { XmiId = "class", Name = "Class" };
            @class.Extensions.Add(new XmiExtension { Extender = "Enterprise Architect", ExtenderId = "6.5", ContentRawXmi = "<properties isAbstract=\"false\"/>" });
            package.PackagedElement.Add(@class);

            var documentation = new Documentation
            {
                Contact = "info@stariongroup.eu",
                Exporter = "uml4net",
                ExporterVersion = "1.0.0",
                TimeStamp = new DateTime(2026, 9, 28, 12, 0, 0, DateTimeKind.Utc)
            };

            documentation.ShortDescription.Add("a short description");
            documentation.LongDescription.Add("a long description");
            documentation.Notice.Add("a notice");
            documentation.Owner.Add("an owner");
            documentation.Extensions.Add(new XmiExtension { Extender = "uml4net", ContentRawXmi = "<note/>" });

            var extensions = new List<XmiExtension> { new() { Id = "documentExtension", Extender = "Enterprise Architect", ExtenderId = "6.5", ContentRawXmi = "<elements/>" } };

            return (package, documentation, extensions);
        }

        private List<string> Validate(XDocument document)
        {
            var errors = new List<string>();

            void Collect(object sender, ValidationEventArgs args) => errors.Add($"{args.Severity}: {args.Message}");

            // the root with its XMI children only; the content of xmi:documentation is not yet schema-valid (#461),
            // so it is left out until that is fixed
            var root = new XElement(document.Root!.Name, document.Root.Attributes(), document.Root.Elements().Where(x => x.Name.Namespace == XmiNamespace && (DocumentationIsValidated || x.Name.LocalName != "documentation")));
            new XDocument(root).Validate(this.schemaSet, Collect);

            // every extension of a model element, on its own
            foreach (var extension in document.Root.Elements().Where(x => x.Name.Namespace != XmiNamespace).SelectMany(x => x.Descendants(XmiNamespace + "extension")))
            {
                // the xmi prefix is declared on the root; it is declared on the copy as well, since xmi:type is a QName
                var copy = new XElement(extension);
                copy.SetAttributeValue(XNamespace.Xmlns + "xmi", XmiNamespace.NamespaceName);
                new XDocument(copy).Validate(this.schemaSet, Collect);
            }

            return errors;
        }

        [Test]
        public async Task Verify_that_the_XMI_constructs_of_a_written_document_are_valid_against_the_XMI_schema()
        {
            var (package, documentation, extensions) = CreateContent();

            var writer = XmiWriterBuilder.Create().WithLogger(NullLoggerFactory.Instance).Build();

            using var stream = new MemoryStream();
            writer.Write(new IXmiElement[] { package }, stream, "conformance.xmi", documentation, extensions);

            using var asyncStream = new MemoryStream();
            await writer.WriteAsync(new IXmiElement[] { package }, asyncStream, "conformance.xmi", documentation, extensions);

            var document = XDocument.Load(new MemoryStream(stream.ToArray()));

            using (Assert.EnterMultipleScope())
            {
                Assert.That(document.Root!.Elements(XmiNamespace + "documentation"), Has.Exactly(1).Items, "the document is expected to hold the documentation");
                Assert.That(document.Root.Elements(XmiNamespace + "extension"), Has.Exactly(1).Items, "the document is expected to hold the document extension");
                Assert.That(document.Descendants(XmiNamespace + "extension").Count(), Is.EqualTo(2), "the extension of the class is expected as well");
                Assert.That(this.Validate(document), Is.Empty);
                Assert.That(this.Validate(XDocument.Load(new MemoryStream(asyncStream.ToArray()))), Is.Empty);
            }
        }
    }
}
