// -------------------------------------------------------------------------------------------------
//  <copyright file="ExtensionExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.Packages
{
    using System;
    
    using uml4net.StructuredClassifiers;

    /// <summary>
    /// The <see cref="ExtensionExtensions"/> class provides extensions methods for <see cref="IExtension"/>
    /// </summary>
    internal static class ExtensionExtensions
    {
        /// <summary>
        /// Queries whether an instance of the extending stereotype must be created when an instance of the
        /// extended class is created. The attribute value is derived from the value of the lower property of
        /// the ExtensionEnd referenced by Extension::ownedEnd; a lower value of 1 means that isRequired is
        /// true, but otherwise it is false. Since the default value of ExtensionEnd::lower is 0, the default
        /// value of isRequired is false.
        /// </summary>
        /// <param name="extension">
        /// The subject <see cref="IExtension"/>
        /// </param>
        /// <returns>
        /// whether an instance of the extending stereotype must be created when an instance of the
        /// extended class is created. The attribute value is derived from the value of the lower property of
        /// the ExtensionEnd referenced by Extension::ownedEnd; a lower value of 1 means that isRequired is
        /// true, but otherwise it is false. Since the default value of ExtensionEnd::lower is 0, the default
        /// value of isRequired is false.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        internal static bool QueryIsRequired(this IExtension extension)
        {
            throw new NotSupportedException("Create a GitHub issue when this method is required");
        }

        /// <summary>
        /// Queries the Class that is extended through an Extension. The property is derived from the type of
        /// the memberEnd that is not the ownedEnd.
        /// </summary>
        /// <param name="extension">
        /// The subject <see cref="IExtension"/>
        /// </param>
        /// <returns>
        /// the Class that is extended through an Extension. The property is derived from the type of
        /// the memberEnd that is not the ownedEnd.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        internal static IClass QueryMetaclass(this IExtension extension)
        {
            throw new NotSupportedException("Create a GitHub issue when this method is required");
        }
    }
}
