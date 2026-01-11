// -------------------------------------------------------------------------------------------------
//  <copyright file="MultiplicityElementExtensionsTestFixture.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2026 Starion Group S.A.
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
    using System;

    using NUnit.Framework;

    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.Values;

    [TestFixture]
    public class MultiplicityElementExtensionsTestFixture
    {
        private Property property;

        [SetUp]
        public void SetUp()
        {
            this.property = new Property();
        }

        [Test]
        public void Verify_That_when_property_is_null_exception_is_raised()
        {
            this.property = null;
            Assert.That(() => MultiplicityElementExtensions.QueryUpperValue(this.property), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_when_no_ValueSpecification_present_defaults_to_one()
        {
            // when there is no Value -> default to 1
            Assert.That(this.property.QueryUpperValue(), Is.EqualTo(1));
        }

        [Test]
        public void Verify_that_Query_upper_returns_expected_value_for_star()
        {
            var value = new LiteralUnlimitedNatural
            {
                Value = "*"
            };

            property.UpperValue.Add(value);

            Assert.That(this.property.QueryUpperValue(), Is.EqualTo(int.MaxValue));
        }

        [Test]
        public void Verify_that_Query_upper_returns_NotSupportedException_when_not_a_LiteralUnlimitedNatural()
        {
            var value = new LiteralBoolean();
            
            property.UpperValue.Add(value);

            Assert.That(() => this.property.QueryUpperValue(), Throws.TypeOf<NotSupportedException>());
        }
    }
}
