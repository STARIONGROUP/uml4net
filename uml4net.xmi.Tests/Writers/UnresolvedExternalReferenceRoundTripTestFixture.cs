// -------------------------------------------------------------------------------------------------
// <copyright file="UnresolvedExternalReferenceRoundTripTestFixture.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    using Microsoft.Extensions.Logging.Abstractions;

    using NUnit.Framework;

    using uml4net.Packages;
    using uml4net.xmi.Readers;
    using uml4net.xmi.Writers;

    /// <summary>
    /// Verifies that a reference to a document that cannot be resolved - the <c>appliedProfile</c> of an
    /// Enterprise Architect document references profiles by a <c>http://www.sparxsystems.com/profiles/…</c>
    /// URL that is an identifier rather than a location - is preserved in its original XMI form and is
    /// written back verbatim rather than being silently lost.
    /// </summary>
    /// <remarks>
    /// This is the regression fixture of https://github.com/STARIONGROUP/uml4net/issues/204
    /// </remarks>
    [TestFixture]
    public class UnresolvedExternalReferenceRoundTripTestFixture
    {
        private string rootPath;

        [SetUp]
        public void SetUp()
        {
            this.rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");
        }

        [Test]
        public void Verify_that_an_unresolvable_appliedProfile_is_preserved_in_its_original_xmi_form()
        {
            var model = this.ReadEnterpriseArchitectModel();

            var unresolvedReferences = model.ProfileApplication
                .SelectMany(x => x.UnresolvedReferences)
                .ToList();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(model.ProfileApplication, Has.Count.EqualTo(4));

                Assert.That(model.ProfileApplication.Select(x => x.UnresolvedReferences.Count),
                    Is.All.EqualTo(1),
                    "each profileApplication declares exactly one appliedProfile that cannot be resolved");

                Assert.That(unresolvedReferences.Select(x => x.PropertyName), Is.All.EqualTo("appliedProfile"));

                Assert.That(unresolvedReferences.Select(x => x.Identifier),
                    Is.EqualTo(QueryAppliedProfileHrefs(this.LoadSourceDocument())));

                Assert.That(unresolvedReferences.Select(x => x.ContentRawXmi),
                    Is.All.Contains("appliedProfile"));
            }
        }

        [Test]
        public void Verify_that_an_unresolvable_appliedProfile_survives_a_write()
        {
            var model = this.ReadEnterpriseArchitectModel();

            var writtenDocument = XDocument.Load(new MemoryStream(Write(model)));
            var sourceDocument = this.LoadSourceDocument();

            var writtenElements = QueryAppliedProfileElements(writtenDocument);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(QueryAppliedProfileHrefs(writtenDocument), Is.EqualTo(QueryAppliedProfileHrefs(sourceDocument)),
                    "the appliedProfile references of the source document were expected to be written back unchanged");

                Assert.That(writtenElements.Select(x => x.Attribute(XmiNamespace + "type")?.Value),
                    Is.All.EqualTo("uml:Profile"),
                    "the xmi:type of the reference element was expected to be preserved as well");

                Assert.That(writtenElements, Has.Count.EqualTo(4));
            }
        }

        [Test]
        public void Verify_that_an_unresolvable_appliedProfile_survives_a_read_write_read_cycle()
        {
            var model = this.ReadEnterpriseArchitectModel();

            using var stream = new MemoryStream(Write(model));

            var rereadResult = this.CreateReader().Read(stream, "EAExport.xmi");
            var rereadModel = rereadResult.QueryRoot(null, "EA_Model") as IPackage;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(rereadModel, Is.Not.Null);

                Assert.That(rereadModel.ProfileApplication.SelectMany(x => x.UnresolvedReferences).Select(x => x.Identifier),
                    Is.EqualTo(model.ProfileApplication.SelectMany(x => x.UnresolvedReferences).Select(x => x.Identifier)),
                    "the preserved references were expected to be read back and to remain unresolvable");
            }
        }

        [Test]
        public async Task Verify_that_the_asynchronous_write_preserves_an_unresolvable_appliedProfile()
        {
            var model = this.ReadEnterpriseArchitectModel();

            using var stream = new MemoryStream();

            var writer = XmiWriterBuilder.Create()
                .WithLogger(NullLoggerFactory.Instance)
                .Build();

            await writer.WriteAsync(model, stream, "EAExport.xmi");

            stream.Position = 0;

            Assert.That(QueryAppliedProfileHrefs(XDocument.Load(stream)),
                Is.EqualTo(QueryAppliedProfileHrefs(this.LoadSourceDocument())));
        }

        /// <summary>
        /// The XMI namespace of the documents that are read and written
        /// </summary>
        private static XNamespace XmiNamespace => XNamespace.Get("http://www.omg.org/spec/XMI/20131001");

        /// <summary>
        /// Loads the Enterprise Architect source document as an <see cref="XDocument"/>
        /// </summary>
        /// <remarks>
        /// The document declares the <c>windows-1252</c> encoding, which is not registered by default on
        /// .NET Core. The content is therefore decoded explicitly; loading from a <see cref="TextReader"/>
        /// makes the encoding declaration irrelevant
        /// </remarks>
        private XDocument LoadSourceDocument()
        {
            using var streamReader = new StreamReader(Path.Combine(this.rootPath, "EAExport.xmi"), Encoding.Latin1);

            return XDocument.Load(streamReader);
        }

        /// <summary>
        /// Queries the <c>appliedProfile</c> elements of the provided <see cref="XDocument"/>, in document order
        /// </summary>
        private static List<XElement> QueryAppliedProfileElements(XDocument document)
        {
            return document.Descendants().Where(x => x.Name.LocalName == "appliedProfile").ToList();
        }

        /// <summary>
        /// Queries the <c>href</c> of the <c>appliedProfile</c> elements of the provided <see cref="XDocument"/>,
        /// in document order
        /// </summary>
        private static List<string> QueryAppliedProfileHrefs(XDocument document)
        {
            return QueryAppliedProfileElements(document).Select(x => x.Attribute("href")?.Value).ToList();
        }

        /// <summary>
        /// Writes the provided <see cref="IPackage"/> and returns the written bytes
        /// </summary>
        private static byte[] Write(IPackage package)
        {
            using var stream = new MemoryStream();

            var writer = XmiWriterBuilder.Create()
                .WithLogger(NullLoggerFactory.Instance)
                .Build();

            writer.Write(package, stream, "EAExport.xmi");

            return stream.ToArray();
        }

        /// <summary>
        /// Reads the Enterprise Architect model and returns its root <see cref="IPackage"/>
        /// </summary>
        private IPackage ReadEnterpriseArchitectModel()
        {
            var xmiReaderResult = this.CreateReader().Read(Path.Combine(this.rootPath, "EAExport.xmi"));

            return xmiReaderResult.QueryRoot(null, "EA_Model") as IPackage;
        }

        /// <summary>
        /// Creates an <see cref="IXmiReader"/> without any registered extender reader
        /// </summary>
        private IXmiReader CreateReader()
        {
            return XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = this.rootPath)
                .WithLogger(NullLoggerFactory.Instance)
                .Build();
        }
    }
}
