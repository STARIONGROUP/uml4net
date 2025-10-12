// -------------------------------------------------------------------------------------------------
//  <copyright file="ClassAttributeTestFixture.cs" company="Starion Group S.A.">
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
    /// Suite of tests for the <see cref="ClassAttribute"/> type.
    /// </summary>
    [TestFixture]
    public class ClassAttributeTestFixture
    {
        [Test]
        public void Verify_that_constructor_sets_all_properties()
        {
            var attribute = new ClassAttribute("id", true, true, true);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(attribute.XmiId, Is.EqualTo("id"));
                Assert.That(attribute.IsAbstract, Is.True);
                Assert.That(attribute.IsFinalSpecialization, Is.True);
                Assert.That(attribute.IsActive, Is.True);
            }
        }

        [Test]
        public void Verify_default_values()
        {
            var attribute = new ClassAttribute();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(attribute.XmiId, Is.EqualTo(string.Empty));
                Assert.That(attribute.IsAbstract, Is.False);
                Assert.That(attribute.IsFinalSpecialization, Is.False);
                Assert.That(attribute.IsActive, Is.False);
            }
        }
    }
}
