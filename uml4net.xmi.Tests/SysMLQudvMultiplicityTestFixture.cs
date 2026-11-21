// -------------------------------------------------------------------------------------------------
// <copyright file="SysMLQudvMultiplicityTestFixture.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Tests
{
    using System.IO;
    using System.Linq;

    using Microsoft.Extensions.Logging.Abstractions;

    using NUnit.Framework;

    using uml4net.Classification;
    using uml4net.StructuredClassifiers;
    using uml4net.xmi.Readers;
    using uml4net.xmi.Writers;

    /// <summary>
    /// Verifies the multiplicities of the normative SysML 1.7 QUDV model library (ptc/24-01-04): the <c>[0..0]</c>
    /// property <c>PrefixedUnit::noQuantityKind</c> has an upperValue <c>LiteralUnlimitedNatural</c> without value,
    /// the default of <c>LiteralUnlimitedNatural::value</c>, 0, being omitted
    /// </summary>
    [TestFixture]
    public class SysMLQudvMultiplicityTestFixture
    {
        private string rootPath;

        [SetUp]
        public void SetUp()
        {
            this.rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "SySML1.7", "StereotypeApplications");
        }

        [Test]
        public void Verify_that_an_upper_value_without_value_is_read_as_0()
        {
            var noQuantityKind = QueryNoQuantityKind(this.Read(Path.Combine(this.rootPath, "QUDV.xmi")));

            using (Assert.EnterMultipleScope())
            {
                Assert.That(noQuantityKind.Lower, Is.EqualTo(0));
                Assert.That(noQuantityKind.Upper, Is.EqualTo("0"), "[0..0], #493");
            }
        }

        [Test]
        public void Verify_that_an_upper_value_without_value_is_still_0_after_a_read_write_read_cycle()
        {
            var xmiReaderResult = this.Read(Path.Combine(this.rootPath, "QUDV.xmi"));
            var outputPath = Path.Combine(this.rootPath, "QUDV-multiplicity-written.xmi");

            try
            {
                XmiWriterBuilder.Create().WithLogger(NullLoggerFactory.Instance).Build().Write(xmiReaderResult.DocumentRootElements, outputPath, xmiReaderResult.XmiRoot);

                Assert.That(QueryNoQuantityKind(this.Read(outputPath)).Upper, Is.EqualTo("0"));
            }
            finally
            {
                File.Delete(outputPath);
            }
        }

        private static IProperty QueryNoQuantityKind(XmiReaderResult xmiReaderResult)
        {
            return xmiReaderResult.QueryRoot("QUDV").PackagedElement
                .OfType<IClass>()
                .Single(x => x.Name == "PrefixedUnit")
                .OwnedAttribute
                .Single(x => x.Name == "noQuantityKind");
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
