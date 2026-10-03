// -------------------------------------------------------------------------------------------------
// <copyright file="StereoTypeApplicationWriterTestFixture.cs" company="Starion Group S.A.">
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
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Linq;

    using Microsoft.Extensions.Logging.Abstractions;

    using NUnit.Framework;

    using uml4net.Classification;
    using uml4net.Packages;
    using uml4net.Profiling;
    using uml4net.StructuredClassifiers;
    using uml4net.xmi.Readers;
    using uml4net.xmi.Settings;
    using uml4net.xmi.Writers;

    /// <summary>
    /// Verifies that the stereotype applications are written back, regenerated from their resolved state
    /// </summary>
    [TestFixture]
    public class StereoTypeApplicationWriterTestFixture
    {
        private const string DocumentName = "profile-and-applications.xmi";

        private static readonly XNamespace XmiNamespace = "http://www.omg.org/spec/XMI/20131001";

        private static readonly XNamespace DemoNamespace = "http://example.org/profiles/Demo/1.0/Demo.xmi";

        private string rootPath;

        [SetUp]
        public void SetUp()
        {
            this.rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "StereotypeApplications");
        }

        [Test]
        public void Verify_that_the_applications_are_written_after_the_model_with_their_tagged_values()
        {
            var xmiReaderResult = this.Read(Path.Combine(this.rootPath, DocumentName));

            var document = this.WriteAndLoad(xmiReaderResult);

            var requirement = document.Root!.Elements(DemoNamespace + "Requirement").Single(x => x.Attribute(XmiNamespace + "id")?.Value == "requirementA");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(document.Root.Attribute(XNamespace.Xmlns + "Demo")?.Value, Is.EqualTo(DemoNamespace.NamespaceName), "the namespace of the applications is declared on xmi:XMI");
                Assert.That(document.Root.Attribute(XNamespace.Xmlns + "Other")?.Value, Is.EqualTo("http://example.org/profiles/Other"));

                Assert.That(document.Root.Elements().Select(x => x.Name.LocalName).ToList().IndexOf("Requirement"),
                    Is.GreaterThan(document.Root.Elements().Select(x => x.Name.LocalName).ToList().IndexOf("Tag")), "the applications are written after the model and the tags");

                Assert.That(requirement.Attributes().Where(x => !x.IsNamespaceDeclaration).Select(x => $"{x.Name.LocalName}={x.Value}"),
                    Is.EqualTo(new[] { "id=requirementA", "base_Class=a", "isMandatory=true", "priority=3", "weight=0.5", "maximum=*", "level=high", "owner=team", "tracedTo=b c" }));
                Assert.That(requirement.Elements("text").Select(x => x.Value), Is.EqualTo(new[] { "first", "second" }));
                Assert.That(requirement.Elements("refines").Select(x => x.Attribute(XmiNamespace + "idref")?.Value ?? x.Attribute("href")?.Value),
                    Is.EqualTo(new[] { "b", "http://www.omg.org/spec/UML/20161101/UML.xmi#Class" }), "an element of the document by xmi:idref, another one by href");

                var other = document.Root.Elements(XName.Get("Marker", "http://example.org/profiles/Other")).Single();
                Assert.That(other.Attribute("base_Class")?.Value, Is.EqualTo("c"));
                Assert.That(other.Attribute("note")?.Value, Is.EqualTo("kept"), "a tagged value of an unresolved application is written as read");
                Assert.That(other.Elements("related").Select(x => x.Attribute(XmiNamespace + "idref")?.Value ?? x.Attribute("href")?.Value), Is.EqualTo(new[] { "a", "other.xmi#x" }));
                Assert.That(other.Element("comment")?.Value, Is.EqualTo("free text"));

                var spaced = document.Root.Elements(XName.Get("SpacedStereotype", "http:///schemas/SecondProfile/_generated/0")).Single();
                Assert.That(spaced.Attribute("DisplayName")?.Value, Is.EqualTo("shown"), "the names of the stereotype and of the property without spaces, as read");
                Assert.That(document.Root.Attribute(XNamespace.Xmlns + "SecondProfile"), Is.Not.Null);

                var missingElement = document.Root.Elements(DemoNamespace + "Requirement").Single(x => x.Attribute(XmiNamespace + "id")?.Value == "missingElement");
                Assert.That(missingElement.Attribute("base_Class")?.Value, Is.EqualTo("doesNotExist"), "an unresolved base_ reference is written as read");
            }
        }

        [Test]
        public void Verify_that_the_applications_survive_a_read_write_read_cycle()
        {
            var xmiReaderResult = this.Read(Path.Combine(this.rootPath, DocumentName));
            var outputPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName() + ".xmi");

            try
            {
                CreateWriter().Write(xmiReaderResult.DocumentRootElements, outputPath, xmiReaderResult.XmiRoot);

                var rereadResult = this.Read(outputPath);

                Assert.That(rereadResult.XmiRoot.StereoTypeApplications.Select(Describe), Is.EqualTo(xmiReaderResult.XmiRoot.StereoTypeApplications.Select(Describe)));
            }
            finally
            {
                File.Delete(outputPath);
            }
        }

        [Test]
        public async Task Verify_that_the_asynchronous_write_gives_the_same_document()
        {
            var xmiReaderResult = this.Read(Path.Combine(this.rootPath, DocumentName));
            var writer = CreateWriter();

            using var stream = new MemoryStream();
            writer.Write(xmiReaderResult.DocumentRootElements, stream, DocumentName, xmiReaderResult.XmiRoot);

            using var asyncStream = new MemoryStream();
            await writer.WriteAsync(xmiReaderResult.DocumentRootElements, asyncStream, DocumentName, xmiReaderResult.XmiRoot);

            Assert.That(asyncStream.ToArray(), Is.EqualTo(stream.ToArray()));
        }

        [Test]
        public async Task Verify_that_an_application_created_in_code_is_written_with_the_namespace_of_its_profile()
        {
            var xmiReaderResult = this.Read(Path.Combine(this.rootPath, DocumentName));
            var model = xmiReaderResult.QueryRoot("model");
            var classA = model.PackagedElement.OfType<IClass>().Single(x => x.XmiId == "a");
            var requirementStereotype = xmiReaderResult.XmiRoot.StereoTypeApplications.Single(x => x.XmiId == "requirementA").Stereotype;
            var isMandatory = requirementStereotype.OwnedAttribute.Single(x => x.Name == "isMandatory");
            var level = requirementStereotype.OwnedAttribute.Single(x => x.Name == "level");

            var application = new StereoTypeApplication
            {
                XmiId = "created",
                Stereotype = requirementStereotype,
                ExtendedElement = classA,
                TaggedValues =
                {
                    new TaggedValue { Property = isMandatory, Values = { false } },
                    new TaggedValue { Property = level, Values = { ((uml4net.SimpleClassifiers.IEnumeration)level.Type).OwnedLiteral.First() } }
                }
            };

            var serialized = await WriteApplication(application, isAsync: true, localIdentifiers: [classA.FullyQualifiedIdentifier]);
            var element = XElement.Parse(serialized);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(element.Name, Is.EqualTo(XName.Get("Requirement", "http://example.org/profiles/Demo")), "the URI of the profile of the stereotype");
                Assert.That(element.GetPrefixOfNamespace("http://example.org/profiles/Demo"), Is.EqualTo("Demo"), "the name of the profile");
                Assert.That(element.Attribute("base_Class")?.Value, Is.EqualTo("a"), "the meta class is the type of the extended element");
                Assert.That(element.Attribute("isMandatory")?.Value, Is.EqualTo("false"));
                Assert.That(element.Attribute("level")?.Value, Is.EqualTo("low"), "an enumeration literal is written by its name, not as a reference");
                Assert.That(await WriteApplication(application, isAsync: false, localIdentifiers: [classA.FullyQualifiedIdentifier]), Is.EqualTo(serialized));
            }
        }

        [Test]
        public void Verify_that_an_application_that_cannot_be_written_is_refused()
        {
            var writer = new StereoTypeApplicationWriter(new DefaultWriterSettings(), NullLoggerFactory.Instance);
            using var xmlWriter = XmlWriter.Create(new StringBuilder());
            var writeContext = new XmiWriteContext("a.xmi", []);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => new StereoTypeApplicationWriter(null, null), Throws.ArgumentNullException);
                Assert.That(() => writer.Write(null, new StereoTypeApplication(), writeContext), Throws.ArgumentNullException);
                Assert.That(() => writer.Write(xmlWriter, null, writeContext), Throws.ArgumentNullException);
                Assert.That(() => writer.Write(xmlWriter, new StereoTypeApplication { ProfileName = "P", NamespaceUri = "urn:p", StereoTypeName = "S" }, null), Throws.ArgumentNullException);
                Assert.That(async () => await writer.WriteAsync(null, new StereoTypeApplication(), writeContext), Throws.ArgumentNullException);
                Assert.That(() => StereoTypeApplicationWriter.QueryNamespace(null), Throws.ArgumentNullException);

                Assert.That(() => writer.Write(xmlWriter, new StereoTypeApplication { XmiId = "x", StereoTypeName = "S" }, writeContext),
                    Throws.InvalidOperationException.With.Message.Contains("namespace prefix and URI"));
                Assert.That(() => writer.Write(xmlWriter, new StereoTypeApplication { XmiId = "x", ProfileName = "P", NamespaceUri = "urn:p" }, writeContext),
                    Throws.InvalidOperationException.With.Message.Contains("no stereotype name"));
                Assert.That(() => writer.Write(xmlWriter, new StereoTypeApplication { XmiId = "x", ProfileName = "P", NamespaceUri = "urn:p", StereoTypeName = "S" }, writeContext),
                    Throws.InvalidOperationException.With.Message.Contains("extends no element"));
            }
        }

        [Test]
        public async Task Verify_that_an_extended_element_and_references_of_another_document_are_written_as_href()
        {
            var external = new Class { XmiId = "ext", DocumentName = "other.xmi", Name = "External" };
            var local = new Class { XmiId = "loc", DocumentName = "a.xmi", Name = "Local" };
            var referenceProperty = new Property { Name = "related", Type = new Class { Name = "NamedElement" } };

            var application = new StereoTypeApplication
            {
                ProfileName = "P",
                NamespaceUri = "urn:p",
                StereoTypeName = "S",
                ExtendedElement = external,
                TaggedValues =
                {
                    new TaggedValue { Property = referenceProperty, Values = { local, external } },
                    new TaggedValue { Name = "counts", Values = { 1, 2 } },
                    new TaggedValue { Name = "untyped", Values = { local } },
                    new TaggedValue { Name = "raw", RawValues = { "doc.xmi#r", "r2" }, IsReference = true }
                }
            };

            var element = XElement.Parse(await WriteApplication(application, isAsync: false, localIdentifiers: [local.FullyQualifiedIdentifier]));

            using (Assert.EnterMultipleScope())
            {
                Assert.That(element.Attribute(XmiNamespace + "id"), Is.Null, "an application without xmi:id is written without one");
                Assert.That(element.Element("base_Class")?.Attribute("href")?.Value, Is.EqualTo("other.xmi#ext"), "the extended element is not written in the document");
                Assert.That(element.Elements("related").Select(x => x.Attribute(XmiNamespace + "idref")?.Value ?? x.Attribute("href")?.Value), Is.EqualTo(new[] { "loc", "other.xmi#ext" }));
                Assert.That(element.Elements("counts").Select(x => x.Value), Is.EqualTo(new[] { "1", "2" }), "several values are written as child elements");
                Assert.That(element.Attribute("untyped")?.Value, Is.EqualTo("loc"), "an element value without property is a reference");
                Assert.That(element.Elements("raw").Select(x => x.Attribute(XmiNamespace + "idref")?.Value ?? x.Attribute("href")?.Value), Is.EqualTo(new[] { "doc.xmi#r", "r2" }));
            }
        }

        private static string Describe(StereoTypeApplication application)
        {
            var taggedValues = application.TaggedValues.Select(x => x.Values.Count > 0
                ? $"{x.Name}={string.Join(",", x.Values.Select(v => v is IXmiElement e ? e.XmiId : TaggedValueConverter.Format(v, x.Property)))}"
                : $"{x.Name}~{string.Join(",", x.RawValues)}");

            return $"{application.XmiId}|{application.ProfileName}:{application.StereoTypeName}|{application.NamespaceUri}|{application.Stereotype?.XmiId}|{application.ElementIdentifier}|{application.ExtendedElement?.XmiId}|{string.Join(";", taggedValues)}";
        }

        private static IXmiWriter CreateWriter()
        {
            return XmiWriterBuilder.Create()
                .WithLogger(NullLoggerFactory.Instance)
                .Build();
        }

        private static async Task<string> WriteApplication(StereoTypeApplication application, bool isAsync, string[] localIdentifiers = null)
        {
            var writer = new StereoTypeApplicationWriter(new DefaultWriterSettings(), NullLoggerFactory.Instance);
            var writeContext = new XmiWriteContext("a.xmi", [.. localIdentifiers ?? ["a.xmi#a"]]);
            var stringBuilder = new StringBuilder();

            using (var xmlWriter = XmlWriter.Create(stringBuilder, new XmlWriterSettings { OmitXmlDeclaration = true, Async = isAsync }))
            {
                if (isAsync)
                {
                    await writer.WriteAsync(xmlWriter, application, writeContext);
                }
                else
                {
                    writer.Write(xmlWriter, application, writeContext);
                }
            }

            return stringBuilder.ToString();
        }

        private XDocument WriteAndLoad(XmiReaderResult xmiReaderResult)
        {
            using var stream = new MemoryStream();

            CreateWriter().Write(xmiReaderResult.DocumentRootElements, stream, DocumentName, xmiReaderResult.XmiRoot);

            stream.Position = 0;

            return XDocument.Load(stream);
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
