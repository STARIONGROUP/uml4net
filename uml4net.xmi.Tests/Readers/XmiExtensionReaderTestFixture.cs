// -------------------------------------------------------------------------------------------------
// <copyright file="XmiExtensionReaderTestFixture.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;

    using Microsoft.Extensions.Logging.Abstractions;

    using Moq;

    using NUnit.Framework;

    using uml4net.xmi.Extender;
    using uml4net.xmi.Readers;
    using uml4net.xmi.Settings;

    [TestFixture]
    public class XmiExtensionReaderTestFixture
    {
        private const string XmiNamespace = "http://www.omg.org/spec/XMI/20131001";

        private const string ExtensionWithMultipleChildren = """
            <xmi:Extension xmlns:xmi="http://www.omg.org/spec/XMI/20131001" xmi:id="EAID_EXTENSION" xmi:uuid="EAUUID_EXTENSION" extender="Enterprise Architect" extenderID="6.5">
              <elements><element name="element-1" /></elements>
              <connectors><connector name="connector-1" /></connectors>
              <profiles><profile name="profile-1" /></profiles>
            </xmi:Extension>
            """;

        private Mock<IExtenderReaderRegistry> extenderReaderRegistry;

        private Mock<IExtenderReader> extenderReader;

        private IXmiReaderSettings xmiReaderSettings;

        private NameSpaceResolver nameSpaceResolver;

        private XmiExtensionReader xmiExtensionReader;

        [SetUp]
        public void SetUp()
        {
            this.extenderReader = new Mock<IExtenderReader>();
            this.extenderReader.Setup(x => x.ReadContent(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(() => new List<object> { new object() });

            this.extenderReaderRegistry = new Mock<IExtenderReaderRegistry>();

            this.xmiReaderSettings = new DefaultSettings();

            this.nameSpaceResolver = new NameSpaceResolver();
            this.nameSpaceResolver.ResolveAndSetNamespace(XmiNamespace);

            this.xmiExtensionReader = new XmiExtensionReader(this.xmiReaderSettings, this.nameSpaceResolver,
                this.extenderReaderRegistry.Object, NullLoggerFactory.Instance);
        }

        [Test]
        public void Verify_that_null_arguments_throw_exception()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => this.xmiExtensionReader.Read(null, "document.xmi", XmiNamespace),
                    Throws.TypeOf<ArgumentNullException>());

                Assert.That(() => this.xmiExtensionReader.Read(CreateXmlReader(ExtensionWithMultipleChildren), "", XmiNamespace),
                    Throws.TypeOf<ArgumentException>());

                Assert.That(() => this.xmiExtensionReader.Read(CreateXmlReader(ExtensionWithMultipleChildren), "document.xmi", ""),
                    Throws.TypeOf<ArgumentException>());
            }
        }

        [Test]
        public void Verify_that_the_attributes_of_the_Extension_are_read()
        {
            this.extenderReaderRegistry.Setup(x => x.Resolve("Enterprise Architect", "6.5")).Returns(this.extenderReader.Object);

            var xmiExtension = this.xmiExtensionReader.Read(CreateXmlReader(ExtensionWithMultipleChildren), "document.xmi", XmiNamespace);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(xmiExtension.Id, Is.EqualTo("EAID_EXTENSION"));
                Assert.That(xmiExtension.Uuid, Is.EqualTo("EAUUID_EXTENSION"));
                Assert.That(xmiExtension.Extender, Is.EqualTo("Enterprise Architect"));
                Assert.That(xmiExtension.ExtenderId, Is.EqualTo("6.5"));
                Assert.That(xmiExtension.DocumentName, Is.EqualTo("document.xmi"));
            }
        }

        [Test]
        public void Verify_that_ContentRawXmi_accumulates_all_top_level_children()
        {
            this.extenderReaderRegistry.Setup(x => x.Resolve("Enterprise Architect", "6.5")).Returns(this.extenderReader.Object);

            var xmiExtension = this.xmiExtensionReader.Read(CreateXmlReader(ExtensionWithMultipleChildren), "document.xmi", XmiNamespace);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(xmiExtension.ContentRawXmi, Does.Contain("<elements>"));
                Assert.That(xmiExtension.ContentRawXmi, Does.Contain("<connectors>"));
                Assert.That(xmiExtension.ContentRawXmi, Does.Contain("<profiles>"));

                Assert.That(xmiExtension.Content, Has.Count.EqualTo(3));
            }

            this.extenderReader.Verify(x => x.ReadContent(It.IsAny<string>(), "document.xmi"), Times.Exactly(3));
        }

        [Test]
        public void Verify_that_each_top_level_child_is_provided_to_the_ExtenderReader()
        {
            this.extenderReaderRegistry.Setup(x => x.Resolve("Enterprise Architect", "6.5")).Returns(this.extenderReader.Object);

            var providedContent = new List<string>();

            this.extenderReader.Setup(x => x.ReadContent(It.IsAny<string>(), It.IsAny<string>()))
                .Callback<string, string>((extensionXmi, _) => providedContent.Add(extensionXmi))
                .Returns(() => new List<object>());

            this.xmiExtensionReader.Read(CreateXmlReader(ExtensionWithMultipleChildren), "document.xmi", XmiNamespace);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(providedContent, Has.Count.EqualTo(3));
                Assert.That(providedContent[0], Does.StartWith("<elements>"));
                Assert.That(providedContent[1], Does.StartWith("<connectors>"));
                Assert.That(providedContent[2], Does.StartWith("<profiles>"));
            }
        }

        [Test]
        public void Verify_that_ContentRawXmi_is_read_when_no_ExtenderReader_is_registered()
        {
            this.extenderReaderRegistry.Setup(x => x.Resolve(It.IsAny<string>(), It.IsAny<string>())).Returns((IExtenderReader)null);

            var xmiExtension = this.xmiExtensionReader.Read(CreateXmlReader(ExtensionWithMultipleChildren), "document.xmi", XmiNamespace);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(xmiExtension.ContentRawXmi, Does.Contain("<elements>"));
                Assert.That(xmiExtension.ContentRawXmi, Does.Contain("<connectors>"));
                Assert.That(xmiExtension.ContentRawXmi, Does.Contain("<profiles>"));

                Assert.That(xmiExtension.Content, Is.Empty);
            }
        }

        [Test]
        public void Verify_that_ContentRawXmi_is_null_when_the_Extension_is_empty()
        {
            const string emptyExtension = """
                <xmi:Extension xmlns:xmi="http://www.omg.org/spec/XMI/20131001" extender="Enterprise Architect" extenderID="6.5" />
                """;

            this.extenderReaderRegistry.Setup(x => x.Resolve("Enterprise Architect", "6.5")).Returns(this.extenderReader.Object);

            var xmiExtension = this.xmiExtensionReader.Read(CreateXmlReader(emptyExtension), "document.xmi", XmiNamespace);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(xmiExtension.ContentRawXmi, Is.Null);
                Assert.That(xmiExtension.Content, Is.Empty);
            }
        }

        [Test]
        public void Verify_that_an_unexpected_xmi_type_throws_exception()
        {
            const string extensionWithUnexpectedType = """
                <xmi:Extension xmlns:xmi="http://www.omg.org/spec/XMI/20131001" xmi:type="uml:Class" extender="Enterprise Architect" extenderID="6.5" />
                """;

            Assert.That(() => this.xmiExtensionReader.Read(CreateXmlReader(extensionWithUnexpectedType), "document.xmi", XmiNamespace),
                Throws.TypeOf<XmlException>());
        }

        private static XmlReader CreateXmlReader(string xml)
        {
            return XmlReader.Create(new StringReader(xml));
        }
    }
}
