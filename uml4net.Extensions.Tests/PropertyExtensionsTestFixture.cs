// -------------------------------------------------------------------------------------------------
//  <copyright file="PropertyExtensionsTestFixture.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2024 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, softwareUseCases
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
//  </copyright>
//  ------------------------------------------------------------------------------------------------

namespace uml4net.Extensions.Tests
{
    using System.IO;
    using System.Linq;

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    using Serilog;

    using uml4net.StructuredClassifiers;
    using uml4net.xmi;
    using xmi.Readers;

    [TestFixture]
    public class PropertyExtensionsTestFixture
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
        public void Verify_that_QueryIsEnum_returns_expected_Result()
        {
            var structuredClassifiersPackage = this.xmiReaderResult.Root.NestedPackage.Single(x => x.Name == "StructuredClassifiers");

            var connector = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Connector");

            var visibility = connector.QueryAllProperties().Single(x => x.Name == "visibility");

            Assert.That(visibility.QueryIsEnum(), Is.True);

            var ownedComment = connector.QueryAllProperties().Single(x => x.Name == "ownedComment");
            
            Assert.That(ownedComment.QueryIsEnum(), Is.False);
        }

        [Test]
        public void Verify_that_QueryIsPrimitiveType_returns_expected_Result()
        {
            var structuredClassifiersPackage = this.xmiReaderResult.Root.NestedPackage.Single(x => x.Name == "StructuredClassifiers");

            var connector = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Connector");

            var isStatic = connector.QueryAllProperties().Single(x => x.Name == "isStatic");

            Assert.That(isStatic.QueryIsPrimitiveType(), Is.True);

            var ownedComment = connector.QueryAllProperties().Single(x => x.Name == "ownedComment");

            Assert.That(ownedComment.QueryIsPrimitiveType(), Is.False);
        }

        [Test]
        public void Verify_that_QueryIsBool_returns_expected_Result()
        {
            var structuredClassifiersPackage = this.xmiReaderResult.Root.NestedPackage.Single(x => x.Name == "StructuredClassifiers");

            var connector = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Connector");

            var isStatic = connector.QueryAllProperties().Single(x => x.Name == "isStatic");

            Assert.That(isStatic.QueryIsBool(), Is.True);

            var ownedComment = connector.QueryAllProperties().Single(x => x.Name == "ownedComment");

            Assert.That(ownedComment.QueryIsBool(), Is.False);
        }

        [Test]
        public void Verify_that_QueryIsNumeric_returns_expected_Result()
        {
            var structuredClassifiersPackage = this.xmiReaderResult.Root.NestedPackage.Single(x => x.Name == "Classification");

            var property = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Property");

            var lower = property.QueryAllProperties().Single(x => x.Name == "lower");

            Assert.That(lower.QueryIsNumeric(), Is.True);

            var ownedComment = property.QueryAllProperties().Single(x => x.Name == "ownedComment");

            Assert.That(ownedComment.QueryIsNumeric(), Is.False);
        }

        [Test]
        public void Verify_that_QueryCSharpTypeName_returns_expected_Result()
        {
            var structuredClassifiersPackage = this.xmiReaderResult.Root.NestedPackage.Single(x => x.Name == "Classification");

            var property = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Property");

            var lower = property.QueryAllProperties().Single(x => x.Name == "lower");

            Assert.That(lower.QueryCSharpTypeName(), Is.EqualTo("int"));

            var isUnique = property.QueryAllProperties().Single(x => x.Name == "isUnique");

            Assert.That(isUnique.QueryCSharpTypeName(), Is.EqualTo("bool"));

            var name = property.QueryAllProperties().Single(x => x.Name == "name");

            Assert.That(name.QueryCSharpTypeName(), Is.EqualTo("string"));
        }

        [Test]
        public void Verify_that_QueryIsEnumerable_returns_expected_Result()
        {
            var structuredClassifiersPackage = this.xmiReaderResult.Root.NestedPackage.Single(x => x.Name == "Classification");

            var property = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Property");

            var lower = property.QueryAllProperties().Single(x => x.Name == "lower");

            Assert.That(lower.QueryIsEnumerable(), Is.False);

            var ownedComment = property.QueryAllProperties().Single(x => x.Name == "ownedComment");

            Assert.That(ownedComment.QueryIsEnumerable(), Is.True);
        }

