// -------------------------------------------------------------------------------------------------
// <copyright file="MessageExtensions.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Interactions
{
    using System;

    /// <summary>
    /// The <see cref="MessageExtensions"/> class provides extensions methods for <see cref="IMessage"/>
    /// </summary>
    internal static class MessageExtensions
    {
        /// <summary>
        /// Queries The derived kind of the Message (complete, lost, found, or unknown).
        /// </summary>
        /// <param name="message">
        /// The subject <see cref="IMessage"/>
        /// </param>
        /// <returns>
        /// The derived kind of the Message (complete, lost, found, or unknown).
        /// </returns>
        internal static MessageKind QueryMessageKind(this IMessage message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            if (message.SendEvent != null && message.ReceiveEvent != null)
            {
                return MessageKind.Complete;
            }

            if (message.SendEvent != null)
            {
                return MessageKind.Lost;
            }

            if (message.ReceiveEvent != null)
            {
                return MessageKind.Found;
            }

            return MessageKind.Unknown;
        }
    }
}
