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
    using Microsoft.Extensions.Logging;
    using NUnit.Framework;
    using Serilog;

    using uml4net.Activities;
    using uml4net.Classification;
    using uml4net.Extensions;
    using uml4net.StructuredClassifiers;
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

            Assert.That(generatedCode, Does.Contain("if (element.Visibility != VisibilityKind.Public)"));
            Assert.That(generatedCode, Does.Contain("xmlWriter.WriteAttributeString(\"visibility\", element.Visibility.QueryXmiLiteral());"));
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

        /// </returns>
        private IClass QueryClass(string packageName, string className)
        {
            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var package = root.NestedPackage.Single(x => x.Name == packageName);

            return package.PackagedElement.OfType<IClass>().Single(x => x.Name == className);
        }
    }
}
