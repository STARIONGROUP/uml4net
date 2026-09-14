// -------------------------------------------------------------------------------------------------
// <copyright file="ExternalReferenceResolverTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Tests.ReferenceResolver
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;
    
    using Serilog;
    using Settings;

    using uml4net.Classification;
    using uml4net.xmi.ReferenceResolver;
    using uml4net.xmi.Resources;

    [TestFixture]
    public class ExternalReferenceResolverTestFixture
    {
        private ILoggerFactory loggerFactory;

        private ExternalReferenceResolver referenceResolver;

        private ResourceLoader resourceLoader;

        private XmiElementCache xmiElementCache;

        private IXmiReaderSettings settings;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();

            loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSerilog();
            });
        }

        [SetUp]
        public void SetUp()
        {
            this.resourceLoader = new ResourceLoader();

            this.xmiElementCache = new XmiElementCache();

            this.settings = new Settings.DefaultSettings();

            this.referenceResolver = new ExternalReferenceResolver(this.resourceLoader,
                this.xmiElementCache, settings, this.loggerFactory.CreateLogger<ExternalReferenceResolver>());
        }

        [Test]
        public void Verify_that_resolving_external_resources_that_are_known_returns_expected_result()
        {
            var property_1 = new Property
            {
                XmiId = "property_1",
                Name = "IsValid",
                DocumentName = "test",
            };
            property_1.SingleValueReferencePropertyIdentifiers.Add("type", "http://www.omg.org/spec/UML/20131001/PrimitiveTypes.xmi#Boolean");
            property_1.MultiValueReferencePropertyIdentifiers.Add("subsettedProperty", ["https://www.omg.org/spec/UML/20131001/PrimitiveTypes.xmi#Boolean"]);

            var property_2 = new Property
            {
                XmiId = "property_2",
                Name = "IsComposite",
                DocumentName = "test",
            };
            property_2.SingleValueReferencePropertyIdentifiers.Add("type", "PrimitiveTypes.xmi#Boolean");
            property_2.MultiValueReferencePropertyIdentifiers.Add("subsettedProperty", ["PrimitiveTypes#Boolean"]);

            this.xmiElementCache.TryAdd(property_1);
            this.xmiElementCache.TryAdd(property_2);

            var resolvedKnowReferences = this.referenceResolver.TryResolve("test");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(resolvedKnowReferences.Count, Is.EqualTo(4));
                Assert.That(resolvedKnowReferences[0].Context, Is.EqualTo("http://www.omg.org/spec/UML/20131001/PrimitiveTypes.xmi"));
                Assert.That(resolvedKnowReferences[1].Context, Is.EqualTo("PrimitiveTypes.xmi"));
                Assert.That(resolvedKnowReferences[2].Context, Is.EqualTo("https://www.omg.org/spec/UML/20131001/PrimitiveTypes.xmi"));
                Assert.That(resolvedKnowReferences[3].Context, Is.EqualTo("PrimitiveTypes"));
            }
        }

        [Test]
        public void Verify_that_external_resources_of_composite_references_are_resolved()
        {
            var operation = new Operation
            {
                XmiId = "operation_1",
                DocumentName = "test",
            };

            operation.CompositeReferencePropertyIdentifiers.Add("ownedParameter",
            [
                new XmiCompositeReference { Identifier = "local", Position = 0 },
                new XmiCompositeReference { Identifier = "PrimitiveTypes.xmi#Boolean", Position = 1 }
            ]);

            this.xmiElementCache.TryAdd(operation);

            var resolvedKnowReferences = this.referenceResolver.TryResolve("test");

            Assert.That(resolvedKnowReferences.Single().Context, Is.EqualTo("PrimitiveTypes.xmi"));
        }

        [Test]
        public void Verify_that_duplicate_use_of_known_resource_returns_only_once()
        {
            var property_1 = new Property
            {
                XmiId = "property_1",
                Name = "IsValid",
                DocumentName = "test",
            };
            property_1.SingleValueReferencePropertyIdentifiers.Add("type", "https://www.omg.org/spec/UML/20131001/PrimitiveTypes.xmi#Boolean");
            property_1.MultiValueReferencePropertyIdentifiers.Add("subsettedProperty", ["https://www.omg.org/spec/UML/20131001/PrimitiveTypes.xmi#Integer"]);

            this.xmiElementCache.TryAdd(property_1);

            var resolvedKnowReferences = this.referenceResolver.TryResolve("test");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(resolvedKnowReferences.Count, Is.EqualTo(1));
                Assert.That(resolvedKnowReferences[0].Context, Is.EqualTo("https://www.omg.org/spec/UML/20131001/PrimitiveTypes.xmi"));
            }
        }

        [Test]
        public void verify_that_http_or_https_resolve_to_local_file()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            this.settings.LocalReferenceBasePath = rootPath;

            var property_1 = new Property
            {
                XmiId = "property_1",
                Name = "IsValid",
                DocumentName = "test",
            };
            property_1.SingleValueReferencePropertyIdentifiers.Add("type", "https://www.omg.org/spec/UML/PrimitiveTypes.xmi#Boolean");
            property_1.SingleValueReferencePropertyIdentifiers.Add("count", "http://www.omg.org/spec/UML/PrimitiveTypes.xmi#Integer");
            property_1.SingleValueReferencePropertyIdentifiers.Add("unlimitedCount", "ftp://www.omg.org/spec/UML/PrimitiveTypes.xmi#LiteralUnlimitedNatural");

            this.xmiElementCache.TryAdd(property_1);

            var resolvedKnowReferences = this.referenceResolver.TryResolve("test");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(resolvedKnowReferences.Count, Is.EqualTo(3));
                Assert.That(resolvedKnowReferences[0].Context, Is.EqualTo("https://www.omg.org/spec/UML/PrimitiveTypes.xmi"));
                Assert.That(resolvedKnowReferences[1].Context, Is.EqualTo("http://www.omg.org/spec/UML/PrimitiveTypes.xmi"));
                Assert.That(resolvedKnowReferences[2].Context, Is.EqualTo("ftp://www.omg.org/spec/UML/PrimitiveTypes.xmi"));
            }
        }

        [Test]
        public void Verity_that_file_references_can_be_processed()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var fileSchemePath = $"file://{rootPath}//PrimitiveTypes.xmi#Boolean";
            var resoureceName = $"file://{rootPath}//PrimitiveTypes.xmi";

            var property_1 = new Property
            {
                XmiId = "property_1",
                Name = "IsValid",
                DocumentName = "test",
            };
            property_1.SingleValueReferencePropertyIdentifiers.Add("type", fileSchemePath);

            this.xmiElementCache.TryAdd(property_1);

            var resolvedKnowReferences = this.referenceResolver.TryResolve("test");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(resolvedKnowReferences.Count, Is.EqualTo(1));
                Assert.That(resolvedKnowReferences[0].Context, Is.EqualTo(resoureceName));
            }
        }

        [Test]
        public void Verify_that_RegisterDocumentLocation_throws_for_empty_arguments()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => this.referenceResolver.RegisterDocumentLocation("", "C:/a.xmi"), Throws.ArgumentException);
                Assert.That(() => this.referenceResolver.RegisterDocumentLocation("a.xmi", null), Throws.ArgumentException);
            }
        }

        [Test]
        public void Verify_that_a_relative_reference_is_resolved_against_the_registered_location_of_the_referencing_document()
        {
            // the base path points at a folder where ../lib/types.xmi does not exist
            this.settings.LocalReferenceBasePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var referencingDocument = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "RelativeReferences", "models", "a.xmi");
            this.referenceResolver.RegisterDocumentLocation("a.xmi", referencingDocument);

            var property = new Property { XmiId = "A-t", DocumentName = "a.xmi" };
            property.SingleValueReferencePropertyIdentifiers.Add("type", "../lib/types.xmi#T");
            this.xmiElementCache.TryAdd(property);

            var resolved = this.referenceResolver.TryResolve("a.xmi");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(resolved, Has.Count.EqualTo(1));
                Assert.That(resolved[0].Context, Is.EqualTo("../lib/types.xmi"), "the context stays the href as written, it is the document name of the elements");
                Assert.That(resolved[0].Stream.Length, Is.GreaterThan(0));
            }

            // the location of the resolved document is known from now on: a relative reference declared in it resolves against lib/
            var chained = new Property { XmiId = "T-b", DocumentName = "../lib/types.xmi" };
            chained.SingleValueReferencePropertyIdentifiers.Add("type", "./base.xmi#B");
            this.xmiElementCache.TryAdd(chained);

            var chainedResolved = this.referenceResolver.TryResolve("../lib/types.xmi");

            Assert.That(chainedResolved.Select(x => x.Context), Is.EqualTo(new[] { "./base.xmi" }));
        }

        [Test]
        public void Verify_that_a_relative_reference_that_does_not_exist_next_to_the_referencing_document_falls_back_to_the_base_path()
        {
            this.settings.LocalReferenceBasePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            this.referenceResolver.RegisterDocumentLocation("test", Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "RelativeReferences", "models", "a.xmi"));

            var property = new Property { XmiId = "p", DocumentName = "test" };
            property.SingleValueReferencePropertyIdentifiers.Add("type", "PrimitiveTypes.xmi#Boolean");
            this.xmiElementCache.TryAdd(property);

            var resolved = this.referenceResolver.TryResolve("test");

            Assert.That(resolved.Select(x => x.Context), Is.EqualTo(new[] { "PrimitiveTypes.xmi" }), "PrimitiveTypes.xmi is not in models/ but is under the base path");
        }

        [Test]
        public void Verify_that_a_remote_reference_is_mapped_to_a_local_copy_by_host_and_path_before_file_name()
        {
            this.settings.LocalReferenceBasePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "RemoteReferences");

            var property = new Property { XmiId = "C-a", DocumentName = "model.xmi" };
            property.SingleValueReferencePropertyIdentifiers.Add("type", "http://example.com/a/types.xmi#T");
            property.MultiValueReferencePropertyIdentifiers.Add("redefinedProperty", ["http://example.com/b/types.xmi#T"]);
            this.xmiElementCache.TryAdd(property);

            var resolved = this.referenceResolver.TryResolve("model.xmi");

            // the streams can be read once only, so their content is materialized before asserting on it
            var contents = resolved.Select(x => new StreamReader(x.Stream).ReadToEnd()).ToList();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(resolved.Select(x => x.Context), Is.EqualTo(new[] { "http://example.com/a/types.xmi", "http://example.com/b/types.xmi" }), "two remote documents with the same file name do not collide");
                Assert.That(contents[0], Does.Contain("name=\"TA\""), "read from example.com/a/types.xmi");
                Assert.That(contents[1], Does.Contain("name=\"TB\""), "read from example.com/b/types.xmi");
            }
        }

        [Test]
        public void Verify_that_non_external_references_are_not_processed()
        {
            var property_1 = new Property
            {
                XmiId = "property_1",
                Name = "IsValid",
                DocumentName = "test",
            };
            property_1.SingleValueReferencePropertyIdentifiers.Add("type", "Boolean");

            this.xmiElementCache.TryAdd(property_1);

            var resolvedKnowReferences = this.referenceResolver.TryResolve("test");

            Assert.That(resolvedKnowReferences.Count, Is.EqualTo(0));
        }

        [Test]
        public void Verify_that_a_resource_key_with_a_trailing_hash_does_not_throw_and_is_not_resolved()
        {
            var property_1 = new Property
            {
                XmiId = "property_1",
                Name = "IsValid",
                DocumentName = "test",
            };
            property_1.SingleValueReferencePropertyIdentifiers.Add("type", "PrimitiveTypes.xmi#");

            this.xmiElementCache.TryAdd(property_1);

            IReadOnlyList<(string Context, Stream Stream)> resolvedKnowReferences = null;

            Assert.That(() => resolvedKnowReferences = this.referenceResolver.TryResolve("test"), Throws.Nothing);

            Assert.That(resolvedKnowReferences.Count, Is.EqualTo(0));
        }
    }
}
