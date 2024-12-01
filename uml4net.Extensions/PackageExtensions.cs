// -------------------------------------------------------------------------------------------------
// <copyright file="PackageExtensions.cs" company="Starion Group S.A.">
//
//   Copyright 2019-2024 Starion Group S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, softwareUseCases
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Extensions
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using uml4net.Packages;

    /// <summary>
    /// Extension methods for <see cref="IPackage"/> interface
    /// </summary>
    public static class PackageExtensions
    {
        /// <summary>
        /// Queries all the packages and subpackages recursively that are contained
        /// by the root package
        /// </summary>
        /// <param name="root">
        /// The root <see cref="IPackage"/>
        /// </param>
        /// <returns>
        /// A  ReadOnlyCollection of all the <see cref="IPackage"/>s that are contained
        /// recursively by the root <see cref="IPackage"/>
        /// </returns>
        public static ReadOnlyCollection<IPackage> QueryPackages(this IPackage root)
        {
            var result = new List<IPackage>();

            if (root == null)
            {
                return result.AsReadOnly();
            }

            result.Add(root);

            if (root.NestedPackage != null)
            {
                foreach (var subPackage in root.NestedPackage)
                {
                    result.AddRange(subPackage.QueryPackages());
                }
            }

            return result.AsReadOnly();
        }
    }
}
