// -------------------------------------------------------------------------------------------------
// <copyright file="ProtocolTransitionExtensionsTestFixture.cs" company="Starion Group S.A.">
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

    using uml4net.Classification;
    using uml4net.CommonBehavior;
    using uml4net.StateMachines;

    [TestFixture]
    public class ProtocolTransitionExtensionsTestFixture
    {
        [Test]
        public void Verify_that_when_protocolTransition_is_null_argument_exception_is_thrown()
        {
            ProtocolTransition protocolTransition = null;

            Assert.That(() => ProtocolTransitionExtensions.QueryReferred(protocolTransition), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_Referred_is_empty_when_there_are_no_triggers()
        {
            var protocolTransition = new ProtocolTransition();

            Assert.That(protocolTransition.Referred, Is.Empty);
        }

        [Test]
        public void Verify_that_Referred_ignores_triggers_whose_event_is_not_a_CallEvent()
        {
            var protocolTransition = new ProtocolTransition();
            protocolTransition.Trigger.Add(new Trigger { Event = new SignalEvent() });

            Assert.That(protocolTransition.Referred, Is.Empty);
        }

        [Test]
        public void Verify_that_Referred_returns_the_operations_of_the_CallEvent_triggers()
        {
            var operation1 = new Operation { Name = "Operation1" };
            var operation2 = new Operation { Name = "Operation2" };

            var protocolTransition = new ProtocolTransition();
            protocolTransition.Trigger.Add(new Trigger { Event = new CallEvent { Operation = operation1 } });
            protocolTransition.Trigger.Add(new Trigger { Event = new SignalEvent() });
            protocolTransition.Trigger.Add(new Trigger { Event = new CallEvent { Operation = operation2 } });

            Assert.That(protocolTransition.Referred, Is.EquivalentTo(new[] { operation1, operation2 }));
        }

        [Test]
        public void Verify_that_Referred_is_deduplicated_across_triggers()
        {
            var operation = new Operation { Name = "Operation" };

            var protocolTransition = new ProtocolTransition();
            protocolTransition.Trigger.Add(new Trigger { Event = new CallEvent { Operation = operation } });
            protocolTransition.Trigger.Add(new Trigger { Event = new CallEvent { Operation = operation } });

            Assert.That(protocolTransition.Referred, Is.EquivalentTo(new[] { operation }));
        }
    }
}
