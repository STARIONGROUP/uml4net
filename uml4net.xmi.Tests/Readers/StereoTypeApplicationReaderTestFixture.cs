// -------------------------------------------------------------------------------------------------
// <copyright file="StereoTypeApplicationReaderTestFixture.cs" company="Starion Group S.A.">
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

    using Microsoft.Extensions.Logging.Abstractions;

    using NUnit.Framework;

    using uml4net.Profiling;
    using uml4net.xmi.Readers;

    [TestFixture]
    public class StereoTypeApplicationReaderTestFixture
    {
        [Test]
        public void Verify_that_when_xmlReader_is_null_exception_is_thrown()
        {
            var stereoTypeApplicationReader = new StereoTypeApplicationReader(null);

            Assert.That(() =>
                stereoTypeApplicationReader.TryRead(null, out StereoTypeApplication application),
                Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Verify_that_the_tagged_values_serialized_as_attributes_and_child_elements_are_read()
        {
            const string xml =
                "<Demo:Requirement xmlns:Demo=\"urn:demo\" xmlns:xmi=\"http://www.omg.org/spec/XMI/20131001\" xmi:id=\"r\" xmi:type=\"Demo:Requirement\" priority=\"3\">" +
                "<text>first</text><base_Class xmi:idref=\"c\"/><refines xmi:idref=\"a\"/><text>second</text><refines href=\"other.xmi#b\"/>" +
                "<structured><value>1</value></structured><empty/></Demo:Requirement>";

            var stereoTypeApplicationReader = new StereoTypeApplicationReader(NullLoggerFactory.Instance);

            using var xmlReader = XmlReader.Create(new StringReader(xml));

            using (Assert.EnterMultipleScope())
            {
                Assert.That(stereoTypeApplicationReader.TryRead(xmlReader, out var application), Is.True);
                Assert.That(application.XmiId, Is.EqualTo("r"));
                Assert.That(application.NamespaceUri, Is.EqualTo("urn:demo"));
                Assert.That(application.ProfileName, Is.EqualTo("Demo"));
                Assert.That(application.StereoTypeName, Is.EqualTo("Requirement"));
                Assert.That(application.MetaClass, Is.EqualTo("Class"));
                Assert.That(application.ElementIdentifier, Is.EqualTo("c"), "the base_ reference as a child element, after a tagged value");
                Assert.That(application.Attributes.Keys, Is.EquivalentTo(new[] { "type", "priority" }), "the attributes as read");
                Assert.That(application.TaggedValues.Select(x => $"{x.Name}:{string.Join(",", x.RawValues)}:{x.IsReference}:{x.IsReadAsAttribute}"),
                    Is.EqualTo(new[] { "priority:3:False:True", "text:first,second:False:False", "refines:a,other.xmi#b:True:False", "empty::False:False" }),
                    "xmi:type is not a tagged value, the values of a property are grouped, and a structured value is not read");
            }
        }

        [Test]
        public void Verify_that_a_second_base_reference_does_not_replace_the_first_one()
        {
            const string xml =
                "<Demo:Requirement xmlns:Demo=\"urn:demo\" xmlns:xmi=\"http://www.omg.org/spec/XMI/20131001\" base_Class=\"a\">" +
                "<base_Class xmi:idref=\"b\"/><base_Element/></Demo:Requirement>";

            var stereoTypeApplicationReader = new StereoTypeApplicationReader(null);

            using var xmlReader = XmlReader.Create(new StringReader(xml));

            using (Assert.EnterMultipleScope())
            {
                Assert.That(stereoTypeApplicationReader.TryRead(xmlReader, out var application), Is.True);
                Assert.That(application.ElementIdentifier, Is.EqualTo("a"));
                Assert.That(application.TaggedValues, Is.Empty, "a base_ element is not a tagged value");
            }
        }

        [Test]
        public void Verify_that_an_element_without_base_reference_is_not_a_stereotype_application()
        {
            const string xml = "<Demo:Note xmlns:Demo=\"urn:demo\" text=\"x\"><base_Class/><other>y</other></Demo:Note>";

            var stereoTypeApplicationReader = new StereoTypeApplicationReader(null);

            using var xmlReader = XmlReader.Create(new StringReader(xml));

            using (Assert.EnterMultipleScope())
            {
                Assert.That(stereoTypeApplicationReader.TryRead(xmlReader, out var application), Is.False);
                Assert.That(application, Is.Null);
            }
        }
    }
}
