// -------------------------------------------------------------------------------------------------
//  <copyright file="ImplementsAttributeTestFixture.cs" company="Starion Group S.A.">
//
//    Copyright (C) 2019-2026 Starion Group S.A.
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
    /// Tests for the <see cref="ImplementsAttribute"/> type.
    /// </summary>
    [TestFixture]
    public class ImplementsAttributeTestFixture
    {
        [Test]
        public void Verify_that_constructor_sets_property()
        {
            var attribute = new ImplementsAttribute("Class.Property");

            Assert.That(attribute.Implementations, Is.EqualTo("Class.Property"));
        }

        [Test]
        public void Verify_that_property_is_settable()
        {
            var attribute = new ImplementsAttribute("Initial");
            attribute.Implementations = "Updated";

            Assert.That(attribute.Implementations, Is.EqualTo("Updated"));
        }
    }
}
