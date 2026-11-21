// -------------------------------------------------------------------------------------------------
// <copyright file="BehaviorExtensionsTestFixture.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Tests.Extend
{
    using NUnit.Framework;

    using uml4net.Activities;
    using uml4net.CommonBehavior;
    using uml4net.StructuredClassifiers;

    [TestFixture]
    public class BehaviorExtensionsTestFixture
    {
        [Test]
        public void Verify_that_when_behavior_is_null_argument_exception_is_thrown()
        {
            Activity behavior = null;

            Assert.That(() => BehaviorExtensions.QueryContext(behavior), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_Context_returns_null_when_the_behavior_has_no_owner()
        {
            var behavior = new Activity();

            Assert.That(behavior.Context, Is.Null);
        }

        [Test]
        public void Verify_that_Context_returns_null_when_the_behavior_is_directly_owned_as_a_nestedClassifier()
        {
            var owningClass = new Class { Name = "Owner" };
            var behavior = new Activity { Name = "Nested" };

            owningClass.NestedClassifier.Add(behavior);

            Assert.That(behavior.Context, Is.Null);
        }

        [Test]
        public void Verify_that_Context_returns_the_first_BehavioredClassifier_found_by_walking_the_owner_chain()
        {
            var owningClass = new Class { Name = "Owner" };
            var behavior = new Activity { Name = "Activity" };

            owningClass.OwnedBehavior.Add(behavior);

            Assert.That(behavior.Context, Is.SameAs(owningClass));
        }

        [Test]
        public void Verify_that_Context_defers_to_the_context_of_an_ancestor_Behavior_with_a_non_empty_context()
        {
            var owningClass = new Class { Name = "Owner" };
            var outerActivity = new Activity { Name = "Outer" };
            owningClass.OwnedBehavior.Add(outerActivity);

            var innerBehavior = new Activity { Name = "Inner" };
            outerActivity.OwnedBehavior.Add(innerBehavior);

            Assert.That(innerBehavior.Context, Is.SameAs(owningClass));
        }

        [Test]
        public void Verify_that_Context_returns_the_ancestor_Behavior_itself_when_its_own_context_is_empty()
        {
            var outerActivity = new Activity { Name = "Outer" };

            var innerBehavior = new Activity { Name = "Inner" };
            outerActivity.OwnedBehavior.Add(innerBehavior);

            Assert.That(innerBehavior.Context, Is.SameAs(outerActivity));
        }
    }
}
