// -------------------------------------------------------------------------------------------------
// <copyright file="XmiReaderExternalReferenceLocationsTestFixture.cs" company="Starion Group S.A.">
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

    using Microsoft.Extensions.Logging.Abstractions;

    using NUnit.Framework;

    using uml4net.StructuredClassifiers;
    using uml4net.xmi.Readers;

    /// <summary>
    /// Verifies that relative hrefs are resolved against the location of the referencing document (XMI 2.5.1
    /// clause 7.10.2, IETF RFC 2396) and that remote hrefs are mapped to local copies by their full URI
    /// </summary>
    [TestFixture]
    public class XmiReaderExternalReferenceLocationsTestFixture
    {
        private string testDataPath;

        [SetUp]
        public void SetUp()
        {
            this.testDataPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");
        }

        private IXmiReader CreateReader(string localReferenceBasePath)
        {
            return XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = localReferenceBasePath)
                .WithLogger(NullLoggerFactory.Instance)
                .Build();
        }

        [Test]
        public void Verify_that_a_chain_of_relative_references_across_folders_is_resolved_against_each_referencing_document()
        {
            // the base path deliberately points elsewhere: ../lib/types.xmi and ./base.xmi only resolve against the documents
            var xmiReaderResult = this.CreateReader(this.testDataPath).Read(Path.Combine(this.testDataPath, "RelativeReferences", "models", "a.xmi"));

            var classA = xmiReaderResult.QueryRoot("p").PackagedElement.OfType<IClass>().Single();
            var typeT = classA.OwnedAttribute.Single().Type as IClass;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(typeT, Is.Not.Null, "../lib/types.xmi#T is resolved against models/a.xmi");
                Assert.That(typeT.Name, Is.EqualTo("T"));
                Assert.That(typeT.DocumentName, Is.EqualTo("../lib/types.xmi"), "the document keeps the name it was referenced by");
                Assert.That(typeT.OwnedAttribute.Single().Type?.Name, Is.EqualTo("B"), "./base.xmi#B is resolved against lib/types.xmi, not against models/a.xmi or the base path");
                Assert.That(xmiReaderResult.ExternalXmiRoots.Keys, Is.EquivalentTo(new[] { "../lib/types.xmi", "./base.xmi" }));
            }
        }

        [Test]
        public void Verify_that_a_relative_reference_falls_back_to_the_LocalReferenceBasePath_when_the_document_has_no_location()
        {
            // reading from a stream registers no location, so ../lib/types.xmi is looked up under the base path
            var basePath = Path.Combine(this.testDataPath, "RelativeReferences", "models");

            using var stream = File.OpenRead(Path.Combine(basePath, "a.xmi"));

            var xmiReaderResult = this.CreateReader(basePath).Read(stream, "a.xmi");

            var classA = xmiReaderResult.QueryRoot("p").PackagedElement.OfType<IClass>().Single();
            var typeT = classA.OwnedAttribute.Single().Type as IClass;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(typeT?.Name, Is.EqualTo("T"), "resolved as <base path>/../lib/types.xmi");
                Assert.That(typeT.OwnedAttribute.Single().Type?.Name, Is.EqualTo("B"), "once found, the location of types.xmi is known and ./base.xmi resolves against it");
            }
        }

        [Test]
        public void Verify_that_remote_documents_with_the_same_file_name_are_mapped_to_local_copies_by_their_full_uri()
        {
            var basePath = Path.Combine(this.testDataPath, "RemoteReferences");

            var xmiReaderResult = this.CreateReader(basePath).Read(Path.Combine(basePath, "model.xmi"));

            var classC = xmiReaderResult.QueryRoot("p").PackagedElement.OfType<IClass>().Single();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(classC.OwnedAttribute.Single(x => x.Name == "a").Type?.Name, Is.EqualTo("TA"), "http://example.com/a/types.xmi is read from example.com/a/types.xmi");
                Assert.That(classC.OwnedAttribute.Single(x => x.Name == "b").Type?.Name, Is.EqualTo("TB"), "http://example.com/b/types.xmi is read from example.com/b/types.xmi");
                Assert.That(xmiReaderResult.ExternalXmiRoots.Keys, Is.EquivalentTo(new[] { "http://example.com/a/types.xmi", "http://example.com/b/types.xmi" }));
            }
        }
    }
}
