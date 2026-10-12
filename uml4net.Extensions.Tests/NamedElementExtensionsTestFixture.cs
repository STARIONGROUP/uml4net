// -------------------------------------------------------------------------------------------------
// <copyright file="NamedElementExtensionsTestFixture.cs" company="Starion Group S.A.">
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
    using Classification;
    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    using Serilog;

    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;
    using uml4net.xmi;
    using uml4net.xmi.Readers;

    [TestFixture]
    public class NamedElementExtensionsTestFixture
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
        public void Verify_that_QueryNamespace_returns_expected_resul()
        {
            var root = this.xmiReaderResult.QueryRoot(xmiId: "_0", name: "UML");

            var structuredClassifiersPackage = root.NestedPackage.Single(x => x.Name == "StructuredClassifiers");

            var connector = structuredClassifiersPackage.PackagedElement.OfType<IClass>()
                .Single(x => x.Name == "Connector");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(root.QueryNamespace(), Is.EqualTo("UML"));
                Assert.That(structuredClassifiersPackage.QueryNamespace(), Is.EqualTo("UML.StructuredClassifiers"));
                Assert.That(connector.QueryNamespace(), Is.EqualTo("UML.StructuredClassifiers.Connector"));
            }
        }

        [Test]
        public void Verify_that_QueryCSharpIdentifier_applies_the_casing_and_escapes_a_keyword()
        {
            var @class = new Property { Name = "class" };
            var ownedComment = new Property { Name = "ownedComment" };
            var upperCase = new Class { Name = "Event" };

            using (Assert.EnterMultipleScope())
            {
                Assert.That(@class.QueryCSharpIdentifier(), Is.EqualTo("@class"), "as modelled, a keyword");
                Assert.That(@class.QueryCSharpIdentifier(CSharpIdentifierCasing.LowerCaseFirstLetter), Is.EqualTo("@class"));
                Assert.That(@class.QueryCSharpIdentifier(CSharpIdentifierCasing.UpperCaseFirstLetter), Is.EqualTo("Class"), "not a keyword after the casing is applied");

                Assert.That(ownedComment.QueryCSharpIdentifier(), Is.EqualTo("ownedComment"));
                Assert.That(ownedComment.QueryCSharpIdentifier(CSharpIdentifierCasing.UpperCaseFirstLetter), Is.EqualTo("OwnedComment"));

                Assert.That(upperCase.QueryCSharpIdentifier(), Is.EqualTo("Event"));
                Assert.That(upperCase.QueryCSharpIdentifier(CSharpIdentifierCasing.LowerCaseFirstLetter), Is.EqualTo("@event"), "a keyword after the casing is applied");
            }
        }

        [Test]
        public void Verify_that_QueryCSharpIdentifier_throws_for_an_element_without_a_name()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => new Property { XmiId = "id-1" }.QueryCSharpIdentifier(),
                    Throws.InvalidOperationException.With.Message.Contains("id-1").And.Message.Contains("Property"));
                Assert.That(() => new Property { Name = " " }.QueryCSharpIdentifier(), Throws.InvalidOperationException);
                Assert.That(() => NamedElementExtensions.QueryCSharpIdentifier(null), Throws.ArgumentNullException);
            }
        }

        [Test]
        public void Verify_that_QueryCSharpIdentifier_escapes_a_registered_keyword()
        {
            var value = new Property { Name = "value" };
            var upperCase = new Property { Name = "Var" };

            try
            {
                StringExtensions.RegisterAdditionalCSharpKeywords("var", "value");

                using (Assert.EnterMultipleScope())
                {
                    Assert.That(value.QueryCSharpIdentifier(), Is.EqualTo("@value"));
                    Assert.That(value.QueryCSharpIdentifier(CSharpIdentifierCasing.UpperCaseFirstLetter), Is.EqualTo("Value"));
                    Assert.That(upperCase.QueryCSharpIdentifier(CSharpIdentifierCasing.LowerCaseFirstLetter), Is.EqualTo("@var"));
                }
            }
            finally
            {
                StringExtensions.ClearAdditionalCSharpKeywords();
            }

            Assert.That(value.QueryCSharpIdentifier(), Is.EqualTo("value"));
        }
    }
}
