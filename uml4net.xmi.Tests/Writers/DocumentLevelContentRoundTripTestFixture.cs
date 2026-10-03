// -------------------------------------------------------------------------------------------------
// <copyright file="DocumentLevelContentRoundTripTestFixture.cs" company="Starion Group S.A.">
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
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    using Microsoft.Extensions.Logging.Abstractions;

    using NUnit.Framework;

    using uml4net.xmi.Readers;
    using uml4net.xmi.Writers;
    using uml4net.xmi.Xmi;

    /// <summary>
    /// Verifies that the document-level content that is captured without being processed, the UML Diagram Interchange
    /// and the unprocessed StandardProfile and PrimitiveTypes elements, is written back
    /// </summary>
    [TestFixture]
    public class DocumentLevelContentRoundTripTestFixture
    {
        private const string DocumentName = "document-level-content.xmi";

        private static readonly XNamespace XmiNamespace = "http://www.omg.org/spec/XMI/20131001";

        private static readonly XNamespace UmlDi = "http://www.omg.org/spec/UML/20161101/UMLDI";

        private string rootPath;

        private string outputPath;

        [SetUp]
        public void SetUp()
        {
            this.rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "DocumentLevelContent");
            this.outputPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName() + ".xmi");
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(this.outputPath))
            {
                File.Delete(this.outputPath);
            }
        }

        [Test]
        public void Verify_that_the_captured_content_is_written_back_in_document_order()
        {
            var xmiReaderResult = this.Read(Path.Combine(this.rootPath, DocumentName));

            using var stream = new MemoryStream();

            CreateWriter().Write(xmiReaderResult.DocumentRootElements, stream, DocumentName, xmiReaderResult.XmiRoot);

            stream.Position = 0;
            var document = XDocument.Load(stream);

            var topLevelElements = document.Root!.Elements().ToList();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(topLevelElements.Select(x => x.Attribute(XmiNamespace + "id")?.Value), Is.EqualTo(new[] { "p", "diagram", "notAnApplication", "primitiveTypesElement" }),
                    "the model, then the captured elements in the order in which they were read; the stereotype applications are not written");

                Assert.That(document.Root.Attribute(XNamespace.Xmlns + "umldi")?.Value, Is.EqualTo(UmlDi.NamespaceName), "the namespaces of the captured elements are declared on xmi:XMI");
                Assert.That(document.Root.Attribute(XNamespace.Xmlns + "dc")?.Value, Is.EqualTo("http://www.omg.org/spec/DD/20131001/DC"), "a prefix used in a value only is declared as well");
                Assert.That(document.Root.Attribute(XNamespace.Xmlns + "StandardProfile"), Is.Not.Null);
                Assert.That(document.Root.Attribute(XNamespace.Xmlns + "primitiveTypes"), Is.Not.Null);

                var diagram = topLevelElements[1];
                Assert.That(diagram.Name, Is.EqualTo(UmlDi + "UMLClassDiagram"));
                Assert.That(diagram.Attributes().Where(x => x.IsNamespaceDeclaration).Select(x => x.Name.LocalName), Is.EqualTo(new[] { "uml" }),
                    "only the uml declaration is repeated: the writer binds uml to another version of the namespace on xmi:XMI");
                Assert.That(diagram.GetNamespaceOfPrefix("uml")?.NamespaceName, Is.EqualTo("http://www.omg.org/spec/UML/20161101"));

                var bounds = diagram.Descendants("bounds").Single();
                Assert.That(bounds.Attribute(XmiNamespace + "type")?.Value, Is.EqualTo("dc:Bounds"));
                Assert.That(bounds.GetNamespaceOfPrefix("dc")?.NamespaceName, Is.EqualTo("http://www.omg.org/spec/DD/20131001/DC"));
                Assert.That(bounds.Attribute("width")?.Value, Is.EqualTo("90"));
            }
        }

        [Test]
        public void Verify_that_the_captured_content_survives_a_read_write_read_cycle()
        {
            var xmiReaderResult = this.Read(Path.Combine(this.rootPath, DocumentName));

            CreateWriter().Write(xmiReaderResult.DocumentRootElements, this.outputPath, xmiReaderResult.XmiRoot);

            var rereadResult = this.Read(this.outputPath);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(rereadResult.XmiRoot.DiagramInterchange.Select(x => x.XmiId), Is.EqualTo(new[] { "diagram" }));
                Assert.That(rereadResult.XmiRoot.UnprocessedContent.Select(x => x.XmiId), Is.EqualTo(new[] { "notAnApplication", "primitiveTypesElement" }));
                Assert.That(rereadResult.XmiRoot.DiagramInterchange.Concat(rereadResult.XmiRoot.UnprocessedContent).Select(x => x.Position), Is.EqualTo(new[] { 1, 2, 3 }));

                var originalElements = xmiReaderResult.XmiRoot.DiagramInterchange.Concat(xmiReaderResult.XmiRoot.UnprocessedContent).ToList();
                var rereadElements = rereadResult.XmiRoot.DiagramInterchange.Concat(rereadResult.XmiRoot.UnprocessedContent).ToList();

                for (var index = 0; index < originalElements.Count; index++)
                {
                    Assert.That(XNode.DeepEquals(Normalize(rereadElements[index].RawXml), Normalize(originalElements[index].RawXml)), Is.True,
                        $"the captured element {originalElements[index].XmiId} is unchanged, apart from the order of its namespace declarations");
                    Assert.That(rereadElements[index].NamespaceDeclarations, Is.EquivalentTo(originalElements[index].NamespaceDeclarations),
                        $"the namespaces in scope of {originalElements[index].XmiId} are unchanged");
                }

                Assert.That(rereadResult.QueryRoot("p").PackagedElement, Has.Count.EqualTo(4));
            }
        }

        [Test]
        public async Task Verify_that_the_asynchronous_overloads_write_the_same_document()
        {
            var xmiReaderResult = this.Read(Path.Combine(this.rootPath, DocumentName));
            var writer = CreateWriter();

            using var stream = new MemoryStream();
            writer.Write(xmiReaderResult.DocumentRootElements, stream, DocumentName, xmiReaderResult.XmiRoot);

            using var asyncStream = new MemoryStream();
            await writer.WriteAsync(xmiReaderResult.DocumentRootElements, asyncStream, DocumentName, xmiReaderResult.XmiRoot);

            await writer.WriteAsync(xmiReaderResult.DocumentRootElements, this.outputPath, xmiReaderResult.XmiRoot);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(asyncStream.ToArray(), Is.EqualTo(stream.ToArray()));
                Assert.That(File.ReadAllBytes(this.outputPath), Is.EqualTo(stream.ToArray()));
            }
        }

        [Test]
        public async Task Verify_that_without_XmiRoot_only_the_root_elements_are_written()
        {
            var xmiReaderResult = this.Read(Path.Combine(this.rootPath, DocumentName));
            var writer = CreateWriter();

            using var stream = new MemoryStream();
            writer.Write(xmiReaderResult.DocumentRootElements, stream, DocumentName, (XmiRoot)null);

            using var asyncStream = new MemoryStream();
            await writer.WriteAsync(xmiReaderResult.DocumentRootElements, asyncStream, DocumentName, (XmiRoot)null);

            stream.Position = 0;
            var document = XDocument.Load(stream);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(document.Root!.Elements().Select(x => x.Attribute(XmiNamespace + "id")?.Value), Is.EqualTo(new[] { "p" }));
                Assert.That(document.Root.Attributes().Where(x => x.IsNamespaceDeclaration).Select(x => x.Name.LocalName), Is.EquivalentTo(new[] { "xmi", "uml" }));
                Assert.That(asyncStream.ToArray(), Is.EqualTo(stream.ToArray()));
            }
        }

        [Test]
        public void Verify_that_the_XmiRoot_file_overloads_check_their_arguments()
        {
            var writer = CreateWriter();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => writer.Write(null, this.outputPath, new XmiRoot()), Throws.ArgumentNullException);
                Assert.That(() => writer.Write([], string.Empty, new XmiRoot()), Throws.ArgumentException);
                Assert.That(async () => await writer.WriteAsync(null, this.outputPath, new XmiRoot()), Throws.ArgumentNullException);
                Assert.That(async () => await writer.WriteAsync([], string.Empty, new XmiRoot()), Throws.ArgumentException);
            }
        }

        /// <summary>
        /// Parses the raw XML of a captured element without its namespace declarations, whose order is not significant,
        /// and with its attributes sorted; the element and attribute names stay qualified by their namespace URI
        /// </summary>
        private static XElement Normalize(string rawXml)
        {
            var element = XElement.Parse(rawXml);

            foreach (var descendant in element.DescendantsAndSelf().ToList())
            {
                var attributes = descendant.Attributes().Where(x => !x.IsNamespaceDeclaration).OrderBy(x => x.Name.ToString()).Select(x => new XAttribute(x.Name, x.Value)).ToList();
                descendant.RemoveAttributes();
                descendant.Add(attributes);
            }

            return element;
        }

        private static IXmiWriter CreateWriter()
        {
            return XmiWriterBuilder.Create()
                .WithLogger(NullLoggerFactory.Instance)
                .Build();
        }

        private XmiReaderResult Read(string path)
        {
            using var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = this.rootPath)
                .WithLogger(NullLoggerFactory.Instance)
                .Build();

            return reader.Read(path);
        }
    }
}
