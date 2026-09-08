// -------------------------------------------------------------------------------------------------
// <copyright file="TransitionExtensionsTestFixture.cs" company="Starion Group S.A.">
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
    public class TransitionExtensionsTestFixture
    {
        [Test]
        public void Verify_that_when_transition_is_null_argument_null_exception_is_thrown()
        {
            Transition transition = null;

            Assert.That(() => TransitionExtensions.QueryRedefinitionContext(transition), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_RedefinitionContext_returns_the_containing_stateMachine_of_its_container_region()
        {
            var stateMachine = new StateMachine { Name = "SM" };
            var region = new Region { Name = "R", StateMachine = stateMachine };

            var source = new State { Name = "Source", Container = region };
            var target = new State { Name = "Target", Container = region };

            var transition = new Transition { Name = "T", Source = source, Target = target, Container = region };

            Assert.That(transition.RedefinitionContext, Is.SameAs(stateMachine));
        }
    }
}
