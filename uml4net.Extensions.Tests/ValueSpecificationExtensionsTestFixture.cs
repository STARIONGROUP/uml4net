// -------------------------------------------------------------------------------------------------
//  <copyright file="ValueSpecificationExtensionsTestFixture.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    using Serilog;

    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.Extensions;
    using uml4net.StructuredClassifiers;
    using uml4net.Values;
    using uml4net.xmi;
    using uml4net.xmi.Readers;

    [TestFixture]
    public class ValueSpecificationExtensionsTestFixture
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
        public void QueryDefaultValueAsString_HandlesDifferentLiteralTypes()
        {
            var literalBool = new LiteralBoolean { Value = true };
            var literalInt = new LiteralInteger { Value = 42 };
            var literalNull = new LiteralNull();
            var literalString = new LiteralString { Value = "star" };
            var literalUnlimited = new LiteralUnlimitedNatural { Value = "*" };
            var instance = new InstanceSpecification { Name = "myInstance" };
            var instanceValue = new InstanceValue { Instance = instance };

            Assert.That(literalBool.QueryDefaultValueAsString(), Is.EqualTo("true"));
            Assert.That(literalInt.QueryDefaultValueAsString(), Is.EqualTo("42"));
            Assert.That(literalNull.QueryDefaultValueAsString(), Is.EqualTo("null"));
            Assert.That(literalString.QueryDefaultValueAsString(), Is.EqualTo("star"));
            Assert.That(literalUnlimited.QueryDefaultValueAsString(), Is.EqualTo("int.MaxValue"));
            Assert.That(instanceValue.QueryDefaultValueAsString(), Is.EqualTo("myInstance"));
        }

        [Test]
        public void Verify_that_QueryLanguageAndBody_returns_expected_result()
        {
            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var structuredClassifiersPackage = root.NestedPackage.Single(x => x.Name == "StructuredClassifiers");

            var connector = structuredClassifiersPackage.PackagedElement.OfType<IClass>().Single(x => x.Name == "Connector");

            var constraint = connector.OwnedRule.Single(x => x.XmiId == "Connector-types");

            var docs = constraint.QueryRawDocumentation();

            Assert.That(docs, Is.EqualTo("The types of the ConnectableElements that the ends of a Connector are attached to must conform to the types of the ends of the Association that types the Connector, if any."));

            var specification = constraint.Specification.Single(x => x.XmiId == "Connector-types-_specification");

            var expectedLanguageAndBody = "OCL: type<>null implies \n" +
                                          "  let noOfEnds : Integer = end->size() in \n" +
                                          "  (type.memberEnd->size() = noOfEnds) and Sequence{1..noOfEnds}->forAll(i | end->at(i).role.type.conformsTo(type.memberEnd->at(i).type))\r\n\r\n";

            var languageAndBody = specification.QueryLanguageAndBody();

            Assert.That(languageAndBody, Is.EqualTo(expectedLanguageAndBody));
        }

        private class UnsupportedValueSpecification : XmiElement, IValueSpecification
        {
            public IElement Possessor { get; set; }
            public IContainerList<IComment> OwnedComment { get; set; }
            public IContainerList<IElement> OwnedElement { get; }
            public IElement Owner { get; }
            public List<IDependency> ClientDependency { get; }
            public string Name { get; set; }
            public IContainerList<IStringExpression> NameExpression { get; set; }
            public INamespace Namespace { get; }
            public string QualifiedName { get; }
            public VisibilityKind Visibility { get; set; }
            public IType Type { get; set; }
            public ITemplateParameter OwningTemplateParameter { get; set; }
            public ITemplateParameter TemplateParameter { get; set; }
        }

        [Test]
        public void QueryDefaultValueAsString_ThrowsOnUnsupportedType()
        {
            var unsupported = new UnsupportedValueSpecification();
            Assert.That(() => unsupported.QueryDefaultValueAsString(), Throws.TypeOf<System.NotSupportedException>());
        }
    }
}
