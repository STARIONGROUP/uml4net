// -------------------------------------------------------------------------------------------------
//  <copyright file="IXmiReaderSettings.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Settings
{
    using System.Collections.Generic;

    /// <summary>
    /// The <see cref="IXmiReaderSettings"/> interface defines settings the <see cref="Readers.XmiReader"/> requires in order to properly read
    /// </summary>
    public interface IXmiReaderSettings
    {
        /// <summary>
        /// Gets or sets the path specifications to resolve pathmap references.
        /// The keys are the pathmap string such as <code>pathmap://UML_PROFILES/primitives.xmi</code> to be used
        /// with the associated value in order to resolve the referenced xmi.
        /// </summary>
        Dictionary<string, string> PathMaps { get; set; }

        /// <summary>
        /// Gets or sets the base directory path used as the local root for resolving referenced XMI files.
        /// </summary>
        string LocalReferenceBasePath { get; set; }

        /// <summary>
        /// Gets or sets the separator used to read properties serialized as a single string
        /// </summary>
        /// <remarks>
        /// The values of the Properties may be serialized as a single string separated by
        /// a separator, (by default by commas).
        /// </remarks>
        char[] ValueSeparator { get; set; }

        /// <summary>
        /// Gets or sets the separator used to read multivalued referenced properties serialized as a single string
        /// </summary>
        /// <remarks>
        /// The values of multivalued Properties may be serialized as a single string separated by
        /// a separator, (by default by single space).
        /// </remarks>
        char[] MultiReferenceValueSeparator { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether strict mode should be used while reading the document
        /// </summary>
        /// <remarks>
        /// When Strict Reading is set to true the reader will throw an exception if it encounters an unknown element or attribute.
        /// Otherwise, it will ignore the unknown element or attribute and log a warning.
        /// </remarks>
        bool UseStrictReading { get; set; }
    }
}
