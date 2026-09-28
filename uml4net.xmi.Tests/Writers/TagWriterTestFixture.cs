// -------------------------------------------------------------------------------------------------
// <copyright file="TagWriterTestFixture.cs" company="Starion Group S.A.">
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

    using uml4net.Mof.Extension;
    using uml4net.xmi.Settings;
    using uml4net.xmi.Writers;

    [TestFixture]
    public class TagWriterTestFixture
    {
        private DefaultWriterSettings settings;

        private TagWriter tagWriter;

        [SetUp]
        public void SetUp()
        {
            this.settings = new DefaultWriterSettings();
            this.tagWriter = new TagWriter(this.settings, null);
        }

        private static Tag CreateTag()
        {
            var tag = new Tag { XmiId = "_1", Name = "org.omg.xmi.schemaType", Value = "http://www.w3.org/2001/XMLSchema#boolean" };
            tag.Element.Add("Boolean");
            tag.Element.Add("Integer");
            return tag;
        }

        private string Write(Action<XmlWriter> write)
        {
            var builder = new StringBuilder();

            using (var xmlWriter = XmlWriter.Create(builder, new XmlWriterSettings { OmitXmlDeclaration = true, Async = true }))
            {
                xmlWriter.WriteStartElement("xmi", "XMI", this.settings.XmiNamespaceUri);
                xmlWriter.WriteAttributeString("xmlns", "mofext", null, this.settings.MofExtNamespaceUri);
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
                await xmlWriter.WriteAttributeStringAsync("xmlns", "mofext", null, this.settings.MofExtNamespaceUri);
                await write(xmlWriter);
                await xmlWriter.WriteEndElementAsync();
            }

            return builder.ToString();
        }

        [Test]
        public async Task Verify_that_a_Tag_is_written_as_a_mofext_Tag_element()
        {
            const string expected = "<mofext:Tag xmi:type=\"mofext:Tag\" xmi:id=\"_1\" name=\"org.omg.xmi.schemaType\" value=\"http://www.w3.org/2001/XMLSchema#boolean\" element=\"Boolean Integer\" />";

            var written = this.Write(x => this.tagWriter.Write(x, CreateTag()));
            var writtenAsync = await this.WriteAsync(x => this.tagWriter.WriteAsync(x, CreateTag()));

            using (Assert.EnterMultipleScope())
            {
                Assert.That(written, Does.Contain(expected));
                Assert.That(writtenAsync, Is.EqualTo(written));
            }
        }

        [Test]
        public async Task Verify_that_the_optional_attributes_of_a_Tag_are_omitted()
        {
            var written = this.Write(x => this.tagWriter.Write(x, new Tag()));
            var writtenAsync = await this.WriteAsync(x => this.tagWriter.WriteAsync(x, new Tag()));

            using (Assert.EnterMultipleScope())
            {
                Assert.That(written, Does.Contain("<mofext:Tag xmi:type=\"mofext:Tag\" />"));
                Assert.That(writtenAsync, Is.EqualTo(written));
            }
        }

        [Test]
        public void Verify_that_the_arguments_are_checked()
        {
            using var xmlWriter = XmlWriter.Create(new MemoryStream(), new XmlWriterSettings { Async = true });

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => new TagWriter(null, null), Throws.ArgumentNullException);
                Assert.That(() => this.tagWriter.Write(null, new Tag()), Throws.ArgumentNullException);
                Assert.That(() => this.tagWriter.Write(xmlWriter, null), Throws.ArgumentNullException);
                Assert.That(async () => await this.tagWriter.WriteAsync(null, new Tag()), Throws.ArgumentNullException);
                Assert.That(async () => await this.tagWriter.WriteAsync(xmlWriter, null), Throws.ArgumentNullException);
            }
        }
    }
}
