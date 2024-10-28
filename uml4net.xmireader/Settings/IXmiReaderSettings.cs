// -------------------------------------------------------------------------------------------------
//  <copyright file="IXmiReaderSettings.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Settings
{
    /// <summary>
    /// The <see cref="IXmiReaderSettings"/> interface defines settings the <see cref="Readers.XmiReader"/> requires in order to properly read
    /// </summary>
    public interface IXmiReaderSettings
    {
        /// <summary>
        /// Gets or sets the UML_PROFILES value, as a local file path to resolve pathmap references
        /// </summary>
        string UmlProfilesDirectoryPath {get;set;}

        /// <summary>
        /// Gets or sets the base directory path used as the local root for resolving referenced XMI files.
        /// </summary>
        string LocalReferenceBasePath { get; set; }
    }
}
