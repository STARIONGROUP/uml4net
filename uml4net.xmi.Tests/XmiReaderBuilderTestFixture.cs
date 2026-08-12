// -------------------------------------------------------------------------------------------------
// <copyright file="XmiReaderBuilderTestFixture.cs" company="Starion Group S.A.">
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

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    using uml4net.xmi.Readers;

    [TestFixture]
    public class XmiReaderBuilderTestFixture
    {
        private string legacyNamespaceFilePath;

        private ILoggerFactory loggerFactory;

        [SetUp]
        public void SetUp()
        {
            this.legacyNamespaceFilePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "EAExportLegacyNamespace.xmi");
            this.loggerFactory = LoggerFactory.Create(builder => { });
        }

        [Test]
        public void Verify_that_a_document_using_an_unrecognized_namespace_throws_without_additional_mapping()
        {
            var reader = XmiReaderBuilder.Create().WithLogger(this.loggerFactory).Build();

            Assert.That(() => reader.Read(this.legacyNamespaceFilePath), Throws.TypeOf<InvalidDataException>());
        }

        [Test]
        public void Verify_that_WithAdditionalNamespaceMapping_allows_a_legacy_namespaced_document_to_be_read()
        {
            var reader = XmiReaderBuilder.Create()
                .WithAdditionalNamespaceMapping("http://schema.omg.org/spec/XMI/2.1", KnowNamespacePrefixes.Xmi)
                .WithAdditionalNamespaceMapping("http://schema.omg.org/spec/UML/2.1", KnowNamespacePrefixes.Uml)
                .WithLogger(this.loggerFactory)
                .Build();

            XmiReaderResult result = null;

            Assert.That(() => result = reader.Read(this.legacyNamespaceFilePath), Throws.Nothing);

            Assert.That(result.Packages, Has.Count.EqualTo(1));
            Assert.That(result.Packages[0].Name, Is.EqualTo("LegacyNamespaceModel"));
            Assert.That(result.Packages[0].NestedPackage[0].Name, Is.EqualTo("LegacyPackage"));
        }

        [Test]
        public void Verify_that_WithAdditionalNamespaceMapping_is_idempotent_for_already_known_namespaces()
        {
            Assert.That(() => XmiReaderBuilder.Create()
                .WithAdditionalNamespaceMapping("http://www.omg.org/spec/XMI/20161101", KnowNamespacePrefixes.Xmi)
                .WithLogger(this.loggerFactory)
                .Build(), Throws.Nothing);
        }

        [Test]
        public void Verify_that_WithAdditionalNamespaceMapping_throws_on_null_or_empty_arguments()
        {
            var scope = XmiReaderBuilder.Create();

            Assert.That(() => scope.WithAdditionalNamespaceMapping(null, KnowNamespacePrefixes.Xmi), Throws.ArgumentException);
            Assert.That(() => scope.WithAdditionalNamespaceMapping(string.Empty, KnowNamespacePrefixes.Xmi), Throws.ArgumentException);
            Assert.That(() => scope.WithAdditionalNamespaceMapping("https://www.stariongroup.eu", null), Throws.ArgumentException);
            Assert.That(() => scope.WithAdditionalNamespaceMapping("https://www.stariongroup.eu", string.Empty), Throws.ArgumentException);
        }
    }
}
