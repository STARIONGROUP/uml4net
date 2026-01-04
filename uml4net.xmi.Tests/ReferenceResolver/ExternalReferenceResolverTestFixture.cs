// -------------------------------------------------------------------------------------------------
//  <copyright file="ExternalReferenceResolverTestFixture.cs" company="Starion Group S.A.">
// 
//    Copyright (C) 2019-2026 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
//  </copyright>
//  ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Tests.ReferenceResolver
{
    using System.IO;

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
    }
}
