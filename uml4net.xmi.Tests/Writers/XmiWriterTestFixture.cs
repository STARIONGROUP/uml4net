// -------------------------------------------------------------------------------------------------
// <copyright file="XmiWriterTestFixture.cs" company="Starion Group S.A.">
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
    using System.IO;
    using System.Threading.Tasks;
    using System.Xml;

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    using uml4net.Packages;
    using uml4net.StructuredClassifiers;
    using uml4net.xmi;
    using uml4net.xmi.Writers;

    [TestFixture]
    public class XmiWriterTestFixture
    {
        private ILoggerFactory loggerFactory;

        private IXmiWriter xmiWriter;

        private Package package;

        [SetUp]
        public void SetUp()
        {
            this.loggerFactory = LoggerFactory.Create(builder => { });

            this.xmiWriter = XmiWriterBuilder.Create()
                .WithLogger(this.loggerFactory)
                .Build();

            this.package = new Package { XmiId = "Package-1", Name = "package" };
        }

        [TearDown]
        public void TearDown()
        {
            this.xmiWriter.Dispose();
        }

        [Test]
        public void Verify_that_Write_throws_when_fileUri_is_null_or_empty()
        {
            Assert.That(() => this.xmiWriter.Write(this.package, (string)null), Throws.ArgumentException);
            Assert.That(() => this.xmiWriter.Write(this.package, string.Empty), Throws.ArgumentException);
        }

        [Test]
        public void Verify_that_Write_throws_when_arguments_are_null_or_empty()
        {
            using var stream = new MemoryStream();

            Assert.That(() => this.xmiWriter.Write(null, stream, "output.xmi"), Throws.ArgumentNullException);
            Assert.That(() => this.xmiWriter.Write(this.package, null, "output.xmi"), Throws.ArgumentNullException);
            Assert.That(() => this.xmiWriter.Write(this.package, stream, null), Throws.ArgumentException);
            Assert.That(() => this.xmiWriter.Write(this.package, stream, string.Empty), Throws.ArgumentException);
        }

        [Test]
        public void Verify_that_WriteAsync_throws_when_fileUri_is_null_or_empty()
        {
            Assert.That(() => this.xmiWriter.WriteAsync(this.package, (string)null), Throws.ArgumentException);
            Assert.That(() => this.xmiWriter.WriteAsync(this.package, string.Empty), Throws.ArgumentException);
        }

        [Test]
        public void Verify_that_WriteAsync_throws_when_arguments_are_null_or_empty()
        {
            using var stream = new MemoryStream();

            Assert.That(() => this.xmiWriter.WriteAsync(null, stream, "output.xmi"), Throws.ArgumentNullException);
            Assert.That(() => this.xmiWriter.WriteAsync(this.package, null, "output.xmi"), Throws.ArgumentNullException);
            Assert.That(() => this.xmiWriter.WriteAsync(this.package, stream, null), Throws.ArgumentException);
            Assert.That(() => this.xmiWriter.WriteAsync(this.package, stream, string.Empty), Throws.ArgumentException);
        }

        [Test]
        public void Verify_that_Write_throws_when_a_contained_element_has_no_XmiId()
        {
            this.package.PackagedElement.Add(new Class { Name = "invalid" });

            using var stream = new MemoryStream();

            Assert.That(() => this.xmiWriter.Write(this.package, stream, "output.xmi"),
                Throws.InvalidOperationException.With.Message.Contains("do not have an XmiId"));
        }

        [Test]
        public void Verify_that_a_root_package_without_an_XmiId_is_written_without_an_xmi_id_attribute()
        {
            var rootWithoutXmiId = new Package { Name = "package" };

            using var stream = new MemoryStream();

            this.xmiWriter.Write(rootWithoutXmiId, stream, "output.xmi");

            var xmlDocument = new XmlDocument();
            stream.Position = 0;
            xmlDocument.Load(stream);

            var packageElement = (XmlElement)xmlDocument.DocumentElement.FirstChild;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(packageElement.Name, Is.EqualTo("uml:Package"));
                Assert.That(packageElement.HasAttribute("xmi:id"), Is.False,
                    "a root package without an XmiId - which is how Enterprise Architect exports its uml:Model - is expected to be written without an xmi:id attribute rather than with an empty one");
                Assert.That(packageElement.GetAttribute("name"), Is.EqualTo("package"));
            }
        }

        [Test]
        public void Verify_that_a_simple_package_is_written_as_expected()
        {
            var @class = new Class { XmiId = "Class-1", Name = "class" };
            this.package.PackagedElement.Add(@class);

            using var stream = new MemoryStream();

            this.xmiWriter.Write(this.package, stream, "output.xmi");

            var xmlDocument = new XmlDocument();
            stream.Position = 0;
            xmlDocument.Load(stream);

            var root = xmlDocument.DocumentElement;

            Assert.That(root.Name, Is.EqualTo("xmi:XMI"));
            Assert.That(root.GetAttribute("xmlns:uml"), Is.EqualTo("http://www.omg.org/spec/UML/20131001"));
            Assert.That(root.GetAttribute("xmlns:xmi"), Is.EqualTo("http://www.omg.org/spec/XMI/20131001"));

            var packageElement = (XmlElement)root.FirstChild;

            Assert.That(packageElement.Name, Is.EqualTo("uml:Package"));
            Assert.That(packageElement.GetAttribute("xmi:type"), Is.EqualTo("uml:Package"));
            Assert.That(packageElement.GetAttribute("xmi:id"), Is.EqualTo("Package-1"));
            Assert.That(packageElement.GetAttribute("name"), Is.EqualTo("package"));

            var classElement = (XmlElement)packageElement.FirstChild;

            Assert.That(classElement.Name, Is.EqualTo("packagedElement"));
            Assert.That(classElement.GetAttribute("xmi:type"), Is.EqualTo("uml:Class"));
            Assert.That(classElement.GetAttribute("xmi:id"), Is.EqualTo("Class-1"));
            Assert.That(classElement.GetAttribute("name"), Is.EqualTo("class"));
        }

        [Test]
        public void Verify_that_a_model_is_written_with_a_uml_Model_root_element()
        {
            var model = new Model { XmiId = "Model-1", Name = "model" };

            using var stream = new MemoryStream();

            this.xmiWriter.Write(model, stream, "output.xmi");

            var xmlDocument = new XmlDocument();
            stream.Position = 0;
            xmlDocument.Load(stream);

            var modelElement = (XmlElement)xmlDocument.DocumentElement.FirstChild;

            Assert.That(modelElement.Name, Is.EqualTo("uml:Model"));
            Assert.That(modelElement.GetAttribute("xmi:type"), Is.EqualTo("uml:Model"));
        }

        [Test]
        public void Verify_that_Write_to_a_file_creates_the_file()
        {
            var fileUri = Path.Combine(TestContext.CurrentContext.WorkDirectory, "xmi-writer-test-output.xmi");

            this.xmiWriter.Write(this.package, fileUri);

            Assert.That(File.Exists(fileUri), Is.True);

            var content = File.ReadAllText(fileUri);

            Assert.That(content, Does.Contain("uml:Package"));
        }

        [Test]
        public async Task Verify_that_WriteAsync_to_a_file_creates_the_file()
        {
            var fileUri = Path.Combine(TestContext.CurrentContext.WorkDirectory, "xmi-writer-test-output-async.xmi");

            await this.xmiWriter.WriteAsync(this.package, fileUri);

            Assert.That(File.Exists(fileUri), Is.True);

            var content = await File.ReadAllTextAsync(fileUri);

            Assert.That(content, Does.Contain("uml:Package"));
        }
    }
}
