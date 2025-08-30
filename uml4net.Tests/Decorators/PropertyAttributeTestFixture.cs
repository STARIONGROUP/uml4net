// -------------------------------------------------------------------------------------------------
//  <copyright file="PropertyAttributeTestFixture.cs" company="Starion Group S.A.">
//
//    Copyright (C) 2019-2025 Starion Group S.A.
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

namespace uml4net.Tests.Decorators
{
    using NUnit.Framework;

    using uml4net.Decorators;
    using uml4net.Classification;

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

        [Test]
        public void Verify_default_values()
        {
            var attribute = new PropertyAttribute();

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
