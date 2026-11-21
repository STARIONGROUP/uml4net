// -------------------------------------------------------------------------------------------------
// <copyright file="ProtocolTransitionExtensions.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.StateMachines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using uml4net.Classification;
    using uml4net.CommonBehavior;

    /// <summary>
    /// The <see cref="ProtocolTransitionExtensions"/> class provides extensions methods for <see cref="IProtocolTransition"/>
    /// </summary>
    internal static class ProtocolTransitionExtensions
    {
        /// <summary>
        /// Queries the association refers to the associated Operation. It is derived from the Operation of the
        /// CallEvent Trigger when applicable. Per the UML 2.5.1 metamodel this is derived as:
        /// <c>trigger->collect(event)->select(oclIsKindOf(CallEvent))->collect(oclAsType(CallEvent).operation)->asSet()</c>.
        /// </summary>
        /// <param name="protocolTransition">
        /// The subject <see cref="IProtocolTransition"/>
        /// </param>
        /// <returns>
        /// The association refers to the associated Operation. It is derived from the Operation of the
        /// CallEvent Trigger when applicable.
        /// </returns>
        internal static List<IOperation> QueryReferred(this IProtocolTransition protocolTransition)
        {
            if (protocolTransition == null)
            {
                throw new ArgumentNullException(nameof(protocolTransition));
            }

            return protocolTransition.Trigger
                .Select(trigger => trigger.Event)
                .OfType<ICallEvent>()
                .Select(callEvent => callEvent.Operation)
                .Distinct()
                .ToList();
        }
    }
}
