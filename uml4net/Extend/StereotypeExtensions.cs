// -------------------------------------------------------------------------------------------------
// <copyright file="StereotypeExtensions.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Packages
{
    using System;

    /// <summary>
    /// The <see cref="StereotypeExtensions"/> class provides extensions methods for <see cref="IStereotype"/>
    /// </summary>
    internal static class StereotypeExtensions
    {
        /// <summary>
        /// Queries the profile that directly or indirectly contains this stereotype.
        /// </summary>
        /// <param name="stereotype">
        /// The subject <see cref="IStereotype"/>
        /// </param>
        /// <returns>
        /// The profile that directly or indirectly contains this stereotype; null when no owner of the stereotype is a
        /// profile, for example a stereotype that is not (yet) owned (UML 2.5.1: containingProfile() is undefined)
        /// </returns>
        internal static IProfile QueryProfile(this IStereotype stereotype)
        {
            if (stereotype == null)
            {
                throw new ArgumentNullException(nameof(stereotype));
            }

            var owner = stereotype.Owner;

            while (owner != null && owner is not IProfile)
            {
                owner = owner.Owner;
            }

            return owner as IProfile;
        }
    }
}
