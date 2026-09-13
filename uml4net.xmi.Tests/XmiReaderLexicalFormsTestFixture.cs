// -------------------------------------------------------------------------------------------------
// <copyright file="XmiReaderLexicalFormsTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Tests
{
    using System.Globalization;
    using System.IO;
    using System.Linq;

    using Microsoft.Extensions.Logging.Abstractions;

    using NUnit.Framework;

    using uml4net.StructuredClassifiers;
    using uml4net.Values;

    /// <summary>
    /// Verifies that Boolean, Integer and Real values are parsed per XML Schema Part 2 (XMI 2.5.1 clause 9.5.2
    /// rule 2i): independent of the current culture, and accepting the xsd:boolean forms 1/0 and the
    /// xsd:double forms INF/-INF/NaN
    /// </summary>
    [TestFixture]
    public class XmiReaderLexicalFormsTestFixture
    {
        private CultureInfo originalCulture;

        [SetUp]
        public void SetUp()
        {
            this.originalCulture = CultureInfo.CurrentCulture;
        }

        [TearDown]
        public void TearDown()
        {
            CultureInfo.CurrentCulture = this.originalCulture;
        }

        [TestCase("")]
        [TestCase("de-DE")]
        [TestCase("fr-FR")]
        public void Verify_that_xsd_lexical_forms_are_read_independent_of_the_culture(string cultureName)
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(cultureName);

            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "LexicalForms");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x =>
                {
                    x.LocalReferenceBasePath = rootPath;
                    x.UseStrictReading = true;
                })
                .WithLogger(NullLoggerFactory.Instance)
                .Build();

            var package = reader.Read(Path.Combine(rootPath, "xsd-lexical-forms.xmi")).QueryRoot("p");
            var @class = package.PackagedElement.OfType<IClass>().Single();

            IValueSpecification DefaultValueOf(string propertyName) => @class.OwnedAttribute.Single(x => x.Name == propertyName).DefaultValue.Single();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(@class.IsAbstract, Is.True, "xsd:boolean '1' as attribute");
                Assert.That(@class.IsLeaf, Is.False, "xsd:boolean '0' as attribute");
                Assert.That(@class.IsActive, Is.True, "xsd:boolean as element");
                Assert.That(@class.OwnedAttribute.Single(x => x.Name == "a").IsReadOnly, Is.True, "xsd:boolean with surrounding whitespace");

                Assert.That(((ILiteralReal)DefaultValueOf("a")).Value, Is.EqualTo(1.5), "xsd:double as attribute, must not depend on the decimal separator of the culture");
                Assert.That(((ILiteralReal)DefaultValueOf("b")).Value, Is.EqualTo(double.PositiveInfinity), "xsd:double INF");
                Assert.That(((ILiteralReal)DefaultValueOf("d")).Value, Is.EqualTo(-2250), "xsd:double with exponent as element");
                Assert.That(((ILiteralInteger)DefaultValueOf("e")).Value, Is.EqualTo(42), "xsd:integer with sign and whitespace");
                Assert.That(((ILiteralInteger)DefaultValueOf("f")).Value, Is.EqualTo(-7), "xsd:integer as element");
            }
        }
    }
}
