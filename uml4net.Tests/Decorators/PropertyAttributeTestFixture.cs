// -------------------------------------------------------------------------------------------------
// <copyright file="PropertyAttributeTestFixture.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Tests.Decorators
{
    using NUnit.Framework;

    using uml4net.Classification;
    using uml4net.Decorators;

    using PropertyAttribute = uml4net.Decorators.PropertyAttribute;

    /// <summary>
    /// Suite of tests for the <see cref="PropertyAttribute"/> type.
    /// </summary>
    [TestFixture]
    public class PropertyAttributeTestFixture
    {
        [Test]
        public void Verify_that_constructor_sets_all_properties()
        {
            var attribute = new uml4net.Decorators.PropertyAttribute(
                "id",
                AggregationKind.Composite,
                0,
                2,
                true,
                true,
                true,
                true,
                false,
                "default");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(attribute.XmiId, Is.EqualTo("id"));
                Assert.That(attribute.Aggregation, Is.EqualTo(AggregationKind.Composite));
                Assert.That(attribute.LowerValue, Is.EqualTo(0));
                Assert.That(attribute.UpperValue, Is.EqualTo(2));
                Assert.That(attribute.IsOrdered, Is.True);
                Assert.That(attribute.IsReadOnly, Is.True);
                Assert.That(attribute.IsDerived, Is.True);
                Assert.That(attribute.IsDerivedUnion, Is.True);
                Assert.That(attribute.IsUnique, Is.False);
                Assert.That(attribute.DefaultValue, Is.EqualTo("default"));
            }
        }

        [Test]
        public void Verify_default_values()
        {
            var attribute = new PropertyAttribute();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(attribute.XmiId, Is.EqualTo(string.Empty));
                Assert.That(attribute.Aggregation, Is.EqualTo(AggregationKind.None));
                Assert.That(attribute.LowerValue, Is.EqualTo(1));
                Assert.That(attribute.UpperValue, Is.EqualTo(1));
                Assert.That(attribute.IsOrdered, Is.False);
                Assert.That(attribute.IsReadOnly, Is.False);
                Assert.That(attribute.IsDerived, Is.False);
                Assert.That(attribute.IsDerivedUnion, Is.False);
                Assert.That(attribute.IsUnique, Is.True);
                Assert.That(attribute.DefaultValue, Is.Null);
            }
        }
    }
}
