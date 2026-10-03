// -------------------------------------------------------------------------------------------------
// <copyright file="StereoTypeApplicationExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.Profiling
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using uml4net.Packages;

    /// <summary>
    /// Extension methods to query the <see cref="IStereotype"/>s applied to an element and their tagged values
    /// </summary>
    public static class StereoTypeApplicationExtensions
    {
        /// <summary>
        /// Queries the <see cref="StereoTypeApplication"/>s of the stereotypes that are applied to the provided element
        /// </summary>
        /// <param name="xmiElement">
        /// The <see cref="IXmiElement"/> whose stereotype applications are queried
        /// </param>
        /// <returns>
        /// The <see cref="StereoTypeApplication"/>s, in the order in which they were read; empty when no stereotype is
        /// applied, or when the element has no <see cref="IXmiElement.Cache"/>
        /// </returns>
        /// <remarks>
        /// The stereotype applications of a document are registered with the element that they extend when the
        /// document is read; the <see cref="StereoTypeApplication.Stereotype"/> of an application is null when its profile
        /// is not available
        /// </remarks>
        public static IReadOnlyList<StereoTypeApplication> QueryStereoTypeApplications(this IXmiElement xmiElement)
        {
            if (xmiElement == null)
            {
                throw new ArgumentNullException(nameof(xmiElement));
            }

            if (xmiElement.Cache != null && xmiElement.Cache.TryGetStereoTypeApplications(xmiElement, out var stereoTypeApplications))
            {
                return stereoTypeApplications.ToList();
            }

            return [];
        }

        /// <summary>
        /// Queries the <see cref="StereoTypeApplication"/> of the stereotype with the provided name that is applied to the
        /// provided element
        /// </summary>
        /// <param name="xmiElement">
        /// The <see cref="IXmiElement"/> whose stereotype application is queried
        /// </param>
        /// <param name="stereoTypeName">
        /// The name of the stereotype, for example <c>Block</c>
        /// </param>
        /// <returns>
        /// The first <see cref="StereoTypeApplication"/> of that stereotype, or null when it is not applied
        /// </returns>
        public static StereoTypeApplication QueryStereoTypeApplication(this IXmiElement xmiElement, string stereoTypeName)
        {
            if (string.IsNullOrEmpty(stereoTypeName))
            {
                throw new ArgumentException("The name of the stereotype is to be provided", nameof(stereoTypeName));
            }

            return xmiElement.QueryStereoTypeApplications().FirstOrDefault(x => (x.Stereotype?.Name ?? x.StereoTypeName) == stereoTypeName);
        }

        /// <summary>
        /// Queries the <see cref="TaggedValue"/> of the property with the provided name
        /// </summary>
        /// <param name="stereoTypeApplication">
        /// The <see cref="StereoTypeApplication"/> whose tagged value is queried
        /// </param>
        /// <param name="name">
        /// The name of the property of the stereotype, for example <c>isEncapsulated</c>
        /// </param>
        /// <returns>
        /// The <see cref="TaggedValue"/>, or null when the application has no value for that property
        /// </returns>
        public static TaggedValue QueryTaggedValue(this StereoTypeApplication stereoTypeApplication, string name)
        {
            if (stereoTypeApplication == null)
            {
                throw new ArgumentNullException(nameof(stereoTypeApplication));
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("The name of the property is to be provided", nameof(name));
            }

            return stereoTypeApplication.TaggedValues.FirstOrDefault(x => (x.Property?.Name ?? x.Name) == name);
        }
    }
}
