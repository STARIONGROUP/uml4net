// -------------------------------------------------------------------------------------------------
//  <copyright file="AssociationExtensionsTestFixture.cs" company="Starion Group S.A.">
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

    using uml4net.StructuredClassifiers;
    using uml4net.Classification;

    /// <summary>
    /// Suite of tests for the <see cref="AssociationExtensions"/> class.
    /// </summary>
    [TestFixture]
    public class AssociationExtensionsTestFixture
    {
        [Test]
        public void Verify_that_QueryEndType_returns_expected_types()
        {
            var association = new Association();
            var classA = new Class { Name = "A" };
            var classB = new Class { Name = "B" };
            var property1 = new Property { Type = classA };
            var property2 = new Property { Type = classB };

            association.OwnedEnd.Add(property1);
            association.OwnedEnd.Add(property2);

            var result = association.QueryEndType();

            Assert.That(result, Is.EquivalentTo([classA, classB]));
        }
    }
}
