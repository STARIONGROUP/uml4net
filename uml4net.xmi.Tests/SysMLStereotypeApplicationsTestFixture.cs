// -------------------------------------------------------------------------------------------------
// <copyright file="SysMLStereotypeApplicationsTestFixture.cs" company="Starion Group S.A.">
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

    using uml4net.Profiling;
    using uml4net.StructuredClassifiers;
    using uml4net.xmi.Readers;

    /// <summary>
    /// Verifies the stereotype applications of the normative SysML 1.7 QUDV model library (ptc/24-01-04), with the
    /// SysML profile (ptc/24-01-02) as the local copy of https://www.omg.org/spec/SysML/20240101/SysML.xmi: the namespace of
    /// the applications is the location of the profile document, not the URI of the profile
    /// </summary>
    [TestFixture]
    public class SysMLStereotypeApplicationsTestFixture
    {
        private string rootPath;

        [SetUp]
        public void SetUp()
        {
            this.rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "SySML1.7", "StereotypeApplications");
        }

        [Test]
        public void Verify_that_the_SysML_and_StandardProfile_applications_of_QUDV_are_resolved()
        {
            var xmiReaderResult = this.Read(Path.Combine(this.rootPath, "QUDV.xmi"));
            var applications = xmiReaderResult.XmiRoot.StereoTypeApplications;
            var prefix = xmiReaderResult.QueryRoot("QUDV").PackagedElement.OfType<IClass>().Single(x => x.Name == "Prefix");
            var block = prefix.QueryStereoTypeApplication("Block");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(applications, Has.Count.EqualTo(19));
                Assert.That(applications.Count(x => x.Stereotype?.Name == "Block"), Is.EqualTo(17));
                Assert.That(applications.Count(x => x.Stereotype?.Name == "ValueType"), Is.EqualTo(1));
                Assert.That(applications.Count(x => x.Stereotype?.Name == "ModelLibrary"), Is.EqualTo(1));
                Assert.That(applications.All(x => x.ExtendedElement != null), Is.True);

                Assert.That(block, Is.Not.Null);
                Assert.That(block.NamespaceUri, Is.EqualTo("https://www.omg.org/spec/SysML/20240101/SysML.xmi"));
                Assert.That(block.Stereotype.DocumentName, Is.EqualTo("https://www.omg.org/spec/SysML/20240101/SysML.xmi"));
                Assert.That(block.QueryTaggedValue("isEncapsulated").Values, Is.EqualTo(new object[] { false }));
                Assert.That(xmiReaderResult.QueryRoot("QUDV").QueryStereoTypeApplication("ModelLibrary")?.Stereotype?.Name, Is.EqualTo("ModelLibrary"));
            }
        }

        [Test]
        public void Verify_that_the_applications_of_QUDV_survive_a_read_write_read_cycle()
        {
            var xmiReaderResult = this.Read(Path.Combine(this.rootPath, "QUDV.xmi"));
            var outputPath = Path.Combine(this.rootPath, "QUDV-written.xmi");

            try
            {
                XmiWriterBuilder.Create().WithLogger(NullLoggerFactory.Instance).Build().Write(xmiReaderResult.DocumentRootElements, outputPath, xmiReaderResult.XmiRoot);

                var written = File.ReadAllText(outputPath);
                var rereadResult = this.Read(outputPath);

                using (Assert.EnterMultipleScope())
                {
                    Assert.That(written, Does.Contain("xmlns:SysML=\"https://www.omg.org/spec/SysML/20240101/SysML.xmi\""));
                    Assert.That(written, Does.Contain("<SysML:Block xmi:id=\"SysML.Block_appliedOn_QUDV.Prefix\" base_Class=\"QUDV.Prefix\" isEncapsulated=\"false\" />"));
                    Assert.That(rereadResult.XmiRoot.StereoTypeApplications.Select(Describe), Is.EqualTo(xmiReaderResult.XmiRoot.StereoTypeApplications.Select(Describe)));
                    Assert.That(rereadResult.XmiRoot.StereoTypeApplications.All(x => x.Stereotype != null && x.ExtendedElement != null), Is.True);
                }
            }
            finally
            {
                File.Delete(outputPath);
            }
        }

        private static string Describe(StereoTypeApplication application)
        {
            return $"{application.XmiId}|{application.Stereotype?.Name}|{application.ExtendedElement?.XmiId}|{string.Join(";", application.TaggedValues.Select(x => $"{x.Name}={string.Join(",", x.Values.Select(v => TaggedValueConverter.Format(v, x.Property)))}"))}";
        }

        private XmiReaderResult Read(string path)
        {
            using var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = this.rootPath)
                .WithLogger(NullLoggerFactory.Instance)
                .Build();

            return reader.Read(path);
        }
    }
}
