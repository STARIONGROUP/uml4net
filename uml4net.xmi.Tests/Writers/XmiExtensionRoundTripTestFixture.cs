// -------------------------------------------------------------------------------------------------
// <copyright file="XmiExtensionRoundTripTestFixture.cs" company="Starion Group S.A.">
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
    using System.Linq;
    using System.Xml.Linq;

    using Microsoft.Extensions.Logging.Abstractions;

    using NUnit.Framework;

    using uml4net.Packages;
    using uml4net.xmi.Readers;
    using uml4net.xmi.Settings;
    using uml4net.xmi.Writers;

    /// <summary>
    /// Verifies that the <c>xmi:Extension</c> of an Enterprise Architect document survives a
    /// read - write - read cycle when no <c>IExtenderReader</c> is registered, which is the default
    /// for consumers of the uml4net.xmi library.
    /// </summary>
    [TestFixture]
    public class XmiExtensionRoundTripTestFixture
    {
        private ReferenceClosureCalculator referenceClosureCalculator;

        private string rootPath;

        [SetUp]
        public void SetUp()
        {
            this.rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            this.referenceClosureCalculator = new ReferenceClosureCalculator(NullLogger<ReferenceClosureCalculator>.Instance);
        }

        [Test]
        public void Verify_that_the_Extension_of_an_EnterpriseArchitect_document_round_trips()
        {
            var originalResult = this.CreateReader().Read(Path.Combine(this.rootPath, "EAExport.xmi"));

            var originalRoot = originalResult.QueryRoot(null, "EA_Model") as IPackage;
            var originalExtension = originalResult.XmiRoot.Extensions.Single();

            using var stream = new MemoryStream();

            var writer = XmiWriterBuilder.Create()
                .WithLogger(NullLoggerFactory.Instance)
                .Build();

            writer.Write(originalRoot, stream, "EAExport.xmi", originalResult.XmiRoot.Extensions);

            stream.Position = 0;

            var rereadResult = this.CreateReader().Read(stream, "EAExport.xmi");

            var rereadRoot = rereadResult.QueryRoot(null, "EA_Model") as IPackage;
            var rereadExtension = rereadResult.XmiRoot.Extensions.Single();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(rereadRoot, Is.Not.Null, "the EA_Model root package was expected to be read back");

                Assert.That(rereadExtension.Extender, Is.EqualTo(originalExtension.Extender));
                Assert.That(rereadExtension.ExtenderId, Is.EqualTo(originalExtension.ExtenderId));

                Assert.That(rereadExtension.ContentRawXmi, Is.EqualTo(originalExtension.ContentRawXmi),
                    "the raw content of the xmi:Extension was expected to survive the round trip unchanged");
            }

            this.AssertContainmentTreesAreEquivalent(originalRoot, rereadRoot, "EAExport.xmi");
        }

        [Test]
        public void Verify_that_the_Extension_is_written_as_the_last_child_of_the_root()
        {
            var originalResult = this.CreateReader().Read(Path.Combine(this.rootPath, "EAExport.xmi"));

            var originalRoot = originalResult.QueryRoot(null, "EA_Model") as IPackage;

            using var stream = new MemoryStream();

            var writer = XmiWriterBuilder.Create()
                .WithLogger(NullLoggerFactory.Instance)
                .Build();

            writer.Write(originalRoot, stream, "EAExport.xmi", originalResult.XmiRoot.Extensions);

            stream.Position = 0;

            var document = XDocument.Load(stream);

            var xmiNamespace = XNamespace.Get("http://www.omg.org/spec/XMI/20131001");

            var children = document.Root.Elements().ToList();
            var extensionElement = children.SingleOrDefault(x => x.Name == xmiNamespace + "Extension");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(extensionElement, Is.Not.Null, "an xmi:Extension was expected as a child of xmi:XMI");
                Assert.That(extensionElement.Attribute("extender")?.Value, Is.EqualTo("Enterprise Architect"));
                Assert.That(extensionElement.Attribute("extenderID")?.Value, Is.EqualTo("6.5"));
                Assert.That(children.Last(), Is.EqualTo(extensionElement),
                    "the xmi:Extension was expected to be written after the model content");

                Assert.That(extensionElement.Elements().Select(x => x.Name.LocalName),
                    Is.EquivalentTo(new[] { "elements", "connectors", "primitivetypes", "profiles" }));
            }
        }

        [Test]
        public void Verify_that_no_Extension_is_written_when_none_is_provided()
        {
            var originalResult = this.CreateReader().Read(Path.Combine(this.rootPath, "EAExport.xmi"));

            var originalRoot = originalResult.QueryRoot(null, "EA_Model") as IPackage;

            using var stream = new MemoryStream();

            var writer = XmiWriterBuilder.Create()
                .WithLogger(NullLoggerFactory.Instance)
                .Build();

            writer.Write(originalRoot, stream, "EAExport.xmi");

            stream.Position = 0;

            var document = XDocument.Load(stream);

            var xmiNamespace = XNamespace.Get("http://www.omg.org/spec/XMI/20131001");

            Assert.That(document.Root.Elements().Any(x => x.Name == xmiNamespace + "Extension"), Is.False,
                "the pre-existing overloads are expected to remain behaviour preserving and write no xmi:Extension");
        }

        /// <summary>
        /// Asserts that the containment trees of the provided packages contain the same elements
        /// </summary>
        private void AssertContainmentTreesAreEquivalent(IPackage originalRoot, IPackage rereadRoot, string documentName)
        {
            var originalPlan = this.referenceClosureCalculator.CalculateWritePlan(originalRoot, ExternalReferenceResolutionKind.Href, documentName);
            var rereadPlan = this.referenceClosureCalculator.CalculateWritePlan(rereadRoot, ExternalReferenceResolutionKind.Href, documentName);

            var missing = originalPlan.LocalIdentifiers.Except(rereadPlan.LocalIdentifiers).Take(10).ToList();
            var extra = rereadPlan.LocalIdentifiers.Except(originalPlan.LocalIdentifiers).Take(10).ToList();

            Assert.That(rereadPlan.LocalIdentifiers.SetEquals(originalPlan.LocalIdentifiers), Is.True,
                $"the containment trees are not equivalent; missing: [{string.Join(", ", missing)}]; extra: [{string.Join(", ", extra)}]");
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
