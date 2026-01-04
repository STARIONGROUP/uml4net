// -------------------------------------------------------------------------------------------------
//  <copyright file="NamespaceExtensions.cs" company="Starion Group S.A.">
// 
//    Copyright (C) 2019-2026 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
//  </copyright>
//  ------------------------------------------------------------------------------------------------

namespace uml4net.CommonStructure
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The <see cref="NamespaceExtensions"/> class provides extensions methods for <see cref="INamespace"/>
    /// </summary>
    internal static class NamespaceExtensions
    {
        /// <summary>
        /// Queries the PackageableElements that are members of this Namespace as a result of either
        /// PackageImports or ElementImports.
        /// </summary>
        /// <param name="namespace">
        /// The subject <see cref="INamespace"/>
        /// </param>
        /// <returns>
        /// the PackageableElements that are members of this Namespace as a result of either
        /// PackageImports or ElementImports.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        internal static List<IPackageableElement> QueryImportedMember(this INamespace @namespace)
        {
            throw new NotSupportedException("Create a GitHub issue when this method is required");
        }
    }
}
