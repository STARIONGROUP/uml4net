// -------------------------------------------------------------------------------------------------
// <copyright file="TypedElementExtensionsTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2019-2026 Starion Group S.A.
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

namespace uml4net.Extensions.Tests
{
    using System.IO;
    using System.Linq;

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    using Serilog;

    using uml4net.Classification;
    using uml4net.StructuredClassifiers;
    using uml4net.Values;
    using uml4net.xmi;
    using uml4net.xmi.Readers;

    [TestFixture]
    public class TypedElementExtensionsTestFixture
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
                Assert.That(() => TypedElementExtensions.QueryIsDataType(null), Throws.ArgumentNullException);
                Assert.That(() => TypedElementExtensions.QueryIsEnum(null), Throws.ArgumentNullException);
                Assert.That(() => TypedElementExtensions.QueryIsPrimitiveType(null), Throws.ArgumentNullException);
                Assert.That(() => TypedElementExtensions.QueryIsBool(null), Throws.ArgumentNullException);
                Assert.That(() => TypedElementExtensions.QueryIsString(null), Throws.ArgumentNullException);
                Assert.That(() => TypedElementExtensions.QueryIsNumeric(null), Throws.ArgumentNullException);
                Assert.That(() => TypedElementExtensions.QueryIsInteger(null), Throws.ArgumentNullException);
                Assert.That(() => TypedElementExtensions.QueryIsFloat(null), Throws.ArgumentNullException);
                Assert.That(() => TypedElementExtensions.QueryIsDouble(null), Throws.ArgumentNullException);
                Assert.That(() => TypedElementExtensions.QueryIsDateTime(null), Throws.ArgumentNullException);
                Assert.That(() => TypedElementExtensions.QueryCSharpTypeName(null), Throws.ArgumentNullException);
                Assert.That(() => TypedElementExtensions.QueryTypeName(null), Throws.ArgumentNullException);
                Assert.That(() => TypedElementExtensions.QueryIsReferenceType(null), Throws.ArgumentNullException);
                Assert.That(() => TypedElementExtensions.QueryIsTypeAbstract(null), Throws.ArgumentNullException);
                Assert.That(() => TypedElementExtensions.QueryIsValueType(null), Throws.ArgumentNullException);
            }
        }
        
        [Test]
        public void Verify_that_untyped_elements_are_typed_as_object()
        {
            // TypedElement::type is [0..1]
            var untypedProperty = new Property { Name = "untyped" };
            var untypedCompositeProperty = new Property { Name = "untypedPart", Aggregation = AggregationKind.Composite };
            var untypedParameter = new Parameter { Name = "untyped" };
            var typedProperty = new Property { Name = "typed", Type = new Class { Name = "Foo" } };

            using (Assert.EnterMultipleScope())
            {
                Assert.That(untypedProperty.QueryTypeName(), Is.Null);
                Assert.That(untypedProperty.QueryInterfaceTypeName(), Is.EqualTo("object"));
                Assert.That(untypedCompositeProperty.QueryInterfaceTypeName(), Is.EqualTo("IElement"), "the values of a composite property are owned elements");
                Assert.That(untypedParameter.QueryInterfaceTypeName(), Is.EqualTo("object"));
                Assert.That(typedProperty.QueryInterfaceTypeName(), Is.EqualTo("IFoo"));

                Assert.That(untypedProperty.QueryCSharpTypeName(), Is.EqualTo("object"));
                Assert.That(untypedProperty.QueryIsReferenceType(), Is.True);
                Assert.That(untypedProperty.QueryIsValueType(), Is.False);

                Assert.That(() => TypedElementExtensions.QueryInterfaceTypeName(null), Throws.ArgumentNullException);
            }
        }

        [Test]
        public void Verify_that_the_full_type_name_of_an_untyped_element_is_a_valid_CSharp_type()
        {
            static Property CreateProperty(string upper, bool isDerived = false, AggregationKind aggregation = AggregationKind.None)
            {
                var property = new Property { Name = "untyped", IsDerived = isDerived, Aggregation = aggregation };
                property.UpperValue.Add(new LiteralUnlimitedNatural { Value = upper });
                return property;
            }

            var untypedParameter = new Parameter { Name = "untyped" };
            var untypedParameters = new Parameter { Name = "untyped" };
            untypedParameters.UpperValue.Add(new LiteralUnlimitedNatural { Value = "*" });

            using (Assert.EnterMultipleScope())
            {
                Assert.That(CreateProperty("1").QueryCSharpFullTypeName(), Is.EqualTo("object"));
                Assert.That(CreateProperty("*").QueryCSharpFullTypeName(), Is.EqualTo("List<object> "));
                Assert.That(CreateProperty("*", isDerived: true).QueryCSharpFullTypeName(), Is.EqualTo("IReadOnlyList<object> "));
                Assert.That(CreateProperty("*", aggregation: AggregationKind.Composite).QueryCSharpFullTypeName(), Is.EqualTo("IContainerList<IElement> "));
                Assert.That(CreateProperty("*", isDerived: true, aggregation: AggregationKind.Composite).QueryCSharpFullTypeName(), Is.EqualTo("IReadOnlyList<IElement> "));

                Assert.That(untypedParameter.QueryCSharpFullTypeName(), Is.EqualTo("object"));
                Assert.That(untypedParameters.QueryCSharpFullTypeName(), Is.EqualTo("List<object> "));
            }
        }

        [Test]
        public void Verify_that_QueryIsReferenceType_returns_expected_Result()
        {
            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var structuredClassifiersPackage = root.NestedPackage.Single(x => x.Name == "Classification");

            var property = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Property");

            var lower = property.QueryAllProperties().Single(x => x.Name == "lower");

            Assert.That(lower.QueryIsReferenceType(), Is.False);

            var ownedComment = property.QueryAllProperties().Single(x => x.Name == "ownedComment");

            Assert.That(ownedComment.QueryIsReferenceType(), Is.True);
        }
        
        [Test]
        public void Verify_that_QueryIsValueProperty_returns_expected_Result()
        {
            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var structuredClassifiersPackage = root.NestedPackage.Single(x => x.Name == "Classification");

            var property = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Property");

            var lower = property.QueryAllProperties().Single(x => x.Name == "lower");

            Assert.That(lower.QueryIsValueType(), Is.True);

            var ownedComment = property.QueryAllProperties().Single(x => x.Name == "ownedComment");

            Assert.That(ownedComment.QueryIsValueType(), Is.False);
        }
    }
}
