// -------------------------------------------------------------------------------------------------
// <copyright file="StateExtensions.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.StateMachines
{
    using System;

    /// <summary>
    /// The <see cref="StateExtensions"/> class provides extensions methods for <see cref="IState"/>
    /// </summary>
    internal static class StateExtensions
    {
        /// <summary>
        /// Queries a state with isComposite=true is said to be a composite State. A composite State is a State that
        /// contains at least one Region.
        /// </summary>
        /// <param name="state">
        /// The subject <see cref="IState"/>
        /// </param>
        /// <returns>
        /// A state with isComposite=true is said to be a composite State. A composite State is a State that
        /// contains at least one Region.
        /// </returns>
        internal static bool QueryIsComposite(this IState state)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }

            return state.Region.Count > 0;
        }

        /// <summary>
        /// Queries a State with isSimple=true is said to be a simple State A simple State does not have any Regions and
        /// it does not refer to any submachine StateMachine.
        /// </summary>
        /// <param name="state">
        /// The subject <see cref="IState"/>
        /// </param>
        /// <returns>
        /// A State with isSimple=true is said to be a simple State A simple State does not have any Regions and
        /// it does not refer to any submachine StateMachine.
        /// </returns>
        internal static bool QueryIsSimple(this IState state)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }

            return state.Region.Count == 0 && !state.QueryIsSubmachineState();
        }

        /// <summary>
        /// Queries A State with isSubmachineState=true is said to be a submachine State Such a State refers to another
        /// StateMachine(submachine).
        /// </summary>
        /// <param name="state">
        /// The subject <see cref="IState"/>
        /// </param>
        /// <returns>
        /// A State with isSubmachineState=true is said to be a submachine State Such a State refers to another
        /// StateMachine(submachine).
        /// </returns>
        internal static bool QueryIsSubmachineState(this IState state)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }

            return state.Submachine != null;
        }

        /// <summary>
        /// Queries A State with isOrthogonal=true is said to be an orthogonal composite State An orthogonal composite
        /// State contains two or more Regions.
        /// </summary>
        /// <param name="state">
        /// The subject <see cref="IState"/>
        /// </param>
        /// <returns>
        /// A State with isOrthogonal=true is said to be an orthogonal composite State An orthogonal composite
        /// State contains two or more Regions.
        /// </returns>
        internal static bool QueryIsOrthogonal(this IState state)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }

            return state.Region.Count > 1;
        }
    }
}
