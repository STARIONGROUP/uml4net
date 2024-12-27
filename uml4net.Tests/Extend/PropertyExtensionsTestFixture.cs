﻿// -------------------------------------------------------------------------------------------------
//  <copyright file="PropertyExtensionsTestFixture.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2024 Starion Group S.A.
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

    using NUnit.Framework;

    using uml4net.Classification;
    using uml4net.Packages;
    using uml4net.StructuredClassifiers;

    [TestFixture]
    public class PropertyExtensionsTestFixture
    {
        [Test]
        public void Verify_that_when_Property_is_null_argument_null_exception_is_thrown()
        {
            IProperty property = null;

            Assert.That(() => PropertyExtensions.QueryIsComposite(property),
                Throws.ArgumentNullException);

            Assert.That(() => PropertyExtensions.QueryOpposite(property),
                Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_QueryIsComposite_returns_the_expected_result()
        {
            var property = new Property();

            property.Aggregation = AggregationKind.None;

            Assert.That(property.IsComposite, Is.False);

            property.Aggregation = AggregationKind.Shared;

            Assert.That(property.IsComposite, Is.False);

            property.Aggregation = AggregationKind.Composite;

            Assert.That(property.IsComposite, Is.True);

        }

    }
}