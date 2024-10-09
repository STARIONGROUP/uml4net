// -------------------------------------------------------------------------------------------------
// <copyright file="IXmiReader.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi
{
    using System.Collections.Generic;
    using System.IO;

    using uml4net.POCO.Packages;

    /// <summary>
    /// The purpose of the <see cref="IXmiReader"/> is to provide a means to read (deserialize)
    /// an UML 2.5.1 model from XMI
    /// </summary>
    public interface IXmiReader
    {
        /// <summary>
        /// reads the content of a UML XMI 2.5.1 file
        /// </summary>
        /// <param name="fileUri">
        /// the path to the XMI file
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{IPackage}"/>
        /// </returns>
        IEnumerable<IPackage> Read(string fileUri);

        /// <summary>
        /// reads the content of a UML XMI 2.5.1 stream
        /// </summary>
        /// <param name="stream">
        /// the <see cref="Stream"/> that contains the XMI content
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{IPackage}"/>
        /// </returns>
        IEnumerable<IPackage> Read(Stream stream);
    }
}