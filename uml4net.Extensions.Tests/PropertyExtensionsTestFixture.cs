// -------------------------------------------------------------------------------------------------
//  <copyright file="PropertyExtensionsTestFixture.cs" company="Starion Group S.A.">
// 
//    Copyright (C) 2019-2025 Starion Group S.A.
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
        public void Verify_that_QueryCSharpTypeName_returns_expected_Result_when_Custom_mappings_are_added()
        {
            var structuredClassifiersPackage = this.xmiReaderResult.Root.NestedPackage.Single(x => x.Name == "Classification");

            var property = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Property");

            var lower = property.QueryAllProperties().Single(x => x.Name == "lower");
            var dataType = property.QueryAllProperties().Single(x => x.Name == "datatype");

            //Using only default mappings
            Assert.Multiple(() =>
            {
                Assert.That(lower.QueryCSharpTypeName(), Is.EqualTo("int"));
                Assert.That(dataType.QueryCSharpTypeName(), Is.EqualTo("DataType"));
            });

            //Using new Custom Type mapping
            PropertyExtensions.AddOrOverwriteCSharpTypeMappings(("DataType", "CustomType"));

            Assert.Multiple(() =>
            {
                Assert.That(lower.QueryCSharpTypeName(), Is.EqualTo("int"));
                Assert.That(dataType.QueryCSharpTypeName(), Is.EqualTo("CustomType"));
            });

            //Using overwritten Custom Type mapping
            PropertyExtensions.AddOrOverwriteCSharpTypeMappings(("DataType", "CustomType2"));

            Assert.Multiple(() =>
            {
                Assert.That(lower.QueryCSharpTypeName(), Is.EqualTo("int"));
                Assert.That(dataType.QueryCSharpTypeName(), Is.EqualTo("CustomType2"));
            });

            //Using overwritten Default Type mapping
            PropertyExtensions.AddOrOverwriteCSharpTypeMappings(("Integer", "CustomInt"));

            Assert.Multiple(() =>
            {
                Assert.That(lower.QueryCSharpTypeName(), Is.EqualTo("CustomInt"));
                Assert.That(dataType.QueryCSharpTypeName(), Is.EqualTo("CustomType2"));
            });

            //After reset of custom mappings all should be using only default mappings again
            PropertyExtensions.ResetCSharpTypeMappingsToDefault();

            Assert.Multiple(() =>
            {
                Assert.That(lower.QueryCSharpTypeName(), Is.EqualTo("int"));
                Assert.That(dataType.QueryCSharpTypeName(), Is.EqualTo("DataType"));
            });

            //Add multiple mappings at once
            PropertyExtensions.AddOrOverwriteCSharpTypeMappings(("DataType", "CustomType2"), ("Integer", "CustomInt"));

            Assert.Multiple(() =>
            {
                Assert.That(lower.QueryCSharpTypeName(), Is.EqualTo("CustomInt"));
                Assert.That(dataType.QueryCSharpTypeName(), Is.EqualTo("CustomType2"));
            });

            Assert.That(() => PropertyExtensions.AddOrOverwriteCSharpTypeMappings(), Throws.TypeOf<System.ArgumentNullException>());
            Assert.That(() => PropertyExtensions.AddOrOverwriteCSharpTypeMappings((null, null)), Throws.TypeOf<System.ArgumentNullException>());
            Assert.That(() => PropertyExtensions.AddOrOverwriteCSharpTypeMappings((string.Empty, null)), Throws.TypeOf<System.ArgumentNullException>());
            Assert.That(() => PropertyExtensions.AddOrOverwriteCSharpTypeMappings((null, string.Empty)), Throws.TypeOf<System.ArgumentNullException>());
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
        public void Verify_that_QueryIsSubsetted_returns_expected_result()
        {
            var commonStructurePackage = this.xmiReaderResult.Root.NestedPackage.Single(x => x.Name == "CommonStructure");

            var @namespace = commonStructurePackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Namespace");

            var elementImport = @namespace.OwnedAttribute.Single(x => x.Name == "elementImport");

            Assert.That(elementImport.QueryIsSubsetted, Is.True);

            var member = @namespace.OwnedAttribute.Single(x => x.Name == "member");

            Assert.That(member.QueryIsSubsetted, Is.False);
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

        [Test]
        public void Verify_that_QueryIsRedefined_returns_expected_Result()
        {
            var structuredClassifiersPackage = this.xmiReaderResult.Root.NestedPackage.Single(x => x.Name == "StructuredClassifiers");

            var association = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Association");

            var properties = association.QueryAllProperties();

            var templateParameter = properties.Single(x => x.XmiId == "Classifier-templateParameter");

            var result = templateParameter.QueryIsRedefined();

            Assert.That(result, Is.True);

            var endType = properties.Single(x => x.XmiId == "Association-endType");

            result = endType.QueryIsRedefined();

            Assert.That(result, Is.False);
        }

        [Test]
        public void Verify_that_QueryHasBeenRedefined_returns_expected_result()
        {
            var allClasses = this.xmiReaderResult.Root.QueryPackages().SelectMany(x => x.PackagedElement.OfType<IClass>()).ToList();

            var structuredClassifiersPackage = this.xmiReaderResult.Root.NestedPackage.Single(x => x.Name == "StructuredClassifiers");

            var association = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Association");

            var properties = association.QueryAllProperties();

            var templateParameter = properties.Single(x => x.XmiId == "ParameterableElement-templateParameter");

            var result = templateParameter.QueryHasBeenRedefined(allClasses);

            Assert.That(result, Is.True);

            var endType = properties.Single(x => x.XmiId == "Association-endType");

            result = endType.QueryHasBeenRedefined(allClasses);

            Assert.That(result, Is.False);
        }
    }
}
