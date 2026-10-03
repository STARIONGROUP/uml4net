// -------------------------------------------------------------------------------------------------
// <copyright file="TaggedValueConverterTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Tests.Readers
{
    using NUnit.Framework;

    using uml4net.Classification;
    using uml4net.Profiling;
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;
    using uml4net.xmi.Readers;

    [TestFixture]
    public class TaggedValueConverterTestFixture
    {
        [TestCase("Boolean", "true", true)]
        [TestCase("Integer", "-7", -7)]
        [TestCase("Real", "2.5", 2.5d)]
        [TestCase("UnlimitedNatural", "4", 4)]
        [TestCase("UnlimitedNatural", "*", int.MaxValue)]
        [TestCase("String", "text", "text")]
        [TestCase("Number", "12", "12")]
        public void Verify_that_a_primitive_value_is_converted(string primitiveTypeName, string rawValue, object expected)
        {
            var property = new Property { Name = "p", Type = new PrimitiveType { Name = primitiveTypeName } };

            var result = TaggedValueConverter.TryConvert(property, new TaggedValue { RawValues = { rawValue } }, _ => null, out var values, out var isReference);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result, Is.True);
                Assert.That(values, Is.EqualTo(new[] { expected }));
                Assert.That(isReference, Is.False);
                Assert.That(TaggedValueConverter.Format(values[0], property), Is.EqualTo(rawValue), "the value is formatted back as it was read");
            }
        }

        [TestCase("Boolean", "maybe")]
        [TestCase("Integer", "99999999999")]
        [TestCase("Real", "abc")]
        public void Verify_that_a_primitive_value_that_cannot_be_converted_gives_no_values(string primitiveTypeName, string rawValue)
        {
            var property = new Property { Name = "p", Type = new PrimitiveType { Name = primitiveTypeName } };

            var result = TaggedValueConverter.TryConvert(property, new TaggedValue { RawValues = { "1", rawValue } }, _ => null, out var values, out _);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result, Is.False);
                Assert.That(values, Is.Empty, "all or nothing");
            }
        }

        [Test]
        public void Verify_that_enumeration_values_data_types_references_and_untyped_properties_are_handled()
        {
            var enumeration = new Enumeration { Name = "Level" };
            var high = new EnumerationLiteral { Name = "high" };
            enumeration.OwnedLiteral.Add(high);

            var target = new Class { XmiId = "t" };

            using (Assert.EnterMultipleScope())
            {
                Assert.That(TaggedValueConverter.TryConvert(new Property { Type = enumeration }, new TaggedValue { RawValues = { "high" } }, _ => null, out var literals, out _), Is.True);
                Assert.That(literals, Is.EqualTo(new object[] { high }));
                Assert.That(TaggedValueConverter.TryConvert(new Property { Type = enumeration }, new TaggedValue { RawValues = { "high", "medium" } }, _ => null, out var none, out _), Is.False);
                Assert.That(none, Is.Empty);

                Assert.That(TaggedValueConverter.TryConvert(new Property { Type = new DataType { Name = "Structured" } }, new TaggedValue { RawValues = { "x" } }, _ => null, out _, out _), Is.False);
                Assert.That(TaggedValueConverter.TryConvert(new Property(), new TaggedValue { RawValues = { "x" } }, _ => null, out _, out _), Is.False, "a property without type");

                Assert.That(TaggedValueConverter.TryConvert(new Property { Type = new Class() }, new TaggedValue { RawValues = { " t  t " }, IsReadAsAttribute = true }, x => x == "t" ? target : null, out var references, out var isReference), Is.True);
                Assert.That(references, Is.EqualTo(new object[] { target, target }));
                Assert.That(isReference, Is.True);
                Assert.That(TaggedValueConverter.TryConvert(new Property { Type = new Class() }, new TaggedValue { RawValues = { "t", "unknown" } }, x => x == "t" ? target : null, out var unresolved, out _), Is.False);
                Assert.That(unresolved, Is.Empty);
            }
        }

        [Test]
        public void Verify_that_the_arguments_are_checked()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => TaggedValueConverter.TryConvert(null, new TaggedValue(), _ => null, out _, out _), Throws.ArgumentNullException);
                Assert.That(() => TaggedValueConverter.TryConvert(new Property(), null, _ => null, out _, out _), Throws.ArgumentNullException);
                Assert.That(() => TaggedValueConverter.TryConvert(new Property(), new TaggedValue(), null, out _, out _), Throws.ArgumentNullException);
            }
        }

        [Test]
        public void Verify_that_values_are_formatted()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(TaggedValueConverter.Format(null, null), Is.Empty);
                Assert.That(TaggedValueConverter.Format(false, null), Is.EqualTo("false"));
                Assert.That(TaggedValueConverter.Format(int.MaxValue, null), Is.EqualTo("2147483647"), "* only for an UnlimitedNatural property");
                Assert.That(TaggedValueConverter.Format(12L, null), Is.EqualTo("12"));
                Assert.That(TaggedValueConverter.Format(1.5f, null), Is.EqualTo("1.5"));
                Assert.That(TaggedValueConverter.Format(2.25m, null), Is.EqualTo("2.25"));
                Assert.That(TaggedValueConverter.Format(new EnumerationLiteral { Name = "low" }, null), Is.EqualTo("low"));
                Assert.That(TaggedValueConverter.Format('c', null), Is.EqualTo("c"));
            }
        }
    }
}
