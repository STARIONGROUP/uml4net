// -------------------------------------------------------------------------------------------------
// <copyright file="ContainerListTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2026 Starion Group S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NUnit.Framework;

    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.Packages;
    using uml4net.StructuredClassifiers;
    using uml4net.Values;

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

        [Test]
        public void Verify_that_the_owner_end_is_set_when_an_element_is_added_and_cleared_when_it_is_removed()
        {
            var specific = new Class { Name = "Specific" };
            var first = new Generalization();
            var second = new Generalization();
            var third = new Generalization();

            specific.Generalization.Add(first);
            specific.Generalization.AddRange(new[] { second, third });

            using (Assert.EnterMultipleScope())
            {
                Assert.That(first.Specific, Is.SameAs(specific), "Add");
                Assert.That(second.Specific, Is.SameAs(specific), "AddRange");
                Assert.That(third.Specific, Is.SameAs(specific), "AddRange");
            }

            specific.Generalization.Remove(first);
            specific.Generalization.RemoveAt(0);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(first.Specific, Is.Null, "Remove");
                Assert.That(second.Specific, Is.Null, "RemoveAt");
                Assert.That(third.Specific, Is.SameAs(specific));
            }

            specific.Generalization.Clear();

            Assert.That(third.Specific, Is.Null, "Clear");
        }

        [Test]
        public void Verify_that_the_indexer_sets_the_owner_end_of_the_new_element_and_clears_that_of_the_replaced_one()
        {
            var specific = new Class { Name = "Specific" };
            var original = new Generalization();
            var replacement = new Generalization();

            specific.Generalization.Add(original);
            specific.Generalization[0] = replacement;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(replacement.Specific, Is.SameAs(specific));
                Assert.That(replacement.Possessor, Is.SameAs(specific));
                Assert.That(original.Specific, Is.Null);
                Assert.That(original.Possessor, Is.Null);
            }
        }

        [Test]
        public void Verify_that_removing_an_element_that_has_moved_to_another_container_does_not_clear_its_new_owner_end()
        {
            var oldOwner = new Class { Name = "Old" };
            var newOwner = new Class { Name = "New" };
            var generalization = new Generalization();

            oldOwner.Generalization.Add(generalization);
            newOwner.Generalization.Add(generalization);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(oldOwner.Generalization, Is.Empty, "adding to another container moves the element (#492)");
                Assert.That(oldOwner.Generalization.Remove(generalization), Is.False);
                Assert.That(generalization.Specific, Is.SameAs(newOwner));
                Assert.That(generalization.Possessor, Is.SameAs(newOwner));
            }
        }

        [Test]
        public void Verify_that_removing_an_element_from_a_subsetting_composite_list_keeps_it_owned_by_the_container()
        {
            // Operation::precondition subsets Namespace::ownedRule (#492)
            var operation = new Operation { Name = "op" };
            var constraint = new Constraint { Name = "pre" };

            operation.OwnedRule.Add(constraint);
            operation.Precondition.Add(constraint);
            operation.Precondition.Remove(constraint);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(operation.OwnedRule, Is.EquivalentTo(new[] { constraint }));
                Assert.That(constraint.Owner, Is.SameAs(operation));
                Assert.That(constraint.Context, Is.SameAs(operation));
                Assert.That(operation.OwnedElement, Is.EquivalentTo(new IElement[] { constraint }));
            }

            operation.OwnedRule.Remove(constraint);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(constraint.Owner, Is.Null);
                Assert.That(constraint.Context, Is.Null);
                Assert.That(operation.OwnedElement, Is.Empty);
            }
        }

        [Test]
        public void Verify_that_RemoveAt_Clear_and_the_indexer_keep_an_element_owned_while_another_list_of_the_container_holds_it()
        {
            var operation = new Operation { Name = "op" };
            var first = new Constraint { Name = "first" };
            var second = new Constraint { Name = "second" };
            var third = new Constraint { Name = "third" };
            var replacement = new Constraint { Name = "replacement" };

            operation.OwnedRule.AddRange([first, second, third]);
            operation.Precondition.AddRange([first, second, third]);

            operation.Precondition.RemoveAt(0);
            operation.Precondition[0] = replacement;
            operation.Precondition.Clear();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(first.Owner, Is.SameAs(operation), "RemoveAt");
                Assert.That(second.Owner, Is.SameAs(operation), "indexer");
                Assert.That(third.Owner, Is.SameAs(operation), "Clear");
                Assert.That(replacement.Owner, Is.Null, "the replacement was only held by the cleared list");
            }
        }

        [Test]
        public void Verify_that_adding_an_element_to_another_container_moves_it()
        {
            var oldOwner = new Class { Name = "Old" };
            var newOwner = new Class { Name = "New" };
            var property = new Property { Name = "p" };

            oldOwner.OwnedAttribute.Add(property);
            newOwner.OwnedAttribute.Add(property);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(oldOwner.OwnedAttribute, Is.Empty);
                Assert.That(oldOwner.OwnedElement, Is.Empty);
                Assert.That(newOwner.OwnedAttribute, Is.EquivalentTo(new[] { property }));
                Assert.That(property.Owner, Is.SameAs(newOwner));
                Assert.That(property.Class, Is.SameAs(newOwner));
            }
        }

        [Test]
        public void Verify_that_moving_an_element_clears_the_owner_end_of_the_list_it_leaves()
        {
            // Class::ownedAttribute has owner end Property::class, Association::ownedEnd has Property::owningAssociation
            var @class = new Class { Name = "C" };
            var association = new Association { Name = "A" };
            var property = new Property { Name = "p" };

            @class.OwnedAttribute.Add(property);
            association.OwnedEnd.Add(property);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(@class.OwnedAttribute, Is.Empty);
                Assert.That(property.Class, Is.Null);
                Assert.That(property.OwningAssociation, Is.SameAs(association));
                Assert.That(property.Owner, Is.SameAs(association));
            }
        }

        [Test]
        public void Verify_that_moving_an_element_removes_it_from_every_list_of_the_previous_container()
        {
            var oldOperation = new Operation { Name = "old" };
            var newOperation = new Operation { Name = "new" };
            var constraint = new Constraint { Name = "pre" };

            oldOperation.OwnedRule.Add(constraint);
            oldOperation.Precondition.Add(constraint);
            newOperation.OwnedRule.Add(constraint);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(oldOperation.OwnedRule, Is.Empty);
                Assert.That(oldOperation.Precondition, Is.Empty);
                Assert.That(constraint.Owner, Is.SameAs(newOperation));
                Assert.That(constraint.Context, Is.SameAs(newOperation));
            }
        }

        [Test]
        public void Verify_that_a_failed_addition_does_not_move_the_element()
        {
            var oldOwner = new Constraint { Name = "old" };
            var newOwner = new Constraint { Name = "new" };
            var specification = new LiteralString { Value = "a" };
            var other = new LiteralString { Value = "b" };

            oldOwner.Specification.Add(specification);
            newOwner.Specification.Add(other);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => newOwner.Specification.Add(specification), Throws.InvalidOperationException, "Constraint::specification is [1..1]");
                Assert.That(oldOwner.Specification, Is.EquivalentTo(new[] { specification }));
                Assert.That(specification.Owner, Is.SameAs(oldOwner));
            }
        }

        [Test]
        public void Verify_that_the_indexer_moves_an_element_from_another_container()
        {
            var oldOwner = new Class { Name = "Old" };
            var newOwner = new Class { Name = "New" };
            var moved = new Property { Name = "moved" };
            var replaced = new Property { Name = "replaced" };

            oldOwner.OwnedAttribute.Add(moved);
            newOwner.OwnedAttribute.Add(replaced);

            ((ContainerList<IProperty>)newOwner.OwnedAttribute)[0] = moved;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(oldOwner.OwnedAttribute, Is.Empty);
                Assert.That(newOwner.OwnedAttribute, Is.EquivalentTo(new[] { moved }));
                Assert.That(moved.Owner, Is.SameAs(newOwner));
                Assert.That(replaced.Owner, Is.Null);
                Assert.That(replaced.Class, Is.Null);
            }
        }

        [Test]
        public void Verify_that_the_non_generic_IList_members_maintain_the_containment()
        {
            var @class = new Class { Name = "C" };
            var list = (System.Collections.IList)@class.Generalization;
            var first = new Generalization();
            var second = new Generalization();
            var third = new Generalization();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(list.Add(first), Is.EqualTo(0));
                Assert.That(first.Specific, Is.SameAs(@class), "IList.Add sets the owner end");
                Assert.That(first.Possessor, Is.SameAs(@class));
            }

            list.Insert(0, second);
            Assert.That(second.Specific, Is.SameAs(@class), "IList.Insert");

            list[0] = third;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(list[0], Is.SameAs(third));
                Assert.That(third.Specific, Is.SameAs(@class), "IList indexer sets the new element");
                Assert.That(second.Specific, Is.Null, "IList indexer clears the replaced element");
                Assert.That(second.Possessor, Is.Null);
            }

            list.Remove(third);
            list.Remove("not a generalization");
            Assert.That(third.Possessor, Is.Null, "IList.Remove");

            list.Add(second);
            list.RemoveAt(0);
            Assert.That(first.Possessor, Is.Null, "IList.RemoveAt");

            list.Clear();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(second.Possessor, Is.Null, "IList.Clear");
                Assert.That(@class.Generalization, Is.Empty);
                Assert.That(() => list.Add(new Class()), Throws.ArgumentException);
                Assert.That(() => list.Insert(0, "not a generalization"), Throws.ArgumentException);
                Assert.That(() => list.Add(null), Throws.ArgumentNullException);
            }
        }

        [Test]
        public void Verify_that_the_owner_ends_of_derived_composite_subsets_are_set_by_the_type_of_the_element()
        {
            // Package::ownedType and Package::nestedPackage are derived subsets of Package::packagedElement
            var package = new Package { Name = "P" };
            var nestedPackage = new Package { Name = "Nested" };
            var @class = new Class { Name = "C" };
            var instanceSpecification = new InstanceSpecification { Name = "i" };

            package.PackagedElement.Add(nestedPackage);
            package.PackagedElement.Add(@class);
            package.PackagedElement.Add(instanceSpecification);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(nestedPackage.NestingPackage, Is.SameAs(package));
                Assert.That(@class.Package, Is.SameAs(package), "Type::package, the owner end of Package::ownedType");
                Assert.That(package.NestedPackage, Is.EquivalentTo(new[] { nestedPackage }));
            }

            package.PackagedElement.Remove(nestedPackage);
            package.PackagedElement.Remove(@class);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(nestedPackage.NestingPackage, Is.Null);
                Assert.That(@class.Package, Is.Null);
            }
        }

        [Test]
        public void Verify_that_a_ContainerList_without_owner_end_actions_only_maintains_the_possessor()
        {
            var package = new Package();
            var containerList = new ContainerList<IPackageableElement>(package);
            var @class = new Class();

            containerList.Add(@class);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(@class.Possessor, Is.SameAs(package));
                Assert.That(@class.Package, Is.Null, "no owner end action was provided");
            }
        }

        [Test]
        public void Verify_that_a_bounded_ContainerList_rejects_an_upper_bound_below_1()
        {
            var package = new Package();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => new ContainerList<IPackageableElement>(package, "Package::packagedElement", 0), Throws.InstanceOf<ArgumentOutOfRangeException>());
                Assert.That(new ContainerList<IPackageableElement>(package).UpperBound, Is.EqualTo(int.MaxValue));
                Assert.That(new ContainerList<IPackageableElement>(package, "Package::packagedElement", 2).UpperBound, Is.EqualTo(2));
            }
        }

        [Test]
        public void Verify_that_a_single_valued_composite_property_rejects_a_second_value()
        {
            var constraint = new Constraint();
            var first = new LiteralString { XmiId = "first" };
            var second = new LiteralString { XmiId = "second" };

            constraint.Specification.Add(first);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => constraint.Specification.Add(second),
                    Throws.InvalidOperationException.With.Message.EqualTo("Constraint::specification holds at most 1 value(s); [second] cannot be added"));
                Assert.That(() => constraint.Specification.Insert(0, second), Throws.InvalidOperationException);
                Assert.That(() => constraint.Specification.AddRange([second]), Throws.InvalidOperationException);
                Assert.That(() => ((IList<IValueSpecification>)constraint.Specification).Insert(0, second), Throws.InvalidOperationException);
                Assert.That(constraint.Specification, Is.EqualTo(new[] { first }));
                Assert.That(second.Possessor, Is.Null, "a rejected element is not owned");
            }

            constraint.Specification[0] = second;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(constraint.Specification, Is.EqualTo(new[] { second }), "a value can be replaced");
                Assert.That(second.Possessor, Is.SameAs(constraint));
                Assert.That(first.Possessor, Is.Null);
            }

            constraint.Specification.Clear();
            constraint.Specification.Add(first);

            Assert.That(constraint.Specification, Is.EqualTo(new[] { first }), "a value can be added again once the property is empty");
        }

        [Test]
        public void Verify_that_a_single_valued_composite_property_with_an_owner_end_rejects_a_second_value()
        {
            var @class = new Class();
            var first = new RedefinableTemplateSignature { XmiId = "first" };
            var second = new RedefinableTemplateSignature { XmiId = "second" };

            @class.OwnedTemplateSignature.Add(first);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => @class.OwnedTemplateSignature.Add(second), Throws.InvalidOperationException.With.Message.Contains("Classifier::ownedTemplateSignature"));
                Assert.That(first.Classifier, Is.SameAs(@class));
                Assert.That(second.Classifier, Is.Null);
            }
        }

        [Test]
        public void Verify_that_a_multi_valued_composite_property_is_not_bounded()
        {
            var package = new Package();

            package.PackagedElement.AddRange([new Class(), new Class(), new Package()]);

            Assert.That(package.PackagedElement, Has.Count.EqualTo(3));
        }

        [Test]
        public void Verify_that_Insert_sets_the_possessor_and_the_owner_end()
        {
            var package = new Package();
            var first = new Class();
            var second = new Class();

            package.PackagedElement.Add(first);
            package.PackagedElement.Insert(0, second);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(package.PackagedElement, Is.EqualTo(new IPackageableElement[] { second, first }));
                Assert.That(second.Possessor, Is.SameAs(package));
                Assert.That(second.Package, Is.SameAs(package));
                Assert.That(() => package.PackagedElement.Insert(0, null), Throws.ArgumentNullException);
                Assert.That(() => package.PackagedElement.Insert(0, package), Throws.InvalidOperationException);
                Assert.That(() => package.PackagedElement.Insert(0, first), Throws.InvalidOperationException);
                Assert.That(() => package.PackagedElement.Insert(-1, new Class()), Throws.InstanceOf<ArgumentOutOfRangeException>());
                Assert.That(() => package.PackagedElement.Insert(3, new Class()), Throws.InstanceOf<ArgumentOutOfRangeException>());
            }
        }
    }
}
