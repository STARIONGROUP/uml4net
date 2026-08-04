// -------------------------------------------------------------------------------------------------
// <copyright file="EnterpriseArchitectExtensionRoundTripTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Extensions.EnterpriseArchitect.Tests.Extender
{
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using NUnit.Framework;

    using uml4net.Packages;
    using uml4net.xmi.Extensions.EnterpriseArchitect.Extender;
    using uml4net.xmi.Extensions.EnterpriseArchitect.Structure;
    using uml4net.xmi.Extensions.EnterpriseArchitect.Structure.Readers;
    using uml4net.xmi.Readers;
    using uml4net.xmi.Settings;
    using uml4net.xmi.Writers;

    using Path = System.IO.Path;

    /// <summary>
    /// Verifies that an Enterprise Architect model, including its <c>xmi:Extension</c> content,
    /// survives a read - write - read cycle
    /// </summary>
    [TestFixture]
    public class EnterpriseArchitectExtensionRoundTripTestFixture
    {
        private ReferenceClosureCalculator referenceClosureCalculator;

        private string rootPath;

        [SetUp]
        public void SetUp()
        {
            this.rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources");

            this.referenceClosureCalculator = new ReferenceClosureCalculator(NullLogger<ReferenceClosureCalculator>.Instance);
        }

        [Test]
        public void Verify_that_an_EnterpriseArchitect_model_and_its_Extension_round_trip()
        {
            var originalResult = this.ReadEnterpriseArchitectModel(Path.Combine(this.rootPath, "EAExport.xmi"));

            var originalRoot = originalResult.QueryRoot(null, "EA_Model") as IPackage;
            var originalExtension = originalResult.XmiRoot.Extensions.Single();

            Assert.That(originalRoot, Is.Not.Null, "the EA_Model root package was expected to be read");

            using var stream = new MemoryStream();

            var writer = XmiWriterBuilder.Create()
                .WithLogger(NullLoggerFactory.Instance)
                .Build();

            writer.Write(originalRoot, stream, "EAExport.xmi", originalResult.XmiRoot.Extensions);

            stream.Position = 0;

            var rereadResult = this.ReadEnterpriseArchitectModel(stream);

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
        public void Verify_that_the_structured_Extension_content_round_trips()
        {
            var originalResult = this.ReadEnterpriseArchitectModel(Path.Combine(this.rootPath, "EAExport.xmi"));

            var originalRoot = originalResult.QueryRoot(null, "EA_Model") as IPackage;

            using var stream = new MemoryStream();

            var writer = XmiWriterBuilder.Create()
                .WithLogger(NullLoggerFactory.Instance)
                .Build();

            writer.Write(originalRoot, stream, "EAExport.xmi", originalResult.XmiRoot.Extensions);

            stream.Position = 0;

            var rereadResult = this.ReadEnterpriseArchitectModel(stream);

            var originalElements = QueryExtensionElementNames(originalResult);
            var rereadElements = QueryExtensionElementNames(rereadResult);

            var originalConnectors = QueryExtensionConnectorCount(originalResult);
            var rereadConnectors = QueryExtensionConnectorCount(rereadResult);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(originalElements, Is.Not.Empty, "the EA extension was expected to contain elements");
                Assert.That(rereadElements, Is.EqualTo(originalElements),
                    "the structured EA extension elements were expected to survive the round trip");

                Assert.That(originalConnectors, Is.GreaterThan(0), "the EA extension was expected to contain connectors");
                Assert.That(rereadConnectors, Is.EqualTo(originalConnectors),
                    "the structured EA extension connectors were expected to survive the round trip");
            }
        }

        [Test]
        public void Verify_that_the_written_document_contains_the_Extension_as_a_sibling_of_the_model()
        {
            var originalResult = this.ReadEnterpriseArchitectModel(Path.Combine(this.rootPath, "EAExport.xmi"));

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

        /// <summary>
        /// Queries the names of the <see cref="Element"/>s that are contained by the extensions of the
        /// provided <see cref="XmiReaderResult"/>
        /// </summary>
        private static string[] QueryExtensionElementNames(XmiReaderResult xmiReaderResult)
        {
            return xmiReaderResult.XmiRoot.Extensions
                .SelectMany(x => x.Content)
                .OfType<Element>()
                .Select(x => x.Name)
                .OrderBy(x => x, System.StringComparer.Ordinal)
                .ToArray();
        }

        /// <summary>
        /// Queries the number of <see cref="Connector"/>s that are contained by the extensions of the
        /// provided <see cref="XmiReaderResult"/>
        /// </summary>
        private static int QueryExtensionConnectorCount(XmiReaderResult xmiReaderResult)
        {
            return xmiReaderResult.XmiRoot.Extensions
                .SelectMany(x => x.Content)
                .OfType<Connector>()
                .Count();
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
        /// Reads the Enterprise Architect model from the provided path
        /// </summary>
        private XmiReaderResult ReadEnterpriseArchitectModel(string path)
        {
            return this.CreateReader().Read(path);
        }

        /// <summary>
        /// Reads the Enterprise Architect model from the provided <see cref="Stream"/>
        /// </summary>
        private XmiReaderResult ReadEnterpriseArchitectModel(Stream stream)
        {
            return this.CreateReader().Read(stream, "EAExport.xmi");
        }

        /// <summary>
        /// Creates an <see cref="IXmiReader"/> that is able to read Enterprise Architect extensions
        /// </summary>
        private IXmiReader CreateReader()
        {
            return XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = this.rootPath)
                .WithExtender<EnterpriseArchitectExtenderReader>()
                .WithExtensionContentReaderFacade<ExtensionContentReaderFacade>()
                .WithLogger(NullLoggerFactory.Instance)
                .Build();
        }
    }
}
