// -------------------------------------------------------------------------------------------------
//  <copyright file="PropertyExtensionsTestFixture.cs" company="Starion Group S.A.">
// 
//    Copyright (C) 2019-2026 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
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
    using Classification;
    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    using Serilog;

    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;
    using uml4net.xmi;
    using uml4net.xmi.Readers;

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
        public void Verify_that_Query_methods_Throw_exception_when_property_is_null()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => PropertyExtensions.QueryIsDataType(null), Throws.ArgumentNullException);
                Assert.That(() => PropertyExtensions.QueryIsEnum(null), Throws.ArgumentNullException);
                Assert.That(() => PropertyExtensions.QueryIsPrimitiveType(null), Throws.ArgumentNullException);
                Assert.That(() => PropertyExtensions.QueryIsBool(null), Throws.ArgumentNullException);
                Assert.That(() => PropertyExtensions.QueryIsString(null), Throws.ArgumentNullException);
                Assert.That(() => PropertyExtensions.QueryIsNumeric(null), Throws.ArgumentNullException);
                Assert.That(() => PropertyExtensions.QueryIsInteger(null), Throws.ArgumentNullException);
                Assert.That(() => PropertyExtensions.QueryIsFloat(null), Throws.ArgumentNullException);
                Assert.That(() => PropertyExtensions.QueryIsDouble(null), Throws.ArgumentNullException);
                Assert.That(() => PropertyExtensions.QueryIsDateTime(null), Throws.ArgumentNullException);
                Assert.That(() => PropertyExtensions.QueryCSharpTypeName(null), Throws.ArgumentNullException);
                Assert.That(() => PropertyExtensions.QueryIsEnumerable(null), Throws.ArgumentNullException);
                Assert.That(() => PropertyExtensions.QueryStructuralFeatureNameEqualsEnclosingType(null, null), Throws.ArgumentNullException);
                Assert.That(() => PropertyExtensions.QueryStructuralFeatureNameEqualsEnclosingType(new Property(), null), Throws.ArgumentNullException);
                Assert.That(() => PropertyExtensions.QueryHasDefaultValue(null), Throws.ArgumentNullException);
                Assert.That(() => PropertyExtensions.QueryDefaultValueAsString(null), Throws.ArgumentNullException);
                Assert.That(() => PropertyExtensions.QueryTypeName(null), Throws.ArgumentNullException);
                Assert.That(() => PropertyExtensions.QueryCSharpFullTypeName(null), Throws.ArgumentNullException);
                Assert.That(() => PropertyExtensions.QueryIsReferenceProperty(null), Throws.ArgumentNullException);
                Assert.That(() => PropertyExtensions.QueryIsTypeAbstract(null), Throws.ArgumentNullException);
                Assert.That(() => PropertyExtensions.QueryIsValueProperty(null), Throws.ArgumentNullException);
                Assert.That(() => PropertyExtensions.QueryIsNullable(null), Throws.ArgumentNullException);
            }
        }

        [Test]
        public void Verify_that_QueryIsEnum_returns_expected_Result()
        {
            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var structuredClassifiersPackage = root.NestedPackage.Single(x => x.Name == "StructuredClassifiers");

            var connector = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Connector");

            var visibility = connector.QueryAllProperties().Single(x => x.Name == "visibility");

            Assert.That(visibility.QueryIsEnum(), Is.True);

            var ownedComment = connector.QueryAllProperties().Single(x => x.Name == "ownedComment");
            
            Assert.That(ownedComment.QueryIsEnum(), Is.False);
        }

        [Test]
        public void Verify_that_QueryIsPrimitiveType_returns_expected_Result()
        {
            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var structuredClassifiersPackage = root.NestedPackage.Single(x => x.Name == "StructuredClassifiers");

            var connector = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Connector");

            var isStatic = connector.QueryAllProperties().Single(x => x.Name == "isStatic");

            Assert.That(isStatic.QueryIsPrimitiveType(), Is.True);

            var ownedComment = connector.QueryAllProperties().Single(x => x.Name == "ownedComment");

            Assert.That(ownedComment.QueryIsPrimitiveType(), Is.False);
        }

        [Test]
        public void Verify_that_QueryIsBool_returns_expected_Result()
        {
            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var structuredClassifiersPackage = root.NestedPackage.Single(x => x.Name == "StructuredClassifiers");

            var connector = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Connector");

            var isStatic = connector.QueryAllProperties().Single(x => x.Name == "isStatic");

            Assert.That(isStatic.QueryIsBool(), Is.True);

            var ownedComment = connector.QueryAllProperties().Single(x => x.Name == "ownedComment");

            Assert.That(ownedComment.QueryIsBool(), Is.False);
        }

        [Test]
        public void Verify_that_QueryIsNumeric_returns_expected_Result()
        {
            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var structuredClassifiersPackage = root.NestedPackage.Single(x => x.Name == "Classification");

            var property = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Property");

            var lower = property.QueryAllProperties().Single(x => x.Name == "lower");

            Assert.That(lower.QueryIsNumeric(), Is.True);

            var ownedComment = property.QueryAllProperties().Single(x => x.Name == "ownedComment");

            Assert.That(ownedComment.QueryIsNumeric(), Is.False);
        }

        [Test]
        public void Verify_that_QueryIsInteger_returns_expected_Result()
        {
            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var structuredClassifiersPackage = root.NestedPackage.Single(x => x.Name == "Classification");

            var property = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Property");

            var lower = property.QueryAllProperties().Single(x => x.Name == "lower");

            Assert.That(lower.QueryIsInteger(), Is.True);

            var ownedComment = property.QueryAllProperties().Single(x => x.Name == "ownedComment");

            Assert.That(ownedComment.QueryIsInteger(), Is.False);
        }

        [Test]
        public void Verify_that_QueryIsFloat_returns_expected_Result()
        {
            var @type = new DataType();

            var floatProperty = new Property
            {
                Type = @type
            };

            using (Assert.EnterMultipleScope())
            {
                @type.Name = "single";
                Assert.That(floatProperty.QueryIsFloat(), Is.True);

                @type.Name = "float";
                Assert.That(floatProperty.QueryIsFloat(), Is.True);

                @type.Name = "String";
                Assert.That(floatProperty.QueryIsFloat(), Is.False);
            }
        }

        [Test]
        public void Verify_that_QueryIsDouble_returns_expected_Result()
        {
            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var valuesPackage = root.NestedPackage.Single(x => x.Name == "Values");

            var property = valuesPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "LiteralReal");

            var value = property.QueryAllProperties().Single(x => x.Name == "value");

            Assert.That(value.QueryIsDouble(), Is.True);

            var ownedComment = property.QueryAllProperties().Single(x => x.Name == "ownedComment");

            Assert.That(ownedComment.QueryIsDouble(), Is.False);
        }

        [Test]
        public void Verify_that_QueryIsDateTime_returns_expected_Result()
        {
            var @type = new DataType();

            var floatProperty = new Property
            {
                Type = @type
            };

            using (Assert.EnterMultipleScope())
            {
                @type.Name = "date";
                Assert.That(floatProperty.QueryIsDateTime(), Is.True);

                @type.Name = "String";
                Assert.That(floatProperty.QueryIsDateTime(), Is.False);
            }
        }

        [Test]
        public void Verify_that_QueryCSharpTypeName_returns_expected_Result()
        {
            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var structuredClassifiersPackage = root.NestedPackage.Single(x => x.Name == "Classification");

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
            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var structuredClassifiersPackage = root.NestedPackage.Single(x => x.Name == "Classification");

            var property = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Property");

            var lower = property.QueryAllProperties().Single(x => x.Name == "lower");
            var dataType = property.QueryAllProperties().Single(x => x.Name == "datatype");

            //Using only default mappings
            using (Assert.EnterMultipleScope())
            {
                Assert.That(lower.QueryCSharpTypeName(), Is.EqualTo("int"));
                Assert.That(dataType.QueryCSharpTypeName(), Is.EqualTo("DataType"));
            }

            //Using new Custom Type mapping
            PropertyExtensions.AddOrOverwriteCSharpTypeMappings(("DataType", "CustomType"));

            using (Assert.EnterMultipleScope())
            {
                Assert.That(lower.QueryCSharpTypeName(), Is.EqualTo("int"));
                Assert.That(dataType.QueryCSharpTypeName(), Is.EqualTo("CustomType"));
            }

            //Using overwritten Custom Type mapping
            PropertyExtensions.AddOrOverwriteCSharpTypeMappings(("DataType", "CustomType2"));

            using (Assert.EnterMultipleScope())
            {
                Assert.That(lower.QueryCSharpTypeName(), Is.EqualTo("int"));
                Assert.That(dataType.QueryCSharpTypeName(), Is.EqualTo("CustomType2"));
            }

            //Using overwritten Default Type mapping
            PropertyExtensions.AddOrOverwriteCSharpTypeMappings(("Integer", "CustomInt"));

            using (Assert.EnterMultipleScope())
            {
                Assert.That(lower.QueryCSharpTypeName(), Is.EqualTo("CustomInt"));
                Assert.That(dataType.QueryCSharpTypeName(), Is.EqualTo("CustomType2"));
            }

            //After reset of custom mappings all should be using only default mappings again
            PropertyExtensions.ResetCSharpTypeMappingsToDefault();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(lower.QueryCSharpTypeName(), Is.EqualTo("int"));
                Assert.That(dataType.QueryCSharpTypeName(), Is.EqualTo("DataType"));
            }

            //Add multiple mappings at once
            PropertyExtensions.AddOrOverwriteCSharpTypeMappings(("DataType", "CustomType2"), ("Integer", "CustomInt"));

            using (Assert.EnterMultipleScope())
            {
                Assert.That(lower.QueryCSharpTypeName(), Is.EqualTo("CustomInt"));
                Assert.That(dataType.QueryCSharpTypeName(), Is.EqualTo("CustomType2"));
            }

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => PropertyExtensions.AddOrOverwriteCSharpTypeMappings(), Throws.TypeOf<System.ArgumentNullException>());
                Assert.That(() => PropertyExtensions.AddOrOverwriteCSharpTypeMappings((null, null)), Throws.TypeOf<System.ArgumentNullException>());
                Assert.That(() => PropertyExtensions.AddOrOverwriteCSharpTypeMappings((string.Empty, null)), Throws.TypeOf<System.ArgumentNullException>());
                Assert.That(() => PropertyExtensions.AddOrOverwriteCSharpTypeMappings((null, string.Empty)), Throws.TypeOf<System.ArgumentNullException>());
            }
        }

        [Test]
        public void Verify_that_QueryIsEnumerable_returns_expected_Result()
        {
            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var structuredClassifiersPackage = root.NestedPackage.Single(x => x.Name == "Classification");

            var property = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Property");

            var lower = property.QueryAllProperties().Single(x => x.Name == "lower");

            Assert.That(lower.QueryIsEnumerable(), Is.False);

            var ownedComment = property.QueryAllProperties().Single(x => x.Name == "ownedComment");

            Assert.That(ownedComment.QueryIsEnumerable(), Is.True);
        }

        [Test]
        public void Verify_that_QueryIsContainment_returns_expected_Result()
        {
            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var structuredClassifiersPackage = root.NestedPackage.Single(x => x.Name == "Classification");

            var property = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Property");

            var lower = property.QueryAllProperties().Single(x => x.Name == "lower");

            Assert.That(lower.IsComposite, Is.False);

            var ownedComment = property.QueryAllProperties().Single(x => x.Name == "ownedComment");

            Assert.That(ownedComment.IsComposite, Is.True);
        }

        [Test]
        public void Verify_that_QueryTypeName_returns_expected_Result()
        {
            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var structuredClassifiersPackage = root.NestedPackage.Single(x => x.Name == "Classification");

            var property = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Property");

            var lower = property.QueryAllProperties().Single(x => x.Name == "lower");

            Assert.That(lower.QueryTypeName(), Is.EqualTo("Integer"));

            var ownedComment = property.QueryAllProperties().Single(x => x.Name == "ownedComment");

            Assert.That(ownedComment.QueryTypeName(), Is.EqualTo("Comment"));
        }

        [Test]
        public void Verify_that_QueryIsReferenceProperty_returns_expected_Result()
        {
            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var structuredClassifiersPackage = root.NestedPackage.Single(x => x.Name == "Classification");

            var property = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Property");

            var lower = property.QueryAllProperties().Single(x => x.Name == "lower");

            Assert.That(lower.QueryIsReferenceProperty(), Is.False);

            var ownedComment = property.QueryAllProperties().Single(x => x.Name == "ownedComment");

            Assert.That(ownedComment.QueryIsReferenceProperty(), Is.True);
        }

        [Test]
        public void Verify_that_QueryIsSubsetted_returns_expected_result()
        {
            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var commonStructurePackage = root.NestedPackage.Single(x => x.Name == "CommonStructure");

            var @namespace = commonStructurePackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Namespace");

            var elementImport = @namespace.OwnedAttribute.Single(x => x.Name == "elementImport");

            Assert.That(elementImport.QueryIsSubsetted, Is.True);

            var member = @namespace.OwnedAttribute.Single(x => x.Name == "member");

            Assert.That(member.QueryIsSubsetted, Is.False);
        }

        [Test]
        public void Verify_that_QueryIsValueProperty_returns_expected_Result()
        {
            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var structuredClassifiersPackage = root.NestedPackage.Single(x => x.Name == "Classification");

            var property = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Property");

            var lower = property.QueryAllProperties().Single(x => x.Name == "lower");

            Assert.That(lower.QueryIsValueProperty(), Is.True);

            var ownedComment = property.QueryAllProperties().Single(x => x.Name == "ownedComment");

            Assert.That(ownedComment.QueryIsValueProperty(), Is.False);
        }

        [Test]
        public void Verify_that_QueryIsNullable_returns_expected_Result()
        {
            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var structuredClassifiersPackage = root.NestedPackage.Single(x => x.Name == "Classification");

            var property = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Property");

            var ownedComment = property.QueryAllProperties().Single(x => x.Name == "ownedComment");

            Assert.That(ownedComment.QueryIsNullable(), Is.False);

            var lowerValue = property.QueryAllProperties().Single(x => x.Name == "lowerValue");

            Assert.That(lowerValue.QueryIsNullable(), Is.True);
        }

        [Test]
        public void Verify_that_QueryIsNullableAndNotString_returns_expected_Result()
        {
            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var structuredClassifiersPackage = root.NestedPackage.Single(x => x.Name == "Classification");

            var property = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Property");

            var nameProperty = property.QueryAllProperties().Single(x => x.Name == "name");

            Assert.That(nameProperty.QueryIsNullableAndNotString(), Is.False);

            var defaultValueProperty = property.QueryAllProperties().Single(x => x.Name == "defaultValue");

            Assert.That(defaultValueProperty.QueryIsNullableAndNotString(), Is.True);
        }

        [Test]
        public void Verify_that_QueryUpperValue_returns_expected_Result()
        {
            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var structuredClassifiersPackage = root.NestedPackage.Single(x => x.Name == "Classification");

            var property = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Property");

            var ownedComment = property.QueryAllProperties().Single(x => x.Name == "ownedComment");

            Assert.That(ownedComment.Upper, Is.EqualTo("*"));

            var lowerValue = property.QueryAllProperties().Single(x => x.Name == "lowerValue");

            Assert.That(lowerValue.Upper, Is.EqualTo("1"));
        }

        [Test]
        public void Verify_that_TryQueryRedefinedByProperty_returns_expected_Result()
        {
            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var structuredClassifiersPackage = root.NestedPackage.Single(x => x.Name == "StructuredClassifiers");

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
            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var structuredClassifiersPackage = root.NestedPackage.Single(x => x.Name == "StructuredClassifiers");

            var association = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Association");

            var properties = association.QueryAllProperties();

            var templateParameter = properties.Single(x => x.XmiId == "Classifier-templateParameter");

            var result = templateParameter.QueryIsRedefinition();

            Assert.That(result, Is.True);

            var endType = properties.Single(x => x.XmiId == "Association-endType");

            result = endType.QueryIsRedefinition();

            Assert.That(result, Is.False);
        }

        [Test]
        public void Verify_that_QueryHasBeenRedefined_returns_expected_result()
        {
            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var allClasses = root.QueryPackages().SelectMany(x => x.PackagedElement.OfType<IClass>()).ToList();

            var structuredClassifiersPackage = root.NestedPackage.Single(x => x.Name == "StructuredClassifiers");

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
