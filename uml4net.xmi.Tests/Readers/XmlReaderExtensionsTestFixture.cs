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
        public void Verify_that_ReadElementContentAsStringInPlace_returns_null_for_a_nil_element()
        {
            using var xmlReader = CreateReaderPositionedOnFirstChild("<root xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'><a xsi:nil='true'/><b/></root>");

            var value = xmlReader.ReadElementContentAsStringInPlace();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(value, Is.Null);
                Assert.That(xmlReader.LocalName, Is.EqualTo("a"));

                Assert.That(xmlReader.Read(), Is.True);
                Assert.That(xmlReader.LocalName, Is.EqualTo("b"));
            }
        }

        [Test]
        public void Verify_that_IsNil_recognises_the_lexical_forms_of_true_in_the_XML_Schema_instance_namespace()
        {
            using var xmlReader = CreateReaderPositionedOnFirstChild("<root xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:other='http://example.com'><a xsi:nil='true'/><b xsi:nil=' 1 '/><c xsi:nil='false'/><d nil='true'/><e other:nil='true'/><f/></root>");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(xmlReader.IsNil(), Is.True, "true");
                xmlReader.Read();
                Assert.That(xmlReader.IsNil(), Is.True, "1");
                xmlReader.Read();
                Assert.That(xmlReader.IsNil(), Is.False, "false");
                xmlReader.Read();
                Assert.That(xmlReader.IsNil(), Is.False, "nil without the xsi namespace");
                xmlReader.Read();
                Assert.That(xmlReader.IsNil(), Is.False, "nil in another namespace");
                xmlReader.Read();
                Assert.That(xmlReader.IsNil(), Is.False, "no nil attribute");
            }
        }

        [Test]
        public void Verify_that_GetHrefAttribute_returns_href_or_the_XLink_simple_link()
        {
            using var xmlReader = CreateReaderPositionedOnFirstChild("<root xmlns:xlink='http://www.w3.org/1999/xlink' xmlns:XLink='http://www.w3.org/1999/XLink' xmlns:other='http://example.com'><a href='doc#1'/><b xlink:href='doc#2' xlink:type='simple'/><c XLink:href='doc#3'/><d href='doc#4' xlink:href='doc#5'/><e other:href='doc#6'/><f/></root>");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(xmlReader.GetHrefAttribute(), Is.EqualTo("doc#1"), "plain href");
                Assert.That(xmlReader.NodeType, Is.EqualTo(XmlNodeType.Element), "the reader is left on the element");
                xmlReader.Read();
                Assert.That(xmlReader.GetHrefAttribute(), Is.EqualTo("doc#2"), "xlink:href in the XLink namespace");
                xmlReader.Read();
                Assert.That(xmlReader.GetHrefAttribute(), Is.EqualTo("doc#3"), "the XLink namespace as spelled in the XMI specification");
                xmlReader.Read();
                Assert.That(xmlReader.GetHrefAttribute(), Is.EqualTo("doc#4"), "the XMI href wins over xlink:href");
                xmlReader.Read();
                Assert.That(xmlReader.GetHrefAttribute(), Is.Null, "href in another namespace is not a link");
                xmlReader.Read();
                Assert.That(xmlReader.GetHrefAttribute(), Is.Null, "no link");
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
        public void Verify_that_GetXmiAttribute_finds_the_attribute_whatever_the_prefix_and_XMI_version()
        {
            using var xmlReader = CreateReaderPositionedOnFirstChild("<root xmlns:x='http://www.omg.org/spec/XMI/20161101' xmlns:uml='http://www.omg.org/spec/UML/20131001'><a x:type='uml:Class' x:id='c1' name='n' type='notXmi'/></root>");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(xmlReader.GetXmiAttribute("type"), Is.EqualTo("uml:Class"), "the unprefixed 'type' attribute is not in the XMI namespace and is not to be returned");
                Assert.That(xmlReader.GetXmiAttribute("id"), Is.EqualTo("c1"));
                Assert.That(xmlReader.GetXmiAttribute("idref"), Is.Null);
                Assert.That(xmlReader.NodeType, Is.EqualTo(XmlNodeType.Element), "the reader is to remain positioned on the element");
                Assert.That(xmlReader.LocalName, Is.EqualTo("a"));
            }
        }

        [Test]
        public void Verify_that_GetXmiAttribute_returns_null_for_an_element_without_attributes()
        {
            using var xmlReader = CreateReaderPositionedOnFirstChild("<root><a/></root>");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(xmlReader.GetXmiAttribute("id"), Is.Null);
                Assert.That(() => xmlReader.GetXmiAttribute(null), Throws.ArgumentException);
            }
        }

        [Test]
        public void Verify_that_ResolveQualifiedName_maps_the_document_prefix_to_the_known_prefix()
        {
            var nameSpaceResolver = new NameSpaceResolver();

            using var xmlReader = CreateReaderPositionedOnFirstChild("<root xmlns='http://www.omg.org/spec/UML/20161101' xmlns:UML='http://www.omg.org/spec/UML/20131001' xmlns:x='http://www.omg.org/spec/XMI/20131001' xmlns:foo='http://example.com/foo'><a/></root>");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(xmlReader.ResolveQualifiedName("UML:Class", nameSpaceResolver), Is.EqualTo("uml:Class"));
                Assert.That(xmlReader.ResolveQualifiedName("Class", nameSpaceResolver), Is.EqualTo("uml:Class"), "an unprefixed name is resolved through the default namespace");
                Assert.That(xmlReader.ResolveQualifiedName("x:Extension", nameSpaceResolver), Is.EqualTo("xmi:Extension"));
                Assert.That(xmlReader.ResolveQualifiedName("foo:Bar", nameSpaceResolver), Is.EqualTo("foo:Bar"), "an unknown namespace is left as is");
                Assert.That(xmlReader.ResolveQualifiedName("unbound:Bar", nameSpaceResolver), Is.EqualTo("unbound:Bar"), "an unbound prefix is left as is");
                Assert.That(xmlReader.ResolveQualifiedName(null, nameSpaceResolver), Is.Null);
                Assert.That(xmlReader.ResolveQualifiedName(string.Empty, nameSpaceResolver), Is.Empty);
                Assert.That(() => xmlReader.ResolveQualifiedName("uml:Class", null), Throws.ArgumentNullException);
            }
        }

        [Test]
        public void Verify_that_ResolveQualifiedName_falls_back_to_the_registered_document_prefixes_for_a_subtree_reader()
        {
            var nameSpaceResolver = new NameSpaceResolver();

            using var xmlReader = CreateReaderPositionedOnFirstChild("<root xmlns:UML='http://www.omg.org/spec/UML/20131001'><a><b/></a></root>");
            using var subtreeReader = xmlReader.ReadSubtree();
            subtreeReader.MoveToContent();
            subtreeReader.Read();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(subtreeReader.LocalName, Is.EqualTo("b"));
                Assert.That(subtreeReader.ResolveQualifiedName("UML:Class", nameSpaceResolver), Is.EqualTo("UML:Class"), "a prefix declared on an ancestor outside the subtree is not resolvable by the subtree reader");

                nameSpaceResolver.RegisterDocumentPrefix("UML", "http://www.omg.org/spec/UML/20131001");

                Assert.That(subtreeReader.ResolveQualifiedName("UML:Class", nameSpaceResolver), Is.EqualTo("uml:Class"), "the registered document prefix is used as fallback");
            }
        }

        [Test]
        public void Verify_that_IsXmiNamespace_recognises_the_OMG_XMI_namespaces()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(XmlReaderExtensions.IsXmiNamespace("http://www.omg.org/spec/XMI/20131001"), Is.True);
                Assert.That(XmlReaderExtensions.IsXmiNamespace("https://www.omg.org/spec/XMI/20161101"), Is.True);
                Assert.That(XmlReaderExtensions.IsXmiNamespace("http://www.omg.org/spec/UML/20131001"), Is.False);
                Assert.That(XmlReaderExtensions.IsXmiNamespace(null), Is.False);
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
                Assert.That(() => xmlReader.IsNil(), Throws.ArgumentNullException);
                Assert.That(() => xmlReader.GetHrefAttribute(), Throws.ArgumentNullException);
                Assert.That(() => xmlReader.GetXmiAttribute("id"), Throws.ArgumentNullException);
                Assert.That(() => xmlReader.ResolveQualifiedName("uml:Class", new NameSpaceResolver()), Throws.ArgumentNullException);
            }
        }
    }
}
