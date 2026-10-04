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
    /// Verifies the serialization style of the writer: no owner back-references, href reference elements without
    /// xmi:type, and the properties in alphabetical order
    /// </summary>
    [TestFixture]
    public class SerializationStyleTestFixture
    {
        private static readonly XNamespace XmiNamespace = "http://www.omg.org/spec/XMI/20131001";

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

                Assert.That(classElement.Elements().Select(x => x.Name.LocalName), Is.EqualTo(new[] { "generalization", "ownedAttribute", "ownedComment" }),
                    "the properties are written in alphabetical order");

                var type = propertyElement.Element("type");
                Assert.That(type.Attribute("href")?.Value, Is.EqualTo("types.xmi#String"));
                Assert.That(type.Attribute(XmiNamespace + "type"), Is.Null, "XMI 2.5.1 rule 9.5.2 2c: a reference element has its link attribute only");

                var general = classElement.Element("generalization").Element("general");
                Assert.That(general.Attributes().Select(x => x.Name.LocalName), Is.EqualTo(new[] { "href" }));
            }
        }
    }
}
