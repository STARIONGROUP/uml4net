// -------------------------------------------------------------------------------------------------
// <copyright file="PropertyHelperTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.HandleBars.Tests
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    using CommonStructure;
    using HandlebarsDotNet;
    using HandlebarsDotNet.Helpers;
    using Microsoft.Extensions.Logging;
    using NUnit.Framework;
    using Serilog;

    using uml4net.Activities;
    using uml4net.Classification;
    using uml4net.Extensions;
    using uml4net.StructuredClassifiers;
    using uml4net.Values;
    using uml4net.xmi;
    using uml4net.xmi.Readers;

    /// <summary>
    /// Suite of tests for the <see cref="DecoratorHelper"/> class
    /// </summary>
    [TestFixture]
    public class PropertyHelperTestFixture
    {
        private IHandlebars handlebarsContext;

        private ILoggerFactory loggerFactory;

        private XmiReaderResult xmiReaderResult;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console()
                .CreateLogger();

            this.loggerFactory = LoggerFactory.Create(builder => { builder.AddSerilog(); });
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

            this.handlebarsContext = Handlebars.Create();
            this.handlebarsContext.Configuration.FormatProvider = CultureInfo.InvariantCulture;

            PropertyHelper.RegisterPropertyHelper(this.handlebarsContext);
        }

        [Test]
        public void Verify_that_property_is_written_as_expected_for_interface()
        {
            var template = "{{ #Property.WriteForInterface this }}";

            var handlebarsTemplate = this.handlebarsContext.Compile(template);

            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var activitiesPackage = root.NestedPackage.Single(x => x.Name == "Activities");

            var activity = activitiesPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Activity");

            var activityEdge = activity.OwnedAttribute.OfType<IProperty>().Single(x => x.XmiId == "Activity-edge");

            var activityEdgeProperty = handlebarsTemplate(activityEdge);

            Assert.That(activityEdgeProperty, Is.EqualTo("public IContainerList<IActivityEdge> Edge { get; set; }" + Environment.NewLine));

            Assert.That(() => handlebarsTemplate(new Dependency()), Throws.ArgumentException);
        }

        [Test]
        public void Verify_that_derived_composite_property_is_written_as_IReadOnlyList_for_interface()
        {
            var template = "{{ #Property.WriteForInterface this }}";

            var handlebarsTemplate = this.handlebarsContext.Compile(template);

            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            IProperty Find(string packageName, string className, string propertyName) =>
                root.NestedPackage.Single(x => x.Name == packageName).PackagedElement.OfType<IClass>().Single(x => x.Name == className)
                    .OwnedAttribute.Single(x => x.Name == propertyName);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(handlebarsTemplate(Find("CommonStructure", "Element", "ownedElement")), Is.EqualTo("public IReadOnlyList<IElement> OwnedElement { get; }" + Environment.NewLine));
                Assert.That(handlebarsTemplate(Find("Activities", "ActivityGroup", "subgroup")), Is.EqualTo("public IReadOnlyList<IActivityGroup> Subgroup { get; }" + Environment.NewLine));
                Assert.That(handlebarsTemplate(Find("Packages", "Package", "ownedType")), Is.EqualTo("public IReadOnlyList<IType> OwnedType { get; }" + Environment.NewLine));
            }
        }

        [Test]
        public void Verify_that_QueryHasDefaultValue_helper_returns_whether_a_default_value_is_specified()
        {
            // a helper used as a sub-expression needs the HandlebarsDotNet.Helpers registration, as in the generator
            var context = Handlebars.Create();
            HandlebarsHelpers.Register(context);
            PropertyHelper.RegisterPropertyHelper(context);

            var template = "{{#if (Property.QueryHasDefaultValue this)}}default{{else}}none{{/if}}";

            var handlebarsTemplate = context.Compile(template);

            var propertyWithDefault = new Property();
            propertyWithDefault.DefaultValue.Add(new LiteralBoolean { Value = true });

            using (Assert.EnterMultipleScope())
            {
                Assert.That(handlebarsTemplate(propertyWithDefault), Is.EqualTo("default"));
                Assert.That(handlebarsTemplate(new Property()), Is.EqualTo("none"));
                Assert.That(() => context.Compile("{{#if (Property.QueryHasDefaultValue this this)}}{{/if}}")(new Property()), Throws.InstanceOf<HandlebarsException>());
            }
        }

        [Test]
        public void Verify_that_untyped_property_is_written_as_object_for_interface()
        {
            var template = "{{ #Property.WriteForInterface this }}";

            var handlebarsTemplate = this.handlebarsContext.Compile(template);

            var untyped = new Property { Name = "untyped" };

            var untypedParts = new Property { Name = "untypedPart", Aggregation = AggregationKind.Composite };
            untypedParts.UpperValue.Add(new LiteralUnlimitedNatural { Value = "*" });

            var owner = new Class { Name = "Owner" };
            owner.OwnedAttribute.Add(untyped);
            owner.OwnedAttribute.Add(untypedParts);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(handlebarsTemplate(untyped), Is.EqualTo("public object Untyped { get; set; }" + Environment.NewLine));
                Assert.That(handlebarsTemplate(untypedParts), Is.EqualTo("public IContainerList<IElement> UntypedPart { get; set; }" + Environment.NewLine));
            }
        }

        [Test]
        public void Verify_that_WriteXmlAttributeForXmiWriter_writes_bool_property_as_expected()
        {
            var template = "{{ #Property.WriteXmlAttributeForXmiWriter this.Property this.Class }}";

            var handlebarsTemplate = this.handlebarsContext.Compile(template);

            var @class = this.QueryClass("StructuredClassifiers", "Class");

            var isAbstract = @class.QueryAllProperties().Single(x => x.XmiId == "Class-isAbstract");

            var generatedCode = handlebarsTemplate(new { Property = isAbstract, Class = @class });

            Assert.That(generatedCode, Does.Contain("if (element.IsAbstract)"));
            Assert.That(generatedCode, Does.Contain("xmlWriter.WriteAttributeString(\"isAbstract\", XmlConvert.ToString(element.IsAbstract));"));
        }

        [Test]
        public void Verify_that_WriteXmlAttributeForXmiWriter_writes_string_property_as_expected()
        {
            var template = "{{ #Property.WriteXmlAttributeForXmiWriter this.Property this.Class }}";

            var handlebarsTemplate = this.handlebarsContext.Compile(template);

            var @class = this.QueryClass("StructuredClassifiers", "Class");

            var name = @class.QueryAllProperties().Single(x => x.XmiId == "NamedElement-name");

            var generatedCode = handlebarsTemplate(new { Property = name, Class = @class });

            Assert.That(generatedCode, Does.Contain("if (!string.IsNullOrEmpty(element.Name))"));
            Assert.That(generatedCode, Does.Contain("xmlWriter.WriteAttributeString(\"name\", element.Name);"));
        }

        [Test]
        public void Verify_that_WriteXmlAttributeForXmiWriter_writes_enum_property_with_default_as_expected()
        {
            var template = "{{ #Property.WriteXmlAttributeForXmiWriter this.Property this.Class }}";

            var handlebarsTemplate = this.handlebarsContext.Compile(template);

            var @class = this.QueryClass("StructuredClassifiers", "Class");

            var visibility = @class.QueryAllProperties().Single(x => x.XmiId == "PackageableElement-visibility");

            var generatedCode = handlebarsTemplate(new { Property = visibility, Class = @class });

            Assert.That(generatedCode, Does.Contain("if (element.Visibility.HasValue && element.Visibility.Value != VisibilityKind.Public)"), "PackageableElement::visibility [0..1] has the metamodel default public");
            Assert.That(generatedCode, Does.Contain("xmlWriter.WriteAttributeString(\"visibility\", element.Visibility.Value.QueryXmiLiteral());"));
        }

        [Test]
        public void Verify_that_WriteXmlAttributeForXmiWriter_always_writes_a_mandatory_value_without_metamodel_default()
        {
            var syncTemplate = this.handlebarsContext.Compile("{{ #Property.WriteXmlAttributeForXmiWriter this.Property this.Class }}");
            var asyncTemplate = this.handlebarsContext.Compile("{{ #Property.WriteXmlAttributeForXmiWriter this.Property this.Class true }}");

            var metaclass = this.QueryClass("StructuredClassifiers", "Class");
            var booleanType = metaclass.QueryAllProperties().Single(x => x.XmiId == "Class-isAbstract").Type;
            var visibilityKind = metaclass.QueryAllProperties().Single(x => x.XmiId == "NamedElement-visibility").Type;
            var realType = this.QueryClass("Values", "LiteralReal").QueryAllProperties().Single(x => x.XmiId == "LiteralReal-value").Type;

            // [1..1] properties without a defaultValue: the C# default of their type is a value of the model
            var owner = new Class { Name = "Sample" };

            Property CreateMandatoryProperty(string name, IType type)
            {
                var property = new Property { Name = name, Type = type };
                property.LowerValue.Add(new LiteralInteger { Value = 1 });
                property.UpperValue.Add(new LiteralUnlimitedNatural { Value = "1" });
                owner.OwnedAttribute.Add(property);
                return property;
            }

            var flag = CreateMandatoryProperty("flag", booleanType);
            var kind = CreateMandatoryProperty("kind", visibilityKind);
            var amount = CreateMandatoryProperty("amount", realType);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(syncTemplate(new { Property = flag, Class = owner }).Trim(), Is.EqualTo("xmlWriter.WriteAttributeString(\"flag\", XmlConvert.ToString(element.Flag));"));
                Assert.That(asyncTemplate(new { Property = flag, Class = owner }).Trim(), Is.EqualTo("await xmlWriter.WriteAttributeStringAsync(null, \"flag\", null, XmlConvert.ToString(element.Flag));"));
                Assert.That(syncTemplate(new { Property = kind, Class = owner }).Trim(), Is.EqualTo("xmlWriter.WriteAttributeString(\"kind\", element.Kind.QueryXmiLiteral());"));
                Assert.That(asyncTemplate(new { Property = kind, Class = owner }).Trim(), Is.EqualTo("await xmlWriter.WriteAttributeStringAsync(null, \"kind\", null, element.Kind.QueryXmiLiteral());"));
                Assert.That(syncTemplate(new { Property = amount, Class = owner }).Trim(), Is.EqualTo("xmlWriter.WriteAttributeString(\"amount\", XmlConvert.ToString(element.Amount));"));
            }
        }

        [Test]
        public void Verify_that_WriteXmlAttributeForXmiWriter_skips_redefined_and_composite_properties()
        {
            var template = "{{ #Property.WriteXmlAttributeForXmiWriter this.Property this.Class }}";

            var handlebarsTemplate = this.handlebarsContext.Compile(template);

            var @class = this.QueryClass("StructuredClassifiers", "Class");

            var redefinedVisibility = @class.QueryAllProperties().Single(x => x.XmiId == "NamedElement-visibility");

            Assert.That(handlebarsTemplate(new { Property = redefinedVisibility, Class = @class }), Is.Empty);

            var ownedAttribute = @class.QueryAllProperties().Single(x => x.XmiId == "StructuredClassifier-ownedAttribute");

            Assert.That(handlebarsTemplate(new { Property = ownedAttribute, Class = @class }), Is.Empty);
        }

        [Test]
        public void Verify_that_WriteXmlAttributeForXmiWriter_writes_single_valued_reference_as_expected()
        {
            var template = "{{ #Property.WriteXmlAttributeForXmiWriter this.Property this.Class }}";

            var handlebarsTemplate = this.handlebarsContext.Compile(template);

            var @class = this.QueryClass("Classification", "Property");

            var type = @class.QueryAllProperties().Single(x => x.XmiId == "TypedElement-type");

            var generatedCode = handlebarsTemplate(new { Property = type, Class = @class });

            Assert.That(generatedCode, Does.Contain("if (element.Type != null && writeContext.IsLocal(element.Type))"));
            Assert.That(generatedCode, Does.Contain("xmlWriter.WriteAttributeString(\"type\", element.Type.XmiId);"));
        }

        [Test]
        public void Verify_that_WriteXmlAttributeForXmiWriter_writes_async_variant_as_expected()
        {
            var template = "{{ #Property.WriteXmlAttributeForXmiWriter this.Property this.Class true }}";

            var handlebarsTemplate = this.handlebarsContext.Compile(template);

            var @class = this.QueryClass("StructuredClassifiers", "Class");

            var name = @class.QueryAllProperties().Single(x => x.XmiId == "NamedElement-name");

            var generatedCode = handlebarsTemplate(new { Property = name, Class = @class });

            Assert.That(generatedCode, Does.Contain("await xmlWriter.WriteAttributeStringAsync(null, \"name\", null, element.Name);"));
        }

        [Test]
        public void Verify_that_WriteXmlElementForXmiWriter_writes_contained_property_as_expected()
        {
            var template = "{{ #Property.WriteXmlElementForXmiWriter this.Property this.Class }}";

            var handlebarsTemplate = this.handlebarsContext.Compile(template);

            var @class = this.QueryClass("StructuredClassifiers", "Class");

            var ownedComment = @class.QueryAllProperties().Single(x => x.XmiId == "Element-ownedComment");

            var generatedCode = handlebarsTemplate(new { Property = ownedComment, Class = @class });

            Assert.That(generatedCode, Does.Contain("foreach (var value in element.OwnedComment)"));
            Assert.That(generatedCode, Does.Contain("this.XmiElementWriterFacade.WriteContainedElement(xmlWriter, value, \"ownedComment\", writeContext);"));
        }

        [Test]
        public void Verify_that_WriteXmlElementForXmiWriter_writes_composite_with_non_derived_subsets_as_reference()
        {
            var template = "{{ #Property.WriteXmlElementForXmiWriter this.Property this.Class }}";

            var handlebarsTemplate = this.handlebarsContext.Compile(template);

            var @class = this.QueryClass("Activities", "Activity");

            var postcondition = @class.QueryAllProperties().Single(x => x.XmiId == "Behavior-postcondition");

            var generatedCode = handlebarsTemplate(new { Property = postcondition, Class = @class });

            Assert.That(generatedCode, Does.Contain("foreach (var value in element.Postcondition)"));
            Assert.That(generatedCode, Does.Contain("this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, value, \"postcondition\", writeContext);"));
        }

        [Test]
        public void Verify_that_WriteXmlElementForXmiWriter_writes_multi_valued_reference_as_expected()
        {
            var template = "{{ #Property.WriteXmlElementForXmiWriter this.Property this.Class }}";

            var handlebarsTemplate = this.handlebarsContext.Compile(template);

            var @class = this.QueryClass("StructuredClassifiers", "Association");

            var navigableOwnedEnd = @class.QueryAllProperties().Single(x => x.XmiId == "Association-navigableOwnedEnd");

            var generatedCode = handlebarsTemplate(new { Property = navigableOwnedEnd, Class = @class });

            Assert.That(generatedCode, Does.Contain("foreach (var value in element.NavigableOwnedEnd)"));
            Assert.That(generatedCode, Does.Contain("this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, value, \"navigableOwnedEnd\", writeContext);"));
        }

        [Test]
        public void Verify_that_WriteXmlElementForXmiWriter_writes_single_valued_reference_href_fallback_as_expected()
        {
            var template = "{{ #Property.WriteXmlElementForXmiWriter this.Property this.Class }}";

            var handlebarsTemplate = this.handlebarsContext.Compile(template);

            var @class = this.QueryClass("Classification", "Property");

            var type = @class.QueryAllProperties().Single(x => x.XmiId == "TypedElement-type");

            var generatedCode = handlebarsTemplate(new { Property = type, Class = @class });

            Assert.That(generatedCode, Does.Contain("if (element.Type != null && !writeContext.IsLocal(element.Type))"));
            Assert.That(generatedCode, Does.Contain("this.XmiElementWriterFacade.WriteReferenceElement(xmlWriter, element.Type, \"type\", writeContext);"));
        }

        [Test]
        public void Verify_that_WriteXmlElementForXmiWriter_skips_scalar_primitives_and_enums()
        {
            var template = "{{ #Property.WriteXmlElementForXmiWriter this.Property this.Class }}";

            var handlebarsTemplate = this.handlebarsContext.Compile(template);

            var @class = this.QueryClass("StructuredClassifiers", "Class");

            var name = @class.QueryAllProperties().Single(x => x.XmiId == "NamedElement-name");

            Assert.That(handlebarsTemplate(new { Property = name, Class = @class }), Is.Empty);

            var visibility = @class.QueryAllProperties().Single(x => x.XmiId == "PackageableElement-visibility");

            Assert.That(handlebarsTemplate(new { Property = visibility, Class = @class }), Is.Empty);
        }

        [Test]
        public void Verify_that_WriteXmlElementForXmiWriter_writes_async_variant_as_expected()
        {
            var template = "{{ #Property.WriteXmlElementForXmiWriter this.Property this.Class true }}";

            var handlebarsTemplate = this.handlebarsContext.Compile(template);

            var @class = this.QueryClass("StructuredClassifiers", "Class");

            var ownedComment = @class.QueryAllProperties().Single(x => x.XmiId == "Element-ownedComment");

            var generatedCode = handlebarsTemplate(new { Property = ownedComment, Class = @class });

            Assert.That(generatedCode, Does.Contain("await this.XmiElementWriterFacade.WriteContainedElementAsync(xmlWriter, value, \"ownedComment\", writeContext);"));
        }

        /// <summary>
        /// Queries a <see cref="IClass"/> from the UML metamodel that is used as test input
        /// </summary>
        /// <param name="packageName">
        /// The name of the package that contains the <see cref="IClass"/>
        /// </param>
        /// <param name="className">
        /// The name of the <see cref="IClass"/>
        /// </param>
        /// <returns>
        /// the queried <see cref="IClass"/>

        [Test]
        public void Verify_that_WriteForClass_keeps_the_owner_end_of_a_composite_property_in_sync()
        {
            var handlebarsTemplate = this.handlebarsContext.Compile("{{ #Property.WriteForClass this.Property this.Class }}");

            var @class = this.QueryClass("StructuredClassifiers", "Class");
            var generalization = @class.QueryAllProperties().Single(x => x.XmiId == "Classifier-generalization");

            var generatedCode = handlebarsTemplate(new { Property = generalization, Class = @class });

            using (Assert.EnterMultipleScope())
            {
                Assert.That(generatedCode, Does.Contain("new ContainerList<IGeneralization>(this,"));
                Assert.That(generatedCode, Does.Contain("containedElement => { containedElement.Specific = this; },"));
                Assert.That(generatedCode, Does.Contain("containedElement => { if (ReferenceEquals(containedElement.Specific, this)) { containedElement.Specific = null; } });"));
            }

            var ownedComment = @class.QueryAllProperties().Single(x => x.XmiId == "Element-ownedComment");

            Assert.That(handlebarsTemplate(new { Property = ownedComment, Class = @class }), Does.Contain("new ContainerList<IComment>(this);"), "the opposite of ownedComment is owned by the association, there is no owner end to maintain");
        }

        [Test]
        public void Verify_that_WriteForClass_bounds_the_ContainerList_of_a_single_valued_composite_property()
        {
            var handlebarsTemplate = this.handlebarsContext.Compile("{{ #Property.WriteForClass this.Property this.Class }}");

            var constraint = this.QueryClass("CommonStructure", "Constraint");
            var specification = constraint.QueryAllProperties().Single(x => x.XmiId == "Constraint-specification");

            var @class = this.QueryClass("StructuredClassifiers", "Class");
            var ownedTemplateSignature = @class.QueryAllProperties().Single(x => x.XmiId == "Classifier-ownedTemplateSignature");

            var generatedOwnedTemplateSignature = handlebarsTemplate(new { Property = ownedTemplateSignature, Class = @class });

            using (Assert.EnterMultipleScope())
            {
                Assert.That(handlebarsTemplate(new { Property = specification, Class = constraint }), Does.Contain("new ContainerList<IValueSpecification>(this, \"Constraint::specification\", 1);"));
                Assert.That(generatedOwnedTemplateSignature, Does.Contain("new ContainerList<IRedefinableTemplateSignature>(this, \"Classifier::ownedTemplateSignature\", 1,"));
                Assert.That(generatedOwnedTemplateSignature, Does.Contain("containedElement => { containedElement.Classifier = this; },"));
            }
        }

        [Test]
        public void Verify_that_WriteXmlElementForXmiReader_keeps_the_first_value_of_a_single_valued_composite_property()
        {
            var handlebarsTemplate = this.handlebarsContext.Compile("{{ #Property.WriteXmlElementForXmiReader this.Property this.Class }}");

            var constraint = this.QueryClass("CommonStructure", "Constraint");
            var specification = constraint.QueryAllProperties().Single(x => x.XmiId == "Constraint-specification");
            var ownedComment = constraint.QueryAllProperties().Single(x => x.XmiId == "Element-ownedComment");

            var generatedSpecification = handlebarsTemplate(new { Property = specification, Class = constraint });
            var generatedOwnedComment = handlebarsTemplate(new { Property = ownedComment, Class = constraint });

            using (Assert.EnterMultipleScope())
            {
                Assert.That(generatedSpecification, Does.Contain("if (poco.Specification.Count == 0)"));
                Assert.That(generatedSpecification, Does.Contain("this.ReportXmiError(xmlReader, poco, \"specification\", $\"The single-valued composite property is given more than once, [{poco.Specification[0].XmiId}] is kept and [{specificationValue?.XmiId}] is ignored\");"));
                Assert.That(generatedOwnedComment, Does.Contain("poco.OwnedComment.Add(ownedCommentValue);"));
                Assert.That(generatedOwnedComment, Does.Not.Contain("ReportXmiError"), "a multi-valued composite property is not bounded");
            }
        }

        [Test]
        public void Verify_that_WriteForClass_sets_the_owner_ends_of_derived_composite_subsets_by_type()
        {
            var handlebarsTemplate = this.handlebarsContext.Compile("{{ #Property.WriteForClass this.Property this.Class }}");

            var @class = this.QueryClass("Packages", "Package");
            var packagedElement = @class.QueryAllProperties().Single(x => x.XmiId == "Package-packagedElement");

            var generatedCode = handlebarsTemplate(new { Property = packagedElement, Class = @class });

            using (Assert.EnterMultipleScope())
            {
                Assert.That(generatedCode, Does.Contain("if (containedElement is IPackage nestedPackageElement) { nestedPackageElement.NestingPackage = this; }"));
                Assert.That(generatedCode, Does.Contain("if (containedElement is IType ownedTypeElement) { ownedTypeElement.Package = this; }"));
                Assert.That(generatedCode, Does.Contain("if (containedElement is IType ownedTypeElement && ReferenceEquals(ownedTypeElement.Package, this)) { ownedTypeElement.Package = null; }"));
            }
        }

        [Test]
        public void Verify_that_the_XmiWriter_helpers_do_not_write_the_owner_end_of_a_composite_association()
        {
            var @class = this.QueryClass("Classification", "Generalization");
            var specific = @class.QueryAllProperties().Single(x => x.XmiId == "Generalization-specific");

            var attributeTemplate = this.handlebarsContext.Compile("{{ #Property.WriteXmlAttributeForXmiWriter this.Property this.Class }}");
            var elementTemplate = this.handlebarsContext.Compile("{{ #Property.WriteXmlElementForXmiWriter this.Property this.Class }}");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(attributeTemplate(new { Property = specific, Class = @class }), Is.Empty, "implied by the nesting of the XML elements");
                Assert.That(elementTemplate(new { Property = specific, Class = @class }), Is.Empty);
            }
        }


        [Test]
        public void Verify_that_an_optional_value_typed_property_is_generated_as_a_nullable_type_and_written_when_set()
        {
            var @class = this.QueryClass("Classification", "Parameter");
            var effect = @class.QueryAllProperties().Single(x => x.XmiId == "Parameter-effect");

            var interfaceTemplate = this.handlebarsContext.Compile("{{ #Property.WriteForInterface this }}");
            var classTemplate = this.handlebarsContext.Compile("{{ #Property.WriteForClass this.Property this.Class }}");
            var writerTemplate = this.handlebarsContext.Compile("{{ #Property.WriteXmlAttributeForXmiWriter this.Property this.Class }}");

            var generalization = this.QueryClass("Classification", "Generalization");
            var isSubstitutable = generalization.QueryAllProperties().Single(x => x.XmiId == "Generalization-isSubstitutable");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(interfaceTemplate(effect), Does.Contain("public ParameterEffectKind? Effect { get; set; }"));
                Assert.That(classTemplate(new { Property = effect, Class = @class }), Does.Match(@"public ParameterEffectKind\?\s+Effect \{ get; set; \}"));
                Assert.That(writerTemplate(new { Property = effect, Class = @class }), Does.Contain("if (element.Effect.HasValue)"), "no metamodel default: every value that is set is written, including create");
                Assert.That(writerTemplate(new { Property = effect, Class = @class }), Does.Contain("element.Effect.Value.QueryXmiLiteral()"));

                Assert.That(classTemplate(new { Property = isSubstitutable, Class = generalization }), Does.Match(@"public bool\?\s+IsSubstitutable \{ get; set; \} = true;"), "the metamodel default is the initial value");
                Assert.That(writerTemplate(new { Property = isSubstitutable, Class = generalization }), Does.Contain("if (element.IsSubstitutable.HasValue && element.IsSubstitutable.Value != true)"));
            }
        }

        /// </returns>
        private IClass QueryClass(string packageName, string className)
        {
            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var package = root.NestedPackage.Single(x => x.Name == packageName);

            return package.PackagedElement.OfType<IClass>().Single(x => x.Name == className);
        }
    }
}
