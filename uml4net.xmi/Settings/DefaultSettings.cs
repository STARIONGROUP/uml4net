// -------------------------------------------------------------------------------------------------
//  <copyright file="DefaultSettings.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;

    /// <summary>
    /// Represents the default settings for the XMI reader, including paths for UML profiles and the root directory.
    /// </summary>
    public class DefaultSettings : IXmiReaderSettings
    {
        /// <summary>
        /// Gets or sets the path specifications to resolve pathmap references.
        /// The keys are the pathmap string such as <code>pathmap://UML_PROFILES/primitives.xmi</code> to be used
        /// with the associated value in order to resolve the referenced xmi.
        /// </summary>
        public Dictionary<string, string> PathMaps { get; set; } = [];

        /// <summary>
        /// Gets or sets the base directory path used as the local root for resolving referenced XMI files.
        /// </summary>
        public string LocalReferenceBasePath { get; set; } = "";
    }
}
