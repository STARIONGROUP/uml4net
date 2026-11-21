// -------------------------------------------------------------------------------------------------
// <copyright file="TransitionExtensionsTestFixture.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Tests.Extend
{
    using NUnit.Framework;

    using uml4net.Classification;
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

        [Test]
        public void Verify_that_RedefinitionContext_is_null_when_the_transition_has_no_container_region()
        {
            var transition = new Transition { Name = "T" };
            var protocolTransition = new ProtocolTransition { Name = "PT" };
            var orphanRegion = new Region { Name = "R" };
            var transitionInOrphanRegion = new Transition { Name = "T2", Container = orphanRegion };

            using (Assert.EnterMultipleScope())
            {
                Assert.That(transition.RedefinitionContext, Is.Null);
                Assert.That(((IRedefinableElement)transition).RedefinitionContext, Is.Empty);
                Assert.That(protocolTransition.RedefinitionContext, Is.Null);
                Assert.That(((IRedefinableElement)protocolTransition).RedefinitionContext, Is.Empty);
                Assert.That(transitionInOrphanRegion.RedefinitionContext, Is.Null, "a region that is not owned by a state machine or a state");
            }
        }
    }
}
