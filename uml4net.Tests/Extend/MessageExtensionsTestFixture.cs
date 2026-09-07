// -------------------------------------------------------------------------------------------------
// <copyright file="MessageExtensionsTestFixture.cs" company="Starion Group S.A.">
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

    using uml4net.Interactions;

    [TestFixture]
    public class MessageExtensionsTestFixture
    {
        [Test]
        public void Verify_that_when_message_is_null_argument_exception_is_thrown()
        {
            Message message = null;

            Assert.That(() => MessageExtensions.QueryMessageKind(message), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_MessageKind_is_complete_when_both_ends_are_set()
        {
            var message = new Message
            {
                SendEvent = new MessageOccurrenceSpecification(),
                ReceiveEvent = new MessageOccurrenceSpecification()
            };

            Assert.That(message.MessageKind, Is.EqualTo(MessageKind.Complete));
        }

        [Test]
        public void Verify_that_MessageKind_is_lost_when_only_sendEvent_is_set()
        {
            var message = new Message
            {
                SendEvent = new MessageOccurrenceSpecification()
            };

            Assert.That(message.MessageKind, Is.EqualTo(MessageKind.Lost));
        }

        [Test]
        public void Verify_that_MessageKind_is_found_when_only_receiveEvent_is_set()
        {
            var message = new Message
            {
                ReceiveEvent = new MessageOccurrenceSpecification()
            };

            Assert.That(message.MessageKind, Is.EqualTo(MessageKind.Found));
        }

        [Test]
        public void Verify_that_MessageKind_is_unknown_when_neither_end_is_set()
        {
            var message = new Message();

            Assert.That(message.MessageKind, Is.EqualTo(MessageKind.Unknown));
        }
    }
}
