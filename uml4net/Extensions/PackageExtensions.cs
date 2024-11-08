// -------------------------------------------------------------------------------------------------
//  <copyright file="ElementExtensions.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2024 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, softwareUseCases
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
//  </copyright>
//  ------------------------------------------------------------------------------------------------

namespace uml4net.Extensions
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using uml4net.POCO.Packages;

    /// <summary>
    /// Extension methods for <see cref="IPackage"/> interface
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
        public static List<IPackage> QueryNestedPackage(this IPackage package)
            => package.PackagedElement.OfType<IPackage>().ToList();
    }
}
