// -------------------------------------------------------------------------------------------------
//  <copyright file="DecoratorHelperTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.HandleBars.Tests
{
    using System.Globalization;

    using HandlebarsDotNet;

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    using Serilog;

    using uml4net.Decorators;
    using uml4net.Extensions;
    using uml4net.POCO.Classification;
    using uml4net.POCO.StructuredClassifiers;
    using uml4net.xmi;
    using uml4net.xmi.Readers;

    /// <summary>
    /// Suite of tests for the <see cref="DecoratorHelper"/> class
    /// </summary>
    [TestFixture]
    public class DecoratorHelperTestFixture
    {
        private IHandlebars handlebarsContenxt;

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

            this.handlebarsContenxt = Handlebars.Create();
            this.handlebarsContenxt.Configuration.FormatProvider = CultureInfo.InvariantCulture;

            DecoratorHelper.RegisterDecoratorHelper(this.handlebarsContenxt);
        }

        [Test]
        public void Verify_that_Decorator_ImplementsAttribute_throws_exception_when_context_is_not_Property()
        {
            var template = "{{ #Decorator.WriteImplementsAttribute this }}";

            var handlebarsTemplate = this.handlebarsContenxt.Compile(template);

            var structuredClassifiersPackage =
                this.xmiReaderResult.Root.NestedPackage.Single(x => x.Name == "StructuredClassifiers");

            Assert.That(() => handlebarsTemplate(structuredClassifiersPackage), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void Verify_that_Decorator_ImplementsAttribute_returns_expected_result()
        {
            var template = "{{ #Decorator.WriteImplementsAttribute this }}";

            var handlebarsTemplate = this.handlebarsContenxt.Compile(template);

            var structuredClassifiersPackage =
                this.xmiReaderResult.Root.NestedPackage.Single(x => x.Name == "StructuredClassifiers");

            var association = structuredClassifiersPackage.PackagedElement.OfType<IClass>()
                .Single(x => x.Name == "Association");

            var ownedComment = association.QueryAllProperties().Single(x => x.Name == "ownedComment");
            var navigableOwnedEnd = association.QueryAllProperties().Single(x => x.Name == "navigableOwnedEnd");

            var ownedCommentImplementsAttribute = handlebarsTemplate(ownedComment);

            Assert.That(ownedCommentImplementsAttribute,
                Is.EqualTo("[Implements(implementation: \"IElement.OwnedComment\")]" + Environment.NewLine));

            var navigableOwnedEndAttribute = handlebarsTemplate(navigableOwnedEnd);

            Assert.That(navigableOwnedEndAttribute,
                Is.EqualTo("[Implements(implementation: \"IAssociation.NavigableOwnedEnd\")]" + Environment.NewLine));
        }

        [Test]
        public void Verify_that_Decorator_PropertyAttribute_throws_exception_when_context_is_not_Property()
        {
            var template = "{{ #Decorator.WritePropertyAttribute this }}";

            var handlebarsTemplate = this.handlebarsContenxt.Compile(template);

            var structuredClassifiersPackage =
                this.xmiReaderResult.Root.NestedPackage.Single(x => x.Name == "StructuredClassifiers");

            Assert.That(() => handlebarsTemplate(structuredClassifiersPackage), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void Verity_that_Decorator_PropertyAttribute_returns_expected_result()
        {
            var template = "{{ #Decorator.WritePropertyAttribute this }}";
            
            var handlebarsTemplate = this.handlebarsContenxt.Compile(template);

            var structuredClassifiersPackage =
                this.xmiReaderResult.Root.NestedPackage.Single(x => x.Name == "StructuredClassifiers");

            var association = structuredClassifiersPackage.PackagedElement.OfType<IClass>()
                .Single(x => x.Name == "Association");

            var ownedComment = association.QueryAllProperties().Single(x => x.Name == "ownedComment");
            var memberEnd = association.QueryAllProperties().Single(x => x.Name == "memberEnd");
            var owner = association.QueryAllProperties().Single(x => x.Name == "owner");

            var ownedCommentPropertyAttribute = handlebarsTemplate(ownedComment);

            Assert.That(ownedCommentPropertyAttribute,
                Is.EqualTo("[Property(xmiId: \"Element-ownedComment\", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]" + Environment.NewLine));

            var memberEndPropertyAttribute = handlebarsTemplate(memberEnd);

            Assert.That(memberEndPropertyAttribute,
                Is.EqualTo(
                    "[Property(xmiId: \"Association-memberEnd\", aggregation: AggregationKind.None, lowerValue: 2, upperValue: int.MaxValue, isOrdered: true, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]" + Environment.NewLine));

            var ownerPropertyAttribute = handlebarsTemplate(owner);

            Assert.That(ownerPropertyAttribute,
                Is.EqualTo(
                    "[Property(xmiId: \"Element-owner\", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]" + Environment.NewLine));
        }

        [Test]
        public void Verify_that_Decorator_RedefinedPropertyAttribute_throws_exception_when_context_is_not_Property()
        {
            var template = "{{ #Decorator.WriteRedefinedPropertyAttribute this }}";

            var handlebarsTemplate = this.handlebarsContenxt.Compile(template);

            var structuredClassifiersPackage =
                this.xmiReaderResult.Root.NestedPackage.Single(x => x.Name == "StructuredClassifiers");

            Assert.That(() => handlebarsTemplate(structuredClassifiersPackage), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void Verity_that_Decorator_RedefinedPropertyAttribute_returns_expected_result()
        {
            var template = "{{ #Decorator.WriteRedefinedPropertyAttribute this }}";

            var handlebarsTemplate = this.handlebarsContenxt.Compile(template);

            var structuredClassifiersPackage = this.xmiReaderResult.Root.NestedPackage.Single(x => x.Name == "StructuredClassifiers");

            var association = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Association");

            var templateParameter = association.QueryAllProperties().Single(x => x.XmiId == "Classifier-templateParameter");

            var templateParameterRedefinedPropertyAttribute = handlebarsTemplate(templateParameter);

            Assert.That(templateParameterRedefinedPropertyAttribute, Is.EqualTo("[RedefinedProperty(propertyName: \"ParameterableElement-templateParameter\")]" + Environment.NewLine));
        }

        [Test]
        public void Verify_that_Decorator_SubsettedPropertyAttribute_throws_exception_when_context_is_not_Property()
        {
            var template = "{{ #Decorator.WriteSubsettedPropertyAttribute this }}";

            var handlebarsTemplate = this.handlebarsContenxt.Compile(template);

            var structuredClassifiersPackage =
                this.xmiReaderResult.Root.NestedPackage.Single(x => x.Name == "StructuredClassifiers");

            Assert.That(() => handlebarsTemplate(structuredClassifiersPackage), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void Verify_that_Decorator_RedefinedByPropertyAttribute_returns_expected_result()
        {
            var template = "{{ #Decorator.WriteRedefinedByPropertyAttribute arg1 arg2 }}";

            var handlebarsTemplate = this.handlebarsContenxt.Compile(template);

            var structuredClassifiersPackage = this.xmiReaderResult.Root.NestedPackage.Single(x => x.Name == "StructuredClassifiers");

            var association = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Association");

            var templateParameter = association.QueryAllProperties().Single(x => x.XmiId == "ParameterableElement-templateParameter");

            var data = new
            {
                arg1 = templateParameter,
                arg2 = association
            };

            var redefinedByPropertyAttribute = handlebarsTemplate(data);

            Assert.That(redefinedByPropertyAttribute,
                Is.EqualTo("[RedefinedByProperty(\"IClassifier.TemplateParameter\")]"));

            var ownedTemplateSignature = association.QueryAllProperties().Single(x => x.XmiId == "TemplateableElement-ownedTemplateSignature");

            data = new
            {
                arg1 = ownedTemplateSignature,
                arg2 = association
            };

            redefinedByPropertyAttribute = handlebarsTemplate(data);

            Assert.That(redefinedByPropertyAttribute,
                Is.EqualTo("[RedefinedByProperty(\"IClassifier.OwnedTemplateSignature\")]"));

            var endType = association.QueryAllProperties().Single(x => x.XmiId == "Association-endType");

            data = new
            {
                arg1 = endType,
                arg2 = association
            };

            redefinedByPropertyAttribute = handlebarsTemplate(data);

            Assert.That(redefinedByPropertyAttribute, Is.Empty);
        }

        [Test]
        public void Verity_that_Decorator_SubsettedPropertyAttribute_returns_expected_result()
        {
            var template = "{{ #Decorator.WriteSubsettedPropertyAttribute this }}";

            var handlebarsTemplate = this.handlebarsContenxt.Compile(template);

            var structuredClassifiersPackage = this.xmiReaderResult.Root.NestedPackage.Single(x => x.Name == "StructuredClassifiers");

            var association = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Association");

            var substitution = association.QueryAllProperties().Single(x => x.Name == "substitution");

            var substitutionSubsettedPropertyAttribute = handlebarsTemplate(substitution);

            var expectedResult = "[SubsettedProperty(propertyName: \"Element-ownedElement\")]" 
                                 + Environment.NewLine + 
                                       "[SubsettedProperty(propertyName: \"NamedElement-clientDependency\")]"
                                 + Environment.NewLine; 

            Log.Logger.Debug(substitutionSubsettedPropertyAttribute);

            Assert.That(substitutionSubsettedPropertyAttribute, Is.EqualTo(expectedResult));
        }
    }
}