// -------------------------------------------------------------------------------------------------
//  <copyright file="XmlNamespacesTestFixture.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2025 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
//  </copyright>
//  ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Tests.Readers
{
    using NUnit.Framework;

    using uml4net.xmi.Readers;

    [TestFixture]
    public class XmlNamespacesTestFixture
    {
        [Test]
        public void QuerySupportedNamespaces_Returns_Other_When_Null_Or_Whitespace()
        {
            Assert.That(XmlNamespaces.QuerySupportedNamespaces(null), Is.EqualTo(SupportedNamespaces.Other));
            Assert.That(XmlNamespaces.QuerySupportedNamespaces(string.Empty), Is.EqualTo(SupportedNamespaces.Other));
            Assert.That(XmlNamespaces.QuerySupportedNamespaces("   \t\r\n  "), Is.EqualTo(SupportedNamespaces.Other));
        }

        [Test]
        public void QuerySupportedNamespaces_Trims_Input()
        {
            var input = "   http://www.omg.org/spec/XMI/20161101   ";
            var result = XmlNamespaces.QuerySupportedNamespaces(input);
            Assert.That(result, Is.EqualTo(SupportedNamespaces.Xmi));
        }

        [TestCase("http://www.omg.org/spec/XMI/20161101")]
        [TestCase("https://www.omg.org/spec/XMI/20161101")]
        public void QuerySupportedNamespaces_Recognizes_Xmi(string uri)
        {
            Assert.That(XmlNamespaces.QuerySupportedNamespaces(uri), Is.EqualTo(SupportedNamespaces.Xmi));
        }

        [TestCase("http://www.omg.org/spec/UML/20161101")]
        [TestCase("https://www.omg.org/spec/UML/20161101")]
        public void QuerySupportedNamespaces_Recognizes_Uml_Base(string uri)
        {
            Assert.That(XmlNamespaces.QuerySupportedNamespaces(uri), Is.EqualTo(SupportedNamespaces.Uml));
        }

        [TestCase("http://www.omg.org/spec/UML/20131001/StandardProfile")]
        [TestCase("https://www.omg.org/spec/UML/20131001/StandardProfile")]
        public void QuerySupportedNamespaces_Recognizes_Uml_StandardProfile(string uri)
        {
            Assert.That(XmlNamespaces.QuerySupportedNamespaces(uri), Is.EqualTo(SupportedNamespaces.UmlStandardProfile));
        }

        [TestCase("http://www.omg.org/spec/UML/20131001/UMLDI")]
        [TestCase("http://www.omg.org/spec/UML/20131001/UMLDI/")]
        public void QuerySupportedNamespaces_Maps_UMLDI_To_UmlStandardProfile(string uri)
        {
            Assert.That(XmlNamespaces.QuerySupportedNamespaces(uri), Is.EqualTo(SupportedNamespaces.UmlStandardProfile));
        }

        [TestCase("http://www.eclipse.org/uml2/5.0.0/UML")]
        [TestCase("https://www.eclipse.org/uml2/5.0.0/UML")]
        public void QuerySupportedNamespaces_Recognizes_Eclipse_Uml2_Uml(string uri)
        {
            Assert.That(XmlNamespaces.QuerySupportedNamespaces(uri), Is.EqualTo(SupportedNamespaces.Uml));
        }

        [TestCase("http://www.eclipse.org/uml2/5.0.0")]
        [TestCase("https://www.eclipse.org/uml2/5.0.0/NotUml")]
        [TestCase("http://example.com/spec/UML/20161101")]
        [TestCase("http://www.omg.org/spec/XMI")] // missing trailing slash and version 
        public void QuerySupportedNamespaces_Returns_Other_For_Unknowns(string uri)
        {
            Assert.That(XmlNamespaces.QuerySupportedNamespaces(uri), Is.EqualTo(SupportedNamespaces.Other));
        }
    }
}
