// -------------------------------------------------------------------------------------------------
// <copyright file="XmlReaderExtensionsTestFixture.cs" company="Starion Group S.A.">
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
    public class XmlReaderExtensionsTestFixture
    {
        private static XmlReader CreateReaderPositionedOnFirstChild(string xml)
        {
            var xmlReader = XmlReader.Create(new StringReader(xml));
            xmlReader.MoveToContent();
            xmlReader.Read();
            return xmlReader;
        }

        [Test]
        public void Verify_that_ReadElementContentAsStringInPlace_leaves_the_reader_on_the_end_tag()
        {
            using var xmlReader = CreateReaderPositionedOnFirstChild("<root><a>value</a><b/></root>");

            var value = xmlReader.ReadElementContentAsStringInPlace();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(value, Is.EqualTo("value"));
                Assert.That(xmlReader.NodeType, Is.EqualTo(XmlNodeType.EndElement));
                Assert.That(xmlReader.LocalName, Is.EqualTo("a"));

                Assert.That(xmlReader.Read(), Is.True);
                Assert.That(xmlReader.NodeType, Is.EqualTo(XmlNodeType.Element));
                Assert.That(xmlReader.LocalName, Is.EqualTo("b"), "the sibling that directly follows the value element is not to be skipped");
            }
        }

        [Test]
        public void Verify_that_ReadElementContentAsStringInPlace_handles_an_empty_element()
        {
            using var xmlReader = CreateReaderPositionedOnFirstChild("<root><a/><b/></root>");

            var value = xmlReader.ReadElementContentAsStringInPlace();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(value, Is.Empty);
                Assert.That(xmlReader.LocalName, Is.EqualTo("a"));

                Assert.That(xmlReader.Read(), Is.True);
                Assert.That(xmlReader.LocalName, Is.EqualTo("b"));
            }
        }

        [Test]
        public void Verify_that_SkipInPlace_leaves_the_reader_on_the_end_tag()
        {
            using var xmlReader = CreateReaderPositionedOnFirstChild("<root><a><nested>x</nested></a><b/></root>");

            xmlReader.SkipInPlace();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(xmlReader.NodeType, Is.EqualTo(XmlNodeType.EndElement));
                Assert.That(xmlReader.LocalName, Is.EqualTo("a"));

                Assert.That(xmlReader.Read(), Is.True);
                Assert.That(xmlReader.LocalName, Is.EqualTo("b"), "the sibling that directly follows the skipped element is not to be skipped");
            }
        }

        [Test]
        public void Verify_that_SkipInPlace_handles_an_empty_element()
        {
            using var xmlReader = CreateReaderPositionedOnFirstChild("<root><a/><b/></root>");

            xmlReader.SkipInPlace();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(xmlReader.LocalName, Is.EqualTo("a"));

                Assert.That(xmlReader.Read(), Is.True);
                Assert.That(xmlReader.LocalName, Is.EqualTo("b"));
            }
        }

        [Test]
        public void Verify_that_the_extension_methods_throw_when_the_reader_is_null()
        {
            XmlReader xmlReader = null;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => xmlReader.ReadElementContentAsStringInPlace(), Throws.ArgumentNullException);
                Assert.That(() => xmlReader.SkipInPlace(), Throws.ArgumentNullException);
            }
        }
    }
}
