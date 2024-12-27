// -------------------------------------------------------------------------------------------------
// <copyright file="PackageExtensions.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2024 Starion Group S.A.
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
    using System.Collections.Generic;
    using System.Linq;

    using uml4net.CommonStructure;
    using uml4net.Utils;

    /// <summary>
    /// The <see cref="PackageExtensions"/> class provides extensions methods for <see cref="IPackage"/>
    /// </summary>
    public static class PackageExtensions
    {
        /// <summary>
        /// Retrieves a collection of nested <see cref="IPackage"/> elements contained within the specified <paramref name="package"/>.
        /// </summary>
        /// <param name="package">The <see cref="IPackage"/> whose nested packages are to be retrieved.</param>
        /// <returns>
        /// A <see cref="List{T}"/> of <see cref="IPackage"/> elements representing the nested packages 
        /// within the specified <paramref name="package"/>.
        /// </returns>
        public static IContainerList<IPackage> QueryNestedPackage(this IPackage package)
        {
            Guard.ThrowIfNull(package);

            var containerList = new ContainerList<IPackage>(package);

            foreach (var packageableElement in package.PackagedElement.OfType<IPackage>())
            {
                containerList.Add(packageableElement);
            }

            return containerList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="package">
        /// The subject <see cref="IPackage"/>
        /// </param>
        /// <returns>
        ///
        /// </returns>
        public static IContainerList<IStereotype> QueryOwnedStereotype(this IPackage package)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="package">
        /// The subject <see cref="IPackage"/>
        /// </param>
        /// <returns>
        ///
        /// </returns>
        public static IContainerList<IType> QueryOwnedType(this IPackage package)
        {
            throw new NotImplementedException();
        }
    }
}
