// -------------------------------------------------------------------------------------------------
//  <copyright file="ClassifierExtensionsTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.Tests.Extend
{
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    using uml4net.Classification;
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;

    [TestFixture]
    public class ClassifierExtensionsTestFixture
    {
        [Test]
        public void Verify_that_QueryAttribute_returns_expected_result()
        {
            var @interface = new Interface();

            var property = new Property
            {
                XmiId = "test_id",
                Name = "test",
            };

            @interface.OwnedAttribute.Add(property);

            var properties = Classification.ClassifierExtensions.QueryAttribute(@interface);

            Assert.That(properties.Single(), Is.EqualTo(property));
        }

        [Test]
        public void Verify_that_when_Class_is_null_argument_exception_is_thrown()
        {
            Class @class = null;

            Assert.That(() => ClassifierExtensions.QueryGeneral(@class), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_QueryAttribute_returns_throws_exception_when_argument_is_Null()
        {
            IInterface @interface = null;

            Assert.That(() => Classification.ClassifierExtensions.QueryAttribute(@interface),
                Throws.ArgumentNullException);
        }
    }
}