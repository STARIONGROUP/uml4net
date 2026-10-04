// -------------------------------------------------------------------------------------------------
// <copyright file="StereotypeExtensions.cs" company="Starion Group S.A.">
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
