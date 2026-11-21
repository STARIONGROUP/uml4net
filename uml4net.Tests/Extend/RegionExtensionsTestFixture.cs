// -------------------------------------------------------------------------------------------------
// <copyright file="RegionExtensionsTestFixture.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Tests.Extend
{
    using NUnit.Framework;

    using uml4net.StateMachines;

    [TestFixture]
    public class RegionExtensionsTestFixture
    {
        [Test]
        public void Verify_that_when_region_is_null_argument_null_exception_is_thrown()
        {
            Region region = null;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => RegionExtensions.QueryContainingStateMachine(region), Throws.ArgumentNullException);
                Assert.That(() => RegionExtensions.QueryRedefinitionContext(region), Throws.ArgumentNullException);
            }
        }

        [Test]
        public void Verify_that_RedefinitionContext_returns_the_containing_stateMachine()
        {
            var stateMachine = new StateMachine { Name = "SM" };
            var region = new Region { Name = "R", StateMachine = stateMachine };

            Assert.That(region.RedefinitionContext, Is.SameAs(stateMachine));
        }

        [Test]
        public void Verify_that_QueryContainingStateMachine_returns_its_own_stateMachine_when_set()
        {
            var stateMachine = new StateMachine { Name = "SM" };
            var region = new Region { Name = "R", StateMachine = stateMachine };

            Assert.That(RegionExtensions.QueryContainingStateMachine(region), Is.SameAs(stateMachine));
        }

        [Test]
        public void Verify_that_QueryContainingStateMachine_recurses_through_its_owning_state_when_stateMachine_is_not_set()
        {
            var stateMachine = new StateMachine { Name = "SM" };
            var topRegion = new Region { Name = "TopRegion", StateMachine = stateMachine };

            var compositeState = new State { Name = "Composite", Container = topRegion };
            var nestedRegion = new Region { Name = "NestedRegion", State = compositeState };

            Assert.That(RegionExtensions.QueryContainingStateMachine(nestedRegion), Is.SameAs(stateMachine));
        }

        [Test]
        public void Verify_that_QueryContainingStateMachine_returns_null_when_neither_stateMachine_nor_state_is_set()
        {
            var region = new Region { Name = "Orphan" };

            Assert.That(RegionExtensions.QueryContainingStateMachine(region), Is.Null);
        }
    }
}
