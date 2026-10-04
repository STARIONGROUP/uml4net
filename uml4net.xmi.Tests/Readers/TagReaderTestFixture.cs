// -------------------------------------------------------------------------------------------------
// <copyright file="TagReaderTestFixture.cs" company="Starion Group S.A.">
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
    using System.IO;
    using System.Xml;

    using NUnit.Framework;

    using uml4net.xmi.Readers;

    [TestFixture]
    public class TagReaderTestFixture
    {
        private const string MofExtNamespaceUri = "http://www.omg.org/spec/MOF/20131001";

        private TagReader tagReader;

        [SetUp]
        public void SetUp()
        {
            var nameSpaceResolver = new NameSpaceResolver();
            nameSpaceResolver.ResolveAndSetNamespace("http://www.omg.org/spec/XMI/20131001");
            nameSpaceResolver.ResolveAndSetNamespace(MofExtNamespaceUri);

            this.tagReader = new TagReader(nameSpaceResolver, null);
        }

        [Test]
        public void Verify_that_a_Tag_serialized_with_attributes_is_read()
        {
            const string xml = "<mofext:Tag xmlns:mofext=\"http://www.omg.org/spec/MOF/20131001\" xmlns:xmi=\"http://www.omg.org/spec/XMI/20131001\" " +
                               "xmi:type=\"mofext:Tag\" xmi:id=\"t\" xmi:uuid=\"u\" name=\"org.omg.xmi.nsPrefix\" value=\"uml\" element=\"a b\"/>";

            var tag = this.tagReader.Read(XmlReader.Create(new StringReader(xml)), MofExtNamespaceUri);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(tag.XmiId, Is.EqualTo("t"));
                Assert.That(tag.XmiUuid, Is.EqualTo("u"));
                Assert.That(tag.Name, Is.EqualTo("org.omg.xmi.nsPrefix"));
                Assert.That(tag.Value, Is.EqualTo("uml"));
                Assert.That(tag.Element, Is.EqualTo(new[] { "a", "b" }));
            }
        }

        [Test]
        public void Verify_that_a_Tag_serialized_with_elements_as_in_Canonical_XMI_is_read()
        {
            const string xml = "<mofext:Tag xmlns:mofext=\"http://www.omg.org/spec/MOF/20131001\" xmlns:xmi=\"http://www.omg.org/spec/XMI/20131001\" " +
                               "xmi:id=\"t\" xmi:uuid=\"u\" xmi:type=\"mofext:Tag\"><name>org.omg.xmi.nsURI</name><value>http://example.org</value>" +
                               "<element xmi:idref=\"a\"/><element href=\"other.xmi#b\"/><unknown>ignored</unknown></mofext:Tag>";

            var tag = this.tagReader.Read(XmlReader.Create(new StringReader(xml)), MofExtNamespaceUri);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(tag.XmiUuid, Is.EqualTo("u"));
                Assert.That(tag.Name, Is.EqualTo("org.omg.xmi.nsURI"));
                Assert.That(tag.Value, Is.EqualTo("http://example.org"));
                Assert.That(tag.Element, Is.EqualTo(new[] { "a", "other.xmi#b" }));
            }
        }
    }
}
