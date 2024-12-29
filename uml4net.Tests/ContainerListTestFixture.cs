// -------------------------------------------------------------------------------------------------
//  <copyright file="ContainerListTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.Tests
{
    using System.Collections.Generic;
    using System.ComponentModel;

    using NUnit.Framework;

    using uml4net.StructuredClassifiers;
    using uml4net.Packages;
    
    [TestFixture]
    public class ContainerListTestFixture
    {
        [Test]
        public void Verify_that_When_container_is_null_ArgumentNullException_is_thrown()
        {
            var package = new Package();

            Assert.That(() => new ContainerList<IPackage>(null, package), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_when_null_object_is_added_to_container_list_ArgumentNullException_is_thrown()
        {
            var package = new Package();

            Assert.That(() => package.PackagedElement.Add(null), Throws.ArgumentNullException);

            Assert.That(() => package.PackagedElement.AddRange(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_when_container_is_added_to_ContainerList_as_element_InvalidOperationException_is_thrown()
        {
            var package = new Package();

            Assert.That(() => package.PackagedElement.Add(package), Throws.InvalidOperationException);
        }

        [Test]
        public void Verify_that_the_same_item_cannot_be_added_more_than_once()
        {
            var package = new Package();

            var @class = new Class();

            package.PackagedElement.Add(@class);

            Assert.That(() => package.PackagedElement.Add(@class), Throws.InvalidOperationException);
        }
    }
}
