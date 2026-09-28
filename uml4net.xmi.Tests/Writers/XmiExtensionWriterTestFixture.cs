// -------------------------------------------------------------------------------------------------
// <copyright file="XmiExtensionWriterTestFixture.cs" company="Starion Group S.A.">
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
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;

    using NUnit.Framework;

    using uml4net.xmi.Settings;
    using uml4net.xmi.Writers;

    [TestFixture]
    public class XmiExtensionWriterTestFixture
    {
        private DefaultWriterSettings settings;

        private XmiExtensionWriter xmiExtensionWriter;

        [SetUp]
        public void SetUp()
        {
            this.settings = new DefaultWriterSettings();
            this.xmiExtensionWriter = new XmiExtensionWriter(this.settings, null);
        }

        private static XmiExtension CreateExtension()
        {
            return new XmiExtension { Id = "ext", Extender = "Enterprise Architect", ExtenderId = "6.5", ContentRawXmi = "<elements/>" };
        }

        private string Write(Action<XmlWriter> write)
        {
            var builder = new StringBuilder();

            using (var xmlWriter = XmlWriter.Create(builder, new XmlWriterSettings { OmitXmlDeclaration = true, Async = true }))
            {
                xmlWriter.WriteStartElement("xmi", "XMI", this.settings.XmiNamespaceUri);
                write(xmlWriter);
                xmlWriter.WriteEndElement();
            }

            return builder.ToString();
        }

        private async Task<string> WriteAsync(Func<XmlWriter, Task> write)
        {
            var builder = new StringBuilder();

            using (var xmlWriter = XmlWriter.Create(builder, new XmlWriterSettings { OmitXmlDeclaration = true, Async = true }))
            {
                await xmlWriter.WriteStartElementAsync("xmi", "XMI", this.settings.XmiNamespaceUri);
                await write(xmlWriter);
                await xmlWriter.WriteEndElementAsync();
            }

            return builder.ToString();
        }

        [Test]
        public async Task Verify_that_an_extension_is_written_as_a_lowercase_extension_element_with_its_type()
        {
            // XMI 2.5.1 clause 7.5.3: the uppercase Extension may only be used as a root element, so within xmi:XMI, a
            // model element or xmi:documentation the lowercase element name is used; clause 9.5.3:
            // "<xmi:extension" "xmi:type='xmi:Extension'"
            const string expected = "<xmi:extension xmi:type=\"xmi:Extension\" xmi:id=\"ext\" extender=\"Enterprise Architect\" extenderID=\"6.5\"><elements/></xmi:extension>";

            var written = this.Write(x => this.xmiExtensionWriter.Write(x, CreateExtension()));
            var writtenAsync = await this.WriteAsync(x => this.xmiExtensionWriter.WriteAsync(x, CreateExtension()));

            using (Assert.EnterMultipleScope())
            {
                Assert.That(written, Does.Contain(expected));
                Assert.That(writtenAsync, Is.EqualTo(written));
            }
        }

        [Test]
        public void Verify_that_the_arguments_are_checked()
        {
            using var xmlWriter = XmlWriter.Create(new MemoryStream(), new XmlWriterSettings { Async = true });

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => this.xmiExtensionWriter.Write(null, CreateExtension()), Throws.ArgumentNullException);
                Assert.That(() => this.xmiExtensionWriter.Write(xmlWriter, null), Throws.ArgumentNullException);
                Assert.That(async () => await this.xmiExtensionWriter.WriteAsync(null, CreateExtension()), Throws.ArgumentNullException);
                Assert.That(async () => await this.xmiExtensionWriter.WriteAsync(xmlWriter, null), Throws.ArgumentNullException);
            }
        }
    }
}
