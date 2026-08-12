// -------------------------------------------------------------------------------------------------
// <copyright file="EnterpriseArchitectLegacyNamespaceDetectorTestFixture.cs" company="Starion Group S.A.">
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
    using System;
    using System.IO;

    using NUnit.Framework;

    using uml4net.xmi.Extensions.EnterpriseArchitect.Extender;

    [TestFixture]
    public class EnterpriseArchitectLegacyNamespaceDetectorTestFixture
    {
        private string resourcesPath;

        [SetUp]
        public void SetUp()
        {
            this.resourcesPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources");
        }

        [Test]
        public void Verify_that_a_legacy_namespaced_Enterprise_Architect_export_is_detected()
        {
            var fileUri = Path.Combine(this.resourcesPath, "EAExportLegacyNamespace.xmi");

            Assert.That(EnterpriseArchitectLegacyNamespaceDetector.IsLegacyEnterpriseArchitectExport(fileUri), Is.True);
        }

        [Test]
        public void Verify_that_a_modern_namespaced_Enterprise_Architect_export_is_not_detected_as_legacy()
        {
            var fileUri = Path.Combine(this.resourcesPath, "EAExport.xmi");

            Assert.That(EnterpriseArchitectLegacyNamespaceDetector.IsLegacyEnterpriseArchitectExport(fileUri), Is.False);
        }

        [Test]
        public void Verify_that_a_non_existent_file_is_not_detected_as_legacy()
        {
            var fileUri = Path.Combine(this.resourcesPath, "does-not-exist.xmi");

            Assert.That(EnterpriseArchitectLegacyNamespaceDetector.IsLegacyEnterpriseArchitectExport(fileUri), Is.False);
        }

        [Test]
        public void Verify_that_a_legacy_namespaced_document_not_exported_by_Enterprise_Architect_is_not_detected()
        {
            var fileUri = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.xmi");

            File.WriteAllText(fileUri, """
                <?xml  version='1.0' encoding='utf-8' ?>
                <xmi:XMI xmlns:xmi="http://schema.omg.org/spec/XMI/2.1" xmlns:uml="http://schema.omg.org/spec/UML/2.1">
                	<xmi:Documentation exporter="Some Other Tool" exporterVersion="1.0"/>
                	<uml:Model xmi:type="uml:Model" name="NotAnEAModel"/>
                </xmi:XMI>
                """);

            try
            {
                Assert.That(EnterpriseArchitectLegacyNamespaceDetector.IsLegacyEnterpriseArchitectExport(fileUri), Is.False);
            }
            finally
            {
                File.Delete(fileUri);
            }
        }

        [Test]
        public void Verify_that_a_malformed_document_is_not_detected_as_legacy()
        {
            var fileUri = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.xmi");

            File.WriteAllText(fileUri, "not xml at all");

            try
            {
                Assert.That(EnterpriseArchitectLegacyNamespaceDetector.IsLegacyEnterpriseArchitectExport(fileUri), Is.False);
            }
            finally
            {
                File.Delete(fileUri);
            }
        }

        [Test]
        public void Verify_that_IsLegacyEnterpriseArchitectExport_throws_on_null_or_empty_fileUri()
        {
            Assert.That(() => EnterpriseArchitectLegacyNamespaceDetector.IsLegacyEnterpriseArchitectExport(null), Throws.ArgumentException);
            Assert.That(() => EnterpriseArchitectLegacyNamespaceDetector.IsLegacyEnterpriseArchitectExport(string.Empty), Throws.ArgumentException);
        }
    }
}
