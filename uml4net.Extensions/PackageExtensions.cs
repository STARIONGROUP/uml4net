// -------------------------------------------------------------------------------------------------
// <copyright file="PackageExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using uml4net.Packages;

    /// <summary>
    /// Extension methods for <see cref="IPackage"/> interface
    /// </summary>
    public static class PackageExtensions
    {
        /// <summary>
        /// Queries all the packages and subpackages recursively that are contained
        /// by the root package, including the root package itself.
        /// </summary>
        /// <param name="root">
        /// The root <see cref="IPackage"/>.
        /// </param>
        /// <returns>
        /// A ReadOnlyCollection of all the <see cref="IPackage"/>s that are contained
        /// recursively by the root <see cref="IPackage"/>, including the root package
        /// itself.
        /// </returns>
        public static ReadOnlyCollection<IPackage> QueryPackages(this IPackage root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            var result = new List<IPackage> { root };

            if (root.NestedPackage != null)
            {
                foreach (var subPackage in root.NestedPackage)
                {
                    result.AddRange(subPackage.QueryPackages());
                }
            }

            return result.AsReadOnly();
        }

        /// <summary>
        /// recursively queries all the nested and imported packages of the
        /// specified root <see cref="IPackage"/>
        /// </summary>
        /// <param name="root">
        /// The root <see cref="IPackage"/> for which the nested and imported
        /// <see cref="IPackage"/>s are queried
        /// </param>
        /// <returns>
        /// A readonly collection of <see cref="IPackage"/> including the root <see cref="IPackage"/>
        /// </returns>
        public static ReadOnlyCollection<IPackage> QueryAllNestedAndImportedPackages(this IPackage root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            var result = new List<IPackage>();
            var visited = new HashSet<IPackage>();
            var stack = new Stack<IPackage>();

            stack.Push(root);

            while (stack.Count > 0)
            {
                var current = stack.Pop();

                if (!visited.Add(current))
                {
                    continue; // already visited
                }

                foreach (var subPackage in current.QueryPackages())
                {
                    stack.Push(subPackage);
                }

                foreach (var packageImport in current.PackageImport)
                {
                    if (packageImport.ImportedPackage != null)
                    {
                        var importedPackage = packageImport.ImportedPackage;

                        stack.Push(importedPackage);

                        foreach (var subPackage in importedPackage.QueryPackages())
                        {
                            stack.Push(subPackage);
                        }
                    }
                }

                result.Add(current);
            }

            return result.AsReadOnly();
        }
    }
}
