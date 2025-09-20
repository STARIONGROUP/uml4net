// -------------------------------------------------------------------------------------------------
// <copyright file="UMLXmiReaderTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2025 Starion Group S.A.
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

    using uml4net.Values;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;
    using uml4net.xmi;

    [TestFixture]
    public class UMLXmiReaderTestFixture
    {
        private ILoggerFactory loggerFactory;

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
        }

        [Test]
        public void Verify_that_UML_PrimitiveTypes__XMI_can_be_read()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = rootPath)
                .WithLogger(this.loggerFactory)
                .Build();

            var xmiReaderResult = reader.Read(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "PrimitiveTypes.xmi"));

            Assert.That(xmiReaderResult.XmiRoot, Is.Not.Null);

            Assert.That(xmiReaderResult.Packages.Count, Is.EqualTo(1));

            var package = xmiReaderResult.Packages.First();

            Assert.That(package.XmiId, Is.EqualTo("_0"));
            Assert.That(package.Name, Is.EqualTo("PrimitiveTypes"));
            Assert.That(package.PackagedElement.Count, Is.EqualTo(5));

            var booleanPrimitiveType = package.PackagedElement.OfType<IPrimitiveType>().Single(x => x.XmiId == "Boolean");

            Assert.That(booleanPrimitiveType.Name, Is.EqualTo("Boolean"));

            var comment = booleanPrimitiveType.OwnedComment.Single();

            Assert.That(comment.AnnotatedElement, Contains.Item(booleanPrimitiveType));
        }

        [Test]
        public void Verify_that_UML_XMI_can_be_read()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = rootPath)
                .WithLogger(this.loggerFactory)
                .Build();

            var xmiReaderResult = reader.Read(Path.Combine(rootPath, "UML.xmi"));

            Assert.That(xmiReaderResult.XmiRoot, Is.Not.Null);
            Assert.That(xmiReaderResult.XmiRoot.Documentation.ShortDescription.First(), Is.EqualTo("UML.xmi: XMI representation of the metamodel for UML 2.5.1."));

            Assert.That(xmiReaderResult.Packages.Count, Is.EqualTo(2));

            var package = xmiReaderResult.QueryRoot("_0", "UML");

            Assert.That(package.XmiId, Is.EqualTo("_0"));
            Assert.That(package.XmiType, Is.EqualTo("uml:Package"));
            Assert.That(package.Name, Is.EqualTo("UML"));

            Assert.That(package.PackageImport.Count, Is.EqualTo(15));

            var packageImport = package.PackageImport.First();
            Assert.That(packageImport.XmiId, Is.EqualTo("_packageImport.0"));

            var structuredClassifiersPackage = package.PackagedElement.OfType<IPackage>().Single(x => x.Name == "StructuredClassifiers");

            var structuredClassifiersPackageClasses = structuredClassifiersPackage.PackagedElement.OfType<IClass>();

            Assert.That(structuredClassifiersPackageClasses.Count, Is.EqualTo(14));

            var @class = structuredClassifiersPackageClasses.Single(x => x.Name == "Class");

            var classOwnedComment = @class.OwnedComment.Single();

            Assert.That(classOwnedComment.Body, Is.EqualTo("A Class classifies a set of objects and specifies the features that characterize the structure and behavior of those objects.  A Class may have an internal structure and Ports.\r\n"));

            Assert.That(@class.Generalization.Count, Is.EqualTo(2));

            Assert.That(@class.OwnedAttribute.Where(x => x.Name is "isActive" or "isAbstract").All(x => x.Type.Name == "Boolean"), Is.True);

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

            var opaqueExpression = classOwnedRule.Specification.First() as IOpaqueExpression;

            Assert.That(opaqueExpression.Body.Single(), Is.EqualTo("not isActive implies (ownedReception->isEmpty() and classifierBehavior = null)"));
            Assert.That(opaqueExpression.Language.Single(), Is.EqualTo("OCL"));

            Assert.That(@class.OwnedAttribute.Count, Is.EqualTo(8));

            var classOwnedAttribute = @class.OwnedAttribute.First();

            Assert.That(classOwnedAttribute.Name, Is.EqualTo("extension"));
            Assert.That(classOwnedAttribute.IsReadOnly, Is.True);
            Assert.That(classOwnedAttribute.IsDerived, Is.True);
            Assert.That(classOwnedAttribute.OwnedComment.First().Body, Is.EqualTo("This property is used when the Class is acting as a metaclass. It references the Extensions that specify additional properties of the metaclass. The property is derived from the Extensions whose memberEnds are typed by the Class."));

            var classLowerValue = (ILiteralInteger)classOwnedAttribute.LowerValue.Single();

            Assert.That(classLowerValue.Value, Is.EqualTo(0));

            var classificationPackage = package.PackagedElement.OfType<IPackage>().Single(x => x.Name == "Classification");

            var aggregationKind = classificationPackage.PackagedElement.OfType<IEnumeration>().Single(x => x.Name == "AggregationKind");

            Assert.That(aggregationKind.XmiId, Is.EqualTo("AggregationKind"));

            var activity = package.PackagedElement.OfType<IPackage>().Single(x => x.Name == "Activities").PackagedElement.OfType<IClass>().Single(x => x.Name == "Activity");

            var property = activity.OwnedAttribute.Single(x => x.XmiId == "Activity-group");
            Assert.That(property.Association, Is.Not.Null);
            Assert.That(property.Association.XmiId, Is.EqualTo("A_group_inActivity"));
            Assert.That(property.Association.MemberEnd, Has.Count.EqualTo(2));
            Assert.That(property.Association.MemberEnd, Has.Member(property));
        }
    }
}
