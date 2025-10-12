// -------------------------------------------------------------------------------------------------
//  <copyright file="ContainerListTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.Tests
{
    using System;
    using System.Linq;

    using NUnit.Framework;

    using uml4net.CommonStructure;
    using uml4net.Packages;
    using uml4net.StructuredClassifiers;

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

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => package.PackagedElement.Add(null), Throws.ArgumentNullException);

                Assert.That(() => package.PackagedElement.AddRange(null), Throws.ArgumentNullException);
            }
        }

        [Test]
        public void Verify_that_when_container_is_added_to_ContainerList_as_element_InvalidOperationException_is_thrown()
        {
            var package = new Package();

            Assert.That(() => package.PackagedElement.Add(package), Throws.InvalidOperationException);
        }

        [Test]
        public void Verify_that_containees_can_be_copied_to_a_new_container()
        {
            var originalContainer = new Package();
            var element = new Class();
            originalContainer.PackagedElement.Add(element);

            var newContainer = new Package();
            var copiedList = new ContainerList<IPackageableElement>(originalContainer.PackagedElement, newContainer, true);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(copiedList.Single(), Is.SameAs(element));
                Assert.That(element.Possessor, Is.SameAs(newContainer));
            }
        }

        [Test]
        public void Verify_that_copying_containees_without_updating_container_keeps_original_possessor()
        {
            var originalContainer = new Package();
            var element = new Class();
            originalContainer.PackagedElement.Add(element);

            var newContainer = new Package();
            _ = new ContainerList<IPackageableElement>(originalContainer.PackagedElement, newContainer);

            Assert.That(element.Possessor, Is.SameAs(originalContainer));
        }

        [Test]
        public void Verify_that_the_same_item_cannot_be_added_more_than_once()
        {
            var package = new Package();

            var @class = new Class();

            package.PackagedElement.Add(@class);

            Assert.That(() => package.PackagedElement.Add(@class), Throws.InvalidOperationException);
        }

        [Test]
        public void Verify_that_AddRange_sets_the_possessor_of_each_element()
        {
            var package = new Package();
            var elements = new IPackageableElement[]
            {
                new Class(),
                new Class(),
            };

            package.PackagedElement.AddRange(elements);

            Assert.That(elements.Select(element => element.Possessor), Is.All.SameAs(package));
        }

        [Test]
        public void Verify_that_AddRange_fails_when_duplicates_are_present()
        {
            var package = new Package();
            var duplicate = new Class();

            Assert.That(() => package.PackagedElement.AddRange(new[] { duplicate, duplicate }), Throws.InvalidOperationException);
        }

        [Test]
        public void Verify_that_when_element_is_removed_its_possessor_is_set_to_null()
        {
            var package = new Package();

            var @class = new Class();

            package.PackagedElement.Add(@class);

            package.PackagedElement.Remove(@class);

            Assert.That(@class.Possessor, Is.Null);
        }

        [Test]
        public void Verify_that_removing_non_existing_items_returns_false_and_preserves_possessor()
        {
            var package = new Package();
            var @class = new Class();
            var outsider = new Class { Possessor = new Package() };

            package.PackagedElement.Add(@class);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(package.PackagedElement.Remove(outsider), Is.False);
                Assert.That(outsider.Possessor, Is.Not.Null);
            }
        }

        [Test]
        public void Verify_that_removing_null_item_throws()
        {
            var package = new Package();

            Assert.That(() => package.PackagedElement.Remove(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_when_element_is_removed_by_index_its_possessor_is_set_to_null()
        {
            var package = new Package();

            var @class = new Class();

            package.PackagedElement.Add(@class);

            package.PackagedElement.RemoveAt(0);

            Assert.That(@class.Possessor, Is.Null);
        }

        [Test]
        public void Verify_that_indexer_enforces_valid_indices()
        {
            var package = new Package();
            package.PackagedElement.Add(new Class());

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => package.PackagedElement[-1], Throws.InstanceOf<ArgumentOutOfRangeException>());
                Assert.That(() => package.PackagedElement[1], Throws.InstanceOf<ArgumentOutOfRangeException>());
                Assert.That(() => package.PackagedElement[-1] = new Class(), Throws.InstanceOf<ArgumentOutOfRangeException>());
                Assert.That(() => package.PackagedElement[1] = new Class(), Throws.InstanceOf<ArgumentOutOfRangeException>());
            }
        }

        [Test]
        public void Verify_that_indexer_sets_possessor_and_detects_duplicates()
        {
            var package = new Package();
            var first = new Class();
            var second = new Class();

            package.PackagedElement.Add(first);
            package.PackagedElement.Add(second);

            var replacement = new Class();
            package.PackagedElement[0] = replacement;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(replacement.Possessor, Is.SameAs(package));
                Assert.That(() => package.PackagedElement[0] = second, Throws.InvalidOperationException);
            }
        }

        [Test]
        public void Verify_that_when_container_list_is_cleared_containee_possessor_is_set_to_null()
        {
            var package = new Package();

            var @class = new Class();

            package.PackagedElement.Add(@class);

            package.PackagedElement.Clear();

            Assert.That(@class.Possessor, Is.Null);
        }
    }
}
