// -------------------------------------------------------------------------------------------------
// <copyright file="ClassHelperTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.HandleBars.Tests
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    using HandlebarsDotNet;

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    using Serilog;

    using uml4net.StructuredClassifiers;
    using uml4net.xmi;
    using uml4net.xmi.Readers;

    /// <summary>
    /// Suite of tests for the <see cref="ClassHelper"/> class
    /// </summary>
    [TestFixture]
    public class ClassHelperTestFixture
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

            ClassHelper.RegisterClassHelper(this.handlebarsContenxt);
        }

        [Test]
        public void Verify_that_QueryOwnedAttributeOrdered_returns_expected_order()
        {
            var template = "{{#each (#Class.QueryOwnedAttributeOrdered this) as | property |}}{{ property.Name }};{{/each}}";

            var action = this.handlebarsContenxt.Compile(template);

            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var activitiesPackage = root.NestedPackage.Single(x => x.Name == "Activities");
            var activity = activitiesPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Activity");

            var result = action(activity);

            Assert.That(result, Is.EqualTo("edge;group;isReadOnly;isSingleExecution;node;partition;structuredNode;variable;"));
        }

        [Test]
        public void Verify_that_QueryOwnedAttributeOrdered_throws_when_not_provided_with_class()
        {
            var template = "{{#each (#Class.QueryOwnedAttributeOrdered this) as | property |}}{{ property.Name }};{{/each}}";

            var action = this.handlebarsContenxt.Compile(template);

            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var activitiesPackage = root.NestedPackage.Single(x => x.Name == "Activities");
            var activity = activitiesPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Activity");
            var property = activity.OwnedAttribute.First();

            Assert.That(() => action(property), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void Verify_that_QueryAllProperties_returns_expected_result()
        {
            var template = "{{#each (#Class.QueryAllProperties this) as | property |}}{{ property.Name }};{{/each}}";

            var action = this.handlebarsContenxt.Compile(template);

            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var activitiesPackage = root.NestedPackage.Single(x => x.Name == "Activities");
            var activity = activitiesPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Activity");

            var result = action(activity);

            Assert.That(result, Is.EqualTo("attribute;classifierBehavior;clientDependency;collaborationUse;context;edge;elementImport;extension;feature;general;generalization;group;importedMember;inheritedMember;interfaceRealization;isAbstract;isAbstract;isActive;isFinalSpecialization;isLeaf;isReadOnly;isReentrant;isSingleExecution;member;name;nameExpression;namespace;nestedClassifier;node;ownedAttribute;ownedAttribute;ownedBehavior;ownedComment;ownedConnector;ownedElement;ownedMember;ownedOperation;ownedParameter;ownedParameterSet;ownedPort;ownedReception;ownedRule;ownedTemplateSignature;ownedTemplateSignature;ownedUseCase;owner;owningTemplateParameter;package;packageImport;part;partition;postcondition;powertypeExtent;precondition;qualifiedName;redefinedBehavior;redefinedClassifier;redefinedElement;redefinitionContext;representation;role;specification;structuredNode;substitution;superClass;templateBinding;templateParameter;templateParameter;useCase;variable;visibility;visibility;"));
        }

        [Test]
        public void Verify_that_QueryAllContainedProperties_returns_expected_result()
        {
            var template = "{{#each (#Class.QueryAllContainedProperties this) as | property |}}{{ property.Name }};{{/each}}";

            var action = this.handlebarsContenxt.Compile(template);

            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var activitiesPackage = root.NestedPackage.Single(x => x.Name == "Activities");
            var activity = activitiesPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Activity");

            var result = action(activity);

            Assert.That(result, Is.EqualTo("collaborationUse;edge;elementImport;generalization;group;interfaceRealization;nameExpression;nestedClassifier;node;ownedAttribute;ownedAttribute;ownedBehavior;ownedComment;ownedConnector;ownedElement;ownedMember;ownedOperation;ownedParameter;ownedParameterSet;ownedPort;ownedReception;ownedRule;ownedTemplateSignature;ownedTemplateSignature;ownedUseCase;packageImport;postcondition;precondition;structuredNode;substitution;templateBinding;variable;"));
        }

        [Test]
        public void Verify_that_QueryAllNonDerivedNonReadOnlyNonContainedReferenceEnumerableProperties_returns_expected_result()
        {
            var template = "{{#each (#Class.QueryAllNonDerivedNonReadOnlyNonContainedReferenceEnumerableProperties this) as | property |}}{{ property.Name }};{{/each}}";

            var action = this.handlebarsContenxt.Compile(template);

            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var commonBehaviorPackage = root.NestedPackage.Single(x => x.Name == "CommonBehavior");
            var behavior = commonBehaviorPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Behavior");

            var result = action(behavior);

            Assert.That(result, Is.EqualTo("powertypeExtent;redefinedBehavior;redefinedClassifier;useCase;"));
        }

        [Test]
        public void Verify_that_QueryAllSpecializations_returns_expected_result()
        {
            var template = "{{#each (#Class.QueryAllSpecializations this) as | cls |}}{{ cls.Name }};{{/each}}";

            var action = this.handlebarsContenxt.Compile(template);

            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var commonBehaviorPackage = root.NestedPackage.Single(x => x.Name == "CommonBehavior");
            var behavior = commonBehaviorPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Behavior");

            var result = action(behavior);

            Assert.That(result, Does.Contain("Activity;"));
        }
    }
}
