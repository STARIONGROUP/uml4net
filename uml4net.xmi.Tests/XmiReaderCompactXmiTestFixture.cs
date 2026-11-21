// -------------------------------------------------------------------------------------------------
// <copyright file="XmiReaderCompactXmiTestFixture.cs" company="Starion Group S.A.">
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

    using uml4net.StructuredClassifiers;

    /// <summary>
    /// Verifies that XMI without whitespace between elements (compact XMI) is read completely: value elements
    /// and skipped elements must not swallow the sibling element that directly follows them
    /// </summary>
    [TestFixture]
    public class XmiReaderCompactXmiTestFixture
    {
        [Test]
        public void Verify_that_compact_xmi_is_read_completely()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "Compact");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x =>
                {
                    x.LocalReferenceBasePath = rootPath;
                    x.UseStrictReading = true;
                })
                .WithLogger(NullLoggerFactory.Instance)
                .Build();

            var xmiReaderResult = reader.Read(Path.Combine(rootPath, "compact.xmi"));

            var package = xmiReaderResult.QueryRoot("p");
            var classes = package.PackagedElement.OfType<IClass>().ToList();
            var classC = classes.Single(x => x.XmiId == "c");
            var property = classC.OwnedAttribute.Single();
            var documentation = xmiReaderResult.XmiRoot.Documentation;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(classes.Select(x => x.Name), Is.EqualTo(new[] { "C", "D" }), "the package that follows the skipped difference element and both classes are read");
                Assert.That(classC.OwnedComment.Select(x => x.Body), Is.EqualTo(new[] { "first", "second" }), "the comment that directly follows the name element is read");
                Assert.That(property.IsReadOnly, Is.True);
                Assert.That(property.OwnedComment.Single().Body, Is.EqualTo("third"), "the comment that directly follows the isReadOnly element is read");

                Assert.That(documentation.Exporter, Is.EqualTo("uml4net"));
                Assert.That(documentation.ExporterVersion, Is.EqualTo("1.0"), "the element that directly follows the exporter element is read");
                Assert.That(documentation.ShortDescription, Is.EqualTo(new[] { "compact" }));
            }
        }
    }
}
