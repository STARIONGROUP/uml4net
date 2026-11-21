// -------------------------------------------------------------------------------------------------
// <copyright file="ClassifierExtensionsTestFixture.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Extensions.Tests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    using Serilog;

    using uml4net.CommonStructure;
    using uml4net.StructuredClassifiers;
    using uml4net.xmi;
    using uml4net.xmi.Readers;

    [TestFixture]
    public class ClassifierExtensionsTestFixture
    {
        private ILoggerFactory loggerFactory;

        private XmiReaderResult xmiReaderResult;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console()
                .CreateLogger();

            this.loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSerilog();
            });
        }

        [SetUp]
        public void SetUp()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = rootPath)
                .WithLogger(this.loggerFactory)
                .Build();

            this.xmiReaderResult = reader.Read(Path.Combine(rootPath, "UML.xmi"));
        }

        [Test]
        public void Verify_that_QueryAllGeneralClassifiers_returns_expected_result()
        {
            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var commonStructuresPackage = root.NestedPackage.Single(x => x.Name == "CommonStructure");

            var dependency = commonStructuresPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Dependency");

            // Dependency -> DirectedRelationship -> Relationship         -> Element
            //               PackageableElement   -> ParameterableElement -> Element
            //                                    -> NamedElement         -> Element

            var classifiers = dependency.QueryAllGeneralClassifiers();

            foreach (var classifier in classifiers)
            {
                Log.Logger.Information(classifier.Name);
            }

            Assert.That(classifiers.Count, Is.EqualTo(7));
        }

        [Test]
        public void Verify_that_QueryAllGeneralClassifiers_throws_when_classifier_is_null()
        {
            Assert.That(() => ClassifierExtensions.QueryAllGeneralClassifiers(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_QueryContainers_returns_expected_result()
        {
            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var packages = root.QueryAllNestedAndImportedPackages();

            var propertyClass = packages.SelectMany(x => x.PackagedElement.OfType<IClass>())
                .Single(x => x.Name == "Property");

            var containers = propertyClass.QueryContainers();

            var containerNames = containers.OfType<INamedElement>().Select(x => x.Name);

            var expected = new List<string>
            {
                "Artifact", "Association", "Class", "DataType", 
                "Interface", "Property", "Signal", "StructuredClassifier"
            };

            Assert.That(expected, Is.EquivalentTo(containerNames));
        }

        [Test]
        public void Verify_that_QueryContainers_throws_when_classifier_is_null()
        {
            Assert.That(() => ClassifierExtensions.QueryContainers(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_QueryConformsTo_returns_expected_result()
        {
            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var commonStructurePackage = root.NestedPackage.Single(x => x.Name == "CommonStructure");

            var dependency = commonStructurePackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Dependency");
            var packageableElement = commonStructurePackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "PackageableElement");
            var element = commonStructurePackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Element");
            var comment = commonStructurePackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Comment");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(dependency.QueryConformsTo(dependency), Is.True, "a classifier conforms to itself");
                Assert.That(dependency.QueryConformsTo(packageableElement), Is.True, "a direct general classifier");
                Assert.That(dependency.QueryConformsTo(element), Is.True, "an indirect general classifier");
                Assert.That(dependency.QueryConformsTo(comment), Is.False);
                Assert.That(element.QueryConformsTo(dependency), Is.False);
            }
        }

        [Test]
        public void Verify_that_QueryConformsTo_throws_for_missing_arguments()
        {
            var classifier = new Class { Name = "Classifier" };

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => ClassifierExtensions.QueryConformsTo(null, classifier), Throws.ArgumentNullException);
                Assert.That(() => classifier.QueryConformsTo(null), Throws.ArgumentNullException);
            }
        }
    }
}
