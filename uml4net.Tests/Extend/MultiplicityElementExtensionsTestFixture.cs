// -------------------------------------------------------------------------------------------------
// <copyright file="MultiplicityElementExtensionsTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.Tests.Extend
{
    using NUnit.Framework;

    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.Values;

    [TestFixture]
    public class MultiplicityElementExtensionsTestFixture
    {
        [Test]
        public void Verify_that_when_multiplicityElement_is_null_argument_exception_is_thrown()
        {
            Property property = null;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => MultiplicityElementExtensions.QueryLower(property), Throws.ArgumentNullException);
                Assert.That(() => MultiplicityElementExtensions.QueryUpper(property), Throws.ArgumentNullException);
            }
        }

        [Test]
        public void Verify_that_Query_lower_returns_expected_value()
        {
            var property = new Property();

            Assert.That(property.Lower, Is.EqualTo(1));

            var value = new LiteralInteger
            {
                Value = 0
            };

            property.LowerValue.Add(value);

            Assert.That(property.Lower, Is.EqualTo(0));
        }

        [Test]
        public void Verify_that_lower_and_upper_are_the_default_1_when_the_bound_is_not_a_literal()
        {
            // ValueSpecification::integerValue() and unlimitedValue() are null for an OpaqueExpression, an Expression
            // or an InstanceValue, in which case lowerBound() and upperBound() are 1
            var withOpaqueExpression = new Property();
            withOpaqueExpression.LowerValue.Add(new OpaqueExpression { Body = { "n" } });
            withOpaqueExpression.UpperValue.Add(new OpaqueExpression { Body = { "m" } });

            var withExpression = new Property();
            withExpression.LowerValue.Add(new Expression { Symbol = "n" });
            withExpression.UpperValue.Add(new Expression { Symbol = "m" });

            var withInstanceValue = new Property();
            withInstanceValue.LowerValue.Add(new InstanceValue());
            withInstanceValue.UpperValue.Add(new InstanceValue());

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => withOpaqueExpression.Lower, Throws.Nothing);
                Assert.That(() => withOpaqueExpression.Upper, Throws.Nothing);
                Assert.That(withOpaqueExpression.Lower, Is.EqualTo(1));
                Assert.That(withOpaqueExpression.Upper, Is.EqualTo("1"));
                Assert.That(withExpression.Lower, Is.EqualTo(1));
                Assert.That(withExpression.Upper, Is.EqualTo("1"));
                Assert.That(withInstanceValue.Lower, Is.EqualTo(1));
                Assert.That(withInstanceValue.Upper, Is.EqualTo("1"));
            }
        }

        [Test]
        public void Verify_that_a_bound_exported_with_the_other_literal_kind_keeps_its_value()
        {
            // tool exports write an upper bound as a LiteralInteger; reading it as the default 1 would turn 0..5 into 0..1
            var property = new Property();
            property.LowerValue.Add(new LiteralUnlimitedNatural { Value = "2" });
            property.UpperValue.Add(new LiteralInteger { Value = 5 });

            var unlimitedLower = new Property();
            unlimitedLower.LowerValue.Add(new LiteralUnlimitedNatural { Value = "*" });

            var negativeUpper = new Property();
            negativeUpper.UpperValue.Add(new LiteralInteger { Value = -1 });

            using (Assert.EnterMultipleScope())
            {
                Assert.That(property.Lower, Is.EqualTo(2));
                Assert.That(property.Upper, Is.EqualTo("5"));
                Assert.That(unlimitedLower.Lower, Is.EqualTo(1), "* is not an integer, the default applies");
                Assert.That(negativeUpper.Upper, Is.EqualTo("1"), "a negative number is not an UnlimitedNatural, the default applies");
            }
        }

        [Test]
        public void Verify_that_Query_upper_returns_expected_value()
        {
            var property = new Property();

            Assert.That(property.Upper, Is.EqualTo("1"));

            var value = new LiteralUnlimitedNatural
            {
                Value = "*"
            };

            property.UpperValue.Add(value);

            Assert.That(property.Upper, Is.EqualTo("*"));
        }
    }
}
