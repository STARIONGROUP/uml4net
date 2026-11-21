// -------------------------------------------------------------------------------------------------
// <copyright file="MessageExtensionsTestFixture.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
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
