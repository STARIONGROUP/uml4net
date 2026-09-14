// -------------------------------------------------------------------------------------------------
// <copyright file="StandardProfileReaderTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Tests
{
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    using Serilog;

    using uml4net.Packages;
    using uml4net.xmi;

    [TestFixture]
    public class StandardProfileReaderTestFixture
    {
        private ILoggerFactory loggerFactory;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();

            this.loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSerilog();
            });
        }

        [Test]
        public void Verify_that_StandardProfile_XMI_can_be_read()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = rootPath)
                .WithLogger(this.loggerFactory)
                .Build();

            var xmiReaderResult = reader.Read(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "StandardProfile.xmi"));

            using (Assert.EnterMultipleScope())
            {
                Assert.That(xmiReaderResult.XmiRoot, Is.Not.Null);
                Assert.That(xmiReaderResult.Packages.Count, Is.EqualTo(3));
                Assert.That(xmiReaderResult.QueryRoot("_0", "StandardProfile").Name, Is.EqualTo("StandardProfile"));
            }
        }

        [Test]
        public void Verify_that_the_roots_and_tags_of_the_document_are_kept_apart_from_those_of_external_documents()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = rootPath)
                .WithLogger(this.loggerFactory)
                .Build();

            var xmiReaderResult = reader.Read(Path.Combine(rootPath, "StandardProfile.xmi"));

            using (Assert.EnterMultipleScope())
            {
                Assert.That(xmiReaderResult.RootElements, Has.Count.EqualTo(3), "the roots of all documents, unchanged");
                Assert.That(xmiReaderResult.DocumentRootElements.Select(x => $"{x.DocumentName}#{x.XmiId}"), Is.EqualTo(new[] { "StandardProfile.xmi#_0" }));
                Assert.That(xmiReaderResult.ExternalRootElements.Select(x => $"{x.DocumentName}#{x.XmiId}"), Is.EquivalentTo(new[] { "http://www.omg.org/spec/UML/20161101/UML.xmi#_0", "http://www.omg.org/spec/UML/20131001/PrimitiveTypes.xmi#_0" }));
                Assert.That(xmiReaderResult.RootElements, Is.EquivalentTo(xmiReaderResult.DocumentRootElements.Concat(xmiReaderResult.ExternalRootElements)));

                Assert.That(xmiReaderResult.XmiRoot.Content, Is.EqualTo(xmiReaderResult.DocumentRootElements));
                Assert.That(xmiReaderResult.XmiRoot.Tags, Has.Count.EqualTo(1), "only the tag of StandardProfile.xmi itself");
                Assert.That(xmiReaderResult.XmiRoot.Tags.Single().Name, Is.EqualTo("org.omg.xmi.nsPrefix"));

                Assert.That(xmiReaderResult.ExternalXmiRoots.Keys, Is.EquivalentTo(new[] { "http://www.omg.org/spec/UML/20161101/UML.xmi", "http://www.omg.org/spec/UML/20131001/PrimitiveTypes.xmi" }));
                Assert.That(xmiReaderResult.ExternalXmiRoots["http://www.omg.org/spec/UML/20161101/UML.xmi"].Tags, Has.Count.EqualTo(1));
                Assert.That(xmiReaderResult.ExternalXmiRoots["http://www.omg.org/spec/UML/20131001/PrimitiveTypes.xmi"].Tags, Has.Count.EqualTo(6));
                Assert.That(xmiReaderResult.ExternalXmiRoots["http://www.omg.org/spec/UML/20161101/UML.xmi"].Content.Single().XmiId, Is.EqualTo("_0"));
                Assert.That(xmiReaderResult.ExternalXmiRoots["http://www.omg.org/spec/UML/20161101/UML.xmi"].Documentation, Is.Not.Null, "the documentation of the external document is read into its own XmiRoot");
            }
        }

        [Test]
        public void Verify_that_writing_the_DocumentRootElements_reproduces_the_document_without_the_external_documents()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = rootPath)
                .WithLogger(this.loggerFactory)
                .Build();

            var xmiReaderResult = reader.Read(Path.Combine(rootPath, "StandardProfile.xmi"));

            using var stream = new MemoryStream();

            var writer = XmiWriterBuilder.Create().WithLogger(this.loggerFactory).Build();
            writer.Write(xmiReaderResult.DocumentRootElements, stream, "StandardProfile.xmi", xmiReaderResult.XmiRoot.Documentation, xmiReaderResult.XmiRoot.Extensions);

            var document = XDocument.Load(new MemoryStream(stream.ToArray()));

            using (Assert.EnterMultipleScope())
            {
                Assert.That(document.Root.Elements().Count(x => x.Name.LocalName == "Profile"), Is.EqualTo(1), "only the profile itself is written");
                Assert.That(document.Root.Elements().Where(x => x.Name.LocalName == "Package"), Is.Empty, "the UML metamodel and PrimitiveTypes are not copied into the output");
                Assert.That(document.Descendants().Count(), Is.LessThan(400), "the source has 177 elements, the UML metamodel has thousands");
                Assert.That(document.Descendants().Select(x => (string)x.Attribute("href")).Where(x => x != null), Has.Some.StartsWith("http://www.omg.org/spec/UML/20161101/UML.xmi#"), "references to the UML metamodel stay cross-document hrefs");
            }
        }

        [Test]
        public void Verify_that_Extension_of_a_Stereotype_can_be_queried()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = rootPath)
                .WithLogger(this.loggerFactory)
                .Build();

            var xmiReaderResult = reader.Read(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "StandardProfile.xmi"));

            var profile = xmiReaderResult.Packages.Single(x => x.Name == "StandardProfile");

            var create = profile.PackagedElement.OfType<IStereotype>().Single(x => x.Name == "Create");

            var extensionNames = create.Extension.Select(x => x.Name).OrderBy(x => x).ToList();

            Assert.That(extensionNames, Is.EquivalentTo(new[] { "BehavioralFeature_Create", "Usage_Create" }));
        }
    }
}
