// -------------------------------------------------------------------------------------------------
// <copyright file="StateExtensionsTestFixture.cs" company="Starion Group S.A.">
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

    using uml4net.StateMachines;

    [TestFixture]
    public class StateExtensionsTestFixture
    {
        [Test]
        public void Verify_that_when_state_is_null_argument_exception_is_thrown()
        {
            State state = null;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => StateExtensions.QueryIsComposite(state), Throws.ArgumentNullException);
                Assert.That(() => StateExtensions.QueryIsSimple(state), Throws.ArgumentNullException);
                Assert.That(() => StateExtensions.QueryIsSubmachineState(state), Throws.ArgumentNullException);
                Assert.That(() => StateExtensions.QueryIsOrthogonal(state), Throws.ArgumentNullException);
            }
        }

        [Test]
        public void Verify_that_a_state_with_no_regions_and_no_submachine_is_simple()
        {
            var state = new State { Name = "Simple" };

            using (Assert.EnterMultipleScope())
            {
                Assert.That(state.IsComposite, Is.False);
                Assert.That(state.IsSimple, Is.True);
                Assert.That(state.IsSubmachineState, Is.False);
                Assert.That(state.IsOrthogonal, Is.False);
            }
        }

        [Test]
        public void Verify_that_a_state_with_one_region_is_composite_but_not_orthogonal()
        {
            var state = new State { Name = "Composite" };
            state.Region.Add(new Region { Name = "R1" });

            using (Assert.EnterMultipleScope())
            {
                Assert.That(state.IsComposite, Is.True);
                Assert.That(state.IsSimple, Is.False);
                Assert.That(state.IsSubmachineState, Is.False);
                Assert.That(state.IsOrthogonal, Is.False);
            }
        }

        [Test]
        public void Verify_that_a_state_with_two_regions_is_orthogonal()
        {
            var state = new State { Name = "Orthogonal" };
            state.Region.Add(new Region { Name = "R1" });
            state.Region.Add(new Region { Name = "R2" });

            using (Assert.EnterMultipleScope())
            {
                Assert.That(state.IsComposite, Is.True);
                Assert.That(state.IsSimple, Is.False);
                Assert.That(state.IsSubmachineState, Is.False);
                Assert.That(state.IsOrthogonal, Is.True);
            }
        }

        [Test]
        public void Verify_that_a_state_with_a_submachine_is_composite_and_a_submachineState()
        {
            var state = new State { Name = "Submachine", Submachine = new StateMachine { Name = "SM" } };

            using (Assert.EnterMultipleScope())
            {
                Assert.That(state.IsComposite, Is.True);
                Assert.That(state.IsSimple, Is.False);
                Assert.That(state.IsSubmachineState, Is.True);
                Assert.That(state.IsOrthogonal, Is.False);
            }
        }
    }
}
