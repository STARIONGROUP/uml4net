// -------------------------------------------------------------------------------------------------
// <copyright file="UMLXmiReaderTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2019-2024 Starion Group S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, softwareUseCases
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
    using POCO.Values;
    using uml4net.POCO.Packages;
    using uml4net.POCO.SimpleClassifiers;
    using uml4net.POCO.StructuredClassifiers;
    
    [TestFixture]
    public class UMLXmiReaderTestFixture
    {
        private ILoggerFactory loggerFactory;

        [SetUp]
        public void SetUp()
        {
            this.loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        }

        [Test]
        public void Verify_that_UML_PrimitiveTypes__XMI_can_be_read()
        {
            var reader = new XmiReader(this.loggerFactory);

            var packages = reader.Read(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "PrimitiveTypes.xmi.xml"));

            Assert.That(packages.Count(), Is.EqualTo(1));

            var package = packages.First();

            Assert.That(package.XmiId, Is.EqualTo("_0"));
            Assert.That(package.Name, Is.EqualTo("PrimitiveTypes"));
        }

        [Test]
        public void Verify_that_UML_XMI_can_be_read()
        {
            var reader = new XmiReader(this.loggerFactory);

            var packages = reader.Read(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "UML.xmi.xml"));

            Assert.That(packages.Count(), Is.EqualTo(1));

            var package = packages.First();

            Assert.That(package.XmiId, Is.EqualTo("_0"));
            Assert.That(package.XmiType, Is.EqualTo("uml:Package"));
            Assert.That(package.Name, Is.EqualTo("UML"));

            Assert.That(package.PackageImport.Count, Is.EqualTo(15));

            var packageImport = package.PackageImport.First();
            Assert.That(packageImport.XmiId, Is.EqualTo("_packageImport.0"));

            var structuredClassifiersPackage = package.PackagedElement.OfType<IPackage>().Single(x => x.Name == "StructuredClassifiers");

            var structuredClassifiersPackageClasses = structuredClassifiersPackage.PackagedElement.OfType<IClass>();

            Assert.That(structuredClassifiersPackageClasses.Count(), Is.EqualTo(14));

            var @class = structuredClassifiersPackageClasses.Single(x => x.Name == "Class");

            var classOwnedComment = @class.OwnedComment.Single();

            Assert.That(classOwnedComment.Body, Is.EqualTo("A Class classifies a set of objects and specifies the features that characterize the structure and behavior of those objects.  A Class may have an internal structure and Ports.\r\n"));

            Assert.That(@class.Generalization.Count, Is.EqualTo(2));

            var structuredClassifiersPackageEnumerations = structuredClassifiersPackage.PackagedElement.OfType<IEnumeration>();

            Assert.That(structuredClassifiersPackageEnumerations.Count, Is.EqualTo(1));

            var connectorKindEnumeration = structuredClassifiersPackageEnumerations.Single();

            Assert.That(connectorKindEnumeration.Name, Is.EqualTo("ConnectorKind"));
            Assert.That(connectorKindEnumeration.OwnedComment.First().Body, Is.EqualTo("ConnectorKind is an enumeration that defines whether a Connector is an assembly or a delegation."));

            Assert.That(connectorKindEnumeration.OwnedLiteral.Count, Is.EqualTo(2));

            var connectorKindEnumerationEnumerationLiteralAssembly = connectorKindEnumeration.OwnedLiteral.First();

            Assert.That(connectorKindEnumerationEnumerationLiteralAssembly.Name, Is.EqualTo("assembly"));
            Assert.That(connectorKindEnumerationEnumerationLiteralAssembly.OwnedComment.First().Body, Is.EqualTo("Indicates that the Connector is an assembly Connector."));

            var classOwnedRule = @class.OwnedRule.Single();

            Assert.That(classOwnedRule.OwnedComment.Single().Body, Is.EqualTo("Only an active Class may own Receptions and have a classifierBehavior."));

            var opaqueExpression = classOwnedRule.Specification as IOpaqueExpression;

            Assert.That(opaqueExpression.Body.Single(), Is.EqualTo("not isActive implies (ownedReception->isEmpty() and classifierBehavior = null)"));
            Assert.That(opaqueExpression.Language.Single(), Is.EqualTo("OCL"));
        }
    }
}
