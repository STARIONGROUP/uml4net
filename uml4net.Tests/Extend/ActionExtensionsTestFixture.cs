// -------------------------------------------------------------------------------------------------
// <copyright file="ActionExtensionsTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.Tests.Extend
{
    using NUnit.Framework;

    using uml4net.Actions;
    using uml4net.Activities;
    using uml4net.StructuredClassifiers;

    [TestFixture]
    public class ActionExtensionsTestFixture
    {
        [Test]
        public void Verify_that_when_action_is_null_argument_exception_is_thrown()
        {
            CallOperationAction action = null;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => ActionExtensions.QueryContext(action), Throws.ArgumentNullException);
                Assert.That(() => ActionExtensions.QueryInput(action), Throws.ArgumentNullException);
                Assert.That(() => ActionExtensions.QueryOutput(action), Throws.ArgumentNullException);
            }
        }

        [Test]
        public void Verify_that_Context_returns_null_when_the_action_has_neither_an_Activity_nor_a_containing_StructuredActivityNode()
        {
            var action = new CallOperationAction();

            Assert.That(action.Context, Is.Null);
        }

        [Test]
        public void Verify_that_Context_is_resolved_through_the_directly_containing_Activity()
        {
            var owningClass = new Class { Name = "Owner" };
            var activity = new Activity { Name = "Activity" };
            owningClass.OwnedBehavior.Add(activity);

            var action = new CallOperationAction { Activity = activity };

            Assert.That(action.Context, Is.SameAs(owningClass));
        }

        [Test]
        public void Verify_that_Context_is_resolved_through_a_containing_StructuredActivityNode()
        {
            var owningClass = new Class { Name = "Owner" };
            var activity = new Activity { Name = "Activity" };
            owningClass.OwnedBehavior.Add(activity);

            var structuredActivityNode = new StructuredActivityNode { Activity = activity };

            var action = new CallOperationAction { InStructuredNode = structuredActivityNode };

            Assert.That(action.Context, Is.SameAs(owningClass));
        }

        [Test]
        public void Verify_that_Input_unions_the_pins_of_every_subsetting_property()
        {
            var argument = new InputPin { Name = "argument" };
            var target = new InputPin { Name = "target" };

            var action = new CallOperationAction();
            action.Argument.Add(argument);
            action.Target.Add(target);

            Assert.That(action.Input, Is.EquivalentTo(new[] { argument, target }));
        }

        [Test]
        public void Verify_that_Input_is_empty_when_no_subsetting_property_has_pins()
        {
            var action = new CallOperationAction();

            Assert.That(action.Input, Is.Empty);
        }

        [Test]
        public void Verify_that_Output_unions_the_pins_of_every_subsetting_property()
        {
            var result = new OutputPin { Name = "result" };

            var action = new CallOperationAction();
            action.Result.Add(result);

            Assert.That(action.Output, Is.EquivalentTo(new[] { result }));
        }
    }
}
