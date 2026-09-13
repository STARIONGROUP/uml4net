// -------------------------------------------------------------------------------------------------
// <copyright file="XmiReaderProxyReferenceTestFixture.cs" company="Starion Group S.A.">
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
    using Microsoft.Extensions.Logging.Abstractions;

    using NUnit.Framework;

    using Serilog;

    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.StructuredClassifiers;
    using uml4net.Values;
    using uml4net.xmi.Readers;
    using uml4net.xmi.Settings;
    using uml4net.xmi.Writers;

    /// <summary>
    /// Verifies that composite properties written as proxies (xmi:idref or href) instead of contained definitions
    /// are read, as described in XMI 2.5.1 clause 7.10
    /// </summary>
    [TestFixture]
    public class XmiReaderProxyReferenceTestFixture
    {
        private ILoggerFactory loggerFactory;

        private string rootPath;

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

            this.rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "ProxyReferences");
        }

        private XmiReaderResult Read(string fileName, bool useStrictReading = false)
        {
            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x =>
                {
                    x.LocalReferenceBasePath = this.rootPath;
                    x.UseStrictReading = useStrictReading;
                })
                .WithLogger(this.loggerFactory)
                .Build();

            return reader.Read(Path.Combine(this.rootPath, fileName));
        }

        [Test]
        public void Verify_that_the_XMI_specification_example_for_UML_is_read()
        {
            var xmiReaderResult = this.Read("doc1.xml");

            var operation = xmiReaderResult.QueryRootElement<IOperation>("idO1");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(operation.XmiGuid, Is.EqualTo("DCE:1234"));
                Assert.That(operation.OwnedRule.Select(x => x.XmiId), Is.EqualTo(new[] { "idC1", "idC2", "idC3", "idC4" }));
                Assert.That(operation.OwnedRule.Select(x => x.Possessor), Is.All.SameAs(operation));
                Assert.That(operation.OwnedRule[3].DocumentName, Is.EqualTo("doc2.xml"));
                Assert.That(operation.OwnedRule.Select(x => x.ConstrainedElement.Single()), Is.All.SameAs(operation));
                Assert.That(operation.OwnedRule.Select(x => ((IOpaqueExpression)x.Specification.Single()).Body.Single()),
                    Is.EqualTo(new[] { "First Constraint definition", "Second Constraint definition", "Third Constraint definition", "Fourth Constraint definition" }));
                Assert.That(operation.OwnedRule.Select(x => x.Specification.Single().Possessor), Is.EqualTo(operation.OwnedRule));
                Assert.That(operation.UnresolvedReferences, Is.Empty);
                Assert.That(operation.CompositeReferencePropertyIdentifiers.Values.SelectMany(x => x), Is.Empty);

                Assert.That(xmiReaderResult.RootElements, Is.EqualTo(new IXmiElement[] { operation }));
                Assert.That(xmiReaderResult.XmiRoot.Content.Select(x => x.XmiId), Is.SupersetOf(new[] { "idO1", "idC2", "idC3", "idC4" }));
            }
        }

        [Test]
        public void Verify_that_proxies_and_definitions_are_kept_in_document_order()
        {
            var xmiReaderResult = this.Read("mixed-order.xml");

            var operation = xmiReaderResult.QueryRootElement<IOperation>("idO1");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(operation.OwnedRule.Select(x => x.XmiId), Is.EqualTo(new[] { "idC2", "idC1", "idC3" }));
                Assert.That(operation.OwnedRule.Select(x => x.Possessor), Is.All.SameAs(operation));
                Assert.That(xmiReaderResult.RootElements, Is.EqualTo(new IXmiElement[] { operation }));
            }
        }

        [Test]
        public void Verify_that_a_proxy_of_a_single_valued_composite_property_with_an_abstract_type_is_read()
        {
            var xmiReaderResult = this.Read("abstract-single-proxy.xml");

            var constraint = xmiReaderResult.QueryRootElement<IConstraint>("idC1");
            var specification = constraint.Specification.Single();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(specification.XmiId, Is.EqualTo("idS1"));
                Assert.That(specification.Possessor, Is.SameAs(constraint));
                Assert.That(xmiReaderResult.RootElements, Is.EqualTo(new IXmiElement[] { constraint }));
            }
        }

        [TestCase(false)]
        [TestCase(true)]
        public void Verify_that_unresolvable_proxies_do_not_prevent_reading(bool useStrictReading)
        {
            XmiReaderResult xmiReaderResult = null;

            Assert.That(() => xmiReaderResult = this.Read("unresolved.xml", useStrictReading), Throws.Nothing);

            var operation = xmiReaderResult.QueryRootElement<IOperation>("idO1");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(operation.OwnedRule, Is.Empty);
                Assert.That(operation.UnresolvedReferences.Select(x => x.Identifier), Is.EqualTo(new[] { "missing.xml#x" }));
                Assert.That(operation.CompositeReferencePropertyIdentifiers["ownedRule"].Select(x => x.Identifier), Is.EqualTo(new[] { "missing", "missing.xml#x" }));
            }
        }

        [Test]
        public void Verify_that_an_unresolvable_composite_href_survives_a_read_write_read_cycle()
        {
            var package = this.Read("unresolved-in-package.xml").QueryRoot("idP1");

            using var stream = new MemoryStream();

            var writer = XmiWriterBuilder.Create()
                .WithLogger(NullLoggerFactory.Instance)
                .Build();

            writer.Write(package, stream, "unresolved-in-package.xml");

            var writtenOwnedRules = XDocument.Load(new MemoryStream(stream.ToArray()))
                .Descendants()
                .Where(x => x.Name.LocalName == "ownedRule")
                .ToList();

            stream.Position = 0;

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = this.rootPath)
                .WithLogger(this.loggerFactory)
                .Build();

            var rereadClass = reader.Read(stream, "unresolved-in-package.xml").QueryRoot("idP1").PackagedElement.OfType<IClass>().Single();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(writtenOwnedRules.Select(x => x.Attribute("href")?.Value), Is.EqualTo(new[] { "missing.xml#x" }));
                Assert.That(rereadClass.OwnedRule, Is.Empty);
                Assert.That(rereadClass.UnresolvedReferences.Select(x => x.Identifier), Is.EqualTo(new[] { "missing.xml#x" }));
                Assert.That(rereadClass.CompositeReferencePropertyIdentifiers["ownedRule"].Single().Identifier, Is.EqualTo("missing.xml#x"));
            }
        }

        [TestCase(ExternalReferenceResolutionKind.Href)]
        [TestCase(ExternalReferenceResolutionKind.Include)]
        public void Verify_that_an_owned_element_defined_in_another_document_survives_a_read_write_read_cycle(ExternalReferenceResolutionKind externalReferenceResolution)
        {
            const string documentName = "package-with-external-owned-rule.xml";

            var package = this.Read(documentName).QueryRoot("idP1");

            using var stream = new MemoryStream();

            var writer = XmiWriterBuilder.Create()
                .UsingSettings(x => x.ExternalReferenceResolution = externalReferenceResolution)
                .WithLogger(NullLoggerFactory.Instance)
                .Build();

            writer.Write(package, stream, documentName);

            var writtenDocument = XDocument.Load(new MemoryStream(stream.ToArray()));
            var writtenOwnedRules = writtenDocument.Descendants().Where(x => x.Name.LocalName == "ownedRule").ToList();
            var xmiIdAttributeName = XName.Get("id", "http://www.omg.org/spec/XMI/20131001");

            stream.Position = 0;

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = this.rootPath)
                .WithLogger(this.loggerFactory)
                .Build();

            var rereadClass = reader.Read(stream, documentName).QueryRoot("idP1").PackagedElement.OfType<IClass>().Single();

            using (Assert.EnterMultipleScope())
            {
                if (externalReferenceResolution == ExternalReferenceResolutionKind.Href)
                {
                    Assert.That(writtenOwnedRules.Select(x => x.Attribute("href")?.Value), Is.EqualTo(new[] { null, "doc2.xml#idC4" }));
                    Assert.That(writtenDocument.Descendants().Select(x => x.Attribute(xmiIdAttributeName)?.Value), Does.Not.Contain("idC4").And.Not.Contain("idS4"));
                }
                else
                {
                    Assert.That(writtenOwnedRules.Select(x => x.Attribute(xmiIdAttributeName)?.Value), Is.EqualTo(new[] { "idC1", "idC4" }));
                }

                Assert.That(rereadClass.OwnedRule.Select(x => x.XmiId), Is.EqualTo(new[] { "idC1", "idC4" }));
                Assert.That(rereadClass.OwnedRule.Select(x => x.Possessor), Is.All.SameAs(rereadClass));
                Assert.That(((IOpaqueExpression)rereadClass.OwnedRule[1].Specification.Single()).Body.Single(), Is.EqualTo("Fourth Constraint definition"));
                Assert.That(rereadClass.UnresolvedReferences, Is.Empty);
            }
        }

        [Test]
        public void Verify_that_unresolvable_proxies_throw_when_ThrowOnUnresolvedReferences_is_set()
        {
            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x =>
                {
                    x.LocalReferenceBasePath = this.rootPath;
                    x.ThrowOnUnresolvedReferences = true;
                })
                .WithLogger(this.loggerFactory)
                .Build();

            var exception = Assert.Throws<UnresolvedReferencesException>(() => reader.Read(Path.Combine(this.rootPath, "unresolved.xml")));

            using (Assert.EnterMultipleScope())
            {
                Assert.That(new DefaultSettings().ThrowOnUnresolvedReferences, Is.False);
                Assert.That(exception.Failures.Select(x => x.Identifier), Is.EquivalentTo(new[] { "missing", "missing.xml#x" }));
                Assert.That(exception.Failures.Select(x => x.PropertyName), Is.All.EqualTo("ownedRule"));
                Assert.That(exception.Failures.Select(x => x.Kind), Is.All.EqualTo(XmiReferenceResolutionFailureKind.NotFound));
                Assert.That(exception.Message, Does.Contain("unresolved.xml#idO1 (uml:Operation).ownedRule -> missing [NotFound]"));
            }
        }

        [Test]
        public void Verify_that_resolvable_documents_do_not_throw_when_ThrowOnUnresolvedReferences_is_set()
        {
            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x =>
                {
                    x.LocalReferenceBasePath = this.rootPath;
                    x.ThrowOnUnresolvedReferences = true;
                })
                .WithLogger(this.loggerFactory)
                .Build();

            Assert.That(() => reader.Read(Path.Combine(this.rootPath, "doc1.xml")), Throws.Nothing);
        }

        [Test]
        public void Verify_that_a_proxy_does_not_take_an_element_away_from_its_owner()
        {
            var xmiReaderResult = this.Read("already-owned.xml");

            var package = xmiReaderResult.QueryRoot("idP1");
            var classA = package.PackagedElement.OfType<IClass>().Single(x => x.Name == "A");
            var classB = package.PackagedElement.OfType<IClass>().Single(x => x.Name == "B");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(classA.OwnedRule.Single().XmiId, Is.EqualTo("idC1"));
                Assert.That(classA.OwnedRule.Single().Possessor, Is.SameAs(classA));
                Assert.That(classB.OwnedRule, Is.Empty);
            }
        }
    }
}
