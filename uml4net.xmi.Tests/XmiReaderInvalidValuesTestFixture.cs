// -------------------------------------------------------------------------------------------------
// <copyright file="XmiReaderInvalidValuesTestFixture.cs" company="Starion Group S.A.">
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
    using System.IO;
    using System.Linq;

    using Microsoft.Extensions.Logging.Abstractions;

    using NUnit.Framework;

    using uml4net.CommonStructure;
    using uml4net.StructuredClassifiers;
    using uml4net.xmi.Readers;

    /// <summary>
    /// Verifies that values that are not valid according to XMI 2.5.1 - numeric or wrongly cased enumeration
    /// literals, duplicate xmi:id values and repeated single-valued references - are rejected with an
    /// <see cref="XmiReadException"/> that names the element, property and line position in strict mode, and are
    /// logged with a defined result in non-strict mode
    /// </summary>
    [TestFixture]
    public class XmiReaderInvalidValuesTestFixture
    {
        private string rootPath;

        [SetUp]
        public void SetUp()
        {
            this.rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "InvalidValues");
        }

        private IXmiReader CreateReader(bool useStrictReading)
        {
            return XmiReaderBuilder.Create()
                .UsingSettings(x =>
                {
                    x.LocalReferenceBasePath = this.rootPath;
                    x.UseStrictReading = useStrictReading;
                })
                .WithLogger(NullLoggerFactory.Instance)
                .Build();
        }

        private XmiReadException ReadStrictlyAndCatch(string fileName)
        {
            return Assert.Throws<XmiReadException>(() => this.CreateReader(useStrictReading: true).Read(Path.Combine(this.rootPath, fileName)));
        }

        [Test]
        public void Verify_that_a_numeric_enumeration_value_is_rejected_in_strict_mode()
        {
            var exception = this.ReadStrictlyAndCatch("numeric-enum.xmi");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(exception.Message, Is.EqualTo("[7] is not the name of a literal of VisibilityKind: uml:Class [c] property [visibility] at line:position 5:6"));
                Assert.That(exception.ElementType, Is.EqualTo("uml:Class"));
                Assert.That(exception.XmiId, Is.EqualTo("c"));
                Assert.That(exception.PropertyName, Is.EqualTo("visibility"));
                Assert.That(exception.LineNumber, Is.EqualTo(5));
                Assert.That(exception.LinePosition, Is.EqualTo(6), "the position of the element name, after the <");
            }
        }

        [Test]
        public void Verify_that_a_numeric_enumeration_value_keeps_the_default_in_non_strict_mode()
        {
            var xmiReaderResult = this.CreateReader(useStrictReading: false).Read(Path.Combine(this.rootPath, "numeric-enum.xmi"));
            var classes = xmiReaderResult.QueryRoot("p").PackagedElement.OfType<IClass>().ToList();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(classes.Single(x => x.XmiId == "c").Visibility, Is.EqualTo(VisibilityKind.Public), "a defined value instead of the undefined (VisibilityKind)7");
                Assert.That(classes.Select(x => x.Name), Is.EqualTo(new[] { "C", "D" }), "reading continues");
            }
        }

        [Test]
        public void Verify_that_a_wrongly_cased_enumeration_literal_is_rejected_in_strict_mode()
        {
            var exception = this.ReadStrictlyAndCatch("wrong-case-enum.xmi");

            Assert.That(exception.Message, Is.EqualTo("[PRIVATE] is not the name of a literal of VisibilityKind: uml:Class [c] property [visibility] at line:position 5:6"));
        }

        [Test]
        public void Verify_that_wrongly_cased_enumeration_literals_keep_the_default_in_non_strict_mode()
        {
            var xmiReaderResult = this.CreateReader(useStrictReading: false).Read(Path.Combine(this.rootPath, "wrong-case-enum.xmi"));
            var classes = xmiReaderResult.QueryRoot("p").PackagedElement.OfType<IClass>().ToList();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(classes.Single(x => x.XmiId == "c").Visibility, Is.EqualTo(VisibilityKind.Public), "the attribute PRIVATE is not the literal private");
                Assert.That(classes.Single(x => x.XmiId == "d").Visibility, Is.EqualTo(VisibilityKind.Public), "the element Private is not the literal private");
            }
        }

        /// <summary>
        /// A duplicate xmi:id is reported but never rejected, not even in strict mode: the normative UML.xmi itself
        /// contains the xmi:id State-isConsistentWith twice
        /// </summary>
        [TestCase(true)]
        [TestCase(false)]
        public void Verify_that_a_duplicate_xmi_id_keeps_the_first_element(bool useStrictReading)
        {
            var xmiReaderResult = this.CreateReader(useStrictReading).Read(Path.Combine(this.rootPath, "duplicate-id.xmi"));
            var classes = xmiReaderResult.QueryRoot("p").PackagedElement.OfType<IClass>().ToList();
            var property = classes.Single(x => x.XmiId == "d").OwnedAttribute.Single();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(classes.Select(x => x.Name), Is.EqualTo(new[] { "First", "Second", "D" }), "both elements are contained");
                Assert.That(property.Type, Is.SameAs(classes.Single(x => x.Name == "First")), "references resolve to the element that was read first");
            }
        }

        [Test]
        public void Verify_that_a_repeated_single_valued_reference_is_rejected_in_strict_mode()
        {
            var exception = this.ReadStrictlyAndCatch("repeated-reference.xmi");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(exception.Message, Is.EqualTo("The single-valued reference is given more than once, [c] is kept and [d] is ignored: uml:Property [a] property [type] at line:position 9:10"));
                Assert.That(exception.ElementType, Is.EqualTo("uml:Property"));
                Assert.That(exception.PropertyName, Is.EqualTo("type"));
            }
        }

        [Test]
        public void Verify_that_a_repeated_single_valued_reference_keeps_the_first_value_in_non_strict_mode()
        {
            var xmiReaderResult = this.CreateReader(useStrictReading: false).Read(Path.Combine(this.rootPath, "repeated-reference.xmi"));
            var classes = xmiReaderResult.QueryRoot("p").PackagedElement.OfType<IClass>().ToList();
            var property = classes.Single(x => x.XmiId == "d").OwnedAttribute.Single();

            Assert.That(property.Type, Is.SameAs(classes.Single(x => x.XmiId == "c")));
        }
    }
}
