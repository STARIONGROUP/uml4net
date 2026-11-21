// -------------------------------------------------------------------------------------------------
// <copyright file="KerMLXmiReaderTestFixture.cs" company="Starion Group S.A.">
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

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    using Serilog;

    using uml4net.Packages;
    using uml4net.xmi;

    [TestFixture]
    public class KerMLXmiReaderTestFixture
    {
        private ILoggerFactory loggerFactory;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .CreateLogger();

            this.loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSerilog();
            });
        }

        [Test]
        public void Verify_that_SysML_XMI_can_be_read()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = rootPath)
                .WithLogger(this.loggerFactory)
                .Build();

            var xmiReaderResult =
                reader.Read(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "KerML.xmi"));

            using (Assert.EnterMultipleScope())
            {
                Assert.That(xmiReaderResult.XmiRoot, Is.Not.Null);
                Assert.That(xmiReaderResult.Packages.Count, Is.EqualTo(2));

                var package = xmiReaderResult.QueryRoot("KerML") as IPackage;

                Assert.That(package.XmiId, Is.EqualTo("KerML"));
                Assert.That(package.Name, Is.EqualTo("KerML"));
            }
        }

        [Test]
        public void Verify_that_owned_rules_written_as_proxies_of_body_conditions_are_read()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = rootPath)
                .WithLogger(this.loggerFactory)
                .Build();

            var xmiReaderResult = reader.Read(Path.Combine(rootPath, "KerML.xmi"));

            var elements = xmiReaderResult.Packages
                .SelectMany(QueryElementAndOwnedElements)
                .ToList();

            var operation = elements.OfType<uml4net.Classification.IOperation>()
                .Single(x => x.XmiId == "Kernel-Packages-LibraryPackage-libraryNamespace_");

            var bodyCondition = operation.BodyCondition.Single();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(bodyCondition.XmiId, Is.EqualTo("Kernel-Packages-LibraryPackage-libraryNamespace_-unnamed1"));
                Assert.That(((uml4net.Values.IOpaqueExpression)bodyCondition.Specification.Single()).Body.Single(), Is.EqualTo("self"));
                Assert.That(bodyCondition.Possessor, Is.SameAs(operation));
                Assert.That(operation.OwnedRule, Has.Member(bodyCondition));

                Assert.That(elements.OfType<uml4net.CommonStructure.IConstraint>().Where(x => string.IsNullOrEmpty(x.XmiId)), Is.Empty);
            }
        }

        private static System.Collections.Generic.IEnumerable<uml4net.CommonStructure.IElement> QueryElementAndOwnedElements(uml4net.CommonStructure.IElement element)
        {
            yield return element;

            foreach (var ownedElement in element.OwnedElement.SelectMany(QueryElementAndOwnedElements))
            {
                yield return ownedElement;
            }
        }
    }
}
