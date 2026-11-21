// -------------------------------------------------------------------------------------------------
// <copyright file="RegionExtensions.cs" company="Starion Group S.A.">
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
    /// The <see cref="RegionExtensions"/> class provides extensions methods for <see cref="IRegion"/>
    /// </summary>
    internal static class RegionExtensions
    {
        /// <summary>
        /// Queries the Classifier in which context this element may be redefined.
        /// </summary>
        /// <param name="region">
        /// The subject <see cref="IRegion"/>
        /// </param>
        /// <returns>
        /// The Classifier in which context this element may be redefined.
        /// </returns>
        internal static IClassifier QueryRedefinitionContext(this IRegion region)
        {
            if (region == null)
            {
                throw new ArgumentNullException(nameof(region));
            }

            return region.QueryContainingStateMachine();
        }

        /// <summary>
        /// Queries the nearest containing <see cref="IStateMachine"/> of the <paramref name="region"/>: its own
        /// <see cref="IRegion.StateMachine"/> when owned directly by one, otherwise the containing StateMachine
        /// of the <see cref="IState"/> that owns it.
        /// </summary>
        /// <param name="region">
        /// The subject <see cref="IRegion"/>
        /// </param>
        /// <returns>
        /// The nearest containing <see cref="IStateMachine"/>, or null when none can be determined.
        /// </returns>
        internal static IStateMachine QueryContainingStateMachine(this IRegion region)
        {
            if (region == null)
            {
                throw new ArgumentNullException(nameof(region));
            }

            return region.StateMachine ?? region.State?.QueryContainingStateMachine();
        }
    }
}
