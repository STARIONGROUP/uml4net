// -------------------------------------------------------------------------------------------------
// <copyright file="SerializationStyleTestFixture.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    using Microsoft.Extensions.Logging.Abstractions;

    using NUnit.Framework;

    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;
    using uml4net.xmi.Writers;

    /// <summary>
    /// Verifies that the writer follows the serialization style of the OMG normative XMI documents: the properties
    /// superclass first with the references before the contained elements, no owner back-references, and href reference
    /// elements without xmi:type
    /// </summary>
    [TestFixture]
    public class SerializationStyleTestFixture
    {
        private static readonly XNamespace XmiNamespace = "http://www.omg.org/spec/XMI/20131001";

        [Test]
        public void Verify_that_the_normative_UML_document_is_written_with_the_same_order_of_child_elements()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");
            var file = Path.Combine(rootPath, "UML.xmi");

            using var reader = XmiReaderBuilder.Create().UsingSettings(x => x.LocalReferenceBasePath = rootPath).WithLogger(NullLoggerFactory.Instance).Build();
            var xmiReaderResult = reader.Read(file);

            using var stream = new MemoryStream();
            XmiWriterBuilder.Create().WithLogger(NullLoggerFactory.Instance).Build().Write(xmiReaderResult.DocumentRootElements, stream, "UML.xmi", xmiReaderResult.XmiRoot);
            stream.Position = 0;

            var original = QueryChildElementSequences(XDocument.Load(file));
            var written = QueryChildElementSequences(XDocument.Load(stream));

            var mismatchesByType = new Dictionary<string, int>();

            foreach (var (xmiId, (xmiType, sequence)) in original)
            {
                // an element that is not written as a child element, for example a reference written as an attribute,
                // is left out of the comparison
                if (written.TryGetValue(xmiId, out var writtenElement) && !sequence.SequenceEqual(writtenElement.Sequence.Where(sequence.Contains)))
                {
                    mismatchesByType[xmiType] = mismatchesByType.TryGetValue(xmiType, out var count) ? count + 1 : 1;
                }
            }

            using (Assert.EnterMultipleScope())
            {
                Assert.That(original, Has.Count.GreaterThan(6000));

                // the remaining differences are in operations (precondition and bodyCondition written after the contained
                // elements) and in State-isConsistentWith, whose xmi:ids are not unique in the normative document
                foreach (var xmiType in new[] { "uml:Package", "uml:Class", "uml:Property", "uml:Association", "uml:Enumeration", "uml:EnumerationLiteral", "uml:Generalization" })
                {
                    Assert.That(mismatchesByType.TryGetValue(xmiType, out var count) ? count : 0, Is.Zero, $"the child elements of the {xmiType} elements are written in the normative order");
                }
            }
        }

        [Test]
        public void Verify_that_owner_back_references_and_the_xmi_type_of_href_elements_are_not_written()
        {
            var package = new Package { XmiId = "package", Name = "package" };
            var @class = new Class { XmiId = "class", Name = "class" };
            var property = new Property { XmiId = "property", Name = "property", Type = new PrimitiveType { XmiId = "String", DocumentName = "types.xmi", Name = "String" } };
            @class.OwnedAttribute.Add(property);
            @class.Generalization.Add(new Generalization { XmiId = "generalization", General = new Class { XmiId = "general", DocumentName = "other.xmi", Name = "General" } });
            @class.OwnedComment.Add(new Comment { XmiId = "comment", Body = "a comment" });
            package.PackagedElement.Add(@class);

            using var stream = new MemoryStream();
            XmiWriterBuilder.Create().WithLogger(NullLoggerFactory.Instance).Build().Write(package, stream, "output.xmi");
            stream.Position = 0;

            var classElement = XDocument.Load(stream).Descendants("packagedElement").Single();
            var propertyElement = classElement.Element("ownedAttribute");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(@class.Package, Is.SameAs(package), "the owner end is set in memory");
                Assert.That(classElement.Attribute("package"), Is.Null, "the owner end Type::package is not written");
                Assert.That(propertyElement.Attribute("class"), Is.Null, "the owner end Property::class is not written");

                Assert.That(classElement.Elements().Select(x => x.Name.LocalName), Is.EqualTo(new[] { "ownedComment", "generalization", "ownedAttribute" }),
                    "superclass first: Element::ownedComment, Classifier::generalization, Class::ownedAttribute");

                var type = propertyElement.Element("type");
                Assert.That(type.Attribute("href")?.Value, Is.EqualTo("types.xmi#String"));
                Assert.That(type.Attribute(XmiNamespace + "type"), Is.Null, "XMI 2.5.1 rule 9.5.2 2c: a reference element has its link attribute only");

                var general = classElement.Element("generalization").Element("general");
                Assert.That(general.Attributes().Select(x => x.Name.LocalName), Is.EqualTo(new[] { "href" }));
            }
        }

        private static Dictionary<string, (string XmiType, List<string> Sequence)> QueryChildElementSequences(XDocument document)
        {
            var result = new Dictionary<string, (string XmiType, List<string> Sequence)>();

            foreach (var element in document.Descendants().Where(x => x.Attribute(XmiNamespace + "id") != null))
            {
                var sequence = new List<string>();

                foreach (var name in element.Elements().Select(x => x.Name.LocalName))
                {
                    if (sequence.Count == 0 || sequence[^1] != name)
                    {
                        sequence.Add(name);
                    }
                }

                result[element.Attribute(XmiNamespace + "id").Value] = (element.Attribute(XmiNamespace + "type")?.Value ?? element.Name.LocalName, sequence);
            }

            return result;
        }
    }
}
