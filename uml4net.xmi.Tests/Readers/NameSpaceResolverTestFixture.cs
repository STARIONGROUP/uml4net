// -------------------------------------------------------------------------------------------------
// <copyright file="NameSpaceResolverTestFixture.cs" company="Starion Group S.A.">
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
    using NUnit.Framework;

    using uml4net.xmi.Readers;

    [TestFixture]
    public class NameSpaceResolverTestFixture
    {
        private NameSpaceResolver nameSpaceResolver;

        [SetUp]
        public void SetUp()
        {
            this.nameSpaceResolver = new NameSpaceResolver();
        }

        [Test]
        public void QuerySupportedNamespaces_Returns_Other_When_Null_Or_Whitespace()
        {
            Assert.That(this.nameSpaceResolver.ResolvePrefix(null), Is.EqualTo("other"));
            Assert.That(this.nameSpaceResolver.ResolvePrefix(string.Empty), Is.EqualTo("other"));
            Assert.That(this.nameSpaceResolver.ResolvePrefix("   \t\r\n  "), Is.EqualTo("other"));
        }

        [Test]
        public void QuerySupportedNamespaces_Trims_Input()
        {
            var input = "   http://www.omg.org/spec/XMI/20161101   ";
            var result = this.nameSpaceResolver.ResolvePrefix(input);
            Assert.That(result, Is.EqualTo("xmi"));
        }

        [TestCase("http://www.omg.org/spec/XMI/20161101")]
        [TestCase("https://www.omg.org/spec/XMI/20161101")]
        public void QuerySupportedNamespaces_Recognizes_Xmi(string uri)
        {
            Assert.That(this.nameSpaceResolver.ResolvePrefix(uri), Is.EqualTo("xmi"));
        }

        [TestCase("http://www.omg.org/spec/UML/20161101")]
        [TestCase("https://www.omg.org/spec/UML/20161101")]
        public void QuerySupportedNamespaces_Recognizes_Uml_Base(string uri)
        {
            Assert.That(this.nameSpaceResolver.ResolvePrefix(uri), Is.EqualTo("uml"));
        }

        [TestCase("http://www.omg.org/spec/UML/20131001/StandardProfile")]
        [TestCase("https://www.omg.org/spec/UML/20131001/StandardProfile")]
        public void QuerySupportedNamespaces_Recognizes_Uml_StandardProfile(string uri)
        {
            Assert.That(this.nameSpaceResolver.ResolvePrefix(uri), Is.EqualTo("StandardProfile"));
        }

        [TestCase("http://www.omg.org/spec/UML/20131001/UMLDI")]
        [TestCase("http://www.omg.org/spec/UML/20131001/UMLDI/")]
        public void QuerySupportedNamespaces_Maps_UMLDI_To_UmlStandardProfile(string uri)
        {
            Assert.That(this.nameSpaceResolver.ResolvePrefix(uri), Is.EqualTo("umldi"));
        }

        [TestCase("http://www.eclipse.org/uml2/5.0.0/UML")]
        [TestCase("https://www.eclipse.org/uml2/5.0.0/UML")]
        public void QuerySupportedNamespaces_Recognizes_Eclipse_Uml2_Uml(string uri)
        {
            Assert.That(this.nameSpaceResolver.ResolvePrefix(uri), Is.EqualTo("uml"));
        }

        [TestCase("http://www.eclipse.org/uml2/5.0.0")]
        [TestCase("https://www.eclipse.org/uml2/5.0.0/NotUml")]
        [TestCase("http://example.com/spec/UML/20161101")]
        [TestCase("http://www.omg.org/spec/XMI")] // missing trailing slash and version 
        public void QuerySupportedNamespaces_Returns_Other_For_Unknowns(string uri)
        {
            Assert.That(this.nameSpaceResolver.ResolvePrefix(uri), Is.EqualTo("other"));
        }

        [Test]
        public void Verify_that_Register_behaves_as_expected()
        {
            Assert.That(() => this.nameSpaceResolver.Register("https://www.stariongroup.eu", "sg"), Throws.Nothing);

            Assert.That(this.nameSpaceResolver.ResolvePrefix("https://www.stariongroup.eu"), Is.EqualTo("sg"));

            Assert.That(() =>this.nameSpaceResolver.Register(null, null), Throws.ArgumentException);
            Assert.That(() => this.nameSpaceResolver.Register("https://www.stariongroup.eu", null), Throws.ArgumentException);
        }

        [Test]
        public void Verify_that_document_prefixes_are_resolved_to_the_supported_prefix()
        {
            this.nameSpaceResolver.RegisterDocumentPrefix("UML", "http://www.omg.org/spec/UML/20131001");
            this.nameSpaceResolver.RegisterDocumentPrefix("x", "http://www.omg.org/spec/XMI/20161101");
            this.nameSpaceResolver.RegisterDocumentPrefix(string.Empty, "http://www.omg.org/spec/UML/20161101");
            this.nameSpaceResolver.RegisterDocumentPrefix("foo", "http://example.com/foo");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(this.nameSpaceResolver.ResolveDocumentPrefix("UML"), Is.EqualTo("uml"));
                Assert.That(this.nameSpaceResolver.ResolveDocumentPrefix("x"), Is.EqualTo("xmi"));
                Assert.That(this.nameSpaceResolver.ResolveDocumentPrefix(string.Empty), Is.EqualTo("uml"), "the default namespace is registered with an empty prefix");
                Assert.That(this.nameSpaceResolver.ResolveDocumentPrefix(null), Is.EqualTo("uml"), "null is treated as the default namespace");
                Assert.That(this.nameSpaceResolver.ResolveDocumentPrefix("foo"), Is.EqualTo("other"), "a prefix bound to an unsupported namespace");
                Assert.That(this.nameSpaceResolver.ResolveDocumentPrefix("unknown"), Is.EqualTo("other"));
                Assert.That(() => this.nameSpaceResolver.RegisterDocumentPrefix("bar", null), Throws.ArgumentException);
            }
        }

        [Test]
        public void Verify_that_registering_a_document_prefix_again_overrides_the_earlier_binding()
        {
            this.nameSpaceResolver.RegisterDocumentPrefix("p", "http://www.omg.org/spec/UML/20131001");
            this.nameSpaceResolver.RegisterDocumentPrefix("p", "http://www.omg.org/spec/XMI/20131001");

            Assert.That(this.nameSpaceResolver.ResolveDocumentPrefix("p"), Is.EqualTo("xmi"));
        }
    }
}
