// -------------------------------------------------------------------------------------------------
// <copyright file="CanonicalXmiWriterTestFixture.cs" company="Starion Group S.A.">
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
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using NUnit.Framework;

    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.Packages;
    using uml4net.Profiling;
    using uml4net.Values;
    using uml4net.xmi.Readers;
    using uml4net.xmi.Writers;

    /// <summary>
    /// Verifies the Canonical XMI serialization of the writer (XMI 2.5.1 Annex B)
    /// </summary>
    [TestFixture]
    public class CanonicalXmiWriterTestFixture
    {
        private static readonly XNamespace XmiNamespace = "http://www.omg.org/spec/XMI/20131001";

        private static readonly XNamespace UmlNamespace = "http://www.omg.org/spec/UML/20131001";

        /// <summary>
        /// The example of Annex B.7, with the constraints in the reverse order, a comment without name, attributes instead
        /// of elements and a reference to another document
        /// </summary>
        private const string AnnexExample = """
            <?xml version="1.0" encoding="UTF-8"?>
            <xmi:XMI xmlns:xmi="http://www.omg.org/spec/XMI/20131001" xmlns:uml="http://www.omg.org/spec/UML/20131001">
              <xmi:documentation xmi:type="xmi:Documentation" exporter="tests"/>
              <uml:Operation xmi:id="op1" xmi:uuid="DCE:1234" name="op1">
                <ownedRule xmi:type="uml:Constraint" xmi:id="c02" xmi:uuid="DCE:efgh" name="co2" constrainedElement="op1">
                  <specification xmi:type="uml:OpaqueExpression" xmi:id="s2" xmi:uuid="DCE:abcde2"><body>Second Constraint definition</body></specification>
                </ownedRule>
                <ownedRule xmi:type="uml:Constraint" xmi:id="c01" xmi:uuid="DCE:abcd" name="co1" constrainedElement="op1">
                  <specification xmi:type="uml:OpaqueExpression" xmi:id="s1" xmi:uuid="DCE:abcde1"><body>First Constraint definition</body></specification>
                </ownedRule>
                <ownedComment xmi:type="uml:Comment" xmi:id="cm" body="no name"/>
                <ownedParameter xmi:type="uml:Parameter" xmi:id="p" name="p-1">
                  <type xmi:type="uml:PrimitiveType" href="http://www.omg.org/spec/UML/20131001/PrimitiveTypes.xmi#Boolean"/>
                </ownedParameter>
                <xmi:extension extender="tests"><note/></xmi:extension>
              </uml:Operation>
            </xmi:XMI>
            """;

        [Test]
        public void Verify_that_a_model_is_written_as_Canonical_XMI()
        {
            var xmiReaderResult = ReadString(AnnexExample, "doc1.xml");

            var canonical = WriteCanonical(xmiReaderResult, "doc1.xml");
            var document = XDocument.Parse(canonical);
            var operation = document.Root!.Element(UmlNamespace + "Operation");
            var rules = operation!.Elements("ownedRule").ToList();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(canonical, Does.StartWith("<?xml version=\"1.0\" encoding=\"utf-8\"?>"), "rule 1: an explicit UTF-8 encoding");
                Assert.That(document.Root.Name, Is.EqualTo(XmiNamespace + "XMI"), "rule 2: an xmi:XMI root");
                Assert.That(document.Root.Elements().Select(x => x.Name), Is.EqualTo(new[] { UmlNamespace + "Operation" }), "rule 11: no xmi:documentation");

                Assert.That(operation.Attributes().Select(x => x.Name.LocalName), Is.EqualTo(new[] { "id", "uuid", "type" }), "rule 5: xmi:id, xmi:uuid and xmi:type in that order, nothing else as an attribute");
                Assert.That(operation.Attribute(XmiNamespace + "id")?.Value, Is.EqualTo("op1"), "B.6: the name of a top-level object");
                Assert.That(operation.Elements().Select(x => x.Name.LocalName).Distinct(), Is.EqualTo(new[] { "ownedComment", "name", "ownedRule", "ownedParameter" }),
                    "B.5.2: Element::ownedComment, NamedElement::name, Namespace::ownedRule, BehavioralFeature::ownedParameter; rule 11: no xmi:extension");

                Assert.That(rules.Select(x => x.Attribute(XmiNamespace + "uuid")?.Value), Is.EqualTo(new[] { "DCE:abcd", "DCE:efgh" }), "B.5.3: the nested elements of a property that is not ordered, by xmi:uuid");
                Assert.That(rules.Select(x => x.Attribute(XmiNamespace + "id")?.Value), Is.EqualTo(new[] { "op1-co1", "op1-co2" }), "B.6: the parent identifier, '-' and the name");
                Assert.That(rules[0].Element("specification")?.Attribute(XmiNamespace + "id")?.Value, Is.EqualTo("op1-co1-specification_1"), "B.6: an object without name is numbered after the property that contains it");
                Assert.That(rules[0].Element("constrainedElement")?.Attribute(XmiNamespace + "idref")?.Value, Is.EqualTo("op1"), "a link to the canonical identifier");

                var comment = operation.Element("ownedComment");
                Assert.That(comment?.Attribute(XmiNamespace + "id")?.Value, Is.EqualTo("op1-ownedComment_1"));
                Assert.That(comment?.Attribute(XmiNamespace + "uuid")?.Value, Is.EqualTo("doc1.xml#cm"), "B.6: the document and the xmi:id that was read when no xmi:uuid was read");
                Assert.That(comment?.Element("body")?.Value, Is.EqualTo("no name"), "rule 5: a value as an XML element");

                var parameter = operation.Element("ownedParameter");
                Assert.That(parameter?.Attribute(XmiNamespace + "id")?.Value, Is.EqualTo("op1-p_1"), "B.6: '-' is replaced by '_'");
                Assert.That(parameter?.Element("type")?.Attributes().Select(x => x.Name.LocalName), Is.EqualTo(new[] { "href" }), "rule 6: a reference element without xmi:type");

                Assert.That(canonical, Does.Not.Contain("<name />"), "rule 4: an element is only self-closing when it is a reference");
            }
        }

        [Test]
        public void Verify_that_writing_the_normative_UML_document_as_Canonical_XMI_reaches_a_fixed_point()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var original = Read(Path.Combine(rootPath, "UML.xmi"), rootPath);
            var first = WriteCanonical(original, "UML.xmi");

            var secondResult = ReadString(first, "UML.xmi", rootPath);
            var second = WriteCanonical(secondResult, "UML.xmi");

            var third = WriteCanonical(ReadString(second, "UML.xmi", rootPath), "UML.xmi");

            using (Assert.EnterMultipleScope())
            {
                // the normative document has elements with duplicate xmi:ids, whose unresolved references are written as
                // read by the first write; from the second write on, the output does not change
                Assert.That(third, Is.EqualTo(second), "a Canonical XMI document is written identically when it is read and written again");
                Assert.That(secondResult.QueryRoot("UML").NestedPackage, Has.Count.EqualTo(original.QueryRoot("_0", "UML").NestedPackage.Count), "the canonical document is read back");
                Assert.That(XDocument.Parse(first).Root!.Elements().First().Name.LocalName, Is.EqualTo("Tag"), "B.5.1: mofext:Tag before uml:Package");
            }
        }

        [Test]
        public void Verify_that_tags_and_stereotype_applications_are_written_as_Canonical_XMI_and_read_back()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "StereotypeApplications");
            var xmiReaderResult = Read(Path.Combine(rootPath, "profile-and-applications.xmi"), rootPath);

            var canonical = WriteCanonical(xmiReaderResult, "profile-and-applications.xmi");
            var document = XDocument.Parse(canonical);
            var rereadResult = ReadString(canonical, "profile-and-applications.xmi", rootPath);

            var tag = document.Root!.Element(XName.Get("Tag", "http://www.omg.org/spec/MOF/20131001"));
            var requirementA = rereadResult.XmiRoot.StereoTypeApplications.Single(x => x.XmiUuid == "profile-and-applications.xmi#requirementA");

            using (Assert.EnterMultipleScope())
            {
                var qualifiedNames = document.Root.Elements().Select(x => $"{x.GetPrefixOfNamespace(x.Name.Namespace)}:{x.Name.LocalName}").ToList();
                Assert.That(qualifiedNames, Is.EqualTo(qualifiedNames.OrderBy(x => x, StringComparer.Ordinal)), "B.5.1: the top-level elements by XML element name");
                Assert.That(qualifiedNames, Does.Contain("Demo:Requirement").And.Contain("Other:Marker").And.Contain("mofext:Tag").And.Contain("uml:Model"));
                Assert.That(tag?.Element("name")?.Value, Is.EqualTo("org.omg.xmi.nsURI"));
                Assert.That(tag?.Element("element")?.Attribute(XmiNamespace + "idref")?.Value, Is.EqualTo("Demo"), "the link of the tag to the canonical identifier of the profile");

                Assert.That(rereadResult.XmiRoot.Tags.Single().Name, Is.EqualTo("org.omg.xmi.nsURI"), "a tag in element form is read");
                Assert.That(rereadResult.XmiRoot.StereoTypeApplications, Has.Count.EqualTo(xmiReaderResult.XmiRoot.StereoTypeApplications.Count));
                Assert.That(requirementA.Stereotype?.Name, Is.EqualTo("Requirement"), "a stereotype application in element form is resolved");
                Assert.That(requirementA.ExtendedElement?.XmiId, Is.EqualTo("Model-A"), "its base_ link is the canonical identifier of the class");
                Assert.That(requirementA.QueryTaggedValue("tracedTo").Values.Cast<IXmiElement>().Select(x => x.XmiId), Is.EquivalentTo(new[] { "Model-B", "Model-C" }));
                Assert.That(requirementA.QueryTaggedValue("isMandatory").Values, Is.EqualTo(new object[] { true }));
            }
        }

        [Test]
        public async Task Verify_that_the_asynchronous_canonical_write_gives_the_same_document_and_the_omitted_content_is_logged()
        {
            var loggerProvider = new CapturingLoggerProvider();
            using var loggerFactory = LoggerFactory.Create(builder => builder.AddProvider(loggerProvider));

            var xmiReaderResult = ReadString(AnnexExample, "doc1.xml");
            xmiReaderResult.XmiRoot.DiagramInterchange.Add(new Xmi.CapturedElement { RawXml = "<a/>", LocalName = "a" });

            var writer = XmiWriterBuilder.Create().UsingSettings(x => x.UseCanonicalXmi = true).WithLogger(loggerFactory).Build();

            using var stream = new MemoryStream();
            writer.Write(xmiReaderResult.DocumentRootElements, stream, "doc1.xml", xmiReaderResult.XmiRoot);

            using var asyncStream = new MemoryStream();
            await writer.WriteAsync(xmiReaderResult.DocumentRootElements, asyncStream, "doc1.xml", xmiReaderResult.XmiRoot);

            var information = loggerProvider.Messages.Where(x => x.Level == LogLevel.Information).Select(x => x.Message).ToList();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(asyncStream.ToArray(), Is.EqualTo(stream.ToArray()));
                Assert.That(information, Has.Some.Contains("The documentation is not written"));
                Assert.That(information, Has.Some.Contains("1 captured elements are not written"));
            }
        }

        [Test]
        public async Task Verify_that_tags_and_stereotype_applications_are_written_identically_by_the_asynchronous_canonical_write()
        {
            var loggerProvider = new CapturingLoggerProvider();
            using var loggerFactory = LoggerFactory.Create(builder => builder.AddProvider(loggerProvider));

            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "StereotypeApplications");
            var xmiReaderResult = Read(Path.Combine(rootPath, "profile-and-applications.xmi"), rootPath);
            xmiReaderResult.XmiRoot.Extensions.Add(new XmiExtension { Extender = "tests", ContentRawXmi = "<a/>" });

            var writer = XmiWriterBuilder.Create().UsingSettings(x => x.UseCanonicalXmi = true).WithLogger(loggerFactory).Build();

            using var stream = new MemoryStream();
            writer.Write(xmiReaderResult.DocumentRootElements, stream, "profile-and-applications.xmi", xmiReaderResult.XmiRoot);

            using var asyncStream = new MemoryStream();
            await writer.WriteAsync(xmiReaderResult.DocumentRootElements, asyncStream, "profile-and-applications.xmi", xmiReaderResult.XmiRoot);

            var stereoTypeApplicationWriter = new StereoTypeApplicationWriter(new Settings.DefaultWriterSettings(), null);
            var writeContext = new XmiWriteContext("a.xmi", [], true);
            using var xmlWriter = System.Xml.XmlWriter.Create(new StringBuilder());

            using (Assert.EnterMultipleScope())
            {
                Assert.That(asyncStream.ToArray(), Is.EqualTo(stream.ToArray()));
                Assert.That(loggerProvider.Messages.Select(x => x.Message), Has.Some.EqualTo("1 extensions are not written: Canonical XMI has no xmi:extension"));

                Assert.That(() => stereoTypeApplicationWriter.WriteCanonical(null, new StereoTypeApplication(), writeContext), Throws.ArgumentNullException);
                Assert.That(async () => await stereoTypeApplicationWriter.WriteCanonicalAsync(null, new StereoTypeApplication(), writeContext), Throws.ArgumentNullException);
                Assert.That(() => stereoTypeApplicationWriter.WriteCanonical(xmlWriter, null, writeContext), Throws.ArgumentNullException);
                Assert.That(() => stereoTypeApplicationWriter.WriteCanonical(xmlWriter, new StereoTypeApplication { ProfileName = "P", NamespaceUri = "urn:p", StereoTypeName = "S" }, null), Throws.ArgumentNullException);
                Assert.That(() => stereoTypeApplicationWriter.WriteCanonical(xmlWriter, new StereoTypeApplication { ProfileName = "P", NamespaceUri = "urn:p", StereoTypeName = "S" }, writeContext),
                    Throws.InvalidOperationException.With.Message.Contains("extends no element"));
            }
        }

        [Test]
        public void Verify_that_without_the_option_the_identifiers_are_written_as_read()
        {
            var xmiReaderResult = ReadString(AnnexExample, "doc1.xml");

            using var stream = new MemoryStream();
            XmiWriterBuilder.Create().WithLogger(NullLoggerFactory.Instance).Build().Write(xmiReaderResult.DocumentRootElements, stream, "doc1.xml", xmiReaderResult.XmiRoot);

            var operation = XDocument.Parse(Encoding.UTF8.GetString(stream.ToArray())).Root!.Element(UmlNamespace + "Operation");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(operation!.Attribute(XmiNamespace + "id")?.Value, Is.EqualTo("op1"));
                Assert.That(operation.Elements("ownedRule").Select(x => x.Attribute(XmiNamespace + "id")?.Value), Is.EqualTo(new[] { "c02", "c01" }), "the ids and the order as read");
                Assert.That(operation.Attribute("name")?.Value, Is.EqualTo("op1"), "a value as an attribute");
                Assert.That(operation.Element("ownedParameter")?.Element("type")?.Attribute(XmiNamespace + "type"), Is.Not.Null, "a reference element with its xmi:type");
            }
        }

        private static string WriteCanonical(XmiReaderResult xmiReaderResult, string documentName)
        {
            using var stream = new MemoryStream();

            XmiWriterBuilder.Create()
                .UsingSettings(x => x.UseCanonicalXmi = true)
                .WithLogger(NullLoggerFactory.Instance)
                .Build()
                .Write(xmiReaderResult.DocumentRootElements, stream, documentName, xmiReaderResult.XmiRoot);

            return Encoding.UTF8.GetString(stream.ToArray());
        }

        private static XmiReaderResult Read(string path, string rootPath)
        {
            using var reader = XmiReaderBuilder.Create().UsingSettings(x => x.LocalReferenceBasePath = rootPath).WithLogger(NullLoggerFactory.Instance).Build();

            return reader.Read(path);
        }

        private static XmiReaderResult ReadString(string xml, string documentName, string rootPath = null)
        {
            using var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = rootPath ?? TestContext.CurrentContext.TestDirectory)
                .WithLogger(NullLoggerFactory.Instance)
                .Build();

            return reader.Read(new MemoryStream(Encoding.UTF8.GetBytes(xml.TrimStart('﻿'))), documentName);
        }

        /// <summary>
        /// An <see cref="ILoggerProvider"/> that captures the formatted log messages
        /// </summary>
        private sealed class CapturingLoggerProvider : ILoggerProvider
        {
            public List<(LogLevel Level, string Message)> Messages { get; } = [];

            public ILogger CreateLogger(string categoryName) => new CapturingLogger(this.Messages);

            public void Dispose()
            {
            }

            private sealed class CapturingLogger(List<(LogLevel Level, string Message)> messages) : ILogger
            {
                public IDisposable BeginScope<TState>(TState state) where TState : notnull => null;

                public bool IsEnabled(LogLevel logLevel) => true;

                public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
                {
                    lock (messages)
                    {
                        messages.Add((logLevel, formatter(state, exception)));
                    }
                }
            }
        }
    }
}
