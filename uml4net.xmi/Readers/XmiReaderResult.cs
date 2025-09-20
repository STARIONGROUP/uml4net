// -------------------------------------------------------------------------------------------------
//  <copyright file="XmiReaderResult.cs" company="Starion Group S.A.">
// 
//    Copyright (C) 2019-2025 Starion Group S.A.
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

namespace uml4net.xmi.Readers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using uml4net.Packages;

    using uml4net.xmi.Xmi;

    /// <summary>
    /// The purpose of the <see cref="XmiReaderResult"/> is capture the result of reading a UML model
    /// from an XMI file (which may reference other XMI files or resources)
    /// </summary>
    public class XmiReaderResult
    {
        /// <summary>
        /// Queries the root package with the specified ID
        /// </summary>
        /// <param name="xmiId">
        /// The XmiId of the <see cref="IPackage"/> that is queried
        /// </param>
        /// <param name="name">
        /// the name of the package that is queried
        /// </param>
        /// <returns>
        /// An instance of <see cref="IPackage"/>
        /// </returns>
        public IPackage QueryRoot(string xmiId, string name = null)
        {
            if (string.IsNullOrEmpty(xmiId) && string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException($"xmiId and name shall not both be null or empty");
            }

            if (string.IsNullOrEmpty(xmiId))
            {
                return this.Packages.Single(x => x.Name == name);
            }

            if (string.IsNullOrEmpty(name))
            {
                return this.Packages.Single(x => x.XmiId == xmiId);
            }

            return this.Packages.Single(x => x.XmiId == xmiId && x.Name == name);
        }

        /// <summary>
        /// Gets or sets all the top-level <see cref="IPackage"/>s that have been read, this includes the Root
        /// </summary>
        /// <remarks>
        /// a top-level package is a package that is either the only package in the document when there is no
        /// <see cref="XmiRoot"/>> wrapper element, or a package that is directly contained by the <see cref="XmiRoot"/>
        /// </remarks>
        public List<IPackage> Packages { get; set; } = [];

        /// <summary>
        /// The <see cref="XmiRoot"/> that has been read
        /// </summary>
        /// <remarks>
        /// In case the root document does not contain a XMI element, an <see cref="XmiRoot"/>
        /// instance is created and set by the <see cref="XmiReader"/>
        /// </remarks>
        public XmiRoot XmiRoot { get; set; }
    }
}