        [Test]
        public void Verify_that_QueryIsContainment_returns_expected_Result()
        {
            var structuredClassifiersPackage = this.xmiReaderResult.Root.NestedPackage.Single(x => x.Name == "Classification");

            var property = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Property");

            var lower = property.QueryAllProperties().Single(x => x.Name == "lower");

            Assert.That(lower.IsComposite, Is.False);

            var ownedComment = property.QueryAllProperties().Single(x => x.Name == "ownedComment");

            Assert.That(ownedComment.IsComposite, Is.True);
        }

        [Test]
        public void Verify_that_QueryTypeName_returns_expected_Result()
        {
            var structuredClassifiersPackage = this.xmiReaderResult.Root.NestedPackage.Single(x => x.Name == "Classification");

            var property = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Property");

            var lower = property.QueryAllProperties().Single(x => x.Name == "lower");

            Assert.That(lower.QueryTypeName(), Is.EqualTo("Integer"));

            var ownedComment = property.QueryAllProperties().Single(x => x.Name == "ownedComment");

            Assert.That(ownedComment.QueryTypeName(), Is.EqualTo("Comment"));
        }

        [Test]
        public void Verify_that_QueryIsReferenceProperty_returns_expected_Result()
        {
            var structuredClassifiersPackage = this.xmiReaderResult.Root.NestedPackage.Single(x => x.Name == "Classification");

            var property = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Property");

            var lower = property.QueryAllProperties().Single(x => x.Name == "lower");

            Assert.That(lower.QueryIsReferenceProperty(), Is.False);

            var ownedComment = property.QueryAllProperties().Single(x => x.Name == "ownedComment");

            Assert.That(ownedComment.QueryIsReferenceProperty(), Is.True);
        }

        [Test]
        public void Verify_that_QueryIsValueProperty_returns_expected_Result()
        {
            var structuredClassifiersPackage = this.xmiReaderResult.Root.NestedPackage.Single(x => x.Name == "Classification");

            var property = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Property");

            var lower = property.QueryAllProperties().Single(x => x.Name == "lower");

            Assert.That(lower.QueryIsValueProperty(), Is.True);

            var ownedComment = property.QueryAllProperties().Single(x => x.Name == "ownedComment");

            Assert.That(ownedComment.QueryIsValueProperty(), Is.False);
        }

        [Test]
        public void Verify_that_QueryIsNullable_returns_expected_Result()
        {
            var structuredClassifiersPackage = this.xmiReaderResult.Root.NestedPackage.Single(x => x.Name == "Classification");

            var property = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Property");

            var ownedComment = property.QueryAllProperties().Single(x => x.Name == "ownedComment");

            Assert.That(ownedComment.QueryIsNullable(), Is.False);

            var lowerValue = property.QueryAllProperties().Single(x => x.Name == "lowerValue");

            Assert.That(lowerValue.QueryIsNullable(), Is.True);
        }

        [Test]
        public void Verify_that_QueryUpperValue_returns_expected_Result()
        {
            var structuredClassifiersPackage = this.xmiReaderResult.Root.NestedPackage.Single(x => x.Name == "Classification");

            var property = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Property");

            var ownedComment = property.QueryAllProperties().Single(x => x.Name == "ownedComment");

            Assert.That(ownedComment.Upper, Is.EqualTo("*"));

            var lowerValue = property.QueryAllProperties().Single(x => x.Name == "lowerValue");

            Assert.That(lowerValue.Upper, Is.EqualTo("1"));
        }

        [Test]
        public void Verify_that_TryQueryRedefinedByProperty_returns_expected_Result()
        {
            var structuredClassifiersPackage = this.xmiReaderResult.Root.NestedPackage.Single(x => x.Name == "StructuredClassifiers");

            var association = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Association");

            var properties = association.QueryAllProperties();

            var templateParameter = properties.Single(x => x.XmiId == "ParameterableElement-templateParameter");

            var result = templateParameter.TryQueryRedefinedByProperty(association, out var redefinedByProperty);

            Assert.That(result, Is.True);

            Assert.That(redefinedByProperty.XmiId, Is.EqualTo("Classifier-templateParameter"));

            var endType = properties.Single(x => x.XmiId == "Association-endType");

            result = endType.TryQueryRedefinedByProperty(association, out redefinedByProperty);

            Assert.That(result, Is.False);

            Assert.That(redefinedByProperty, Is.Null);
        }
    }
}
