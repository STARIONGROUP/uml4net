// -------------------------------------------------------------------------------------------------
//  <copyright file="XmiReaderResult.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Readers
{
    using System.Collections.Generic;

    using uml4net.Packages;

    /// <summary>
    /// The purpose of the <see cref="XmiReaderResult"/> is capture the result of reading a UML model
    /// from an XMI file (which may reference other XMI files or resources)
    /// </summary>
    public class XmiReaderResult
    {
        /// <summary>
        /// Gets or sets the root <see cref="IPackage"/>. This is the <see cref="IPackage"/> that is the container
        /// of the UML model file that was initially read
        /// </summary>
        public IPackage Root { get; set; }

        /// <summary>
        /// Gets or sets all the <see cref="IPackage"/>s that have been read, this includes the <see cref="Root"/>
        /// </summary>
        public List<IPackage> Packages { get; set; } = new ();
    }
}
