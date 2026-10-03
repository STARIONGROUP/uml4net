// -------------------------------------------------------------------------------------------------
// <copyright file="CapturedElementWriterTestFixture.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;

    using Microsoft.Extensions.Logging.Abstractions;

    using NUnit.Framework;

    using uml4net.xmi.Writers;
    using uml4net.xmi.Xmi;

    [TestFixture]
    public class CapturedElementWriterTestFixture
    {
        private const string RawXml =
            "<a:Note xmlns:a=\"http://example.org/a\" xmlns:x=\"http://example.org/x\" xmlns=\"http://example.org/default\" id=\"n\">" +
            "<!--remark--><text>one</text><code><![CDATA[x < y]]></code><kept xml:space=\"preserve\">  </kept><plain/></a:Note>";

        private CapturedElementWriter capturedElementWriter;

        private CapturedElement capturedElement;

        [SetUp]
        public void SetUp()
        {
            this.capturedElementWriter = new CapturedElementWriter(NullLoggerFactory.Instance);

            this.capturedElement = new CapturedElement
            {
                NamespaceUri = "http://example.org/a",
                Prefix = "a",
                LocalName = "Note",
                RawXml = RawXml
            };
        }

        [Test]
        public void Verify_that_the_content_is_written_and_a_declaration_in_scope_is_not_repeated()
        {
            var written = this.Write(writer => this.capturedElementWriter.Write(writer, this.capturedElement));

            using (Assert.EnterMultipleScope())
            {
                Assert.That(written, Does.StartWith("<root xmlns:a=\"http://example.org/a\"><a:Note xmlns:x=\"http://example.org/x\" xmlns=\"http://example.org/default\" id=\"n\">"),
                    "a is declared by the root element, x and the default namespace are not");
                Assert.That(written, Does.Contain("<!--remark--><text>one</text><code><![CDATA[x < y]]></code><kept xml:space=\"preserve\">  </kept><plain /></a:Note>"),
                    "comments, text, CDATA and significant whitespace are written");
            }
        }

        [Test]
        public async Task Verify_that_the_asynchronous_write_gives_the_same_result()
        {
            var written = this.Write(writer => this.capturedElementWriter.Write(writer, this.capturedElement));

            var writtenAsync = await this.WriteAsync(writer => this.capturedElementWriter.WriteAsync(writer, this.capturedElement));

            Assert.That(writtenAsync, Is.EqualTo(written));
        }

        [Test]
        public void Verify_that_the_arguments_are_checked()
        {
            using var xmlWriter = XmlWriter.Create(new StringBuilder());

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => this.capturedElementWriter.Write(null, this.capturedElement), Throws.ArgumentNullException);
                Assert.That(() => this.capturedElementWriter.Write(xmlWriter, null), Throws.ArgumentNullException);
                Assert.That(() => this.capturedElementWriter.Write(xmlWriter, new CapturedElement { Prefix = "a", LocalName = "Note" }), Throws.ArgumentException);
                Assert.That(async () => await this.capturedElementWriter.WriteAsync(null, this.capturedElement), Throws.ArgumentNullException);
                Assert.That(async () => await this.capturedElementWriter.WriteAsync(xmlWriter, null), Throws.ArgumentNullException);
            }
        }

        [Test]
        public void Verify_that_the_root_namespace_declarations_leave_out_declared_conflicting_and_default_prefixes()
        {
            var first = new CapturedElement
            {
                NamespaceDeclarations = new Dictionary<string, string>
                {
                    ["xmi"] = "http://www.omg.org/spec/XMI/20131001",
                    ["umldi"] = "http://www.omg.org/spec/UML/20161101/UMLDI",
                    [""] = "http://example.org/default",
                    ["dc"] = "http://www.omg.org/spec/DD/20131001/DC"
                }
            };

            var second = new CapturedElement
            {
                NamespaceDeclarations = new Dictionary<string, string>
                {
                    ["dc"] = "http://example.org/other-dc",
                    ["di"] = "http://www.omg.org/spec/DD/20131001/DI"
                }
            };

            var declarations = CapturedElementWriter.QueryRootNamespaceDeclarations([first, second], ["xmi", "uml"]);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(declarations.Select(x => $"{x.Key}={x.Value}"), Is.EqualTo(new[]
                {
                    "umldi=http://www.omg.org/spec/UML/20161101/UMLDI",
                    "dc=http://www.omg.org/spec/DD/20131001/DC",
                    "di=http://www.omg.org/spec/DD/20131001/DI"
                }), "xmi is declared already, the default namespace stays local and the second dc stays local");

                Assert.That(() => CapturedElementWriter.QueryRootNamespaceDeclarations(null, []), Throws.ArgumentNullException);
                Assert.That(() => CapturedElementWriter.QueryRootNamespaceDeclarations([], null), Throws.ArgumentNullException);
            }
        }

        private string Write(Action<XmlWriter> write)
        {
            var stringBuilder = new StringBuilder();

            using (var xmlWriter = XmlWriter.Create(stringBuilder, new XmlWriterSettings { OmitXmlDeclaration = true }))
            {
                xmlWriter.WriteStartElement("root");
                xmlWriter.WriteAttributeString("xmlns", "a", null, "http://example.org/a");
                write(xmlWriter);
                xmlWriter.WriteEndElement();
            }

            return stringBuilder.ToString();
        }

        private async Task<string> WriteAsync(Func<XmlWriter, Task> write)
        {
            var stringBuilder = new StringBuilder();

            using (var xmlWriter = XmlWriter.Create(stringBuilder, new XmlWriterSettings { OmitXmlDeclaration = true, Async = true }))
            {
                await xmlWriter.WriteStartElementAsync(null, "root", null);
                await xmlWriter.WriteAttributeStringAsync("xmlns", "a", null, "http://example.org/a");
                await write(xmlWriter);
                await xmlWriter.WriteEndElementAsync();
            }

            return stringBuilder.ToString();
        }
    }
}
