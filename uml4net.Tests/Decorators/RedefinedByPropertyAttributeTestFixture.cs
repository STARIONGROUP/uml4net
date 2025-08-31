// -------------------------------------------------------------------------------------------------
//  <copyright file="RedefinedByPropertyAttributeTestFixture.cs" company="Starion Group S.A.">
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

    /// <summary>
    /// Tests for the <see cref="RedefinedByPropertyAttribute"/> type.
    /// </summary>
    [TestFixture]
    public class RedefinedByPropertyAttributeTestFixture
    {
        [Test]
        public void Verify_that_constructor_sets_property()
        {
            var attribute = new RedefinedByPropertyAttribute("PropertyName");

            Assert.That(attribute.PropertyName, Is.EqualTo("PropertyName"));
        }

        [Test]
        public void Verify_that_property_is_settable()
        {
            var attribute = new RedefinedByPropertyAttribute("Initial");
            attribute.PropertyName = "Updated";

            Assert.That(attribute.PropertyName, Is.EqualTo("Updated"));
        }
    }
}
