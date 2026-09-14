// -------------------------------------------------------------------------------------------------
// <copyright file="ClassHelperTestFixture.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using Classification;
    using CommonStructure;
    using HandlebarsDotNet;

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    using Serilog;

    using uml4net.Extensions;
    using uml4net.StructuredClassifiers;
    using uml4net.xmi;
    using uml4net.xmi.Readers;

    /// <summary>
    /// Suite of tests for the <see cref="ClassHelper"/> class
    /// </summary>
    [TestFixture]
    public class ClassHelperTestFixture
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

            ClassHelper.RegisterClassHelper(this.handlebarsContext);
        }

        [Test]
        public void Verify_that_QueryOwnedAttributeOrdered_returns_expected_order()
        {
            var template = "{{#each (#Class.QueryOwnedAttributeOrdered this) as | property |}}{{ property.Name }};{{/each}}";

            var action = this.handlebarsContext.Compile(template);

            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var activitiesPackage = root.NestedPackage.Single(x => x.Name == "Activities");
            var activity = activitiesPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Activity");

            var result = action(activity);

            Assert.That(result, Is.EqualTo("edge;group;isReadOnly;isSingleExecution;node;partition;structuredNode;variable;"));

            Assert.That(() => action(new Dependency()), Throws.ArgumentException);
        }

        [Test]
        public void Verify_that_QueryOwnedAttributeOrdered_throws_when_not_provided_with_class()
        {
            var template = "{{#each (#Class.QueryOwnedAttributeOrdered this) as | property |}}{{ property.Name }};{{/each}}";

            var action = this.handlebarsContext.Compile(template);

            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var activitiesPackage = root.NestedPackage.Single(x => x.Name == "Activities");
            var activity = activitiesPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Activity");
            var property = activity.OwnedAttribute.First();

            Assert.That(() => action(property), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void Verify_that_QueryAllOperations_returns_expected_result()
        {
            var template = "{{#each (#Class.QueryAllOperations this) as | operation |}}{{ operation.Name }};{{/each}}";

            var action = this.handlebarsContext.Compile(template);

            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var commonStructurePackage = root.NestedPackage.Single(x => x.Name == "CommonStructure");
            var dependency = commonStructurePackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Dependency");

            var expected = string.Concat(dependency.QueryAllOperations().Select(x => $"{x.Name};"));

            var result = action(dependency);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(expected, Is.Not.Empty);
                Assert.That(result, Is.EqualTo(expected));
            }

            Assert.That(() => action(new Dependency()), Throws.ArgumentException);
        }

        [Test]
        public void Verify_that_QueryAllProperties_returns_expected_result()
        {
            var template = "{{#each (#Class.QueryAllProperties this) as | property |}}{{ property.Name }};{{/each}}";

            var action = this.handlebarsContext.Compile(template);

            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var activitiesPackage = root.NestedPackage.Single(x => x.Name == "Activities");
            var activity = activitiesPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Activity");

            var result = action(activity);

            Assert.That(result, Is.EqualTo("attribute;classifierBehavior;clientDependency;collaborationUse;context;edge;elementImport;extension;feature;general;generalization;group;importedMember;inheritedMember;interfaceRealization;isAbstract;isAbstract;isActive;isFinalSpecialization;isLeaf;isReadOnly;isReentrant;isSingleExecution;member;name;nameExpression;namespace;nestedClassifier;node;ownedAttribute;ownedAttribute;ownedBehavior;ownedComment;ownedConnector;ownedElement;ownedMember;ownedOperation;ownedParameter;ownedParameterSet;ownedPort;ownedReception;ownedRule;ownedTemplateSignature;ownedTemplateSignature;ownedUseCase;owner;owningTemplateParameter;package;packageImport;part;partition;postcondition;powertypeExtent;precondition;qualifiedName;redefinedBehavior;redefinedClassifier;redefinedElement;redefinitionContext;representation;role;specification;structuredNode;substitution;superClass;templateBinding;templateParameter;templateParameter;useCase;variable;visibility;visibility;"));

            Assert.That(() => action(new Dependency()), Throws.ArgumentException);
        }

        [Test]
        public void Verify_that_QueryAllContainedProperties_returns_expected_result()
        {
            var template = "{{#each (#Class.QueryAllContainedProperties this) as | property |}}{{ property.Name }};{{/each}}";

            var action = this.handlebarsContext.Compile(template);

            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var activitiesPackage = root.NestedPackage.Single(x => x.Name == "Activities");
            var activity = activitiesPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Activity");

            var result = action(activity);

            Assert.That(result, Is.EqualTo("collaborationUse;edge;elementImport;generalization;group;interfaceRealization;nameExpression;nestedClassifier;node;ownedAttribute;ownedAttribute;ownedBehavior;ownedComment;ownedConnector;ownedElement;ownedMember;ownedOperation;ownedParameter;ownedParameterSet;ownedPort;ownedReception;ownedRule;ownedTemplateSignature;ownedTemplateSignature;ownedUseCase;packageImport;postcondition;precondition;structuredNode;substitution;templateBinding;variable;"));

            Assert.That(() => action(new Dependency()), Throws.ArgumentException);
        }

        [Test]
        public void Verify_that_QueryAllNonDerivedNonReadOnlyNonContainedReferenceEnumerableProperties_returns_expected_result()
        {
            var template = "{{#each (#Class.QueryAllNonDerivedNonReadOnlyNonContainedReferenceEnumerableProperties this) as | property |}}{{ property.Name }};{{/each}}";

            var action = this.handlebarsContext.Compile(template);

            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var commonBehaviorPackage = root.NestedPackage.Single(x => x.Name == "CommonBehavior");
            var behavior = commonBehaviorPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Behavior");

            var result = action(behavior);

            Assert.That(result, Is.EqualTo("powertypeExtent;redefinedBehavior;redefinedClassifier;useCase;"));

            Assert.That(() => action(new Dependency()), Throws.ArgumentException);
        }

        [Test]
        public void Verify_that_QueryAllSpecializations_returns_expected_result()
        {
            var template = "{{#each (#Class.QueryAllSpecializations this) as | cls |}}{{ cls.Name }};{{/each}}";

            var action = this.handlebarsContext.Compile(template);

            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var commonBehaviorPackage = root.NestedPackage.Single(x => x.Name == "CommonBehavior");
            var behavior = commonBehaviorPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Behavior");

            var result = action(behavior);

            Assert.That(result, Does.Contain("Activity;"));

            Assert.That(() => action(new Dependency()), Throws.ArgumentException);
        }

        [Test]
        public void Verify_that_RenderInheritanceDiagram_renders_svg_when_diagram_exists()
        {
            var template = "{{#Class.RenderInheritanceDiagram class diagrams}}<div>{{{this}}}</div>{{/Class.RenderInheritanceDiagram}}";

            var action = this.handlebarsContext.Compile(template);

            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var activitiesPackage = root.NestedPackage.Single(x => x.Name == "Activities");
            var activity = activitiesPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Activity");

            var diagrams = new Dictionary<string, string>
            {
                [activity.XmiId] = "<svg>test-diagram</svg>"
            };

            var result = action(new { @class = activity, diagrams });

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result, Does.Contain("<svg>test-diagram</svg>"));
                Assert.That(result, Does.Contain("<div>"));
            }
        }

        [Test]
        public void Verify_that_RenderInheritanceDiagram_renders_nothing_when_diagram_does_not_exist()
        {
            var template = "before{{#Class.RenderInheritanceDiagram class diagrams}}<div>{{{this}}}</div>{{/Class.RenderInheritanceDiagram}}after";

            var action = this.handlebarsContext.Compile(template);

            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var activitiesPackage = root.NestedPackage.Single(x => x.Name == "Activities");
            var activity = activitiesPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Activity");

            var diagrams = new Dictionary<string, string>();

            var result = action(new { @class = activity, diagrams });

            Assert.That(result, Is.EqualTo("beforeafter"));
        }

        [Test]
        public void Verify_that_RenderInheritanceDiagram_renders_nothing_when_arguments_are_insufficient()
        {
            var template = "before{{#Class.RenderInheritanceDiagram class}}<div>{{{this}}}</div>{{/Class.RenderInheritanceDiagram}}after";

            var action = this.handlebarsContext.Compile(template);

            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var activitiesPackage = root.NestedPackage.Single(x => x.Name == "Activities");
            var activity = activitiesPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Activity");

            var result = action(new { @class = activity });

            Assert.That(result, Is.EqualTo("beforeafter"));
        }

        [Test]
        public void Verify_that_WriteDerivedPropertyCasesForXmiReader_writes_a_case_per_derived_property_that_skips_the_element()
        {
            var template = "{{#Class.WriteDerivedPropertyCasesForXmiReader this}}";

            var action = this.handlebarsContext.Compile(template);

            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var structuredClassifiersPackage = root.NestedPackage.Single(x => x.Name == "StructuredClassifiers");
            var @class = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Class");

            var result = action(@class);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result, Does.Contain("case (KnowNamespacePrefixes.Uml, \"qualifiedName\"):"), "derived property");
                Assert.That(result, Does.Contain("case (KnowNamespacePrefixes.Uml, \"ownedElement\"):"), "derived union");
                Assert.That(result, Does.Contain("case (KnowNamespacePrefixes.Uml, \"superClass\"):"), "derived property of the class itself");
                Assert.That(result, Does.Not.Contain("case (KnowNamespacePrefixes.Uml, \"name\"):"), "properties that are read have no skip case");
                Assert.That(result, Does.Not.Contain("case (KnowNamespacePrefixes.Uml, \"ownedAttribute\"):"), "properties that are read have no skip case");
                Assert.That(result, Does.Contain("this.logger.LogDebug(\"Ignoring the serialized derived property {LocalName} of Class at line:position {LineNumber}:{LinePosition}\", xmlReader.LocalName, xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);"));
                Assert.That(result, Does.Contain("xmlReader.SkipInPlace();"));
                Assert.That(result.Split("case (KnowNamespacePrefixes.Uml, \"qualifiedName\"):").Length, Is.EqualTo(2), "each derived property name is written once");
            }
        }

        [Test]
        public void Verify_that_WriteDerivedPropertyCasesForXmiReader_writes_nothing_for_a_class_without_derived_properties()
        {
            var template = "{{#Class.WriteDerivedPropertyCasesForXmiReader this}}";

            var action = this.handlebarsContext.Compile(template);

            var result = action(new Class { Name = "Plain" });

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Verify_that_WriteDerivedPropertyCasesForXmiReader_throws_when_not_provided_with_class()
        {
            var action = this.handlebarsContext.Compile("{{#Class.WriteDerivedPropertyCasesForXmiReader this}}");

            Assert.That(() => action(new Dependency()), Throws.ArgumentException);

            var actionWithoutArguments = this.handlebarsContext.Compile("{{#Class.WriteDerivedPropertyCasesForXmiReader}}");

            Assert.That(() => actionWithoutArguments(new Class()), Throws.InstanceOf<HandlebarsException>());
        }
    }
}
