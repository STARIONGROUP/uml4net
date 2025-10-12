// -------------------------------------------------------------------------------------------------
//  <copyright file="MultiplicityElementExtensionsTestFixture.cs" company="Starion Group S.A.">
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
