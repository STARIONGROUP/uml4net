// -------------------------------------------------------------------------------------------------
// <copyright file="UMLDIXmiReaderTestFixture.cs" company="Starion Group S.A.">
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

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    using Serilog;

    using uml4net.Classification;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;
    using uml4net.xmi;

    [TestFixture]
    public class UMLDIXmiReaderTestFixture
    {
        private const string DiDocument = "http://www.omg.org/spec/DD/20131001/DI.xmi";

        private const string DcDocument = "http://www.omg.org/spec/DD/20131001/DC.xmi";

        private ILoggerFactory loggerFactory;

        private string emptyLocalReferenceBasePath;

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

            // no local copy of the OMG documents can be found here: they have to come from the embedded resources
            this.emptyLocalReferenceBasePath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(this.emptyLocalReferenceBasePath);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Directory.Delete(this.emptyLocalReferenceBasePath, true);
        }

        [Test]
        public void Verify_that_the_DI_and_DC_documents_referenced_by_UMLDI_are_resolved_from_the_embedded_resources()
        {
            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = this.emptyLocalReferenceBasePath)
                .WithLogger(this.loggerFactory)
                .Build();

            var xmiReaderResult = reader.Read(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "UMLDI.xmi"));

            var umlDi = xmiReaderResult.DocumentRootElements.OfType<IPackage>().Single();
            var umlDiagram = umlDi.PackagedElement.OfType<IClass>().Single(x => x.Name == "UMLDiagram");
            var umlDiagramElement = umlDi.PackagedElement.OfType<IClass>().Single(x => x.Name == "UMLDiagramElement");
            var modelElement = umlDiagramElement.OwnedAttribute.Single(x => x.Name == "modelElement");

            var di = xmiReaderResult.ExternalXmiRoots[DiDocument].Content.OfType<IPackage>().Single();
            var shape = di.PackagedElement.OfType<IClass>().Single(x => x.Name == "Shape");
            var bounds = shape.OwnedAttribute.Single(x => x.Name == "bounds");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(xmiReaderResult.ExternalXmiRoots.Keys, Does.Contain(DiDocument));
                Assert.That(xmiReaderResult.ExternalXmiRoots.Keys, Does.Contain(DcDocument), "DC is referenced by DI");

                Assert.That(umlDi.PackageImport.Select(x => x.ImportedPackage.Name), Does.Contain("DI"));
                Assert.That(umlDiagram.Generalization.Select(x => x.General.Name), Is.EquivalentTo(new[] { "Diagram", "PackageableElement", "UMLDiagramElement" }));
                Assert.That(modelElement.RedefinedProperty.Single().Name, Is.EqualTo("modelElement"));
                Assert.That(modelElement.RedefinedProperty.Single().Owner, Is.InstanceOf<IClass>().With.Property(nameof(IClass.Name)).EqualTo("DiagramElement"));

                Assert.That(di.PackageImport.Select(x => x.ImportedPackage.Name), Is.EquivalentTo(new[] { "DC", "UML" }), "the 2013 UML URI of DI resolves to the embedded UML 2.5.1 document");
                Assert.That(bounds.Type, Is.InstanceOf<IDataType>().With.Property(nameof(IDataType.Name)).EqualTo("Bounds"));
            }
        }
    }
}
