// -------------------------------------------------------------------------------------------------
// <copyright file="TransitionExtensions.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.StateMachines
{
    using System;

    using uml4net.Classification;

    /// <summary>
    /// The <see cref="TransitionExtensions"/> class provides extensions methods for <see cref="ITransition"/>
    /// </summary>
    internal static class TransitionExtensions
    {
        /// <summary>
        /// References the Classifier in which context this element may be redefined.
        /// </summary>
        /// <param name="transition">
        /// The subject <see cref="ITransition"/>
        /// </param>
        /// <returns>
        /// The Classifier in which context this element may be redefined, the state machine that contains the
        /// <see cref="ITransition.Container"/>; null when the transition has no container region, for example a
        /// transition that is not (yet) owned (UML 2.5.1: container.containingStateMachine() is undefined)
        /// </returns>
        internal static IClassifier QueryRedefinitionContext(this ITransition transition)
        {
            if (transition == null)
            {
                throw new ArgumentNullException(nameof(transition));
            }

            return transition.Container?.QueryContainingStateMachine();
        }
    }
}
